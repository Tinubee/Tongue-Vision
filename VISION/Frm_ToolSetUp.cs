using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using System.Threading;
using System.Diagnostics;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.ImageProcessing;
using System.Reflection;

namespace VISION
{
    public partial class Frm_ToolSetUp : Form
    {
        private Class_Common cm { get { return Program.cm; } }

        //INIControl setting = new INIControl(PGgloble.getInstance.SETTING);
        internal MultiPatternResult frm_MultiPatternResult; //다중패턴툴 전체결과
        private Frm_Main Main; //메인화면
        private PGgloble Glob; //글로벌함수
        double[] gainvalue; //카메라 GAIN 값
        double[] exposurevalue; //카메라 EXPOSURE값

        private CogImage24PlanarColor Oriimage = new CogImage24PlanarColor(); //셋업창에서 쓸 컬러이미지
        private CogImage8Grey Monoimage = new CogImage8Grey(); //셋업창에서 쓸 모노이미지
        private CogImage8Grey Fiximage; //픽스쳐이미지(보정이미지)
        private string FimageSpace; //보정범위

        private Cogs.Model TempModel; //모델
        private Cogs.Blob[,] TempBlobs; //블롭툴
        private Cogs.Line[,] TempLines; //라인툴
        private Cogs.Circle[,] TempCircles; //써클툴
        private Cogs.MultiPMAlign[,] TempMulti; //다중패턴툴
        private Cogs.Hisogram[,] TempHistogram; //명암차 확인

        private bool[,] TempBlobEnable; //블롭툴 사용여부
        private bool[,] TempLineEnable; //라인툴 사용여부
        private bool[,] TempCircleEnable; //써클툴 사용여부
        private bool[,] TempMultiEnable; //다중패턴툴 사용여부
        private bool[,] TempHistogramEnable; //히스토그램툴 사용여부

        private int[,] TempBlobOKCount; //블롭툴 OK 되는 카운트
        private int[,] TempBlobFixPatternNumber;

        private bool Dataset = false;
        public bool liveflag = false;
        bool FormLoad = false;
        bool ImageDelete = false;
        int SelectNumber;
        //int ImagePathNumber;

        public Frm_ToolSetUp(Frm_Main main)
        {
            InitializeComponent();
            btn_Livestop.Enabled = false;
            Dataset = true;
            Main = main;
            Glob = PGgloble.getInstance;
            Glob.CamNumber = 0;
            TempModel = Glob.RunnModel;
            TempBlobs = TempModel.Blob();
            TempBlobEnable = TempModel.BlobEnables();
            TempBlobOKCount = TempModel.BlobOKCounts();
            TempBlobFixPatternNumber = TempModel.BlobFixPatternNumbers();
            TempLines = TempModel.Line();
            TempLineEnable = TempModel.LineEnables();
            TempCircles = TempModel.Circle();
            TempCircleEnable = TempModel.CircleEnables();
            TempMulti = TempModel.MultiPatterns();
            TempMultiEnable = TempModel.MultiPatternEnables();
            TempHistogram = TempModel.Histograms();
            TempHistogramEnable = TempModel.HistogramEnables();

            string[] Polarty = { "White to Black", "Black to  White", "Don't Care" };
            string[] Blob = { "White Blob", "Black Blob" };
            string[] Direction = { "Inward", "Outward" };
            string[] AreaShape = { "CogCircle", "CogEllipse", "CogRectangleAffine", "CogCircularAnnulusSection" };
            
            cb_BlobPolarty.Items.AddRange(Blob);
            cb_LinePolarty.Items.AddRange(Polarty);
            cb_LineDirection.Items.AddRange(Direction);
            for (int i = 0; i < 30; i++)
            {
                cb_MultiPatternName.Items.Add(TempMulti[Glob.CamNumber, i].ToolName());
            }
            //cb_MultiPatternName.Items.AddRange(TempMulti[0, 1].ToolName());

            num_BlobToolNumber.Value = 0;
            num_LineToolNum.Value = 1;
            num_CircleToolNumber.Value = 1;
            num_MultiPatternToolNumber.Value = 0;
            num_HistogramToolNumber.Value = 0;

            ChangeBlobToolNumber();
            LineChangeToolNumber();
            CircleChangeToolNumber();
            ChangeMultiPatternToolNumber();
            ChangeHistogramToolNumber();

            Dataset = false;
        }

        private void Frm_ToolSetUp_Load(object sender, EventArgs e)
        {
            FormLoad = true;
            //Glob.CamNumber = 0;
            LoadSetup(); //셋팅 불러오기.
            //CameraSet(); //카메라 Exposure 및 Gain Set Up - 20201215 김형민 ( Main 쪽 Load 할때도 적용 해야되는지 확인하기.)
            UpdateCamStats(); //카메라 상태 변경
            dgv_ToolSetUp.DoubleBuffered(true);
            DGVUpadte(); //데이터그리드뷰 설정.
            timer1.Start();
        }

        private void DGVUpadte()
        {
            dgv_ToolSetUp.Rows.Clear();
            for (int i = 0; i < 30; i++)
            {
                /*패턴툴이름 & 블롭툴 이름*/
                dgv_ToolSetUp.Rows.Add(Glob.RunnModel.MultiPatterns()[Glob.CamNumber, i].ToolName());
                dgv_ToolSetUp.Rows[i].Cells[2].Value = Glob.RunnModel.Blob()[Glob.CamNumber, i].ToolName();
            }
        }
        private void LoadSetup()
        {
            try
            {
                /*카메라 및 조명값 저장되어있는 ini파일 경로.*/
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");

                /*카메라 및 조명값 불러와 셋업창에 표시.*/
                num_Exposure.Value = Convert.ToDecimal(CamSet.ReadData($"Camera{Glob.CamNumber}", "Exposure"));
                num_Gain.Value = Convert.ToDecimal(CamSet.ReadData($"Camera{Glob.CamNumber}", "Gain"));
                num_LightCH1.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl{Glob.LightControlNumber}", "CH1"));
                Thread.Sleep(50);
                num_LightCH2.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl{Glob.LightControlNumber}", "CH2"));
                Thread.Sleep(50);
                num_LightCH3.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl{Glob.LightControlNumber}", "CH3"));
                Thread.Sleep(50);
                num_LightCH4.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl{Glob.LightControlNumber}", "CH4"));

                for (int i = 0; i < Main.AllCams.Count; i++)
                {
                    Glob.CameraOption[i].Exposure = Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"));
                    Glob.CameraOption[i].Gain = Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Gain"));
                    //gainvalue[i] = Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"));
                    //exposurevalue[i] = Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Gain"));
                }
                FormLoad = false;
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        private void btn_ImageOpen_Click(object sender, EventArgs e)
        {
            /* 2020-02-17 김형민
             * ColorImage & MonoImage 들어오는거 확인해야됨 -> type 으로 확인하는 부분 변경해야될수도
             */
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ImageDelete = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Glob.ImageFilePath = ofd.FileName;
                string type = Path.GetExtension(ofd.FileName);
                string[] ImageFileName = ofd.FileNames;
                if (type == ".jpg")
                {
                    CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    //Oriimage = (CogImage24PlanarColor)Imageopen2[0];
                    Imageopen2.Close();
                    //CogImageFileBMP Imageopen = new CogImageFileBMP();
                    //Imageopen.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    //Imageopen.Close();
                }
                else
                {
                    CogImageFileBMP Imageopen2 = new CogImageFileBMP();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    Monoimage = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                for (int i = 0; i < ImageFileName.Count(); i++)
                {
                    ImageList.Items.Add(ImageFileName[i]);
                }
                ImageList.SelectedIndex = ImageList.Items.Count - 1;
                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("셋팅창을 종료 하시겠습니까?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            try
            {
                for (int i = 0; i < Main.AllCams.Count; i++)
                {
                    Glob.RunnModel.Loadmodel(Glob.RunnModel.Modelname(), Glob.MODELROOT, i);
                }

                if (Main.frm_toolsetup != null)
                {
                    Main.frm_toolsetup = null;
                }
                //Main.LightOFF();
                GC.Collect();
                Dispose();
                Close();
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
                //Main.LightOFF();
                GC.Collect();
                Dispose();
                Close();
            }
        }

        private void BlobEnableChange(int toolnumber)
        {
            cb_BlobToolUsed.Text = cb_BlobToolUsed.Checked == true ? "USE" : "UNUSED";
            cb_BlobToolUsed.ForeColor = cb_BlobToolUsed.Checked == true ? Color.Lime : Color.Red;
        }

        public void Pattern_Train()
        {
            if (TempMulti[Glob.CamNumber, 0].Run((CogImage8Grey)cdyDisplay.Image) == true)
            {
                Fiximage = TempModel.FixtureImage((CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, 0].ResultPoint(TempMulti[Glob.CamNumber, 0].HighestResultToolNumber()), TempMulti[Glob.CamNumber, 0].ToolName(), Glob.CamNumber, out FimageSpace, TempMulti[Glob.CamNumber, 0].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train(int toolnumber)
        {
            if (TempMulti[Glob.CamNumber, toolnumber].Run((CogImage8Grey)cdyDisplay.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage((CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, toolnumber].ResultPoint(TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber()), TempMulti[Glob.CamNumber, toolnumber].ToolName(), Glob.CamNumber, toolnumber, out FimageSpace, TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Line_Train(int toolnumber)
        {
            if (TempMulti[Glob.CamNumber, toolnumber].Run((CogImage8Grey)cdyDisplay.Image) == true)
            {
                Fiximage = TempModel.LINE_FixtureImage((CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, toolnumber].ResultPoint(TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber()), TempMulti[Glob.CamNumber, toolnumber].ToolName(), Glob.CamNumber, toolnumber, out FimageSpace, TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }

        private void ImageClear()
        {
            cdyDisplay.StaticGraphics.Clear();
            cdyDisplay.InteractiveGraphics.Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
            INIControl CalibrationValue = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CalibrationValue.ini");
            if (MessageBox.Show("셋팅값을 저장 하시겠습니까?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            Process.Start($"{Glob.SAVEFROM}");
            Glob.RunnModel.Line(TempLines); //라인툴저장
            Glob.RunnModel.LineEnables(TempLineEnable); //라인툴사용여부
            Glob.RunnModel.Blob(TempBlobs); //블롭툴저장
            Glob.RunnModel.BlobEnables(TempBlobEnable); //블롭툴사용여부
            Glob.RunnModel.BlobOKCounts(TempBlobOKCount); //블롭카운트
            Glob.RunnModel.BlobFixPatternNumbers(TempBlobFixPatternNumber);
            Glob.RunnModel.MultiPatterns(TempMulti); // 멀티패턴툴저장
            Glob.RunnModel.MultiPatternEnables(TempMultiEnable); // 멀티패턴툴사용여부저장
            Glob.RunnModel.Histograms(TempHistogram);
            Glob.RunnModel.HistogramEnables(TempHistogramEnable);

            Glob.RunnModel.SaveModel(Glob.MODELROOT + "\\" + Glob.RunnModel.Modelname() + "\\" + $"Cam{Glob.CamNumber}", Glob.CamNumber); //모델명
            Glob.LightCH[Glob.LightControlNumber, 0] = (int)num_LightCH1.Value; //채널1 조명값
            Glob.LightCH[Glob.LightControlNumber, 1] = (int)num_LightCH2.Value; //채널1 조명값
            Glob.LightCH[Glob.LightControlNumber, 2] = (int)num_LightCH3.Value; //채널1 조명값
            Glob.LightCH[Glob.LightControlNumber, 3] = (int)num_LightCH4.Value; //채널1 조명값
            CamSet.WriteData($"Camera{Glob.CamNumber}", "Exposure", num_Exposure.Value.ToString()); //카메라 노출값
            CamSet.WriteData($"Camera{Glob.CamNumber}", "Gain", num_Gain.Value.ToString()); //카메라 Gain값
            CamSet.WriteData($"LightControl{Glob.LightControlNumber}", "CH1", Glob.LightCH[Glob.LightControlNumber, 0].ToString()); //카메라별 조명값 1
            CamSet.WriteData($"LightControl{Glob.LightControlNumber}", "CH2", Glob.LightCH[Glob.LightControlNumber, 1].ToString()); //카메라별 조명값 2
            CamSet.WriteData($"LightControl{Glob.LightControlNumber}", "CH3", Glob.LightCH[Glob.LightControlNumber, 2].ToString()); //카메라별 조명값 3
            CamSet.WriteData($"LightControl{Glob.LightControlNumber}", "CH4", Glob.LightCH[Glob.LightControlNumber, 3].ToString()); //카메라별 조명값 4
            Process[] myProcesses = Process.GetProcessesByName("SaveForm_KHM");
            if (myProcesses.LongLength > 0)
            {
                myProcesses[0].Kill();
            }
            MessageBox.Show("저장 완료", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeBlobToolNumber()
        {
            Dataset = true;
            int Toolnumber = (int)num_BlobToolNumber.Value;

            cb_BlobPolarty.SelectedIndex = TempBlobs[Glob.CamNumber, Toolnumber].Polarity();
            cb_MultiPatternName.SelectedIndex = TempBlobs[Glob.CamNumber, Toolnumber].SpaceName();
            num_BlobMinipixel.Value = TempBlobs[Glob.CamNumber, Toolnumber].Minipixel();
            num_BlobThreshold.Value = TempBlobs[Glob.CamNumber, Toolnumber].Threshold();
            num_AreaPoinrNumber.Value = TempBlobs[Glob.CamNumber, Toolnumber].PointNumber();
            num_BlobMaxCout.Value = TempBlobOKCount[Glob.CamNumber, Toolnumber];

            cb_BlobToolUsed.Checked = TempBlobEnable[Glob.CamNumber, Toolnumber];
            BlobEnableChange(Toolnumber);
            Dataset = false;
        }
        private void btn_ToolRun_Click(object sender, EventArgs e)
        {
            if (cdyDisplay.Image == null)
                return;
            INIControl setting = new INIControl(Glob.SETTING);
            ImageClear();
            Pattern_Train();
            switch (Glob.CamNumber) //CAM 별 INSPECT 함수 나눠놈 - 20200205 김형민.
            {
                case 0:
                    lb_Tool_InspectResult.Text = Main.Inspect_Cam0(cdyDisplay) ? "O K" : "N G";
                    lb_Tool_InspectResult.BackColor = lb_Tool_InspectResult.Text == "O K" ? Color.Lime : Color.Red;
                    break;
                case 1:
                    lb_Tool_InspectResult.Text = Main.Inspect_Cam1(cdyDisplay) ? "O K" : "N G";
                    lb_Tool_InspectResult.BackColor = lb_Tool_InspectResult.Text == "O K" ? Color.Lime : Color.Red;
                    break;
                case 2:
                    lb_Tool_InspectResult.Text = Main.Inspect_Cam2(cdyDisplay) ? "O K" : "N G";
                    lb_Tool_InspectResult.BackColor = lb_Tool_InspectResult.Text == "O K" ? Color.Lime : Color.Red;
                    break;
                case 3:
                    lb_Tool_InspectResult.Text = Main.Inspect_Cam3(cdyDisplay) ? "O K" : "N G";
                    lb_Tool_InspectResult.BackColor = lb_Tool_InspectResult.Text == "O K" ? Color.Lime : Color.Red;
                    break;
                case 4:
                    if (Glob.AligneMode)
                    {
                        double angle = Main.CheckAngle(cdyDisplay);
                        angle = angle * (180 / Math.PI);
                        lb_Tool_InspectResult.Text = angle.ToString("F2") + "도";
                        lb_Tool_InspectResult.BackColor = Color.Black;
                    }
                    else
                    {
                        lb_Tool_InspectResult.Text = Main.Inspect_Cam4(cdyDisplay) ? "O K" : "N G";
                        lb_Tool_InspectResult.BackColor = lb_Tool_InspectResult.Text == "O K" ? Color.Lime : Color.Red;
                    }
                    break;
            }
            Invoke(new Action(delegate ()
            {
                Main.DgvResult(dgv_ToolSetUp, Glob.CamNumber, 1); //-추가된함수
            }));
        }

        private void btn_OneShot_Click(object sender, EventArgs e)
        {
            try
            {
                cdyDisplay.Image = null;
                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();
                Main.SnapShot(Glob.CamNumber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        private void btn_Live_Click(object sender, EventArgs e)
        {
            try
            {
                if (liveflag == false)
                {
                    cdyDisplay.InteractiveGraphics.Clear();
                    cdyDisplay.StaticGraphics.Clear();
                    cdyDisplay.Fit();
                    Main.StartLive(Glob.CamNumber);

                    liveflag = true;
                    btn_OneShot.Enabled = false;
                    btn_Live.Enabled = false;
                    num_Exposure.Enabled = true;
                    num_Gain.Enabled = true;
                    btn_Livestop.Enabled = true;
                    btn_Exit.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
                return;
            }
        }

        private void num_Exposure_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (num_Exposure.Enabled == true)
                {
                    Main.ExposureSet(Glob.CamNumber, Convert.ToDouble(num_Exposure.Value));
                }
            }
            catch (Exception ee)
            {
                cm.info($"{MethodBase.GetCurrentMethod().Name} : {ee.Message}");
            }
        }

        private void btn_Livestop_Click(object sender, EventArgs e)
        {
            try
            {
                liveflag = false;
                cdyDisplay.StaticGraphics.Clear();
                cdyDisplay.InteractiveGraphics.Clear();
                btn_OneShot.Enabled = true;
                btn_Live.Enabled = true;
                num_Exposure.Enabled = false;
                num_Gain.Enabled = false;
                btn_Exit.Enabled = true;
                Main.StopLive(Glob.CamNumber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        private void num_Gain_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_ImageSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CogImageFileBMP ImageSave = new CogImageFileBMP();
                ImageSave.Open(sfd.FileName + ".bmp", CogImageFileModeConstants.Write);
                ImageSave.Append(cdyDisplay.Image);
                ImageSave.Close();
            }
        }

        private void num_LightCH1_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightCH[Glob.LightControlNumber, 0] = (int)num_LightCH1.Value;
            if (Main.LightControl[Glob.LightControlNumber].IsOpen == false)
            {
                return;
            }
            Main.LightValueChange(Glob.LightCH[Glob.LightControlNumber, 0], Main.LightControl[Glob.LightControlNumber]);
        }

        private void num_LightCH2_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightCH[Glob.LightControlNumber, 1] = (int)num_LightCH2.Value;
            if (Main.LightControl[Glob.LightControlNumber].IsOpen == false)
            {
                return;
            }
            Main.LightValueChange(Glob.LightCH[Glob.LightControlNumber, 1], Main.LightControl[Glob.LightControlNumber]);
        }
        private void num_LightCH3_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightCH[Glob.LightControlNumber, 2] = (int)num_LightCH3.Value;
            if (Main.LightControl[Glob.LightControlNumber].IsOpen == false)
            {
                return;
            }
            Main.LightValueChange(Glob.LightCH[Glob.LightControlNumber, 2], Main.LightControl[Glob.LightControlNumber]);
        }

        private void num_LightCH4_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightCH[Glob.LightControlNumber, 3] = (int)num_LightCH4.Value;
            if (Main.LightControl[Glob.LightControlNumber].IsOpen == false)
            {
                return;
            }
            Main.LightValueChange(Glob.LightCH[Glob.LightControlNumber, 3], Main.LightControl[Glob.LightControlNumber]);
        }
        private void num_BlobToolNum_ValueChanged(object sender, EventArgs e)
        {
            ChangeBlobToolNumber();
        }

        private void cb_BlobToolUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
            {
                TempBlobEnable[Glob.CamNumber, (int)num_BlobToolNumber.Value] = cb_BlobToolUsed.Checked;
                BlobEnableChange((int)num_BlobToolNumber.Value);
            }
        }

        private void cb_BlobPolarty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].Polarity(cb_BlobPolarty.SelectedIndex);
        }

        private void num_BlobMinipixel_ValueChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].Minipixel((int)num_BlobMinipixel.Value);
        }

        private void num_BlobThreshold_ValueChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].Threshold((int)num_BlobThreshold.Value);
        }

        private void btn_BlobInspectionArea_Click(object sender, EventArgs e)
        {
            ImageClear();
            Bolb_Train((int)num_BlobToolNumber.Value);
            TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].Area_Affine(ref cdyDisplay, (CogImage8Grey)cdyDisplay.Image, cb_MultiPatternName.SelectedIndex.ToString());
        }

        private void btn_BlobInspection_Click(object sender, EventArgs e)
        {
            ImageClear();
            Bolb_Train((int)num_BlobToolNumber.Value);
            CogGraphicCollection Collection = new CogGraphicCollection();
            //TempBlobs[(int)num_BlobToolNum.Value].Run(Fiximage);
            TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].Run((CogImage8Grey)cdyDisplay.Image);
            if (TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].ResultBlobCount() != TempBlobOKCount[Glob.CamNumber, (int)num_BlobToolNumber.Value])
            {
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].ResultAllBlobDisplayPLT(Collection, false);
            }
            else
            {
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].ResultAllBlobDisplayPLT(Collection, true);
            }
            cdyDisplay.StaticGraphics.AddList(Collection, "");
            tb_BlobCount.Text = TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].ResultBlobCount().ToString();
        }

        private void BLOBINSPECTION_DoubleClick_1(object sender, EventArgs e)
        {
            TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].ToolSetup();
        }

        private void num_BlobMaxCout_ValueChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempBlobOKCount[Glob.CamNumber, (int)num_BlobToolNumber.Value] = (int)num_BlobMaxCout.Value;
        }

        private void ImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImageDelete == false)
            {
                string ImageType;
                ListBox temp_lbx = (ListBox)sender;
                //string FilePath = Glob.ImageFilePath;
                //string ImageName = FilePath + temp_lbx.SelectedItem.ToString();
                string ImageName = temp_lbx.SelectedItem.ToString();

                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();

                CogImageFileTool curimage = new CogImageFileTool();
                curimage.Operator.Open(ImageName, CogImageFileModeConstants.Read);
                curimage.Run();
                ImageType = curimage.OutputImage.GetType().ToString();
                if (ImageType.Contains("CogImage24PlanarColor"))
                {
                    CogImageConvertTool imageconvert = new CogImageConvertTool();
                    imageconvert.InputImage = curimage.OutputImage;
                    imageconvert.RunParams.RunMode = CogImageConvertRunModeConstants.Plane2;
                    imageconvert.Run();
                    cdyDisplay.Image = (CogImage8Grey)imageconvert.OutputImage;
                }
                else
                {
                    cdyDisplay.Image = (CogImage8Grey)curimage.OutputImage; //JPG 파일
                }
                //cdyDisplay.Image = (CogImage8Grey)curimage.OutputImage;
                cdyDisplay.Fit();
                GC.Collect();

                btn_ToolRun.PerformClick();
            }
            else
            {
                if (ImageList.Items.Count == 0)
                {
                    ImageClear();
                    cdyDisplay.Image = null;
                }
                else
                {
                    ImageDelete = false;
                    ImageList.SelectedIndex = SelectNumber == 0 ? SelectNumber : SelectNumber - 1;
                }
            }
        }

        private void btn_AllClear_Click(object sender, EventArgs e)
        {
            ImageList.Items.Clear();
            ImageClear();
            cdyDisplay.Image = null;
        }

        private void btn_DeleteImage_Click(object sender, EventArgs e)
        {
            if (ImageList.Items.Count == 0)
                return;
            ImageDelete = true;
            SelectNumber = ImageList.SelectedIndex;
            ImageList.Items.RemoveAt(ImageList.SelectedIndex);
        }

        private void num_LineToolNum_ValueChanged(object sender, EventArgs e)
        {
            LineChangeToolNumber();
        }

        private void LineChangeToolNumber()
        {
            Dataset = true;
            int Toolnumber = (int)num_LineToolNum.Value;

            cb_LinePolarty.SelectedIndex = TempLines[Glob.CamNumber, Toolnumber].Polarity();
            cb_LineDirection.SelectedIndex = TempLines[Glob.CamNumber, Toolnumber].Direction();

            cb_LineToolUsed.Checked = TempLineEnable[Glob.CamNumber, Toolnumber];
            num_LineCaliperNum.Value = TempLines[Glob.CamNumber, Toolnumber].CaliperNumber();
            LineEnableChange(Toolnumber);
            Dataset = false;
        }

        private void LineEnableChange(int toolnumber)
        {
            cb_LineToolUsed.Text = cb_LineToolUsed.Checked == true ? "USE" : "UNUSED";
            cb_LineToolUsed.ForeColor = cb_LineToolUsed.Checked == true ? Color.Lime : Color.Red;
        }

        private void cb_LineToolUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
            {
                TempLineEnable[Glob.CamNumber, (int)num_LineToolNum.Value] = cb_LineToolUsed.Checked;
                LineEnableChange((int)num_LineToolNum.Value);
            }
        }

        private void cb_LinePolarty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].Polarity(cb_LinePolarty.SelectedIndex);
        }

        private void num_LineCaliperNum_ValueChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].CaliperNumber((int)num_LineCaliperNum.Value);
        }

        private void cb_LineDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].Direction(cb_LineDirection.SelectedIndex);
        }

        private void btn_LineInspectionArea_Click(object sender, EventArgs e)
        {
            ImageClear();
            Pattern_Train();
            TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].Area(ref cdyDisplay, (CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, 0].ToolName());
        }

        private void btn_LineInspection_Click(object sender, EventArgs e)
        {
            CogGraphicCollection Collection = new CogGraphicCollection();
            ImageClear();
            Pattern_Train();
            TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].Run((CogImage8Grey)cdyDisplay.Image);
            TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].ResultDisplay(cdyDisplay, Collection);
        }

        private void Frm_ToolSetUp_KeyDown(object sender, KeyEventArgs e)
        {
            //************************************단축키 모음************************************//
            if (e.Control && e.KeyCode == Keys.S) //ctrl + s : 셋팅값 저장.
                btn_Save_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.O) //ctrl + o : 이미지 열기. 
                btn_ImageOpen_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.H) //ctrl + h : 카메라 1회촬영.
                btn_OneShot_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.L) //ctrl + l : 카메라 라이브 모드
                btn_Live_Click(sender, e);
            //if (e.KeyCode == Keys.Escape) // esc : 셋팅창 종료
            //    btn_Exit_Click(sender, e);
            if (e.Control && e.KeyCode == Keys.D1) //ctrl + 1 : 1번카메라 화면.
                btn_Cam1.PerformClick();
            if (e.Control && e.KeyCode == Keys.D2) //ctrl + 2 : 2번카메라 화면.
                btn_Cam2.PerformClick();
            if (e.Control && e.KeyCode == Keys.D3) //ctrl + 3 : 3번카메라 화면.
                btn_Cam3.PerformClick();
            if (e.Control && e.KeyCode == Keys.D4) //ctrl + 4 : 4번카메라 화면.
                btn_Cam4.PerformClick();
            if (e.Control && e.KeyCode == Keys.D5) //ctrl + 5 : 5번카메라 화면.
                btn_Cam5.PerformClick();
        }

        private void LINEINSPECTION_DoubleClick(object sender, EventArgs e)
        {
            TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].InputImage((CogImage8Grey)cdyDisplay.Image);
            TempLines[Glob.CamNumber, (int)num_LineToolNum.Value].ToolSetup();
        }

        private void ImageList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btn_DeleteImage_Click(sender, e);
        }
        private void UpdateCamStats()
        {
            /*현재 선택된 카메라 상태 확인*/
            btn_Cam1.BackColor = Glob.CamNumber == 0 ? Color.Lime : Color.Silver;
            btn_Cam2.BackColor = Glob.CamNumber == 1 ? Color.Lime : Color.Silver;
            btn_Cam3.BackColor = Glob.CamNumber == 2 ? Color.Lime : Color.Silver;
            btn_Cam4.BackColor = Glob.CamNumber == 3 ? Color.Lime : Color.Silver;
            btn_Cam5.BackColor = Glob.CamNumber == 4 ? Color.Lime : Color.Silver;
        }
        private void UpdateCameraSet()
        {
            try
            {
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
                INIControl CalibrationValue = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CalibrationValue.ini");
                //카메라 및 조명 setting값 ini파일에 저장. - 카메라별로
                //변경될수도있는 사항 : 모델별로 각각 카메라 setting값을 따로 가져가야 될 수도있을꺼 같음. - 191231 김형민 
                // --> 모델별로 카메라값 가져가도록 변경완료 - 200122 김형민
                num_Exposure.Value = Convert.ToDecimal(CamSet.ReadData($"Camera{Glob.CamNumber}", "Exposure"));
                num_Gain.Value = Convert.ToDecimal(CamSet.ReadData($"Camera{Glob.CamNumber}", "Gain"));
                //num_LightCH1.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl_Cam{Glob.CamNumber}", "CH1"));
                //num_LightCH2.Value = Convert.ToDecimal(CamSet.ReadData($"LightControl_Cam{Glob.CamNumber}", "CH2"));
                FormLoad = false;
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        private void ReLoadVisionTool()
        {
            try
            {
                PGgloble gls = PGgloble.getInstance;
                if (gls.RunnModel.Loadmodel(Glob.RunnModel.Modelname(), gls.MODELROOT, Glob.CamNumber) == true)
                {

                }
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        private void btn_Cam1_Click(object sender, EventArgs e)
        {
            try
            {
                //CAM1부터있는 모든 버튼들이 하나의 이벤트로 묶어져있다.(참조확인)
                if (Program.CameraList.Count() == 0)
                    return;

                FormLoad = true;
                int job = Convert.ToInt32((sender as Button).Tag); //클리한 버튼의 TAG값 받아오기.
                Glob.CamNumber = Convert.ToInt32(Program.CameraList[job].Number);

                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();
                cdyDisplay.Image = null;

                UpdateCamStats(); //카메라 상태표시 변경
                UpdateCameraSet(); //카메라 셋팅 변경
                ReLoadVisionTool(); //카메라별로 Vision Tool 이 저장되어있기 때문에 CamNumber가 바뀔때 마다 불러와준다.

                ChangeMultiPatternToolNumber();
                ChangeBlobToolNumber();
                LineChangeToolNumber();
                CircleChangeToolNumber();
                DGVUpadte();
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }

        }

        private void num_AreaPoinrNumber_ValueChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
                TempBlobs[Glob.CamNumber, (int)num_BlobToolNumber.Value].AreaPointNumber((int)num_AreaPoinrNumber.Value);
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].InputImage((CogImage8Grey)cdyDisplay.Image);
            TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].ToolSetup();
        }

        private void num_CircleToolNumber_ValueChanged(object sender, EventArgs e)
        {
            CircleChangeToolNumber();
        }

        private void CircleChangeToolNumber()
        {
            Dataset = true;
            int Toolnumber = (int)num_CircleToolNumber.Value;
            cb_CircleToolUsed.Checked = TempCircleEnable[Glob.CamNumber, Toolnumber];
            CircleEnableChange(Toolnumber);
            Dataset = false;
        }

        private void CircleEnableChange(int toolnumber)
        {
            cb_CircleToolUsed.Text = cb_CircleToolUsed.Checked == true ? "USE" : "UNUSED";
            cb_CircleToolUsed.ForeColor = cb_CircleToolUsed.Checked == true ? Color.Lime : Color.Red;
        }

        private void cb_CircleToolUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
            {
                TempCircleEnable[Glob.CamNumber, (int)num_CircleToolNumber.Value] = cb_CircleToolUsed.Checked;
                CircleEnableChange((int)num_CircleToolNumber.Value);
            }
        }

        private void btn_CircleFindArea_Click(object sender, EventArgs e)
        {
            ImageClear();
            Pattern_Train();
            TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].Area(ref cdyDisplay, (CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, 0].ToolName());
        }

        private void btn_FindCircle_Click(object sender, EventArgs e)
        {
            ImageClear();
            Pattern_Train();
            TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].Run((CogImage8Grey)cdyDisplay.Image);
            TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].ResultDisplay(ref cdyDisplay);
            tb_CircleXPoint.Text = TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].ResultLocation_X().ToString("F4");
            tb_CircleYPoint.Text = TempCircles[Glob.CamNumber, (int)num_CircleToolNumber.Value].ResultLocation_Y().ToString("F4");
        }

        private void label27_DoubleClick(object sender, EventArgs e)
        {
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].InputImage((CogImage8Grey)cdyDisplay.Image);
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ToolSetup();
        }
        private void num_TrainImageNumber_ValueChanged(object sender, EventArgs e)
        {
            int Toolnumber = (int)num_MultiPatternToolNumber.Value;
            cdyMultiPTTrained.Image = TempMulti[Glob.CamNumber, Toolnumber].TrainedImage((int)num_TrainImageNumber.Value);
        }

        private void num_MultiPatternToolNumber_ValueChanged(object sender, EventArgs e)
        {
            ChangeMultiPatternToolNumber();
            CheckMultiPatternStatus();
        }

        private void ChangeMultiPatternToolNumber()
        {
            Dataset = true;
            int Toolnumber = (int)num_MultiPatternToolNumber.Value;
            cb_MultiPatternToolUsed.Checked = TempMultiEnable[Glob.CamNumber, Toolnumber];
            cdyMultiPTTrained.Image = TempMulti[Glob.CamNumber, Toolnumber].TrainedImage(0);
            num_MultiPatternScore.Value = Convert.ToDecimal(TempMulti[Glob.CamNumber, Toolnumber].Threshold() * 100);
            lb_PatternCount.Text = $"등록된 패턴 수 : {TempMulti[Glob.CamNumber, Toolnumber].PatternCount()}개";
            lb_FindPatternCount.Text = $"찾은 패턴 수 : {TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultCount()}개";
            num_TrainImageNumber.Maximum = TempMulti[Glob.CamNumber, Toolnumber].PatternCount() - 1;
            num_TrainImageNumber.Minimum = 0;
            MultiPatternAnlgeModeChange(Toolnumber);
            MultiPatternEnableChange(Toolnumber);
            Dataset = false;
        }

        private void MultiPatternAnlgeModeChange(int toolnumber)
        {
            if (TempMulti[Glob.CamNumber, toolnumber].AngleMode() == CogPMAlignZoneConstants.Nominal)
            {
                cb_AngleMode.Checked = false;
                num_AngleHigh.Enabled = false;
                num_AngleLow.Enabled = false;
            }
            else
            { 
                cb_AngleMode.Checked = true;
                num_AngleHigh.Enabled = true;
                num_AngleLow.Enabled = true;
            }

            cb_AngleMode.Text = cb_AngleMode.Checked == true ? "USE" : "UNUSED";
            cb_AngleMode.ForeColor = cb_AngleMode.Checked == true ? Color.Lime : Color.Red;

            num_AngleHigh.Value = (decimal)TempMulti[Glob.CamNumber, toolnumber].AngleHigh();
            num_AngleLow.Value = (decimal)TempMulti[Glob.CamNumber, toolnumber].AngleLow();
        }

        private void MultiPatternEnableChange(int toolnumber)
        {
            cb_MultiPatternToolUsed.Text = cb_MultiPatternToolUsed.Checked == true ? "USE" : "UNUSED";
            cb_MultiPatternToolUsed.ForeColor = cb_MultiPatternToolUsed.Checked == true ? Color.Lime : Color.Red;
        }
        private void CheckMultiPatternStatus()
        {
            if (TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].istrain((int)num_MultiPatternToolNumber.Value) == true)
            {
                cdyMultiPTTrained.Image = TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].TrainedImage(0);
            }
            else
            {
                cdyMultiPTTrained.Image = null;
            }
        }

        private void cb_MultiPatternToolUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
            {
                TempMultiEnable[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value] = cb_MultiPatternToolUsed.Checked;
                MultiPatternEnableChange((int)num_MultiPatternToolNumber.Value);
            }
        }

        private void btn_MultiPatternToolRun_Click(object sender, EventArgs e)
        {
            ImageClear();
            Pattern_Train();
            MultiPatternSearch();
        }

        private void btn_PatternInput_Click(object sender, EventArgs e)
        {
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].InputImage((CogImage8Grey)cdyDisplay.Image);
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ToolSetup();
            ChangeMultiPatternToolNumber();
        }

        private void btn_ResultShow_Click(object sender, EventArgs e)
        {
            frm_MultiPatternResult = new MultiPatternResult(this, TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultCount());
            frm_MultiPatternResult.Show();
        }

        private void num_MultiPatternScore_ValueChanged(object sender, EventArgs e)
        {
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].Threshold((double)num_MultiPatternScore.Value / 100);
        }

        private void btn_MultiPTSearchArea_Click(object sender, EventArgs e)
        {
            ImageClear();
            Pattern_Train();
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].SearchArea(ref cdyDisplay, (CogImage8Grey)cdyDisplay.Image);
        }

        private void btn_ColortoMono_Click(object sender, EventArgs e)
        {
            if (cdyDisplay.Image == null) //Image가 없으면 return
                return;
            if (cdyDisplay.Image.GetType().ToString().Contains("CogImage8Grey")) //Mono Image로 되어있으면 return
                return;

            CogImageConvertTool ImageConvert = new CogImageConvertTool();
            ImageConvert.InputImage = cdyDisplay.Image;
            ImageConvert.RunParams.RunMode = CogImageConvertRunModeConstants.Plane0;
            ImageConvert.Run();
            Main.Monoimage[Glob.CamNumber] = (CogImage8Grey)ImageConvert.OutputImage;
            cdyDisplay.Image = Main.Monoimage[Glob.CamNumber];
        }

        private void btn_MonotoColor_Click(object sender, EventArgs e)
        {
            if (cdyDisplay.Image == null) //Image가 없으면 return
                return;
            if (cdyDisplay.Image.GetType().ToString().Contains("CogImage24PlanarColor"))//Color Image로 되어있으면 return
                return;

            cdyDisplay.Image = Main.Colorimage[Glob.CamNumber];
        }

        private void cb_Mono_CheckedChanged(object sender, EventArgs e)
        {
            INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
            Glob.ImageType[Glob.CamNumber] = true;
            CamSet.WriteData($"Camera{Glob.CamNumber}", "ImageType", Glob.ImageType[Glob.CamNumber].ToString()); //ImageType
        }

        private void cb_Color_CheckedChanged(object sender, EventArgs e)
        {
            INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
            Glob.ImageType[Glob.CamNumber] = false;
            CamSet.WriteData($"Camera{Glob.CamNumber}", "ImageType", Glob.ImageType[Glob.CamNumber].ToString()); //ImageType
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cb_Mono.BackColor = Glob.ImageType[Glob.CamNumber] == true ? Color.Lime : SystemColors.Control;
            cb_Color.BackColor = Glob.ImageType[Glob.CamNumber] == false ? Color.Lime : SystemColors.Control;
            cb_AlignMode.BackColor = Glob.AligneMode == true ? Color.Lime : Color.Red;
            lb_LightControlNumber.Text = Glob.LightControlNumber.ToString();
            cb_MultiPatternTracking.Text = Glob.TrackingMode[Glob.CamNumber] == true ? "실시간 추적중" : "실시간 추적중지";
            cb_MultiPatternTracking.BackColor = Glob.TrackingMode[Glob.CamNumber] == true ? Color.Lime : Color.Red;
        }

        private void Frm_ToolSetUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void num_LightControlNumber_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightControlNumber = (int)num_LightControlNumber.Value;
            num_LightCH1.Value = Convert.ToDecimal(Glob.LightCH[Glob.LightControlNumber, 0]);
            Thread.Sleep(50);
            num_LightCH2.Value = Convert.ToDecimal(Glob.LightCH[Glob.LightControlNumber, 1]);
            Thread.Sleep(50);
            num_LightCH3.Value = Convert.ToDecimal(Glob.LightCH[Glob.LightControlNumber, 2]);
            Thread.Sleep(50);
            num_LightCH4.Value = Convert.ToDecimal(Glob.LightCH[Glob.LightControlNumber, 3]);
        }

        private void num_HistogramToolNumber_ValueChanged(object sender, EventArgs e)
        {
            ChangeHistogramToolNumber();
        }

        private void ChangeHistogramToolNumber()
        {
            Dataset = true;
            int Toolnumber = (int)num_HistogramToolNumber.Value;
            cb_HistogramToolUsed.Checked = TempHistogramEnable[Glob.CamNumber, Toolnumber];
            HistogramEnableChange(Toolnumber);
            Dataset = false;
        }
        private void HistogramEnableChange(int toolnumber)
        {
            cb_HistogramToolUsed.Text = cb_HistogramToolUsed.Checked == true ? "USE" : "UNUSED";
            cb_HistogramToolUsed.ForeColor = cb_HistogramToolUsed.Checked == true ? Color.Lime : Color.Red;
        }

        private void cb_HistogramToolUsed_CheckedChanged(object sender, EventArgs e)
        {
            if (Dataset == false)
            {
                TempHistogramEnable[Glob.CamNumber, (int)num_HistogramToolNumber.Value] = cb_HistogramToolUsed.Checked;
                HistogramEnableChange((int)num_HistogramToolNumber.Value);
            }
        }

        private void btn_HistogramInspectionArea_Click(object sender, EventArgs e)
        {
            ImageClear();
            Histogram_Train((int)num_HistogramToolNumber.Value);
            TempHistogram[Glob.CamNumber, (int)num_HistogramToolNumber.Value].Area_Affine(ref cdyDisplay, (CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, (int)num_HistogramToolNumber.Value].ToolName());
        }
        public void Histogram_Train(int toolnumber)
        {
            if (TempMulti[Glob.CamNumber, toolnumber].Run((CogImage8Grey)cdyDisplay.Image) == true)
            {
                Fiximage = TempModel.Histogram_FixtureImage((CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, toolnumber].ResultPoint(TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber()), TempMulti[Glob.CamNumber, toolnumber].ToolName(), Glob.CamNumber, toolnumber, out FimageSpace, TempMulti[Glob.CamNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }

        private void btn_HistogramInspection_Click(object sender, EventArgs e)
        {
            ImageClear();
            Histogram_Train((int)num_HistogramToolNumber.Value);
            CogGraphicCollection Collection = new CogGraphicCollection();
            TempHistogram[Glob.CamNumber, (int)num_HistogramToolNumber.Value].Run((CogImage8Grey)cdyDisplay.Image);
            TempHistogram[Glob.CamNumber, (int)num_HistogramToolNumber.Value].ResultDisplay(Collection, true);
            cdyDisplay.StaticGraphics.AddList(Collection, "");
            tb_HistogramResultMax.Text = TempHistogram[Glob.CamNumber, (int)num_HistogramToolNumber.Value].ResultHistogramMax().ToString();
            tb_HistogramResultMin.Text = TempHistogram[Glob.CamNumber, (int)num_HistogramToolNumber.Value].ResultHistogramMin().ToString();
        }

        private void cb_MultiPatternTracking_CheckedChanged(object sender, EventArgs e)
        {
            Glob.TrackingMode[Glob.CamNumber] = Glob.TrackingMode[Glob.CamNumber] == true ? false : true;
            if (Glob.TrackingMode[Glob.CamNumber])
            {
                bk_TrackingPattern.RunWorkerAsync();
            }
            else
            {
                bk_TrackingPattern.CancelAsync();
            }
        }

        private void bk_TrackingPattern_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (bk_TrackingPattern.CancellationPending == true)
                    return;

                Invoke((Action)delegate { MultiPatternSearch(); });
            }
        }

        private void MultiPatternSearch()
        {
            if (TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].Run((CogImage8Grey)cdyDisplay.Image) == true)
            {
                for (int i = 0; i < TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultCount(); i++)
                {
                    Glob.MultiPatternResultData[Glob.CamNumber, i] = TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultScore(i);
                }
                //Fiximage = TempModel.FixtureImage((CogImage8Grey)cdyDisplay.Image, TempPattern[Glob.CamNumber, (int)num_PatternToolNumber.Value].ResultPoint(), TempPattern[Glob.CamNumber, (int)num_PatternToolNumber.Value].ToolName(), Glob.CamNumber, out FimageSpace);
                Glob.MultiInsPat_Result[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value] = TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultScore(TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].HighestResultToolNumber());
                TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultDisplay(ref cdyDisplay, TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].HighestResultToolNumber());
                lb_FindPatternCount.Text = $"찾은 패턴 수 : {TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultCount()}개";
                lb_MultiScore.Text = $"{TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultScore(TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].HighestResultToolNumber()).ToString("F2")}%";
                lb_MultiScore.ForeColor = Color.Lime;
            }
            else
            {
                ImageClear();
                //TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultDisplay(ref cdyDisplay, TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].HighestResultToolNumber());
                lb_MultiScore.Text = "패턴 찾기 실패";
                lb_FindPatternCount.Text = $"찾은 패턴 수 : {TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].ResultCount()}개";
                lb_MultiScore.ForeColor = Color.Red;
            }
        }

        private void cb_MultiPatternName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int toolnum = cb_MultiPatternName.SelectedIndex;
            TempBlobFixPatternNumber[Glob.CamNumber, (int)num_BlobToolNumber.Value] = toolnum;
            ImageClear();
            if (TempMulti[Glob.CamNumber, toolnum].Run((CogImage8Grey)cdyDisplay.Image))
            {
                Fiximage = TempModel.Blob_FixtureImage((CogImage8Grey)cdyDisplay.Image, TempMulti[Glob.CamNumber, toolnum].ResultPoint(TempMulti[Glob.CamNumber, toolnum].HighestResultToolNumber()), TempMulti[Glob.CamNumber, toolnum].ToolName(), Glob.CamNumber, toolnum, out FimageSpace, TempMulti[Glob.CamNumber, toolnum].HighestResultToolNumber());
            }
            else
            {
                //cm.info("이미지가 없습니다.");
            }
        }

        private void cb_AlignMode_CheckedChanged(object sender, EventArgs e)
        {
            Glob.AligneMode = Glob.AligneMode == true ? false : true; 
        }

        private void cb_AngleMode_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AngleMode.Checked)
            {
                TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].AngleMode(CogPMAlignZoneConstants.LowHigh);
                num_AngleHigh.Enabled = true;
                num_AngleLow.Enabled = true;
            }
            else
            {
                TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].AngleMode(CogPMAlignZoneConstants.Nominal);
                num_AngleHigh.Enabled = false;
                num_AngleLow.Enabled = false;
            }

            cb_AngleMode.Text = cb_AngleMode.Checked == true ? "USE" : "UNUSED";
            cb_AngleMode.ForeColor = cb_AngleMode.Checked == true ? Color.Lime : Color.Red;
        }

        private void num_AngleLow_ValueChanged(object sender, EventArgs e)
        {
            double setAngle = (double)num_AngleLow.Value * (Math.PI / 180);
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].AngleLow(setAngle);
        }

        private void num_AngleHigh_ValueChanged(object sender, EventArgs e)
        {
            double setAngle = (double)num_AngleHigh.Value * (Math.PI / 180);
            TempMulti[Glob.CamNumber, (int)num_MultiPatternToolNumber.Value].AngleHigh(setAngle);
        }
    }
}
