using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SpaceApp.Models;

namespace SpaceApp.Entity
{
    public class User : IdentityUser
    {
        public string IdNumber { get; set; }
        public bool IsMarried { get; set; }
        public bool IsWorker { get; set; }
        public string Address { get; set; }

        public virtual Worker UserWorker { get; set; }

        public User()
        {
        }

        public User(string idNumber, bool isMarried, bool isWorker, string address, string username)
        {
            this.IdNumber = idNumber;
            this.IsMarried = isMarried;
            this.IsWorker = isWorker;
            this.Address = address;
            this.Username = username;
        }

        public string GetIdNumber()
        {
            return this.IdNumber;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public bool GetIsMarried()
        {
            return this.IsMarried;
        }

        public bool GetIsWorker()
        {
            return this.IsWorker;
        }

        public string GetAddress()
        {
            return this.Address;
        }
    }

}
