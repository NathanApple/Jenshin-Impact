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
    public class TopUpHelper
    {
        public static string TopUp(TopUpRequestDTO data)
        {
            string message = "";
            // CODE HERE

            try
            {
                if (string.IsNullOrEmpty(data.Email.ToString()))
                {
                    throw new Exception("EmptyArgument");
                }

                var users = EntityHelper.Get<MsUser>().
                    Where(x => x.UserEmail == data.Email).ToList();

                if (!users.Any())
                {
                    throw new Exception("NotFound");
                }
                users.ForEach(x =>
               {
                   var userBalance = EntityHelper.Get<MsUserBalance>()
                    .Where(y => y.UserID == x.UserID).FirstOrDefault();

                   userBalance.UserGenesisCrystalAmount = userBalance.UserGenesisCrystalAmount + data.Amount;

                   EntityHelper.Update(userBalance);

               });
                message = data.Amount + " Genesis Crystal has been topped up to " + data.Email;

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