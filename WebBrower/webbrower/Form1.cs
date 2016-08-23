using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace webbrower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
            textBoxAddrInput.Text = "https://shop.jd.com/index.action";
            textBoxWareId.Text = "10103045034";
            webBrowserTest.Navigate(textBoxAddrInput.Text);
            webBrowserTest.ScriptErrorsSuppressed = true;
        }

        private void buttonWebGo_Click(object sender, EventArgs e)
        {
            webBrowserTest.Navigate(textBoxAddrInput.Text);
        }
        
        /// <summary>
        /// 获取输入价格，并将此价格填充到指定的表中，然后提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModifyP_Click(object sender, EventArgs e)
        {
            // 获取输入商品ID: 10103045034
            string strWareId = textBoxWareId.Text.Trim();  //获取输入商品ID
            string strAddr = "https://ware.shop.jd.com/ware/publish/ware_editWare.action?wid="+strWareId+"&saleStatus=onSale";
            
            textBoxAddrInput.Text = strAddr;

            //打开指定网页
            webBrowserTest.Navigate(strAddr);
        }

        private void GetElems()
        {
            string strPrice = textBoxPriseInput.Text.Trim();
            while (webBrowserTest.ReadyState != WebBrowserReadyState.Complete) ;
            //获取指定元素价格
            if( strPrice == "" )
            {
                strPrice = "9999.00";
            }

            HtmlElement elems = webBrowserTest.Document.GetElementById("price_1547893111");
            if (null == elems)
            {
                MessageBox.Show("没有找到price_1547893111");
            }
            else
            {
                elems.SetAttribute("value", strPrice);
            }

            elems = webBrowserTest.Document.GetElementById("warePubBtn");
            if (null == elems)
            {
                MessageBox.Show("没有找到 warePubBtn ");
            }
            else
            {
                elems.SetAttribute("value", "保存-找到");
                elems.InvokeMember("click");
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            GetElems();
        }

        private void  WriteWebBrowserRegKey(string fileName, string strValue)
        {
            // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION\\test", true); //该项必须已存在
            //software.SetValue("webbrower.exe", "7000", RegistryValueKind.DWord);
            //在HKEY_LOCAL_MACHINE\SOFTWARE\test下创建一个名为“test”，值为“博客园”的键值。如果该键值原本已经存在，则会修改替换原来的键值，如果不存在则是创建该键值。
            // 注意：SetValue()还有第三个参数，主要是用于设置键值的类型，如：字符串，二进制，Dword等等~~默认是字符串。如：
            software.SetValue("test", "0", RegistryValueKind.DWord); //二进制信息
            key.Close();
        }
    }
}
