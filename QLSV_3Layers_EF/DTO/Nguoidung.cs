using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3Layers_EF.DAL
{
    public class Nguoidung
    {
        public Nguoidung()
        {
        }

        [Key]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // admin, student

        public virtual SV SinhVien { get; set; }
    }
}
