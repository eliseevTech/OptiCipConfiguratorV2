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
        /// MODE_AFFICHAGE
        /// </summary>
        [Column("ID_RECORD")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// NOM_MAT
        /// </summary>
        [Column("NOM")]
        [MaxLength(50)]
        public string Name { get; set; }



        [Column("VERROU")]
        public bool WriteLock { get; set; }

        [Column("MODE_DECL")]
        public int Mode { get; set; }

        /// <summary>
        /// Добжен быть в формате PLC_GEA|LMK_GEA1_WS1_L1_Seq_Counter
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("DECL_ITEM1")]
        public string TagSequence { get; set; }

        /// <summary>
        /// Добжен быть в формате PLC_GEA|LMK_GEA1_WS1_L1_Object_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("DECL_ITEM2")]
        public string TagObject { get; set; }

        /// <summary>
        /// PLC_GEA|LMK_GEA1_WS1_L1_Recipe_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("PARAM_ITEM1")]
        public string TagRecipe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [RegularExpression("^NEP*")]
        [MaxLength(32)]
        [Column("MODE_EXPERT")]
        public string ExpertMode { get; set; }

        /// <summary>
        /// PLC_GEA|LMK_GEA1_WS1_L1_Product_Number
        /// </summary>
        [RegularExpression("^.+[|].+$")]
        [MaxLength(255)]
        [Column("PARAM_ITEM2")]
        public string TagProduct { get; set; }

   

        [RegularExpression("^GRP_RECORD*")]
        [MaxLength(20)]
        [Column("TYPE_BATCH")]
        public string GroupType { get; set; }

        [Column("CODE_EXPERT")]
        public short CODE_EXPERT { get; set; }

        /// <summary>
        /// TEMP=34|COND=33|FLOW=33|SL_AL1_EFF=10|SL_AL2_EFF=20
        /// </summary>
        [RegularExpression(@"^TEMP=\d+[|]COND=\d+[|]FLOW=\d+[|]SL_AL1_EFF=\d+[|]SL_AL2_EFF=\d+$")]
        [MaxLength(255)]
        [Column("PARAM_EXPERT")]
        public string PARAM_EXPERT { get; set; }

        /// <summary>
        /// PLC_GEA|LMK_GEA1_WS1_L1_Status
        /// </summary>
        [MaxLength(255)]
        [Column("PARAM_ITEM10")]
        public string PARAM_ITEM10 { get; set; }

        [MaxLength(255)]
        [Column("PARAM_ITEM11")]
        public string PARAM_ITEM11 { get; set; }

        [MaxLength(255)]
        [Column("PARAM_ITEM12")]
        public string PARAM_ITEM12 { get; set; }

        [MaxLength(255)]
        [Column("PARAM_ITEM13")]
        public string PARAM_ITEM13 { get; set; }

        [MaxLength(255)]
        [Column("PLC_LOCK1")]
        public string PLC_LOCK1 { get; set; }

        [MaxLength(255)]
        [Column("PLC_LOCK2")]
        public string PLC_LOCK2 { get; set; }

        [Column("GOLDEN_LOCK")]
        public bool GOLDEN_LOCK { get; set; }

        [Column("ID_DCO")]
        public short ID_DCO { get; set; }



    }
}
