using System.ComponentModel.DataAnnotations;

namespace Production.Models;

public class Line
{
    [Key]
    public int Id { get; set; }
    public string line_name { get; set; }
    public string Note { get; set; }
    public string Manager { get; set; }
}