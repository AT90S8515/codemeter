using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        [NotMapped]
        public int TotalTime { get; set; }

        [NotMapped]
        public decimal Total { get; set; }

        public void SetTotals()
        {
            if (Tasks == null) return;
            foreach (var task in Tasks)
            {
                task.SetStartAndEnd();
            }
            TotalTime = Tasks.Sum(x => x.ElapsedSeconds);
            Total = Price*TotalTime/3600M;
        }
    }
}