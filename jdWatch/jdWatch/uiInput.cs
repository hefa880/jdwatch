using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UiInputDataStruct.Mode;
using Fatq.SqlCommit.Mode;
using System.Threading;
using WareDealer;
using WareDealer.Mode;
using WareDealer.Helper;
using Hank.ComLib;
using Hank.UiCtlLib;

namespace jdWatch
{
    
    public partial class uiInput : Form
    {
        IList<InputDataStruct> uiInput_list = new List<InputDataStruct>();
        IList<InputDataStruct> uiInput_listShow = new List<InputDataStruct>();
        

        //定义一个委托  
        public delegate void MyInvoke();
        public uiInput()
        {
            InitializeComponent();
            dataGridViewUiIpnut.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void uiIput_ThreadBuild()
        {
            Thread demoThread = null;

            for(int i = 0; i< uiInput_list.Count;i++ )
            {
                demoThread = new Thread(new ParameterizedThreadStart(uiIput_ThreadGetdataGridViewWareInfor));
                demoThread.IsBackground = true;
                demoThread.Start(uiInput_list[i]);
            }
            
        }

        public void uiIput_ThreadGetdataGridViewWareInfor(object data)
        {
            InputDataStruct ListNode = data as InputDataStruct;
            ProductInfo wareInfor;

            //获取WEB数据
            SysParams.GatherModel = GatherType.Single;
            wareInfor = WareDealer.WareService.GetInstance().GetWareInfoByID(ListNode.data.ProductSkuid);

            if (null != wareInfor)
            {
                ListNode.data.ProductDescribe = wareInfor.ProductName.ToString().Trim();
                ListNode.data.ProductSeller = wareInfor.ProductBrand;
            }
            else
            {
                ListNode.data.ProductState = "无效SKUID";
            }
            uiInput_listShow.Add(ListNode);

            if (uiInput_list.Count == uiInput_listShow.Count )
            {
                uiInpu_taskGetWareInfor();
            }
        }

        /// <summary>
        /// 自动获商品信息的取任务，调用更新到 DataGridView
        /// </summary>
        public void uiInpu_taskGetWareInfor()
        {
            if (dataGridViewUiIpnut.InvokeRequired)
            {
                //委托对象  
                MyInvoke mi = new MyInvoke(uiIput_ShowDataToGridView);
                //异步调用委托  
                this.BeginInvoke(mi);
            }
            // listWareInforNode.Clear();
        }
        /// <summary>
        /// 将数据更新到DataGridView
        /// </summary>
        /// <param name="datGridView"></param>
        public void uiIput_ShowDataToGridView()
        {
            for(int i = 0; i < uiInput_listShow.Count;i++ )
            {
                for (int c = 3; c< 7;c++)
                {
                    DataGridViewComboBoxCell comboxcell = dataGridViewUiIpnut.Rows[uiInput_listShow[i].data.index].Cells[c] as DataGridViewComboBoxCell;
                    string str = uiInput_listShow[i].data.ProductDescribe;
                    string strItem = "";
                    int index = 0;
                    int cell = 0;
                    if(null == str || "无效SKUID" == uiInput_listShow[i].data.ProductState)
                    {
                        continue;
                    }
                    for (;;)
                    {
                        index = str.IndexOf(" ");
                        if (index > 0 )
                        {
                            strItem = str.Substring(0, index);
                        }

                        if( 3 == c )
                        {
                            
                           if( strItem.IndexOf("荣耀") >= 0)
                            {
                                comboxcell.Items.Add("华为");
                            }
                        }

                        comboxcell.Items.Add(strItem.Trim());
                        if(cell == 0)
                        {
                            comboxcell.Value = strItem;
                            cell = 1;
                        }
                        
                        if (index <=  0 )
                        {
                            break;
                        }
                        strItem = str.Substring(index, str.Length - index);
                        str = strItem.Trim();
                    }
                }
              
                dataGridViewUiIpnut.Rows[uiInput_listShow[i].data.index].Cells[7].Value = uiInput_listShow[i].data.ProductDescribe.ToString().Trim();
                dataGridViewUiIpnut.Rows[uiInput_listShow[i].data.index].Cells[1].Value = uiInput_listShow[i].data.ProductSeller.ToString().Trim();
            }
            uiInput_listShow.Clear();
        }

        /// <summary>
        /// 从个表中获取数据，并添加到链表
        /// </summary>
        private void uiInput_GetDataGridViewData()
        {
            uiInput_list.Clear();
            int i = -1;
            foreach (DataGridViewRow dr in dataGridViewUiIpnut.Rows)
            {
                i++;
                if (null == dr.Cells[0].FormattedValue)
                {
                    continue;
                }

                if (dr.Cells[0].FormattedValue.ToString() == true.ToString() && null != dr.Cells[2].Value )
                {
                    InputDataStruct inputData = new InputDataStruct();

                    inputData.data = new CUiInputDataStruct();
                    if (null != dr.Cells[1].Value)
                        inputData.data.ProductSeller      = dr.Cells[1].Value.ToString().Trim();
                    if (null != dr.Cells[2].Value)
                        inputData.data.ProductSkuid    = dr.Cells[2].Value.ToString().Trim();

                    if( null != dr.Cells[3].Value )
                        inputData.data.ProductName       = dr.Cells[3].Value.ToString().Trim();
                    if (null != dr.Cells[4].Value)
                        inputData.data.ProductSerial     = dr.Cells[4].Value.ToString().Trim();
                    if (null != dr.Cells[5].Value)
                        inputData.data.ProductColor      = dr.Cells[5].Value.ToString().Trim();
                    if (null != dr.Cells[6].Value)
                        inputData.data.ProductVersion    = dr.Cells[6].Value.ToString().Trim();
                  
                    if (null != dr.Cells[8].Value)
                        inputData.data.ProductWarnPrice  = Convert.ToDouble(dr.Cells[8].Value.ToString().Trim());
                    if (null != dr.Cells[9].Value)
                        inputData.data.ProductWarnDriect = dr.Cells[9].Value.ToString().Trim();
                    if (null != dr.Cells[10].Value)
                        inputData.data.ProductState      = dr.Cells[10].Value.ToString().Trim();
                    inputData.data.index = i;

                    uiInput_list.Add(inputData);
                }
            }
        }

        private void uiIput_ShowSaveStatus()
        {
            for(int i = 0,j=0;i< dataGridViewUiIpnut.Rows.Count -1 && j < uiInput_list.Count; i++)
            {
                if(dataGridViewUiIpnut.Rows[i].Cells[6].Value.ToString().Trim() == uiInput_list[j].data.ProductSkuid )
                {
                    if (uiInput_list[j].data.ProductState == "新增")
                    {
                        dataGridViewUiIpnut.Rows.RemoveAt(i);
                        uiInput_list.Remove(uiInput_list[j]);
                        i--;
                    }
                    else
                    {
                        dataGridViewUiIpnut.Rows[i].Cells[10].Value = uiInput_list[j].data.ProductState;
                        j++;
                    }
                }
            }
          //  uiInput_list.Clear();
        }

       /// <summary>
       /// 自动添加行号
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dataGridViewUiIpnut_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
            textBoxUiInputCount.Text = "当前数据：" + (dataGridViewUiIpnut.Rows.Count - 1);
        }

        /// <summary>
        /// 从表中获取商品编号，并向WEB请求数据，并将数据写回本表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputGetWareInfor_Click(object sender, EventArgs e)
        {
            //此部分可能用到多线程完成

            //获取SKUID
            uiInput_GetDataGridViewData();
            if( uiInput_list.Count <= 0 )
            {
                MessageBox.Show("请选择要获取的项目！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            buttonUiInputGetWareInfor.Enabled = false;

            //调用多线程获取WEB数据
            uiIput_ThreadBuild();
            buttonUiInputGetWareInfor.Enabled = true;
        }

        /// <summary>
        /// 将编辑好的数据写入数据库保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputSaveToSql_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            int countSuccessed = 0;
            int countFailed= 0;
            SqlCommit sqlconn = new SqlCommit();

            uiInput_GetDataGridViewData();
            if( 0 == uiInput_list.Count  )
            {
                return;
            }
            // 保存到数据库
            for(int i = 0; i < uiInput_list.Count; i++ )
            {
                bRet = sqlconn.Sqlcommit_Insert(uiInput_list[i].data);
                if(true == bRet )
                {
                    uiInput_list[i].data.ProductState = "新增";
                    countSuccessed++;
                }
                else
                {
                    uiInput_list[i].data.ProductState = "已有";
                    countFailed++;
                }
            }

            //检查链表数据，如果提交成功则从dataGridViewUiIpnut中删除，否则保留，并在状态列显示原因
            uiIput_ShowSaveStatus();
            if(uiInput_list.Count > 0 ) /// && this.Text != "编辑数据库")
            {
                DialogResult dRet = DialogResult.No;

                dRet = MessageBox.Show("有重复的数据，是否要覆盖？\n是，覆盖\n否，抛弃这些重复数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRet == DialogResult.Yes)
                {
                    for (int i = 0; i < uiInput_list.Count; i++)
                    {
                        bRet = sqlconn.Sqlcommit_Update(uiInput_list[i].data); 
                    }
                }
                
                for (int i = 0; i < dataGridViewUiIpnut.Rows.Count - 1; i++)
                {
                     if (null == dataGridViewUiIpnut.Rows[i].Cells[0].Value)
                     {
                          continue;
                      }

                     if (dataGridViewUiIpnut.Rows[i].Cells[0].Value.ToString() == true.ToString())
                     {
                          dataGridViewUiIpnut.Rows.RemoveAt(i);
                          i--; //关键在这里
                     }
                 }
                uiInput_list.Clear();
            }
            
        }

        /// <summary>
        /// 删除指定的行与数据，并提示用户是否也删除数据库的数据
        /// 删除时可能要对uiMainWatch下的表，uiWatch下的表都要查询一次，如果有，则删除
        /// 如果要调用到其他的窗口，可能要用到消息投递的机制，或将定义改为公有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputdel_Click(object sender, EventArgs e)
        {
            bool bDelSql = false;
            int countErr = 0;
            DialogResult dRet = DialogResult.No;

            dRet = MessageBox.Show("是否同时删除数据库对应的数据？\n是，删除数据库对应数据\n否，仅仅删除当前表中数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if( dRet == DialogResult.Yes )
            {
                bDelSql = true;
                //MessageBox.Show("delete Sql!!!");
            }
            else
            {
                bDelSql = false;
            }

            uiInput_GetDataGridViewData();
            if (true == bDelSql )
            {
                //删除数据，从链表提取，直接从库中删除
                for( int i =0; i< uiInput_list.Count;i++)
                {
                    SqlCommit sqlcomm = new SqlCommit();
                    if( true == sqlcomm.Sqlcommit_Del("product_infor", "product_skuid = " + uiInput_list[i].data.ProductSkuid) )
                    {
                        countErr++;
                    }
                }
            }

            for (int i = 0; i < dataGridViewUiIpnut.Rows.Count - 1; i++)
            {
                if (null == dataGridViewUiIpnut.Rows[i].Cells[0].Value)
                {
                    continue;
                }

                if (dataGridViewUiIpnut.Rows[i].Cells[0].Value.ToString() == true.ToString())
                {
                    dataGridViewUiIpnut.Rows.RemoveAt(i);
                    i--; //关键在这里
                }
            }
            MessageBox.Show("成功删除了:" + countErr + "条数据");

            uiInputShowCountData();
        }

        private void buttonUiInputSelect_Click(object sender, EventArgs e)
        {
            if (buttonUiInputSelect.Text == "全选")
            {
                buttonUiInputSelect.Text = "反选";
                foreach (DataGridViewRow dr in dataGridViewUiIpnut.Rows)
                {
                    if (dr.Cells[0].FormattedValue.ToString() == false.ToString())
                    {
                        dr.Cells[0].Value = true;
                    }
                }
            }
            else
            {
                buttonUiInputSelect.Text = "全选";
                foreach (DataGridViewRow dr in dataGridViewUiIpnut.Rows)
                {
                    if (dr.Cells[0].FormattedValue.ToString() == true.ToString())
                    {
                        dr.Cells[0].Value = false;
                    }
                }
            }
        }

        /// <summary>
        /// 从数据库获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputEditSql_Click(object sender, EventArgs e)
        {
           // dataGridViewUiIpnut.Columns.Clear();
            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DialogResult dRet = DialogResult.No;

            if (buttonUiInputEditSql.Text != "编辑数据库")
            {
                this.Text = "录入";
                buttonUiInputEditSql.Text = "编辑数据库";

                dRet = MessageBox.Show("录入数据时会覆盖当前表中的内容，如果当前表中有数据，请点击保存后再进行编辑！！！\n是，进入录入模式\n否，放弃录入模式", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRet == DialogResult.No)
                {
                    return;
                    //MessageBox.Show("放弃编辑数据!");
                }

                if (dataGridViewUiIpnut.Rows.Count > 1)
                {
                    for (int count = 0; count < dataGridViewUiIpnut.Rows.Count - 1; count++)
                    {
                        dataGridViewUiIpnut.Rows.RemoveAt(count);
                        count--;
                    }
                }
                buttonUiInputGetWareInfor.Enabled = true;
                uiInputShowCountData();
                return;
            }

            dRet = MessageBox.Show("编辑数据库时会覆盖当前表中的内容，如果当前表中有数据，请点击保存后再进行编辑！！！\n是，直接编辑数据库\n否，放弃编辑数据库", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRet == DialogResult.No)
            {
                return;
                //MessageBox.Show("放弃编辑数据!");
            }
            this.Text = "编辑数据库";
            buttonUiInputEditSql.Text = "录入模式";
            buttonUiInputGetWareInfor.Enabled = false;

            if( dataGridViewUiIpnut.Rows.Count >  1)
            {
              for( int count = 0; count < dataGridViewUiIpnut.Rows.Count - 1; count++ )
              {
                dataGridViewUiIpnut.Rows.RemoveAt(count);
                count--;
              }
            }

            DataSet ds = sqlcomm.Sqlcommit_Select("select * from product_infor");

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

            for (int i = 0,j=0; i < dt.Rows.Count;i++ )
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkboxcell);
                int c;
                for (j = 0, c = 0; j < 10;j++ )
                {
                    DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                    if (j == 6 || j> 8)
                    {
                        textboxcell.Value = "";
                    }
                    else if( j< 8)
                    {

                        textboxcell.Value = dt.Rows[i].ItemArray.GetValue(c++).ToString().Trim();
                    }
                        
                    row.Cells.Add(textboxcell);
                }
                if (dataGridViewUiIpnut.Rows.Count % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Lavender;
                }
                dataGridViewUiIpnut.Rows.Add(row);
            }

            uiInputShowCountData();
        }

        private void uiInputShowCountData()
        {
            dataGridViewUiIpnut.Refresh();
            textBoxUiInputCount.Text = "当前数据：" + (dataGridViewUiIpnut.Rows.Count - 1);

        }
        private void dataGridViewUiIpnut_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridViewUiIpnut.Rows.Count % 2 == 0 )
            {
                dataGridViewUiIpnut.Rows[dataGridViewUiIpnut.Rows.Count-1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                dataGridViewUiIpnut.Rows[dataGridViewUiIpnut.Rows.Count-1].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }

    }
}
