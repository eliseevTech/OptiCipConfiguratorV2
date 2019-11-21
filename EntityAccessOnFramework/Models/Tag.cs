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

        /// <summary>
        /// LIEN
        /// </summary>
        [Column("LIEN")]
        [MaxLength(32)]
        public string OpcShortLink { get; set; }

        /// <summary>
        /// ITEM
        /// </summary>
        [Column("ITEM")]
        [MaxLength(50)]
        public string OpcItem { get; set; }

        /// <summary>
        /// LIBELLE
        /// </summary>
        [Column("LIBELLE")]
        [MaxLength(50)]
        public string Label { get; set; }

        /// <summary>
        /// UNITE
        /// </summary>
        [Column("UNITE")]
        [MaxLength(10)]
        public string Unit { get; set; }


        /// <summary>
        /// MISE_ECHELLE
        /// </summary>
        [Column("MISE_ECHELLE")]
        public bool? MISE_ECHELLE { get; set; }

        /// <summary>
        /// MIN_API
        /// </summary>
        [Column("MIN_API")]
        public int? MapMin { get; set; }

        /// <summary>
        /// MAX_API
        /// </summary>
        [Column("MAX_API")]
        public int? MapMax{ get; set; }

        /// <summary>
        /// MIN_API
        /// </summary>
        [Column("MIN_PHYS")]
        public double? PhysicalMin { get; set; }

        /// <summary>
        /// MAX_API
        /// </summary>
        [Column("MAX_PHYS")]
        public double? PhysicalMax { get; set; }

        /// <summary>
        /// CODE_TRAITEMENT
        /// </summary>
        [Column("CODE_TRAITEMENT")]
        public short? CODE_TRAITEMENT { get; set; }

        /// <summary>
        /// PRECIS
        /// </summary>
        [Column("PRECIS")]
        public short? PRECIS { get; set; }

    }
}
