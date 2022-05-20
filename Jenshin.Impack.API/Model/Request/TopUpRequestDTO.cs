using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jenshin.Impack.API.Model.Request
{
    public class TopUpRequestDTO
    {
        public string Email { get; set; }
        public int Amount { get; set; }
    }
}
