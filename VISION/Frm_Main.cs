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
using System.Diagnostics;
using System.Threading;
using Cognex.VisionPro;
using System.Runtime.InteropServices;
using Cognex.VisionPro.Display;
using System.IO.Ports;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using System.Drawing.Imaging;
using System.Reflection;
using KimLib;
using System.Net.Sockets;

namespace VISION
{
    public delegate void EventCallBack(Bitmap bmp);
    public partial class Frm_Main : Form
    {
        Log log = new Log();
        public List<Basler.Pylon.ICameraInfo> AllCams;// 컴퓨터에 접근 된 카메라 리스트
        public Basler.Pylon.Camera[] Cam = new Basler.Pylon.Camera[5];// 프로그램에서 제어 할 카메라.
        public bool[] CameraStats = new bool[5]; //카메라 상태 체크
        private Basler.Pylon.PixelDataConverter ImageConverter = new Basler.Pylon.PixelDataConverter(); // 이미지 컨버터
        private Basler.Pylon.IEnumParameter PixelParameter = null; // 픽셀 컨트롤 파라미터
        private Basler.Pylon.IFloatParameter ExposureParameter = null; // 노출 컨트롤 파라미터
        private bool isFirst = true;
        private bool AcqEnable = false;
        private int FreamCount = 0;
        private string[] CameraSerialNumber = new string[5]; //카메라 시리얼번호
        private int CameraNumber; //카메라 번호
        public Stopwatch[] InspectTime = new Stopwatch[5]; //검사시간
        Frm_Loading frm_loading; //로딩화면 
        private Class_Common cm { get { return Program.cm; } } //에러 메세지 보여주기.
        public CogImage24PlanarColor[] Colorimage = new CogImage24PlanarColor[5]; //컬러 이미지
        public CogImage8Grey[] Monoimage = new CogImage8Grey[5]; //흑백이미지
        internal Frm_ToolSetUp frm_toolsetup; //툴셋업창 화면
        public SerialPort[] LightControl; //조명컨트롤러

        internal bool[] trigflag; //트리거 불함수
        private CogImage8Grey Fiximage; //PMAlign툴의 결과이미지(픽스쳐이미지)
        private string FimageSpace; //PMAlign툴 SpaceName(보정하기위해)

        private Cogs.Model TempModel; //모델
        private Cogs.Blob[,] TempBlobs; //블롭툴
        private Cogs.Line[,] TempLines; //라인툴
        private Cogs.Circle[,] TempCircles; //써클툴
        private Cogs.MultiPMAlign[,] TempMulti; //멀티패턴툴

        private bool[,] TempLineEnable; //라인툴 사용여부
        private bool[,] TempBlobEnable;//블롭툴 사용여부
        private bool[,] TempCircleEnable; //써클툴 사용여부
        private bool[,] TempMultiEnable; //멀티패턴툴 사용여부
        private int[,] TempMultiOrderNumber;
        private int[,] TempBlobOKCount;//블롭툴 설정갯수
        private int[,] TempBlobFixPatternNumber;

        private PGgloble Glob; //전역변수 - CLASS "PGgloble" 참고.

        public bool AutoRun = false; //오토런 상태
        //public SerialPort[] LightControl = new SerialPort[4];
        public bool LightStats = false; //조명 상태
        public bool[] InspectResult = new bool[5]; //검사결과.
        public bool[] PatternInspectResult = new bool[5];
        public bool[] BlobInspectResult = new bool[5];
        public bool Modelchange = false; //모델체인지
        //public Stopwatch[] InspectTime = new Stopwatch[5]; //검사시간
        public double[] OK_Count = new double[5]; //양품개수
        public double[] NG_Count = new double[5]; //NG품개수
        public double[] TOTAL_Count = new double[5]; //총개수
        public double[] NG_Rate = new double[5]; //총개수
        public bool[] InspectFlag = new bool[5]; //검사 플래그.

        Thread snap1; //CAM1 Shot 쓰레드
        Thread snap2; //CAM2 Shot 쓰레드
        Thread snap3; //CAM3 Shot 쓰레드
        Thread snap4; //CAM4 Shot 쓰레드
        Thread snap5; //CAM5 Shot 쓰레드

        Label[] OK_Label; //수량 OK 라벨
        Label[] NG_Label; //수량 NG 라벨
        Label[] TOTAL_Label; //총수량 라벨
        Label[] NGRATE_Label; //불량률 라벨
        Label[] CameraStats_Label; //카메라 상태 체크 라벨
        CogDisplay[] MainCogDisplay; //메인폼 디스플레이 

        DateTime ChangeDateTime;

        //Socket 통신 ( Vision Client / PLC Server )
        TcpClient Client;

        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;

        Encoding encode = Encoding.GetEncoding("utf-8");

        public bool PLCConnected = false; //PLC 연결상태
        public int reToPLCReasultCount = 0;

        //PIN TEST
        public int pingCount = 0;
        public bool pingUse = false;

        public string[] orderNumberSignal = new string[8] { "1130", "1240", "2130", "2240", "3130", "3240", "4130", "4240" };

        public Frm_Main()
        {
            Glob = PGgloble.getInstance; //전역변수 사용
            Process.Start($"{Glob.LOADINGFROM}");
            InitializeComponent();
            LightControl = new SerialPort[3] { LightControl1, LightControl2, LightControl3 };
            MainCogDisplay = new CogDisplay[5] { cdyDisplay, cdyDisplay2, cdyDisplay3, cdyDisplay4, cdyDisplay5 };
            StandFirst(); //처음 Setting해줘야 하는 부분.
            Glob.RunnModel = new Cogs.Model(); //코그넥스 모델 확인.
        }
        private void Log_OnLogEvent(object sender, LogItem e)
        {
            logControl1.ManageLog(e);
        }
        
        private void ConnectPLC()
        {
            try
            {
                short[] nIP = new short[4];
                /*IP번호 - 바뀔일이 없을꺼같지만.. 바뀔수도있어서 TEXTBOX로 만들어 놈*/
                nIP[0] = Convert.ToInt16(textBoxIP0.Text);
                nIP[1] = Convert.ToInt16(textBoxIP1.Text);
                nIP[2] = Convert.ToInt16(textBoxIP2.Text);
                nIP[3] = Convert.ToInt16(textBoxIP3.Text);

                string IP = $"{nIP[0]}.{nIP[1]}.{nIP[2]}.{nIP[3]}";
                int port = 10001;

                if (btnConnect.Text == "연결하기")
                {
                    try
                    {
                        Client = new TcpClient();
                        Client.Connect(IP, port);
                        stream = Client.GetStream();
                        PLCConnected = true;
                        log.AddLogMessage(LogType.Infomation, 0, $"Connected to Server : {IP}");
                        btnConnect.Text = "해제하기";
                        Reader = new StreamReader(stream, encode);
                        Writer = new StreamWriter(stream);
                        timer_sandPLC.Start();
                        pingUse = true;
                        bk_Signal.RunWorkerAsync();
                    }
                    catch (SocketException e)
                    {
                        PLCConnected = false;
                        pingUse = false;
                        if (bk_Signal.IsBusy == true)
                        {
                            bk_Signal.CancelAsync();
                        }
                        log.AddLogMessage(LogType.Error, 0, e.Message);
                    }
                }
                else if (btnConnect.Text == "해제하기")
                {
                    try
                    {
                        btnConnect.Text = "연결하기";
                        PLCConnected = false;
                        if (Reader != null) Reader.Close();
                        if (Writer != null) Writer.Close();
                        if (Client != null) Client.Close();
                        if (bk_Signal.IsBusy == true)
                        {
                            bk_Signal.CancelAsync();
                        }
                        pingUse = false;
                    }
                    catch(Exception e)
                    {
                        PLCConnected = false;
                        log.AddLogMessage(LogType.Error, 0, e.Message);
                    }
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} : {ee.Message}");
            }
        }

        private void MonoCameraShot()
        {
            cdyDisplay.Image = null;
            cdyDisplay.InteractiveGraphics.Clear();
            cdyDisplay.StaticGraphics.Clear();

            snap1 = new Thread(new ThreadStart(SnapShot1));
            snap1.Priority = ThreadPriority.Highest;
            snap1.Start();

            cdyDisplay3.Image = null;
            cdyDisplay3.InteractiveGraphics.Clear();
            cdyDisplay3.StaticGraphics.Clear();

            snap3 = new Thread(new ThreadStart(SnapShot3));
            snap3.Priority = ThreadPriority.Highest;
            snap3.Start();
        }

        private void AllCameraShot()
        {
            //cdyDisplay.Image = null;
            //cdyDisplay.InteractiveGraphics.Clear();
            //cdyDisplay.StaticGraphics.Clear();

            snap1 = new Thread(new ThreadStart(SnapShot1));
            snap1.Priority = ThreadPriority.Highest;
            snap1.Start();


            //cdyDisplay2.Image = null;
            //cdyDisplay2.InteractiveGraphics.Clear();
            //cdyDisplay2.StaticGraphics.Clear();

            snap2 = new Thread(new ThreadStart(SnapShot2));
            snap2.Priority = ThreadPriority.Highest;
            snap2.Start();


            //cdyDisplay3.Image = null;
            //cdyDisplay3.InteractiveGraphics.Clear();
            //cdyDisplay3.StaticGraphics.Clear();

            snap3 = new Thread(new ThreadStart(SnapShot3));
            snap3.Priority = ThreadPriority.Highest;
            snap3.Start();

          
            //cdyDisplay4.Image = null;
            //cdyDisplay4.InteractiveGraphics.Clear();
            //cdyDisplay4.StaticGraphics.Clear();

            snap4 = new Thread(new ThreadStart(SnapShot4));
            snap4.Priority = ThreadPriority.Highest;
            snap4.Start();
        }

        private void ColorCameraShot()
        {
            cdyDisplay2.Image = null;
            cdyDisplay2.InteractiveGraphics.Clear();
            cdyDisplay2.StaticGraphics.Clear();

            snap2 = new Thread(new ThreadStart(SnapShot2));
            snap2.Priority = ThreadPriority.Highest;
            snap2.Start();

            cdyDisplay4.Image = null;
            cdyDisplay4.InteractiveGraphics.Clear();
            cdyDisplay4.StaticGraphics.Clear();

            snap4 = new Thread(new ThreadStart(SnapShot4));
            snap4.Priority = ThreadPriority.Highest;
            snap4.Start();
        }

        private void GrabEndSandPLC(string headerData, string tempData)
        {
            double sendnumber = Convert.ToDouble(tempData) + 1;
            string strsendData = $"{headerData}{sendnumber}";
            SendToPLC(strsendData);
        }

        private void bk_Signal_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (PLCConnected)
                {
                    if (bk_Signal.CancellationPending)
                        return;

                    if (stream.CanRead)
                    {
                        byte[] buffer = new byte[1024];

                        stream.Read(buffer, 0, buffer.Length);
                        string ReceiveData = Encoding.ASCII.GetString(buffer);
                        ReceiveData = ReceiveData.Substring(0, 8);

                        log.AddLogMessage(LogType.Infomation, 0, $"PLC -> PC : {ReceiveData}");
                        string headerData = ReceiveData.Substring(0,4);
                        string tempData = ReceiveData.Substring(4, 4);

                        if (ReceiveData == "AUTOSTRT")
                            pingUse = false;
                        if (ReceiveData == "AUTOEEND")
                            pingUse = true;

                        if (headerData == "SKCM" || headerData == "SBCM")
                        {

                            Glob.InspectOrder = Array.IndexOf(orderNumberSignal, tempData)+1;
                            if (headerData == "SKCM")
                            {
                                AllCameraShot();
                                //ColorCameraShot();
                                //MonoCameraShot();
                            }
                        }
                        else if(headerData == "JUDG")
                        {
                            reToPLCReasultCount = reToPLCReasultCount + 1;
                            switch (tempData)
                            {
                                case "1111":
                                    SendToPLC("JUDG1000");
                                    break;
                                case "2222":
                                    SendToPLC("JUDG2000");
                                    break;
                                case "3333":
                                    SendToPLC("JUDG3000");
                                    break;
                                case "4444":
                                    SendToPLC("JUDG4000");
                                    break;
                            }
                        }
                        else if(headerData == "UCMP" || headerData =="UCAM")
                        {
                            switch (tempData)
                            {
                                //얼라인 작업추가하기. ( 멀티패턴 0번각도로 얼라인 값 보내기 )
                                case "1111":
                                    // 1. 이미지 촬영 ( 각도 추출을 위한 이미지 촬영 )
                                    Glob.AligneMode = true;
                                    Glob.topAlignNumber = "1";
                                    Glob.InspectOrder = 1;
                                    cdyDisplay5.Image = null;
                                    cdyDisplay5.InteractiveGraphics.Clear();
                                    cdyDisplay5.StaticGraphics.Clear();

                                    snap5 = new Thread(new ThreadStart(SnapShot5));
                                    snap5.Priority = ThreadPriority.Highest;
                                    snap5.Start();
                                    break;
                                case "2222":
                                    Glob.AligneMode = true;
                                    Glob.topAlignNumber = "2";
                                    Glob.InspectOrder = 2;
                                    cdyDisplay5.Image = null;
                                    cdyDisplay5.InteractiveGraphics.Clear();
                                    cdyDisplay5.StaticGraphics.Clear();

                                    snap5 = new Thread(new ThreadStart(SnapShot5));
                                    snap5.Priority = ThreadPriority.Highest;
                                    snap5.Start();
                                    break;
                                case "3333":
                                    Glob.AligneMode = true;
                                    Glob.topAlignNumber = "3";
                                    Glob.InspectOrder = 3;
                                    cdyDisplay5.Image = null;
                                    cdyDisplay5.InteractiveGraphics.Clear();
                                    cdyDisplay5.StaticGraphics.Clear();

                                    snap5 = new Thread(new ThreadStart(SnapShot5));
                                    snap5.Priority = ThreadPriority.Highest;
                                    snap5.Start();
                                    break;
                                case "4444":
                                    Glob.AligneMode = true;
                                    Glob.topAlignNumber = "4";
                                    Glob.InspectOrder = 4;
                                    cdyDisplay5.Image = null;
                                    cdyDisplay5.InteractiveGraphics.Clear();
                                    cdyDisplay5.StaticGraphics.Clear();

                                    snap5 = new Thread(new ThreadStart(SnapShot5));
                                    snap5.Priority = ThreadPriority.Highest;
                                    snap5.Start();
                                    break;
                                case "0004":
                                    SendToPLC("UC4P0000");
                                    break;
                                case "0003":
                                    SendToPLC("UC3P0000");
                                    break;
                                case "0002":
                                    SendToPLC("UC2P0000");
                                    break;
                                case "0001":
                                    SendToPLC("UC1P0000");
                                    break;

                            }
                        }
                       
                    }
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{ee.Message}");
            }          
        }

        private delegate void delegateUpdateOutIn();
        public void StandFirst()
        {
            Directory.CreateDirectory(Glob.MODELROOT); // 프로그램 모델 루트 디렉토리 작성

            INIControl Config = new INIControl(Glob.CONFIGFILE);
            INIControl Modellist = new INIControl(Glob.MODELLIST);
            INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);
            INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로

            for (int i = 0; i < 5; i++) //카메라에서 찍은 이미지 변수 초기화 과정.
            {
                Monoimage[i] = new CogImage8Grey();
                Colorimage[i] = new CogImage24PlanarColor();
            }
            for (int i = 0; i < Program.CameraList.Count(); i++)
            {
                CameraSerialNumber[i] = Program.CameraList[i].SerialNum;
            }

            Glob.ImageSaveRoot = setting.ReadData("SYSTEM", "Image Save Root"); //이미지 저장 경로
            Glob.DataSaveRoot = setting.ReadData("SYSTEM", "Data Save Root"); //데이터 저장 경로
            log.InitializeLog($"{Glob.DataSaveRoot}\\Log");
            log.OnLogEvent += Log_OnLogEvent;
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            btnConnect.Text = "연결하기";
            lb_Ver.Text = $"Ver. {Glob.PROGRAM_VERSION}"; //프로그램버전표시.
            Initialize_CamvalueInit(); //카메라 초기화
            LoadSetup(); //프로그램 셋팅 로드.
            Initialize_LightControl(); //조명컨트롤러 연결.
            ConnectPLC(); //PLC연결
            CognexModelLoad(); //코그넥스모델 로드
            timer_Setting.Start(); //타이머에서 계속해서 확인하는 것들
            Initialize_CameraInit(); //카메라 초기화 및 연결 - 카메라연결을 제일 마지막에 해줘야한다.
            log.AddLogMessage(LogType.Infomation, 0, "Vision Program Start");
            Process[] myProcesses = Process.GetProcessesByName("LoadingForm_KHM");
            if (myProcesses.LongLength > 0)
            {
                myProcesses[0].Kill();
            }
           
        }
        public void SnapShot1()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[0].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[0].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot2()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[1].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[1].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot3()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[2].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[2].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot4()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[3].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[3].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot5()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[4].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[4].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot(int CamNumber)
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[CamNumber].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[CamNumber].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        public void StartLive(int CamNumber)
        {
            FreamCount = 0;
            AcqEnable = true;
            Cam[CamNumber].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.Continuous);
            Cam[CamNumber].StreamGrabber.Start(Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
        }

        public void StopLive(int CamNumber)
        {
            Cam[CamNumber].StreamGrabber.Stop();
        }

        private void UpDateCams()
        { // 연결 가능한 카메라 리스트 갱신하기
            try
            {
                AllCams = Basler.Pylon.CameraFinder.Enumerate(); // 카메라 리스트 초기화

                if (AllCams.Count < 1)
                { // 카메라가 없으면 나가기
                    return;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        private void DistoryCamera()
        {
            try
            {             // 예제소스 앞단은 화면상 파라미터값 해제
                for (int i = 0; i < 5; i++)
                {
                    if (Cam[i] != null)
                    {
                        Cam[i].Close();
                        Cam[i].Dispose();
                        Cam[i] = null;
                    }
                    CameraStats[i] = false;
                    MainCogDisplay[i].Image = null;
                    MainCogDisplay[i].InteractiveGraphics.Clear();
                    MainCogDisplay[i].StaticGraphics.Clear();
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }

        public void GainSet(int CamNum, double Value)
        {
            if (Cam[CamNum] == null) return;
            try
            {
                Cam[CamNum].Parameters[Basler.Pylon.PLCamera.GainAbs].SetValue(Value);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        public void ExposureSet(int CamNum, double Value)
        {
            if (Cam[CamNum] == null) return;
            try
            {
                Cam[CamNum].Parameters[Basler.Pylon.PLCamera.ExposureTimeAbs].SetValue(Value);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        #region InnerClass
        private class EnumValue
        {
            public EnumValue(Basler.Pylon.IEnumParameter parameter)
            {
                ValueName = parameter.GetValue();
                ValueDisplayName = parameter.GetAdvancedValueProperties(ValueName).GetPropertyOrDefault(Basler.Pylon.AdvancedParameterAccessKey.DisplayName, ValueName);
            }

            public EnumValue(Basler.Pylon.IEnumParameter parameter, string valueName)
            {
                ValueName = valueName;
                ValueDisplayName = parameter.GetAdvancedValueProperties(valueName).GetPropertyOrDefault(Basler.Pylon.AdvancedParameterAccessKey.DisplayName, valueName);
            }

            public override string ToString()
            {
                return ValueDisplayName;
            }

            public string ValueName;
            public string ValueDisplayName;
        };
        #endregion

        private void Initialize_LightControl()
        {
            try
            {
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
                INIControl setting = new INIControl(Glob.SETTING);
                for (int i = 0; i < LightControl.Count(); i++)
                {
                    if (LightControl[i].IsOpen == true)
                    {
                        LightControl[i].Close();
                    }
                    LightControl[i].BaudRate = Convert.ToInt32(setting.ReadData("COMMUNICATION", $"Baud Rate{i}"));
                    LightControl[i].Parity = Parity.None;
                    LightControl[i].DataBits = Convert.ToInt32(setting.ReadData("COMMUNICATION", $"Data Bits{i}"));
                    LightControl[i].StopBits = StopBits.One;
                    LightControl[i].PortName = setting.ReadData("COMMUNICATION", $"Port number{i}");
                    LightControl[i].Open();
                    for (int j = 0; j < 4; j++)
                    {
                        Glob.LightCH[i, j] = Convert.ToInt32(CamSet.ReadData($"LightControl{i}", $"CH{j + 1}")); //저장된 조명값 불러오기.
                    }
                    LightOFF(LightControl[i]); // 처음 실행했을때는 조명을 꺼주자. (AUTO모드로 변경됐을때, 조명 켜주자)
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        public bool CameraSerialNumberCheck(int CameraNumber, string CameraIP, string serialnumber)
        {
            //CameraSerialNumber[0] = "23443316"; //CAM1
            //CameraSerialNumber[1] = "23668377"; //CAM2
            //CameraSerialNumber[2] = "23668362"; //CAM3
            //CameraSerialNumber[3] = "23655508"; //CAM4
            //CameraSerialNumber[4] = "23668363"; //CAM5
            string[] EachIP = CameraIP.Split('.');
            switch (EachIP[2])
            {
                case "1":
                    if (serialnumber == CameraSerialNumber[0])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM1 not Connect - SerialNumber Error");
                        return false;
                    }
                case "2":
                    if (serialnumber == CameraSerialNumber[1])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM2 not Connect - SerialNumber Error");
                        return false;
                    }
                case "3":
                    if (serialnumber == CameraSerialNumber[2])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM3 not Connect - SerialNumber Error");
                        return false;
                    }
                case "4":
                    if (serialnumber == CameraSerialNumber[3])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM4 not Connect - SerialNumber Error");
                        return false;
                    }
                case "5":
                    if (serialnumber == CameraSerialNumber[4])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM5 not Connect - SerialNumber Error");
                        return false;
                    }

            }
            return false;
        }
        private void Initialize_CameraInit()
        {
            try
            {
                //int CameraNumber = 0;
                for (int i = 0; i < AllCams.Count; i++)
                {
                    CameraNumber = 0;
                    Basler.Pylon.ICameraInfo EachCam = AllCams[i]; //불러온 카메라 각각 차례대로 불러오기.
                    string SerialNumber = EachCam[Basler.Pylon.CameraInfoKey.SerialNumber]; //불러온 카메라 시리얼번호확인.
                    //카메라 시리얼번호 맞추기
                    for (int y = 0; y < 5; y++)
                    {
                        if (CameraSerialNumber[y] == SerialNumber) //설정된 시리얼번호와 불러온 시리얼번호 일치여부 확인.
                        {
                            Cam[y] = new Basler.Pylon.Camera(EachCam);
                            CameraNumber = y;
                        }
                    }
                    /*
                     * 불러온 시리얼번호가 카메라 번호가 맞는지 확인.(IP 3번째 숫자를 이용하여 확인)
                     * 시리얼번호가 일치 하는데, 실제 연결되어야될 카메라가 아닌 다른 카메라가 연결되는것을 방지하기 위하여, 확인해주는 작업
                     *  ex) Program상 CAM2에서 2번카메라가 나와야되는데 3번카메라가 나오는 현상이 생겨 추가해놈
                     */
                    if (!CameraSerialNumberCheck(CameraNumber, Cam[CameraNumber].CameraInfo["Address"], SerialNumber))
                    {
                        continue;
                    }

                    Cam[CameraNumber].CameraOpened += Basler.Pylon.Configuration.AcquireSingleFrame;
                    if (Cam[CameraNumber].IsOpen == true)
                    {
                        //연결되어있으면 해제 시켜주기.
                        Cam[CameraNumber].Close();
                        Cam[CameraNumber].Dispose();
                    }
                    /*카메라 이벤트 생성*/
                    switch (CameraNumber)
                    {
                        case 0:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost;
                            Cam[CameraNumber].CameraOpened += onCameraOpened;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped;
                            break;
                        case 1:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost2;
                            Cam[CameraNumber].CameraOpened += onCameraOpened2;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed2;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted2;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed2;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped2;
                            break;
                        case 2:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost3;
                            Cam[CameraNumber].CameraOpened += onCameraOpened3;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed3;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted3;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed3;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped3;
                            break;
                        case 3:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost4;
                            Cam[CameraNumber].CameraOpened += onCameraOpened4;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed4;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted4;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed4;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped4;
                            break;
                        case 4:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost5;
                            Cam[CameraNumber].CameraOpened += onCameraOpened5;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed5;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted5;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed5;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped5;
                            break;
                    }
                    Cam[CameraNumber].Open(); //카메라 오픈
                    CameraStats[CameraNumber] = true; //카메라 연결상태 
                    log.AddLogMessage(LogType.Result, 0, $"CAM{CameraNumber + 1} 연결 성공");
                    PixelParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.PixelFormat]; // 카메라 픽셀 설정

                    /* 카메라 프레임 올려주기 위한 설정추가 - 김형민 2021-03-19 */
                    Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.GevSCPSPacketSize].SetValue(9000);

                    // 노출 설정 (카메라 허용 값대로 가져오기.
                    if (Cam[CameraNumber].Parameters.Contains(Basler.Pylon.PLCamera.ExposureTimeAbs))
                    {
                        ExposureParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.ExposureTimeAbs];
                    }
                    else
                    {
                        ExposureParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.ExposureTime];
                    }

                    // 카메라 픽셀 설정 먼저.
                    if (PixelParameter.IsWritable && PixelParameter.IsReadable)
                    {
                        string Selected = PixelParameter.GetValue();

                        foreach (string values in PixelParameter)
                        {
                            EnumValue item = new EnumValue(this.PixelParameter, values); // EnumValue : 아래 추가 선언 되어 있다.

                            if (Selected == values)
                            {

                            }
                        }
                    }
                    else if (PixelParameter.IsReadable)
                    {
                        EnumValue item = new EnumValue(PixelParameter);
                    }
                    else
                    {

                    }

                    if (ExposureParameter.IsReadable)
                    {
                        //this.nudExposure.Minimum = (decimal)this.ExposureParameter.GetMinimum();
                        //this.nudExposure.Maximum = (decimal)this.ExposureParameter.GetMaximum();
                        //this.nudExposure.Value = (decimal)this.ExposureParameter.GetValue();
                        //this.nudExposure.Enabled = true;
                    }
                    this.isFirst = false;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - CAM{CameraNumber + 1} {ee.Message}");
            }
        }
        private void Initialize_CamvalueInit()
        {
            try
            {
                for (int i = 0; i < CameraStats.Count(); i++)
                {
                    CameraStats[i] = false; //카메라 상태 전체 False
                }
                AllCams = Basler.Pylon.CameraFinder.Enumerate(); //PC와 연결되어있는 카메라 전체불러오기
                if (AllCams.Count < 1)
                {
                    log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - 연결된 카메라가 없습니다");
                    return;
                }
                if (AllCams.Count != 5) //5개가 연결되어있지않으면.
                {
                    log.AddLogMessage(LogType.Warning, 0, $"{5 - AllCams.Count}개의 카메라가 접근하지 못하였습니다. ※카메라 전원 및 IP Adress 확인※");
                }
                else //정상적으로 전체카메라 불러오기 성공.
                {
                    log.AddLogMessage(LogType.Result, 0, $"{AllCams.Count}개의 카메라 접근 성공.");
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }

        private void LoadSetup()
        {
            try
            {
                OK_Label = new Label[5] { lb_CAM1_OK, lb_CAM2_OK, lb_CAM3_OK, lb_CAM4_OK, lb_CAM5_OK };
                NG_Label = new Label[5] { lb_CAM1_NG, lb_CAM2_NG, lb_CAM3_NG, lb_CAM4_NG, lb_CAM5_NG };
                TOTAL_Label = new Label[5] { lb_CAM1_TOTAL, lb_CAM2_TOTAL, lb_CAM3_TOTAL, lb_CAM4_TOTAL, lb_CAM5_TOTAL };
                NGRATE_Label = new Label[5] { lb_CAM1_NGRATE, lb_CAM2_NGRATE, lb_CAM3_NGRATE, lb_CAM4_NGRATE, lb_CAM5_NGRATE };
                CameraStats_Label = new Label[5] { lb_Cam1Stats, lb_Cam2Stats, lb_Cam3Stats, lb_Cam4Stats, lb_Cam5Stats };
                INIControl Modellist = new INIControl(Glob.MODELLIST); // ini파일 경로
                INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);  // ini파일 경로
                INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로

                string LastModel = CFGFILE.ReadData("LASTMODEL", "NAME"); //마지막 사용모델 확인.
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{LastModel}\\CamSet.ini");
                for (int i = 0; i < 5; i++)
                {
                    Glob.RunnModel.Loadmodel(LastModel, Glob.MODELROOT, i); //VISION TOOL LOAD
                }
                //****************************스펙 값****************************//
                for (int i = 0; i < 5; i++)
                {
                    Glob.ImageType[i] = Convert.ToBoolean(CamSet.ReadData($"Camera{i}", "ImageType")); //이미지 타입설정
                    ExposureSet(i, Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"))); //노출값 설정
                }


                for (int i = 0; i < 4; i++)
                {
                    //****************************COMPORT 연결관련****************************//
                    Glob.PortName[i] = setting.ReadData("COMMUNICATION", $"Port number{i}");
                    Glob.Parity[i] = setting.ReadData("COMMUNICATION", $"Parity Check{i}");
                    Glob.StopBits[i] = setting.ReadData("COMMUNICATION", $"Stop bits{i}");
                    Glob.DataBit[i] = setting.ReadData("COMMUNICATION", $"Data Bits{i}");
                    Glob.BaudRate[i] = setting.ReadData("COMMUNICATION", $"Baud Rate{i}");
                }

                //****************************검사 사용유무****************************//
                for (int i = 0; i < 5; i++)
                {
                    if (setting.ReadData("SYSTEM", $"CAM{i + 1} Inspect Used Check", true) == "1")
                        Glob.InspectUsed[i] = true;
                    else
                        Glob.InspectUsed[i] = false;
                }
                if (setting.ReadData("SYSTEM", "OK IMAGE SAVE", true) == "1")
                    Glob.OKImageSave = true;
                else
                    Glob.OKImageSave = false;

                if (setting.ReadData("SYSTEM", "NG IMAGE SAVE", true) == "1")
                    Glob.NGImageSave = true;
                else
                    Glob.NGImageSave = false;

                for (int i = 0; i < 5; i++)
                {
                    if (setting.ReadData("SYSTEM", $"검사툴 {i}", true) == "1")
                        Glob.AllToolInspectUsed[i] = true;
                    else
                        Glob.AllToolInspectUsed[i] = false;
                }
                Glob.SelectPCNumber = Convert.ToInt32(setting.ReadData("SYSTEM", "PCNumber"));
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }

        #region CAM1 Events
        private void onConnectionLost(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM1 Connection Lost");
        }
        private void onCameraOpened(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM1 Close");
            //StatsCheck("CAM1 Close", true);
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 GrabStart");
        }

        private void onImageGrabbed(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.

            try
            {
                InspectTime[0] = new Stopwatch();
                InspectTime[0].Reset();
                InspectTime[0].Start();

                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    string Result = "";
                    //if (!Stopwatch.IsRunning || Stopwatch.ElapsedMilliseconds > 33)
                    //{
                    //Stopwatch.Restart();
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);

                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    //Image Type Check
                    if (Glob.ImageType[0] == true)
                        Monoimage[0] = new CogImage8Grey(Image);
                    else
                        Colorimage[0] = new CogImage24PlanarColor(Image);

                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        if (Glob.ImageType[0] == true)
                            frm_toolsetup.cdyDisplay.Image = Monoimage[0];
                        else
                            frm_toolsetup.cdyDisplay.Image = Colorimage[0];
                        //StopLive(0);
                    }
                    else
                    {
                        Image = null;
                        if (Glob.ImageType[0] == true)
                            cdyDisplay.Image = Monoimage[0];
                        else
                            cdyDisplay.Image = Colorimage[0];
                        //INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
                        //Glob.LightCH[1, 2] = Convert.ToInt32(CamSet.ReadData($"LightControl{Glob.LightControlNumber}", "CH3"));
                        //LightValueChange(Glob.LightCH[1, 2], LightControl[1]);

                        if (Inspect_Cam0(cdyDisplay) == true)
                        {
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam1_Result.BackColor = Color.Lime;
                                lb_Cam1_Result.Text = "O K";
                                OK_Count[0]++;
                                if (Glob.OKImageSave)
                                    ImageSave1(Result, 1, cdyDisplay);
                            });
                            Glob.CAM1_Inspect = true;
                        }
                        else
                        {
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam1_Result.BackColor = Color.Red;
                                lb_Cam1_Result.Text = "N G";
                                NG_Count[0]++;
                                if (Glob.NGImageSave)
                                    ImageSave1(Result, 1, cdyDisplay);
                            });
                            Glob.CAM1_Inspect = false;
                        }
                        //ImageSave1(Result, 3, cdyDisplay);
                       
                        InspectTime[0].Stop();
                        BeginInvoke((Action)delegate { lb_Cam1_InsTime.Text = InspectTime[0].ElapsedMilliseconds.ToString() + "msec"; });
                        //DataSave();
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} : {ee.Message}");
            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 GrabStop");

            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM2 Events
        private void onConnectionLost2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost2), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 Connection Lost");
        }

        private void onCameraOpened2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM2 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed2(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed2), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            //StatsCheck("CAM2 Inspect Start", false);
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.

            try
            {
                InspectTime[1] = new Stopwatch();
                InspectTime[1].Reset();
                InspectTime[1].Start();

                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    //Image Type Check
                    if (Glob.ImageType[1] == true)
                        Monoimage[1] = new CogImage8Grey(Image);
                    else
                        Colorimage[1] = new CogImage24PlanarColor(Image);
                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        if (Glob.ImageType[1] == true)
                            frm_toolsetup.cdyDisplay.Image = Monoimage[1];
                        else
                            frm_toolsetup.cdyDisplay.Image = Colorimage[1];
                        //StopLive(1);
                    }
                    else
                    {
                        Image = null;
                        if (Glob.ImageType[1] == true)
                            cdyDisplay2.Image = Monoimage[1];
                        else
                            cdyDisplay2.Image = Colorimage[1];
                        if (Inspect_Cam1(cdyDisplay2) == true)
                        {
                            //1번 Vision 검사결과 OK
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam2_Result.BackColor = Color.Lime;
                                lb_Cam2_Result.Text = "O K";
                                OK_Count[1]++;
                                if (Glob.OKImageSave)
                                    ImageSave2(Result, 2, cdyDisplay2);
                            });
                        }
                        else
                        {
                            //1번 Vision 검사결과 NG
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam2_Result.BackColor = Color.Red;
                                lb_Cam2_Result.Text = "N G";
                                NG_Count[1]++;
                                if (Glob.NGImageSave)
                                    ImageSave2(Result, 2, cdyDisplay2);
                            });
                        }
                        //ImageSave2(Result, 4, cdyDisplay2);
                        InspectTime[1].Stop();
                        BeginInvoke((Action)delegate { lb_Cam2_InsTime.Text = InspectTime[1].ElapsedMilliseconds.ToString() + "msec"; });
                        //Glob.CAM2_Inspect = false;
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped2(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 GrabStop");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM3 Events
        private void onConnectionLost3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost3), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM3 Connection Lost");
        }

        private void onCameraOpened3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM3 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed3(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed3), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.
            try
            {
                InspectTime[2] = new Stopwatch();
                InspectTime[2].Reset();
                InspectTime[2].Start();

                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    if (Glob.ImageType[2] == true)
                        Monoimage[2] = new CogImage8Grey(Image);
                    else
                        Colorimage[2] = new CogImage24PlanarColor(Image);
                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        if (Glob.ImageType[2] == true)
                            frm_toolsetup.cdyDisplay.Image = Monoimage[2];
                        else
                            frm_toolsetup.cdyDisplay.Image = Colorimage[2];
                        //StopLive(2);
                    }
                    else
                    {
                        Image = null;
                        if (Glob.ImageType[2] == true)
                            cdyDisplay3.Image = Monoimage[2];
                        else
                            cdyDisplay3.Image = Colorimage[2];
                        if (Inspect_Cam2(cdyDisplay3) == true)
                        {
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam3_Result.BackColor = Color.Lime;
                                lb_Cam3_Result.Text = "O K";
                                OK_Count[2]++;
                                if (Glob.OKImageSave)
                                    ImageSave3(Result, 3, cdyDisplay3);
                            });
                        }
                        else
                        {
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam3_Result.BackColor = Color.Red;
                                lb_Cam3_Result.Text = "N G";
                                NG_Count[2]++;
                                if (Glob.NGImageSave)
                                    ImageSave3(Result, 3, cdyDisplay3);
                            });
                        }
                        //ImageSave3(Result, 5, cdyDisplay3);
                        InspectTime[2].Stop();
                        BeginInvoke((Action)delegate { lb_Cam3_InsTime.Text = InspectTime[2].ElapsedMilliseconds.ToString() + "msec"; });
                        //Glob.CAM3_Inspect = false;
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped3(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 Stop");
            SendToPLC($"SBCM{orderNumberSignal[Glob.InspectOrder - 1] + 1}");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM4 Events
        private void onConnectionLost4(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost4), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM4 Connection Lost");
        }

        private void onCameraOpened4(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened4), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM4 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed4(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed4), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM4 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted4(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted4), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM4 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed4(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed4), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.
            try
            {
                InspectTime[3] = new Stopwatch();
                InspectTime[3].Reset();
                InspectTime[3].Start();
                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);

                    if (Glob.ImageType[3] == true)
                        Monoimage[3] = new CogImage8Grey(Image);
                    else
                        Colorimage[3] = new CogImage24PlanarColor(Image);
                    // 실제 사용 하려면 이 부분에서 다른 방법으로 처리 필요. 이벤트 방식이라 이미지용 전역 변수 하나 필요할지도 모름.
                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        if (Glob.ImageType[3] == true)
                            frm_toolsetup.cdyDisplay.Image = Monoimage[3];
                        else
                            frm_toolsetup.cdyDisplay.Image = Colorimage[3];
                        //StopLive(3);
                    }
                    else
                    {
                        Image = null;
                        if (Glob.ImageType[3] == true)
                            cdyDisplay4.Image = Monoimage[3];
                        else
                            cdyDisplay4.Image = Colorimage[3];

                        if (Inspect_Cam3(cdyDisplay4) == true)
                        {
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam4_Result.BackColor = Color.Lime;
                                lb_Cam4_Result.Text = "O K";
                                OK_Count[3]++;
                                if (Glob.OKImageSave)
                                    ImageSave4(Result, 4, cdyDisplay4);
                            });
                        }
                        else
                        {
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam4_Result.BackColor = Color.Red;
                                lb_Cam4_Result.Text = "N G";
                                NG_Count[3]++;
                                if (Glob.NGImageSave)
                                    ImageSave4(Result, 4, cdyDisplay4);
                            });
                        }
                        //ImageSave4(Result, 6, cdyDisplay4);
                        InspectTime[3].Stop();
                        BeginInvoke((Action)delegate { lb_Cam4_InsTime.Text = InspectTime[3].ElapsedMilliseconds.ToString() + "msec"; });
                        //Glob.CAM4_Inspect = false;
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();

            }
            return;
        }

        private void onGrabStopped4(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped4), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM4 GrabStop");
            SendToPLC($"SKCM{orderNumberSignal[Glob.InspectOrder - 1] + 1}");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM5 Events
        private void onConnectionLost5(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost5), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM5 Connection Lost");
        }

        private void onCameraOpened5(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened5), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM5 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed5(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed5), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM5 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted5(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted5), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM5 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed5(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed5), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            //StatsCheck("CAM2 Inspect Start", false);
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.
            try
            {
                if (!Glob.AligneMode)
                {
                    InspectTime[4] = new Stopwatch();
                    InspectTime[4].Reset();
                    InspectTime[4].Start();
                }
                
                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    if (Glob.ImageType[4] == true)
                        Monoimage[4] = new CogImage8Grey(Image);
                    else
                        Colorimage[4] = new CogImage24PlanarColor(Image);

                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        if (Glob.ImageType[4] == true)
                            frm_toolsetup.cdyDisplay.Image = Monoimage[4];
                        else
                            frm_toolsetup.cdyDisplay.Image = Colorimage[4];

                        //StopLive(4);
                    }
                    else
                    {
                        Image = null;
                        if (Glob.ImageType[4] == true)
                            cdyDisplay5.Image = Monoimage[4];
                        else
                            cdyDisplay5.Image = Colorimage[4];
                        cdyDisplay5.Image = Monoimage[4];

                        if (Glob.AligneMode)
                        {
                            double angle = CheckAngle(cdyDisplay5);

                            lb_Cam5_Result.Text = angle.ToString("F2") + "도"; //표시는 double로
                            lb_Cam5_Result.BackColor = Color.Gray;

                            int intAngle = (int)Math.Ceiling(angle); //반올림해서 정수형으로 변환   
                                                               
                            string strSendPLC = $"UC{Glob.topAlignNumber}P{intAngle.ToString("D4")}"; //4자리로 맞추고 빈자리는 0으로 채우기
                            SendToPLC(strSendPLC); //PLC로 전송                        
                            Glob.AligneMode = false; //얼라인모드 bool함수 초기화
                            ImageSave5("AlignMode", 5, cdyDisplay5);
                        }
                        else
                        {
                            if (Inspect_Cam4(cdyDisplay5) == true)
                            {
                                Result = "OK";
                                BeginInvoke((Action)delegate
                                {
                                    lb_Cam5_Result.BackColor = Color.Lime;
                                    lb_Cam5_Result.Text = "O K";
                                    OK_Count[4]++;
                                    if (Glob.OKImageSave)
                                        ImageSave5(Result, 5, cdyDisplay5);
                                });
                            }
                            else
                            {
                                Result = "NG";
                                BeginInvoke((Action)delegate
                                {
                                    lb_Cam5_Result.BackColor = Color.Red;
                                    lb_Cam5_Result.Text = "N G";
                                    NG_Count[4]++;
                                    if (Glob.NGImageSave)
                                        ImageSave5(Result, 5, cdyDisplay5);
                                });
                            }
                            //ImageSave5(Result, 7, cdyDisplay5);
                            InspectTime[4].Stop();
                            BeginInvoke((Action)delegate { lb_Cam5_InsTime.Text = InspectTime[4].ElapsedMilliseconds.ToString() + "msec"; });
                            //Glob.CAM5_Inspect = false;
                        }
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }


        public double CheckAngle(CogDisplay setCog)
        {
            //각도 추출하는 함수 추가.
            if (TempMulti[4, 0].Run((CogImage8Grey)setCog.Image))
            {
                TempMulti[4,0].ResultDisplay(ref setCog, TempMulti[4, 0].HighestResultToolNumber());
                double topAngle = TempMulti[4, 0].PatternAngle(TempMulti[4, 0].HighestResultToolNumber());
                return topAngle;
            }
            else
            {
                return 0;
            }
        }

        private void onGrabStopped5(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped5), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM5 GrabStop");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        private void btn_ToolSetUp_Click(object sender, EventArgs e)
        {
            frm_toolsetup = new Frm_ToolSetUp(this);
            frm_toolsetup.Show();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            INIControl setting = new INIControl(Glob.SETTING);
            DateTime dt = DateTime.Now;
            setting.WriteData("Exit Date", "Date", dt.ToString("yyyyMMdd"));
            Application.Exit();
        }

        private void btn_SystemSetup_Click(object sender, EventArgs e)
        {
            Frm_SystemSetUp FrmSystemSetUp = new Frm_SystemSetUp(this);
            FrmSystemSetUp.Show();
        }

        private void timer_Setting_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (dt.Day == ChangeDateTime.Day)
            {
                DataSave1(dt.AddDays(-1));
            }
            ChangeDateTime = dt.AddDays(1);
            lb_Time.Text = dt.ToString("yyyy년 MM월 dd일 HH:mm:ss"); //현재날짜
            lb_CurruntModelName.Text = Glob.RunnModel.Modelname(); //현재사용중인 모델명 체크
            Glob.CurruntModelName = Glob.RunnModel.Modelname();
            lb_Mode.Text = AutoRun == true ? "AUTO RUN" : "MANUAL";
            lb_Mode.BackColor = AutoRun == true ? Color.Lime : Color.Red;
            lb_PLCStats.BackColor = PLCConnected == true ? Color.Lime : Color.Red;
            btnConnect.BackColor = PLCConnected == true ? Color.Lime : Color.Red;
            btn_Light.BackColor = LightStats == true ? Color.Lime : Color.Red;

            for (int i = 0; i < AllCams.Count; i++)
            {
                OK_Label[i].Text = OK_Count[i].ToString();
                NG_Label[i].Text = NG_Count[i].ToString();
                TOTAL_Count[i] = OK_Count[i] + NG_Count[i];
                TOTAL_Label[i].Text = (OK_Count[i] + NG_Count[i]).ToString();

                if (NG_Count[i] != 0)
                {
                    NG_Rate[i] = (NG_Count[i] / TOTAL_Count[i]) * 100;
                    NGRATE_Label[i].Text = NG_Rate[i].ToString("F1") + "%";
                }
            }
            for (int i = 0; i < 5; i++)
            {
                //CameraStats_Label[i].BackColor = CameraStats[i] == true ? Color.Lime : Color.Red;
            }
            btn_PC1.BackColor = Glob.SelectPCNumber == 1 ? Color.Lime : Color.Red;
            btn_PC2.BackColor = Glob.SelectPCNumber == 2 ? Color.Lime : Color.Red;
        }
        public static byte[] HextoByte(string hex)
        {
            byte[] convert = new byte[hex.Length / 2];
            int length = convert.Length;
            for (int i = 0; i < length; i++)
            {
                convert[i] = Convert.ToByte(hex.Substring(i * 2), 16);
            }

            return convert;
        }

        private void btn_Status_Click(object sender, EventArgs e)
        {
            if (Glob.SelectPCNumber == 1 || Glob.SelectPCNumber == 2)
            {
                log.AddLogMessage(LogType.Infomation, 0, "AUTO MODE START");
                AutoRun = true;
                btn_Status.Enabled = false;
                btn_ToolSetUp.Enabled = false;
                btn_Model.Enabled = false;
                btn_SystemSetup.Enabled = false;
                btn_Stop.Enabled = true;
                CognexModelLoad();
                LightON(LightControl[0],0);
                LightON(LightControl[1],1);
            }
            else
            {
                log.AddLogMessage(LogType.Error, 0, "PC 번호를 설정 해 주시기 바랍니다.");
            }
        }

        public void Bolb_Train1(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage1((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train2(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage2((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train3(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage3((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train4(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage4((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train5(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage5((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void CognexModelLoad()
        {
            Glob = PGgloble.getInstance;
            TempModel = Glob.RunnModel;
            TempLines = TempModel.Line();
            TempLineEnable = TempModel.LineEnables();
            TempBlobs = TempModel.Blob();
            TempBlobEnable = TempModel.BlobEnables();
            TempBlobOKCount = TempModel.BlobOKCounts();
            TempBlobFixPatternNumber = TempModel.BlobFixPatternNumbers();
            TempCircles = TempModel.Circle();
            TempCircleEnable = TempModel.CircleEnables();
            TempMulti = TempModel.MultiPatterns();
            TempMultiEnable = TempModel.MultiPatternEnables();
            TempMultiOrderNumber = TempModel.MultiPatternOrderNumbers();
        }

        #region Inpection CAM0 
        public bool Inspect_Cam0(CogDisplay cog)
        {
            //if (!Glob.InspectUsed[0] && frm_toolsetup == null)
            //    return true;

            int CameraNumber = 0;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            Glob.PatternTool[CameraNumber] = true;
            Glob.BlobTool[CameraNumber] = true;
            CogGraphicCollection Collection = new CogGraphicCollection();
            string[] temp = new string[30];
            if (Glob.AllToolInspectUsed[0]) //다중 패턴
            {
                if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image)) //기본패턴 등록해두기.
                {
                    Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
                }
                //*******************************MultiPattern Tool Run******************************//
                if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
                {
                    for (int lop = 0; lop < 30; lop++)
                    {
                        if (TempMultiEnable[CameraNumber, lop] == true && TempMultiOrderNumber[CameraNumber,lop] == Glob.InspectOrder)
                        {
                            if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                            {
                                InspectResult[CameraNumber] = false;
                                Glob.PatternTool[CameraNumber] = false;
                            }
                        }
                    }
                }
                else
                {
                    InspectResult[CameraNumber] = false;
                    Glob.PatternTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[1]) //블롭 툴
            {
                //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
                for (int toolnum = 0; toolnum < 29; toolnum++)
                {
                    if (TempBlobEnable[CameraNumber, toolnum])
                    {
                        Bolb_Train1(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                        TempBlobs[CameraNumber, toolnum].Area_Affine_Main1(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                    }
                }

                if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    //BLOB 검사 FAIL
                    InspectResult[CameraNumber] = false;
                    Glob.BlobTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[2])
            {
                if (TempModel.Histogram_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[3])
            {
                if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }

            if (Glob.AllToolInspectUsed[4])
            {
                if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
                {

                }
                else
                {
                    //LINE 검사 FAIL
                    InspectResult[CameraNumber] = false;
                }
            }

            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            cog.StaticGraphics.AddList(Collection, "");

            return InspectResult[CameraNumber];
        }
        #endregion 

        #region Inpection CAM1 
        public bool Inspect_Cam1(CogDisplay cog)
        {
            //if (!Glob.InspectUsed[1] && frm_toolsetup == null)
            //    return true;

            int CameraNumber = 1;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            Glob.PatternTool[CameraNumber] = true;
            Glob.BlobTool[CameraNumber] = true;
            CogGraphicCollection Collection = new CogGraphicCollection();
            string[] temp = new string[30];
            if (Glob.AllToolInspectUsed[0]) //다중 패턴
            {
                if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
                {
                    Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
                }
                //*******************************MultiPattern Tool Run******************************//
                if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
                {
                    for (int lop = 0; lop < 30; lop++)
                    {
                        if (TempMultiEnable[CameraNumber, lop] == true && TempMultiOrderNumber[CameraNumber,lop] == Glob.InspectOrder)
                        {
                            if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                            {
                                InspectResult[CameraNumber] = false;
                                Glob.PatternTool[CameraNumber] = false;
                            }
                        }
                    }
                }
                else
                {
                    InspectResult[CameraNumber] = false;
                    Glob.PatternTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[1])
            {
                //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
                for (int toolnum = 0; toolnum < 29; toolnum++)
                {
                    if (TempBlobEnable[CameraNumber, toolnum])
                    {
                        Bolb_Train2(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                        TempBlobs[CameraNumber, toolnum].Area_Affine_Main2(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                    }
                }
                if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    //BLOB 검사 FAIL
                    InspectResult[CameraNumber] = false;
                    Glob.BlobTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[2])
            {
                if (TempModel.Histogram_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[3])
            {
                if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[4])
            {
                if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
                {

                }
                else
                {
                    //LINE 검사 FAIL
                    InspectResult[CameraNumber] = false;
                }
            }

            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            cog.StaticGraphics.AddList(Collection, "");
            return InspectResult[CameraNumber];
        }
        #endregion 

        #region Inpection CAM2 
        public bool Inspect_Cam2(CogDisplay cog)
        {
            //if (!Glob.InspectUsed[2] && frm_toolsetup == null)
            //    return true;

            int CameraNumber = 2;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            Glob.PatternTool[CameraNumber] = true;
            Glob.BlobTool[CameraNumber] = true;
            CogGraphicCollection Collection = new CogGraphicCollection();
            string[] temp = new string[30];
            if (Glob.AllToolInspectUsed[0])
            {
                if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
                {
                    Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
                }
                //*******************************MultiPattern Tool Run******************************//
                if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
                {
                    for (int lop = 0; lop < 30; lop++)
                    {
                        if (TempMultiEnable[CameraNumber, lop] == true && TempMultiOrderNumber[CameraNumber, lop] == Glob.InspectOrder)
                        {
                            if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                            {
                                InspectResult[CameraNumber] = false;
                                Glob.PatternTool[CameraNumber] = false;
                            }
                        }
                    }
                }
                else
                {
                    InspectResult[CameraNumber] = false;
                    Glob.PatternTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[1])
            {
                //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
                for (int toolnum = 0; toolnum < 29; toolnum++)
                {
                    if (TempBlobEnable[CameraNumber, toolnum])
                    {
                        Bolb_Train3(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                        TempBlobs[CameraNumber, toolnum].Area_Affine_Main3(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                    }
                }
                //******************************Blob Tool Run******************************//
                if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    //BLOB 검사 FAIL
                    InspectResult[CameraNumber] = false;
                    Glob.BlobTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[2])
            {
                if (TempModel.Histogram_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[3])
            {
                if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[4])
            {
                if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
                {

                }
                else
                {
                    //LINE 검사 FAIL
                    InspectResult[CameraNumber] = false;
                }
            }


            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            cog.StaticGraphics.AddList(Collection, "");
            return InspectResult[CameraNumber];
        }
        #endregion

        #region Inpection CAM3 
        public bool Inspect_Cam3(CogDisplay cog)
        {
            //if (!Glob.InspectUsed[3] && frm_toolsetup == null)
            //    return true;

            int CameraNumber = 3;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            Glob.PatternTool[CameraNumber] = true;
            Glob.BlobTool[CameraNumber] = true;
            CogGraphicCollection Collection = new CogGraphicCollection();
            string[] temp = new string[30];
            if (Glob.AllToolInspectUsed[0])
            {
                if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
                {
                    Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
                }
                //*******************************MultiPattern Tool Run******************************//
                if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
                {
                    for (int lop = 0; lop < 30; lop++)
                    {
                        if (TempMultiEnable[CameraNumber, lop] == true && TempMultiOrderNumber[CameraNumber, lop] == Glob.InspectOrder)
                        {
                            if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                            {
                                InspectResult[CameraNumber] = false;
                                Glob.PatternTool[CameraNumber] = false;
                            }
                        }
                    }
                }
                else
                {
                    InspectResult[CameraNumber] = false;
                    Glob.PatternTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[1])
            {
                //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
                for (int toolnum = 0; toolnum < 29; toolnum++)
                {
                    if (TempBlobEnable[CameraNumber, toolnum])
                    {
                        Bolb_Train4(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                        TempBlobs[CameraNumber, toolnum].Area_Affine_Main4(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                    }
                }
                //******************************Blob Tool Run******************************//
                if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    //BLOB 검사 FAIL
                    InspectResult[CameraNumber] = false;
                    Glob.BlobTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[2])
            {
                if (TempModel.Histogram_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[3])
            {
                if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[4])
            {
                if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
                {

                }
                else
                {
                    //LINE 검사 FAIL
                    InspectResult[CameraNumber] = false;
                }
            }


            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            cog.StaticGraphics.AddList(Collection, "");
            return InspectResult[CameraNumber];
        }
        #endregion 

        #region Inpection CAM4 
        public bool Inspect_Cam4(CogDisplay cog)
        {
            //if (!Glob.InspectUsed[4] && frm_toolsetup == null)
            //    return true;

            int CameraNumber = 4;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            Glob.PatternTool[CameraNumber] = true;
            Glob.BlobTool[CameraNumber] = true;
            CogGraphicCollection Collection = new CogGraphicCollection();
            string[] temp = new string[30];
            if (Glob.AllToolInspectUsed[0])
            {
                if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
                {
                    Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
                }
                //*******************************MultiPattern Tool Run******************************//
                if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
                {
                    for (int lop = 0; lop < 30; lop++)
                    {
                        if (TempMultiEnable[CameraNumber, lop] == true && TempMultiOrderNumber[CameraNumber, lop] == Glob.InspectOrder)
                        {
                            if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                            {
                                InspectResult[CameraNumber] = false;
                                Glob.PatternTool[CameraNumber] = false;
                            }
                        }
                    }
                }
                else
                {
                    InspectResult[CameraNumber] = false;
                    Glob.PatternTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[1])
            {
                //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
                for (int toolnum = 0; toolnum < 29; toolnum++)
                {
                    if (TempBlobEnable[CameraNumber, toolnum])
                    {
                        Bolb_Train5(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                        TempBlobs[CameraNumber, toolnum].Area_Affine_Main5(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                    }
                }
                //******************************Blob Tool Run******************************//
                if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    //BLOB 검사 FAIL
                    InspectResult[CameraNumber] = false;
                    Glob.BlobTool[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[2])
            {
                if (TempModel.Histogram_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[3])
            {
                if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
                {

                }
                else
                {
                    InspectResult[CameraNumber] = false;
                }
            }
            if (Glob.AllToolInspectUsed[4])
            {
                if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
                {

                }
                else
                {
                    //LINE 검사 FAIL
                    InspectResult[CameraNumber] = false;
                }
            }


            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            cog.StaticGraphics.AddList(Collection, "");
            return InspectResult[CameraNumber];
        }
        #endregion 

        public void DgvResult(DataGridView dgv, int camnumber, int cellnumber)
        {
            if (frm_toolsetup != null)
            {
                for (int i = 0; i < 30; i++)
                {
                    if (TempBlobEnable[camnumber, i] == true)
                    {
                        if (TempBlobs[camnumber, i].ResultBlobCount() != TempBlobOKCount[camnumber, i]) // - 검사결과 NG
                        {
                            dgv.Rows[i].Cells[3].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[3].Style.BackColor = Color.Red;
                        }
                        else // - 검사결과 OK
                        {
                            dgv.Rows[i].Cells[3].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[3].Value = "NOT USED";
                        dgv.Rows[i].Cells[3].Style.BackColor = SystemColors.Control;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    if (TempBlobEnable[camnumber, i] == true)
                    {
                        if (TempBlobs[camnumber, i].ResultBlobCount() != TempBlobOKCount[camnumber, i]) // - 검사결과 NG
                        {
                            dgv.Rows[i].Cells[cellnumber + 1].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = Color.Red;
                        }
                        else // - 검사결과 OK
                        {
                            dgv.Rows[i].Cells[cellnumber + 1].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = Color.Lime;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[cellnumber + 1].Value = "NOT USED";
                        dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = SystemColors.Control;
                    }
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (TempMultiEnable[camnumber, i] == true && TempMultiOrderNumber[camnumber,i] == Glob.InspectOrder)
                {
                    if (TempMulti[camnumber, i].ResultPoint(TempMulti[camnumber, i].HighestResultToolNumber()) != null)
                    {
                        if (Glob.MultiInsPat_Result[camnumber, i] > TempMulti[camnumber, i].Threshold() * 100)
                        {
                            dgv.Rows[i].Cells[cellnumber].Value = Glob.MultiInsPat_Result[camnumber, i].ToString("F2");
                            dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            dgv.Rows[i].Cells[cellnumber].Value = Glob.MultiInsPat_Result[camnumber, i].ToString("F2");
                            dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Red;
                            InspectResult[camnumber] = false;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[cellnumber].Value = "NG";
                        dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Red;
                        InspectResult[camnumber] = false;
                    }
                }
                else
                {
                    dgv.Rows[i].Cells[cellnumber].Value = "NOT USED";
                    dgv.Rows[i].Cells[cellnumber].Style.BackColor = SystemColors.Control;
                }
            }
        }
        public void DisplayLabelShow(CogGraphicCollection Collection, CogDisplay cog, int X, int Y, string Text)
        {
            CogCreateGraphicLabelTool Label = new CogCreateGraphicLabelTool();
            Label.InputGraphicLabel.Color = Cognex.VisionPro.CogColorConstants.Green;
            Label.InputImage = cog.Image;
            Label.InputGraphicLabel.X = X;
            Label.InputGraphicLabel.Y = Y;
            Label.InputGraphicLabel.Text = Text;
            Label.Run();
            Collection.Add(Label.GetOutputGraphicLabel());
        }
        public void ImageSave1(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //log.AddLogFileList(ee.Message);
            }
        }
        public void ImageSave2(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }
        public void ImageSave3(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }
        public void ImageSave4(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }
        public void ImageSave5(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }

        public void DataSave1(DateTime dt)
        {
            //DATA 저장부분 TEST 후 적용 시키기.
            //DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot + $@"\{Glob.CurruntModelName}\{dt.ToString("yyyyMM")}";
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            Root += $@"\CountData_{dt.ToString("yyyyMMdd")}.csv";
            Writer = new StreamWriter(Root, true);
            for (int i = 0; i < AllCams.Count(); i++)
            {
                Writer.WriteLine($"CAM{i},TOTAL,{TOTAL_Count[i].ToString()},OK,{OK_Count[i].ToString()},NG,{NG_Count[i].ToString()},NGRate,{NG_Rate[i].ToString()}");
                OK_Count[i] = 0;
                NG_Count[i] = 0;
                NG_Rate[i] = 0;
            }
           
            Writer.Close();
        }

        public void ErrorLogSave()
        {
            DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot;
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            Root += $@"\ErrorLog_{dt.ToString("yyyyMMdd-HH")}.csv";
            Writer = new StreamWriter(Root, true);
            Writer.WriteLine($"Time,{dt.ToString("yyyyMMdd_HH mm ss")}");
            Writer.Close();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            log.AddLogMessage(LogType.Infomation, 0, "AUTO MODE STOP");
            AutoRun = false;
            btn_Stop.Enabled = false;
            btn_ToolSetUp.Enabled = true;
            btn_Model.Enabled = true;
            btn_SystemSetup.Enabled = true;
            btn_Status.Enabled = true;
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
            //MODEL FORM 열기.
            Frm_Model frm_model = new Frm_Model(Glob.RunnModel.Modelname(), this);
            frm_model.Show();
        }

        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            //****************************단축키 모음****************************//
            if (e.Control && e.KeyCode == Keys.T) //ctrl + t : 툴셋팅창 열기
                btn_ToolSetUp.PerformClick();
            if (e.Control && e.KeyCode == Keys.M) //ctrl + m : 모델창 열기
                btn_Model.PerformClick();
            if (e.Control && e.KeyCode == Keys.C) //ctrl + c : 카메라 셋팅창 열기.
                btn_CamList_Click(sender, e);
            if (e.KeyCode == Keys.Escape) // esc : 프로그램 종료
                btn_Exit.PerformClick();
        }

        private void btn_CamList_Click(object sender, EventArgs e)
        {
            Frm_CamSet frm_camset = new Frm_CamSet(this);
            if (frm_camset.ShowDialog() == DialogResult.OK)
            {
                //Camera Serial Number Setting 이후 프로그램 재시작하여, Camera 연결.
                Application.Restart(); //프로그램 재시작
            }
            else
            {

            }
        }
        private void Frm_Main_Paint(object sender, PaintEventArgs e)
        {
            if (frm_loading != null)
            {
                frm_loading.Close();
                frm_loading.Dispose();
                frm_loading = null;
            }
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            int jobNo = Convert.ToInt16((sender as Button).Tag);
            Main_TabControl.SelectedIndex = jobNo;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectPLC(); //PLC 연결 및 해제.
        }
        public void LightValueChange(int lightvalue, SerialPort LightControl)
        {
            try
            {
                if (LightControl.IsOpen == false)
                {
                    return;
                }
                LightStats = true;
                string Str1 = Glob.LightCH[Glob.LightControlNumber, 0].ToString("X");
                string Str2 = Glob.LightCH[Glob.LightControlNumber, 1].ToString("X");
                string Str3 = Glob.LightCH[Glob.LightControlNumber, 2].ToString("X");
                string Str4 = Glob.LightCH[Glob.LightControlNumber, 3].ToString("X");
                byte[] temp = new byte[10];
                temp[0] = 0x3A;
                temp[1] = 0x3A;
                temp[2] = 0x00;
                temp[3] = Convert.ToByte(Str1.Substring(0), 16);
                temp[4] = Convert.ToByte(Str2.Substring(0), 16);
                temp[5] = Convert.ToByte(Str3.Substring(0), 16);
                temp[6] = Convert.ToByte(Str4.Substring(0), 16);
                int checksum = temp[2] ^ temp[3] ^ temp[4] ^ temp[5] ^ temp[6];
                temp[7] = (byte)checksum;
                temp[8] = 0xEE;
                temp[9] = 0xEE;

                LightControl.Write(temp, 0, 10);
            }
            catch(Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, ee.Message);
            }
        }
        public void LightON(SerialPort LightControl,int Number)
        {
            if (LightControl.IsOpen == false)
            {
                return;
            }
            LightStats = true;
            string Str1 = Glob.LightCH[Number, 0].ToString("X");
            string Str2 = Glob.LightCH[Number, 1].ToString("X");
            string Str3 = Glob.LightCH[Number, 2].ToString("X");
            string Str4 = Glob.LightCH[Number, 3].ToString("X");
            byte[] temp = new byte[10];
            temp[0] = 0x3A;
            temp[1] = 0x3A;
            temp[2] = 0x00;
            temp[3] = Convert.ToByte(Str1.Substring(0), 16);
            temp[4] = Convert.ToByte(Str2.Substring(0), 16);
            temp[5] = Convert.ToByte(Str3.Substring(0), 16);
            temp[6] = Convert.ToByte(Str4.Substring(0), 16);
            int checksum = temp[2] ^ temp[3] ^ temp[4] ^ temp[5] ^ temp[6];
            temp[7] = (byte)checksum;
            temp[8] = 0xEE;
            temp[9] = 0xEE;

            LightControl.Write(temp, 0, 10);
        }
        public void LightOFF(SerialPort LightControl)
        {
            if (LightControl.IsOpen == false)
            {
                return;
            }
            LightStats = false;
            byte[] temp = new byte[10];
            temp[0] = 0x3A;
            temp[1] = 0x3A;
            temp[2] = 0x00;
            temp[3] = 0x00;
            temp[4] = 0x00;
            temp[5] = 0x00;
            temp[6] = 0x00;
            int checksum = temp[2] ^ temp[3] ^ temp[4] ^ temp[5] ^ temp[6];
            temp[7] = (byte)checksum;
            temp[8] = 0xEE;
            temp[9] = 0xEE;

            LightControl.Write(temp, 0, 10);
        }

        private void btn_Light_Click(object sender, EventArgs e)
        {
            if (LightControl[Glob.LightControlNumber].IsOpen == false)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - LightControl Not Connected");
                //cm.info("LightControl Not Connected");
                return;
            }
            if (LightStats == false)
            {
                LightON(LightControl[Glob.LightControlNumber], Glob.LightControlNumber);
            }
            else
            {
                LightOFF(LightControl[Glob.LightControlNumber]);
            }
        }

        private void num_LightNumber_ValueChanged(object sender, EventArgs e)
        {
            Glob.LightControlNumber = (int)num_LightNumber.Value;
        }

        private void btn_ReconnectCam_Click(object sender, EventArgs e)
        {
            DistoryCamera();
            Thread.Sleep(50);
            Initialize_CamvalueInit();
            Initialize_CameraInit();
        }

        private void btn_PC1_Click(object sender, EventArgs e)
        {
            INIControl Writer = new INIControl(this.Glob.SETTING);
            int jobNo = Convert.ToInt16((sender as Button).Tag);
            Glob.SelectPCNumber = jobNo;

            Writer.WriteData("SYSTEM", "PCNumber", Glob.SelectPCNumber.ToString());
        }

        private void lb_Cam1Stats_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string type = Path.GetExtension(ofd.FileName);
                if (type == ".bmp")
                {
                    CogImageFileBMP Imageopen = new CogImageFileBMP();
                    Imageopen.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    //Oriimage = (Cognex.VisionPro.CogImage24PlanarColor)Imageopen[0];
                    Monoimage[0] = (CogImage8Grey)Imageopen[0];
                    Imageopen.Close();
                }
                else
                {
                    CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    Monoimage[0] = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                //Monoimage = TempModel.Imageconvert(Oriimage);
                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();
                cdyDisplay.Image = Monoimage[0];
                if (Inspect_Cam0(cdyDisplay) == true)
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam1_Result.BackColor = Color.Lime;
                        lb_Cam1_Result.Text = "O K";
                        OK_Count[0]++;
                    });
                    Glob.CAM1_Inspect = true;
                }
                else
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam1_Result.BackColor = Color.Red;
                        lb_Cam1_Result.Text = "N G";
                        NG_Count[0]++;
                    });
                    Glob.CAM1_Inspect = false;
                }
            }
        }

        private void lb_Cam2Stats_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string type = Path.GetExtension(ofd.FileName);
                if (type == ".bmp")
                {
                    CogImageFileBMP Imageopen = new CogImageFileBMP();
                    Imageopen.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    //Oriimage = (Cognex.VisionPro.CogImage24PlanarColor)Imageopen[0];
                    Monoimage[1] = (CogImage8Grey)Imageopen[1];
                    Imageopen.Close();
                }
                else
                {
                    CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    Monoimage[0] = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                //Monoimage = TempModel.Imageconvert(Oriimage);
                cdyDisplay2.InteractiveGraphics.Clear();
                cdyDisplay2.StaticGraphics.Clear();
                cdyDisplay2.Image = Monoimage[0];
                if (Inspect_Cam1(cdyDisplay2) == true)
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam2_Result.BackColor = Color.Lime;
                        lb_Cam2_Result.Text = "O K";
                        OK_Count[0]++;
                    });
                    Glob.CAM1_Inspect = true;
                }
                else
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam2_Result.BackColor = Color.Red;
                        lb_Cam2_Result.Text = "N G";
                        NG_Count[0]++;
                    });
                    Glob.CAM1_Inspect = false;
                }
            }
        }

        private void lb_Cam3Stats_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string type = Path.GetExtension(ofd.FileName);
                if (type == ".bmp")
                {
                    CogImageFileBMP Imageopen = new CogImageFileBMP();
                    Imageopen.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    //Oriimage = (Cognex.VisionPro.CogImage24PlanarColor)Imageopen[0];
                    Monoimage[0] = (CogImage8Grey)Imageopen[0];
                    Imageopen.Close();
                }
                else
                {
                    CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    Monoimage[0] = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                //Monoimage = TempModel.Imageconvert(Oriimage);
                cdyDisplay3.InteractiveGraphics.Clear();
                cdyDisplay3.StaticGraphics.Clear();
                cdyDisplay3.Image = Monoimage[0];
                if (Inspect_Cam2(cdyDisplay3) == true)
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam3_Result.BackColor = Color.Lime;
                        lb_Cam3_Result.Text = "O K";
                        OK_Count[0]++;
                    });
                    Glob.CAM1_Inspect = true;
                }
                else
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam3_Result.BackColor = Color.Red;
                        lb_Cam3_Result.Text = "N G";
                        NG_Count[0]++;
                    });
                    Glob.CAM1_Inspect = false;
                }
            }
        }

        private void lb_Cam4Stats_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string type = Path.GetExtension(ofd.FileName);
                if (type == ".bmp")
                {
                   CogImageFileBMP Imageopen = new CogImageFileBMP();
                    Imageopen.Open(ofd.FileName,CogImageFileModeConstants.Read);
                    //Oriimage = (Cognex.VisionPro.CogImage24PlanarColor)Imageopen[0];
                    Monoimage[0] = (CogImage8Grey)Imageopen[0];
                    Imageopen.Close();
                }
                else
                {
                   CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName,CogImageFileModeConstants.Read);
                    Monoimage[0] = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                //Monoimage = TempModel.Imageconvert(Oriimage);
                cdyDisplay4.InteractiveGraphics.Clear();
                cdyDisplay4.StaticGraphics.Clear();
                cdyDisplay4.Image = Monoimage[0];
                if (Inspect_Cam3(cdyDisplay4) == true)
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam4_Result.BackColor = Color.Lime;
                        lb_Cam4_Result.Text = "O K";
                        OK_Count[0]++;
                    });
                    Glob.CAM1_Inspect = true;
                }
                else
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam4_Result.BackColor = Color.Red;
                        lb_Cam4_Result.Text = "N G";
                        NG_Count[0]++;
                    });
                    Glob.CAM1_Inspect = false;
                }
            }
        }

        private void lb_Cam5Stats_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string type = Path.GetExtension(ofd.FileName);
                if (type == ".bmp")
                {
                    CogImageFileBMP Imageopen = new CogImageFileBMP();
                    Imageopen.Open(ofd.FileName,CogImageFileModeConstants.Read);
                    //Oriimage = (Cognex.VisionPro.CogImage24PlanarColor)Imageopen[0];
                    Monoimage[0] = (CogImage8Grey)Imageopen[0];
                    Imageopen.Close();
                }
                else
                {
                   CogImageFileJPEG Imageopen2 = new CogImageFileJPEG();
                    Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                    Monoimage[0] = (CogImage8Grey)Imageopen2[0];
                    Imageopen2.Close();
                }
                //Monoimage = TempModel.Imageconvert(Oriimage);
                cdyDisplay5.InteractiveGraphics.Clear();
                cdyDisplay5.StaticGraphics.Clear();
                cdyDisplay5.Image = Monoimage[0];
                if (Inspect_Cam4(cdyDisplay5) == true)
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam5_Result.BackColor = Color.Lime;
                        lb_Cam5_Result.Text = "O K";
                        OK_Count[0]++;
                    });
                    Glob.CAM1_Inspect = true;
                }
                else
                {
                    BeginInvoke((Action)delegate
                    {
                        lb_Cam5_Result.BackColor = Color.Red;
                        lb_Cam5_Result.Text = "N G";
                        NG_Count[0]++;
                    });
                    Glob.CAM1_Inspect = false;
                }
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bk_Signal.IsBusy == true)
            {
                bk_Signal.CancelAsync();
            }
            timer_sandPLC.Stop();
            DistoryCamera();
        }

        private void SendToPLC(string signal)
        {
            try
            {
                if (Writer == null)
                {
                    log.AddLogMessage(LogType.Error, 0, $"PLC Send Error : Check Connection");
                    return;
                }

                Writer.WriteLine(signal);
                Writer.Flush();
                log.AddLogMessage(LogType.Infomation, 0, $"PC -> PLC : {signal}");
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, ee.Message);
            }
        }

        private void timer_sandPLC_Tick(object sender, EventArgs e)
        {
            try
            {
                button2.Text = $"Ping Count : {pingCount++} {pingUse}";
                if (pingUse)
                {
                    Writer.WriteLine("PingPing");
                    Writer.Flush();
                }
               
            }
            catch(Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, ee.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer_sandPLC.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer_sandPLC.Start();
        }
        private void OutPutSignal(object sender, EventArgs e)
        {
            int jobNo = Convert.ToInt16((sender as Button).Tag);
            string btnName = Convert.ToString((sender as Button).Text);
            btnName = btnName.Substring(0, 4);
            //짝수 = OK , 홀수 = NG
            if(jobNo%2 == 0)
                SendToPLC($"{btnName}OK01");
            else
                SendToPLC($"{btnName}ER01");
        }

        private void lb_CurruntModelName_Click(object sender, EventArgs e)
        {

        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvtype = dgv.GetType();
            PropertyInfo pi = dgvtype.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
