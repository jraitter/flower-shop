using System.ComponentModel.DataAnnotations;

namespace mysql.Models
{
  public class Flower
  {
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    public string Name { get; set; }
    public float Price { get; set; }

  }
}