﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPC_Rental.Models.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string GroupID { set; get; }
    }
}