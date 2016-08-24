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
    public partial class uiLogin : Form
    {
        public uiLogin()
        {
            InitializeComponent();
        }

        private void buttonUiLogin_Click(object sender, EventArgs e)
        {
            string userName = textBoxUiLoginUserName.Text.ToString().Trim();
            string userPwd = textBoxUiLoginUserPwd.Text.ToString().Trim();
            string sqlAddr = textBoxUiLoginSqlAddr.Text.ToString().Trim();
            //获取用户名与密码，登录对应的服务器
            //如果通过验证则放行，进入主界面，否则结束并退出
            //if(userName == "" )
            //{
            //    MessageBox.Show("用户名不能为空！");
            //    return;
            //}

            //if (userPwd == "")
            //{
            //    MessageBox.Show("密码不能为空！");
            //    return;
            //}

            //if (sqlAddr == "")
            //{
            //    MessageBox.Show("服务器地址不能为空！");
            //    return;
            //}

            if ( false == uiLoginCheck(userName, userPwd,sqlAddr) )
            {
                //Close();
                MessageBox.Show("登录失败！");
            }
            else
            {
                //退出返回主界面
                Close();

            }

        }


        private bool uiLoginCheck(string uiLoginUser, string uiLoginPwd,string uiLoginSqlAddr )
        {
            bool bRet = false;

            //登录SQL服务器


            //查询并验证

            //通过则返回true
            bRet = true;

            return bRet;
        }
    }
}
