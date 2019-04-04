using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class IssueBillDAO
    {
        private static IssueBillDAO instance;

        public static IssueBillDAO Instance
        {
            get { if (instance == null) instance = new IssueBillDAO(); return IssueBillDAO.instance; }
            set { IssueBillDAO.instance = value; }
        }

        private IssueBillDAO() { }

        public List<IssueBill> GetListIssueBill()
        {
            List<IssueBill> list = new List<IssueBill>();

            string query = "select * from IssueBill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                IssueBill issueBill = new IssueBill(item);
                list.Add(issueBill);
            }

            return list;

        }

        public IssueBill GetIssueBillByID(int id)
        {
            IssueBill bill = null;

            string query = "select * from IssueBill where idIssueBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                bill = new IssueBill(item);
                return bill;
            }

            return bill;
        }

        public bool InsertIssueBill(int idCustomer, string date, int total)
        {
            string query = string.Format("insert IssueBill(idCustomer, issueDate, issueTotal) values({0},convert(date, {1}, 103),{2} )", idCustomer, date, total);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateIssueBill(int idIssueBill, int idCustomer, string date, int total)
        {
            string query = string.Format("update IssueBill set  idCustomer = {1}, issueDate = convert(date, N'{2}', 103), issueTotal = {3} where idIssueBill = {0} ", idIssueBill, idCustomer, date, total);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteIssueBill(int idIssueBill)
        {
            string query = string.Format("delete IssueBill where idIssueBill = {0}", idIssueBill);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //public List<IssueBill> SearchProducerByName(string name)
        //{
          //  List<Producer> list = new List<Producer>();
            //string query = string.Format("select * from Producer where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            //DataTable data = DataProvider.Instance.ExecuteQuery(query);

            //foreach (DataRow item in data.Rows)
            //{
              //  Producer producer = new Producer(item);
                //list.Add(producer);
            //}

            //return list;

        //}
    }
}
