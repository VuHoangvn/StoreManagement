using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class ProducerDebtDAO
    {
        private static ProducerDebtDAO instance;

        public static ProducerDebtDAO Instance
        {
            get { if (instance == null) instance = new ProducerDebtDAO(); return ProducerDebtDAO.instance; }
            set { ProducerDebtDAO.instance = value; }
        }

        private ProducerDebtDAO() { }



        public List<ProducerDebt> GetListProducerDebt()
        {
            List<ProducerDebt> list = new List<ProducerDebt>();

            string query = "select * from ProducerDebt";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProducerDebt producerDebt = new ProducerDebt(item);
                list.Add(producerDebt);
            }

            return list;

        }

        public List<ProducerDebt> SearchProducerDebtByName(string name)
        {
            List<ProducerDebt> list = new List<ProducerDebt>();
            string query = string.Format("select * from ProducerDebt where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProducerDebt producerDebt = new ProducerDebt(item);
                list.Add(producerDebt);
            }

            return list;

        }






        public bool InsertProducerDebt(int idProducer, int idReceiptBill, int debt, int payment)
        {
            string query = string.Format("insert ProducerDebt(idProducer, idReceiptBill, debt, payment) values({0},{1},{2},{3})", idProducer, idReceiptBill, debt, payment);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }



        public bool DeleteProducerDebt(int idProducer)
        {
            string query = string.Format("delete ProducerDebt where idProducer = {0}", idProducer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
