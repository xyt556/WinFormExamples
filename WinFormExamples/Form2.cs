using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormExamples
{
    public partial class Form2 : Form
    {
        private string _text;
        public string TextBoxVal
        {
            get { return _text; }
            set { _text = value; }
        }


        public Form2()
        {
            InitializeComponent();

            textBox1.Text = "";            
            this.AcceptButton = button1;//将button1设置为窗体的AcceptButton，则可响应回车键
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(string.Empty))
            {
                _text = textBox1.Text;
            }
        }

    }
}
