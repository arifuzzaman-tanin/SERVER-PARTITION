using System.Configuration;

namespace ServerDetails
{
    public class OptionHelper
    {
        public string? ServiceName { get; set; }
        public bool IsEnabled { get; set; }
    }
    public static class NotificationService
    {
        public static List<OptionHelper> NotificationOptions()
        {
            var isEmailEnabled = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get(ServiceName.Email));
            var isTGBotEnabled = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get(ServiceName.TGBot));
            var isSpecialEnabled = Convert.ToBoolean(ConfigurationSettings.AppSettings.Get(ServiceName.Special));

            List<OptionHelper> options = new List<OptionHelper>();

            if (isEmailEnabled)
            {
                options.Add(new OptionHelper
                {
                    ServiceName = ServiceName.Email,
                    IsEnabled = true
                });
            }

            if (isTGBotEnabled)
            {
                options.Add(new OptionHelper
                {
                    ServiceName = ServiceName.TGBot,
                    IsEnabled = true
                });
            }

            if (isSpecialEnabled)
            {
                options.Add(new OptionHelper
                {
                    ServiceName = ServiceName.Special,
                    IsEnabled = true
                });
            }

            return options;
        }

        public static void SendNotification(List<PartionHelper> partionHelpers)
        {
            foreach (var option in NotificationService.NotificationOptions())
            {
                if (option.ServiceName == ServiceName.Email)
                {
                    Console.WriteLine("Email Send: " + partionHelpers);
                }

                if (option.ServiceName == ServiceName.TGBot)
                {
                    Console.WriteLine("TGBot Send: " + partionHelpers);
                }

                if (option.ServiceName == ServiceName.Special)
                {
                    Console.WriteLine("Special Send: " + partionHelpers);
                }
            }
        }
    }
}
