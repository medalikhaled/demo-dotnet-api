using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Pizza
{


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
     
    public DateTime createdAt { get; set; } = DateTime.Now; 
}
