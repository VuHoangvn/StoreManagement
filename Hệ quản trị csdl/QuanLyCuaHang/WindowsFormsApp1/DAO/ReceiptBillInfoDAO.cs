using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class ReceiptBillInfoDAO
    {
        private static ReceiptBillInfoDAO instance;

        public static ReceiptBillInfoDAO Instance
        {
            get { if (instance == null) instance = new ReceiptBillInfoDAO(); return ReceiptBillInfoDAO.instance; }
            set { ReceiptBillInfoDAO.instance = value; }
        }

        private ReceiptBillInfoDAO() { }

        public List<ReceiptBillInfo> GetListById(int id)
        {
            List<ReceiptBillInfo> list = new List<ReceiptBillInfo>();

            string query = "select * from ReceiptBillInfo where idReceiptBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ReceiptBillInfo receiptbillinfo = new ReceiptBillInfo(item);
                list.Add(receiptbillinfo);
            }

            return list;

        }

        public bool InsertReceiptBillInfo(int idReceiptBill, int idGoods, int idCategory, int amount, int price, int discount)
        {
            string query = string.Format("insert into ReceiptBillInfo(idReceiptBill, idGoods, idCategory, amount, price, discount) values({0}, {1}, {2}, {3}, {4},{5})", idReceiptBill, idGoods, idCategory, amount, price, discount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateReceiptBillInfo(int idReceiptBillInfo, int idGoods, int idCategory, int amount, int price, int discount)
        {
            string query = string.Format("update ReceiptBillInfo set idGoods = {1}, idCategory = {2}, amount = {3}, price = {4}, discount = {5} where idReceiptBillInfo = {0}", idReceiptBillInfo, idGoods, idCategory, amount, price, discount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteReceiptBillInfo(int idReceiptBillInfo)
        {
            string query = string.Format("delete ReceiptBillInfo where idReceiptBillInfo = {0}", idReceiptBillInfo);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool CancelReceiptBill(int idReceiptBill)
        {
            string query = string.Format("delete ReceiptBillInfo where idReceiptBill = {0}", idReceiptBill);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }

}
