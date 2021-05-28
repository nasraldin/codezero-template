using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CodeZero.Data;
using CodeZero.Domain;
using CodeZero.Domain.Mediator;
using CodeZero.Domain.Messaging;
using CodeZeroTemplate.Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace CodeZeroTemplate.Data.AppDbContext
{
    public class ApplicationDbContext : DbContext, IAppDbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IMediatorHandler _mediatorHandler;
#pragma warning restore IDE0052 // Remove unread private members

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediatorHandler mediatorHandler, IDomainEventDispatcher dispatcher) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            _dispatcher = dispatcher;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Log>? Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}