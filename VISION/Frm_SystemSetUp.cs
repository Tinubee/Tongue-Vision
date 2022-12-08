using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION
{
    public partial class Frm_SystemSetUp : Form
    {
        Frm_Main Main;
        private PGgloble Unit;
        CheckBox[] AllToolUsed;
        CheckBox[] EachCamInspectUsed;
        public Frm_SystemSetUp(Frm_Main main)
        {
            Main = main;
            InitializeComponent();
            Unit = PGgloble.getInstance;
            AllToolUsed = new CheckBox[5] { cb_AllMultiPatternUsed, cb_AllBlobUsed, cb_AllHistogramUsed, cb_AllCircleUsed, cb_AllLineUsed };
            EachCamInspectUsed = new CheckBox[5] { cb_Used, cb_Used2, cb_Used3, cb_Used4, cb_Used5 };
            string[] Parity = { "NONE", "Odd", "Even", "Mark", "Space" };
            string[] Stopbit = { "NONE", "1", "2", "1.5" };
            string[] BaudRate = { "300", "600", "1200", "2400", "9600", "14400", "19200", "28800", "38400", "57600", "115200" };
            string[] Databit = { "5", "6", "7", "8" };
            cb_PortNumber.Items.Add("NONE");
            cb_PortNumber.Items.AddRange(SerialPort.GetPortNames());
            cb_ParityCheck.Items.AddRange(Parity);
            cb_Stopbit.Items.AddRange(Stopbit);
            cb_BaudRate.Items.AddRange(BaudRate);
            cb_Databit.Items.AddRange(Databit);

            num_LightNumber.Value = 0;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ImageRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_ImageSaveRoot.Text = fbd.SelectedPath;
            }
        }

        private void btn_DataRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_DataSaveRoot.Text = fbd.SelectedPath;
            }
        }

        private void Frm_SystemSetUp_Load(object sender, EventArgs e)
        {
            tb_ImageSaveRoot.Text = Unit.ImageSaveRoot;
            tb_DataSaveRoot.Text = Unit.DataSaveRoot;

            cb_PortNumber.SelectedItem = Unit.PortName[Unit.LightControlNumber];
            cb_ParityCheck.SelectedItem = Unit.Parity[Unit.LightControlNumber];
            cb_Stopbit.SelectedItem = Unit.StopBits[Unit.LightControlNumber];
            cb_BaudRate.SelectedItem = Unit.BaudRate[Unit.LightControlNumber];
            cb_Databit.SelectedItem = Unit.DataBit[Unit.LightControlNumber];
            for (int i = 0; i < 5; i++)
            {
                EachCamInspectUsed[i].Checked = Unit.InspectUsed[i];
            }
            cb_OkSave.Checked = Unit.OKImageSave;
            cb_NGSave.Checked = Unit.NGImageSave;
            for (int i = 0; i < AllToolUsed.Count(); i++)
            {
                AllToolUsed[i].Checked = Unit.AllToolInspectUsed[i];
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            INIControl Writer = new INIControl(this.Unit.SETTING);
            Unit.ImageSaveRoot = tb_ImageSaveRoot.Text;
            Unit.DataSaveRoot = tb_DataSaveRoot.Text;

            if (cb_PortNumber.SelectedItem != null)
                Unit.PortName[Unit.LightControlNumber] = cb_PortNumber.SelectedItem.ToString();
            Unit.Parity[Unit.LightControlNumber] = cb_ParityCheck.SelectedItem.ToString();
            Unit.StopBits[Unit.LightControlNumber] = cb_Stopbit.SelectedItem.ToString();
            Unit.BaudRate[Unit.LightControlNumber] = cb_BaudRate.SelectedItem.ToString();
            Unit.DataBit[Unit.LightControlNumber] = cb_Databit.SelectedItem.ToString();
            for (int i = 0; i < 5; i++)
            {
                Unit.InspectUsed[i] = EachCamInspectUsed[i].Checked;
            }
            

            Writer.WriteData("SYSTEM", "Image Save Root", Unit.ImageSaveRoot);
            Writer.WriteData("SYSTEM", "Data Save Root", Unit.DataSaveRoot);

            Writer.WriteData("COMMUNICATION", $"Port number{Unit.LightControlNumber}", Unit.PortName[Unit.LightControlNumber]);
            Writer.WriteData("COMMUNICATION", $"Parity Check{Unit.LightControlNumber}", Unit.Parity[Unit.LightControlNumber]);
            Writer.WriteData("COMMUNICATION", $"Stop bits{Unit.LightControlNumber}", Unit.StopBits[Unit.LightControlNumber]);
            Writer.WriteData("COMMUNICATION", $"Data Bits{Unit.LightControlNumber}", Unit.DataBit[Unit.LightControlNumber]);
            Writer.WriteData("COMMUNICATION", $"Baud Rate{Unit.LightControlNumber}", Unit.BaudRate[Unit.LightControlNumber]);
            for (int i = 0; i < 5; i++)
            {
                if (Unit.InspectUsed[i])
                {
                    Writer.WriteData("SYSTEM", $"CAM{i+1} Inspect Used Check", "1");
                }
                else
                {
                    Writer.WriteData("SYSTEM", $"CAM{i+1} Inspect Used Check", "0");
                }
            }
         
            if (cb_OkSave.Checked)
            {
                Writer.WriteData("SYSTEM", "OK IMAGE SAVE", "1");
            }
            else
            {
                Writer.WriteData("SYSTEM", "OK IMAGE SAVE", "0");
            }
            if (cb_NGSave.Checked)
            {
                Writer.WriteData("SYSTEM", "NG IMAGE SAVE", "1");
            }
            else
            {
                Writer.WriteData("SYSTEM", "NG IMAGE SAVE", "0");
            }
            for (int i = 0; i < AllToolUsed.Count(); i++)
            {
                if (AllToolUsed[i].Checked)
                {
                    Writer.WriteData("SYSTEM", $"검사툴 {AllToolUsed[i].Tag}", "1");
                }
                else
                {
                    Writer.WriteData("SYSTEM", $"검사툴 {AllToolUsed[i].Tag}", "0");
                }
            }

            MessageBox.Show("저장 완료", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_Used_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Used.Checked == true)
            {
                cb_Used.Text = "Used";
                cb_Used.BackColor = Color.Lime;
            }
            else
            {
                cb_Used.Text = "Not Used";
                cb_Used.BackColor = Color.Red;
            }
        }

        private void cb_OkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_OkSave.Checked == true)
            {
                Unit.OKImageSave = true;
                cb_OkSave.Text = "Save";
                cb_OkSave.BackColor = Color.Lime;
            }
            else
            {
                Unit.OKImageSave = false;
                cb_OkSave.Text = "UnSave";
                cb_OkSave.BackColor = Color.Red;
            }
        }

        private void cb_NGSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_NGSave.Checked == true)
            {
                Unit.NGImageSave = true;
                cb_NGSave.Text = "Save";
                cb_NGSave.BackColor = Color.Lime;
            }
            else
            {
                Unit.NGImageSave = false;
                cb_NGSave.Text = "UnSave";
                cb_NGSave.BackColor = Color.Red;
            }
        }

        private void num_LightNumber_ValueChanged(object sender, EventArgs e)
        {
            Unit.LightControlNumber = (int)num_LightNumber.Value;
            LightControlChange(Unit.LightControlNumber);
        }

        public void LightControlChange(int LightNumber)
        {
            cb_PortNumber.SelectedItem = Unit.PortName[Unit.LightControlNumber];
            cb_ParityCheck.SelectedItem = Unit.Parity[Unit.LightControlNumber];
            cb_Stopbit.SelectedItem = Unit.StopBits[Unit.LightControlNumber];
            cb_BaudRate.SelectedItem = Unit.BaudRate[Unit.LightControlNumber];
            cb_Databit.SelectedItem = Unit.DataBit[Unit.LightControlNumber];
        }

        private void cb_AllMultiPatternUsed_CheckedChanged(object sender, EventArgs e)
        {
            /*
             *  0 : 다중 학습 툴
             *  1 : 블롭 툴
             *  2 : 히스토그램 툴
             *  3 : 써클 툴
             *  4 : 라인 툴
             */
            int jobNo = Convert.ToInt16((sender as CheckBox).Tag);
            
            if (AllToolUsed[jobNo].Checked == true)
            {
                Unit.AllToolInspectUsed[jobNo] = true;
                AllToolUsed[jobNo].Text = "사용";
                AllToolUsed[jobNo].BackColor = Color.Lime;
            }
            else
            {
                Unit.AllToolInspectUsed[jobNo] = false;
                AllToolUsed[jobNo].Text = "미사용";
                AllToolUsed[jobNo].BackColor = Color.Red;
            }
        }

        private void cb_Used2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Used2.Checked == true)
            {
                cb_Used2.Text = "Used";
                cb_Used2.BackColor = Color.Lime;
            }
            else
            {
                cb_Used2.Text = "Not Used";
                cb_Used2.BackColor = Color.Red;
            }
        }

        private void cb_Used3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Used3.Checked == true)
            {
                cb_Used3.Text = "Used";
                cb_Used3.BackColor = Color.Lime;
            }
            else
            {
                cb_Used3.Text = "Not Used";
                cb_Used3.BackColor = Color.Red;
            }
        }

        private void cb_Used4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Used4.Checked == true)
            {
                cb_Used4.Text = "Used";
                cb_Used4.BackColor = Color.Lime;
            }
            else
            {
                cb_Used4.Text = "Not Used";
                cb_Used4.BackColor = Color.Red;
            }
        }

        private void cb_Used5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Used5.Checked == true)
            {
                cb_Used5.Text = "Used";
                cb_Used5.BackColor = Color.Lime;
            }
            else
            {
                cb_Used5.Text = "Not Used";
                cb_Used5.BackColor = Color.Red;
            }
        }
    }
}
