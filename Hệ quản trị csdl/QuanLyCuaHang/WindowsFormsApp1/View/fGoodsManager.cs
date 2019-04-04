using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class fGoodsManager : Form
    {

        BindingSource producerlist = new BindingSource();
        BindingSource issuedetailList = new BindingSource();
        BindingSource receiptdetailList = new BindingSource();

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        

        public fGoodsManager(Account account)
        {
            InitializeComponent();

            this.LoginAccount = account;
            
            LoadAll();
        }

        #region Method

        void AddIssueInfoBinding()
        {
            txbIssueAmount.DataBindings.Add(new Binding("Text", dtgvIssueDetail.DataSource, "amount", true, DataSourceUpdateMode.Never));
            txbIssuePrice.DataBindings.Add(new Binding("Text", dtgvIssueDetail.DataSource, "Price", true, DataSourceUpdateMode.Never));
            txbIssueDiscount.DataBindings.Add(new Binding("Text", dtgvIssueDetail.DataSource, "discount", true, DataSourceUpdateMode.Never));
        }

        void AddReceiptInfoBinding()
        {
            txbReceiptAmount.DataBindings.Add(new Binding("Text", dtgvReceiptDetail.DataSource, "amount", true, DataSourceUpdateMode.Never));
            txbReceiptPrice.DataBindings.Add(new Binding("Text", dtgvReceiptDetail.DataSource, "price", true, DataSourceUpdateMode.Never));
            txbReceiptDiscount.DataBindings.Add(new Binding("Text", dtgvReceiptDetail.DataSource, "discount", true, DataSourceUpdateMode.Never));
        }

        void LoadListIssueInfo()
        {
            issuedetailList.DataSource = IssueBillInformDAO.Instance.GetListById(3);
        }

        void LoadListReceiptInfo()
        {
            receiptdetailList.DataSource = ReceiptBillInfoDAO.Instance.GetListById(3);
        }
        void LoadProducerIntoComboBox(ComboBox cb)
        {
            cb.DataSource = ProducerDAO.Instance.GetListProducer();
            cb.DisplayMember = "name";
            
        }


        void LoadGoodsIntoComboBox(ComboBox cb)
        {
            cb.DataSource = GoodsDAO.Instance.GetListGood();
            cb.DisplayMember = "name";
        }


        void LoadCustomerIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CustomerDAO.Instance.GetListCustomer();
            cb.DisplayMember = "name";
        }

        void LoadGoodsCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = GoodsCategoryDAO.Instance.GetListGoodsCategory();
            cb.DisplayMember = "name";
        }


        void LoadAll()
        {
            dtgvIssueDetail.DataSource = issuedetailList;
            dtgvReceiptDetail.DataSource = receiptdetailList;


            LoadProducerIntoComboBox(cbProvider);
            LoadProducerIntoComboBox(cbProducer1);
            LoadGoodsIntoComboBox(cbIssueGoods);
            LoadGoodsIntoComboBox(cbReceiptGoods);
            LoadCustomerIntoComboBox(cbCustomer);
            //LoadGoodsCategoryIntoComboBox(cbIssueCategory);
            //LoadGoodsCategoryIntoComboBox(cbReceiptCategory);
            LoadGoods();
            LoadListIssueInfo();
            LoadListReceiptInfo();

            AddIssueInfoBinding();
            AddReceiptInfoBinding();
        }



        void ChangeAccount(int type)
        {
            tsAdmin.Enabled = type == 1;
            tmProfile.Text += " (" + loginAccount.DisplayName + ")";
        }

        void LoadGoods()
        {
            DataTable data = GoodsDAO.Instance.LoadGoodsList();
            
        }

        void AddProducer(string name, string address, string telephone)
        {
            if (ProducerDAO.Instance.InsertProducer(name, address, telephone))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

        }

        void AddCustomer(string name, string address, string telephone)
        {
            if (CustomerDAO.Instance.InsertCustomer(name, address, telephone))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

        }

        void AddCategory(string name)
        {
            if (GoodsCategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

        }

        void AddIssueBill(int idIssueBill, int idGoods, int idCategory, int amount, int price, int discount)
        {
            if (IssueBillInformDAO.Instance.InsertIssueBillInfo(idIssueBill, idGoods, idCategory, amount, price,discount))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListIssueInfo();
        }

        void EditIssueBill(int idIssueBillInfo, int idGoods, int idCategory, int amount, int price, int discount)
        {
            if (IssueBillInformDAO.Instance.UpdateIssueBillInfo(idIssueBillInfo, idGoods, idCategory, amount, price, discount))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListIssueInfo();
        }

        void DeleteIssueBill(int idIssueBillInfo)
        {
            if (IssueBillInformDAO.Instance.DeleteIssueBillInfo(idIssueBillInfo))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListIssueInfo();
        }

        void RefreshIssueBill()
        {

            LoadListIssueInfo();
        }

        void AddReceiptBill(int idReceiptBill, int idGoods, int idCategory, int amount, int price, int discount)
        {
            if (ReceiptBillInfoDAO.Instance.InsertReceiptBillInfo(idReceiptBill, idGoods, idCategory, amount, price, discount))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListReceiptInfo();
        }

        void EditReceiptBill(int idReceiptBillInfo, int idGoods, int idCategory, int amount, int price, int discount)
        {
            if (ReceiptBillInfoDAO.Instance.UpdateReceiptBillInfo(idReceiptBillInfo, idGoods, idCategory, amount, price, discount))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListReceiptInfo();
        }

        void DeleteReceiptBill(int idReceiptBillInfo)
        {
            if (ReceiptBillInfoDAO.Instance.DeleteReceiptBillInfo(idReceiptBillInfo))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListReceiptInfo();
        }

        void RefreshReceiptBill()
        {

            LoadListReceiptInfo();
        }

        #endregion

        #region Events
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateAccountEvent += f_UpdateAccountEvent;
            f.ShowDialog();
        }

        private void f_UpdateAccountEvent(object sender, AccountEvent e)
        {
            tmProfile.Text = "Thông tin cá nhân (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.ShowDialog();
        }

        //
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txbNameProducer.Text;
            string address = txbAddressProducer.Text;
            string telephone = txbTeleProducer.Text;

            AddProducer(name, address, telephone);
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txbCustomerName.Text;
            string address = txbCustomerAddress.Text;
            string telephone = txbCustomerTelephone.Text;

            AddCustomer(name, address, telephone);
        }

        private void cbIssueGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIssueCategory.DataSource = GoodsCategoryDAO.Instance.GetCategoryByGoodsName(cbIssueGoods.Text);
            cbIssueCategory.DisplayMember = "Name";
        }


        private void cbReceiptGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbReceiptCategory.DataSource = GoodsCategoryDAO.Instance.GetCategoryByGoodsName(cbReceiptGoods.Text);
            cbReceiptCategory.DisplayMember = "Name";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string name = txbGoodsName.Text;
            int idCategory = (cbCategory.SelectedItem as GoodsCategory).Id;
            int idProducer = (cbProvider.SelectedItem as Producer).IdProducer;
            int amount = 0;
            int price = 0;

            if (GoodsDAO.Instance.InsertGoods(idCategory, idProducer, amount, name, price))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = cbCategory.Text;

            AddCategory(name);
        }
        private void txbReceiptPrice_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
               
            //}
            //catch
            //{

            //}
        }

        private void btnAddReceiptDetail_Click(object sender, EventArgs e)
        {
            int idReceiptBill = 3;
            int idGoods = (cbReceiptGoods.SelectedItem as Good).IdGoods;
            int idCategory = (cbReceiptCategory.SelectedItem as GoodsCategory).Id;
            int amount = Int32.Parse(txbReceiptAmount.Text);
            int price = Int32.Parse(txbReceiptPrice.Text);
            int discount = Int32.Parse(txbReceiptDiscount.Text);

            AddReceiptBill(idReceiptBill, idGoods, idCategory, amount, price, discount);
        }

        private void btnEditReceiptDetail_Click(object sender, EventArgs e)
        {
            int idReceiptBillInfo = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idReceiptBillInfo"].Value;
            int idGoods = (cbReceiptGoods.SelectedItem as Good).IdGoods;
            int idCategory = (cbReceiptCategory.SelectedItem as GoodsCategory).Id;
            int amount = Int32.Parse(txbReceiptAmount.Text);
            int price = Int32.Parse(txbReceiptPrice.Text);
            int discount = Int32.Parse(txbReceiptDiscount.Text);

            EditReceiptBill(idReceiptBillInfo, idGoods, idCategory, amount, price, discount);
        }

        private void btnDeleteReceiptDetail_Click(object sender, EventArgs e)
        {
            int idReceiptBillInfo = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idReceiptBillInfo"].Value;

            DeleteReceiptBill(idReceiptBillInfo);

        }

        private void btnRefreshDetail_Click(object sender, EventArgs e)
        {

        }


        private void btnAddIssueBill_Click(object sender, EventArgs e)
        {
            int idIssueBill = 3;
            int idGoods = (cbIssueGoods.SelectedItem as Good).IdGoods;
            int idCategory = (cbIssueCategory.SelectedItem as GoodsCategory).Id;
            int amount = Int32.Parse(txbIssueAmount.Text);
            int price = Int32.Parse(txbIssuePrice.Text);
            int discount = Int32.Parse(txbIssueDiscount.Text);

            AddIssueBill(idIssueBill, idGoods, idCategory, amount, price, discount);
        }

        private void btnEditIssueBill_Click(object sender, EventArgs e)
        {
            int idIssueBillInfo = (int)dtgvIssueDetail.SelectedCells[0].OwningRow.Cells["idIssueBillInfo"].Value;
            int idGoods = (cbIssueGoods.SelectedItem as Good).IdGoods;
            int idCategory = (cbIssueCategory.SelectedItem as GoodsCategory).Id;
            int amount = Int32.Parse(txbIssueAmount.Text);
            int price = Int32.Parse(txbIssuePrice.Text);
            int discount = Int32.Parse(txbIssueDiscount.Text);

            EditIssueBill(idIssueBillInfo, idGoods, idCategory, amount, price, discount);
        }

        private void btnDeleteIssueBill_Click(object sender, EventArgs e)
        {
            int idIssueBillInfo = (int)dtgvIssueDetail.SelectedCells[0].OwningRow.Cells["idIssueBillInfo"].Value;

            DeleteReceiptBill(idIssueBillInfo);
        }

        private void btnRefreshIssueBill_Click(object sender, EventArgs e)
        {

        }

        private void dtgvReceiptDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvReceiptDetail.SelectedCells.Count > 0)
            {
                int id = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                int id1 = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idGoods"].Value;


                GoodsCategory category = GoodsCategoryDAO.Instance.GetCategoryByID(id);
                Good good = GoodsDAO.Instance.GetGoodsByID(id1);


                int index = -1;
                int i = 0;

                foreach (Good item in cbReceiptGoods.Items)
                {
                    if (item.IdGoods == good.IdGoods)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbReceiptGoods.SelectedIndex = index;

                i = 0;

                foreach (GoodsCategory item in cbReceiptCategory.Items)
                {
                    if (item.Id == category.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbReceiptCategory.SelectedIndex = index;


            }

        }

        private void dtgvIssueDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvIssueDetail.SelectedCells.Count > 0)
            {
                int id = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                int id1 = (int)dtgvReceiptDetail.SelectedCells[0].OwningRow.Cells["idGoods"].Value;


                GoodsCategory category = GoodsCategoryDAO.Instance.GetCategoryByID(id);
                Good good = GoodsDAO.Instance.GetGoodsByID(id1);


                int index = -1;
                int i = 0;

                foreach (Good item in cbIssueGoods.Items)
                {
                    if (item.IdGoods == good.IdGoods)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbIssueGoods.SelectedIndex = index;

                i = 0;

                foreach (GoodsCategory item in cbIssueCategory.Items)
                {
                    if (item.Id == category.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbIssueCategory.SelectedIndex = index;


            }
        }

        #endregion


    }
}
