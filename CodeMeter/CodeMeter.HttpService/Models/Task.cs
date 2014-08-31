namespace CodeMeter.HttpService.Models
{
    public class Task : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Project Project { get; set; }
        public int ProjectID { get; set; }
    }
}