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

namespace ConnectDataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.mycon.Open();
            string sql = "select top 2 * from cdsgus";
            SqlDataAdapter myda = new SqlDataAdapter(sql, Program.mycon);
            DataSet myds = new DataSet();
            myda.Fill(myds, "lianxi");
            fpSpread1.DataSource = myds.Tables["lianxi"];
        }
    }
}
