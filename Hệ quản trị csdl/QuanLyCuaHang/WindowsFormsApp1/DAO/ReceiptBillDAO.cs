using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class ReceiptBillDAO
    {
        private static ReceiptBillDAO instance;

        public static ReceiptBillDAO Instance
        {
            get { if (instance == null) instance = new ReceiptBillDAO(); return ReceiptBillDAO.instance; }
            set { ReceiptBillDAO.instance = value; }
        }

        private ReceiptBillDAO() { }

        public List<ReceiptBill> GetListReceiptBill()
        {
            List<ReceiptBill> list = new List<ReceiptBill>();

            string query = "select * from ReceiptBill";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ReceiptBill receiptBill = new ReceiptBill(item);
                list.Add(receiptBill);
            }

            return list;

        }

        public ReceiptBill GetReceiptBillByID(int id)
        {
            ReceiptBill bill = null;

            string query = "select * from ReceiptBill where idReceiptBill = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                bill = new ReceiptBill(item);
                return bill;
            }

            return bill;
        }

        public bool InsertReceiptBill(int idProducer, string date, int total)
        {
            string query = string.Format("insert ReceiptBill(idProducer, receiptDate, receiptTotal) values({0},convert(date, {1}, 103),{2} )", idProducer, date, total);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateReceiptBill(int idReceiptBill, int idProducer, string date, int total)
        {
            string query = string.Format("update ReceiptBill set  idProducer = {1}, receiptDate = convert(date, N'{2}', 103), receiptTotal = {3} where idReceiptBill = {0} ", idReceiptBill, idProducer, date, total);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteReceiptBill(int idReceiptBill)
        {
            string query = string.Format("delete ReceiptBill where idReceiptBill = {0}", idReceiptBill);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
