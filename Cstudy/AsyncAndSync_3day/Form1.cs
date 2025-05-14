using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            //AsyncCallback //비동기 작업이 다 끝나고 나서 실행될 함수지정, 실행.
            AsyncCallback callback = new AsyncCallback(Complete);

            //비동기
            MySettingDeiegate mySettingDeiegate = MySetting;
            //비동기 작업이 끝났냐?
            IAsyncResult ar = mySettingDeiegate.BeginInvoke(myString, callback, "aaaaa"); //비동기
            bool state = ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3)); 

            //"비동기 작업이 끝날 때까지 최대 3초 동안 기다린다.
            //만약 3초 안에 끝나면 true, 안 끝났으면 false를 반환한다."

            //비동기작업이 5초 > 기다리는 시간 3초 

            //3초를 초과
            if (state)
            {
                //1.번작업
                MessageBox.Show("작업이 실행중");
            }
            //Begininvoke
            //mySettingDeiegate.Invoke(myString); //동기
            //mySettingDeiegate.BeginInvoke(myString, null,null); //비동기

            //비동기작업이 우선끝나면aa
            //비동기작업이 더늦게 끝났기 때문에 긴aaaaaaaaaa

            //동기작업에서는 aa
            label1.Text = myString;
        }

        private void Complete(IAsyncResult ar)
        {
            //네트워크통신
            //Socket클래스의 객체
            //비동기작업 mySetting
            //Complete("aaaaa")
            string str = (string)ar.AsyncState; //aaaaa 

            //3.번작업
            MessageBox.Show(str);
        }

        private void MySetting(string str)
        {
            //for(int i=0; i < 100; i++)
            //{
            //    str += "aaa";
            //}

            //////다른 쓰레드에서 메소드가 실행됨.

            /////쓰레드가 생성되는 것은 되는 것은 아니다.
            //this.BeginInvoke((Action)(() =>
            //{
            //    label1.Text = str;

            //}));

            //this.Invoke((Action)(() =>
            //{
            //    label1.Text = str;

            //}));

            //오래걸린 함수가 다 끝나면
            Thread.Sleep(5000);
            
            //2. 비동기 작업은 계속 실행
            MessageBox.Show("BBBBBBBB작업진행중");
        }
    }
}
