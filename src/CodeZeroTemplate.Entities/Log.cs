using System;
using CodeZero.Domain.Entities;

namespace CodeZeroTemplate.Entities
{
    public class Log : BaseEntity<long>
    {
        /// <summary>
        /// Gets or sets the Logged date.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public string? Environment { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        public string? Application { get; set; }

        /// <summary>
        /// Gets or sets the RequestMethod.
        /// </summary>
        public string? RequestMethod { get; set; }

        /// <summary>
        /// Gets or sets the RequestPath.
        /// </summary>
        public string? RequestPath { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public string? Level { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        public string? Exception { get; set; }

        /// <summary>
        /// Gets or sets the exception data.
        /// </summary>
        public string? ExceptionDetail { get; set; }

        /// <summary>
        /// Gets or sets the Properties data for Serilog.
        /// </summary>
        public string? Properties { get; set; }

        /// <summary>
        /// Gets or sets the exception Source.
        /// </summary>
        public string? Source { get; set; }

        /// <summary>
        /// Gets or sets the exception type.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets the ClientAgent.
        /// </summary>
        public string? ClientAgent { get; set; }

        /// <summary>
        /// Gets or sets the IP Address.
        /// </summary>
        public string? ClientIp { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string? User { get; set; }

        protected sealed override bool Validate() => false;
    }
}