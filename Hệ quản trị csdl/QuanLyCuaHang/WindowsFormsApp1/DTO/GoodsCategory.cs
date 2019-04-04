using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    class GoodsCategory
    {
        private int id;
        private string name;

        public GoodsCategory(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public GoodsCategory(DataRow row)
        {
            this.id = (int) row["idCategory"];
            this.name = row["name"].ToString();
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
