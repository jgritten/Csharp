/*Update/ Delete Tab Fully Coded By: Justin Gritten*/
/*Add New Record Tab Fully Coded By: Anushka De Silva*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPP248_Csharp_DotNet
{
    public partial class frmTEManager : Form
    {
        public frmTEManager()
        {
            InitializeComponent();
        }

        // variables
        string username;
        string selected = "";
        string entryVal;
        private Supplier supplier;
        private Product product;
        private Product_Suppliers prodSup;
        private Package package;
        //private Packages_Products_Suppliers pkgProdSup;

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        private void btnSupSaveRecord_Click(object sender, EventArgs e)
        {
            if (IsValidSupplier())
            {
                supplier = new Supplier();
                this.PutSupplierData(supplier);
                try
                {
                    supplier.SupplierID = Convert.ToInt32(SupplierDB.AddSupplier(supplier));
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Entry Successfully Added!", "Supplier Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayControls();
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                catch (Exception ex1)
                {

                    MessageBox.Show(ex1.Message, ex1.GetType().ToString());
                }
            }
        }
        private bool IsValidSupplier()
        {
            return  Validator.IsPresent(txtSupSupName) &&
                    Validator.IsPresent(txtSupSupplierID) &&
                    Validator.IsInt32(txtSupSupplierID);
        }

        private void PutSupplierData(Supplier sup)
        {
            supplier.SupplierID = Convert.ToInt32(txtSupSupplierID.Text);
            supplier.SupplierName = txtSupSupName.Text;
        }

        //Functionality of Supplier's Clear Record Button
        private void btnSupClearRecord_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        //Functionality of Supplier's Exit Button
        private void btnSupExit_Click(object sender, EventArgs e)
        {
            ClearControls();
            grpBoxSuppliers.Visible = false;
        }


        /*Functionality of Product Entry Form*/
        //Functionality of Product's Save Record Button
        private void btnProdSaveRecord_Click(object sender, EventArgs e)
        {
            if (IsValidProduct())
            {
                product = new Product();
                product.ProductName = txtProdProductName.Text;
                try
                {
                    int num = ProductDB.AddProduct(product);
                    if (num > 0)
                    {
                        MessageBox.Show("Entry Successfully Added!", "Package Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    DisplayControls();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message, ex1.GetType().ToString());
                }
            }
            else {MessageBox.Show("Product Name cannot be Blank");}
        }

        private bool IsValidProduct_Supplier()
        {
            return
                Validator.IsPresent(txtProdProductName);
        }

        private bool IsValidProduct()
        {
            return Validator.IsPresent(txtProdProductName);
        }

        //Functionality of Product's Clear Record Button
        private void btnProdClearRecord_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        //Functionality of Product's Exit Button
        private void btnProdExit_Click(object sender, EventArgs e)
        {
            ClearControls();
            grpBoxProducts.Visible = false;
        }
        
        //Functionality of ComboBoxForms to select different forms and display exact Entry Form 
        private void cmbForms_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    List<Supplier> sups = SupplierDB.GetSupplierByName();
        //    List<Product> props = ProductDB.GetProductsByName();


        //    entryVal = cmbForms.SelectedItem.ToString();
        //    this.NewRecord();
        //    switch (entryVal)
        //    {
        //        case "Packages":
        //            grpBoxPackages.Visible = true;
        //            grpBoxPackages.BringToFront();
        //            grpBoxSuppliers.Visible = false;
        //            grpBoxProducts.Visible = false;
        //            grpBoxProdSup.Visible = false;
        //            List<Product_Suppliers> psups = Product_SuppliersDB.GetAllProduct_SupplierByNames();
        //            dgvProdSupData.DataSource = psups;
        //            break;
        //        case "Suppliers":
        //            grpBoxPackages.Visible = false;
        //            grpBoxSuppliers.Visible = true;
        //            grpBoxSuppliers.BringToFront();
        //            grpBoxProducts.Visible = false;
        //            grpBoxProdSup.Visible = false;
        //            break;
        //        case "Products":

        //            grpBoxPackages.Visible = false;
        //            grpBoxSuppliers.Visible = false;
        //            grpBoxProdSup.Visible = false;
        //            grpBoxProducts.Visible = true;
        //            grpBoxProducts.BringToFront();
        //            break;
        //        case "Products Suppliers":
        //            grpBoxPackages.Visible = false;
        //            grpBoxSuppliers.Visible = false;
        //            grpBoxProdSup.Visible = true;
        //            grpBoxProducts.BringToFront();
        //            grpBoxProducts.Visible = false;


        //            cmbBoxProdSupProdName.DataSource = props;
        //            cmbBoxProdSupProdName.DisplayMember = "ProductName";
        //            cmbBoxProdSupProdName.ValueMember = "ProductId";

        //            cmbBoxProdSupSupplierName.DataSource = sups;
        //            cmbBoxProdSupSupplierName.DisplayMember = "SupplierName";
        //            cmbBoxProdSupSupplierName.ValueMember = "SupplierID";


        //            break;
        //        default:
        //            MessageBox.Show("Please Select One of Listed Options", "Value Selector", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            break;
        //    }

        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Supplier> sups = SupplierDB.GetSupplierByName();
            List<Product> props = ProductDB.GetProductsByName();


            entryVal = cmbForms.SelectedItem.ToString();
            this.NewRecord();
            switch (entryVal)
            {
                case "Packages":
                    grpBoxPackages.Visible = true;
                    grpBoxSuppliers.Visible = false;
                    grpBoxProducts.Visible = false;
                    grpBoxProdSup.Visible = false;
                    List<Product_Suppliers> psups = Product_SuppliersDB.GetAllProduct_SupplierByNames();
                    dgvProdSupData.DataSource = psups;
                    dgvProdSupData.Columns[1].Visible = false;
                    dgvProdSupData.Columns[2].Visible = false;

                    break;
                case "Suppliers":
                    grpBoxPackages.Visible = false;
                    grpBoxSuppliers.Visible = true;
                    grpBoxProducts.Visible = false;
                    grpBoxProdSup.Visible = false;
                    break;
                case "Products":

                    grpBoxPackages.Visible = false;
                    grpBoxSuppliers.Visible = false;
                    grpBoxProdSup.Visible = false;
                    grpBoxProducts.Visible = true;
                    break;
                case "Products Suppliers":
                    grpBoxPackages.Visible = false;
                    grpBoxSuppliers.Visible = false;
                    grpBoxProdSup.Visible = true;
                    grpBoxProducts.Visible = false;


                    cmbBoxProdSupProdName.DataSource = props;
                    cmbBoxProdSupProdName.DisplayMember = "ProductName";
                    cmbBoxProdSupProdName.ValueMember = "ProductId";

                    cmbBoxProdSupSupplierName.DataSource = sups;
                    cmbBoxProdSupSupplierName.DisplayMember = "SupplierName";
                    cmbBoxProdSupSupplierName.ValueMember = "SupplierID";


                    break;
                default:
                    MessageBox.Show("Please Select One of Listed Options", "Value Selector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        //Functionality of Form Load of frmTEManager
        private void newRegistration_Click(object sender, EventArgs e)
        {


        }
        /*Functionality of Package Entry Form*/
        //Functionality of Package's Save Record Button
        private void btnPkgPackageSaveRecord_Click(object sender, EventArgs e)
        {
            if (IsValidPackageData())
            {
                Package newPack = new Package();
                newPack = PutPackage(newPack);

                try
                {
                    DateTime startDate = dtpPkgPackageStartDate.Value;
                    DateTime endDate = dtpPkgPackageEndDate.Value;
                    int commision = Convert.ToInt32(txtPkgPackageAgencyCommission.Text);
                    int basePrice = Convert.ToInt32(txtPkgPackageBasePrice.Text);
                    if (startDate > endDate)
                    {
                        MessageBox.Show("Package Start Date need to be Before Package End Date", "Validation Rule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (commision > basePrice)
                    {
                        MessageBox.Show("Commission Cannot Be Greater Than the Base Price", "Validation Rule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        newPack.PackageId = Convert.ToInt32(PackageDB.AddItem(newPack));
                        //Packages_Products_Suppliers pkgProdSup = new Packages_Products_Suppliers();
                        //pkgProdSup.PackageId = newPack.PackageId;
                        //pkgProdSup.ProductSupplierId = Convert.ToInt32(txtPkgProdSupID.Text);
                        //this.PutPackageSupplierProduct(pkgProdSup);
                        //pkgProdSup.PackageId = Convert.ToInt32(Packages_Products_SuppliersDB.AddItem(pkgProdSup));
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Entry Successfully Added!", "Package Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayControls();
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                catch (Exception ex1)
                {

                    MessageBox.Show(ex1.Message, ex1.GetType().ToString());
                }
            }
        }

        private bool IsValidPackageData()
        {
            return
                Validator.IsPresent(txtPkgPackageName) &&
                Validator.IsPresent(txtPkgPackageDesc) &&
                Validator.IsPresent(dtpPkgPackageStartDate) &&
                Validator.IsPresent(dtpPkgPackageEndDate) &&
                Validator.IsDecimal(txtPkgPackageBasePrice) &&
                Validator.IsDecimal(txtPkgPackageAgencyCommission);
        }

        private Package PutPackage(Package newPackage)
        {
            newPackage.pkgName = txtPkgPackageName.Text.ToString();
            newPackage.pkgDesc = txtPkgPackageName.Text.ToString();
            newPackage.pkgStartDate = dtpPkgPackageStartDate.Value;
            newPackage.pkgEndDate = dtpPkgPackageEndDate.Value;
            newPackage.pkgBasePrice = Convert.ToInt32(txtPkgPackageBasePrice.Text);
            newPackage.pkgAgencyCommission = Convert.ToInt32(txtPkgPackageAgencyCommission.Text);
            return newPackage;
        }

        //This is Get Information from Textbox of Package Supplier Groupbox's Product-Supplier ID and Putthing Info into Database
        private void PutPackageSupplierProduct(Packages_Products_Suppliers pkgProdSup)
        {
            pkgProdSup.ProductSupplierId = Convert.ToInt32(txtPkgProdSupID.Text);
        }

        //Functionality of Package's Clear Record Button
        private void btnPkgPackageClearRecord_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        //Functionality of Package's Exit Button
        private void btnPkgPackageExit_Click(object sender, EventArgs e)
        {
            ClearControls();
            grpBoxPackages.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (selected != "")
            {
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                dgvInfo.Enabled = true;
                pbxTravel.Visible = true;
                pbxTravelBig.Visible = false;
                dgvInfo.Focus();
                btnLast.Enabled = true;
                btnNext.Enabled = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                if (cbxSearchTable.SelectedItem.ToString() != null)
                {
                    selected = cbxSearchTable.SelectedItem.ToString();
                }

                if (selected == "Packages")
                {
                    List<Package> packages = PackageDB.GetPackages();
                    gbxPackages.Visible = true;
                    gbxPackages.BringToFront();
                    dgvInfo.DataSource = packages;
                }
                else if (selected == "Products")
                {
                    List<Product> products = ProductDB.GetProducts();
                    gbxProducts.Visible = true;
                    gbxProducts.BringToFront();
                    dgvInfo.DataSource = products;
                }
                else if (selected == "Suppliers")
                {
                    List<Supplier> suppliers = SupplierDB.GetSuppliers();
                    gbxSuppliers.Visible = true;
                    gbxSuppliers.BringToFront();
                    dgvInfo.DataSource = suppliers;
                }
                else if (selected == "Product Suppliers")
                {
                    List<Product_Suppliers> product_suppliers = Product_SuppliersDB.GetProduct_Suppliers();
                    gbxProductSuppliers.Visible = true;
                    gbxProductSuppliers.BringToFront();
                    cbxProdSupProducts.DataSource = ProductDB.GetProducts();
                    cbxProdSupSuppliers.DataSource = SupplierDB.GetSuppliers();
                    dgvInfo.DataSource = product_suppliers;
                    dgvInfo.Columns[3].Visible = false;
                    dgvInfo.Columns[4].Visible = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (selected == "Packages")
            {
                foreach (DataGridViewRow row in dgvInfo.SelectedRows)
                {
                    package = (Package)row.DataBoundItem;
                    lblPkgId.Text = package.PackageId.ToString();
                    txtName.Text = package.pkgName.ToString();
                    txtCommission.Text = String.Format("{0:.##}", package.pkgAgencyCommission);
                    txtPrice.Text = String.Format("{0:.##}", package.pkgBasePrice);
                    dtpStartDate.Value = package.pkgStartDate.Date;
                    dtpEndDate.Value = package.pkgEndDate.Date;
                    txtDescription.Text = package.pkgDesc.ToString();
                }
            }
            else if (selected == "Products")
            {
                foreach (DataGridViewRow row in dgvInfo.SelectedRows)
                {
                    product = (Product)row.DataBoundItem;
                    txtProductName.Text = product.ProductName;
                    lblProductId.Text = product.ProductId.ToString();
                }
                
            }
            else if (selected == "Suppliers")
            {
                foreach (DataGridViewRow row in dgvInfo.SelectedRows)
                {
                    supplier = (Supplier)row.DataBoundItem;
                    txtSupplierName.Text = supplier.SupplierName;
                    lblSupplierId.Text = supplier.SupplierID.ToString();
                }
            }
            else if (selected == "Product Suppliers")
            {
                foreach (DataGridViewRow row in dgvInfo.SelectedRows)
                {
                    prodSup = (Product_Suppliers)row.DataBoundItem;
                    product = ProductDB.GetProductById(prodSup.ProductID);
                    supplier = SupplierDB.GetSupplierById(prodSup.SupplierID);
                    //cbxProdSupProducts.DisplayMember = product.ProductName.ToString();
                    //cbxProdSupProducts.ValueMember = product.ProductId.ToString();
                    cbxProdSupProducts.DisplayMember = "ProductName";
                    cbxProdSupProducts.ValueMember = "ProductId";
                    
                    cbxProdSupSuppliers.DisplayMember = "SupplierName";
                    cbxProdSupSuppliers.ValueMember = "SupplierID";
                    lblProductSuppliersId.Text = prodSup.ProductSuppliersID.ToString();
                }
            }  
        }

        //This functions loads Product-Supplier ID when user click certain record from DataGrid View
        private void dgvProdSupData_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow prodsupRow in dgvProdSupData.SelectedRows)
            {
                if (entryVal == "Packages Entry")
                {
                    Product_Suppliers prodSup = (Product_Suppliers)prodsupRow.DataBoundItem;
                    txtPkgProdSupID.Text = prodSup.ProductSuppliersID.ToString();
                }
            }
        }

        //private void dgvProdSupData_SelectionChanged(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow row in dgvProdSupData.SelectedRows)
        //    {
        //        if (entryVal == "Packages Entry")
        //        {
        //            Package pack = (Package)row.DataBoundItem;
        //            //txtPkgProdSupID.Text = prodSup.ProductSuppliersID.ToString();
        //        }
        //    }
        //}

        //This is a private function which clear textboxs if it is needed
        private void ClearControls()
        {
            txtPkgPackageAgencyCommission.Text = " ";
            txtPkgPackageBasePrice.Text = " ";
            txtPkgPackageDesc.Text = " ";
            txtPkgPackageName.Text = " ";
            txtPkgProdSupID.Text = " ";

            txtSupSupName.Text = " ";
            txtSupSupplierID.Text = " ";

            txtProdProductName.Text = " ";
        }

        //This is a Private Function Which Disable all the Input Controls After a New Records 
        private void DisplayControls()
        {
            //Text Boxes, Date Time Picker and Grid View in Packages Group Box
            txtPkgPackageAgencyCommission.Enabled = false;
            txtPkgPackageBasePrice.Enabled = false;
            txtPkgPackageDesc.Enabled = false;
            txtPkgPackageName.Enabled = false;
            txtPkgProdSupID.Enabled = false;
            dtpPkgPackageEndDate.Enabled = false;
            dtpPkgPackageStartDate.Enabled = false;
            dgvProdSupData.Enabled = false;

            //Text Boxes in Supplier Group Box
            txtSupSupName.Enabled = false;
            txtSupSupplierID.Enabled = false;

            //Text Box in Product Group Box
            txtProdProductName.Enabled = false;

            //All Save Record Buttons in Three Different Group Boxes
            btnPkgPackageSaveRecord.Enabled = false;
            btnSupSaveRecord.Enabled = false;
            btnProdSaveRecord.Enabled = false;

            //All Clear Record Buttons in Three Different Group Boxes
            btnPkgPackageClearRecord.Enabled = false;
            btnSupClearRecord.Enabled = false;
            btnProdClearRecord.Enabled = false;

            cmbBoxProdSupProdName.Enabled = false;
            cmbBoxProdSupSupplierName.Enabled = false;
            btnProdSupSaveRecord.Enabled = false;
        }

        //This is a Private Function Which Enable all the Input Controls for New Records 
        private void NewRecord()
        {
            //Text Boxes, Date Time Picker and Grid View in Packages Group Box
            txtPkgPackageAgencyCommission.Enabled = true;
            txtPkgPackageBasePrice.Enabled = true;
            txtPkgPackageDesc.Enabled = true;
            txtPkgPackageName.Enabled = true;
            txtPkgProdSupID.Enabled = false;
            dtpPkgPackageEndDate.Enabled = true;
            dtpPkgPackageStartDate.Enabled = true;
            dgvProdSupData.Enabled = true;

            //Text Boxes in Supplier Group Box
            txtSupSupName.Enabled = true;
            txtSupSupplierID.Enabled = true;

            //Text Box in Product Group Box
            txtProdProductName.Enabled = true;

            //All Save Record Buttons in Three Different Group Boxes
            btnPkgPackageSaveRecord.Enabled = true;
            btnSupSaveRecord.Enabled = true;
            btnProdSaveRecord.Enabled = true;

            //All Clear Record Buttons in Three Different Group Boxes
            btnPkgPackageClearRecord.Enabled = true;
            btnSupClearRecord.Enabled = true;
            btnProdClearRecord.Enabled = true;
        }

        

        private void frmTEManager_Load(object sender, EventArgs e)
        {
            cmbForms.SelectedIndex = 0;
            cbxSearchTable.SelectedIndex = 0;
            lblUserName.Text = username;
        }

        private void cbxSearchTable_DropDown(object sender, EventArgs e)
        {
            cbxSearchTable.Items.Remove("<Select Items to Display>");
            btnSearch.Enabled = true;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            dgvInfo.Rows[0].Selected = true;
            dgvInfo.CurrentCell = dgvInfo.Rows[0].Cells[0];            
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            dgvInfo.Rows[dgvInfo.Rows.Count - 1].Selected = true;
            dgvInfo.CurrentCell = dgvInfo.Rows[dgvInfo.Rows.Count - 1].Cells[0];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentCell.RowIndex <= dgvInfo.Rows.Count - 2)
            {
                dgvInfo.Rows[dgvInfo.CurrentCell.RowIndex + 1].Selected = true;
                dgvInfo.CurrentCell = dgvInfo.Rows[dgvInfo.CurrentCell.RowIndex + 1].Cells[0];
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentCell.RowIndex >= 1)
            {
                dgvInfo.Rows[dgvInfo.CurrentCell.RowIndex - 1].Selected = true;
                dgvInfo.CurrentCell = dgvInfo.Rows[dgvInfo.CurrentCell.RowIndex - 1].Cells[0];
            }
        }

        private void cbxSearchTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = cbxSearchTable.SelectedItem.ToString();
            dgvInfo.Enabled = false;
            btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
        }

        private void btnSupUpdate_Click(object sender, EventArgs e)
        {
            Supplier oldSupplier = SupplierDB.GetSupplierById(Convert.ToInt32(lblSupplierId.Text));
            Supplier newSupplier = new Supplier();
            newSupplier.SupplierID = Convert.ToInt32(lblSupplierId.Text);
            newSupplier.SupplierName = txtSupplierName.Text;

            if (Validator.IsPresent(txtSupplierName))
            {
                if (SupplierDB.UpdateSupplier(oldSupplier, newSupplier))
                {
                    MessageBox.Show("Supplier Updated Successfully");
                }
            }

            List<Supplier> suppliers = SupplierDB.GetSuppliers();
            dgvInfo.DataSource = suppliers;
            dgvInfo.Focus();
        }

        private void btnSupDelete_Click(object sender, EventArgs e)
        {
            supplier = SupplierDB.GetSupplierById(Convert.ToInt32(lblSupplierId.Text));
            if (SupplierDB.DeleteSupplier(supplier))
            {
                MessageBox.Show("Supplier Deleted Successfully");
            }

            List<Supplier> suppliers = SupplierDB.GetSuppliers();
            dgvInfo.DataSource = suppliers;
            dgvInfo.Focus();
        }

        private void btnProdUpdate_Click(object sender, EventArgs e)
        {
            Product oldProduct = ProductDB.GetProductById(Convert.ToInt32(lblProductId.Text));
            Product newProduct = new Product();
            newProduct.ProductId = Convert.ToInt32(lblProductId.Text);
            newProduct.ProductName = txtProductName.Text;
            if (ProductDB.UpdateProduct(oldProduct, newProduct))
            {
                MessageBox.Show("Product Updated Successfully");
            }

            List<Product> products = ProductDB.GetProducts();
            dgvInfo.DataSource = products;
            dgvInfo.Focus();
        }

        private void btnProdDelete_Click(object sender, EventArgs e)
        {
            product = ProductDB.GetProductById(Convert.ToInt32(lblProductId.Text));
            if (ProductDB.DeleteProduct(product))
            {
                MessageBox.Show("Product Deleted Successfully");

            }

            List<Product> products = ProductDB.GetProducts();
            dgvInfo.DataSource = products;
            dgvInfo.Focus();
        }

        private void btnPkgDelete_Click(object sender, EventArgs e)
        {
            package = PackageDB.GetPackageById(Convert.ToInt32(lblPkgId.Text));
            if (PackageDB.Delete(package))
            {
                MessageBox.Show("Package Deleted Successfully");
            }
            List<Package> packages = PackageDB.GetPackages();
            dgvInfo.DataSource = packages;
            dgvInfo.Focus();
        }

        private void btnPkgUpdate_Click(object sender, EventArgs e)
        {
            Package newPackage = new Package();
            Package oldPackage = new Package();
            newPackage.PackageId = Convert.ToInt32(lblPkgId.Text);
            newPackage.pkgName = txtName.Text;
            newPackage.pkgStartDate = dtpStartDate.Value;
            newPackage.pkgEndDate = dtpEndDate.Value;
            newPackage.pkgBasePrice = Convert.ToDecimal(txtPrice.Text);
            newPackage.pkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
            newPackage.pkgDesc = txtDescription.Text;


            foreach (DataGridViewRow row in dgvInfo.SelectedRows)
            {
                oldPackage = (Package)row.DataBoundItem;
                lblPkgId.Text = oldPackage.PackageId.ToString();
                txtName.Text = oldPackage.pkgName.ToString();
                txtCommission.Text = String.Format("{0:.##}", oldPackage.pkgAgencyCommission);
                txtPrice.Text = String.Format("{0:.##}", oldPackage.pkgBasePrice);
                dtpStartDate.Value = oldPackage.pkgStartDate.Date;
                dtpEndDate.Value = oldPackage.pkgEndDate.Date;
                txtDescription.Text = oldPackage.pkgDesc.ToString();
            }

            if (PackageDB.Update(oldPackage, newPackage))
            {
                MessageBox.Show("Package Updated Successfully");
            }
            List<Package> packages = PackageDB.GetPackages();
            dgvInfo.DataSource = packages;
            dgvInfo.Focus();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
        private void btnProdSupSaveRecord_Click(object sender, EventArgs e)
        {
            Product_Suppliers prodSupplier = new Product_Suppliers();
            prodSupplier.ProductID = Int32.Parse(cmbBoxProdSupProdName.SelectedValue.ToString());
            prodSupplier.SupplierID = Int32.Parse(cmbBoxProdSupSupplierName.SelectedValue.ToString());
            //prodSup.ProductSuppliersID = Convert.ToInt32(Product_SuppliersDB.AddItem(prodSupplier));
            try
            {
                int num = Convert.ToInt32(Product_SuppliersDB.AddItem(prodSupplier));
                if (num > 0)
                {
                    MessageBox.Show("Entry Successfully Added!", "Product Supplier Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    DisplayControls();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        private void btnProdSupExit_Click(object sender, EventArgs e)
        {
            ClearControls();
            grpBoxProdSup.Visible = false;
        }

        private void btnProdSupExit_Click_1(object sender, EventArgs e)
        {
            grpBoxProdSup.Visible = false;
        }

        private void btnProdSupDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
