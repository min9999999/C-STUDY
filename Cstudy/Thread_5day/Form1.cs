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
    public partial class Form1 : Form
    {
        Thread th = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Thread_5day_2 thread_5day_2 = new Thread_5day_2();
            thread_5day_2.Show();
        }
        ///빌드로 새로운 파일 생성.
        ///

    }
}
