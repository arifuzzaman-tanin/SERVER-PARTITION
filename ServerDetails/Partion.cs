namespace ServerDetails
{
    public class PartionHelper
    {
        public string? PartionName { get; set; }
        public double TotalSpace { get; set; }
        public double AvailableSpace { get; set; }
    }

    public static class Partion
    {
        public static List<PartionHelper> Spaces()
        {
            List<PartionHelper> partionHelper = new List<PartionHelper>();
            try
            {
                DriveInfo[] myDrives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in myDrives)
                {
                    //Console.WriteLine("Drive: {0} ({1}, {2})",
                    //    drive.Name, drive.DriveFormat, drive.DriveType);

                    if (drive.IsReady == true)
                    {
                        // Calculate the percentage free space
                        double freeSpacePerc =
                            (drive.AvailableFreeSpace / (float)drive.TotalSize) * 100;

                        // Ouput drive information
                        //Console.WriteLine("\tFree space:\t{0}",
                        //    drive.AvailableFreeSpace);
                        //Console.WriteLine("\tTotal space:\t{0}",
                        //    drive.TotalSize);

                        //Console.WriteLine("\n\tPercentage free space: {0:0.00}%.",
                        //    freeSpacePerc);

                        partionHelper.Add(new PartionHelper
                        {
                            PartionName = drive.Name,
                            TotalSpace = drive.TotalSize,
                            AvailableSpace = drive.AvailableFreeSpace,
                        });
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return partionHelper;
        }
    }
}

