using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class Goods
    {
        private int idGoods;
        private int idCategory;
        private int idProducer;
        private int amount;
        private string name;
        private int price;

        public Goods(int idGoods, int idCategory, int idProducer, int amount, string name, int price)
        {
            this.idGoods = idGoods;
            this.idCategory = idCategory;
            this.idProducer = idProducer;
            this.amount = amount;
            this.name = name;
            this.price = price;
        }

        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public int IdProducer { get => idProducer; set => idProducer = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdGoods { get => idGoods; set => idGoods = value; }
        public string Name { get => name; set => name = value; }
    }
}
