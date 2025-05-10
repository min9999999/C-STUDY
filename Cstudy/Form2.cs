using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multithread_1day
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //thread1 = new Thread(new ThreadStart(WorkThread));
            //thread1.IsBackground = true; //UIThread가 종료될때 해당 쓰레드도 종료.
            //thread1.Priority = ThreadPriority.Normal; //OS(운영체제)자원을 얼마나 자주 사용할 것인지 할당.
            //thread1.Start();

            //thread2 = new Thread(new ThreadStart(Work2));
            //thread2.IsBackground = true; //UIThread가 종료될때 해당 쓰레드도 종료.
            //thread2.Priority = ThreadPriority.Normal; //OS(운영체제)자원을 얼마나 자주 사용할 것인지 할당.
            //thread2.Start();
        }
    }
}
