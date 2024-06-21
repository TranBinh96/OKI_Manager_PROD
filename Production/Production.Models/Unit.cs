using System.ComponentModel.DataAnnotations;

namespace Production.Models;


public class Unit
{
    [Key]
    public int Id { get; set; }
    public string? unit_name { get; set; }
    public int? line_id { get; set; }
    public string? Note { get; set; }
}