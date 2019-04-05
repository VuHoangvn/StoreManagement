using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class CustomerDebt
    {
        private int idCustomerDebt;
        private int idCustomer;
        private int idIssueBill;
        private int debt;
        private int payment;

        public CustomerDebt(int idCustomerDebt, int idCustomer, int idIssueBill, int debt, int payment)
        {
            this.idCustomerDebt = idCustomerDebt;
            this.idCustomer = idCustomer;
            this.idIssueBill = idIssueBill;
            this.debt = debt;
            this.payment = payment;
        }

        public CustomerDebt(DataRow row)
        {
            this.idCustomerDebt = (int)row["idCustomerDebt"];
            this.idCustomer = (int)row["idCustomer"];
            this.idIssueBill = (int)row["idIssueBill"];
            this.debt = (int)row["debt"];
            this.payment = (int)row["payment"];
        }

        public int IdCustomerDebt { get => idCustomerDebt; set => idCustomerDebt = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int IdIssueBill { get => idIssueBill; set => idIssueBill = value; }
        public int Debt { get => debt; set => debt = value; }
        public int Payment { get => payment; set => payment = value; }
    }
}
