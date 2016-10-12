﻿using System;
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
using System.IO;

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
            //uiLoginW    = new uiLogin();
            //uiWatchW    = new uiWatch();
            //uiIputW     = new uiInput();
            //uiHistoryW  = new uiHistory();
            //uiSysW      = new uiSys();
            //进入登录界面
           // uiLoginW.ShowDialog();
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
            //uiWatchW.sndWarnListToUiMain += uiWatchW_sndWarnListToUiMain;
            //uiWatchW.ShowDialog();
            
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
                //uiMain_GetDataGridViewData();
                //if (uiMain_list.Count <= 0)
                //{
                //    MessageBox.Show("请选择要获取的项目！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //    return;
                //}
                //InitializeTimer();
                // uiMain_watchTask();
                uiMain_watchTaskV2();
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
        Thread demoThread = null;
        private void uiMain_watchTask()
        {
            SqlCommit sqlconn = new SqlCommit();
            uiMain_list.Clear();
            uiMain_listShow.Clear();
            //获取数据监控数据表
            for(int j = 0;j<5;j++)
            {
                WarePriceNode inputData = new WarePriceNode();
                inputData.warePriceN = new WarePrice();
                inputData.warePriceN.ProductSkuid = "3466744";
                uiMain_list.Add(inputData);
            }
            
            //开启线程
            for (int i = 0; i < uiMain_list.Count; i++)
            {
                demoThread = new Thread(new ParameterizedThreadStart(uiMain_ThreadGetWareInfor));
                demoThread.IsBackground = true;
                demoThread.Name = i.ToString();
                demoThread.Start(uiMain_list[i]);
            }
        }

        private void uiMain_watchTaskV2()
        {
            uiMain_list.Clear();
            uiMain_listShow.Clear();
            for (int i = 0; i < 21; i++)
            {
                demoThread = new Thread(new ParameterizedThreadStart(uiMain_ChildTread));
                demoThread.IsBackground = true;
                demoThread.Name = i.ToString();
                demoThread.Start("task" + i.ToString());
            }
        }
        delegate void SetTextCallback(string text);
        public void Write(string text)
        {
            FileStream fs = new FileStream("jdwatch.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(text);
            sw.Close();
            fs.Close();
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
           
            if (this.textBoxLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (textBoxLog.Text.Length > 1024 * 512)
                {
                    this.textBoxLog.Clear();
                }

                DateTime tm =  DateTime.Now;
                Write(tm.ToLocalTime().ToString() + "  " + text + "\r\n");
                this.textBoxLog.AppendText(tm.ToLocalTime().ToString() + "  " + text + "\r\n");
                if(text.LastIndexOf("报警")> 0 )
                    this.textBoxLog.ForeColor = Color.Red;
                else
                    this.textBoxLog.ForeColor = Color.Teal;
                //  this.textBoxLog.Text += tm.ToLocalTime().ToString() + "  "+text + "\r\n";
                this.textBoxLog.ScrollToCaret();
                this.textBoxLog.Focus();
                this.textBoxLog.Select(this.textBoxLog.TextLength, 0);//光标定位到文本最后
                this.textBoxLog.ScrollToCaret();
            }
        }
        private void uiMain_Reg()
        {
           if( DateTime.Now >  DateTime.Parse("2016-10-30") )
           {
               MessageBox.Show("已经过试用期，请联系管理员注册\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               Close();
           }
        }
        private void uiMain_ChildTread(object data)
        {
            string  taskNo = data as string;
           // SetText("uiMain_ChildTread Task" + Thread.CurrentThread.Name.ToString() + "\n");
            if ( "task0" == taskNo)
            {
                // 获取数据列表
                uiMain_GetSetSqlList();
            }
            else
            {
                //执行获取数据的任务
                uiMain_ChildThreadGetWareInfor();
                //执行完成，等待下次任务来临
            }
        }

        private void uiMain_GetSetSqlList()
        {
            SqlCommit sqlcomm = new SqlCommit();
            bool bSleep = false;
            int timerCount = 0;

            while (true)
            {
                if(buttonUiMainWatchStart.Text == "开始监控")
                {
                    SetText("Task0 Exit\n");
                    Thread.CurrentThread.Abort();
                    break;
                }
                uiMain_Reg();
                if( true == bSleep )
                {
                    Thread.Sleep(1000);
                    if(timerCount % 10 == 0 )
                    {
                        int left = 15 * 60 - timerCount;
                        SetText("距离下轮开始的时间还有:" + left + " 秒\n");
                    }
                    timerCount++;
                    if ( timerCount > 15 * 60 )
                    {
                        timerCount = 0;
                        bSleep = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                int tatolNumber = 0;
                int ops = 0;
                //每次最多只取20个数据
                DataSet ds = sqlcomm.Sqlcommit_Select("select product_id,product_skuid,product_warn_price from product_infor ");
                if( null == ds )
                {
                    SetText("Task0 拉取失败\n");
                    Thread.Sleep(10000);
                    continue;
                }

                DataTable dt = ds.Tables[0];//填充
                if (dt == null || dt.Rows.Count == 0)
                {
                    //  MessageBox.Show("拉取失败");
                    SetText("Task0 拉取失败\n");
                    Thread.Sleep(10000);
                    continue;
                }
                else
                {
                    tatolNumber = dt.Rows.Count;
                    ops = 0;
                    SetText("Task0 成功拉取:" + dt.Rows.Count.ToString()+ "\n");

                    // string str = "成功拉取:" + dt.Rows.Count.ToString();
                    // MessageBox.Show(str);
                }

                while (true)
                {
                    if (ops == tatolNumber)
                    {
                        SetText("做完了一轮!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\r\n");
                        uiMain_list.Clear();
                        tatolNumber = 0;
                        ops = 0;
                        timerCount = 0;
                        bSleep = true;
                        break;
                    }
                        
                    //取完填写在链表中，由其他线程读取使用
                    for (; ops < tatolNumber;)
                    {
                        WarePriceNode ListNode = new WarePriceNode();
                        ListNode.warePriceN = new WarePrice();

                        if ("" == dt.Rows[0].ItemArray.GetValue(1).ToString().Trim())
                        {
                            continue;
                        }
                        ListNode.warePriceN.ProductSkuid = dt.Rows[0].ItemArray.GetValue(1).ToString().Trim();
                        ListNode.warePriceN.ProductWarnPrice = Convert.ToDouble(dt.Rows[0].ItemArray.GetValue(2).ToString().Trim());

                        // 添加到链表中去
                        uiMain_list.Add(ListNode);
                        ops++;
                        SetText("添加 " + ops + " 条 " + ListNode.warePriceN.ProductSkuid +"\n");
                        
                        if ((0 != ops) && (ops % 20 == 0))
                        {
                            break;
                        }
                        dt.Rows.RemoveAt(0);
                        if(dt.Rows.Count == 0)
                        {
                            SetText("Task0 Count == 0!\n");
                            break;
                        }
                    }

                    SetText( "Task0 填写main_show表共 " + ops +" 条数据OK\n");
                    uiMain_listShow.Clear();
                    uiMain_list[0].startFlag = true;
                    //检查链表使用的情况，如果都已经获取到数据，并填写main_show表上，则提交此次数据
                    for (;;)
                    {
                        //如果都已经获取到数据
                        if (uiMain_listShow.Count >= uiMain_list.Count)
                        {
                            //并填写main_show表上，则提交此次数据
                            SetText("Task0 提交数据\n");
                            uiMain_UpdateSql();
                            tatolNumber -= ops;
                            ops = 0;
                            uiMain_list.Clear();
                            uiMain_listShow.Clear();
                            break;
                        }
                        else
                        {
                            SetText("Task0 wait"+ uiMain_listShow.Count.ToString()  + " / " +  uiMain_list.Count.ToString());
                            Thread.Sleep(1000);
                        }

                        if (buttonUiMainWatchStart.Text == "开始监控")
                        {
                            SetText("Task0 Exit\n");
                            Thread.CurrentThread.Abort();
                            break;
                        }
                    }
                }
               
            }
        }

        private bool uiMain_UpdateSql()
        {
            DataTable dt = new DataTable();
            DataTable dt_state = new DataTable();

            dt.Columns.Add("product_id", Type.GetType("System.Guid"));
            dt.Columns.Add("product_skuid", Type.GetType("System.String"));
            dt.Columns.Add("product_warn_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("product_jd_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("product_app_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("product_weixin_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("product_qq_price", Type.GetType("System.Decimal"));
            dt.Columns.Add("product_stock", Type.GetType("System.String"));
            dt.Columns.Add("product_get_time", Type.GetType("System.DateTime"));
           // dt.Columns.Add("product_url", Type.GetType("System.String"));
            dt.Columns.Add("isDelete", Type.GetType("System.Byte"));
            
            dt_state.Columns.Add("ID", Type.GetType("System.Guid"));
            dt_state.Columns.Add("SKU", Type.GetType("System.String"));
            dt_state.Columns.Add("Status", Type.GetType("System.String"));

            SqlCommit sqlconn = new SqlCommit();
            ///将数据写入SQL
            for (int i = 0; i < uiMain_list.Count; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = System.Guid.NewGuid(); // uiMain_listShow[i].warePriceN.
                newRow[1] = uiMain_listShow[i].warePriceN.ProductSkuid;
                newRow[2] = uiMain_listShow[i].warePriceN.ProductWarnPrice;
                newRow[3] = uiMain_listShow[i].warePriceN.ProductPCPrice;
                newRow[4] = uiMain_listShow[i].warePriceN.ProductAppPrice;
                newRow[5] = uiMain_listShow[i].warePriceN.ProductWeiXinPrice;
                newRow[6] = uiMain_listShow[i].warePriceN.ProductQQPrice;
                newRow[7] = uiMain_listShow[i].warePriceN.ProductStock;
                newRow[8] = uiMain_listShow[i].warePriceN.ProductGetTime;
              //  newRow[9] = "https://item.jd.com/"+uiMain_listShow[i].warePriceN.ProductSkuid+".html";
                newRow[9] = 0;
                string warn = "";
                if(uiMain_listShow[i].warePriceN.WarnTablFlag == 1 )
                {
                    warn = " 低价报警";
                }
                else if(uiMain_listShow[i].warePriceN.WarnTablFlag == 2 )
                {
                    warn = " 新松联缺货提示";
                }
                
                string tex = i+" " + newRow[1].ToString() + " " + newRow[2].ToString() + " " + newRow[3].ToString() + " " + newRow[4].ToString() + " " + newRow[5].ToString() + " " +
                             newRow[6].ToString() + " " + newRow[7].ToString() + " " + newRow[8].ToString() + warn+ "\n";
                SetText(tex);
                dt.Rows.Add(newRow);
                //  sqlconn.Sqlcommit_Insert(uiMain_listShow[i].warePriceN);

               DataRow newRow_state = dt_state.NewRow();

                newRow_state[0] = newRow[0];// System.Guid.NewGuid(); // uiMain_listShow[i].warePriceN.
                newRow_state[1] = uiMain_listShow[i].warePriceN.ProductSkuid;
                newRow_state[2] = uiMain_listShow[i].warePriceN.WarnTablFlag;
                dt_state.Rows.Add(newRow_state);
                sqlconn.Sqlcommit_Del("product_status", "SKU= '"+ newRow_state[1].ToString()+"'");
                sqlconn.Sqlcommit_Update("product_price", uiMain_listShow[i].warePriceN.ProductSkuid);
                if( sqlconn.Sqlcommit_InsertAll("product_price", dt) )
                {
                    sqlconn.Sqlcommit_InsertAll("product_status", dt_state);
                }
                else
                {
                    SetText("提交失败！！！！");
                }
                

                dt.Rows.Remove(newRow);
                dt_state.Rows.Remove(newRow_state);
            }

            //  sqlconn.Sqlcommit_InsertAll("product_price", dt);
            //   sqlconn.Sqlcommit_InsertAll("product_status", dt_state);
            uiMain_listShow.Clear();
            uiMain_list.Clear();

            return true;
        }

        public void uiMain_ChildThreadGetWareInfor( )
        {
            int ops = 0;
            int index = 0;
            while(true)
            {
                while (true)
                {
                    if (buttonUiMainWatchStart.Text == "开始监控")
                    {
                        SetText("Task" + Thread.CurrentThread.Name.ToString() + " Exit OK\n");
                        Thread.CurrentThread.Abort();
                        break;
                    }

                    if (0 == uiMain_list.Count)
                    {
                       // SetText("Task" + Thread.CurrentThread.Name.ToString() + " uiMain_list.Count == 0\n");
                        Thread.Sleep(1000);
                        continue;
                    }

                    //if (uiMain_list[0].startFlag == false)
                    //{
                    //    SetText( "Task" + Thread.CurrentThread.Name.ToString() + " uiMain_list[0].startFlag == false\n");
                    //    Thread.Sleep(2000);
                    //    continue;
                    //}
                    //else
                    {
                        ops = 0;
                        break;
                    }
                }
                index = Convert.ToInt32(Thread.CurrentThread.Name) - 1;
              //  SetText("Task" + Thread.CurrentThread.Name.ToString() + " try to get wareinfor\n");
                if (index >= uiMain_list.Count )
                {
                    uiMain_list[0].startFlag = false;
                    Thread.Sleep(1000);
                    continue;
                }

                if ("" == uiMain_list[index].warePriceN.ProductSkuid)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                WarePriceNode ListNode = new WarePriceNode();
                ListNode = uiMain_list[index];
                WarePriceNode wareNoe;
                ProductInfo wareInfor;
                
                //获取WEB数据
                SysParams.GatherModel = GatherType.Single;
                wareInfor = WareDealer.WareService.GetInstance().GetWareInfoByID(ListNode.warePriceN.ProductSkuid);
                wareNoe = WareDealer.WareService.GetInstance().FatQGetBatchPrice(ListNode.warePriceN.ProductSkuid);
                if (null != wareInfor)
                {
                    ListNode.warePriceN.ProductPCPrice = wareNoe.warePriceN.ProductPCPrice;
                    ListNode.warePriceN.ProductAppPrice = wareNoe.warePriceN.ProductAppPrice;
                    ListNode.warePriceN.ProductQQPrice = wareNoe.warePriceN.ProductQQPrice;
                    ListNode.warePriceN.ProductWeiXinPrice = wareNoe.warePriceN.ProductWeiXinPrice;
                    ListNode.warePriceN.ProductSeller = wareInfor.ProductBrand;
                    ListNode.warePriceN.ProductGetTime = wareInfor.CreateTime;

                    switch (wareInfor.ProductIsSaled)
                    {
                        case -10:
                            ListNode.warePriceN.ProductStock = "无效SKUID";
                            break;
                        case -1:
                            ListNode.warePriceN.ProductStock = "下架";
                            break;
                        case 0:
                            ListNode.warePriceN.ProductStock = "无货";
                            break;
                        case 1:
                            ListNode.warePriceN.ProductStock = "有货";
                            break;
                        case 2:
                            ListNode.warePriceN.ProductStock = "配货";
                            break;
                        case 3:
                            ListNode.warePriceN.ProductStock = "预订";
                            break;

                        default:
                            ListNode.warePriceN.ProductStock = "无库存信息";
                            break;
                    }

                    bool bWarn = uiMainWatchWarnCheck(ListNode.warePriceN);
                    //将报警的归类一个表
                    if (true == bWarn)
                    {
                        ListNode.warePriceN.WarnTablFlag = 1;
                    }
                    else if (ListNode.warePriceN.ProductSeller.ToString().IndexOf("新松联") >= 0 &&
                        "无货" == ListNode.warePriceN.ProductStock.ToString())
                    {
                        //将数据打上异常标志
                        ListNode.warePriceN.WarnTablFlag = 2;
                    }
                    else
                    {
                        ListNode.warePriceN.WarnTablFlag = 0;
                    }
                }
                else
                {
                    ListNode.warePriceN.ProductStock = "无效SKUID";
                }

                uiMain_listShow.Add(ListNode);
                SetText("Task" + Thread.CurrentThread.Name.ToString() + " uiMain_listShow.Add OK "+ ListNode.warePriceN.ProductSkuid+"\n");

                while (true)
                {
                    if (buttonUiMainWatchStart.Text == "开始监控")
                    {
                        SetText("Task" + Thread.CurrentThread.Name.ToString() + "Exit OK\n");
                        Thread.CurrentThread.Abort();
                        break;
                    }
                    if ( 0 == uiMain_listShow.Count)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        public void uiMain_ThreadGetWareInfor(object data)
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
                ListNode.warePriceN.ProductPCPrice = wareNoe.warePriceN.ProductPCPrice;
                ListNode.warePriceN.ProductAppPrice = wareNoe.warePriceN.ProductAppPrice;
                ListNode.warePriceN.ProductQQPrice = wareNoe.warePriceN.ProductQQPrice;
                ListNode.warePriceN.ProductWeiXinPrice = wareNoe.warePriceN.ProductWeiXinPrice;
                ListNode.warePriceN.ProductSeller = wareInfor.ProductBrand;
                ListNode.warePriceN.ProductGetTime = wareInfor.CreateTime;

                switch (wareInfor.ProductIsSaled)
                {
                    case -10:
                        ListNode.warePriceN.ProductStock = "无效SKUID";
                        break;
                    case -1:
                        ListNode.warePriceN.ProductStock = "下架";
                        break;
                    case 0:
                        ListNode.warePriceN.ProductStock = "无货";
                        break;
                    case 1:
                        ListNode.warePriceN.ProductStock = "有货";
                        break;
                    case 2:
                        ListNode.warePriceN.ProductStock = "配货";
                        break;
                    case 3:
                        ListNode.warePriceN.ProductStock = "预订";
                        break;

                    default:
                        ListNode.warePriceN.ProductStock = "无库存信息";
                        break;
                }

                bool bWarn = uiMainWatchWarnCheck(ListNode.warePriceN);
                //将报警的归类一个表
                if (true == bWarn)
                {
                    ListNode.warePriceN.WarnTablFlag = 1;
                }
                else if (ListNode.warePriceN.ProductSeller.ToString().IndexOf("新松联") >= 0 &&
                    "无货" == ListNode.warePriceN.ProductStock.ToString())
                {
                    //将数据打上异常标志
                    ListNode.warePriceN.WarnTablFlag = 2;
                }
                else
                {
                    ListNode.warePriceN.WarnTablFlag = 0;
                }
            }
            else
            {
                ListNode.warePriceN.ProductStock = "无效SKUID";
            }

            uiMain_listShow.Add(ListNode);

            if (uiMain_list.Count == uiMain_listShow.Count)
            {
                DataTable dt = new DataTable();
                DataTable dt_state = new DataTable();

                dt.Columns.Add("product_id", Type.GetType("System.Guid"));
                dt.Columns.Add("product_skuid", Type.GetType("System.String"));
                dt.Columns.Add("product_warn_price", Type.GetType("System.Decimal"));
                dt.Columns.Add("product_jd_price", Type.GetType("System.Decimal"));
                dt.Columns.Add("product_app_price", Type.GetType("System.Decimal"));
                dt.Columns.Add("product_weixin_price", Type.GetType("System.Decimal"));
                dt.Columns.Add("product_qq_price", Type.GetType("System.Decimal"));
                dt.Columns.Add("product_stock", Type.GetType("System.String"));
                dt.Columns.Add("product_get_time", Type.GetType("System.DateTime"));
              //  dt.Columns.Add("product_url", Type.GetType("System.String"));

                dt_state.Columns.Add("ID", Type.GetType("System.Guid"));
                dt_state.Columns.Add("SKU", Type.GetType("System.String"));
                dt_state.Columns.Add("Status", Type.GetType("System.String"));


                ///将数据写入SQL
                for (int i =0;i < uiMain_list.Count;i++)
                {
                    DataRow newRow = dt.NewRow();
                    newRow[0] = System.Guid.NewGuid(); // uiMain_listShow[i].warePriceN.
                    newRow[1] = uiMain_listShow[i].warePriceN.ProductSkuid;
                    newRow[2] = uiMain_listShow[i].warePriceN.ProductWarnPrice;
                    newRow[3] = uiMain_listShow[i].warePriceN.ProductPCPrice;
                    newRow[4] = uiMain_listShow[i].warePriceN.ProductAppPrice;
                    newRow[5] = uiMain_listShow[i].warePriceN.ProductWeiXinPrice;
                    newRow[6] = uiMain_listShow[i].warePriceN.ProductQQPrice;
                    newRow[7] = uiMain_listShow[i].warePriceN.ProductStock;
                    newRow[8] = uiMain_listShow[i].warePriceN.ProductGetTime;
                    dt.Rows.Add(newRow);

                    DataRow newRow_state = dt_state.NewRow();

                    newRow_state[0] = System.Guid.NewGuid(); // uiMain_listShow[i].warePriceN.
                    newRow_state[1] = uiMain_listShow[i].warePriceN.ProductSkuid;
                    newRow_state[2] = uiMain_listShow[i].warePriceN.WarnTablFlag;
                    dt_state.Rows.Add(newRow_state);

                }
                SqlCommit sqlconn = new SqlCommit();

                sqlconn.Sqlcommit_InsertAll("product_infor", dt);
                sqlconn.Sqlcommit_InsertAll("product_status", dt_state);
                uiMain_listShow.Clear();
            }
            else
            {
                //注意处理线程,此处应该结束
                //demoThread.DisableComObjectEagerCleanup();
               //demoThread.Abort();
            }
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
                ListNode.warePriceN.ProductSeller       = wareInfor.ProductBrand;
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
                //if (dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[1].Value.ToString().IndexOf("新松联") >=0 && 
                if (uiMain_listShow[i].warePriceN.ProductSeller.ToString().IndexOf("新松联") >= 0 &&
                    "无货" == uiMain_listShow[i].warePriceN.ProductStock.ToString())
                {
                  //  uiMainWatchDisplayDiffTable(dataGridViewUiMainMyWarn, dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index]);
                  //将数据打上异常标志
                }

                //将报警的归类一个表
                if (true == bWarn)
                {
                    //uiMainWatchDisplayDiffTable(dataGridViewUiMainWarn, dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index]);
                    ////对报警的行字体显示红色
                    //dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[8].Style.ForeColor = Color.Red;
                    //dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[9].Style.ForeColor = Color.Red;
                    //dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[10].Style.ForeColor = Color.Red;
                    //dataGridViewUiMainWatch.Rows[uiMain_listShow[i].warePriceN.index].Cells[11].Style.ForeColor = Color.Red;

                    //将数据打上异常标志
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

        private void buttonUiCreateNew_Click(object sender, EventArgs e)
        {

        }
    }
}
