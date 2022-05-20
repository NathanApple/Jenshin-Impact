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
    [Table("MsUserBalance")]
    public class MsUserBalance : BaseModel
    {
        [Column("UserID")]
        [Key]
        public Guid UserID { get; set; }
        [Column("UserPrimogemAmount")]
        public int UserPrimogemAmount { get; set; }
        [Column("UserGenesisCrystalAmount")]
        public int UserGenesisCrystalAmount { get; set; }
    }
}
