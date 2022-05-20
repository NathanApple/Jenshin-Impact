using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jenshin.Impack.API.Model.Request
{
    public class PurchaseRequestDTO
    {
        public Guid UserID { get; set; }
        public Guid ItemID { get; set; }
        public int Amount { get; set; }
    }
}
