using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class UserRegister
    {
        public String name;
        public String email;
        public String pass;
        public String passConfirm;
        public String phonenumber;
        public String addadress;

        public UserRegister() { }
        public UserRegister(String name, String email, String pass, String passConfirm, String phonenumber, String addadress)
        {
            this.name = name;
            this.email = email;
            this.pass = pass;
            this.passConfirm = passConfirm;
            this.phonenumber = phonenumber;
            this.addadress = addadress;
        }
        public String Name { get => this.name; set => this.name = value; }
        public String Email { get => this.email; set => this.email = value; }
        public String Pass { get => this.pass; set => this.pass = value; }
        public String PassConfirm { get => this.passConfirm; set => this.passConfirm = value; }
        public String Phonenumber { get => this.phonenumber; set => this.phonenumber = value; }
        public String Addadress { get => this.addadress; set => this.addadress = value; }
    }
}