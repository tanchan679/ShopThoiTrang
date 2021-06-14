using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class UserLogin
    {
        public String email;
        public String pass;
        public String Email { get => this.email; set => this.email = value; }
        public String Pass { get => this.pass; set => this.pass = value; }
    }
}