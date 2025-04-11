using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models;

[Table("Books")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(255)] public string Title { get; set; } = string.Empty;

    [Required] public int PublicationYear { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public Author? Author { get; set; }
}