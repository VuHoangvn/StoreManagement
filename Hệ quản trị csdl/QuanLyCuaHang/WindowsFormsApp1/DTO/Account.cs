using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class Account
    {
        private string userName;
        private string displayName;
        private string passWord;
        private int type;

        public Account (string userName, string displayName, int type, string passWord = null)
        {
            this.userName = userName;
            this.displayName = displayName;
            this.type = type;
            this.passWord = passWord;
        }

        public Account (DataRow row)
        {
            this.userName = row["userName"].ToString();
            this.displayName = row["displayName"].ToString();
            this.type = (int)row["type"];
            this.passWord = row["passWord"].ToString();
        }

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
    }
}
