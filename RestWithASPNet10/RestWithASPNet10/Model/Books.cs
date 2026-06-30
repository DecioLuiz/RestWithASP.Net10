using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNet10.Model
{
    [Table("books")]
    public class Books
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("title", TypeName = "varchar(MAX)")]
        public string Title { get; set; }
        [Column("author", TypeName = "varchar(MAX)")]
        public string Author { get; set; }
        [Required]
        [Column("price")]
        public Decimal Price { get; set; }
        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
