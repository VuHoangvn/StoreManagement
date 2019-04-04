using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class Customer
    {
        private int idCustomer;
        private string name;
        private string address;
        private string telephone;

        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string Address { get => address; set => address = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Name { get => name; set => name = value; }

        public Customer(int idCustomer, string name, string address, string telephone)
        {
            this.IdCustomer = idCustomer;
            this.Name = name;
            this.Address = address;
            this.Telephone = telephone;
        }

        public Customer(DataRow row)
        {
            this.IdCustomer = (int)row["idCustomer"];
            this.Name = row["name"].ToString();
            this.Address = row["address"].ToString();
            this.Telephone = row["telephone"].ToString();
        }


    }
}
