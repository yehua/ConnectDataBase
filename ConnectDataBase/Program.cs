using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConnectDataBase
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 
        public static SqlConnection mycon;
        [STAThread]
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConnectDataBase();
            Application.Run(new Form1());
        }
        /// <summary>
        ///链接数据库 
        /// </summary>
        private static void ConnectDataBase()
        {
            string con, sql;
            con = "Server=.;Database=shifenzheng;Trusted_Connection=SSPI";
            mycon = new SqlConnection(con);
        }
    }
}
