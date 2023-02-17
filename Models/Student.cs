using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

public class Student
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string Specialty { get; set; } 

}