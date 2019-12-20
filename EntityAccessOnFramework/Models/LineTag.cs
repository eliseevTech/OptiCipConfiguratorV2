using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
    [Table("COURBES_BATCH_SONDES")]
    public class LineTag
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
        [Column("ID_STAT")]
        public int GroupId { get; set; }

        /// <summary>
        /// NOM_MAT
        /// </summary>
        [Column("ID_MAT")]
        public int StationId { get; set; }

        /// <summary>
        /// ID_RECORD
        /// </summary>
        [Column("ID_RECORD")]        
        public int LineId { get; set; }

        /// <summary>
        /// NO_OBJET
        /// </summary>
        [Column("NO_OBJET")]
        public int ObjectId { get; set; }

        /// <summary>
        /// ID_EQT
        /// </summary>
        [Column("ID_EQT")]
        public int TagId { get; set; }

        /// <summary>
        /// ID_RECORD
        /// </summary>
        [Column("ECH_VISIBLE")]
        public bool ShowScale { get; set; }

        /// <summary>
        /// GN_COLOR
        /// </summary>
        [Column("GN_COLOR")]
        public int Color { get; set; }

        /// <summary>
        /// TR_LINESTYLE , 0 by default
        /// </summary>
        [Column("TR_LINESTYLE")]
        public int LineStyle { get; set; }

        /// <summary>
        /// ширина линии
        /// TR_WIDTH
        /// </summary>
        [Column("TR_WIDTH")]
        public int Width { get; set; }

        /// <summary>
        /// TR_INTERPOL
        /// </summary>
        [Column("TR_INTERPOL")]
        public int TR_INTERPOL { get; set; }

        /// <summary>
        /// DIG_ENABLED
        /// </summary>
        [Column("DIG_ENABLED")]
        public bool IsDigital { get; set; }

        /// <summary>
        /// DIG_REFHIG
        /// </summary>
        [Column("DIG_REFHIG")]
        public int PositionHigh { get; set; }

        /// <summary>
        /// DIG_REFLOW
        /// </summary>
        [Column("DIG_REFLOW")]
        public double PositionLow { get; set; }

        /// <summary>
        /// DIG_REFSTYLE
        /// default 1
        /// </summary>
        [Column("DIG_REFSTYLE")]
        public int DIG_REFSTYLE { get; set; }


        /// <summary>
        /// DIG_HEIGHT
        /// for digital 1 \ for analog 0
        /// </summary>
        [Column("DIG_HEIGHT")]
        public double DIG_HEIGHT { get; set; }

    }
}
