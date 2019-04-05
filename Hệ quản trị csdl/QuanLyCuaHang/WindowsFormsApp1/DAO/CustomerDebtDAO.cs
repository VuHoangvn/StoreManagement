using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class CustomerDebtDAO
    {
        private static CustomerDebtDAO instance;

        public static CustomerDebtDAO Instance
        {
            get { if (instance == null) instance = new CustomerDebtDAO(); return CustomerDebtDAO.instance; }
            set { CustomerDebtDAO.instance = value; }
        }

        private CustomerDebtDAO() { }

        

        public List<CustomerDebt> GetListCustomerDebt()
        {
            List<CustomerDebt> list = new List<CustomerDebt>();

            string query = "select * from CustomerDebt";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CustomerDebt customerDebt = new CustomerDebt(item);
                list.Add(customerDebt);
            }

            return list;

        }

        public List<CustomerDebt> SearchCustomerDebtByName(string name)
        {
            List<CustomerDebt> list = new List<CustomerDebt>();
            string query = string.Format("select * from CustomerDebt where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CustomerDebt customerDebt = new CustomerDebt(item);
                list.Add(customerDebt);
            }

            return list;

        }

        

        


        public bool InsertCustomerDebt(int idCustomer, int idIssueBill, int debt, int payment)
        {
            string query = string.Format("insert CustomerDebt(idCustomer, idIssueBill, debt, payment) values({0},{1},{2},{3})", idCustomer, idIssueBill, debt, payment);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        

        public bool DeleteCustomerDebt(int idCustomer)
        {
            string query = string.Format("delete CustomerDebt where idCustomer = {0}", idCustomer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
