using System;
using System.Collections.Generic;

namespace CodeMeter.HttpService.Models
{
    public class Project : Entity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}