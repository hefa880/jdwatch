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

namespace jdWatch
{
    public partial class uiInput : Form
    {
        IList<InputDataStruct> uiInput_list = new List<InputDataStruct>();

        public uiInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从个表中获取数据，并添加到链表
        /// </summary>
        private void uiInput_GetDataGridViewData()
        {
            uiInput_list.Clear();
            

            foreach (DataGridViewRow dr in dataGridViewUiIpnut.Rows)
            {
                if (null == dr.Cells[0].FormattedValue)
                {
                    continue;
                }

                if (dr.Cells[0].FormattedValue.ToString() == true.ToString() && null != dr.Cells[6].Value )
                {
                    InputDataStruct inputData = new InputDataStruct();

                    inputData.data.ProductName       = dr.Cells[1].Value.ToString().Trim();
                    inputData.data.ProductSerial     = dr.Cells[2].Value.ToString().Trim();
                    inputData.data.ProductColor      = dr.Cells[3].Value.ToString().Trim();
                    inputData.data.ProductVersion    = dr.Cells[4].Value.ToString().Trim();
                    inputData.data.ProductSkuid      = dr.Cells[6].Value.ToString().Trim();
                    inputData.data.ProductSeller     = dr.Cells[7].Value.ToString().Trim();
                    inputData.data.ProductWarnPrice  = Convert.ToDouble(dr.Cells[8].Value.ToString().Trim());
                    inputData.data.ProductWarnDriect = dr.Cells[9].Value.ToString().Trim();
                    inputData.data.ProductState      = dr.Cells[10].Value.ToString().Trim();

                    uiInput_list.Add(inputData);
                }
            }
        }

       /// <summary>
       /// 自动添加行号
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dataGridViewUiIpnut_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 从表中获取商品编号，并向WEB请求数据，并将数据写回本表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputGetWareInfor_Click(object sender, EventArgs e)
        {
            //此部分可能用到定时器完成
        }

        /// <summary>
        /// 将编辑好的数据写入数据库保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUiInputSaveToSql_Click(object sender, EventArgs e)
        {
            SqlCommit sqlconn = new SqlCommit();

            uiInput_GetDataGridViewData();
            // 保存到数据库
            for(int i = 0; i < uiInput_list.Count; i++ )
                sqlconn.Sqlcommit_Insert("input_tbl", uiInput_list[i].data); 
            //检查链表数据，如果提交成功则从dataGridViewUiIpnut中删除，否则保留，并在状态列显示原因

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

        private void buttonUiInputEditSql_Click(object sender, EventArgs e)
        {

        }

    }
}
