using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multithread_1day
{
    public partial class Form1 : Form
    {
        int a = 5;
        object lockObj = new object();

        AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        
        public Thread thread1 = null;
        public Thread thread2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(WorkThread));
            thread1.IsBackground = true; //UIThread가 종료될때 해당 쓰레드도 종료.
            thread1.Priority = ThreadPriority.Normal; //OS(운영체제)자원을 얼마나 자주 사용할 것인지 할당.
            thread1.Start();

            thread2 = new Thread(new ThreadStart(Work2));
            thread2.IsBackground = true; //UIThread가 종료될때 해당 쓰레드도 종료.
            thread2.Priority = ThreadPriority.Normal; //OS(운영체제)자원을 얼마나 자주 사용할 것인지 할당.
            thread2.Start();

            // 1day: mulithread
            //Form2 form2 = new Form2();
            //form2.Show(); //form2에서 어떠한 작업을 개별적으로 실행.

            //Thread.Sleep(5000); //UIThread가 멈추면...
            //form2가 개별쓰레드로 동작.
        }

        /// <summary>
        /// thread가 사용할 함수
        /// </summary>
        private void WorkThread()
        {
            while (true) // 반복문
            {
                //1번째로 신호를 받기 위해서 기다리는 상태.
                autoResetEvent.WaitOne(); //신호를 받을 때 까지 대기하게 됩니다.

                //다음작업을 하기를 원하면
                MessageBox.Show("" + a);


                ////lockObj 상호배제 잠금. (1번)
                //lock (lockObj)
                //{
                //    //코드실행. (2번)
                //    Thread.Sleep(2000);
                //    //Thread1에서
                //    a = 3;
                //}
                ////상호배제 잠금해제(4번)

            }


            // 1day: mulithread
            //try
            //{
            //    //여기가 실행.
            //    Thread.Sleep(2000); //2초동안 해당 쓰레드가 일시중지;
            //                        //MessageBox.Show("BBB테스트"); //별개로 동작 2초후에 //메세지
            //                        //병렬작업
            //                        //오래걸리는 작업.
            //                        //네트워크 전송, 수신, DB작업.
            //}
            //catch (Exception ex)
            //{
            //    //오류내용을 Txt..기록.
            //}

        }

        private void Work2()
        {
            while (true) // 반복문
            {

                a++;
                Thread.Sleep(5000);
                autoResetEvent.Set(); //신호를 보내

                ////Thread2에서
                ////lockObj 상호배제 잠금요청. 대기..(3번)
                //lock (lockObj)
                //{
                //    //코드실행(5번)
                //    a = 4;
                //    Thread.Sleep(3000);

                //    MessageBox.Show("" + a); //4값이 출력될것으로 기대..
                //    //파일 읽고쓰기, 네트워크 전송, 수신, DB작업 등등..
                //}
                ////상호배제 잠금해제(6번)

            }


            // 1day: mulithread
            //try
            //{
            //    //반복적인 작업.
            //    while (true)
            //    {
            //        try
            //        {

            //        }
            //        catch (Exception ex)
            //        {
            //            throw;
            //        }
            //    }
            //    //로딩창, 로딩바를 호출해서
            //    //여기가 실행.
            //    Thread.Sleep(5000); //5초동안 해당 쓰레드가 일시중지;
            //    MessageBox.Show("AAA테스트"); //별개로 동작 2초후에
            //}
            //catch (Exception ex)
            //{

            //}
        }   

        //실행될때의 시작속도를 확인해보자.

    }
}
