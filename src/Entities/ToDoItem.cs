using CodeZero.Domain;
using CodeZero.Domain.Entities;
using Entities.Events;

namespace Entities
{
    public class ToDoItem : BaseEntity<int>, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;

            AddDomainEvent(new ToDoItemCompletedEvent(this));
        }

        public override string ToString()
        {
            string status = IsDone ? "Done!" : "Not done.";
            return $"{Id}: Status: {status} - {Title} - {Description}";
        }

        protected sealed override bool Validate() => false;
    }
}