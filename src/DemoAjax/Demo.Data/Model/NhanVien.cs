using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Model
{
    [Table("NhanVien")]
   public class NhanVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Required]
        public string TenNhanVien { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Required]
        public string DiaChi { get; set; }
        [StringLength(12)]
        [Column(TypeName = "varchar")]

        public string SoDienThoai { get; set; }
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Email { get; set; }
        public int Tuoi { get; set; }
    }
}

