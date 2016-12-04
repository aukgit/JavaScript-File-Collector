using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaScriptFileCollector {
    public partial class CategoryForm : Form {

        internal FileNameCollector FileNameCollectorForm;

        public CategoryForm() {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {

        }

        private void Savebtn_Click(object sender, EventArgs e) {
            CatagoryBindingSource.EndEdit();
            var ds = (CatagoryBindingSource.DataSource as Config.Config);

            FileNameCollectorForm.ConfigDataSet = ds;

            //FileNameCollectorForm.ConfigDataSet = ConfigDataSet;
            Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e) {
            CatagoryBindingSource.DataSource = ConfigDataSet;
            CatagoryBindingSource.DataMember = "ConfigCategory";
        }
    }
}
