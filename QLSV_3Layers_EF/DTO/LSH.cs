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
    public class LSH
    {
        public LSH()
        {
            SVs = new HashSet<SV>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string ClassName { get; set; }

        public virtual ICollection<SV> SVs { get; set; }
    }
}