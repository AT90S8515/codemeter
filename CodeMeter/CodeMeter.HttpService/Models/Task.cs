using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CodeMeter.HttpService.Models
{
    public class Task : Entity
    {
        public Task()
        {
            Logs = new Collection<TaskLog>();
        }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(2048)]
        public string Description { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public bool IsRunning { get; set; }
        public ICollection<TaskLog> Logs { get; set; }
        [NotMapped]
        public DateTime? StartTime { get; set; }
        [NotMapped]
        public DateTime? EndTime { get; set; }
        [NotMapped]
        public int ElapsedSeconds { get; set; }
        internal void SetStartAndEnd()
        {
            var first = Logs.FirstOrDefault();
            var last = Logs.LastOrDefault();
            StartTime = first != null ? first.Start : null;
            EndTime = last != null && last.End.HasValue ? last.End.Value : (DateTime?) null;
            if (StartTime == null || EndTime == null)
            {
                return;
            }
            ElapsedSeconds = (int)EndTime.Value.Subtract(StartTime.Value).TotalSeconds;
        }
    }
}