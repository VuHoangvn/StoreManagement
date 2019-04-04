using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class Good
    {
        private int idGoods;
        private int idCategory;
        private int idProducer;
        private int amount;
        private string name;
        private int price;

        public Good(int idGoods, int idCategory, int idProducer, int amount, string name, int price)
        {
            this.idGoods = idGoods;
            this.idCategory = idCategory;
            this.idProducer = idProducer;
            this.amount = amount;
            this.name = name;
            this.price = price;
        }

        public Good(DataRow row)
        {
            this.IdGoods = (int)row["idGoods"];
            this.IdCategory = (int)row["idCategory"];
            this.IdProducer = (int)row["idProducer"];
            this.Amount = (int)row["amount"];
            this.Price = (int)row["price"];
            this.Name = row["name"].ToString();
        }

        public int IdGoods { get => idGoods; set => idGoods = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdProducer { get => idProducer; set => idProducer = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
    }
}
