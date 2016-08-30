using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fatq.SqlCommit.Mode;
using System.Threading;
using WareDealer;
using WareDealer.Mode;
using WareDealer.Helper;
using Hank.ComLib;
using Hank.UiCtlLib;
using UiInputDataStruct.Mode;



namespace jdWatch
{
    public delegate void uiWatch_SndWarnList(IList<InputDataStruct> uiInputList);
    public partial class uiWatch : Form
    {
        IList<InputDataStruct> uiInputList = new List<InputDataStruct>();
        public uiWatch()
        {
            InitializeComponent();
            dataGridViewUiWatch.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;
            //读取数据库，并将基本信息表反馈到当前的uiWatch的dataGridViewUiWatch

            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;
            //拉取所有的数据
            ds = sqlcomm.Sqlcommit_Select("select * from product_infor");

            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("当前数据库无数据，请录入后再进行监测！！！");
                return;
            }

            dataGridVewClear();
            comboxClear(1);
            comboxClear(2);
            comboxClear(3);

            for (int i = 0, j = 0; i < dt.Rows.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkboxcell);

                for (j = 0; j < 7; j++)
                {
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                    textboxcell.Value = dt.Rows[i].ItemArray.GetValue(j).ToString().Trim();
                    row.Cells.Add(textboxcell);
                    if (2 == j)
                    {
                        if (comboBoxUiWatchPName.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchPName.Items.Add(textboxcell.Value);
                        }
                    }

                    if (3 == j)
                    {
                        if (comboBoxUiWatchSerial.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchSerial.Items.Add(textboxcell.Value);
                        }
                    }

                    if (4 == j)
                    {
                        if (comboBoxUiWatchColor.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchColor.Items.Add(textboxcell.Value);
                        }
                    }
                }
                dataGridViewUiWatch.Rows.Add(row);
            }
        }

        /// <summary>
        /// 使用SKUID去查询数据库信息，并将信息反馈到当前的uiWatch的dataGridViewUiWatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiWatchSeachSkuid_Click(object sender, EventArgs e)
        {
           string str = textBoxUiWatchSeleSkuid.Text.ToString().Trim();

           if( null == str || "" == str )
           {
               MessageBox.Show("请输入指定的商品编号");
               return;
           }

            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;
   
            string strQl = "select * from product_infor where product_skuid = '" + str + "'";
            ds = sqlcomm.Sqlcommit_Select(strQl);

            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }
 
            dataGridVewClear();
            comboxClear(1);
            comboxClear(2);
            comboxClear(3);

            for (int i = 0, j = 0; i < dt.Rows.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkboxcell);

                for (j = 0; j < 7; j++)
                {
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                    textboxcell.Value = dt.Rows[i].ItemArray.GetValue(j).ToString().Trim();
                    row.Cells.Add(textboxcell);
                    if (0 == j)
                    {
                        if (comboBoxUiWatchPName.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchPName.Items.Add(textboxcell.Value);
                            comboBoxUiWatchPName.SelectedItem = textboxcell.Value;
                        }
                    }

                    if (1 == j)
                    {
                        if (comboBoxUiWatchSerial.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchSerial.Items.Add(textboxcell.Value);
                            comboBoxUiWatchSerial.SelectedItem = textboxcell.Value;
                        }
                    }

                    if (2 == j)
                    {
                        if (comboBoxUiWatchColor.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchColor.Items.Add(textboxcell.Value);
                            comboBoxUiWatchColor.SelectedItem = textboxcell.Value;
                        }
                    }
                }
                dataGridViewUiWatch.Rows.Add(row);
            }
        }

        /// <summary>
        /// 将dataGridView的所有行选中或是反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiWatchSele_Click(object sender, EventArgs e)
        {
            if (buttonUiWatchSele.Text == "全选")
            {
                buttonUiWatchSele.Text = "反选";
                foreach (DataGridViewRow dr in dataGridViewUiWatch.Rows)
                {
                    if (dr.Cells[0].FormattedValue.ToString() == false.ToString())
                    {
                        dr.Cells[0].Value = true;
                    }
                }
            }
            else
            {
                buttonUiWatchSele.Text = "全选";
                foreach (DataGridViewRow dr in dataGridViewUiWatch.Rows)
                {
                    if (dr.Cells[0].FormattedValue.ToString() == true.ToString())
                    {
                        dr.Cells[0].Value = false;
                    }
                }
            }
        }

        /// <summary>
        /// 从个表中获取数据，并添加到链表
        /// </summary>
        private void uiWatch_GetDataGridViewData()
        {
            uiInputList.Clear();

          //  int i = -1;
            foreach (DataGridViewRow dr in dataGridViewUiWatch.Rows)
            {
             //   i++;
                if (null == dr.Cells[0].FormattedValue)
                {
                    continue;
                }

                if (dr.Cells[0].FormattedValue.ToString() == true.ToString() && null != dr.Cells[2].Value)
                {
                    InputDataStruct inputData = new InputDataStruct();

                    inputData.data = new CUiInputDataStruct();
                    if (null != dr.Cells[1].Value)
                        inputData.data.ProductSeller = dr.Cells[1].Value.ToString().Trim();

                    if (null != dr.Cells[2].Value)
                        inputData.data.ProductSkuid  = dr.Cells[2].Value.ToString().Trim();

                    if (null != dr.Cells[3].Value)
                        inputData.data.ProductName = dr.Cells[3].Value.ToString().Trim();

                    if (null != dr.Cells[4].Value)
                        inputData.data.ProductSerial = dr.Cells[4].Value.ToString().Trim();

                    if (null != dr.Cells[5].Value)
                        inputData.data.ProductColor = dr.Cells[5].Value.ToString().Trim();

                    if (null != dr.Cells[6].Value)
                        inputData.data.ProductVersion = dr.Cells[6].Value.ToString().Trim();

                    if (null != dr.Cells[7].Value)
                        inputData.data.ProductWarnPrice = Convert.ToDouble(dr.Cells[7].Value.ToString().Trim());

                    inputData.data.index = 0;

                    uiInputList.Add(inputData);
                }
            }
        }

        public event uiWatch_SndWarnList  sndWarnListToUiMain;
        /// <summary>
        /// 将选中的行信息添加到uiMaim的 dataGridViewUiMainWatch表中去
        /// 添加完成后，提示添加成功多少条，如果有重复的，提示是否覆盖
        /// 完成添加后，提示用户是否开启监控，如果开启则通知uiMain的 buttonUiMainWatchStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiWatchAddToWatch_Click(object sender, EventArgs e)
        {
            //UInt32 timeMs = Convert.ToUInt32(textBoxUiWatchFrq.Text) * 1000 * 60;
            //if (timeMs < (5 * 1000 * 60))
            //{
            //    timeMs = 5 * 1000 * 60;
            //}

            uiWatch_GetDataGridViewData();
            sndWarnListToUiMain(uiInputList);
            this.Close();
        }

        /// <summary>
        /// 从数据库按 商品名 的条件拉取数据。
        /// 0，如果当前框内无数据，则从数据库拉取所有的数据
        /// 1,显示在comboBoxUiWatchPName，comboBoxUiWatchSerial，comboBoxUiWatchColor
        /// 2,在uiWatch的dataGridViewUiWatch 显示此条件下的数据 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUiWatchPName_DropDown(object sender, EventArgs e)
        {
            if( 0 == comboBoxUiWatchPName.Items.Count )
            {
                //MessageBox.Show("无商品信息数据，正从数据库获取...");
                //从数据库获取

                //获取完成后填充数据到当前框，comboBoxUiWatchSerial和comboBoxUiWatchColor
                comboBoxUiWatchPName.Items.Add("所有");
                //添加所有获得对应的数据在此框
               // comboBoxUiWatchPName.Items.Add("小米");

                //添加所有获得对应的数据在comboBoxUiWatchSerial框
                comboBoxUiWatchSerial.Items.Add("所有");
               // comboBoxUiWatchSerial.Items.Add("红米Note");

                //添加所有获得对应的数据在comboBoxUiWatchColor框
                comboBoxUiWatchColor.Items.Add("所有");
               // comboBoxUiWatchColor.Items.Add("红色");


                //将获取到的数据显示在 dataGridViewUiWatch
            }

        }

        /// <summary>
        /// 根据选中的品牌到数据库拉取出来，并显示在 comboBoxUiWatchSerial，comboBoxUiWatchColor与 comboBoxUiWatchSerial，comboBoxUiWatchColor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUiWatchPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;
            string strP = comboBoxUiWatchPName.SelectedItem.ToString();

            if ( "所有" == strP)
            {
                //拉取所有的数据
                ds = sqlcomm.Sqlcommit_Select("select * from product_infor");      
            }
            else
            {
                string str = "select * from product_infor where product_name = '" + comboBoxUiWatchPName.SelectedItem.ToString() + "'";
                ds = sqlcomm.Sqlcommit_Select(str);
            }

            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }
            else
            {
                // string str = "成功拉取:" + dt.Rows.Count.ToString();
                // MessageBox.Show(str);
            }
            dataGridVewClear();
            comboxClear(2);
            comboxClear(3);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                  dataGridViewAddRow(dt, i, comboBoxUiWatchPName);
            }
        }

        /// <summary>
        /// 以品牌+当前选中的为条件，向服务器请求对应的数据,并将数据更新在dataGridViewUiWatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUiWatchSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == comboBoxUiWatchPName.SelectedIndex )
            {
                MessageBox.Show("请先选择 品牌 再选择此项!");
               // comboBoxUiWatchSerial.SelectedIndex = -1;
                return;
            }

            string str = comboBoxUiWatchPName.SelectedItem.ToString();
            string strSerial = comboBoxUiWatchSerial.SelectedItem.ToString();
            if( "所有" == str || "所有" == strSerial)
            {
                return;
            }
            //  MessageBox.Show("条件为："+str + strSerial);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch
            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;

            string strSql = "select * from product_infor where product_name = '" + comboBoxUiWatchPName.SelectedItem.ToString() + "'" + " and product_serial = '" + strSerial + "'";
            ds = sqlcomm.Sqlcommit_Select(strSql);
            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }
            else
            {
                // string str = "成功拉取:" + dt.Rows.Count.ToString();
                // MessageBox.Show(str);
            }
            dataGridVewClear();
            comboxClear(3);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridViewAddRow(dt, i, comboBoxUiWatchSerial);
            }

        }

        /// <summary>
        /// 以品牌+系列+当前选中的为条件向服务器请求数据，并将数据更新在dataGridViewUiWatch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxUiWatchColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == comboBoxUiWatchPName.SelectedIndex  || -1 == comboBoxUiWatchSerial.SelectedIndex )
            {
                MessageBox.Show("请先选择 品牌与系列 再选择此项!");
                //comboBoxUiWatchColor.SelectedIndex = -1;
                return;
            }

            string strPName  = comboBoxUiWatchPName.SelectedItem.ToString();
            string strSerial = comboBoxUiWatchSerial.SelectedItem.ToString();
            string strColor = comboBoxUiWatchColor.SelectedItem.ToString();

            if ("所有" == strPName || "所有" == strSerial ||  "所有"== strColor)
            {
                return;
            }
            //  MessageBox.Show("条件为：" + strPName + strSerial + strColor);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch

            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;

            string strSql = "select * from product_infor where product_name = '" + comboBoxUiWatchPName.SelectedItem.ToString() + "'" + " and product_serial = '" + strSerial + "'"+ " and product_color = '"+ strColor+"'";
            ds = sqlcomm.Sqlcommit_Select(strSql);
            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }
            else
            {
                // string str = "成功拉取:" + dt.Rows.Count.ToString();
                // MessageBox.Show(str);
            }
            dataGridVewClear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridViewAddRow(dt, i, comboBoxUiWatchColor);
            }

        }

        private void dataGridViewAddRow( DataTable dt, int i, ComboBox comBox)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
            row.Cells.Add(checkboxcell);
            DataGridView datGridV = dataGridViewUiWatch;
            // 3,4,5,6,7
            for (int index = 0; index < 6; index++)
            {
                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                textboxcell.Value = dt.Rows[i].ItemArray.GetValue(index).ToString().Trim();
                row.Cells.Add(textboxcell);
                if (comboBoxUiWatchPName == comBox)
                {
                    if (2 == index)
                    {
                        if (comboBoxUiWatchPName.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchPName.Items.Add(textboxcell.Value);
                        }
                    }

                    if (3 == index)
                    {
                        if (comboBoxUiWatchSerial.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchSerial.Items.Add(textboxcell.Value);
                        }
                    }
                }

                if (comboBoxUiWatchSerial == comBox || comboBoxUiWatchPName == comBox)
                {
                    if (4 == index)
                    {
                        if (comboBoxUiWatchColor.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiWatchColor.Items.Add(textboxcell.Value);
                        }
                    }
                }

            }

            if (datGridV.Rows.Count % 2 == 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.Lavender;
            }
            datGridV.Rows.Add(row);
        }



        private void dataGridViewUiWatch_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridViewUiWatch_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridViewUiWatch.Rows.Count % 2 == 0)
            {
                dataGridViewUiWatch.Rows[dataGridViewUiWatch.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                dataGridViewUiWatch.Rows[dataGridViewUiWatch.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }

        private void dataGridVewClear()
        {
            if (dataGridViewUiWatch.Rows.Count > 1)
            {
                for (int count = 0; count < dataGridViewUiWatch.Rows.Count - 1; count++)
                {
                    dataGridViewUiWatch.Rows.RemoveAt(count);
                    count--;
                }
            }
        }

        private void comboxClear( int i)
        { 
            if(1 == i )
            {
                comboBoxUiWatchPName.Items.Clear();
                comboBoxUiWatchPName.Items.Add("所有");
            }

            if(2 == i)
            {
                comboBoxUiWatchSerial.Items.Clear();
                comboBoxUiWatchSerial.Items.Add("所有");
            }
            if(3 == i)
            {
                comboBoxUiWatchColor.Items.Clear();
                comboBoxUiWatchColor.Items.Add("所有");
            }
        }
    }
}
