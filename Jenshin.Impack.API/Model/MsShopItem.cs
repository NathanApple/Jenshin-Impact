using Binus.WS.Pattern.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jenshin.Impack.API.Model
{
    [DatabaseName("JenshinDB")]
    [Table("MsShopItem")]
    public class MsShopItem : BaseModel
    {
        [Column("ItemID")]
        [Key]
        public Guid ItemID { get; set; }
        [Column("ItemName")]
        public string ItemName { get; set; }
        [Column("ItemDescription")]
        public string ItemDescription { get; set; }
        [Column("ItemPrice")]
        public int ItemPrice { get; set; }
        [Column("GenesisCrystalOnly")]
        public bool GenesisCrystalOnly { get; set; }
        [Column("Stsrc")]
        public string Stsrc { get; set; }
        [Column("UpdatedDt")]
        public DateTime? UpdatedDt { get; set; }
        [Column("UpdatedBy")]
        public string UpdatedBy { get; set; }
        [Column("CreatedDt")]
        public DateTime? CreatedDt { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
    }
}
