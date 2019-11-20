using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
   [Table("PRO_GROUPES")]
    public class Station
    {        
        /// <summary>
        /// ID_PROJ
        /// </summary>
        [Column("ID_PROJ")]
        public int ProjectId { get; set; }

        /// <summary>
        /// ID_STAT
        /// </summary>
        [Column("ID_STAT")]
        public int GroupId { get; set; }

        /// <summary>
        /// ID_MAT  
        /// </summary>
        [Key]
        [Column("ID_MAT")]
        public int Id { get; set; }

        /// <summary>
        /// NOM_MAT
        /// </summary>
        [Column("NOM_MAT")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// TYPE_MAT
        /// </summary>
        [Column("TYPE_MAT")]
        [MaxLength(15)]
        [RegularExpression("^LIGNE*")]
        public string Type { get; set; }
    }
}
