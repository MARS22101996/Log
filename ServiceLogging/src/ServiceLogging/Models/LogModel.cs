using System;

namespace ServiceLogging.Models
{
    public class LogModel
    {
        public string ServiceName { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        public Guid CorrelationId { get; set; }

        public string Logger { get; set; }
    }
}
