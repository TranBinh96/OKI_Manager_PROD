using System.ComponentModel.DataAnnotations;

namespace Production.Models;

using System;

public class TypeLine
{
    [Key]
    public int Id { get; set; }
    public string? Type_name { get; set; }
    public string? Note { get; set; }
    public DateTime? Create_date { get; set; }
    public DateTime? Update_date { get; set; }
}
