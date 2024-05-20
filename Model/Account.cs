using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? no { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? pincode { get; set; }
        public string? address { get; set; }
        public decimal  balance { get; set; }

    }
}