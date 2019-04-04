using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        public static AccountTypeDAO Instance
        {
            get { if (instance == null) instance = new AccountTypeDAO(); return AccountTypeDAO.instance; }
            set { instance = value; }
        }

        private AccountTypeDAO() { }

        public List<AccountType> GetListAccountType()
        {
            List<AccountType> list = new List<AccountType>();

            string query = "select * from AccountType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                 AccountType type = new AccountType(item);
                list.Add(type);
            }

            return list;
        }

        public AccountType GetAccountTypeByID(int id)
        {
            AccountType type = null;

            string query = "select * from AccountType where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                type = new AccountType(item);
                return type;
            }

            return type;
        }
    }
}
