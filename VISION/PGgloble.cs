using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION
{
    public class PGgloble
    {
        #region "DO NOT TOUCH"
        private static PGgloble instance = null;
        private static readonly object Lock = new object();

        private PGgloble()
        {

        }

        public static PGgloble getInstance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new PGgloble();
                    }
                    return instance;
                }
            }
        }
        #endregion
        public readonly string PROGRAMROOT = Application.StartupPath;

        public static DirectoryInfo currentPath = Directory.GetParent(Environment.CurrentDirectory);
        public static string topPath = currentPath.Parent.Parent.FullName;

        public readonly string LOADINGFROM = topPath + "\\OtherForm\\LoadingForm\\LoadingForm_KHM\\bin\\Debug\\LoadingForm_KHM.exe"; //로딩창 경로
        public readonly string SAVEFROM = topPath + "\\OtherForm\\SaveForm\\SaveForm_KHM\\bin\\Debug\\SaveForm_KHM.exe"; //저장창 경로
        public readonly string MODELCHANGEFROM = topPath + "\\OtherForm\\ModelChange\\ModelChange_KHM\\bin\\Debug\\ModelChange_KHM.exe"; //변경창 경로

        public readonly string MODELROOT = Application.StartupPath + "\\Models"; //모델저장경로.
        public readonly string MODELLIST = Application.StartupPath + "\\ModelList.ini"; //모델리스트 ini파일

        public readonly string MODELCONFIGFILE = "\\Modelcfg.ini"; //모델 사용유무 저장.

        public readonly string CONFIGFILE = Application.StartupPath + "\\config.ini";
        public readonly string SETTING = Application.StartupPath + "\\setting.ini"; //setting값 저장

        public readonly string PROGRAM_VERSION = "1.0.0"; //Program Version
        #region "버전 관리 및 업데이트 내용"
        //1.0.0 - 현장투입 후 완성된 최종버전(주요기능 및 프로그램 구성 완료) - 날짜 / 이름
        #endregion

        // 시스템
        public Cogs.Model RunnModel = null;

        public string CurruntModelName;
        public string ImageSaveRoot; // 이미지 저장 경로
        public string DataSaveRoot; // 검사 결과 저장 경로
        public string LineName; // 프로그램 메인 화면 중앙 상단에 적힐 무언가.

        public string Camera_SerialNumber; //카메라 시리얼번호.
        public CamSets[] CameraOption = new CamSets[5]; //카메라 옵션 클래스

        // Light controller
        public int LightControlNumber;
        public string[] PortName = new string[4]; // 포트 번호
        public string[] Parity = new string[4]; // 패리티 비트
        public string[] StopBits = new string[4]; // 스톱비트
        public string[] DataBit = new string[4]; // 데이터 비트
        public string[] BaudRate = new string[4]; // 보오 레이트
        public int[,] LightCH = new int[4,4]; //조명컨트롤러 채널(컨트롤번호, 채널번호) 조명값

        public bool[] InspectUsed = new bool[5]; //카메라별 검사 사용
        public string ImageFilePath; //이미지파일경로.
        public int CamNumber; //사용카메라번호
       

        public bool CAM1_Inspect = false;
        public bool CAM2_Inspect = false;
        public bool CAM3_Inspect = false;
        public bool CAM4_Inspect = false;
        public bool CAM5_Inspect = false;

        public bool AligneMode = false;
        public char topAlignNumber = '1';

        //툴의 검사결과
        public bool[] PatternTool = new bool[5];
        public bool[] BlobTool = new bool[5];

        //CAMERA별 PIXEL 값
        public bool OKImageSave = true;
        public bool NGImageSave = true;

        public double[,] MultiInsPat_Result = new double[5, 30];
        public double[,] MultiPatternResultData = new double[5, 30];

        public bool[] ImageType = new bool[5]; //true : 흑백 , False : 컬러
        public bool[] AllToolInspectUsed = new bool[5]; //각각의 툴 검사 사용
        public bool[] TrackingMode = new bool[5];

        public int SelectPCNumber;
        public int InspectOrder;
    }


    public struct CamSets
    {
        public double Exposure; //조리개값
        public double Gain;
        public int DelayTime; //지연시간
    }
}
