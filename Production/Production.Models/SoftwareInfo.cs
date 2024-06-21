namespace Production.Models;

using System;

public class SoftwareInfo
{
    public int Id { get; set; }
    public string IP { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string Version { get; set; }
    public string CreateTime { get; set; } // Assuming you want to store it as string
    public string UpdateTime { get; set; } // Assuming you want to store it as string
}
