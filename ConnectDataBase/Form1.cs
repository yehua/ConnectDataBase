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
        DataTable Results = new DataTable();
        public Form1()
        {
            InitializeComponent();
            setDt();
            setStyle();
        }

        struct Customer
        {
            string Name;//姓名
            string ctfid;//身份证号
            string gender;//性别
            string Birthday;//生日
            string address;//地址
            string Mobile;//电话
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.mycon.Open();
            string sql = "SELECT TOP 1000 Name as 姓名, ctfid as 身份证号 ,gender as 性别 ,Birthday as 生日 ,address as 地址,Mobile as 电话  from cdsgus";
            if (textBox1.Text != "" && textBox1.Text != null)
            {
                sql += " where Name='" + textBox1.Text;
                sql += "'";
            }
            SqlDataAdapter myda = new SqlDataAdapter(sql, Program.mycon);
            Program.mycon.Close();
            DataSet myds = new DataSet();
            myda.Fill(myds, "lianxi");
            Results= myds.Tables["lianxi"];

            fpSpread1.DataSource = Results;
            setStyle();
        }
        /// <summary>
        /// 设置dt格式
        /// </summary>
        private void setDt()
        {
            Results.Columns.Add("姓名");
            Results.Columns.Add("身份证号");
            Results.Columns.Add("性别");
            Results.Columns.Add("生日");
            Results.Columns.Add("地址");
            Results.Columns.Add("电话");
        }
        /// <summary>
        /// 设置样式
        /// </summary>
        private void setStyle()
        {
            fpSpread1_Sheet1.Columns[0].Width =50;
            fpSpread1_Sheet1.Columns[1].Width =115;
            fpSpread1_Sheet1.Columns[2].Width = 35;
            fpSpread1_Sheet1.Columns[3].Width = 60;
            fpSpread1_Sheet1.Columns[4].Width = 250;
            fpSpread1_Sheet1.Columns[5].Width = 154;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "添加")
            {
                button2.Text = "取消";

            }
            else
            {
                button2.Text = "添加";
            }
           // button2.Text= button2.Text=="添加" ? "取消": "添加";
        }
    }
}
