using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class ReceiptBill
    {
        private int idReceiptBill;
        private int idProducer;
        private string date;
        private int total;

        public ReceiptBill(int idReceiptBill, int idProducer, string date, int total)
        {
            this.idReceiptBill = idReceiptBill;
            this.idProducer = idProducer;
            this.date = date;
            this.total = total;
        }

        public ReceiptBill(DataRow row)
        {
            this.idReceiptBill = (int)row["idReceiptBill"];
            this.idProducer = (int)row["idProducer"];
            this.date = row["receiptDate"].ToString();
            this.total = (int)row["receiptTotal"];
        }
        public int IdReceiptBill { get => idReceiptBill; set => idReceiptBill = value; }
        public int IdProducer { get => idProducer; set => idProducer = value; }
        public string Date { get => date; set => date = value; }
        public int Total { get => total; set => total = value; }
    }
}
