using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class IssueBillInfo
    {
        private int idIssueBillInfo;
        private int idIssueBill;
        private int idCategory;
        private int idGoods;
        private int amount;
        private int price;
        private int discount;

        public IssueBillInfo(int idIssueBillInfo, int idIssueBill, int idCategory, int idGoods, int amount, int price, int discount)
        {
            this.idIssueBillInfo = idIssueBillInfo;
            this.idIssueBill = idIssueBill;
            this.idCategory = idCategory;
            this.idGoods = idGoods;
            this.amount = amount;
            this.price = price;
            this.discount = discount;
        }

        public IssueBillInfo(DataRow row)
        {
            this.idIssueBillInfo = (int)row["idIssueBillInfo"];
            this.idIssueBill = (int)row["idIssueBill"];
            this.idCategory = (int)row["idCategory"];
            this.idGoods = (int)row["idGoods"];
            this.amount = (int)row["amount"];
            this.price = (int)row["price"];
            this.discount = (int)row["discount"];

        }

        public int IdIssueBill { get => idIssueBill; set => idIssueBill = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdGoods { get => idGoods; set => idGoods = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public int IdIssueBillInfo { get => idIssueBillInfo; set => idIssueBillInfo = value; }
    }
}
