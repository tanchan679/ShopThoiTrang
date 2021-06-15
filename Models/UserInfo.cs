using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class UserInfo
    {
        public String name;
        public String email;
        public String phonenumber;
        public String addadress;

        public UserInfo() { }
        public UserInfo(String name, String email, String phonenumber, String addadress)
        {
            this.name = name;
            this.email = email;
            this.phonenumber = phonenumber;
            this.addadress = addadress;
        }
        public String Name { get => this.name; set => this.name = value; }
        public String Email { get => this.email; set => this.email = value; }
        public String Phonenumber { get => this.phonenumber; set => this.phonenumber = value; }
        public String Addadress { get => this.addadress; set => this.addadress = value; }
    }
}