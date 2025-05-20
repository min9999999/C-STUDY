using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Timer_7day
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //코드 주기적으로 실행 .3초
            //UI Thread동작.

            //label1.Text = "aaaa";
            ////간단한 작업은 System.Windows.Forms.Timer 사용하기!!

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer = new System.Timers.Timer(3000);
            //timer.Elapsed += OnTime;
            //timer.Enabled = true;   // 실행여부
            //timer.AutoReset = true;  // 반복인지 1번실행인지 여부

            int a = 5;
            System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(TimerWork), a, 1000, 5000); //처음실행은 1초, 반복주기 5초
            //UI-Thread
            //화면가 분리되서 오래걸리는 작업을 처리하는데 사용.
            //DB작업, 파일, 읽기쓰기, 네트워크통신, 전자전기 통신, 주기적인 계산작업등등...
        }

        private void TimerWork(object state)
        {
            //try catch를 사용하면 싱행됨
            //try
            //{
            //    int a = 0;
            //    int c = 1 / a;
            //}
            //catch (Exception ex)
            //{

            //}

            //int a = 0;
            //int c = 1 / a; //1을 0으로 나누면 -> 예외 


            //a값을 얻을 수 있다.
            //int c = (int)state;
            //MessageBox.Show(c + "");
        }

        private void OnTime(object sender, ElapsedEventArgs e) 
        {
            //3초
            //label1
            //UI-Thread
            //화면가 분리되서 오래걸리는 작업을 처리하는데 사용.
            //DB작업, 파일, 읽기쓰기, 네트워크통신, 전자전기 통신, 주기적인 계산작업등등...

        }
    }
}
