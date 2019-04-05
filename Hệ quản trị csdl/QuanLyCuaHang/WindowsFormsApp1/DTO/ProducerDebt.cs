using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class ProducerDebt
    {
        private int idProducerDebt;
        private int idProducer;
        private int idReceiptBill;
        private int debt;
        private int payment;

        public int IdProducerDebt { get => idProducerDebt; set => idProducerDebt = value; }
        public int IdProducer { get => idProducer; set => idProducer = value; }
        public int IdReceiptBill { get => idReceiptBill; set => idReceiptBill = value; }
        public int Debt { get => debt; set => debt = value; }
        public int Payment { get => payment; set => payment = value; }

        public ProducerDebt(int idProducerDebt, int idProducer, int idReceiptBill, int debt, int payment)
        {
            this.IdProducerDebt = idProducerDebt;
            this.IdProducer = idProducer;
            this.IdReceiptBill = idReceiptBill;
            this.Debt = debt;
            this.Payment = payment;
        }

        public ProducerDebt(DataRow row)
        {
            this.IdProducerDebt = (int)row["idProducerDebt"];
            this.IdProducer = (int)row["idProducer"];
            this.IdReceiptBill = (int)row["idReceiptBill"];
            this.Debt = (int)row["debt"];
            this.Payment = (int)row["payment"];
        }

        
    }
}
