using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace Fatq.ConncetSql.Mode
{
    public class FatqConnection
    {
        //private static string connectionString =
        //    @"Server = .\XSL;" +
        //    "Database = jdWatch;" +
        //    "User ID = sa;" +
        //    "Password = 123456;";
        private static string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        private SqlConnection ConnectionOpen()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 插入数据,成功true,
        /// </summary>
        /// <param name="sqlData"></param>
        public bool ConnSqlInsert(string sqlData )
        {
            int n = -1;
            SqlConnection sqlconn  = ConnectionOpen();
            SqlCommand cmd = new SqlCommand(sqlData, sqlconn);
           // cmd.ExecuteReader();
            n = cmd.ExecuteNonQuery();//执行返回插入的行数
            sqlconn.Close();

            return n > 0 ? true:false;
        }

        /// <summary>
        /// 更新数据库,成功true,
        /// </summary>
        /// <param name="sqlData"></param>
        public bool ConnSqlUpdate(string updateTbl, string updateValue, string updateRow)
        {
            int n = -1;
            //我们为 lastname 是 "Wilson" 的人添加 firstname：
            //UPDATE Person SET FirstName = 'Fred' WHERE LastName = 'Wilson' 
            SqlConnection sqlconn = ConnectionOpen();
            string sqlUpdate = "update " + updateTbl + " set " + updateValue + " where " + updateRow;
            SqlCommand cmd = new SqlCommand(sqlUpdate, sqlconn);
            n = cmd.ExecuteNonQuery();
            sqlconn.Close();
            if(n>0)
            {
               // MessageBox.Show("修改成功");
            }
            return n > 0 ? true : false;
        }

        /// <summary>
        /// 获取数据库表数据
        /// </summary>
        /// <param name="sqlData"></param>
        //public DataSet ConnSqlSelect(string getTbl )
        //{
        //    SqlConnection conn = ConnectionOpen();
        //    string sqlQuery = "select * from "+getTbl;

        //    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);

        //    DataSet ds = new DataSet();
        //    sda.Fill(ds);
        //    conn.Close();
        //    cmd.Dispose();
        //    return ds;
        //}

        /// <summary>
        /// 自主填写SQL语句，从表中获取指定的数据
        /// </summary>
        /// <param name="selectString"></param>
        /// <returns></returns>
        public DataSet ConnSqlSelect(string selectString)
        {
            SqlConnection conn = ConnectionOpen();
           // string sqlQuery = "select * from " + getTbl;

            SqlCommand cmd = new SqlCommand(selectString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
            cmd.Dispose();
            return ds;
        }

        /// <summary>
        /// 查询数据库是否有指定的数据，有则返回true,否则false
        /// </summary>
        /// <param name="delValue"></param>
        /// <returns></returns>
        public bool ConnSqQuery(string queryTbl, string queryColumn, string queryValue)
        {
            int count = -1;
            SqlConnection sqlconn = ConnectionOpen();
          //  string sqlCheck = "select Count(1) from product_infor where product_skuid=('" + queryValue + "')";
            string sqlCheck = "select Count(1) from "+ queryTbl + " where "+ queryColumn +"=('" + queryValue + "')";

            SqlCommand cmd = new SqlCommand(sqlCheck, sqlconn);
            count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                // MessageBox.Show("数据已经存在！！！");
               
            }

            return count > 0 ? true : false;
        }

        public bool ConnSqQuery(string queryTbl, string queryValue)
        {
            int count = -1;
            SqlConnection sqlconn = ConnectionOpen();
            //  string sqlCheck = "select Count(1) from product_infor where product_skuid=('" + queryValue + "')";
            string sqlCheck = "select Count(1) from " + queryTbl + " where " +  queryValue ;

            SqlCommand cmd = new SqlCommand(sqlCheck, sqlconn);
            count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                // MessageBox.Show("数据已经存在！！！");
            }
            //select a, b, c from x,y,z where e = 1 and f = 2 and g = 3 
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 直接输入SQL语句就即可返回对应的值是否存在，一般用于密码核对
        /// </summary>
        /// <param name="querySqlString"></param>
        /// <returns></returns>
        public bool ConnSqQuery(string querySqlString)
        {
            int count = -1;
            //select a, b, c from x,y,z where e = 1 and f = 2 and g = 3 
            SqlConnection sqlconn = ConnectionOpen();
            SqlCommand cmd = new SqlCommand(querySqlString, sqlconn);
            count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                // MessageBox.Show("数据已经存在！！！");
            }
            
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 删除指定的数据,成功返回true,否则false
        /// </summary>
        /// <param name="delValue"></param>
        /// <returns></returns>
        public bool ConnSqlDel(string delTbl,  string delRow)
        {
            int count = -1;

            //删除某行
            //DELETE FROM Person WHERE LastName = 'Wilson' 
            SqlConnection sqlconn = ConnectionOpen();
            string sqlDel = "delete from " + delTbl + " where "  + delRow;
            SqlCommand cmd = new SqlCommand(sqlDel, sqlconn);
            count = cmd.ExecuteNonQuery();
            sqlconn.Close();
            if (count > 0)
            {
                // MessageBox.Show("删除成功");
            }

            return count > 0 ? true : false;
        }
    }
}