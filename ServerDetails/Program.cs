using ServerDetails;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
        var diskSpaces = Partion.Spaces();
        NotificationService.SendNotification(diskSpaces);
    }
}