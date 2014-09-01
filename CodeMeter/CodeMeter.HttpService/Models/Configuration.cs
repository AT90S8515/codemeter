using System.ComponentModel.DataAnnotations;

namespace CodeMeter.HttpService.Models
{
    public class Configuration : Entity
    {
        public int CheckInterval { get; set; }
        public int NotificationInterval { get; set; }
        public bool CheckRunning { get; set; }
        public bool SendSms { get; set; }
        public bool SendEmail { get; set; }
        [StringLength(255)]
        public string Recepient { get; set; }
        [StringLength(255)]
        public string Sender { get; set; }

        [StringLength(255)]
        public string Smtp { get; set; }
        public int Port { get; set; }
        [StringLength(255)]
        public string Username { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public bool Ssl { get; set; }
    }
}