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
    public partial class fAdmin : Form
    {
        BindingSource customerlist = new BindingSource();
        BindingSource goodCategoryList = new BindingSource();
        BindingSource goodslist = new BindingSource();
        BindingSource accountlist = new BindingSource();
        BindingSource producerlist = new BindingSource();
        BindingSource issueBillList = new BindingSource();
        BindingSource receiptBillList = new BindingSource();

        public Account loginAccount;


        public fAdmin()
        {
            InitializeComponent();
            LoadAll();
            
        }
        #region Method

        void ShowIssueBill(int idIssueBill)
        {
            dtgvIssueDetail.DataSource = IssueBillInformDAO.Instance.GetListById(idIssueBill);
        }

        void ShowReceiptBill(int idReceiptBill)
        {
            dtgvReceiptDetail.DataSource = ReceiptBillInfoDAO.Instance.GetListById(idReceiptBill);
        }

        void AddGoodsCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void AddCustomerBinding()
        {
            txbCustomerId.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "idCustomer", true, DataSourceUpdateMode.Never));
            txbCustomerName.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbCustomerAddress.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "address", true, DataSourceUpdateMode.Never));
            txbCustomerTelephone.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "telephone", true, DataSourceUpdateMode.Never));
        }

        void AddProducerBinding()
        {
            txbIdProducer.DataBindings.Add(new Binding("Text", dtgvProducer.DataSource, "idProducer", true, DataSourceUpdateMode.Never));
            txbNameProducer.DataBindings.Add(new Binding("Text", dtgvProducer.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbAddressProducer.DataBindings.Add(new Binding("Text", dtgvProducer.DataSource, "address", true, DataSourceUpdateMode.Never));
            txbTeleProducer.DataBindings.Add(new Binding("Text", dtgvProducer.DataSource, "telephone", true, DataSourceUpdateMode.Never));
        }

        void AddIssueBinding()
        {
            txbIdIssueBill.DataBindings.Add(new Binding("Text", dtgvIssueBill.DataSource, "idIssueBill", true, DataSourceUpdateMode.Never));
            txbIssueCustomer.DataBindings.Add(new Binding("Text", dtgvIssueBill.DataSource, "idCustomer", true, DataSourceUpdateMode.Never));
            txbIssueDate.DataBindings.Add(new Binding("Text", dtgvIssueBill.DataSource, "issueDate", true, DataSourceUpdateMode.Never));
            txbIssueTotal.DataBindings.Add(new Binding("Text", dtgvIssueBill.DataSource, "issueTotal", true, DataSourceUpdateMode.Never));
        }

        void AddReceiptBinding()
        {
            txbIdReceiptBill.DataBindings.Add(new Binding("Text", dtgvReceiptBill.DataSource, "idReceiptBill", true, DataSourceUpdateMode.Never));
            txbReceiptProducer.DataBindings.Add(new Binding("Text", dtgvReceiptBill.DataSource, "idProducer", true, DataSourceUpdateMode.Never));
            txbReceiptDate.DataBindings.Add(new Binding("Text", dtgvReceiptBill.DataSource, "Date", true, DataSourceUpdateMode.Never));
            txbReceiptTotal.DataBindings.Add(new Binding("Text", dtgvReceiptBill.DataSource, "Total", true, DataSourceUpdateMode.Never));
        }
        void AddGoodsBinding()
        {
            txbGoodsID.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idGoods", true, DataSourceUpdateMode.Never));
            txbGoodsName.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "Name", true, DataSourceUpdateMode.Never));
            //cbGoodsCategory.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idCategory"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            //cbProvider.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "idProducer"));
            txtGoodsAmount.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "amount", true, DataSourceUpdateMode.Never));
            txtGoodsPrice.DataBindings.Add(new Binding("Text", dtgvGoods.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
        }

        void LoadListCategory()
        {
            goodCategoryList.DataSource = GoodsCategoryDAO.Instance.GetListGoodsCategory();
        }
        void LoadListProducer()
        {
            producerlist.DataSource = ProducerDAO.Instance.GetListProducer();
        }

        void LoadCustomerList()
        {
            customerlist.DataSource = CustomerDAO.Instance.GetListCustomer();
        }

        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadIssueBillList()
        {
            issueBillList.DataSource = IssueBillDAO.Instance.GetListIssueBill();
        }

        void LoadReceiptBillList()
        {
            receiptBillList.DataSource = ReceiptBillDAO.Instance.GetListReceiptBill();
        }

        void LoadListGoods()
        {
            goodslist.DataSource = GoodsDAO.Instance.LoadGoodsList();
        }

        void LoadGoodsCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = GoodsCategoryDAO.Instance.GetListGoodsCategory();
            cb.DisplayMember = "name";
        }

        void LoadProducerIntoComboBox(ComboBox cb)
        {
            cb.DataSource = ProducerDAO.Instance.GetListProducer();
            cb.DisplayMember = "name";
        }

        void LoadAccountTypeIntoComboBox(ComboBox cb)
        {
            cb.DataSource = AccountTypeDAO.Instance.GetListAccountType();
            cb.DisplayMember = "name";
        }
        void LoadAll()
        {
            dtgvCategory.DataSource = goodCategoryList;
            dtgvGoods.DataSource = goodslist;
            dtgvAccount.DataSource = accountlist;
            dtgvProducer.DataSource = producerlist;
            dtgvCustomer.DataSource = customerlist;
            dtgvIssueBill.DataSource = issueBillList;
            dtgvReceiptBill.DataSource = receiptBillList;

            LoadListCategory();
            LoadListGoods();
            LoadAccount();
            LoadListProducer();
            LoadCustomerList();
            LoadIssueBillList();
            LoadReceiptBillList();
            LoadGoodsCategoryIntoComboBox(cbGoodsCategory);
            LoadProducerIntoComboBox(cbProvider);
            LoadAccountTypeIntoComboBox(cbAccountType);

            AddGoodsCategoryBinding();
            AddAccountBinding();
            AddProducerBinding();
            AddGoodsBinding();
            AddCustomerBinding();
            AddIssueBinding();
            AddReceiptBinding();

        }

       

        void AddAccount(string userName, string displayName,int type)
        {
           if( AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Tài khoản đang sử dụng!");
            }
            else
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }

                LoadAccount();
            }
            
        }

        void ResetPassWord(string userName)
        {
            if (AccountDAO.Instance.ResetPassWord(userName))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            
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

            LoadListProducer();
        }

        void EditProducer(int idProducer, string name, string address, string telephone)
        {
            if (ProducerDAO.Instance.UpdateProducer(idProducer, name, address, telephone))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListProducer();
        }

        void DeleteProducer(int idProducer)
        {
            
                if (ProducerDAO.Instance.DeleteProducer(idProducer))
                {
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }

                LoadListProducer();
            

        }

        void EditIssueBill(int idIssueBill, int idCustomer, string date, int total)
        {
            if (IssueBillDAO.Instance.UpdateIssueBill(idIssueBill, idCustomer, date, total))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadIssueBillList();
        }

        void DeleteIssueBill(int idIssueBill)
        {

            if (IssueBillDAO.Instance.DeleteIssueBill(idIssueBill))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadIssueBillList();


        }


        void EditReceiptBill(int idReceiptBill, int idProducer, string date, int total)
        {
            if (ReceiptBillDAO.Instance.UpdateReceiptBill(idReceiptBill, idProducer, date, total))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadReceiptBillList();
        }

        void DeleteReceiptBill(int idReceiptBill)
        {

            if (ReceiptBillDAO.Instance.DeleteReceiptBill(idReceiptBill))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadReceiptBillList();


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

            LoadCustomerList();
        }

        void EditCustomer(int idCustomer, string name, string address, string telephone)
        {
            if (CustomerDAO.Instance.UpdateCustomer(idCustomer, name, address, telephone))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadCustomerList();
        }

        void DeleteCustomer(int idCustomer)
        {

            if (CustomerDAO.Instance.DeleteCustomer(idCustomer))
            {
                MessageBox.Show("Xóa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadCustomerList();


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

            LoadListCategory();
        }

        void EditCategory(string name, int id)
        {
            if (GoodsCategoryDAO.Instance.UpdateCategory(name, id))
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }

            LoadListCategory();
        }

        void DeleteCategory(int id)
        {
            
                if (GoodsCategoryDAO.Instance.DeleteCategory(id))
                {
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi!");
                }

                LoadListCategory();
            

        }

        List<Good> SearchGoodsByName(string name)
        {
            List<Good> listGoods = GoodsDAO.Instance.SearchGoodsByName(name);

            return listGoods;
        }

        List<GoodsCategory> SearchCategoryByName(string name)
        {
            List<GoodsCategory> listGoods = GoodsCategoryDAO.Instance.SearchGoodsCategoryByName(name);

            return listGoods;
        }

        List<Producer> SearchProducerByName(string name)
        {
            List<Producer> listProducer = ProducerDAO.Instance.SearchProducerByName(name);

            return listProducer;
        }

        List<Customer> SearchCustomerByName(string name)
        {
            List<Customer> listcustomer = CustomerDAO.Instance.SearchCustomerByName(name);

            return listcustomer;
        }

        List<Account> SearchAccountByName(string name)
        {
            List<Account> listaccount = AccountDAO.Instance.SearchAccountByName(name);

            return listaccount;
        }
        #endregion

        #region Events
        private void tpBill_Click(object sender, EventArgs e)
        {

        }


        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPassWord(userName);
        }

        private void txbGoodsID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvGoods.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvGoods.SelectedCells[0].OwningRow.Cells["idCategory"].Value;
                    int id1 = (int)dtgvGoods.SelectedCells[0].OwningRow.Cells["idProducer"].Value;

                    GoodsCategory category = GoodsCategoryDAO.Instance.GetCategoryByID(id);
                    Producer producer = ProducerDAO.Instance.GetProducerByID(id1);

                    int index = -1;
                    int i = 0;
                    foreach (GoodsCategory item in cbGoodsCategory.Items)
                    {
                        if (item.Id == category.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbGoodsCategory.SelectedIndex = index;

                    index = -1;
                    i = 0;
                    foreach (Producer item in cbProvider.Items)
                    {
                        if (item.IdProducer == producer.IdProducer)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbProvider.SelectedIndex = index;
                }

            }
            catch 
            {

            }
            

        }

       

        private void cbAccountType_TextChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            if (dtgvAccount.SelectedCells.Count > 0 && dtgvAccount.SelectedCells[0].OwningRow.Cells["Type"].Value != null)
            {
                int id = (int)dtgvAccount.SelectedCells[0].OwningRow.Cells["Type"].Value;
                AccountType account = AccountTypeDAO.Instance.GetAccountTypeByID(id);

                int index = -1;
                int i = 0;
                foreach (AccountType item in cbAccountType.Items)
                {
                    if (item.Id == account.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbAccountType.SelectedIndex = index;
            }
        }

        private void btnShowGoods_Click(object sender, EventArgs e)
        {
            LoadListGoods();
        }



        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            int type = (cbAccountType.SelectedItem as AccountType).Id;
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;

            AddAccount(userName, displayName, type);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            int type = (cbAccountType.SelectedItem as AccountType).Id;
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;

            EditAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }


        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            string name = txbGoodsName.Text;
            int idCategory = (cbGoodsCategory.SelectedItem as GoodsCategory).Id;
            int idProducer = (cbProvider.SelectedItem as Producer).IdProducer;
            int amount = Int32.Parse(txtGoodsAmount.Text);
            int price = Int32.Parse(txtGoodsPrice.Text);

            if (GoodsDAO.Instance.InsertGoods(idCategory, idProducer, amount, name, price))
            {
                MessageBox.Show("Thêm thành công!");
                LoadListGoods();
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void btnEditGoods_Click(object sender, EventArgs e)
        {
            string name = txbGoodsName.Text;
            int idCategory = (cbGoodsCategory.SelectedItem as GoodsCategory).Id;
            int idProducer = (cbProvider.SelectedItem as Producer).IdProducer;
            int amount = Int32.Parse(txtGoodsAmount.Text);
            int price = Int32.Parse(txtGoodsPrice.Text);
            int idGoods = Int32.Parse(txbGoodsID.Text);

            if (GoodsDAO.Instance.UpdateGoods(idCategory, idProducer, amount, name, price, idGoods))
            {
                MessageBox.Show("Sửa thành công!");
                LoadListGoods();
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void btnDeleteGoods_Click(object sender, EventArgs e)
        {
            int idGoods = Int32.Parse(txbGoodsID.Text);

            if (GoodsDAO.Instance.DeleteGoods(idGoods))
            {
                MessageBox.Show("Xóa thành công!");
                LoadListGoods();
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }

       



        private void btnAddProducer_Click(object sender, EventArgs e)
        {
            string name = txbNameProducer.Text;
            string address = txbAddressProducer.Text;
            string telephone = txbTeleProducer.Text;

            AddProducer(name, address, telephone);
        }

        private void btnEditProducer_Click(object sender, EventArgs e)
        {
            int idProducer = Int32.Parse(txbIdProducer.Text);
            string name = txbNameProducer.Text;
            string address = txbAddressProducer.Text;
            string telephone = txbTeleProducer.Text;

            EditProducer(idProducer, name, address, telephone);
        }

        private void btnDeleteProducer_Click(object sender, EventArgs e)
        {
            int idProducer = Int32.Parse(txbIdProducer.Text);

            DeleteProducer(idProducer);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadListProducer();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txbCustomerName.Text;
            string address = txbCustomerAddress.Text;
            string telephone = txbCustomerTelephone.Text;

            AddCustomer(name, address, telephone);
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            int idCustomer = Int32.Parse(txbCustomerId.Text);
            string name = txbCustomerName.Text;
            string address = txbCustomerAddress.Text;
            string telephone = txbCustomerTelephone.Text;

            EditCustomer(idCustomer, name, address, telephone);
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            int idCustomer = Int32.Parse(txbCustomerId.Text);

            DeleteCustomer(idCustomer);
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            AddCategory(name);
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txbCategoryID.Text);
            string name = txbCategoryName.Text;
            

            EditCategory(name, id);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txbCategoryID.Text);

            DeleteCategory(id);
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }



        private void btnSearchGoods_Click(object sender, EventArgs e)
        {
            goodslist.DataSource = SearchGoodsByName(txbSearchGoodsName.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goodCategoryList.DataSource = SearchCategoryByName(txbSearchCategory.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            customerlist.DataSource = SearchCustomerByName(txbSearchCustomer.Text);
        }

        private void btnSearchProducer_Click(object sender, EventArgs e)
        {
            producerlist.DataSource = SearchProducerByName(txbSearchProducer.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accountlist.DataSource = SearchAccountByName(txbSearchAccount.Text);
        }

        // issueBill

        private void btnIssueDetail_Click(object sender, EventArgs e)
        {
            int idIssueBill = Int32.Parse(txbIdIssueBill.Text);

            ShowIssueBill(idIssueBill);
        }

        private void btnIsueEdit_Click(object sender, EventArgs e)
        {
            int idIssueBill = Int32.Parse(txbIdIssueBill.Text);
            int idIssueCustomer = Int32.Parse(txbIssueCustomer.Text);
            int idIssueTotal = Int32.Parse(txbIssueTotal.Text);
            string date = txbIssueDate.Text;

            EditIssueBill(idIssueBill, idIssueCustomer, date, idIssueTotal);
        }

        private void btnIssueDelete_Click(object sender, EventArgs e)
        {
            int idIssueBill = Int32.Parse(txbIdIssueBill.Text);

            DeleteIssueBill(idIssueBill);
        }

        private void btnIssueRefresh_Click(object sender, EventArgs e)
        {
            LoadIssueBillList();
        }

        //ReceiptBill
        private void btnReceiptDetail_Click(object sender, EventArgs e)
        {
            int idReceiptBill = Int32.Parse(txbIdReceiptBill.Text);

            ShowReceiptBill(idReceiptBill);
        }

        private void btnEditReceipt_Click(object sender, EventArgs e)
        {
            int idReceiptBill = Int32.Parse(txbIdReceiptBill.Text);
            int idReceiptProducer = Int32.Parse(txbReceiptProducer.Text);
            int idReceiptTotal = Int32.Parse(txbReceiptTotal.Text);
            string date = txbReceiptDate.Text;

            EditReceiptBill(idReceiptBill, idReceiptProducer, date, idReceiptTotal);
        }

        private void btnDeleteReceipt_Click(object sender, EventArgs e)
        {
            int idReceiptBill = Int32.Parse(txbIdReceiptBill.Text);

            DeleteReceiptBill(idReceiptBill);
        }

        private void btnReceiptRefresh_Click(object sender, EventArgs e)
        {
            LoadReceiptBillList();
        }

        #endregion


    }
}
