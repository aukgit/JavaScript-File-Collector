using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaScriptFileCollector {
    public partial class FileNameCollector : Form {
        public FileNameCollector() {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void toolStripButton3_Click(object sender, EventArgs e) {

        }

        private void ReadXml(DataSet ds, string fileLocation) {
            if (!string.IsNullOrEmpty(fileLocation)) {
                if (File.Exists(fileLocation)) {
                    ds.ReadXmlSchema(fileLocation);
                }
            }
        }

        private void FileNameCollector_Load(object sender, EventArgs e) {
            ConfigDataSet = new Config.Config();
            ReadXml(ConfigDataSet, ConfigurationFilePathText.Text);

            //DataAdapter  adp = new OdbcDataAdapter();
            //adp.Fill(ConfigDataSet);

        }

        private void button3_Click(object sender, EventArgs e) {
            LoadCatelogoryEdit();
        }

        private void button4_Click(object sender, EventArgs e) {
            //MessageBox.Show(CatagoryCombo.SelectedValue.ToString());
            if (CatagoryCombo.SelectedValue == null) {
                MessageBox.Show("Sorry cannot edit null.");
                return;
            }
            var id = (int) CatagoryCombo.SelectedValue;

            if (id > 0) {
                LoadCatelogoryEdit(id);
            }
        }

        private void LoadCatelogoryEdit(int? id = null) {
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.ConfigDataSet = ConfigDataSet;
            categoryForm.FileNameCollectorForm = this;
            if (id != null) {
                string findId = id.Value.ToString();
                categoryForm.CatagoryBindingSource.Find("ConfigCategoryID", findId);
            }
            categoryForm.ShowDialog(this);
            configCategoryBindingSource.DataMember = "ConfigCategory";
            configCategoryBindingSource.DataSource = this.ConfigDataSet;
          

            CatagoryCombo.ResetBindings();
        }
    }
}
