using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jdWatch
{
    public partial class uiWatch : Form
    {
        public uiWatch()
        {
            InitializeComponent();
            //读取数据库，并将基本信息表反馈到当前的uiWatch的dataGridViewUiWatch
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
        /// 将选中的行信息添加到uiMaim的 dataGridViewUiMainWatch表中去
        /// 添加完成后，提示添加成功多少条，如果有重复的，提示是否覆盖
        /// 完成添加后，提示用户是否开启监控，如果开启则通知uiMain的 buttonUiMainWatchStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiWatchAddToWatch_Click(object sender, EventArgs e)
        {

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
      
          //  string str ="选中了"+ comboBoxUiWatchPName.SelectedItem.ToString();
           // MessageBox.Show(str);

            if( "所有" == comboBoxUiWatchPName.SelectedItem.ToString())
            {
                //拉取所有的数据
            }
            else
            {

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
          //  MessageBox.Show("条件为："+str + strSerial);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch

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

          //  MessageBox.Show("条件为：" + strPName + strSerial + strColor);
            //向SQL查询些字段的信息，并将信息反馈到dataGridViewUiWatch

        }

        private void dataGridViewUiWatch_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
