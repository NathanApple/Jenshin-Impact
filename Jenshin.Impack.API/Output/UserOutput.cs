using Binus.WS.Pattern.Output;
using System;
using System.Collections.Generic;

namespace Jenshin.Impack.API.Output
{
    public class UserOutput : OutputBase
    {
        public List<User> Data { get; set; }

        public UserOutput()
        {
            this.Data = new List<User>();
        }
    }

    public class SpecificUserOutput : OutputBase
    {
        public List<SpecificUser> Data { get; set; }

        public SpecificUserOutput()
        {
            this.Data = new List<SpecificUser>();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int AdventureRank { get; set; }
        public string Email { get; set; }
        public string Signature { get; set; }
    }

    public class SpecificUser
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Primogem { get; set; }
        public int GenesisCrystal { get; set; }
    }
}
