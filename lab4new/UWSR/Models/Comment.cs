using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UWSR.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SessionId { get; set; }
        public DateTime Stamp { get; init; } = DateTime.Now;
        public string Text { get; set; }
        public Link Link { get; set; }
    }
}
