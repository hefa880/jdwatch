using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiInputDataStruct.Mode;
using Fatq.ConncetSql.Mode;
using System.Windows.Forms;
using System.Data;
using WareDealer.Mode;

////////所有SQL操作填写都在这里完成，最后调用SqlConnect.cs的函数完成
////////
//////

namespace Fatq.SqlCommit.Mode
{
    public class SqlCommit
    {

        /// <summary>
        /// 插入数据,根据不同的表，插入的数据格式不一样
        /// </summary>
        /// <param name="toTabl"></param>
        /// 要插入的表
        /// <param name="toValues"></param>
        /// 要插入的值
        /// <returns></returns>
        public bool Sqlcommit_Insert(string toTabl, string toValues)
        {
            bool bRet = false;

            return bRet;
        }
        /// <summary>
        /// 由录入接口调用
        /// 向基本信息表插入数据，重复数据则不插入，应该由调用者处理，处理应该有放弃或是调用更新接口来更新此条数据
        /// </summary>
        /// <param name="toValues"></param>
        /// <returns></returns>
        public bool Sqlcommit_Insert(CUiInputDataStruct toValues)
        {
            bool bRet = false;
            FatqConnection sqlconn = new FatqConnection();
            string sqlData = "insert into product_infor( product_name,  product_serial,  product_color,product_version,  product_skuid, product_seller,product_warn_price,produect_warn_drict) values ('" +
                toValues.ProductName + "', '" + toValues.ProductSerial + "', '" + toValues.ProductColor + "', '" + 
                toValues.ProductVersion + "','" + toValues.ProductSkuid + "','" + toValues.ProductSeller + "' ,'" + toValues.ProductWarnPrice + "'," + toValues.ProductWarnDriect+"')";

            bRet = sqlconn.ConnSqQuery("product_infor", "product_skuid", toValues.ProductSkuid);
            if( true == bRet )
            {
                //  MessageBox.Show("数据重复！！！");
                bRet = false;
            }
            else 
            {
                bRet = sqlconn.ConnSqlInsert(sqlData);
            }
 
            return bRet;
        }

        public bool Sqlcommit_Insert(WarePrice toValues)
        {
            bool bRet = false;
            FatqConnection sqlconn = new FatqConnection();

            string sqlData = "insert into product_price(  product_skuid,product_warning_price,product_jd_price,product_app_price,product_weixin_price,product_qq_price,product_time_get,product_status) values ('" +
                toValues.ProductSkuid + "', '" + toValues.ProductWarnPrice + "', '" + toValues.ProductPCPrice + "', '" +
                toValues.ProductAppPrice + "','" + toValues.ProductWeiXinPrice + "','" + toValues.ProductQQPrice + "' ,'" + toValues.ProductGetTime + "','" + toValues.ProductStock + "')";

            bRet = sqlconn.ConnSqQuery("product_infor", "product_skuid", toValues.ProductSkuid);
            if (true == bRet)
            {
                
                bRet = sqlconn.ConnSqlInsert(sqlData);
               
            }
            else
            {
                //  MessageBox.Show("无此基本数据！");
                bRet = false;
            }

            return bRet;
        }
       /// <summary>
       /// 由监控接口调用
        /// 向价格表插入数据，如果数据不存在，则放弃插入
       /// </summary>
       /// <param name="InsertPrice"></param>
       /// <returns></returns>
        public bool Sqlcommit_Insert(string sqlData)
        {
            bool bRet = false;
            FatqConnection sqlconn = new FatqConnection();
          
            bRet = sqlconn.ConnSqlInsert(sqlData);

            //string sqlData =
            //   "insert into product_price( product_skuid,product_warning_price,product_jd_price,product_app_price,product_weixin_price,product_qq_price,product_time_get,product_status) values ('" +
            //   wareInfor.SkuID + "', '" + wareInfor.ProductPCWarnPrice + "', '" + wareInfor.ProductPrice + "', '" +
            //   wareInfor.ProductMobilePrice + "','" + wareInfor.ProductWXPrice + "', '" + wareInfor.ProductQQPrice + "', '" +
            //   wareInfor.CreateTime + "',' " + wareInfor.ProductIsSaled + "')";

            // bRet = sqlconn.ConnSqQuery("product_infor", "product_skuid", toValues.ProductSkuid);
            // if (true == bRet)
            // {
            //     //  MessageBox.Show("数据存在！");
            //     bRet = sqlconn.ConnSqlInsert(sqlData);
            // }
            // else
            // {

            // }

            return bRet;
        }
        public bool Sqlcommit_Update(string toTabl, string toValues )
        {
            bool bRet = false;

            return bRet;
        }

        public bool Sqlcommit_Update(CUiInputDataStruct toValues)
        {
            bool bRet = false;
            FatqConnection sqlconn = new FatqConnection();

            bRet = sqlconn.ConnSqQuery("product_infor", "product_skuid", toValues.ProductSkuid);
            if (true == bRet)
            {
                //  MessageBox.Show("有数据存在！！");
                string sqlData = "product_name = '" + toValues.ProductName + "', product_serial = '" + toValues.ProductSerial +
                                "', product_color = '" + toValues.ProductColor + "', product_version = '" + toValues.ProductVersion +
                                "', product_skuid = '" + toValues.ProductSkuid + "', product_seller = '" + toValues.ProductSeller +
                                "', product_warn_price = '" + toValues.ProductWarnPrice + "', produect_warn_drict = '"+toValues.ProductWarnDriect+"'";
                bRet = sqlconn.ConnSqlUpdate("product_infor", sqlData, "product_skuid = '" + toValues.ProductSkuid + "'");
            }
            else
            {
               
            }
            return bRet;
        }

        public bool Sqlcommit_InsertAll(string tbl,DataTable dt)
        {
            bool bRet = false;

            FatqConnection sqlconn = new FatqConnection();
            bRet = sqlconn.ConnSqlInsert(tbl,dt);

            return bRet;
        }
        public bool Sqlcommit_Update(string  toValues)
        {
            bool bRet = false;
            FatqConnection sqlconn = new FatqConnection();

            bRet = sqlconn.ConnSqQuery(toValues);

            return bRet;
        }
         public int Sqlcommit_Qurey(string toTabl, string toValues)
         {
             int iret = -1;

             return iret;
         }

         public DataSet Sqlcommit_Select(string sqlString)
         {
             ///select * from " + getTbl
             FatqConnection sqlconn = new FatqConnection();
             //string sqlString = "select * from " + toTabl;
             DataSet ds = sqlconn.ConnSqlSelect(sqlString);

             return ds;
         }
         public bool Sqlcommit_Del(string toTabl, string toValues)
         {
             // DELETE FROM 表名称 WHERE 列名称 = 值
             FatqConnection sqlconn = new FatqConnection();
             return sqlconn.ConnSqlDel(toTabl, toValues);

         }


    }
}