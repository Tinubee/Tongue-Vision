using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Dimensioning;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VISION.Cogs
{
    public class Model
    {
        private PGgloble Glob = PGgloble.getInstance;
        // 모델 기초 자료
        private string Name; // 모델 명
        private int Number; // 모델 번호

        public const int CIRCLETOOLMAX = 10;
        public const int BLOBTOOLMAX = 30;
        public const int LINETOOLMAX = 10;
        public const int OCRTOOLMAX = 10;
        public const int MULTIPATTERNMAX = 30;
        public const int HISTOGRAMMAX = 30;
        //Program.CameraList = CamList.LoadCamInfo();

        private Line[,] Lines = new Line[Program.CameraList.Count(), LINETOOLMAX];
        private bool[,] LineEnable = new bool[Program.CameraList.Count(), LINETOOLMAX];

        private Blob[,] Blobs = new Blob[Program.CameraList.Count(), BLOBTOOLMAX];
        private bool[,] BlobEnable = new bool[Program.CameraList.Count(), BLOBTOOLMAX];
        private int[,] BlobOKCount = new int[Program.CameraList.Count(), BLOBTOOLMAX];
        private int[,] BlobFixPatternNumber = new int[Program.CameraList.Count(), BLOBTOOLMAX];

        private MultiPMAlign[,] MultiPattern = new MultiPMAlign[Program.CameraList.Count(), MULTIPATTERNMAX];
        private bool[,] MultiPatternEnable = new bool[Program.CameraList.Count(), MULTIPATTERNMAX];

        private Circle[,] Circles = new Circle[Program.CameraList.Count(), CIRCLETOOLMAX];
        private bool[,] CircleEnable = new bool[Program.CameraList.Count(), CIRCLETOOLMAX];

        private Hisogram[,] Histogram = new Hisogram[Program.CameraList.Count(), HISTOGRAMMAX];
        private bool[,] HistogramEnable = new bool[Program.CameraList.Count(), HISTOGRAMMAX];
        public Model()
        { // 초기화
            int CircleMax = CIRCLETOOLMAX - 1;
            int BlobMax = BLOBTOOLMAX - 1;
            int LineMax = LINETOOLMAX - 1;
            int MultiPatternMax = MULTIPATTERNMAX - 1;
            int HistogramMax = HISTOGRAMMAX - 1;

            for (int i = 0; i < Program.CameraList.Count(); i++)
            {
                for (int lop = 0; lop <= MultiPatternMax; lop++)
                {
                    MultiPattern[i, lop] = new MultiPMAlign(lop);
                }
                for (int lop = 0; lop <= BlobMax; lop++)
                {
                    Blobs[i, lop] = new Blob(lop);
                }
                for (int lop = 0; lop <= LineMax; lop++)
                {
                    Lines[i, lop] = new Line(lop);
                }
                for (int lop = 0; lop < CircleMax; lop++)
                {
                    Circles[i, lop] = new Circle(lop);
                }
                for (int lop = 0; lop <= HistogramMax; lop++)
                {
                    Histogram[i, lop] = new Hisogram(lop);
                }
            }
        }
        /// <summary>
        /// 모델 이름으로 모델 교체
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ModelRoot"></param>
        /// <returns></returns>
        public bool Loadmodel(string Name, string ModelRoot, int camnumber, bool isFirst = false)
        {
            INIControl Modellist;
            INIControl CFGFILE;

            PGgloble global = PGgloble.getInstance;

            Modellist = new INIControl(global.MODELLIST);
            CFGFILE = new INIControl(global.CONFIGFILE);

            string CHKName;
            int CHKNumber;

            CHKNumber = int.Parse(Modellist.ReadData("NAME", Name, true));
            CHKName = Modellist.ReadData("NUMBER", CHKNumber.ToString(), false);

            if (Directory.Exists(ModelRoot) == false)
            {
                return false;
            }

            ModelRoot += "\\" + CHKName + $"\\Cam{camnumber}"; //각 Camera별 Vision Tool .vpp 파일 경로.

            if (Directory.Exists(ModelRoot) == false)
            {
                Directory.CreateDirectory(ModelRoot);
                //eturn false;
            }

            if (Read(ModelRoot, camnumber) == false)
            {
                if (isFirst == false)
                {
                    return false;
                }
            }

            this.Name = CHKName;
            Number = CHKNumber;

            CFGFILE.WriteData("LASTMODEL", "NAME", this.Name);
            CFGFILE.WriteData("LASTMODEL", "NUMBER", Number.ToString());
            return true;
        }

        /// <summary>
        /// 검사 모델 파일 불러오기
        /// </summary>
        /// <param name="path">경로</param>
        /// <returns></returns>
        private bool Read(string path, int cam)
        {
            GC.Collect();
            // 실제 모델 전환하는 메소드
            PGgloble glos = PGgloble.getInstance;
            INIControl Modelcfg = new INIControl(path + glos.MODELCONFIGFILE);

            int CircleMax = CIRCLETOOLMAX - 1;
            int BlobMax = BLOBTOOLMAX - 1;
            int LineMax = LINETOOLMAX - 1;
            int MultiPatternMax = MULTIPATTERNMAX - 1;
            int HistogramMax = HISTOGRAMMAX - 1;

            for (int lop = 0; lop <= MultiPatternMax; lop++)
            {
                MultiPattern[cam, lop].LoadTool(path);
                MultiPatternEnable[cam, lop] = Modelcfg.ReadData("MULTI PATTERN - " + lop.ToString(), "Enable") == "1" ? true : false;
            }
            for (int lop = 0; lop <= BlobMax; lop++)
            {
                Blobs[cam, lop].Loadtool(path);
                BlobEnable[cam, lop] = Modelcfg.ReadData("BLOB - " + lop.ToString(), "Enable") == "1" ? true : false;
                if (Modelcfg.ReadData("BLOB - " + lop.ToString(), "OKCount") == "")
                    Modelcfg.WriteData("BLOB - " + lop.ToString(), "OKCount", BlobOKCount[cam, lop].ToString());
                if (Modelcfg.ReadData("BLOB - " + lop.ToString(), "BlobFixPatternNumber") == "")
                    Modelcfg.WriteData("BLOB - " + lop.ToString(), "BlobFixPatternNumber", lop.ToString());
                BlobOKCount[cam, lop] = Convert.ToInt32(Modelcfg.ReadData("BLOB - " + lop.ToString(), "OKCount"));
                BlobFixPatternNumber[cam, lop] = Convert.ToInt32(Modelcfg.ReadData("BLOB - " + lop.ToString(), "BlobFixPatternNumber"));
            }
            for (int lop = 0; lop <= LineMax; lop++)
            {
                Lines[cam, lop].Loadtool(path);
                LineEnable[cam, lop] = Modelcfg.ReadData("LINE - " + lop.ToString(), "Enable") == "1" ? true : false;
            }
            for (int lop = 0; lop < CircleMax; lop++)
            {
                Circles[cam, lop].Loadtool(path);
                CircleEnable[cam, lop] = Modelcfg.ReadData("CIRCLE - " + lop.ToString(), "Enable") == "1" ? true : false;
            }
            for (int lop = 0; lop <= HistogramMax; lop++)
            {
                Histogram[cam, lop].Loadtool(path);
                HistogramEnable[cam, lop] = Modelcfg.ReadData("HISTOGRAM - " + lop.ToString(), "Enable") == "1" ? true : false;
            }
            return true;
        }

        public CogImage8Grey Imageconvert(Cognex.VisionPro.CogImage24PlanarColor image)
        {
            if (image == null)
            {
                return null;
            }

            Cognex.VisionPro.ImageProcessing.CogImageConvertTool Tool = new Cognex.VisionPro.ImageProcessing.CogImageConvertTool();
            Tool.RunParams.RunMode = Cognex.VisionPro.ImageProcessing.CogImageConvertRunModeConstants.Plane0;

            Tool.InputImage = image;
            Tool.Run();
            return (CogImage8Grey)Tool.OutputImage;
        }

        /// <summary>
        /// 현재 모델을 파일에 저장
        /// </summary>
        /// <param name="path">경로</param>
        /// <returns></returns>
        public bool SaveModel(string path, int cam)
        {
            PGgloble glos = PGgloble.getInstance;
            INIControl Modelcfg = new INIControl(path + glos.MODELCONFIGFILE);

            int CircleMax = CIRCLETOOLMAX - 1;
            int BlobMax = BLOBTOOLMAX - 1;
            int LineMax = LINETOOLMAX - 1;
            int MultiPatternMax = MULTIPATTERNMAX - 1;
            int HistogramMax = HISTOGRAMMAX - 1;

            for (int lop = 0; lop <= MultiPatternMax; lop++)
            {
                MultiPattern[cam, lop].SaveTool(path);
                if (MultiPatternEnable[cam, lop] == true)
                {
                    Modelcfg.WriteData("MULTI PATTERN - " + lop.ToString(), "Enable", "1");
                }
                else
                {
                    Modelcfg.WriteData("MULTI PATTERN - " + lop.ToString(), "Enable", "0");
                }
            }

            for (int lop = 0; lop <= BlobMax; lop++)
            {
                Blobs[cam, lop].Savetool(path);
                if (BlobEnable[cam, lop] == true)
                {
                    Modelcfg.WriteData("BLOB - " + lop.ToString(), "Enable", "1");
                }
                else
                {
                    Modelcfg.WriteData("BLOB - " + lop.ToString(), "Enable", "0");
                }
                Modelcfg.WriteData("BLOB - " + lop.ToString(), "OKCount", BlobOKCount[cam, lop].ToString());
                Modelcfg.WriteData("BLOB - " + lop.ToString(), "BlobFixPatternNumber", BlobFixPatternNumber[cam, lop].ToString());
            }
            for (int lop = 0; lop < CircleMax; lop++)
            {
                Circles[cam, lop].Savetool(path);
                if (CircleEnable[cam, lop] == true)
                {
                    Modelcfg.WriteData("CIRCLE - " + lop.ToString(), "Enable", "1");
                }
                else
                {
                    Modelcfg.WriteData("CIRCLE - " + lop.ToString(), "Enable", "0");
                }
            }
            for (int lop = 0; lop <= LineMax; lop++)
            {
                Lines[cam, lop].Savetool(path);
                if (LineEnable[cam, lop] == true)
                {
                    Modelcfg.WriteData("LINE - " + lop.ToString(), "Enable", "1");
                }
                else
                {
                    Modelcfg.WriteData("LINE - " + lop.ToString(), "Enable", "0");
                }
            }
            for (int lop = 0; lop <= HistogramMax; lop++)
            {
                Histogram[cam, lop].Savetool(path);
                if (HistogramEnable[cam, lop] == true)
                {
                    Modelcfg.WriteData("HISTOGRAM - " + lop.ToString(), "Enable", "1");
                }
                else
                {
                    Modelcfg.WriteData("HISTOGRAM - " + lop.ToString(), "Enable", "0");
                }
            }
            return true;
        }
        public string Modelname()
        {
            // 현재 모델 명
            return Name;
        }

        public int ModelNumber()
        {
            // 현재 모델 번호
            return this.Number;
        }
        public Hisogram[,] Histograms()
        {
            return Histogram;
        }
        public void Histograms(Hisogram[,] histograms)
        {
            Histogram = histograms;
        }
        public bool[,] HistogramEnables()
        {
            return HistogramEnable;
        }
        public void HistogramEnables(bool[,] histogramenable)
        {
            HistogramEnable = histogramenable;
        }
        public MultiPMAlign[,] MultiPatterns()
        {
            return MultiPattern;
        }
        public void MultiPatterns(MultiPMAlign[,] multipatts)
        {
            MultiPattern = multipatts;
        }
        public bool[,] MultiPatternEnables()
        {
            return MultiPatternEnable;
        }
        public void MultiPatternEnables(bool[,] multipatternenable)
        {
            MultiPatternEnable = multipatternenable;
        }
      
        public Circle[,] Circle()
        {
            return Circles;
        }

        public void Circle(Circle[,] circle)
        {
            Circles = circle;
        }
        public bool[,] CircleEnables()
        {
            return CircleEnable;
        }

        public void CircleEnables(bool[,] circleenable)
        {
            CircleEnable = circleenable;
        }
        public Line[,] Line()
        {
            return Lines;
        }

        public void Line(Line[,] line)
        {
            Lines = line;
        }

        public bool[,] LineEnables()
        {
            return LineEnable;
        }

        public void LineEnables(bool[,] lineenable)
        {
            LineEnable = lineenable;
        }
        public Blob[,] Blob()
        {
            return Blobs;
        }
        public void Blob(Blob[,] blob)
        {
            Blobs = blob;
        }

        public bool[,] BlobEnables()
        {
            return BlobEnable;
        }

        public void BlobEnables(bool[,] blobenable)
        {
            BlobEnable = blobenable;
        }

        public int[,] BlobOKCounts()
        {
            return BlobOKCount;
        }

        public void BlobOKCounts(int[,] OKcount)
        {
            BlobOKCount = OKcount;
        }
        public int[,] BlobFixPatternNumbers()
        {
            return BlobFixPatternNumber;
        }

        public void BlobFixPatternNumbers(int[,] PatternNumber)
        {
            BlobFixPatternNumber = PatternNumber;
        }
        public bool MultiPattern_Inspection(ref Cognex.VisionPro.Display.CogDisplay Display, CogImage8Grey Image, ref string[] ResultString, int CamNumber, CogGraphicCollection Collection)
        {
            try
            {
                bool Result = true;
                CogGraphicCollection CollectionNG = new CogGraphicCollection();
                int MultiPatternMax = MULTIPATTERNMAX - 1;

                Display.Image = Image;
                Display.InteractiveGraphics.Clear();
                Display.StaticGraphics.Clear();

                for (int lop = 0; lop <= MultiPatternMax; lop++)
                {
                    if (MultiPatternEnable[CamNumber, lop] == true)
                    {
                        MultiPattern[CamNumber, lop].Run(Image);
                        ResultString[lop] = "OK";
                    }
                    else
                    {
                        ResultString[lop] = "NON";
                    }
                }
                //검사 툴 결과 확인.
                for (int lop = 0; lop <= MultiPatternMax; lop++)
                {
                    if (MultiPatternEnable[CamNumber, lop] == true)
                    {
                        if (MultiPattern[CamNumber, lop].ResultCount() < 1)
                        {
                            Result = false;
                        }
                        MultiPattern[CamNumber, lop].ResultDisplay(Display,Collection, MultiPattern[CamNumber, lop].HighestResultToolNumber(),lop);
                        Glob.MultiInsPat_Result[CamNumber, lop] = MultiPattern[CamNumber, lop].ResultScore(MultiPattern[CamNumber, lop].HighestResultToolNumber());
                    }
                    else
                    {
                        //ltiPattern[CamNumber, lop].ResultNGDisplay(Display, Collection);
                        Glob.MultiInsPat_Result[CamNumber, lop] = 0;
                        //Result = false;
                    }
                }
                return Result;
            }
            catch
            {
                return false;
            }
        }
        public bool Blob_Inspection(ref Cognex.VisionPro.Display.CogDisplay Display, Cognex.VisionPro.CogImage8Grey Image, ref string[] ResultString, int CamNumber, CogGraphicCollection Collection)
        {
            try
            {
                bool Result = true;

                CogGraphicCollection CollectionNG = new CogGraphicCollection();
                int BlobMax = BLOBTOOLMAX - 1;
                // 검사 툴 작동
                for (int lop = 0; lop <= BlobMax; lop++)
                {
                    if (BlobEnable[CamNumber, lop] == true)
                    {
                        Blobs[CamNumber, lop].Run(Image);
                        ResultString[lop] = "OK";
                    }
                    else
                    {
                        ResultString[lop] = "NON";
                    }
                }
                for (int lop = 0; lop <= BlobMax; lop++)
                {
                    if (BlobEnable[CamNumber, lop] == true)
                    {
                        if (Blobs[CamNumber, lop].ResultBlobCount() != BlobOKCount[CamNumber, lop]) // - 검사결과 NG
                        {
                            //Blob영역 표시 
                            Result = false;
                            Blobs[CamNumber, lop].ResultAllBlobDisplayPLT(Collection, false);
                            ResultString[lop] = "NG";
                        }
                        else // - 검사결과 OK
                        {
                            Blobs[CamNumber, lop].ResultAllBlobDisplayPLT(Collection, true);
                        }
                    }
                }
                //}
                return Result;
            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.Message);
                return false;
            }
        }
       
        public bool Line_Inspection(ref Cognex.VisionPro.Display.CogDisplay Display, CogImage8Grey Image, ref string[] ResultString, int CamNumber, CogGraphicCollection Collection)
        {
            try
            {
                bool Result = true;
                CogGraphicCollection CollectionNG = new CogGraphicCollection();
                int LineMax = LINETOOLMAX - 1;

                Display.Image = Image;

                for (int lop = 1; lop <= LineMax; lop++)
                {
                    if (LineEnable[CamNumber, lop] == true)
                    {
                        Lines[CamNumber, lop].Run(Image);
                        ResultString[lop] = "OK";
                    }
                    else
                    {
                        ResultString[lop] = "NON";
                    }
                }
                for (int lop = 1; lop <= LineMax; lop++)
                {
                    if (LineEnable[CamNumber, lop] == true)
                    {
                        Lines[CamNumber, lop].ResultDisplay(Display, Collection);
                    }
                }

                return Result;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public bool Circle_Inspection(ref Cognex.VisionPro.Display.CogDisplay Display, Cognex.VisionPro.CogImage8Grey Image, ref string[] ResultString, int CamNumber, CogGraphicCollection Collection)
        {
            try
            {
                bool Result = true;

                CogGraphicCollection CollectionNG = new CogGraphicCollection();
                int CircleMax = CIRCLETOOLMAX - 1;

                for (int lop = 1; lop <= CircleMax; lop++)
                {
                    if (CircleEnable[CamNumber, lop] == true)
                    {
                        Circles[CamNumber, lop].Run(Image);
                        ResultString[lop] = "OK";
                    }
                    else
                    {
                        ResultString[lop] = "NON";
                    }
                }

                for (int lop = 1; lop <= CircleMax; lop++)
                {
                    if (CircleEnable[CamNumber, lop] == true)
                    {
                        Circles[CamNumber, lop].ResultAllDisplay(Collection);
                    }
                }
                return Result;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public bool Histogram_Inspection(ref Cognex.VisionPro.Display.CogDisplay Display, Cognex.VisionPro.CogImage8Grey Image, ref string[] ResultString, int CamNumber, CogGraphicCollection Collection)
        {
            try
            {
                bool Result = true;
                CogGraphicCollection CollectionNG = new CogGraphicCollection();
                int HistogramMax = HISTOGRAMMAX - 1;

                Display.Image = Image;

                for (int lop = 1; lop <= HistogramMax; lop++)
                {
                    if (HistogramEnable[CamNumber, lop] == true)
                    {
                        Histogram[CamNumber, lop].Run(Image);
                        ResultString[lop] = "OK";
                    }
                    else
                    {
                        ResultString[lop] = "NON";
                    }
                }
                for (int lop = 1; lop <= HistogramMax; lop++)
                {
                    if (HistogramEnable[CamNumber, lop] == true)
                    {
                        //Histogram[CamNumber, lop].ResultDisplay(Display, Collection);
                    }
                }

                return Result;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public CogImage8Grey FixtureImage(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, 0].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, 0].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, 0].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey Blob_FixtureImage(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }

        public CogImage8Grey Blob_FixtureImage1(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }

        public CogImage8Grey Blob_FixtureImage2(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey Blob_FixtureImage3(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey Blob_FixtureImage4(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling =CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey Blob_FixtureImage5(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey Histogram_FixtureImage(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename, int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
        public CogImage8Grey LINE_FixtureImage(CogImage8Grey OriImage, CogTransform2DLinear Fixtured, string SetName, int Camnumber, int toolnumber, out string ImageSpacename,int HighPatternNumber)
        {
            CogFixtureTool Fixture = new CogFixtureTool();

            Fixture.InputImage = OriImage;
            Fixture.RunParams.FixturedSpaceName = SetName;
            Fixture.RunParams.UnfixturedFromFixturedTransform = Fixtured;
            Fixture.RunParams.FixturedSpaceNameDuplicateHandling = CogFixturedSpaceNameDuplicateHandlingConstants.Compatibility;
            //***************추가***************//
            Fixtured.TranslationX = MultiPattern[Camnumber, toolnumber].TransX(HighPatternNumber);
            Fixtured.TranslationY = MultiPattern[Camnumber, toolnumber].TransY(HighPatternNumber);
            Fixtured.Rotation = MultiPattern[Camnumber, toolnumber].TransRotation(HighPatternNumber);

            Fixture.Run();
            ImageSpacename = Fixture.OutputImage.SelectedSpaceName;
            return (CogImage8Grey)Fixture.OutputImage;
        }
    }

    public struct Points
    {
        public double X;
        public double Y;
        public int Threshold;
        public bool Enable;
    }
}
