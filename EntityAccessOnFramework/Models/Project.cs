using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
    [Table("PRO_PROJETS")]
    public class Project
    {
        /// <summary>
        /// ID_PROJ
        /// </summary>
        [Column("ID_PROJ")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID_SETUP
        /// </summary>
        [Column("ID_SETUP")]
        public int SetupId { get; set; }

        /// <summary>
        /// NOM_PROJET
        /// </summary>
        [Column("NOM_PROJET")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// DESCRIPTION
        /// </summary>
        [Column("DESCRIPTION")]
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// ACTIF_RECORD
        /// </summary>
        [Column("ACTIF_RECORD")]
        public bool? ACTIF_RECORD { get; set; }

        /// <summary>
        /// ACTIF_VIEWER
        /// </summary>
        [Column("ACTIF_VIEWER")]
        public bool? ACTIF_VIEWER { get; set; }

        /// <summary>
        /// ACTIF_CONFIG
        /// </summary>
        [Column("ACTIF_CONFIG")]
        public bool? ACTIF_CONFIG { get; set; }
    

           
    }
}
