namespace Production.Models;

using System;

public class DiskInfo
{
    public string IP { get; set; }
    public string HostName { get; set; }
    public string DiskScan { get; set; }
    public string Size { get; set; }
    public string DiskUse { get; set; }
    public string RemainingDiskSpaceDescription { get; set; }
    public string CreateTime { get; set; } // Assuming you want to store it as string
    public string UpdateTime { get; set; } // Assuming you want to store it as string

}
