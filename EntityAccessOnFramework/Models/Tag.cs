using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
    [Table("SONDES")]
    public class Tag
    {
        /// <summary>
        /// ID_EQT
        /// </summary>
        [Column("ID_EQT")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID_PROJ
        /// </summary>
        [Column("ID_PROJ")]
        public int ProjectId { get; set; }

        /// <summary>
        /// NOM
        /// </summary>
        [Column("NOM")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// ALIAS_NOM
        /// </summary>
        [Column("ALIAS_NOM")]
        [MaxLength(50)]
        public string Alias { get; set; }

        /// <summary>
        /// ALIAS_NOM
        /// </summary>
        [Column("TYPE_EQT")]
        [MaxLength(15)]
        public string Type { get; set; }

        ///// <summary>
        ///// ALIAS_NOM
        ///// </summary>
        //[Column("LIEN")]
        //[MaxLength(15)]
        //public string OpcLink { get; set; }

    }
}
