using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION.Cogs
{
    public class Hisogram
    {
        private Cognex.VisionPro.ImageProcessing.CogHistogramTool Tool;
        //public bool Singleblob;

        /// <summary>
        /// 툴의 기본 초기화를 담당 함. 입력 되는 이름은 툴 파일 저장과 읽어 오는 작업에 쓰임.
        /// </summary>
        /// <param name="Toolnumber">툴의 이름.</param>
        public Hisogram(int Toolnumber = 0)
        {
            Tool = new Cognex.VisionPro.ImageProcessing.CogHistogramTool();
            Tool.Name = "Hisogram - " + Toolnumber.ToString();
            Tool.RunParams.BinMode = Cognex.VisionPro.ImageProcessing.CogHistogramBinModeConstants.Auto;
            Tool.RunParams.NumBins = 256;
            Tool.RunParams.RegionMode = Cognex.VisionPro.CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;
        }

        private bool NewTool()
        { // 툴의 가장 초기 상태 셋업
            Cognex.VisionPro.CogPolygon Region = new Cognex.VisionPro.CogPolygon();

            Region.NumVertices = 4;
            Region.SetVertexX(0, 130);
            Region.SetVertexY(0, 60);
            Region.SetVertexX(1, 500);
            Region.SetVertexY(1, 60);
            Region.SetVertexX(2, 500);
            Region.SetVertexY(2, 450);
            Region.SetVertexX(3, 130);
            Region.SetVertexY(3, 450);

            Region.LineWidthInScreenPixels = 1;
            Region.LineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.Solid;
            Region.Color = Cognex.VisionPro.CogColorConstants.Green;

            Region.SelectedLineWidthInScreenPixels = 1;
            Region.SelectedColor = Cognex.VisionPro.CogColorConstants.Cyan;
            Region.SelectedLineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.DashDot;

            Region.DragLineWidthInScreenPixels = 1;
            Region.DragColor = Cognex.VisionPro.CogColorConstants.Blue;
            Region.DragLineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.Dot;
            Region.TipText = "Search Area";

            Region.Interactive = true;
            Region.GraphicDOFEnable = Cognex.VisionPro.CogPolygonDOFConstants.All;

            Tool.Region = Region;

            return true;
        }
        public string ToolName()
        {
            return this.Tool.Name;
        }

        /// <summary>
        /// 파일에서 툴을 불러 옴. 파일이 있는 폴더의 경로만 제공 하면 됨.
        /// </summary>
        /// <param name="path">파일이 있는  폴더의 경로</param>
        /// <returns></returns>
        public bool Loadtool(string path)
        {
            string Savepath = path;
            string TempName = this.Tool.Name;

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

            Tool = (Cognex.VisionPro.ImageProcessing.CogHistogramTool)Cognex.VisionPro.CogSerializer.LoadObjectFromFile(Savepath);
            Tool.Name = TempName;
            Application.DoEvents();
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

            Cognex.VisionPro.CogSerializer.SaveObjectToFile(Tool, Savepath);

            return true;
        }

        /// <summary>
        /// 툴에 이미지 입력
        /// </summary>
        /// <param name="image">툴에 입력 할 이미지</param>
        /// <returns></returns>
        public bool InputImage(Cognex.VisionPro.CogImage8Grey image)
        {
            if (image == null)
            {
                return false;
            }

            Tool.InputImage = image;
            return true;
        }

        /// <summary>
        /// 툴 동작. 검사를 수행함.
        /// </summary>
        /// <param name="image">툴에 입력 할 이미지.</param>
        /// <returns>결과</returns>
        public bool Run(Cognex.VisionPro.CogImage8Grey image)
        {
            if (InputImage(image) == false)
            {
                return false;
            }

            Cognex.VisionPro.CogPolygon Region = (Cognex.VisionPro.CogPolygon)this.Tool.Region;
            Region.Selected = false;

            Tool.Region = Region;

            Tool.Run();

            //if (Tool.Results == null)
            //{
            //    return false;
            //}

            //if (Tool.Results.GetBlobs().Count > 0)
            //{
            //    return false;
            //}

            return true;
        }

        public bool Run(Cognex.VisionPro.CogImage8Grey image, Points Point, string SpaceName)
        {
            if (InputImage(image) == false)
            {
                return false;
            }

            Cognex.VisionPro.CogCircularAnnulusSection Region = (Cognex.VisionPro.CogCircularAnnulusSection)this.Tool.Region;

            Region.Selected = false;

            Region.CenterX = Point.X;
            Region.CenterY = Point.Y;

            //Threshold(Point.Threshold);

            Tool.Region.SelectedSpaceName = SpaceName;
            Tool.Region = Region;

            Tool.Run();

            //if (Tool.Results == null)
            //{
            //    return false;
            //}

            //if (Tool.Results.GetBlobs().Count <= 0)
            //{
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 검사 영역을 화면에 표시
        /// </summary>
        /// <param name="display">표시 대상 디스플레이</param>
        /// <param name="image">대상 이미지</param>
        public void Area_Affine(ref Cognex.VisionPro.Display.CogDisplay display, Cognex.VisionPro.CogImage8Grey image, string ImageSpace)
        {
            if (InputImage(image) == false)
            {
                return;
            }

            if (this.Tool.Region == null)
            {
                this.NewTool();
            }

            Cognex.VisionPro.CogPolygon area = (Cognex.VisionPro.CogPolygon)Tool.Region; //영역설정 CogRectangleAffine에서 CogPolygon으로 변경함 - 191230
            area.Interactive = true;
            area.GraphicDOFEnable = Cognex.VisionPro.CogPolygonDOFConstants.All;
            area.SelectedSpaceName = ImageSpace;
            area.Color = Cognex.VisionPro.CogColorConstants.Green;
            Tool.Region = area;

            display.InteractiveGraphics.Add((Cognex.VisionPro.ICogGraphicInteractive)Tool.Region, null, false);
        }
        public void ResultDisplay(Cognex.VisionPro.CogGraphicCollection Collection, bool result)
        {
            if (Tool.Result == null)
            {
                return;
            }
            Cognex.VisionPro.CogPolygon ResultRegion;

            ResultRegion = (Cognex.VisionPro.CogPolygon)Tool.Region;
            ResultRegion.Color = result == false ? Cognex.VisionPro.CogColorConstants.Red : Cognex.VisionPro.CogColorConstants.Green;
            Collection.Add(ResultRegion);
        }
        public int ResultHistogramMax()
        {
            if (Tool.Result == null)
            {
                return 0;
            }

            return Tool.Result.Maximum;
        }

        public int ResultHistogramMin()
        {
            if (Tool.Result == null)
            {
                return 0;
            }

            return Tool.Result.Minimum;
        }

        /// <summary>
        /// 검사 툴 전체 셋업 화면을 화면에 표시
        /// </summary>
        public void ToolSetup()
        {
            Form Window = new Form();
            Cognex.VisionPro.ImageProcessing.CogHistogramEditV2 Edit = new Cognex.VisionPro.ImageProcessing.CogHistogramEditV2();

            Edit.Dock = DockStyle.Fill; // 화면 채움
            Edit.Subject = Tool; // 에디트에 툴 정보 입력.
            Window.Controls.Add(Edit); // 폼에 에디트 추가.

            Window.Width = 800;
            Window.Height = 600;

            Window.Show(); // 폼 실행
        }
    }
}

