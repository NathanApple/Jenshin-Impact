using Jenshin.Impack.API.Model;
using Binus.WS.Pattern.Entities;
using Binus.WS.Pattern.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Jenshin.Impack.API.Output;
using Jenshin.Impack.API.Model.Request;

namespace Jenshin.Impack.API.Helper
{
    public class PurchaseHelper
    {
        public static string PurchaseItem(PurchaseRequestDTO data)
        {
            string message = "";
            // CODE HERE

            try
            {
                if (string.IsNullOrEmpty(data.UserID.ToString())|| string.IsNullOrEmpty(data.ItemID.ToString())|| string.IsNullOrEmpty(data.Amount.ToString()))
                {
                    throw new Exception("EmptyArgument");
                }

                if (data.Amount <= 0)
                {
                    throw new Exception("Amount is not a valid number");
                }

                var userBalance = EntityHelper.Get<MsUserBalance>().
                    Where(x => x.UserID == data.UserID).FirstOrDefault();
                var item = EntityHelper.Get<MsShopItem>().
                    Where(x => x.ItemID == data.ItemID).FirstOrDefault();

                if (userBalance == null || item == null)
                {
                    throw new Exception("NotFound");
                }

                var totalPrice = item.ItemPrice * data.Amount;
                // Check if gems is enough
                if ((userBalance.UserPrimogemAmount + userBalance.UserGenesisCrystalAmount) >= totalPrice)
                {

                    // Check if primogem is higher than price
                    if (userBalance.UserPrimogemAmount >= totalPrice)
                    {
                        userBalance.UserPrimogemAmount = userBalance.UserPrimogemAmount - totalPrice;
                    } else
                    {
                        userBalance.UserGenesisCrystalAmount = (userBalance.UserPrimogemAmount + userBalance.UserGenesisCrystalAmount) - totalPrice;
                        userBalance.UserPrimogemAmount = 0;
                    }

                    var Transaction = EntityHelper.Add(new TrUserPurchase
                    {
                        UserID = data.UserID,
                        ItemID = data.ItemID,
                        PurchaseAmount = data.Amount
                    });
                    EntityHelper.Update(userBalance);
                    message = "Purchase Successfull";


                }
                else
                {
                    message = "Insufficient Funds";
                }




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // END OF CODE
            return message;
        }
    }
}