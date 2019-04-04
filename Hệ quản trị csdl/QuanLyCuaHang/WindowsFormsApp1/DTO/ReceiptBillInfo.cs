using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class ReceiptBillInfo
    {
        private int idReceiptBillInfo;
        private int idReceiptBill;
        private int idCategory;
        private int idGoods;
        private int amount;
        private int price;
        private int discount;

        public ReceiptBillInfo(int idReceiptBillInfo, int idReceiptBill, int idCategory, int idGoods, int amount, int price, int discount)
        {
            this.idReceiptBillInfo = idReceiptBillInfo;
            this.IdReceiptBill = idReceiptBill;
            this.IdCategory = idCategory;
            this.IdGoods = idGoods;
            this.Amount = amount;
            this.Price = price;
            this.Discount = discount;
        }

        public ReceiptBillInfo(DataRow row)
        {
            this.idReceiptBillInfo = (int)row["idReceiptBillInfo"];
            this.idReceiptBill = (int)row["idReceiptBill"];
            this.idCategory = (int)row["idCategory"];
            this.idGoods = (int)row["idGoods"];
            this.amount = (int)row["amount"];
            this.price = (int)row["price"];
            this.discount = (int)row["discount"];
            
        }

        public int IdReceiptBillInfo { get => idReceiptBillInfo; set => idReceiptBillInfo = value; }
        public int IdReceiptBill { get => idReceiptBill; set => idReceiptBill = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdGoods { get => idGoods; set => idGoods = value; }
        public int Amount { get => amount; set => amount = value; }
        public int Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        
    }
}
