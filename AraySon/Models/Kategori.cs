using System.ComponentModel.DataAnnotations.Schema;

namespace AraySon.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
}
