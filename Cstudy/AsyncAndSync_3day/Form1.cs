using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndSync_3day
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //메소드를 참조할 수 있다.
        delegate void MySettingDeiegate(string str);

        private void Form1_Load(object sender, EventArgs e)
        {
            string myString = "aa";
            //비동기
            MySettingDeiegate mySettingDeiegate = MySetting;
            mySettingDeiegate.Invoke(myString); //동기
            //mySettingDeiegate.BeginInvoke(myString, null,null); //비동기

            //비동기작업이 우선끝나면aa
            //비동기작업이 더늦게 끝났기 때문에 긴aaaaaaaaaa

            //동기작업에서는 aa
            label1.Text = myString;
        }

        private void MySetting(string str)
        {
            for(int i=0; i < 100; i++)
            {
                str += "aaa";
            }

            ////다른 쓰레드에서 메소드가 실행됨.

            ///쓰레드가 생성되는 것은 되는 것은 아니다.
            this.BeginInvoke((Action)(() =>
            {
                label1.Text = str;

            }));

            this.Invoke((Action)(() =>
            {
                label1.Text = str;

            }));
        }
    }
}
