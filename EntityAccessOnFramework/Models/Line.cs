using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
   [Table("COURBES_BATCH_GEN")]
    public class Line
    {        

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
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// NOM
        /// </summary>
        [Column("NOM")]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// VERROU
        /// </summary>
        [Column("VERROU")]
        public bool Lock { get; set; }

        /// <summary>
        /// MODE_DECL
        /// </summary>
        [Column("MODE_DECL")]
        public int Mode { get; set; }

        /// <summary>
        /// DECL_ITEM1
        /// Добжен быть в формате PLC_GEA|LMK_GEA1_WS1_L1_Seq_Counter
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("DECL_ITEM1")]
        public string TagSequence { get; set; }

        /// <summary>
        /// DECL_ITEM2
        /// Добжен быть в формате PLC_GEA|LMK_GEA1_WS1_L1_Object_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("DECL_ITEM2")]
        public string TagObject { get; set; }

        /// <summary>
        /// PARAM_ITEM1
        /// PLC_GEA|LMK_GEA1_WS1_L1_Recipe_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("PARAM_ITEM1")]
        public string TagRecipe { get; set; }

        /// <summary>
        /// MODE_EXPERT
        /// </summary>
        [RegularExpression("^NEP*")]
        [MaxLength(32)]
        [Column("MODE_EXPERT")]
        public string ExpertMode { get; set; }

        /// <summary>
        /// PARAM_ITEM2
        /// PLC_GEA|LMK_GEA1_WS1_L1_Product_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("PARAM_ITEM2")]
        public string TagProduct { get; set; }

        /// <summary>
        /// GroupType
        /// Allowed value = GRP_RECORD
        /// </summary>
        [RegularExpression("^GRP_RECORD*")]
        [MaxLength(20)]
        [Column("TYPE_BATCH")]
        public string GroupType { get; set; }

        /// <summary>
        /// CODE_EXPERT
        /// </summary>
        [Column("CODE_EXPERT")]
        public short CODE_EXPERT { get; set; }

        /// <summary>
        /// PARAM_EXPERT
        /// TEMP=34|COND=33|FLOW=33|SL_AL1_EFF=10|SL_AL2_EFF=20
        /// </summary>
        [RegularExpression(@"^TEMP=\d+[|]COND=\d+[|]FLOW=\d+[|]SL_AL1_EFF=\d+[|]SL_AL2_EFF=\d+$")]
        [MaxLength(255)]
        [Column("PARAM_EXPERT")]
        public string ExpertProperties { get; set; }

        /// <summary>
        /// PARAM_ITEM10
        /// PLC_GEA|LMK_GEA1_WS1_L1_Status
        /// </summary>
        [MaxLength(255)]
        [Column("PARAM_ITEM10")]
        public string TagStatus { get; set; }

        /// <summary>
        /// PARAM_ITEM11
        /// </summary>
        [MaxLength(255)]
        [Column("PARAM_ITEM11")]
        public string PARAM_ITEM11 { get; set; }

        /// <summary>
        /// PARAM_ITEM12
        /// </summary>
        [MaxLength(255)]
        [Column("PARAM_ITEM12")]
        public string PARAM_ITEM12 { get; set; }

        /// <summary>
        /// PARAM_ITEM13
        /// </summary>
        [MaxLength(255)]
        [Column("PARAM_ITEM13")]
        public string PARAM_ITEM13 { get; set; }

        /// <summary>
        /// PLC_LOCK1
        /// </summary>
        [MaxLength(255)]
        [Column("PLC_LOCK1")]
        public string PLC_LOCK1 { get; set; }

        /// <summary>
        /// PLC_LOCK2
        /// </summary>
        [MaxLength(255)]
        [Column("PLC_LOCK2")]
        public string PLC_LOCK2 { get; set; }

        /// <summary>
        /// GOLDEN_LOCK
        /// </summary>
        [Column("GOLDEN_LOCK")]
        public bool GOLDEN_LOCK { get; set; }

        /// <summary>
        /// ID_DCO
        /// </summary>
        [Column("ID_DCO")]
        public short ID_DCO { get; set; }



    }
}
