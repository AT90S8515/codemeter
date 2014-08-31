using System;

namespace CodeMeter.HttpService.Models
{
    public class TaskLog : Entity
    {
        public Task Task { get; set; }
        public int TaskID { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        //public int Elapsed
        //{
        //    get
        //    {
        //        if (!Start.HasValue) return 0;
        //        var end = End.HasValue ? End.Value : DateTime.Now;
        //        return (int)end.Subtract(Start.Value).TotalSeconds;
        //    }
        //}
    }
}