using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eventCreateAndCall_6day
{
    public partial class Form1 : Form
    {
        //폼 2 이벤트를 수신
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MyFirst += Sum;
            form2.Show();
        }

        private void Sum(int aaaa)
        {
            //다른 쓰레드에서 발생시킨 event일경우도 this.BeginInvoke 크로스 쓰레드 에러 처리.
            this.BeginInvoke(new Action(() =>
            {
                label1.Text = "" + aaaa;
            }));
        }

    }
}
