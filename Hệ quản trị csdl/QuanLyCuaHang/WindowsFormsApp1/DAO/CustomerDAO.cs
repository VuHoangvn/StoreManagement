using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        public List<Customer> GetListCustomer()
        {
            List<Customer> list = new List<Customer>();

            string query = "select * from Customer";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }

            return list;

        }

        public Customer GetCustomerByID(int id)
        {
            Customer customer = null;

            string query = "select * from Customer where idCustomer = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                customer = new Customer(item);
                return customer;
            }

            return customer;
        }

        public bool InsertCustomer(string name, string address, string telephone)
        {
            string query = string.Format("insert Customer(name, address, telephone) values(N'{0}',N'{1}',{2} )", name, address, telephone);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCustomer(int idCustomer, string name, string address, string telephone)
        {
            string query = string.Format("update Customer set  name = N'{1}', address=N'{2}', telephone = {3} where idCustomer = {0} ", idCustomer, name, address, telephone);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCustomer(int idCustomer)
        {
            string query = string.Format("delete Customer where idCustomer = {0}", idCustomer);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            List<Customer> list = new List<Customer>();
            string query = string.Format("select * from Customer where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Customer customer = new Customer(item);
                list.Add(customer);
            }

            return list;

        }
    }
}
