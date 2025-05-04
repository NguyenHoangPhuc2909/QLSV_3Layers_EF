using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3Layers_EF.DAL
{
    [Table("Diem")]
    public class Diem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }

        [Required]
        public string MSSV { get; set; }

        [ForeignKey("MSSV")]
        public virtual SV Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual MonHoc Course { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        [StringLength(20)]
        public string Semester { get; set; }
    }
}