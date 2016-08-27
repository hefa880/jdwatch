using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiInputDataStruct.Mode
{
    public class CUiInputDataStruct
    {
        
        public string ProductName;  // 品牌 1
        public string ProductSerial;//系列  2
        public string ProductColor;//颜色 3
        public string ProductVersion;//版本 4
        public string ProductSkuid;//商品编号 6
        public string ProductSeller;//商家    7
        public double ProductWarnPrice;//控价  8
        public string ProductWarnDriect;//控价方向  9
        public string ProductState;//状态[已有，新增] 10
    }

    public class InputDataStruct
    {
        public CUiInputDataStruct data;
    }
}