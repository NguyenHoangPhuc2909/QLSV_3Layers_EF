using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3Layers_EF.DAL
{
    [Table("MonHoc")]
    public class MonHoc
    {
        public MonHoc()
        {
            Grades = new HashSet<Diem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required]
        public int Credits { get; set; }

        public virtual ICollection<Diem> Grades { get; set; }
    }
}