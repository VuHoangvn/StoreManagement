using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class IssueBillInformDAO
    {
        private static IssueBillInformDAO instance;

        public static IssueBillInformDAO Instance
        {
            get { if (instance == null) instance = new IssueBillInformDAO(); return IssueBillInformDAO.instance; }
            set { IssueBillInformDAO.instance = value; }
        }

        private IssueBillInformDAO() { }

        public List<IssueBillInfo> GetListById(int id)
        {
            List<IssueBillInfo> list = new List<IssueBillInfo>();

            string query = "select * from IssueBillInfo where idIssueBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                IssueBillInfo issuebillinfo = new IssueBillInfo(item);
                list.Add(issuebillinfo);
            }

            return list;

        }

        public bool CancelIssueBill(int idIssueBill)
        {
            string query = string.Format("delete IssueBillInfo where idIssueBill = {0}", idIssueBill);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool InsertIssueBillInfo(int idIssueBill, int idGoods, int idCategory, int amount, int price, int discount)
        {
            string query = string.Format("insert into IssueBillInfo(idIssueBill, idGoods, idCategory, amount, price, discount) values({0}, {1}, {2}, {3}, {4},{5})", idIssueBill, idGoods, idCategory, amount, price, discount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateIssueBillInfo(int idIssueBillInfo, int idGoods, int idCategory, int amount, int price, int discount)
        {
            string query = string.Format("update IssueBillInfo set idGoods = {1}, idCategory = {2}, amount = {3}, price = {4}, discount = {5} where idIssueBillInfo = {0}", idIssueBillInfo, idGoods, idCategory, amount, price, discount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteIssueBillInfo(int idIssueBillInfo)
        {
            string query = string.Format("delete IssueBillInfo where idIssueBillInfo = {0}", idIssueBillInfo);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
