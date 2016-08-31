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
    public partial class uiMain : Form
    {
        public uiLogin    uiLoginW;
        public uiWatch    uiWatchW;
        public uiInput     uiIputW;
        public uiHistory   uiHistoryW;
        public uiSys       uiSysW;
        System.Timers.Timer myTimer = new System.Timers.Timer();
        Double  myTimerInterval;
        IList<WarePriceNode> uiMain_list = new List<WarePriceNode>();   //从表从获取到链表中
        IList<WarePriceNode> uiMain_listShow = new List<WarePriceNode>();  //用于显示的链表
       // IList<InputDataStruct> uiInput_list = new List<InputDataStruct>();
        
        public uiMain()
        {
            InitializeComponent();
            uiLoginW    = new uiLogin();
            uiWatchW    = new uiWatch();
            uiIputW     = new uiInput();
            uiHistoryW  = new uiHistory();
            uiSysW      = new uiSys();
            //进入登录界面
            uiLoginW.ShowDialog();
            dataGridViewUiMainWatch.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;
            dataGridViewUiMainWarn.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;
            dataGridViewUiMainMyWarn.Rows[0].DefaultCellStyle.BackColor = Color.Lavender;

        }

        private void buttonUiMainBaseInput_Click(object sender, EventArgs e)
        {
            uiIputW.ShowDialog();
        }

        private void buttonUiMainHistory_Click(object sender, EventArgs e)
        {
            uiHistoryW.ShowDialog();
        }

        private void buttonUiMainSys_Click(object sender, EventArgs e)
        {
            uiSysW.ShowDialog();
        }

        private void buttonUiMainWatch_Click(object sender, EventArgs e)
        {
            uiWatchW.sndWarnListToUiMain += uiWatchW_sndWarnListToUiMain;
            uiWatchW.ShowDialog();
            
        }

        void uiWatchW_sndWarnListToUiMain(IList<InputDataStruct> uiInputList)
        {
          //  throw new NotImplementedException();
           // MessageBox.Show("收到");

            for (int index = 0; index < uiInputList.Count; index++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
                row.Cells.Add(checkboxcell);

                DataGridViewTextBoxCell textboxcell_1 = new DataGridViewTextBoxCell();
                textboxcell_1.Value = uiInputList[index].data.ProductSeller; //商家
                row.Cells.Add(textboxcell_1);

                DataGridViewTextBoxCell textboxcell_2 = new DataGridViewTextBoxCell();
                textboxcell_2.Value = uiInputList[index].data.ProductSkuid; //
                row.Cells.Add(textboxcell_2);

                DataGridViewTextBoxCell textboxcell_3 = new DataGridViewTextBoxCell();
                textboxcell_3.Value = uiInputList[index].data.ProductName; //
                row.Cells.Add(textboxcell_3);

                DataGridViewTextBoxCell textboxcell_4 = new DataGridViewTextBoxCell();
                textboxcell_4.Value = uiInputList[index].data.ProductSerial; //
                row.Cells.Add(textboxcell_4);

                DataGridViewTextBoxCell textboxcell_5 = new DataGridViewTextBoxCell();
                textboxcell_5.Value = uiInputList[index].data.ProductColor; //
                row.Cells.Add(textboxcell_5);

                DataGridViewTextBoxCell textboxcell_6 = new DataGridViewTextBoxCell();
                textboxcell_6.Value = uiInputList[index].data.ProductVersion; //
                row.Cells.Add(textboxcell_6);

                DataGridViewTextBoxCell textboxcell_7 = new DataGridViewTextBoxCell();
                textboxcell_7.Value =  Convert.ToDouble( uiInputList[index].data.ProductWarnPrice); //
                row.Cells.Add(textboxcell_7);

                this.dataGridViewUiMainWatch.Rows.Add(row);
            }
           
        }

        private void dataGridViewUiMainWatch_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridViewUiMainWarn_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridViewUiMainMyWarn_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void comboBoxUiMainPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;
            string strP = comboBoxUiMainPName.SelectedItem.ToString();

            if ("所有" == strP)
            {
                //拉取所有的数据
                ds = sqlcomm.Sqlcommit_Select("select * from product_infor");
            }
            else
            {
                string str = "select * from product_infor where product_name = '" + comboBoxUiMainPName.SelectedItem.ToString() + "'";
                ds = sqlcomm.Sqlcommit_Select(str);
            }

            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }

            DataGridView datGridV;
            if (tabControlUiMainWatch.SelectedTab.Text == "监控表")
            {
                datGridV = dataGridViewUiMainWatch;
            }
            else if (tabControlUiMainWatch.SelectedTab.Text == "异常表")
            {
                datGridV = dataGridViewUiMainWarn;
            }
            else
            {
                datGridV = dataGridViewUiMainMyWarn;
            }
            dataGridVewClear(datGridV);
            comboxClear(2);
            comboxClear(3);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridViewAddRow(datGridV, dt, i, comboBoxUiMainPName);
            }
        }

        private void comboBoxUiMainPSerial_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (-1 == comboBoxUiMainPName.SelectedIndex)
            {
                MessageBox.Show("请先选择 品牌 再选择此项!");
                // comboBoxUiWatchSerial.SelectedIndex = -1;
                return;
            }

            string str = comboBoxUiMainPName.SelectedItem.ToString();
            string strSerial = comboBoxUiMainPSerial.SelectedItem.ToString();
            if ("所有" == str || "所有" == strSerial)
            {
                return;
            }

            //  MessageBox.Show("条件为："+str + strSerial);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch
            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;

            string strSql = "select * from product_infor where product_name = '" + comboBoxUiMainPName.SelectedItem.ToString() + "'" + " and product_serial = '" + strSerial + "'";
            ds = sqlcomm.Sqlcommit_Select(strSql);
            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }
  
            DataGridView datGridV;
            if (tabControlUiMainWatch.SelectedTab.Text == "监控表")
            {
                datGridV = dataGridViewUiMainWatch;
            }
            else if (tabControlUiMainWatch.SelectedTab.Text == "异常表")
            {
                datGridV = dataGridViewUiMainWarn;
            }
            else
            {
                datGridV = dataGridViewUiMainMyWarn;
            }
            dataGridVewClear(datGridV);
            comboxClear(3);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridViewAddRow(datGridV, dt, i, comboBoxUiMainPSerial);
            }
        }

        private void comboBoxUiMainPColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == comboBoxUiMainPName.SelectedIndex || -1 == comboBoxUiMainPSerial.SelectedIndex)
            {
                MessageBox.Show("请先选择 品牌与系列 再选择此项!");
                //comboBoxUiWatchColor.SelectedIndex = -1;
                return;
            }

            string strPName = comboBoxUiMainPName.SelectedItem.ToString();
            string strSerial = comboBoxUiMainPSerial.SelectedItem.ToString();
            string strColor = comboBoxUiMainPColor.SelectedItem.ToString();

            if ("所有" == strPName || "所有" == strSerial || "所有" == strColor)
            {
                return;
            }
            //  MessageBox.Show("条件为：" + strPName + strSerial + strColor);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch

            SqlCommit sqlcomm = new SqlCommit();
            DataTable dt;
            DataSet ds;

            string strSql = "select * from product_infor where product_name = '" + comboBoxUiMainPName.SelectedItem.ToString() + "'" + " and product_serial = '" + strSerial + "'" + " and product_color = '" + strColor + "'";
            ds = sqlcomm.Sqlcommit_Select(strSql);
            dt = ds.Tables[0];//填充
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("拉取失败");
                return;
            }

            DataGridView datGridV;
            if (tabControlUiMainWatch.SelectedTab.Text == "监控表")
            {
                datGridV = dataGridViewUiMainWatch;
            }
            else if (tabControlUiMainWatch.SelectedTab.Text == "异常表")
            {
                datGridV = dataGridViewUiMainWarn;
            }
            else
            {
                datGridV = dataGridViewUiMainMyWarn;
            }

            dataGridVewClear(datGridV);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridViewAddRow(datGridV,dt,i,null);
            }
        }

        private void dataGridViewAddRow(DataGridView datGridV, DataTable dt, int i, ComboBox comBox )
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
            row.Cells.Add(checkboxcell);
          
            // 3,4,5,6,7
            for (int index = 0; index < 6; index++)
            {
                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                textboxcell.Value = dt.Rows[i].ItemArray.GetValue(index).ToString().Trim();
                row.Cells.Add(textboxcell);
                if ( comboBoxUiMainPName == comBox )
                {
                    if (2 == index)
                    {
                        if (comboBoxUiMainPName.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiMainPName.Items.Add(textboxcell.Value);
                        }
                    }

                    if (3 == index)
                    {
                        if (comboBoxUiMainPSerial.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiMainPSerial.Items.Add(textboxcell.Value);
                        }
                    }
                }

                if (comboBoxUiMainPSerial == comBox || comboBoxUiMainPName == comBox)
                {
                    if (4 == index)
                    {
                        if (comboBoxUiMainPColor.Items.IndexOf(textboxcell.Value) < 0)
                        {
                            comboBoxUiMainPColor.Items.Add(textboxcell.Value);
                        }
                    }
                }
                
            }

            DataGridViewTextBoxCell textb = new DataGridViewTextBoxCell();
            textb.Value = dt.Rows[i].ItemArray.GetValue(6).ToString().Trim();
            row.Cells.Add(textb);

            // 8,9,10,11,12,13,14
            for (int index = 0; index < 6; index++)
            {
                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                textboxcell.Value = "";
                row.Cells.Add(textboxcell);
            }
            DataGridViewLinkCell linkcell = new DataGridViewLinkCell();
            linkcell.Value = "查看";
            linkcell.TrackVisitedState = true;
            row.Cells.Add(linkcell);

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
        private void dataGridVewClear(DataGridView datGridV)
        {
            if (datGridV.Rows.Count > 1)
            {
                for (int count = 0; count < datGridV.Rows.Count - 1; count++)
                {
                    datGridV.Rows.RemoveAt(count);
                    count--;
                }
            }
        }

        private void comboxClear(int i)
        {
            if (1 == i)
            {
                comboBoxUiMainPName.Items.Clear();
                comboBoxUiMainPName.Items.Add("所有");
            }

            if (2 == i)
            {
                comboBoxUiMainPSerial.Items.Clear();
                comboBoxUiMainPSerial.Items.Add("所有");
            }
            if (3 == i)
            {
                comboBoxUiMainPColor.Items.Clear();
                comboBoxUiMainPColor.Items.Add("所有");
            }
        }

        /// <summary>
        /// 从个表中获取数据，并添加到链表
        /// </summary>
        private void uiMain_GetDataGridViewData()
        {
            uiMain_list.Clear();
            int i = -1;
            foreach (DataGridViewRow dr in dataGridViewUiMainWatch.Rows)
            {
                i++;
                if (null == dr.Cells[0].FormattedValue)
                {
                    continue;
                }

                if (dr.Cells[0].FormattedValue.ToString() == true.ToString() && null != dr.Cells[6].Value)
                {
                    WarePriceNode inputData = new WarePriceNode();

                    inputData.warePriceN  = new WarePrice();

                    if (null != dr.Cells[2].Value)
                    {
                        inputData.warePriceN.ProductSkuid = dr.Cells[2].Value.ToString().Trim();
                        if (null != dr.Cells[7].Value)
                        {
                            inputData.warePriceN.ProductWarnPrice = Convert.ToDouble( dr.Cells[7].Value.ToString().Trim());
                        }
                        inputData.warePriceN.index += i;
                    }
                    
                    uiMain_list.Add(inputData);
                }
            }
        }

        private void buttonUiMainWatchStart_Click(object sender, EventArgs e)
        {
            if(buttonUiMainWatchStart.Text == "开始监控")
            {
                buttonUiMainWatchStart.Text = "停止";
                textBoxUiMainWatchFrq.Enabled = false;
                myTimerInterval = 0;
                uiMain_GetDataGridViewData();
                if (uiMain_list.Count <= 0)
                {
                    MessageBox.Show("请选择要获取的项目！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }
                InitializeTimer();
            }
            else
            {
                buttonUiMainWatchStart.Text = "开始监控";
                myTimer.Enabled = false;
                myTimerInterval = 0;
                textBoxUiMainWatchFrq.Enabled = true;
            }
        }

        public void InitializeTimer(UInt32 timeMs)
        {
            // 调用本方法开始用计算器          
            myTimer.Interval = timeMs;
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(timerTask);
            myTimer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            myTimer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        public void InitializeTimer()
        {
            // 调用本方法开始用计算器          
            myTimer.Interval = 1000;
            myTimerInterval = 0;
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(timerTask);
            myTimer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            myTimer.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

            
        }

        public void timerTask(object source, System.Timers.ElapsedEventArgs e)
        {
            UInt32 timeMs = Convert.ToUInt32(textBoxUiMainWatchFrq.Text) * 1000 * 60;
            if (timeMs < (5 * 1000 * 60))
            {
                timeMs = 5 * 1000 * 60;
                textBoxUiMainWatchFrq.Text = "5";
            }
            if ( myTimerInterval == 0 )
            {
               //  myTimer.Enabled = false;
                 myTimer.Interval = 10000;
             //    myTimer.Enabled = true;
                 myTimerInterval += myTimer.Interval;
                 uiMain_ThreadBuild();
            }
            else
            {
                myTimerInterval += myTimer.Interval;
                if (myTimerInterval >= timeMs )
                {
                     uiMain_ThreadBuild();
                }
            }
           
           
        }

        private void uiMain_ThreadBuild()
        {
            Thread demoThread = null;

            for (int i = 0; i < uiMain_list.Count; i++)
            {
                demoThread = new Thread(new ParameterizedThreadStart(uiMain_ThreadGetdataGridViewWareInfor));
                demoThread.IsBackground = true;
                demoThread.Start(uiMain_list[i]);
            }

        }

        /// <summary>
        /// 获取网页价格
        /// </summary>
        /// <param name="data"></param>
        public void uiMain_ThreadGetdataGridViewWareInfor(object data)
        {
            WarePriceNode ListNode = data as WarePriceNode;
            WarePriceNode wareNoe;
            ProductInfo wareInfor;

            //获取WEB数据
            SysParams.GatherModel = GatherType.Single;
           wareInfor = WareDealer.WareService.GetInstance().GetWareInfoByID(ListNode.warePriceN.ProductSkuid);
           wareNoe = WareDealer.WareService.GetInstance().FatQGetBatchPrice(ListNode.warePriceN.ProductSkuid);
            if (null != wareInfor)
            {
                ListNode.warePriceN.ProductPCPrice      = wareNoe.warePriceN.ProductPCPrice;
                ListNode.warePriceN.ProductAppPrice     = wareNoe.warePriceN.ProductAppPrice;
                ListNode.warePriceN.ProductQQPrice      = wareNoe.warePriceN.ProductQQPrice;
                ListNode.warePriceN.ProductWeiXinPrice  = wareNoe.warePriceN.ProductWeiXinPrice;

                ListNode.warePriceN.ProductGetTime = wareInfor.CreateTime;

                switch (wareInfor.ProductIsSaled)
               {
                   case -10:
                       ListNode.warePriceN.ProductStock = "无效SKUID";
                       break;
                   case -1: ListNode.warePriceN.ProductStock = "下架";
                       break;
                   case 0: ListNode.warePriceN.ProductStock = "无货";
                       break;
                   case 1: ListNode.warePriceN.ProductStock = "有货";
                       break;
                   case 2: ListNode.warePriceN.ProductStock = "配货";
                       break;
                   case 3: ListNode.warePriceN.ProductStock = "预订";
                       break;

                   default:
                       ListNode.warePriceN.ProductStock = "无库存信息";
                       break;
               }

            }
            else
            {
                ListNode.warePriceN.ProductStock = "无效SKUID";
            }

            uiMain_listShow.Add(ListNode);

            if (uiMain_list.Count == uiMain_listShow.Count)
            {
                uiMain_listShowTask();
            }

        }

        private void uiMain_listShowTask()
        {
            bool bWarn = false;
            bool bRet = false;
         //   int countSuccessed = 0;
         //   int countFailed = 0;
            SqlCommit sqlconn = new SqlCommit();

          //  MessageBox.Show("还没有完全获取");
            for (int i = 0; i < uiMain_listShow.Count;i++ )
            {
                // 存在SQL
                bRet = sqlconn.Sqlcommit_Insert(uiMain_listShow[i].warePriceN);
                if(false == bRet )
                {
                    // MessageBox.Show("无此件数据的基本信息，请在录入后再操作！");
                }
                //检查报警
                bWarn = uiMainWatchWarnCheck(uiMain_listShow[i].warePriceN);
                // 8, PC
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[8].Value = uiMain_listShow[i].warePriceN.ProductPCPrice.ToString();
                // 9, APP价
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[9].Value = uiMain_listShow[i].warePriceN.ProductAppPrice.ToString();
                //10 , Q价
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[10].Value = uiMain_listShow[i].warePriceN.ProductQQPrice.ToString();
                // 11 ,WeiXin价
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[11].Value = uiMain_listShow[i].warePriceN.ProductWeiXinPrice.ToString();
                // 12,库存
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[12].Value = uiMain_listShow[i].warePriceN.ProductStock.ToString();
                //13，时间
                dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[13].Value = uiMain_listShow[i].warePriceN.ProductGetTime.ToString();
                //14,查看

                //将指定商家无库存的归类到我的异常表
                if (dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[1].Value.ToString().IndexOf("新松联") >=0 && 
                    "无货" == uiMain_listShow[i].warePriceN.ProductStock.ToString())
                {
                    uiMainWatchDisplayDiffTable(dataGridViewUiMainMyWarn, dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index]);
                }

                //将报警的归类一个表
                if (true == bWarn)
                {
                    uiMainWatchDisplayDiffTable(dataGridViewUiMainWarn, dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index]);
                    //对报警的行字体显示红色
                    dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[8].Style.ForeColor = Color.Red;
                    dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[9].Style.ForeColor = Color.Red;
                    dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[10].Style.ForeColor = Color.Red;
                    dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[11].Style.ForeColor = Color.Red;
                }
            }
            uiMain_listShow.Clear();
        }

        private bool uiMainWatchWarnCheck(WarePrice wPrice)
        {
            bool bRet = false;

            if (wPrice.ProductPCPrice < wPrice.ProductWarnPrice || wPrice.ProductAppPrice  < wPrice.ProductWarnPrice ||
                wPrice.ProductQQPrice < wPrice.ProductWarnPrice || wPrice.ProductWeiXinPrice < wPrice.ProductWarnPrice)
            {
                bRet = true;
            }

            return bRet;
        }

        private void uiMainWatchDisplayDiffTable(DataGridView datGridV,DataGridViewRow row )
        {
            DataGridViewRow rowNew = new DataGridViewRow();
            DataGridViewCheckBoxCell checkboxcell = new DataGridViewCheckBoxCell();
            rowNew.Cells.Add(checkboxcell);

            for (int i = 1; i < row.Cells.Count - 1; i++)
            {
                DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                textboxcell.Value = row.Cells[i].Value;
                rowNew.Cells.Add(textboxcell);
            }

           DataGridViewLinkCell linkcell = new DataGridViewLinkCell();
           linkcell.Value = "查看";
           linkcell.TrackVisitedState = true;
           rowNew.Cells.Add(linkcell);

           if (datGridV.Rows.Count % 2 == 0)
           {
               rowNew.DefaultCellStyle.BackColor = Color.LightSteelBlue;
           }
           else
           {
               rowNew.DefaultCellStyle.BackColor = Color.Lavender;
           }

           datGridV.Rows.Add(rowNew);

           
        }
        private void comboBoxUiMainPName_DropDown(object sender, EventArgs e)
        {
            if (0 == comboBoxUiMainPName.Items.Count)
            {
                //MessageBox.Show("无商品信息数据，正从数据库获取...");
                //从数据库获取

                //获取完成后填充数据到当前框，comboBoxUiWatchSerial和comboBoxUiWatchColor
                comboBoxUiMainPName.Items.Add("所有");
                //添加所有获得对应的数据在此框
                // comboBoxUiWatchPName.Items.Add("小米");

                //添加所有获得对应的数据在comboBoxUiWatchSerial框
                comboBoxUiMainPSerial.Items.Add("所有");
                // comboBoxUiWatchSerial.Items.Add("红米Note");

                //添加所有获得对应的数据在comboBoxUiWatchColor框
                comboBoxUiMainPColor.Items.Add("所有");
                // comboBoxUiWatchColor.Items.Add("红色");


                //将获取到的数据显示在 dataGridViewUiWatch
            }
        }

        private void buttonUiMainSelec_Click(object sender, EventArgs e)
        {
            bool bFlag = false;

            DataGridView datGridV;
            if (tabControlUiMainWatch.SelectedTab.Text == "监控表")
            {
                datGridV = dataGridViewUiMainWatch;
            }
            else if (tabControlUiMainWatch.SelectedTab.Text == "异常表")
            {
                datGridV = dataGridViewUiMainWarn;
            }
            else
            {
                datGridV = dataGridViewUiMainMyWarn;
            }

            if (buttonUiMainSelec.Text == "全选")
            {
                buttonUiMainSelec.Text = "反选";
                bFlag = true;
            }
            else
            {
                buttonUiMainSelec.Text = "全选";
                bFlag = false;
            }

            foreach (DataGridViewRow dr in datGridV.Rows)
            {
                dr.Cells[0].Value = bFlag;
            }

        }

        private void dataGridViewUiMainWatch_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridViewUiMainWatch.Rows.Count % 2 == 0)
            {
                dataGridViewUiMainWatch.Rows[dataGridViewUiMainWatch.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                dataGridViewUiMainWatch.Rows[dataGridViewUiMainWatch.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }

        private void dataGridViewUiMainWarn_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridViewUiMainWarn.Rows.Count % 2 == 0)
            {
                dataGridViewUiMainWarn.Rows[dataGridViewUiMainWarn.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                dataGridViewUiMainWarn.Rows[dataGridViewUiMainWarn.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }

        private void dataGridViewUiMainMyWarn_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridViewUiMainMyWarn.Rows.Count % 2 == 0)
            {
                dataGridViewUiMainMyWarn.Rows[dataGridViewUiMainMyWarn.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            else
            {
                dataGridViewUiMainMyWarn.Rows[dataGridViewUiMainMyWarn.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }
    }
}
