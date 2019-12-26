using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
   [Table("PRO_ATELIERS")]
    public class Group
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
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// NOM_MAT
        /// </summary>
        [Column("NOM_STAT")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// MODE_AFFICHAGE
        /// </summary>
        [Column("MODE_AFFICHAGE")]
        public short? ModeAffichage { get; set; }
    }
}
