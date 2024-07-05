using System.ComponentModel.DataAnnotations;

namespace Production.Models;

using System;

public class ComputerResponse
{
    public int? Id { get; set; }
    public string? Station { get; set; }
    public string? HostName { get; set; }
    public string? IP { get; set; }
    public int? Rage { get; set; }
    public int? Type_Id { get; set; }
    public int? Unit_Id { get; set; }
    public int? Line_Id { get; set; }
    public string? Note { get; set; }
    public int? Running { get; set; }
    public string? CreateDate { get; set; }
    public string? UpdateDate { get; set; }

    public static string FormatDateTime(DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null;
    }
}
