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
using UiInputDataStruct.Mode;

namespace jdWatch
{
    public partial class uiCreateNew : Form
    {
        IList<InputDataStruct> uiCreateNew_list = new List<InputDataStruct>();
        public uiCreateNew()
        {
            InitializeComponent();
        }

        private void uiCreateNew_GetDataGridViewData()
        {
            uiCreateNew_list.Clear();
            int i = -1;
            foreach (DataGridViewRow dr in dataGridViewUiCreateNew.Rows)
            {
                i++;
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
                        inputData.data.ProductSkuid = dr.Cells[2].Value.ToString().Trim();

                    if (null != dr.Cells[3].Value)
                        inputData.data.ProductName = dr.Cells[3].Value.ToString().Trim();
                    if (null != dr.Cells[4].Value)
                        inputData.data.ProductSerial = dr.Cells[4].Value.ToString().Trim();
                    if (null != dr.Cells[5].Value)
                        inputData.data.ProductColor = dr.Cells[5].Value.ToString().Trim();
                    if (null != dr.Cells[6].Value)
                        inputData.data.ProductVersion = dr.Cells[6].Value.ToString().Trim();

                    if (null != dr.Cells[8].Value)
                        inputData.data.ProductWarnPrice = Convert.ToDouble(dr.Cells[8].Value.ToString().Trim());
                    if (null != dr.Cells[9].Value)
                        inputData.data.ProductWarnDriect = dr.Cells[9].Value.ToString().Trim();
                    if (null != dr.Cells[10].Value)
                        inputData.data.ProductState = dr.Cells[10].Value.ToString().Trim();
                    inputData.data.index = i;

                    uiCreateNew_list.Add(inputData);
                }
            }
        }

        private void UiCreateNew_ShowSaveStatus()
        {
            for (int i = 0, j = 0; i < dataGridViewUiCreateNew.Rows.Count - 1 && j < uiCreateNew_list.Count; i++)
            {
                if (dataGridViewUiCreateNew.Rows[i].Cells[6].Value.ToString().Trim() == uiCreateNew_list[j].data.ProductSkuid)
                {
                    if (uiCreateNew_list[j].data.ProductState == "新增")
                    {
                        dataGridViewUiCreateNew.Rows.RemoveAt(i);
                        uiCreateNew_list.Remove(uiCreateNew_list[j]);
                        i--;
                    }
                    else
                    {
                        dataGridViewUiCreateNew.Rows[i].Cells[10].Value = uiCreateNew_list[j].data.ProductState;
                        j++;
                    }
                }
            }
            //  uiInput_list.Clear();
        }

        private void buttonUiCreateNewSave_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            int countSuccessed = 0;
            int countFailed = 0;
            SqlCommit sqlconn = new SqlCommit();

            uiCreateNew_GetDataGridViewData();
            if (0 == uiCreateNew_list.Count)
            {
                return;
            }
            // 保存到数据库
            for (int i = 0; i < uiCreateNew_list.Count; i++)
            {
                bRet = sqlconn.Sqlcommit_Insert(uiCreateNew_list[i].data);
                if (true == bRet)
                {
                    uiCreateNew_list[i].data.ProductState = "新增";
                    countSuccessed++;
                }
                else
                {
                    uiCreateNew_list[i].data.ProductState = "已有";
                    countFailed++;
                }
            }

            //检查链表数据，如果提交成功则从dataGridViewUiIpnut中删除，否则保留，并在状态列显示原因
            UiCreateNew_ShowSaveStatus();
            if (uiCreateNew_list.Count > 0) /// && this.Text != "编辑数据库")
            {
                DialogResult dRet = DialogResult.No;

                dRet = MessageBox.Show("有重复的数据，是否要覆盖？\n是，覆盖\n否，抛弃这些重复数据", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRet == DialogResult.Yes)
                {
                    for (int i = 0; i < uiCreateNew_list.Count; i++)
                    {
                        bRet = sqlconn.Sqlcommit_Update(uiCreateNew_list[i].data);
                    }
                }

                for (int i = 0; i < dataGridViewUiCreateNew.Rows.Count - 1; i++)
                {
                    if (null == dataGridViewUiCreateNew.Rows[i].Cells[0].Value)
                    {
                        continue;
                    }

                    if (dataGridViewUiCreateNew.Rows[i].Cells[0].Value.ToString() == true.ToString())
                    {
                        dataGridViewUiCreateNew.Rows.RemoveAt(i);
                        i--; //关键在这里
                    }
                }
                uiCreateNew_list.Clear();
            }
        }
    }
}
