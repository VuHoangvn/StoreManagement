using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class GoodsDAO
    {
        private static GoodsDAO instance;

        public static GoodsDAO Instance
        {
            get { if (instance == null) instance = new GoodsDAO(); return GoodsDAO.instance; }
            set { GoodsDAO.instance = value; } 
        }

        private GoodsDAO() { }

        public DataTable LoadGoodsList()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetGoodsList");
            return data;
        }

        public List<Good> GetListGood()
        {
            List<Good> list = new List<Good>();

            string query = "select * from Goods";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Good good = new Good(item);
                list.Add(good);
            }

            return list;

        }

        public List<Good> SearchGoodsByName(string name)
        {
            List<Good> list = new List<Good>();
            string query = string.Format("select * from Goods where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Good good = new Good(item);
                list.Add(good);
            }

            return list;
            
        }

        public Good GetGoodsByID(int id)
        {
            Good good = null;

            string query = "select * from Goods where idGoods = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                good  = new Good(item);
                return good;
            }

            return good;
        }


        public bool InsertGoods(int idCategory, int idProducer, int amount, string name, int price)
        {
            string query = string.Format("insert Goods(idCategory, idProducer, amount, name, price) values({0},{1},{2},N'{3}',{4})", idCategory, idProducer, amount, name,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateGoods(int idCategory, int idProducer, int amount, string name, int price, int idGoods)
        {
            string query = string.Format("update Goods set idCategory = {0}, idProducer = {1}, amount = {2}, name = N'{3}', price = {4} where idGoods = {5} ", idCategory, idProducer, amount, name, price, idGoods);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteGoods(int idGoods)
        {
            string query = string.Format("delete Goods where idGoods = {0}", idGoods);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
