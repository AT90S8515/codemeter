using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeMeter.HttpService.Models
{
    public class Project : Entity
    {
        public Guid Guid { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Client { get; set; }
        [StringLength(2048)]
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; }
        [Range(0, 1000)]
        public int Price { get; set; }
    }
}