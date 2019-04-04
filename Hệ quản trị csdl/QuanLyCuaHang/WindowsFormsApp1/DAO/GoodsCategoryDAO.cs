using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class GoodsCategoryDAO
    {
        private static GoodsCategoryDAO instance;

        public static GoodsCategoryDAO Instance
        {
            get { if (instance == null) instance = new GoodsCategoryDAO(); return GoodsCategoryDAO.instance; }
            set { GoodsCategoryDAO.instance = value; }
        }

        private GoodsCategoryDAO() { }

        public List<GoodsCategory> GetListGoodsCategory()
        {
            List<GoodsCategory> list = new List<GoodsCategory>();

            string query = "select * from Category";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                GoodsCategory category = new GoodsCategory(item);
                list.Add(category);
            }

            return list;
        }

        public GoodsCategory GetCategoryByID(int id)
        {
            GoodsCategory category = null;

            string query = "select * from Category where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new GoodsCategory(item);
                return category;
            }

            return category;
        }

        public List<GoodsCategory> GetCategoryByGoodsName(string name)
        {
            List<GoodsCategory> list = new List<GoodsCategory>();

            string query = string.Format("select idCategory from Goods where name = N'{0}'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {

                GoodsCategory category = GoodsCategoryDAO.Instance.GetCategoryByID((int)item["idCategory"]);
                list.Add(category);
            }

            return list;
        }

        public List<GoodsCategory> SearchGoodsCategoryByName(string name)
        {
            List<GoodsCategory> list = new List<GoodsCategory>();
            string query = string.Format("select * from Category where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                GoodsCategory goodscategory = new GoodsCategory(item);
                list.Add(goodscategory);
            }

            return list;

        }

        public bool InsertCategory(string name)
        {
            string query = string.Format("insert Category (name) values(N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(string name, int id)
        {
            string query = string.Format("update Category set name = N'{0}' where idCategory = {1} ", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = string.Format("delete Category where idCategory = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
