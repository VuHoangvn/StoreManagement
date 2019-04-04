using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class IssueBill
    {
        private int idIssueBill;
        private int idCustomer;
        private string issueDate;
        private int issueTotal;

        public IssueBill(int idIssueBill, int idCustomer, string issueDate, int issueTotal)
        {
            this.idIssueBill = idIssueBill;
            this.idCustomer = idCustomer;
            this.issueDate = issueDate;
            this.issueTotal = issueTotal;
        }

        public IssueBill(DataRow row)
        {
            this.idIssueBill = (int)row["idIssueBill"];
            this.idCustomer = (int) row["idCustomer"];
            this.issueDate = row["issueDate"].ToString();
            this.issueTotal = (int) row["issueTotal"];
        }

        public int IdIssueBill { get => idIssueBill; set => idIssueBill = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string IssueDate { get => issueDate; set => issueDate = value; }
        public int IssueTotal { get => issueTotal; set => issueTotal = value; }
    }
}
