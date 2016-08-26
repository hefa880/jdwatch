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
    public partial class uiMain : Form
    {
        public uiLogin    uiLoginW;
        public uiWatch    uiWatchW;
        public uiInput     uiIputW;
        public uiHistory   uiHistoryW;
        public uiSys       uiSysW;

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
            uiWatchW.ShowDialog();
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
    }
}
