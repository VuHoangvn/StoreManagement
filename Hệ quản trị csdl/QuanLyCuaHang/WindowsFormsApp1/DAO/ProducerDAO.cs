using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class ProducerDAO
    {
        private static ProducerDAO instance;

        public static ProducerDAO Instance
        { get { if (instance == null) instance = new ProducerDAO(); return ProducerDAO.instance; }
            set { ProducerDAO.instance = value; }
        }

        private ProducerDAO() { }

        public List<Producer> GetListProducer()
        {
            List<Producer> list = new List<Producer>();

            string query = "select * from Producer";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Producer producer = new Producer(item);
                list.Add(producer);
            }

            return list;

        }

        public Producer GetProducerByID(int id)
        {
            Producer producer = null;

            string query = "select * from Producer where idProducer = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                producer = new Producer(item);
                return producer;
            }

            return producer;
        }

        public bool InsertProducer(string name, string address, string telephone)
        {
            string query = string.Format("insert Producer(name, address, telephone) values(N'{0}',N'{1}',{2} )", name, address, telephone);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateProducer(int idProducer, string name, string address, string telephone)
        {
            string query = string.Format("update Producer set  name = N'{1}', address=N'{2}', telephone = {3} where idProducer = {0} ", idProducer, name, address, telephone);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteProducer(int idProducer)
        {
            string query = string.Format("delete Producer where idProducer = {0}", idProducer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Producer> SearchProducerByName(string name)
        {
            List<Producer> list = new List<Producer>();
            string query = string.Format("select * from Producer where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Producer producer = new Producer(item);
                list.Add(producer);
            }

            return list;

        }


    }
}
