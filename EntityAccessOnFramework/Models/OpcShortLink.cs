using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAccessOnFramework.Models
{
    [Table("LIENS_OPC")]
    public class OpcShortLink
    {
        /// <summary>
        /// ID_EQT
        /// </summary>
        [Column("ID_PROJ")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// LIEN (short link name)
        /// </summary>
        [MaxLength(32)]
        [Column("LIEN")]
        public string Name { get; set; }

        /// <summary>
        /// PC (адрес Opc сервера)
        /// </summary>
        [Column("PC")]
        [MaxLength(50)]
        public string PcAddress { get; set; } = "(Local)";

        /// <summary>
        /// SERVER (OPC server name)
        /// </summary>
        [Column("SERVER")]
        [MaxLength(50)]
        public string OpcServer { get; set; }

        /// <summary>
        /// GROUPE ( значения например GRP_PLC_BRINOX)
        /// </summary>
        [Column("GROUPE")]
        [MaxLength(50)]
        public string GROUPE { get; set; }

        /// <summary>
        /// ACTIF
        /// </summary>
        [Column("ACTIF")]
        public bool IsActive { get; set; }

        /// <summary>
        /// UPDATE_RATE is MS
        /// </summary>
        [Column("UPDATE_RATE")]
        public int UpdateRate { get; set; }

        /// <summary>
        /// PREFIXE_ITEM
        /// </summary>
        [Column("PREFIXE_ITEM")]
        [MaxLength(32)]
        public string PREFIXE_ITEM { get; set; }

        /// <summary>
        /// KEY_SERVER
        /// </summary>
        [Column("KEY_SERVER")]
        [MaxLength(20)]
        public string KEY_SERVER { get; set; }


        /// <summary>
        /// NGRP
        /// </summary>
        [Column("NGRP")]
        public int NGRP { get; set; }
    }
}
