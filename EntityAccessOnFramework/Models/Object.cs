using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
   [Table("COURBES_BATCH_DET")]
    public class LineObject
    {
        /// <summary>
        /// ID_PROJ
        /// </summary>
        [Key]
        [Column("ID_PROJ")]
        public int ProjectId { get; set; }

        /// <summary>
        /// ID_STAT
        /// </summary>
        [Key]
        [Column("ID_STAT")]
        public int GroupId { get; set; }

        /// <summary>
        /// ID_MAT
        /// </summary>
        [Key]
        [Column("ID_MAT")]
        public int StationId { get; set; }

        /// <summary>
        /// ID_RECORD
        /// </summary>
        [Key]
        [Column("ID_RECORD")]
        public int LineId { get; set; }

        /// <summary>
        /// NO_OBJET
        /// </summary>
        [Key]
        [Column("NO_OBJET")]
        public int Id { get; set; }

        /// <summary>
        /// NOM_OBJET
        /// </summary>
        [Column("NOM_OBJET")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// FREQ
        /// Record period in milliseconds
        /// </summary>
        [Column("FREQ")]
        public int RecordPeriod { get; set; }

        /// <summary>
        /// XSPAN
        /// Start time range
        /// </summary>
        [Column("XSPAN")]
        public int TrendStartTimeRange { get; set; }

        /// <summary>
        /// SEUIL_1_COMPTEURS
        /// first threshold of loses
        /// </summary>
        [Column("SEUIL_1_COMPTEURS")]
        public int? LosesThreshold1 { get; set; }

        /// <summary>
        /// SEUIL_2_COMPTEURS
        /// first threshold of loses
        /// </summary>
        [Column("SEUIL_2_COMPTEURS")]
        public int? LosesThreshold2 { get; set; }

        [Column("VERROU")]
        public bool Lock { get; set; }

        /// <summary>
        /// PROPERTIES_1
        /// CT_CTRL_COND=1|TP_CTRL_COND=0|SL_AL1_cond=1500|SL_AL2_cond=2000
        /// </summary>
        [Column("PROPERTIES_1")]
        [RegularExpression(@"^CT_CTRL_COND=\d+[|]TP_CTRL_COND=\d+[|]SL_AL1_cond=\d+[|]SL_AL2_cond=\d+$")]
        public string Properties { get; set; }

        /// <summary>
        /// START_ANA_PERCENT
        /// </summary>
        [Column("START_ANA_PERCENT")]
        public short? START_ANA_PERCENT { get; set; }

        /// <summary>
        /// FLOW_THEO
        /// Теоретический поток
        /// </summary>
        [Column("FLOW_THEO")]
        public int? TheoreticFlow { get; set; }

        /// <summary>
        /// TYPE_OBJET
        /// </summary>
        [Column("TYPE_OBJET")]
        [MaxLength(12)]
        public string ObjecType { get; set; }

        /// <summary>
        /// PARAM_EXPERT
        /// </summary>
        [Column("PARAM_EXPERT")]
        [MaxLength(255)]
        public string PARAM_EXPERT { get; set; }

        /// <summary>
        /// IMPRIME_AUTO
        /// по умолчанию false
        /// </summary>
        [Column("IMPRIME_AUTO")]
        public bool IMPRIME_AUTO { get; set; }

        /// <summary>
        /// GOLDEN_LOCK
        /// по умолчанию false
        /// </summary>
        [Column("GOLDEN_LOCK")]
        public bool GOLDEN_LOCK { get; set; }

        /// <summary>
        /// TIME_LOOP
        /// по умолчанию false
        /// </summary>
        [Column("TIME_LOOP")]
        public int? TIME_LOOP { get; set; }
    }
}
