using Jenshin.Impack.API.Model;
using Binus.WS.Pattern.Entities;
using Binus.WS.Pattern.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Jenshin.Impack.API.Output;

namespace Jenshin.Impack.API.Helper
{
    public class ItemHelper
    {
        public static int AddNewItem(MsShopItem data)
        {
            // CODE HERE

            try
            {
                EntityHelper.Add(new MsShopItem(){
                    ItemName = data.ItemName,
                    ItemDescription = data.ItemDescription,
                    ItemPrice = data.ItemPrice,
                    GenesisCrystalOnly = data.GenesisCrystalOnly,
                    Stsrc = "A",
                    CreatedDt = DateTime.Now,
                    CreatedBy = "tester",

                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // END OF CODE
            return 1;
        }


        public static int UpdateItem(MsShopItem data)
        {
            var returnValue = new List<SpecificUser>();

            // CODE HERE

            try
            {
                if (string.IsNullOrEmpty(data.ItemID.ToString()))
                {
                    throw new Exception("EmptyArgument");
                }
                var newItems = EntityHelper.Get<MsShopItem>()
                    .Where(x => x.ItemID == data.ItemID).ToList();
                newItems.ForEach(x =>
                {
                    if(!string.IsNullOrEmpty(data.ItemName)) x.ItemName = data.ItemName;
                    if (!string.IsNullOrEmpty(data.ItemDescription)) x.ItemDescription = data.ItemDescription;
                    if (!string.IsNullOrEmpty(data.ItemPrice.ToString())) x.ItemPrice = data.ItemPrice;
                    if (!string.IsNullOrEmpty(data.GenesisCrystalOnly.ToString())) x.GenesisCrystalOnly = data.GenesisCrystalOnly;
                });

                EntityHelper.Update(newItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // END OF CODE
            return 1;
        }
    }
}