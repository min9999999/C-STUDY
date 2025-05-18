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

namespace eventCreateAndCall_6day
{
    public partial class Form2 : Form
    {
        //이벤트를 게시.
        public delegate void OnMyFirstHandler(int a);
        public event OnMyFirstHandler MyFirst;

        Thread th = null;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //개발자가 만든 클래스
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(MyTest));
            th.IsBackground = true;
            th.Start();
        }

        private void MyTest()
        {
            MyFirst(5); //이벤트를 발생.
        }
    }
}
