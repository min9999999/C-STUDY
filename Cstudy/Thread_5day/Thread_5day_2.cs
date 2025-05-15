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

namespace Thread_5day
{
    public partial class Thread_5day_2 : Form
    {
        public Thread_5day_2()
        {
            InitializeComponent();
        }

        Thread th = null;
        bool stop = false;

        private void Thread_5day_2_Load(object sender, EventArgs e)
        {
            //UIThread

            //스레드 자원할당
            th = new Thread(new ThreadStart(methodStart));
            th.IsBackground = true; //UI쓰레드가 종료될 때 자원을 해제.
            //1방법은 isBackground
            th.Start();
        }

        private void methodStart()
        {
            // 프로그램이 실행이되다가..
            // os 상황이 안좋아지면 ..프로그램에 영향을 줌.
            // UI-Thread와의 Thread에서 컨트롤에 접근시 예외


            // 크로스 쓰레드에러 처리완료.
            //this.Invoke((MethodInvoker)delegate
            //{
            //    label1.Text = "aaa";
            //});

            this.Invoke(new Action(() =>
            {
                label1.Text = "aaa";
            }));

            label1.Text = "aaa";
            while (!stop)
            {
                //1초씩 쓰레드가 멈추도록
                Thread.Sleep(1000);
                //MessageBox.Show("aaaa");
            }
        }

        private void threadStop()
        {
            if(th != null)
            {
                th.Abort();
            }
            th = null; 
        }


        private void Thread_5day_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //방법2: 폼이 닫힐 때 쓰레드 자원을 해제
            stop = true; //while문 작업이 멈춘다
            if(th!= null)
            {
                th.Abort();
            }
            th = null;
        }
    }
}
