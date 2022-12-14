using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;

namespace VISION.Cogs
{
    public class Circle
    {
        private CogFindCircleTool Tool;

        public Circle(int Toolnumber)
        {
            this.Tool = new CogFindCircleTool();
            this.Tool.Name = "Circle - " + Toolnumber.ToString();
        }

        private void NewTool()
        { // 툴의 가장 초기 상태 셋업
            CogCircularArc Region = new CogCircularArc();

            Region.CenterX = 800;
            Region.CenterY = 800;

            Region.LineStyle = CogGraphicLineStyleConstants.Solid;
            Region.LineWidthInScreenPixels = 3;
            Region.Color = CogColorConstants.Green;

            Region.SelectedLineStyle = CogGraphicLineStyleConstants.Dash;
            Region.SelectedLineWidthInScreenPixels = 3;
            Region.SelectedColor = CogColorConstants.Cyan;

            Region.DragLineStyle = CogGraphicLineStyleConstants.Dot;
            Region.DragLineWidthInScreenPixels = 3;
            Region.DragColor =CogColorConstants.Blue;

            Region.GraphicDOFEnable = CogCircularArcDOFConstants.All;
            Region.Interactive = true;

            this.Tool.RunParams.ExpectedCircularArc = Region;

            this.Tool.RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
            this.Tool.RunParams.CaliperSearchDirection = CogFindCircleSearchDirectionConstants.Inward;
            this.Tool.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
        }

        /// <summary>
        /// 파일에서 툴을 불러 옴. 파일이 있는 폴더의 경로만 제공 하면 됨.
        /// </summary>
        /// <param name="path">파일이 있는  폴더의 경로</param>
        /// <returns></returns>
        public bool Loadtool(string path)
        {
            string Savepath = path;

            if (System.IO.Directory.Exists(Savepath) == false)
            {
                NewTool();
                return true;
            }

            Savepath = Savepath + "\\" + Tool.Name + ".vpp";

            if (System.IO.File.Exists(Savepath) == false)
            {
                NewTool();
                return false;
            }

            Tool = (CogFindCircleTool)CogSerializer.LoadObjectFromFile(Savepath);

            return true;
        }

        /// <summary>
        /// 파일에 툴의 정보를 씀. 대상 파일이 위치 할 폴더의 경로만 제공 하면 됨.
        /// </summary>
        /// <param name="path">저장 할 대상 폴더의 경로</param>
        /// <returns></returns>
        public bool Savetool(string path)
        {
            string Savepath = path;

            if (System.IO.Directory.Exists(Savepath) == false)
            {
                return false;
            }

            Savepath = Savepath + "\\" + Tool.Name + ".vpp";

            CogSerializer.SaveObjectToFile(Tool, Savepath);

            return true;
        }

        public bool InputImage(CogImage8Grey Image)
        {
            if (Image == null)
            {
                return false;
            }
            else
            {
                this.Tool.InputImage = Image;
                return true;
            }
        }

        public bool Run(CogImage8Grey Image)
        {
            if (!this.InputImage(Image))
            {
                return false;
            }

            this.Tool.Run();

            System.Threading.Thread.Sleep(50);

            if (this.Tool.Results == null)
            {
                return false;
            }

            if (this.Tool.Results.Count < 1)
            {
                return false;
            }

            return true;
        }

        public void Area(ref CogDisplay Display, CogImage8Grey Image, string ImageSpace)
        {
            if (this.InputImage(Image) == true)
            {
                CogLineSegment Region;
                CogGraphicCollection cogRegion_Collection;
                ICogRecord cogRect_FindRecord;
                Tool.CurrentRecordEnable = CogFindCircleCurrentRecordConstants.All;
                cogRect_FindRecord = Tool.CreateCurrentRecord();

                cogRegion_Collection = (CogGraphicCollection)cogRect_FindRecord.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;

                //if (this.Tool.RunParams.ExpectedCircularArc == null)
                //{
                //    Region = new Cognex.VisionPro.CogLineSegment();
                //}
                //else
                //{
                //    Region = this.Tool.RunParams.cal;
                //}

                this.Tool.RunParams.ExpectedCircularArc.SelectedSpaceName = ImageSpace;
                //this.Tool.RunParams.ex = Region;

                Display.InteractiveGraphics.Add(this.Tool.RunParams.ExpectedCircularArc, null, false);
                //for (int i = 0; i < cogRegion_Collection.Count; i++)
                //{
                //    Display.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)cogRegion_Collection[i], "FindLine", true);
                //}
            }
        }

        //public void Area(ref Cognex.VisionPro.Display.CogDisplay Display)
        //{
        //    Display.InteractiveGraphics.Add(this.Tool.RunParams.ExpectedCircularArc, null, false);
        //}

        public double Threshold()
        {
            return this.Tool.RunParams.CaliperRunParams.ContrastThreshold;
        }

        public void Threshold(double threshold)
        {
            this.Tool.RunParams.CaliperRunParams.ContrastThreshold = threshold;
        }

        public int Halfpixel()
        {
            return this.Tool.RunParams.CaliperRunParams.FilterHalfSizeInPixels;
        }

        public void Halfpixel(int halfpixel)
        {
            this.Tool.RunParams.CaliperRunParams.FilterHalfSizeInPixels = halfpixel;
        }

        public double[] ResultLocation()
        {
            double[] Result = { 0.0, 0.0 };

            if (this.Tool.Results == null)
            {
                return Result;
            }

            if (this.Tool.Results.Count < 1)
            {
                return Result;
            }

            Result[0] = this.Tool.Results.GetCircle().CenterX;
            Result[1] = this.Tool.Results.GetCircle().CenterY;

            return Result;
        }

        public double ResultLocation_X()
        {
            double Result = 0.0;

            if (this.Tool.Results == null)
            {
                return Result;
            }

            if (this.Tool.Results.Count == 0)
            {
                return Result;
            }

            Result = this.Tool.Results.GetCircle().CenterX;

            return Result;
        }

        public double ResultLocation_Y()
        {
            double Result = 0.0;

            if (this.Tool.Results == null)
            {
                return Result;
            }

            if (this.Tool.Results.Count < 1)
            {
                return Result;
            }
            Result = this.Tool.Results.GetCircle().CenterY;

            return Result;
        }
        public void ResultAllDisplay(CogGraphicCollection Collection)
        {
            if (Tool.Results == null)
            {
                return;
            }
            if (Tool.Results.Count < 1)
            {
                return;
            }
            Collection.Add(Tool.Results.GetCircle());
            //Collection.Add(Tool.Results.LineResultsB.GetLine());
        }
        public CogCircle GetCircle()
        {
            if (Tool.Results == null)
            {
                return null;
            }
            return Tool.Results.GetCircle();
        }
        public void ResultDisplay(ref CogDisplay Display)
        {
            if (this.Tool.Results == null)
            {
                return;
            }

            if (this.Tool.Results.Count < 1)
            {
                return;
            }

            CogCircle Result = null;
            Result = this.Tool.Results.GetCircle();
            if (Result == null)
            {
                return;
            }
            Result.LineWidthInScreenPixels = 5;
            Result.Color = CogColorConstants.DarkGreen;

            Display.InteractiveGraphics.Add(Result, null, true);
        }

        public void ToolSetup()
        {
            System.Windows.Forms.Form Window = new System.Windows.Forms.Form();
            CogFindCircleEditV2 Edit = new CogFindCircleEditV2();

            Edit.Dock = System.Windows.Forms.DockStyle.Fill; // 화면 채움
            Edit.Subject = Tool; // 에디트에 툴 정보 입력.
            Window.Controls.Add(Edit); // 폼에 에디트 추가.

            Window.Width = 800;
            Window.Height = 600;

            Window.Show(); // 폼 실행
        }
    }
}
