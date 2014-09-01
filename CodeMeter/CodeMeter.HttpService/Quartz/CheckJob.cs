using System;
using System.Net;
using System.Net.Mail;
using CodeMeter.HttpService.Models;
using Quartz;
using System.Linq;

namespace CodeMeter.HttpService.Quartz
{
    public class CheckJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var c = new DataContext())
            {
                var cfg = c.Configurations.Single();
                if (cfg.CheckRunning && (cfg.SendEmail || cfg.SendSms))
                {
                    var running = c.TaskLogs.Where(x => !x.End.HasValue);
                    var now = DateTime.Now;
                    foreach (var taskLog in running)
                    {
                        var timeRunning = (int)now.Subtract(taskLog.Start.Value).TotalMinutes;
                        if (timeRunning > cfg.NotificationInterval)
                        {
                            if (cfg.SendEmail)
                            {
                                try
                                {
                                    using (var smtp = new SmtpClient(cfg.Smtp, cfg.Port))
                                    {
                                        smtp.EnableSsl = cfg.Ssl;
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = new NetworkCredential(cfg.Username, cfg.Password);

                                        var mail = new MailMessage(cfg.Sender, cfg.Recepient)
                                        {
                                            Subject = "CodeMeter Notification",
                                            Body = "Task " + taskLog.TaskID + " is running for " + timeRunning + " minutes"
                                        };
                                        smtp.Send(mail);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (cfg.SendSms)
                            {
                                
                            }
                        }
                    }
                }
            }
        }
    }
}