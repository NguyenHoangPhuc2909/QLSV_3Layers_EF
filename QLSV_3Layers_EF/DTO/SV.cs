using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLSV_3Layers_EF.DAL
{
    [Table("SinhVien")]
    public class SV
    {
        public SV()
        {
            Grades = new HashSet<Diem>();
        }

        [Key]
        [Required]
        [StringLength(50)]
        public string MSSV { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual LSH Class { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        // Thiết lập đúng cho quan hệ 1-1 với Nguoidung
        [Required]
        public string Username { get; set; }

        public virtual Nguoidung Nguoidung { get; set; }

        public virtual ICollection<Diem> Grades { get; set; }
    }
}