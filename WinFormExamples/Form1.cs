using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WinFormExamples
{
    public partial class Form1 : Form
    {
        #region 窗体构造函数
        public Form1()
        {
            InitializeComponent();
        }
        
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("FormLoad", "That's OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //float a = 2, b = 1, s = 0;
            //for (int i = 1; i <= 5; i++)
            //{
            //    s += a / b;
            //    int t = (int)(a + b);
            //    b = a;
            //    a = t;
            //}


            //MessageBox.Show(((int)s).ToString());


            #region Button示例

            this.nCounter = 50;
            this.ShowCounter();
 
            #endregion

            #region TextBox

		    tbInput.ForeColor = Color.Blue;//需添加System.Drawing命名空间;
            tbHint.BackColor = Color.White;
            tbHint.ForeColor = Color.Green;
            tbHint.ReadOnly = true; 

	        #endregion

            #region RadioButton

            rbAl2O3.Checked = true;

            #endregion

            #region CheckBox
            checkBox1.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            checkBox2.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            checkBox3.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            #endregion

            #region ComboBox

            cboMajor.SelectedIndex = 0;

            #endregion

            #region Panel & GroupBox
		    
            cboCourse1.SelectedIndex = 0;
 
	        #endregion
        }


        #region Button示例
        private int nCounter;

        private void btnInc_Click(object sender, EventArgs e)
        {
            this.nCounter++;
            this.ShowCounter();
        }

        private void btnDes_Click(object sender, EventArgs e)
        {
            this.nCounter--;
            this.ShowCounter();
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {
            string strMsg = "当前计数器=" + this.nCounter.ToString("D8");
            MessageBox.Show(strMsg, "提示");
            
        }
        private void ShowCounter()
        {
            string strMsg = this.nCounter.ToString("D8");
            this.lblResult.Text = strMsg;
        }
        
        #endregion

        #region Label示例
        private void lblClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lblClick.Text);
        }

        private void lblDbClick_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(lblDbClick.Text);
        }
        
        #endregion

        #region TextBox

        private void btnClrText_Click(object sender, EventArgs e)
        {
            textBox7.Clear();//Clear方法
        }

        private void btnApdText_Click(object sender, EventArgs e)
        {
            textBox7.AppendText("_NewText");//AppendText方法
        }

        private void tbInput_Enter(object sender, EventArgs e)
        {
            //光标进入清除原有文本
            tbInput.Clear();            
        }

        private void tbInput_Leave(object sender, EventArgs e)
        {
            //焦点退出，将文本添加到tbHint新的一行
            tbHint.AppendText(this.tbInput.Text + Environment.NewLine);
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            //将当前tbInput中文本内容同步显示到lblCopy中
            lblCopy.Text = this.tbInput.Text;
        }
        #endregion

        #region RadioButton
        private void rbSiO2_CheckedChanged(object sender, EventArgs e)
        {
            lblHardness.Text = rbSiO2.Text + "的硬度为：";
            tbHardness.Text = "7";
        }

        private void rbAl2O3_CheckedChanged(object sender, EventArgs e)
        {
            lblHardness.Text = rbAl2O3.Text + "的硬度为：";
            tbHardness.Text = "9";
        }

        private void rbCaCO3_CheckedChanged(object sender, EventArgs e)
        {
            lblHardness.Text = rbCaCO3.Text + "的硬度为：";
            tbHardness.Text = "3";
        }

        private void rbBaSO4_CheckedChanged(object sender, EventArgs e)
        {
            lblHardness.Text = rbSiO2.Text + "的硬度为：";
            tbHardness.Text = "3.5";
        }
        #endregion

        #region CheckBox
        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //检查用户输入的信息是否有效
            if (txtMineralName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("矿物名称为空，请重新输入!");
                txtMineralName.Focus();
            }
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            str = "矿物名称：" + txtMineralName.Text + "\n";
            str += "物理性质：" +
                (cbTransperancy.Checked ? "透明度" : "") +
                (cbLuster.Checked ? "光泽" : "") +
                (cbColor.Checked ? "颜色" : "") + "\n";
            lblMineral.Text = str;
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb != null)
            {
                if (cb.Equals(checkBox3) && cb.CheckState == CheckState.Checked)
                {
                    cb.CheckState = CheckState.Indeterminate;
                }

                label21.Text = "点击对象：" + cb.Text;
                label22.Text = "Checked: " + cb.Checked.ToString();
                label23.Text = "CheckState: " + cb.CheckState.ToString();                
            }
        }

        #endregion

        #region ListBox
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strCourse="";
            Form2 frmInput = new Form2();
            frmInput.Text = "请输入课程名";
            if (frmInput.ShowDialog()==DialogResult.OK)
            {
                strCourse = frmInput.TextBoxVal;//通过Form2的TextBoxVal属性获取输入文本
            }            
            
            if (strCourse != null && strCourse != string.Empty)
                listBox1.Items.Add(strCourse);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string strCourse = "";
                Form2 frmInput = new Form2();
                frmInput.Text = "请输入课程名";
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    strCourse = frmInput.TextBoxVal;//通过Form2的TextBoxVal属性获取输入文本
                }
                if (strCourse != null && strCourse != string.Empty)
                    listBox1.Items.Insert(listBox1.SelectedIndex, strCourse);

            }
            else
            {
                MessageBox.Show("请选中一项作为插入位置！", "提示");
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                lstRight.Items.Add(lstLeft.SelectedItem);
                lstLeft.Items.Remove(lstLeft.SelectedItem);
            }
        }

        private void btnRightAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstLeft.Items)
            {
                lstRight.Items.Add(item);
            }
            lstLeft.Items.Clear();
        }

        private void btnLeftAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstRight.Items)
            {
                lstLeft.Items.Add(item);
            }
            lstRight.Items.Clear();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                lstLeft.Items.Add(lstRight.SelectedItem);
                lstRight.Items.Remove(lstRight.SelectedItem);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstRight.Items.Clear();
        }
        #endregion

        #region ComboBox
        private void cboMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboMajor.SelectedIndex)
            {
                case 0:
                    cboCourse.Items.Clear();
                    cboCourse.Items.Add("地学程序设计");
                    cboCourse.Items.Add("普通地质学");
                    cboCourse.Items.Add("构造地质学");
                    cboCourse.Items.Add("能源地质学");
                    cboCourse.SelectedIndex = 0;
                    break;
                case 1:
                    cboCourse.Items.Clear();
                    cboCourse.Items.Add("瞬变电磁法概论");
                    cboCourse.Items.Add("电法勘探原理");
                    cboCourse.SelectedIndex = 0;
                    break;
                case 2:
                    cboCourse.Items.Clear();
                    cboCourse.Items.Add("专门水文地质学");
                    cboCourse.Items.Add("普通地质学");
                    cboCourse.SelectedIndex = 0;
                    break;
            }
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtComboBox.Text = "专业：" + cboMajor.SelectedItem.ToString() +
                "，课程：" + cboCourse.SelectedItem.ToString();
        }
        
        #endregion

        #region Panel & GroupBox
        private void btnPanelGroupBox_Click(object sender, EventArgs e)
        {
            textBox11.Text = cboCourse1.SelectedItem.ToString() + "\n" +
                (radioButton5.Checked ? radioButton5.Text : radioButton6.Text);

            //MessageBox.Show(
                //"Info",
                //"duang", 
                //MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
            //MessageBox.Show("Info", "duang", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        
        #endregion

        #region Dialog
        private void btnShowMsgBox_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("这是一个消息框", "消息框标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            MessageBox.Show("hell0", "this", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
            MessageBox.Show( "Hello","How are you!");
            //MessageBox.Show("Hello", "World", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FontDialog fdg = new FontDialog();
            fdg.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ColorDialog cdg = new ColorDialog();
            cdg.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdg = new OpenFileDialog();
            if (ofdg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdg = new SaveFileDialog();
            sfdg.ShowDialog();
        }
        
        #endregion

        #region 菜单工具栏状态栏
        private void munuItemQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemOpenPic_Click(object sender, EventArgs e)
        {
            OpenPic();
        }

        private void tbtnOpen_Click(object sender, EventArgs e)
        {
            OpenPic();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(new Point(Convert.ToInt32(Cursor.Position.X), Convert.ToInt32(Cursor.Position.Y)));
            }
        }


        private void OpenPic()
        {
            OpenFileDialog ofdg = new OpenFileDialog();
            ofdg.Filter = "GIF图片|*.gif|PNG图片|*.png|JPG图片|*.jpg|全部文件|*.*";
            ofdg.InitialDirectory = Directory.GetCurrentDirectory();
            if (ofdg.ShowDialog() == DialogResult.OK && File.Exists(ofdg.FileName))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(ofdg.FileName);
                pictureBox1.Refresh();
                toolStripStatusLabel1.Text = ofdg.FileName;
            }
        }

        #endregion

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public interface IA
    {

    }
    public interface IB
    {
    }

    class C:IA,IB
    {

    }
    struct S:IA,IB
    {

    }


}
