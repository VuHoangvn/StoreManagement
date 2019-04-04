using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class Producer
    {
        private int idProducer;
        private string name;
        private string address;
        private string telephone;

        public Producer(int idProducer, string name, string address, string telephone)
        {
            this.idProducer = idProducer;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
        }

        public Producer(DataRow row)
        {
            this.idProducer = (int)row["idProducer"];
            this.name = row["name"].ToString();
            this.address = row["address"].ToString();
            this.telephone = row["telephone"].ToString();
        }

        public int IdProducer { get => idProducer; set => idProducer = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}
