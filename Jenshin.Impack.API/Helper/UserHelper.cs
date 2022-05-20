using Jenshin.Impack.API.Model;
using Binus.WS.Pattern.Entities;
//using Binus.WS.Pattern.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Jenshin.Impack.API.Output;


namespace Jenshin.Impack.API.Helper
{
    public class UserHelper
    {
        public static List<User> GetAllUser()
        {
            var returnValue = new List<User>();

            // CODE HERE

            try
            {
                var Items = EntityHelper.Get<MsUser>().ToList();
                returnValue = Items.Select(x => new User
                {
                    Name = x.UserName,
                    AdventureRank = x.UserAdventureRank,
                    Email = x.UserEmail,
                    Signature = x.UserSignature,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // END OF CODE

            return returnValue;
        }


        public static List<SpecificUser> GetSpecificUser(string Email, string Username)
        {
            var returnValue = new List<SpecificUser>();

            // CODE HERE

            try
            {
                // Function Validation
                // Ref: https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=net-6.0
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Username))
                {
                    throw new Exception("ConflictArgument");
                } else if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Username))
                {
                    throw new Exception("EmptyArgument");
                }

                var thisUser = new List<MsUser>();
                if(!string.IsNullOrEmpty(Username))
                {
                    thisUser = EntityHelper.Get<MsUser>(x => x.UserName == Username).ToList();
                } else if (!string.IsNullOrEmpty(Email))
                {
                    thisUser = EntityHelper.Get<MsUser>(x => x.UserEmail == Email).ToList();
                }

                var listUserBalance = EntityHelper.Get<MsUserBalance>().ToList();

                returnValue = thisUser.GroupJoin(
                        listUserBalance,
                        leftkey => leftkey.UserID,
                        rightkey => rightkey.UserID,
                        (leftdata, rightdata) => new SpecificUser()
                        {
                            ID = leftdata.UserID,
                            Name = leftdata.UserName,
                            Primogem = rightdata.Select(x => x.UserPrimogemAmount).First(),
                            GenesisCrystal = rightdata.Select(x => x.UserGenesisCrystalAmount).First(),
                        }).ToList();

                // https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-6.0
                if (!returnValue.Any())
                {
                    throw new Exception("NotFound");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // END OF CODE

            return returnValue;
        }
    }
}