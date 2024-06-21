using System.ComponentModel.DataAnnotations;

namespace Production.Models;

using System;

public class Computer_Production
{
    [Key]
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
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
