using Binus.WS.Pattern.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jenshin.Impack.API.Output
{
    public class ItemOutput : OutputBase
    {
        public ItemOutput()
        {
            this.Success = 0;
        }
        public int Success { get; set; }
    }
}
