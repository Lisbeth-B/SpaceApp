using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApp.Entity
{
    public class Worker
    {

        public int Id { get; }
        public string IdNumber { get; set; }
        public decimal Salary { get; set; }
        public virtual User WorkerUser { get; set; }

        public Worker(string idNumber, decimal salary)
        {
            IdNumber = idNumber;
            Salary = salary;
        }

    }
}
