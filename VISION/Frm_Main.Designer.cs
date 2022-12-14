namespace VISION
{
    partial class Frm_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.tlpUnder = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SystemSetup = new System.Windows.Forms.Button();
            this.btn_ToolSetUp = new System.Windows.Forms.Button();
            this.btn_Model = new System.Windows.Forms.Button();
            this.btn_CamSet = new System.Windows.Forms.Button();
            this.tlpTopSide = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Mode = new System.Windows.Forms.Label();
            this.lb_CurruntModelName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Time = new System.Windows.Forms.Label();
            this.lb_Ver = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Status = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_PLCStats = new System.Windows.Forms.Label();
            this.timer_Setting = new System.Windows.Forms.Timer(this.components);
            this.LightControl1 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.logControl1 = new KimLib.LogControl();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay5 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam5_Result = new System.Windows.Forms.Label();
            this.lb_Cam5Stats = new System.Windows.Forms.Label();
            this.lb_Cam5_InsTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay3 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam3_Result = new System.Windows.Forms.Label();
            this.lb_Cam3Stats = new System.Windows.Forms.Label();
            this.lb_Cam3_InsTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay2 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam2_Result = new System.Windows.Forms.Label();
            this.lb_Cam2Stats = new System.Windows.Forms.Label();
            this.lb_Cam2_InsTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam4_Result = new System.Windows.Forms.Label();
            this.lb_Cam4Stats = new System.Windows.Forms.Label();
            this.lb_Cam4_InsTime = new System.Windows.Forms.Label();
            this.cdyDisplay4 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam1Stats = new System.Windows.Forms.Label();
            this.lb_Cam1_Result = new System.Windows.Forms.Label();
            this.lb_Cam1_InsTime = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.textBoxIP2 = new System.Windows.Forms.TextBox();
            this.lbConnTitle = new System.Windows.Forms.Label();
            this.textBoxIP3 = new System.Windows.Forms.TextBox();
            this.textBoxIP1 = new System.Windows.Forms.TextBox();
            this.textBoxIP0 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Output17 = new System.Windows.Forms.Button();
            this.btn_Output7 = new System.Windows.Forms.Button();
            this.btn_Output16 = new System.Windows.Forms.Button();
            this.btn_Output15 = new System.Windows.Forms.Button();
            this.btn_Output6 = new System.Windows.Forms.Button();
            this.btn_Output14 = new System.Windows.Forms.Button();
            this.btn_Output13 = new System.Windows.Forms.Button();
            this.btn_Output5 = new System.Windows.Forms.Button();
            this.btn_Output12 = new System.Windows.Forms.Button();
            this.btn_Output4 = new System.Windows.Forms.Button();
            this.btn_Output0 = new System.Windows.Forms.Button();
            this.btn_Output3 = new System.Windows.Forms.Button();
            this.btn_Output1 = new System.Windows.Forms.Button();
            this.btn_Output2 = new System.Windows.Forms.Button();
            this.btn_Output11 = new System.Windows.Forms.Button();
            this.btn_Output10 = new System.Windows.Forms.Button();
            this.btn_Output9 = new System.Windows.Forms.Button();
            this.btn_Output8 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_INPUT17 = new System.Windows.Forms.Button();
            this.btn_INPUT16 = new System.Windows.Forms.Button();
            this.btn_INPUT15 = new System.Windows.Forms.Button();
            this.btn_INPUT14 = new System.Windows.Forms.Button();
            this.btn_INPUT13 = new System.Windows.Forms.Button();
            this.btn_INPUT12 = new System.Windows.Forms.Button();
            this.btn_INPUT11 = new System.Windows.Forms.Button();
            this.btn_INPUT10 = new System.Windows.Forms.Button();
            this.btn_INPUT9 = new System.Windows.Forms.Button();
            this.btn_INPUT8 = new System.Windows.Forms.Button();
            this.btn_INPUT0 = new System.Windows.Forms.Button();
            this.btn_INPUT1 = new System.Windows.Forms.Button();
            this.btn_INPUT2 = new System.Windows.Forms.Button();
            this.btn_INPUT3 = new System.Windows.Forms.Button();
            this.btn_INPUT4 = new System.Windows.Forms.Button();
            this.btn_INPUT5 = new System.Windows.Forms.Button();
            this.btn_INPUT6 = new System.Windows.Forms.Button();
            this.btn_INPUT7 = new System.Windows.Forms.Button();
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM5_NGRATE = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lb_CAM5_TOTAL = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.lb_CAM5_NG = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.lb_CAM5_OK = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM4_NGRATE = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lb_CAM4_TOTAL = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lb_CAM4_NG = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lb_CAM4_OK = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM3_NGRATE = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lb_CAM3_TOTAL = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lb_CAM3_NG = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lb_CAM3_OK = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM2_NGRATE = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lb_CAM2_TOTAL = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lb_CAM2_NG = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lb_CAM2_OK = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM1_NGRATE = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lb_CAM1_TOTAL = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lb_CAM1_NG = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lb_CAM1_OK = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_IO = new System.Windows.Forms.Button();
            this.btn_Count = new System.Windows.Forms.Button();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.num_LightNumber = new System.Windows.Forms.NumericUpDown();
            this.btn_Light = new System.Windows.Forms.Button();
            this.LightControl2 = new System.IO.Ports.SerialPort(this.components);
            this.LightControl3 = new System.IO.Ports.SerialPort(this.components);
            this.btn_ReconnectCam = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_PC2 = new System.Windows.Forms.Button();
            this.btn_PC1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bk_Signal = new System.ComponentModel.BackgroundWorker();
            this.timer_sandPLC = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tlpUnder.SuspendLayout();
            this.tlpTopSide.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay5)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay3)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay2)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay4)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Main_TabControl.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LightNumber)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpUnder
            // 
            this.tlpUnder.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpUnder.ColumnCount = 13;
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.959229F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.959229F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpUnder.Controls.Add(this.btn_SystemSetup, 12, 0);
            this.tlpUnder.Controls.Add(this.btn_ToolSetUp, 4, 0);
            this.tlpUnder.Controls.Add(this.btn_Model, 9, 0);
            this.tlpUnder.Controls.Add(this.btn_CamSet, 8, 0);
            this.tlpUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpUnder.Location = new System.Drawing.Point(0, 994);
            this.tlpUnder.Name = "tlpUnder";
            this.tlpUnder.RowCount = 1;
            this.tlpUnder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnder.Size = new System.Drawing.Size(1920, 86);
            this.tlpUnder.TabIndex = 1;
            // 
            // btn_SystemSetup
            // 
            this.btn_SystemSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SystemSetup.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SystemSetup.Image = global::VISION.Properties.Resources.Setting;
            this.btn_SystemSetup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SystemSetup.Location = new System.Drawing.Point(1774, 4);
            this.btn_SystemSetup.Name = "btn_SystemSetup";
            this.btn_SystemSetup.Size = new System.Drawing.Size(142, 78);
            this.btn_SystemSetup.TabIndex = 0;
            this.btn_SystemSetup.Text = "System Setting";
            this.btn_SystemSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SystemSetup.UseVisualStyleBackColor = true;
            this.btn_SystemSetup.Click += new System.EventHandler(this.btn_SystemSetup_Click);
            // 
            // btn_ToolSetUp
            // 
            this.btn_ToolSetUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ToolSetUp.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ToolSetUp.Image = global::VISION.Properties.Resources.Setup;
            this.btn_ToolSetUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ToolSetUp.Location = new System.Drawing.Point(560, 4);
            this.btn_ToolSetUp.Name = "btn_ToolSetUp";
            this.btn_ToolSetUp.Size = new System.Drawing.Size(183, 78);
            this.btn_ToolSetUp.TabIndex = 0;
            this.btn_ToolSetUp.Tag = "Front";
            this.btn_ToolSetUp.Text = "Tool Setting";
            this.btn_ToolSetUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ToolSetUp.UseVisualStyleBackColor = true;
            this.btn_ToolSetUp.Click += new System.EventHandler(this.btn_ToolSetUp_Click);
            // 
            // btn_Model
            // 
            this.btn_Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Model.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Model.Image = global::VISION.Properties.Resources.JobOpen;
            this.btn_Model.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Model.Location = new System.Drawing.Point(1357, 4);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(132, 78);
            this.btn_Model.TabIndex = 2;
            this.btn_Model.Tag = "";
            this.btn_Model.Text = "Model";
            this.btn_Model.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Model.UseVisualStyleBackColor = true;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // btn_CamSet
            // 
            this.btn_CamSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_CamSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CamSet.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CamSet.Image = global::VISION.Properties.Resources.OneShot;
            this.btn_CamSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CamSet.Location = new System.Drawing.Point(1218, 4);
            this.btn_CamSet.Name = "btn_CamSet";
            this.btn_CamSet.Size = new System.Drawing.Size(132, 78);
            this.btn_CamSet.TabIndex = 51;
            this.btn_CamSet.Tag = "";
            this.btn_CamSet.Text = "Camera Setting";
            this.btn_CamSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CamSet.UseVisualStyleBackColor = true;
            this.btn_CamSet.Click += new System.EventHandler(this.btn_CamList_Click);
            // 
            // tlpTopSide
            // 
            this.tlpTopSide.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTopSide.ColumnCount = 9;
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.08826F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.77986F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.21735F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.561666F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.557187F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.554338F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.414443F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.414443F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.412449F));
            this.tlpTopSide.Controls.Add(this.lb_Mode, 4, 0);
            this.tlpTopSide.Controls.Add(this.lb_CurruntModelName, 5, 0);
            this.tlpTopSide.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpTopSide.Controls.Add(this.btn_Exit, 8, 0);
            this.tlpTopSide.Controls.Add(this.btn_Stop, 7, 0);
            this.tlpTopSide.Controls.Add(this.btn_Status, 6, 0);
            this.tlpTopSide.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpTopSide.Controls.Add(this.label1, 2, 0);
            this.tlpTopSide.Controls.Add(this.lb_PLCStats, 3, 0);
            this.tlpTopSide.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTopSide.Location = new System.Drawing.Point(0, 0);
            this.tlpTopSide.Name = "tlpTopSide";
            this.tlpTopSide.RowCount = 1;
            this.tlpTopSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopSide.Size = new System.Drawing.Size(1920, 77);
            this.tlpTopSide.TabIndex = 2;
            // 
            // lb_Mode
            // 
            this.lb_Mode.AutoSize = true;
            this.lb_Mode.BackColor = System.Drawing.Color.Lime;
            this.lb_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Mode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_Mode.Location = new System.Drawing.Point(1278, 3);
            this.lb_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.lb_Mode.Name = "lb_Mode";
            this.lb_Mode.Size = new System.Drawing.Size(159, 71);
            this.lb_Mode.TabIndex = 31;
            this.lb_Mode.Text = "AUTORUN";
            this.lb_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CurruntModelName
            // 
            this.lb_CurruntModelName.AutoSize = true;
            this.lb_CurruntModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lb_CurruntModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CurruntModelName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CurruntModelName.Location = new System.Drawing.Point(1442, 3);
            this.lb_CurruntModelName.Margin = new System.Windows.Forms.Padding(2);
            this.lb_CurruntModelName.Name = "lb_CurruntModelName";
            this.lb_CurruntModelName.Size = new System.Drawing.Size(159, 71);
            this.lb_CurruntModelName.TabIndex = 1;
            this.lb_CurruntModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lb_Time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_Ver, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(216, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 69);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.BackColor = System.Drawing.Color.Black;
            this.lb_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Time.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Time.ForeColor = System.Drawing.Color.White;
            this.lb_Time.Location = new System.Drawing.Point(4, 1);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(230, 33);
            this.lb_Time.TabIndex = 0;
            this.lb_Time.Text = "0000-00-00 오전 00:00:00";
            this.lb_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Ver
            // 
            this.lb_Ver.AutoSize = true;
            this.lb_Ver.BackColor = System.Drawing.Color.Black;
            this.lb_Ver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Ver.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Ver.ForeColor = System.Drawing.Color.White;
            this.lb_Ver.Location = new System.Drawing.Point(4, 35);
            this.lb_Ver.Name = "lb_Ver";
            this.lb_Ver.Size = new System.Drawing.Size(230, 33);
            this.lb_Ver.TabIndex = 4;
            this.lb_Ver.Text = "Ver. 1.0.0";
            this.lb_Ver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Image = global::VISION.Properties.Resources.Close;
            this.btn_Exit.Location = new System.Drawing.Point(1814, 3);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(103, 71);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Stop.Image = global::VISION.Properties.Resources.Stop;
            this.btn_Stop.Location = new System.Drawing.Point(1710, 3);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(99, 71);
            this.btn_Stop.TabIndex = 9;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Status
            // 
            this.btn_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Status.Image = global::VISION.Properties.Resources.Run;
            this.btn_Status.Location = new System.Drawing.Point(1606, 3);
            this.btn_Status.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Status.Name = "btn_Status";
            this.btn_Status.Size = new System.Drawing.Size(99, 71);
            this.btn_Status.TabIndex = 5;
            this.btn_Status.UseVisualStyleBackColor = true;
            this.btn_Status.Click += new System.EventHandler(this.btn_Status_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = global::VISION.Properties.Resources.logo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 69);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(461, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 75);
            this.label1.TabIndex = 11;
            this.label1.Text = "PC1 Vision Program";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_PLCStats
            // 
            this.lb_PLCStats.AutoSize = true;
            this.lb_PLCStats.BackColor = System.Drawing.Color.Lime;
            this.lb_PLCStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_PLCStats.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_PLCStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_PLCStats.Location = new System.Drawing.Point(1114, 3);
            this.lb_PLCStats.Margin = new System.Windows.Forms.Padding(2);
            this.lb_PLCStats.Name = "lb_PLCStats";
            this.lb_PLCStats.Size = new System.Drawing.Size(159, 71);
            this.lb_PLCStats.TabIndex = 38;
            this.lb_PLCStats.Text = "PLC";
            this.lb_PLCStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_Setting
            // 
            this.timer_Setting.Tick += new System.EventHandler(this.timer_Setting_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.logControl1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel14, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1426, 917);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // logControl1
            // 
            this.logControl1.Color_ControlBack = System.Drawing.Color.Black;
            this.logControl1.Color_ErrorText = System.Drawing.Color.Red;
            this.logControl1.Color_NormalText = System.Drawing.Color.White;
            this.logControl1.Color_WarningText = System.Drawing.Color.Yellow;
            this.logControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logControl1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logControl1.Location = new System.Drawing.Point(954, 459);
            this.logControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(468, 457);
            this.logControl1.TabIndex = 41;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.cdyDisplay5, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel15, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(479, 462);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(468, 451);
            this.tableLayoutPanel14.TabIndex = 21;
            // 
            // cdyDisplay5
            // 
            this.cdyDisplay5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay5.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay5.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay5.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay5.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay5.Location = new System.Drawing.Point(4, 63);
            this.cdyDisplay5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay5.MouseWheelSensitivity = 1D;
            this.cdyDisplay5.Name = "cdyDisplay5";
            this.cdyDisplay5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay5.OcxState")));
            this.cdyDisplay5.Size = new System.Drawing.Size(460, 384);
            this.cdyDisplay5.TabIndex = 8;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel15.Controls.Add(this.lb_Cam5_Result, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.lb_Cam5Stats, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.lb_Cam5_InsTime, 2, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(460, 52);
            this.tableLayoutPanel15.TabIndex = 9;
            // 
            // lb_Cam5_Result
            // 
            this.lb_Cam5_Result.AutoSize = true;
            this.lb_Cam5_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam5_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam5_Result.Location = new System.Drawing.Point(96, 1);
            this.lb_Cam5_Result.Name = "lb_Cam5_Result";
            this.lb_Cam5_Result.Size = new System.Drawing.Size(222, 50);
            this.lb_Cam5_Result.TabIndex = 1;
            this.lb_Cam5_Result.Text = "Result";
            this.lb_Cam5_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam5Stats
            // 
            this.lb_Cam5Stats.AutoSize = true;
            this.lb_Cam5Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam5Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam5Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam5Stats.Name = "lb_Cam5Stats";
            this.lb_Cam5Stats.Size = new System.Drawing.Size(85, 50);
            this.lb_Cam5Stats.TabIndex = 0;
            this.lb_Cam5Stats.Text = "CAM 5";
            this.lb_Cam5Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam5Stats.Click += new System.EventHandler(this.lb_Cam5Stats_Click);
            // 
            // lb_Cam5_InsTime
            // 
            this.lb_Cam5_InsTime.AutoSize = true;
            this.lb_Cam5_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam5_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam5_InsTime.Location = new System.Drawing.Point(325, 1);
            this.lb_Cam5_InsTime.Name = "lb_Cam5_InsTime";
            this.lb_Cam5_InsTime.Size = new System.Drawing.Size(131, 50);
            this.lb_Cam5_InsTime.TabIndex = 2;
            this.lb_Cam5_InsTime.Text = "0 msec";
            this.lb_Cam5_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.cdyDisplay3, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(954, 4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(468, 451);
            this.tableLayoutPanel8.TabIndex = 20;
            // 
            // cdyDisplay3
            // 
            this.cdyDisplay3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay3.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay3.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay3.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay3.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay3.Location = new System.Drawing.Point(4, 63);
            this.cdyDisplay3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay3.MouseWheelSensitivity = 1D;
            this.cdyDisplay3.Name = "cdyDisplay3";
            this.cdyDisplay3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay3.OcxState")));
            this.cdyDisplay3.Size = new System.Drawing.Size(460, 384);
            this.cdyDisplay3.TabIndex = 8;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3_Result, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3Stats, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3_InsTime, 2, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(460, 52);
            this.tableLayoutPanel13.TabIndex = 9;
            // 
            // lb_Cam3_Result
            // 
            this.lb_Cam3_Result.AutoSize = true;
            this.lb_Cam3_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3_Result.Location = new System.Drawing.Point(96, 1);
            this.lb_Cam3_Result.Name = "lb_Cam3_Result";
            this.lb_Cam3_Result.Size = new System.Drawing.Size(222, 50);
            this.lb_Cam3_Result.TabIndex = 1;
            this.lb_Cam3_Result.Text = "Result";
            this.lb_Cam3_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam3Stats
            // 
            this.lb_Cam3Stats.AutoSize = true;
            this.lb_Cam3Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam3Stats.Name = "lb_Cam3Stats";
            this.lb_Cam3Stats.Size = new System.Drawing.Size(85, 50);
            this.lb_Cam3Stats.TabIndex = 0;
            this.lb_Cam3Stats.Text = "CAM 3";
            this.lb_Cam3Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam3Stats.Click += new System.EventHandler(this.lb_Cam3Stats_Click);
            // 
            // lb_Cam3_InsTime
            // 
            this.lb_Cam3_InsTime.AutoSize = true;
            this.lb_Cam3_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3_InsTime.Location = new System.Drawing.Point(325, 1);
            this.lb_Cam3_InsTime.Name = "lb_Cam3_InsTime";
            this.lb_Cam3_InsTime.Size = new System.Drawing.Size(131, 50);
            this.lb_Cam3_InsTime.TabIndex = 2;
            this.lb_Cam3_InsTime.Text = "0 msec";
            this.lb_Cam3_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cdyDisplay2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(479, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(468, 451);
            this.tableLayoutPanel5.TabIndex = 19;
            // 
            // cdyDisplay2
            // 
            this.cdyDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay2.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay2.Location = new System.Drawing.Point(4, 63);
            this.cdyDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay2.MouseWheelSensitivity = 1D;
            this.cdyDisplay2.Name = "cdyDisplay2";
            this.cdyDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay2.OcxState")));
            this.cdyDisplay2.Size = new System.Drawing.Size(460, 384);
            this.cdyDisplay2.TabIndex = 8;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2_Result, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2Stats, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2_InsTime, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(460, 52);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // lb_Cam2_Result
            // 
            this.lb_Cam2_Result.AutoSize = true;
            this.lb_Cam2_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2_Result.Location = new System.Drawing.Point(96, 1);
            this.lb_Cam2_Result.Name = "lb_Cam2_Result";
            this.lb_Cam2_Result.Size = new System.Drawing.Size(222, 50);
            this.lb_Cam2_Result.TabIndex = 1;
            this.lb_Cam2_Result.Text = "Result";
            this.lb_Cam2_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam2Stats
            // 
            this.lb_Cam2Stats.AutoSize = true;
            this.lb_Cam2Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam2Stats.Name = "lb_Cam2Stats";
            this.lb_Cam2Stats.Size = new System.Drawing.Size(85, 50);
            this.lb_Cam2Stats.TabIndex = 0;
            this.lb_Cam2Stats.Text = "CAM 2";
            this.lb_Cam2Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam2Stats.Click += new System.EventHandler(this.lb_Cam2Stats_Click);
            // 
            // lb_Cam2_InsTime
            // 
            this.lb_Cam2_InsTime.AutoSize = true;
            this.lb_Cam2_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2_InsTime.Location = new System.Drawing.Point(325, 1);
            this.lb_Cam2_InsTime.Name = "lb_Cam2_InsTime";
            this.lb_Cam2_InsTime.Size = new System.Drawing.Size(131, 50);
            this.lb_Cam2_InsTime.TabIndex = 2;
            this.lb_Cam2_InsTime.Text = "0 msec";
            this.lb_Cam2_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cdyDisplay4, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 462);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(468, 451);
            this.tableLayoutPanel7.TabIndex = 16;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel11.ColumnCount = 3;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel11.Controls.Add(this.lb_Cam4_Result, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.lb_Cam4Stats, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.lb_Cam4_InsTime, 2, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(462, 52);
            this.tableLayoutPanel11.TabIndex = 10;
            // 
            // lb_Cam4_Result
            // 
            this.lb_Cam4_Result.AutoSize = true;
            this.lb_Cam4_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam4_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam4_Result.Location = new System.Drawing.Point(96, 1);
            this.lb_Cam4_Result.Name = "lb_Cam4_Result";
            this.lb_Cam4_Result.Size = new System.Drawing.Size(223, 50);
            this.lb_Cam4_Result.TabIndex = 1;
            this.lb_Cam4_Result.Text = "Result";
            this.lb_Cam4_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam4Stats
            // 
            this.lb_Cam4Stats.AutoSize = true;
            this.lb_Cam4Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam4Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam4Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam4Stats.Name = "lb_Cam4Stats";
            this.lb_Cam4Stats.Size = new System.Drawing.Size(85, 50);
            this.lb_Cam4Stats.TabIndex = 0;
            this.lb_Cam4Stats.Text = "CAM 4";
            this.lb_Cam4Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam4Stats.Click += new System.EventHandler(this.lb_Cam4Stats_Click);
            // 
            // lb_Cam4_InsTime
            // 
            this.lb_Cam4_InsTime.AutoSize = true;
            this.lb_Cam4_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam4_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam4_InsTime.Location = new System.Drawing.Point(326, 1);
            this.lb_Cam4_InsTime.Name = "lb_Cam4_InsTime";
            this.lb_Cam4_InsTime.Size = new System.Drawing.Size(132, 50);
            this.lb_Cam4_InsTime.TabIndex = 2;
            this.lb_Cam4_InsTime.Text = "0 msec";
            this.lb_Cam4_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cdyDisplay4
            // 
            this.cdyDisplay4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay4.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay4.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay4.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay4.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay4.Location = new System.Drawing.Point(3, 61);
            this.cdyDisplay4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay4.MouseWheelSensitivity = 1D;
            this.cdyDisplay4.Name = "cdyDisplay4";
            this.cdyDisplay4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay4.OcxState")));
            this.cdyDisplay4.Size = new System.Drawing.Size(462, 387);
            this.cdyDisplay4.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cdyDisplay, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(468, 451);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // cdyDisplay
            // 
            this.cdyDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay.Location = new System.Drawing.Point(4, 63);
            this.cdyDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay.MouseWheelSensitivity = 1D;
            this.cdyDisplay.Name = "cdyDisplay";
            this.cdyDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay.OcxState")));
            this.cdyDisplay.Size = new System.Drawing.Size(460, 384);
            this.cdyDisplay.TabIndex = 8;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1Stats, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1_Result, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1_InsTime, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(460, 52);
            this.tableLayoutPanel10.TabIndex = 9;
            // 
            // lb_Cam1Stats
            // 
            this.lb_Cam1Stats.AutoSize = true;
            this.lb_Cam1Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam1Stats.Name = "lb_Cam1Stats";
            this.lb_Cam1Stats.Size = new System.Drawing.Size(85, 50);
            this.lb_Cam1Stats.TabIndex = 0;
            this.lb_Cam1Stats.Text = "CAM 1";
            this.lb_Cam1Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam1Stats.Click += new System.EventHandler(this.lb_Cam1Stats_Click);
            // 
            // lb_Cam1_Result
            // 
            this.lb_Cam1_Result.AutoSize = true;
            this.lb_Cam1_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1_Result.Location = new System.Drawing.Point(96, 1);
            this.lb_Cam1_Result.Name = "lb_Cam1_Result";
            this.lb_Cam1_Result.Size = new System.Drawing.Size(222, 50);
            this.lb_Cam1_Result.TabIndex = 1;
            this.lb_Cam1_Result.Text = "Result";
            this.lb_Cam1_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam1_InsTime
            // 
            this.lb_Cam1_InsTime.AutoSize = true;
            this.lb_Cam1_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1_InsTime.Location = new System.Drawing.Point(325, 1);
            this.lb_Cam1_InsTime.Name = "lb_Cam1_InsTime";
            this.lb_Cam1_InsTime.Size = new System.Drawing.Size(131, 50);
            this.lb_Cam1_InsTime.TabIndex = 3;
            this.lb_Cam1_InsTime.Text = "0 msec";
            this.lb_Cam1_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel21);
            this.tabPage2.Controls.Add(this.tableLayoutPanel20);
            this.tabPage2.Controls.Add(this.tableLayoutPanel19);
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel21.ColumnCount = 6;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel21.Controls.Add(this.btnConnect, 5, 0);
            this.tableLayoutPanel21.Controls.Add(this.textBoxIP2, 3, 0);
            this.tableLayoutPanel21.Controls.Add(this.lbConnTitle, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.textBoxIP3, 4, 0);
            this.tableLayoutPanel21.Controls.Add(this.textBoxIP1, 2, 0);
            this.tableLayoutPanel21.Controls.Add(this.textBoxIP0, 1, 0);
            this.tableLayoutPanel21.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 1;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(478, 34);
            this.tableLayoutPanel21.TabIndex = 45;
            // 
            // btnConnect
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.Location = new System.Drawing.Point(399, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 26);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "연결하기";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textBoxIP2
            // 
            this.textBoxIP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIP2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxIP2.Location = new System.Drawing.Point(241, 4);
            this.textBoxIP2.Name = "textBoxIP2";
            this.textBoxIP2.Size = new System.Drawing.Size(72, 25);
            this.textBoxIP2.TabIndex = 2;
            this.textBoxIP2.Text = "0";
            this.textBoxIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbConnTitle
            // 
            this.lbConnTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbConnTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbConnTitle.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbConnTitle.ForeColor = System.Drawing.Color.White;
            this.lbConnTitle.Location = new System.Drawing.Point(4, 1);
            this.lbConnTitle.Name = "lbConnTitle";
            this.lbConnTitle.Size = new System.Drawing.Size(72, 32);
            this.lbConnTitle.TabIndex = 0;
            this.lbConnTitle.Text = "IP";
            this.lbConnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxIP3
            // 
            this.textBoxIP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIP3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxIP3.Location = new System.Drawing.Point(320, 4);
            this.textBoxIP3.Name = "textBoxIP3";
            this.textBoxIP3.Size = new System.Drawing.Size(72, 25);
            this.textBoxIP3.TabIndex = 1;
            this.textBoxIP3.Text = "220";
            this.textBoxIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxIP1
            // 
            this.textBoxIP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIP1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxIP1.Location = new System.Drawing.Point(162, 4);
            this.textBoxIP1.Name = "textBoxIP1";
            this.textBoxIP1.Size = new System.Drawing.Size(72, 25);
            this.textBoxIP1.TabIndex = 3;
            this.textBoxIP1.Text = "168";
            this.textBoxIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxIP0
            // 
            this.textBoxIP0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIP0.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBoxIP0.Location = new System.Drawing.Point(83, 4);
            this.textBoxIP0.Name = "textBoxIP0";
            this.textBoxIP0.Size = new System.Drawing.Size(72, 25);
            this.textBoxIP0.TabIndex = 4;
            this.textBoxIP0.Text = "192";
            this.textBoxIP0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel20.ColumnCount = 1;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 2;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(104, 589);
            this.tableLayoutPanel20.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 293);
            this.label2.TabIndex = 0;
            this.label2.Text = "INPUT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 293);
            this.label3.TabIndex = 1;
            this.label3.Text = "OUTPUT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel19.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Controls.Add(this.btn_Output17, 1, 8);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output7, 0, 7);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output16, 1, 7);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output15, 1, 6);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output6, 0, 6);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output14, 1, 5);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output13, 1, 4);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output5, 0, 5);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output12, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output4, 0, 4);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output0, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output3, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output1, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output2, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output11, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output10, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output9, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.btn_Output8, 0, 8);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(109, 334);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 9;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(372, 294);
            this.tableLayoutPanel19.TabIndex = 44;
            // 
            // btn_Output17
            // 
            this.btn_Output17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output17.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output17.Location = new System.Drawing.Point(189, 260);
            this.btn_Output17.Name = "btn_Output17";
            this.btn_Output17.Size = new System.Drawing.Size(179, 30);
            this.btn_Output17.TabIndex = 52;
            this.btn_Output17.Tag = "";
            this.btn_Output17.UseVisualStyleBackColor = true;
            // 
            // btn_Output7
            // 
            this.btn_Output7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output7.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output7.Location = new System.Drawing.Point(4, 228);
            this.btn_Output7.Name = "btn_Output7";
            this.btn_Output7.Size = new System.Drawing.Size(178, 25);
            this.btn_Output7.TabIndex = 42;
            this.btn_Output7.Tag = "";
            this.btn_Output7.UseVisualStyleBackColor = true;
            // 
            // btn_Output16
            // 
            this.btn_Output16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output16.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output16.Location = new System.Drawing.Point(189, 228);
            this.btn_Output16.Name = "btn_Output16";
            this.btn_Output16.Size = new System.Drawing.Size(179, 25);
            this.btn_Output16.TabIndex = 51;
            this.btn_Output16.Tag = "";
            this.btn_Output16.UseVisualStyleBackColor = true;
            // 
            // btn_Output15
            // 
            this.btn_Output15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output15.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output15.Location = new System.Drawing.Point(189, 196);
            this.btn_Output15.Name = "btn_Output15";
            this.btn_Output15.Size = new System.Drawing.Size(179, 25);
            this.btn_Output15.TabIndex = 50;
            this.btn_Output15.Tag = "";
            this.btn_Output15.UseVisualStyleBackColor = true;
            // 
            // btn_Output6
            // 
            this.btn_Output6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output6.Location = new System.Drawing.Point(4, 196);
            this.btn_Output6.Name = "btn_Output6";
            this.btn_Output6.Size = new System.Drawing.Size(178, 25);
            this.btn_Output6.TabIndex = 41;
            this.btn_Output6.Tag = "";
            this.btn_Output6.UseVisualStyleBackColor = true;
            // 
            // btn_Output14
            // 
            this.btn_Output14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output14.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output14.Location = new System.Drawing.Point(189, 164);
            this.btn_Output14.Name = "btn_Output14";
            this.btn_Output14.Size = new System.Drawing.Size(179, 25);
            this.btn_Output14.TabIndex = 49;
            this.btn_Output14.Tag = "";
            this.btn_Output14.UseVisualStyleBackColor = true;
            // 
            // btn_Output13
            // 
            this.btn_Output13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output13.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output13.Location = new System.Drawing.Point(189, 132);
            this.btn_Output13.Name = "btn_Output13";
            this.btn_Output13.Size = new System.Drawing.Size(179, 25);
            this.btn_Output13.TabIndex = 48;
            this.btn_Output13.Tag = "9";
            this.btn_Output13.Text = "CAM5 NG";
            this.btn_Output13.UseVisualStyleBackColor = true;
            this.btn_Output13.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output5
            // 
            this.btn_Output5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output5.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output5.Location = new System.Drawing.Point(4, 164);
            this.btn_Output5.Name = "btn_Output5";
            this.btn_Output5.Size = new System.Drawing.Size(178, 25);
            this.btn_Output5.TabIndex = 40;
            this.btn_Output5.Tag = "5";
            this.btn_Output5.UseVisualStyleBackColor = true;
            // 
            // btn_Output12
            // 
            this.btn_Output12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output12.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output12.Location = new System.Drawing.Point(189, 100);
            this.btn_Output12.Name = "btn_Output12";
            this.btn_Output12.Size = new System.Drawing.Size(179, 25);
            this.btn_Output12.TabIndex = 47;
            this.btn_Output12.Tag = "7";
            this.btn_Output12.Text = "CAM4 NG";
            this.btn_Output12.UseVisualStyleBackColor = true;
            this.btn_Output12.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output4
            // 
            this.btn_Output4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output4.Location = new System.Drawing.Point(4, 132);
            this.btn_Output4.Name = "btn_Output4";
            this.btn_Output4.Size = new System.Drawing.Size(178, 25);
            this.btn_Output4.TabIndex = 39;
            this.btn_Output4.Tag = "8";
            this.btn_Output4.Text = "CAM5 OK";
            this.btn_Output4.UseVisualStyleBackColor = true;
            this.btn_Output4.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output0
            // 
            this.btn_Output0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output0.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output0.Location = new System.Drawing.Point(4, 4);
            this.btn_Output0.Name = "btn_Output0";
            this.btn_Output0.Size = new System.Drawing.Size(178, 25);
            this.btn_Output0.TabIndex = 35;
            this.btn_Output0.Tag = "0";
            this.btn_Output0.Text = "CAM1 OK";
            this.btn_Output0.UseVisualStyleBackColor = true;
            this.btn_Output0.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output3
            // 
            this.btn_Output3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output3.Location = new System.Drawing.Point(4, 100);
            this.btn_Output3.Name = "btn_Output3";
            this.btn_Output3.Size = new System.Drawing.Size(178, 25);
            this.btn_Output3.TabIndex = 38;
            this.btn_Output3.Tag = "6";
            this.btn_Output3.Text = "CAM4 OK";
            this.btn_Output3.UseVisualStyleBackColor = true;
            this.btn_Output3.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output1
            // 
            this.btn_Output1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output1.Location = new System.Drawing.Point(4, 36);
            this.btn_Output1.Name = "btn_Output1";
            this.btn_Output1.Size = new System.Drawing.Size(178, 25);
            this.btn_Output1.TabIndex = 36;
            this.btn_Output1.Tag = "2";
            this.btn_Output1.Text = "CAM2 OK";
            this.btn_Output1.UseVisualStyleBackColor = true;
            this.btn_Output1.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output2
            // 
            this.btn_Output2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output2.Location = new System.Drawing.Point(4, 68);
            this.btn_Output2.Name = "btn_Output2";
            this.btn_Output2.Size = new System.Drawing.Size(178, 25);
            this.btn_Output2.TabIndex = 37;
            this.btn_Output2.Tag = "4";
            this.btn_Output2.Text = "CAM3 OK";
            this.btn_Output2.UseVisualStyleBackColor = true;
            this.btn_Output2.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output11
            // 
            this.btn_Output11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output11.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output11.Location = new System.Drawing.Point(189, 68);
            this.btn_Output11.Name = "btn_Output11";
            this.btn_Output11.Size = new System.Drawing.Size(179, 25);
            this.btn_Output11.TabIndex = 46;
            this.btn_Output11.Tag = "5";
            this.btn_Output11.Text = "CAM3 NG";
            this.btn_Output11.UseVisualStyleBackColor = true;
            this.btn_Output11.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output10
            // 
            this.btn_Output10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output10.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output10.Location = new System.Drawing.Point(189, 36);
            this.btn_Output10.Name = "btn_Output10";
            this.btn_Output10.Size = new System.Drawing.Size(179, 25);
            this.btn_Output10.TabIndex = 45;
            this.btn_Output10.Tag = "3";
            this.btn_Output10.Text = "CAM2 NG";
            this.btn_Output10.UseVisualStyleBackColor = true;
            this.btn_Output10.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output9
            // 
            this.btn_Output9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output9.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output9.Location = new System.Drawing.Point(189, 4);
            this.btn_Output9.Name = "btn_Output9";
            this.btn_Output9.Size = new System.Drawing.Size(179, 25);
            this.btn_Output9.TabIndex = 44;
            this.btn_Output9.Tag = "1";
            this.btn_Output9.Text = "CAM1 NG";
            this.btn_Output9.UseVisualStyleBackColor = true;
            this.btn_Output9.Click += new System.EventHandler(this.OutPutSignal);
            // 
            // btn_Output8
            // 
            this.btn_Output8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output8.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output8.Location = new System.Drawing.Point(4, 260);
            this.btn_Output8.Name = "btn_Output8";
            this.btn_Output8.Size = new System.Drawing.Size(178, 30);
            this.btn_Output8.TabIndex = 43;
            this.btn_Output8.Tag = "";
            this.btn_Output8.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT17, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT16, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT15, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT14, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT13, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT12, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT11, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT10, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT8, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT0, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT3, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT5, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT6, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT7, 0, 7);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(109, 39);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(372, 294);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btn_INPUT17
            // 
            this.btn_INPUT17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT17.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT17.Location = new System.Drawing.Point(189, 260);
            this.btn_INPUT17.Name = "btn_INPUT17";
            this.btn_INPUT17.Size = new System.Drawing.Size(179, 30);
            this.btn_INPUT17.TabIndex = 52;
            this.btn_INPUT17.Tag = "17";
            this.btn_INPUT17.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT16
            // 
            this.btn_INPUT16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT16.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT16.Location = new System.Drawing.Point(189, 228);
            this.btn_INPUT16.Name = "btn_INPUT16";
            this.btn_INPUT16.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT16.TabIndex = 51;
            this.btn_INPUT16.Tag = "16";
            this.btn_INPUT16.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT15
            // 
            this.btn_INPUT15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT15.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT15.Location = new System.Drawing.Point(189, 196);
            this.btn_INPUT15.Name = "btn_INPUT15";
            this.btn_INPUT15.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT15.TabIndex = 50;
            this.btn_INPUT15.Tag = "15";
            this.btn_INPUT15.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT14
            // 
            this.btn_INPUT14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT14.Location = new System.Drawing.Point(189, 164);
            this.btn_INPUT14.Name = "btn_INPUT14";
            this.btn_INPUT14.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT14.TabIndex = 49;
            this.btn_INPUT14.Tag = "14";
            this.btn_INPUT14.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT13
            // 
            this.btn_INPUT13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT13.Location = new System.Drawing.Point(189, 132);
            this.btn_INPUT13.Name = "btn_INPUT13";
            this.btn_INPUT13.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT13.TabIndex = 48;
            this.btn_INPUT13.Tag = "";
            this.btn_INPUT13.Text = "CAM5 Trigger";
            this.btn_INPUT13.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT12
            // 
            this.btn_INPUT12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT12.Location = new System.Drawing.Point(189, 100);
            this.btn_INPUT12.Name = "btn_INPUT12";
            this.btn_INPUT12.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT12.TabIndex = 47;
            this.btn_INPUT12.Tag = "";
            this.btn_INPUT12.Text = "CAM4 Trigger";
            this.btn_INPUT12.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT11
            // 
            this.btn_INPUT11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT11.Location = new System.Drawing.Point(189, 68);
            this.btn_INPUT11.Name = "btn_INPUT11";
            this.btn_INPUT11.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT11.TabIndex = 46;
            this.btn_INPUT11.Tag = "";
            this.btn_INPUT11.Text = "CAM3 Trigger";
            this.btn_INPUT11.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT10
            // 
            this.btn_INPUT10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT10.Location = new System.Drawing.Point(189, 36);
            this.btn_INPUT10.Name = "btn_INPUT10";
            this.btn_INPUT10.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT10.TabIndex = 45;
            this.btn_INPUT10.Tag = "";
            this.btn_INPUT10.Text = "CAM2 Trigger";
            this.btn_INPUT10.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT9
            // 
            this.btn_INPUT9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT9.Location = new System.Drawing.Point(189, 4);
            this.btn_INPUT9.Name = "btn_INPUT9";
            this.btn_INPUT9.Size = new System.Drawing.Size(179, 25);
            this.btn_INPUT9.TabIndex = 44;
            this.btn_INPUT9.Tag = "";
            this.btn_INPUT9.Text = "CAM1 Trigger";
            this.btn_INPUT9.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT8
            // 
            this.btn_INPUT8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT8.Location = new System.Drawing.Point(4, 260);
            this.btn_INPUT8.Name = "btn_INPUT8";
            this.btn_INPUT8.Size = new System.Drawing.Size(178, 30);
            this.btn_INPUT8.TabIndex = 43;
            this.btn_INPUT8.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT0
            // 
            this.btn_INPUT0.BackColor = System.Drawing.Color.LightGray;
            this.btn_INPUT0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT0.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT0.Location = new System.Drawing.Point(4, 4);
            this.btn_INPUT0.Name = "btn_INPUT0";
            this.btn_INPUT0.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT0.TabIndex = 2;
            this.btn_INPUT0.Text = "Vision1 Ready";
            this.btn_INPUT0.UseVisualStyleBackColor = false;
            // 
            // btn_INPUT1
            // 
            this.btn_INPUT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT1.Location = new System.Drawing.Point(4, 36);
            this.btn_INPUT1.Name = "btn_INPUT1";
            this.btn_INPUT1.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT1.TabIndex = 4;
            this.btn_INPUT1.Text = "Vision2 Ready";
            this.btn_INPUT1.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT2
            // 
            this.btn_INPUT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT2.Location = new System.Drawing.Point(4, 68);
            this.btn_INPUT2.Name = "btn_INPUT2";
            this.btn_INPUT2.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT2.TabIndex = 6;
            this.btn_INPUT2.Text = "Vision3 Ready";
            this.btn_INPUT2.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT3
            // 
            this.btn_INPUT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT3.Location = new System.Drawing.Point(4, 100);
            this.btn_INPUT3.Name = "btn_INPUT3";
            this.btn_INPUT3.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT3.TabIndex = 8;
            this.btn_INPUT3.Text = "Vision4 Ready";
            this.btn_INPUT3.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT4
            // 
            this.btn_INPUT4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT4.Location = new System.Drawing.Point(4, 132);
            this.btn_INPUT4.Name = "btn_INPUT4";
            this.btn_INPUT4.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT4.TabIndex = 10;
            this.btn_INPUT4.Text = "Vision5 Ready";
            this.btn_INPUT4.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT5
            // 
            this.btn_INPUT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT5.Location = new System.Drawing.Point(4, 164);
            this.btn_INPUT5.Name = "btn_INPUT5";
            this.btn_INPUT5.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT5.TabIndex = 12;
            this.btn_INPUT5.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT6
            // 
            this.btn_INPUT6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT6.Location = new System.Drawing.Point(4, 196);
            this.btn_INPUT6.Name = "btn_INPUT6";
            this.btn_INPUT6.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT6.TabIndex = 14;
            this.btn_INPUT6.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT7
            // 
            this.btn_INPUT7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT7.Location = new System.Drawing.Point(4, 228);
            this.btn_INPUT7.Name = "btn_INPUT7";
            this.btn_INPUT7.Size = new System.Drawing.Size(178, 25);
            this.btn_INPUT7.TabIndex = 16;
            this.btn_INPUT7.UseVisualStyleBackColor = true;
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.tabPage2);
            this.Main_TabControl.Controls.Add(this.tabPage5);
            this.Main_TabControl.Location = new System.Drawing.Point(1428, 338);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new System.Drawing.Size(492, 656);
            this.Main_TabControl.TabIndex = 25;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableLayoutPanel27);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(484, 630);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel27.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel29, 1, 4);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel28, 1, 3);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel18, 1, 2);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel17, 1, 1);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel16, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel27.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel27.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel27.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 5;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(478, 624);
            this.tableLayoutPanel27.TabIndex = 0;
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel29.ColumnCount = 2;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel29.Controls.Add(this.lb_CAM5_NGRATE, 1, 3);
            this.tableLayoutPanel29.Controls.Add(this.label51, 0, 3);
            this.tableLayoutPanel29.Controls.Add(this.lb_CAM5_TOTAL, 1, 2);
            this.tableLayoutPanel29.Controls.Add(this.label53, 0, 2);
            this.tableLayoutPanel29.Controls.Add(this.lb_CAM5_NG, 1, 1);
            this.tableLayoutPanel29.Controls.Add(this.label55, 0, 1);
            this.tableLayoutPanel29.Controls.Add(this.lb_CAM5_OK, 1, 0);
            this.tableLayoutPanel29.Controls.Add(this.label57, 0, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(100, 500);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 4;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(374, 120);
            this.tableLayoutPanel29.TabIndex = 10;
            // 
            // lb_CAM5_NGRATE
            // 
            this.lb_CAM5_NGRATE.AutoSize = true;
            this.lb_CAM5_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM5_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM5_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM5_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM5_NGRATE.Location = new System.Drawing.Point(116, 88);
            this.lb_CAM5_NGRATE.Name = "lb_CAM5_NGRATE";
            this.lb_CAM5_NGRATE.Size = new System.Drawing.Size(254, 31);
            this.lb_CAM5_NGRATE.TabIndex = 7;
            this.lb_CAM5_NGRATE.Text = "0";
            this.lb_CAM5_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label51.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label51.ForeColor = System.Drawing.Color.Yellow;
            this.label51.Location = new System.Drawing.Point(4, 88);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(105, 31);
            this.label51.TabIndex = 6;
            this.label51.Text = "NG RATE";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM5_TOTAL
            // 
            this.lb_CAM5_TOTAL.AutoSize = true;
            this.lb_CAM5_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM5_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM5_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM5_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM5_TOTAL.Location = new System.Drawing.Point(116, 59);
            this.lb_CAM5_TOTAL.Name = "lb_CAM5_TOTAL";
            this.lb_CAM5_TOTAL.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM5_TOTAL.TabIndex = 5;
            this.lb_CAM5_TOTAL.Text = "0";
            this.lb_CAM5_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label53.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(4, 59);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(105, 28);
            this.label53.TabIndex = 4;
            this.label53.Text = "TOTAL";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM5_NG
            // 
            this.lb_CAM5_NG.AutoSize = true;
            this.lb_CAM5_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM5_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM5_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM5_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM5_NG.Location = new System.Drawing.Point(116, 30);
            this.lb_CAM5_NG.Name = "lb_CAM5_NG";
            this.lb_CAM5_NG.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM5_NG.TabIndex = 3;
            this.lb_CAM5_NG.Text = "0";
            this.lb_CAM5_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Black;
            this.label55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label55.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label55.ForeColor = System.Drawing.Color.Red;
            this.label55.Location = new System.Drawing.Point(4, 30);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(105, 28);
            this.label55.TabIndex = 2;
            this.label55.Text = "NG";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM5_OK
            // 
            this.lb_CAM5_OK.AutoSize = true;
            this.lb_CAM5_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM5_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM5_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM5_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM5_OK.Location = new System.Drawing.Point(116, 1);
            this.lb_CAM5_OK.Name = "lb_CAM5_OK";
            this.lb_CAM5_OK.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM5_OK.TabIndex = 1;
            this.lb_CAM5_OK.Text = "0";
            this.lb_CAM5_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label57.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label57.ForeColor = System.Drawing.Color.Lime;
            this.label57.Location = new System.Drawing.Point(4, 1);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(105, 28);
            this.label57.TabIndex = 0;
            this.label57.Text = "OK";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel28.ColumnCount = 2;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel28.Controls.Add(this.lb_CAM4_NGRATE, 1, 3);
            this.tableLayoutPanel28.Controls.Add(this.label43, 0, 3);
            this.tableLayoutPanel28.Controls.Add(this.lb_CAM4_TOTAL, 1, 2);
            this.tableLayoutPanel28.Controls.Add(this.label45, 0, 2);
            this.tableLayoutPanel28.Controls.Add(this.lb_CAM4_NG, 1, 1);
            this.tableLayoutPanel28.Controls.Add(this.label47, 0, 1);
            this.tableLayoutPanel28.Controls.Add(this.lb_CAM4_OK, 1, 0);
            this.tableLayoutPanel28.Controls.Add(this.label49, 0, 0);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(100, 376);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 4;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(374, 117);
            this.tableLayoutPanel28.TabIndex = 9;
            // 
            // lb_CAM4_NGRATE
            // 
            this.lb_CAM4_NGRATE.AutoSize = true;
            this.lb_CAM4_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM4_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM4_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM4_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM4_NGRATE.Location = new System.Drawing.Point(116, 88);
            this.lb_CAM4_NGRATE.Name = "lb_CAM4_NGRATE";
            this.lb_CAM4_NGRATE.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM4_NGRATE.TabIndex = 7;
            this.lb_CAM4_NGRATE.Text = "0";
            this.lb_CAM4_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Black;
            this.label43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label43.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label43.ForeColor = System.Drawing.Color.Yellow;
            this.label43.Location = new System.Drawing.Point(4, 88);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(105, 28);
            this.label43.TabIndex = 6;
            this.label43.Text = "NG RATE";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM4_TOTAL
            // 
            this.lb_CAM4_TOTAL.AutoSize = true;
            this.lb_CAM4_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM4_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM4_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM4_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM4_TOTAL.Location = new System.Drawing.Point(116, 59);
            this.lb_CAM4_TOTAL.Name = "lb_CAM4_TOTAL";
            this.lb_CAM4_TOTAL.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM4_TOTAL.TabIndex = 5;
            this.lb_CAM4_TOTAL.Text = "0";
            this.lb_CAM4_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Black;
            this.label45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label45.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(4, 59);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(105, 28);
            this.label45.TabIndex = 4;
            this.label45.Text = "TOTAL";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM4_NG
            // 
            this.lb_CAM4_NG.AutoSize = true;
            this.lb_CAM4_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM4_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM4_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM4_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM4_NG.Location = new System.Drawing.Point(116, 30);
            this.lb_CAM4_NG.Name = "lb_CAM4_NG";
            this.lb_CAM4_NG.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM4_NG.TabIndex = 3;
            this.lb_CAM4_NG.Text = "0";
            this.lb_CAM4_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.Black;
            this.label47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label47.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label47.ForeColor = System.Drawing.Color.Red;
            this.label47.Location = new System.Drawing.Point(4, 30);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(105, 28);
            this.label47.TabIndex = 2;
            this.label47.Text = "NG";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM4_OK
            // 
            this.lb_CAM4_OK.AutoSize = true;
            this.lb_CAM4_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM4_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM4_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM4_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM4_OK.Location = new System.Drawing.Point(116, 1);
            this.lb_CAM4_OK.Name = "lb_CAM4_OK";
            this.lb_CAM4_OK.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM4_OK.TabIndex = 1;
            this.lb_CAM4_OK.Text = "0";
            this.lb_CAM4_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label49.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label49.ForeColor = System.Drawing.Color.Lime;
            this.label49.Location = new System.Drawing.Point(4, 1);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(105, 28);
            this.label49.TabIndex = 0;
            this.label49.Text = "OK";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_NGRATE, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.label35, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_TOTAL, 1, 2);
            this.tableLayoutPanel18.Controls.Add(this.label37, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_NG, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.label39, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_OK, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.label41, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(100, 252);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 4;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(374, 117);
            this.tableLayoutPanel18.TabIndex = 8;
            // 
            // lb_CAM3_NGRATE
            // 
            this.lb_CAM3_NGRATE.AutoSize = true;
            this.lb_CAM3_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM3_NGRATE.Location = new System.Drawing.Point(116, 88);
            this.lb_CAM3_NGRATE.Name = "lb_CAM3_NGRATE";
            this.lb_CAM3_NGRATE.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM3_NGRATE.TabIndex = 7;
            this.lb_CAM3_NGRATE.Text = "0";
            this.lb_CAM3_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.ForeColor = System.Drawing.Color.Yellow;
            this.label35.Location = new System.Drawing.Point(4, 88);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(105, 28);
            this.label35.TabIndex = 6;
            this.label35.Text = "NG RATE";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_TOTAL
            // 
            this.lb_CAM3_TOTAL.AutoSize = true;
            this.lb_CAM3_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM3_TOTAL.Location = new System.Drawing.Point(116, 59);
            this.lb_CAM3_TOTAL.Name = "lb_CAM3_TOTAL";
            this.lb_CAM3_TOTAL.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM3_TOTAL.TabIndex = 5;
            this.lb_CAM3_TOTAL.Text = "0";
            this.lb_CAM3_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(4, 59);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(105, 28);
            this.label37.TabIndex = 4;
            this.label37.Text = "TOTAL";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_NG
            // 
            this.lb_CAM3_NG.AutoSize = true;
            this.lb_CAM3_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM3_NG.Location = new System.Drawing.Point(116, 30);
            this.lb_CAM3_NG.Name = "lb_CAM3_NG";
            this.lb_CAM3_NG.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM3_NG.TabIndex = 3;
            this.lb_CAM3_NG.Text = "0";
            this.lb_CAM3_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Black;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label39.ForeColor = System.Drawing.Color.Red;
            this.label39.Location = new System.Drawing.Point(4, 30);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(105, 28);
            this.label39.TabIndex = 2;
            this.label39.Text = "NG";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_OK
            // 
            this.lb_CAM3_OK.AutoSize = true;
            this.lb_CAM3_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM3_OK.Location = new System.Drawing.Point(116, 1);
            this.lb_CAM3_OK.Name = "lb_CAM3_OK";
            this.lb_CAM3_OK.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM3_OK.TabIndex = 1;
            this.lb_CAM3_OK.Text = "0";
            this.lb_CAM3_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Black;
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label41.ForeColor = System.Drawing.Color.Lime;
            this.label41.Location = new System.Drawing.Point(4, 1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(105, 28);
            this.label41.TabIndex = 0;
            this.label41.Text = "OK";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_NGRATE, 1, 3);
            this.tableLayoutPanel17.Controls.Add(this.label27, 0, 3);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_TOTAL, 1, 2);
            this.tableLayoutPanel17.Controls.Add(this.label29, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_NG, 1, 1);
            this.tableLayoutPanel17.Controls.Add(this.label31, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_OK, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.label33, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(100, 128);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 4;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(374, 117);
            this.tableLayoutPanel17.TabIndex = 7;
            // 
            // lb_CAM2_NGRATE
            // 
            this.lb_CAM2_NGRATE.AutoSize = true;
            this.lb_CAM2_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM2_NGRATE.Location = new System.Drawing.Point(116, 88);
            this.lb_CAM2_NGRATE.Name = "lb_CAM2_NGRATE";
            this.lb_CAM2_NGRATE.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM2_NGRATE.TabIndex = 7;
            this.lb_CAM2_NGRATE.Text = "0";
            this.lb_CAM2_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.Yellow;
            this.label27.Location = new System.Drawing.Point(4, 88);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(105, 28);
            this.label27.TabIndex = 6;
            this.label27.Text = "NG RATE";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_TOTAL
            // 
            this.lb_CAM2_TOTAL.AutoSize = true;
            this.lb_CAM2_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM2_TOTAL.Location = new System.Drawing.Point(116, 59);
            this.lb_CAM2_TOTAL.Name = "lb_CAM2_TOTAL";
            this.lb_CAM2_TOTAL.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM2_TOTAL.TabIndex = 5;
            this.lb_CAM2_TOTAL.Text = "0";
            this.lb_CAM2_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Black;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(4, 59);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 28);
            this.label29.TabIndex = 4;
            this.label29.Text = "TOTAL";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_NG
            // 
            this.lb_CAM2_NG.AutoSize = true;
            this.lb_CAM2_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM2_NG.Location = new System.Drawing.Point(116, 30);
            this.lb_CAM2_NG.Name = "lb_CAM2_NG";
            this.lb_CAM2_NG.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM2_NG.TabIndex = 3;
            this.lb_CAM2_NG.Text = "0";
            this.lb_CAM2_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Black;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Location = new System.Drawing.Point(4, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(105, 28);
            this.label31.TabIndex = 2;
            this.label31.Text = "NG";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_OK
            // 
            this.lb_CAM2_OK.AutoSize = true;
            this.lb_CAM2_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM2_OK.Location = new System.Drawing.Point(116, 1);
            this.lb_CAM2_OK.Name = "lb_CAM2_OK";
            this.lb_CAM2_OK.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM2_OK.TabIndex = 1;
            this.lb_CAM2_OK.Text = "0";
            this.lb_CAM2_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.ForeColor = System.Drawing.Color.Lime;
            this.label33.Location = new System.Drawing.Point(4, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(105, 28);
            this.label33.TabIndex = 0;
            this.label33.Text = "OK";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel16.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_NGRATE, 1, 3);
            this.tableLayoutPanel16.Controls.Add(this.label24, 0, 3);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_TOTAL, 1, 2);
            this.tableLayoutPanel16.Controls.Add(this.label22, 0, 2);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_NG, 1, 1);
            this.tableLayoutPanel16.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_OK, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(100, 4);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 4;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(374, 117);
            this.tableLayoutPanel16.TabIndex = 6;
            // 
            // lb_CAM1_NGRATE
            // 
            this.lb_CAM1_NGRATE.AutoSize = true;
            this.lb_CAM1_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM1_NGRATE.Location = new System.Drawing.Point(116, 88);
            this.lb_CAM1_NGRATE.Name = "lb_CAM1_NGRATE";
            this.lb_CAM1_NGRATE.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM1_NGRATE.TabIndex = 7;
            this.lb_CAM1_NGRATE.Text = "0";
            this.lb_CAM1_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.Color.Yellow;
            this.label24.Location = new System.Drawing.Point(4, 88);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(105, 28);
            this.label24.TabIndex = 6;
            this.label24.Text = "NG RATE";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_TOTAL
            // 
            this.lb_CAM1_TOTAL.AutoSize = true;
            this.lb_CAM1_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM1_TOTAL.Location = new System.Drawing.Point(116, 59);
            this.lb_CAM1_TOTAL.Name = "lb_CAM1_TOTAL";
            this.lb_CAM1_TOTAL.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM1_TOTAL.TabIndex = 5;
            this.lb_CAM1_TOTAL.Text = "0";
            this.lb_CAM1_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(4, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 28);
            this.label22.TabIndex = 4;
            this.label22.Text = "TOTAL";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_NG
            // 
            this.lb_CAM1_NG.AutoSize = true;
            this.lb_CAM1_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM1_NG.Location = new System.Drawing.Point(116, 30);
            this.lb_CAM1_NG.Name = "lb_CAM1_NG";
            this.lb_CAM1_NG.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM1_NG.TabIndex = 3;
            this.lb_CAM1_NG.Text = "0";
            this.lb_CAM1_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(4, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 28);
            this.label20.TabIndex = 2;
            this.label20.Text = "NG";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_OK
            // 
            this.lb_CAM1_OK.AutoSize = true;
            this.lb_CAM1_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM1_OK.Location = new System.Drawing.Point(116, 1);
            this.lb_CAM1_OK.Name = "lb_CAM1_OK";
            this.lb_CAM1_OK.Size = new System.Drawing.Size(254, 28);
            this.lb_CAM1_OK.TabIndex = 1;
            this.lb_CAM1_OK.Text = "0";
            this.lb_CAM1_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.Lime;
            this.label17.Location = new System.Drawing.Point(4, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 28);
            this.label17.TabIndex = 0;
            this.label17.Text = "OK";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 123);
            this.label5.TabIndex = 0;
            this.label5.Text = "CAM1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 123);
            this.label6.TabIndex = 1;
            this.label6.Text = "CAM2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(4, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 123);
            this.label8.TabIndex = 2;
            this.label8.Text = "CAM3";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 373);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 123);
            this.label12.TabIndex = 3;
            this.label12.Text = "CAM4";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(4, 497);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 126);
            this.label14.TabIndex = 4;
            this.label14.Text = "CAM5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_IO
            // 
            this.btn_IO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_IO.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_IO.ForeColor = System.Drawing.Color.White;
            this.btn_IO.Location = new System.Drawing.Point(4, 4);
            this.btn_IO.Name = "btn_IO";
            this.btn_IO.Size = new System.Drawing.Size(90, 37);
            this.btn_IO.TabIndex = 30;
            this.btn_IO.Tag = "0";
            this.btn_IO.Text = "I/O";
            this.btn_IO.UseVisualStyleBackColor = false;
            this.btn_IO.Click += new System.EventHandler(this.btn_Log_Click);
            // 
            // btn_Count
            // 
            this.btn_Count.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Count.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Count.ForeColor = System.Drawing.Color.White;
            this.btn_Count.Location = new System.Drawing.Point(101, 4);
            this.btn_Count.Name = "btn_Count";
            this.btn_Count.Size = new System.Drawing.Size(90, 37);
            this.btn_Count.TabIndex = 32;
            this.btn_Count.Tag = "1";
            this.btn_Count.Text = "수량";
            this.btn_Count.UseVisualStyleBackColor = false;
            this.btn_Count.Click += new System.EventHandler(this.btn_Log_Click);
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel31.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel31.ColumnCount = 5;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.Controls.Add(this.num_LightNumber, 3, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_Light, 4, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_IO, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_Count, 1, 0);
            this.tableLayoutPanel31.Location = new System.Drawing.Point(1428, 79);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(489, 45);
            this.tableLayoutPanel31.TabIndex = 27;
            // 
            // num_LightNumber
            // 
            this.num_LightNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_LightNumber.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_LightNumber.Location = new System.Drawing.Point(295, 4);
            this.num_LightNumber.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.num_LightNumber.Name = "num_LightNumber";
            this.num_LightNumber.Size = new System.Drawing.Size(90, 36);
            this.num_LightNumber.TabIndex = 28;
            this.num_LightNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_LightNumber.ValueChanged += new System.EventHandler(this.num_LightNumber_ValueChanged);
            // 
            // btn_Light
            // 
            this.btn_Light.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Light.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Light.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Light.ForeColor = System.Drawing.Color.White;
            this.btn_Light.Location = new System.Drawing.Point(390, 2);
            this.btn_Light.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Light.Name = "btn_Light";
            this.btn_Light.Size = new System.Drawing.Size(97, 41);
            this.btn_Light.TabIndex = 33;
            this.btn_Light.Tag = "4";
            this.btn_Light.Text = "조명";
            this.btn_Light.UseVisualStyleBackColor = false;
            this.btn_Light.Click += new System.EventHandler(this.btn_Light_Click);
            // 
            // LightControl2
            // 
            this.LightControl2.PortName = "COM2";
            // 
            // LightControl3
            // 
            this.LightControl3.PortName = "COM8";
            // 
            // btn_ReconnectCam
            // 
            this.btn_ReconnectCam.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ReconnectCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ReconnectCam.ForeColor = System.Drawing.Color.White;
            this.btn_ReconnectCam.Location = new System.Drawing.Point(1428, 130);
            this.btn_ReconnectCam.Name = "btn_ReconnectCam";
            this.btn_ReconnectCam.Size = new System.Drawing.Size(137, 45);
            this.btn_ReconnectCam.TabIndex = 34;
            this.btn_ReconnectCam.Tag = "4";
            this.btn_ReconnectCam.Text = "카메라 재연결";
            this.btn_ReconnectCam.UseVisualStyleBackColor = false;
            this.btn_ReconnectCam.Click += new System.EventHandler(this.btn_ReconnectCam_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel9.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.Controls.Add(this.btn_PC2, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btn_PC1, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(1571, 130);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(345, 45);
            this.tableLayoutPanel9.TabIndex = 35;
            // 
            // btn_PC2
            // 
            this.btn_PC2.BackColor = System.Drawing.Color.Lime;
            this.btn_PC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PC2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PC2.ForeColor = System.Drawing.Color.Black;
            this.btn_PC2.Location = new System.Drawing.Point(230, 2);
            this.btn_PC2.Margin = new System.Windows.Forms.Padding(1);
            this.btn_PC2.Name = "btn_PC2";
            this.btn_PC2.Size = new System.Drawing.Size(113, 41);
            this.btn_PC2.TabIndex = 34;
            this.btn_PC2.Tag = "2";
            this.btn_PC2.Text = "PC 2";
            this.btn_PC2.UseVisualStyleBackColor = false;
            this.btn_PC2.Click += new System.EventHandler(this.btn_PC1_Click);
            // 
            // btn_PC1
            // 
            this.btn_PC1.BackColor = System.Drawing.Color.Lime;
            this.btn_PC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_PC1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_PC1.ForeColor = System.Drawing.Color.Black;
            this.btn_PC1.Location = new System.Drawing.Point(116, 2);
            this.btn_PC1.Margin = new System.Windows.Forms.Padding(1);
            this.btn_PC1.Name = "btn_PC1";
            this.btn_PC1.Size = new System.Drawing.Size(111, 41);
            this.btn_PC1.TabIndex = 33;
            this.btn_PC1.Tag = "1";
            this.btn_PC1.Text = "PC 1";
            this.btn_PC1.UseVisualStyleBackColor = false;
            this.btn_PC1.Click += new System.EventHandler(this.btn_PC1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Lime;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 39);
            this.label4.TabIndex = 32;
            this.label4.Text = "PC선택";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bk_Signal
            // 
            this.bk_Signal.WorkerSupportsCancellation = true;
            this.bk_Signal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_Signal_DoWork);
            // 
            // timer_sandPLC
            // 
            this.timer_sandPLC.Interval = 5000;
            this.timer_sandPLC.Tick += new System.EventHandler(this.timer_sandPLC_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1529, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1448, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.btn_ReconnectCam);
            this.Controls.Add(this.tableLayoutPanel31);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tlpTopSide);
            this.Controls.Add(this.tlpUnder);
            this.Controls.Add(this.Main_TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISION PROGRAM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frm_Main_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Main_KeyDown);
            this.tlpUnder.ResumeLayout(false);
            this.tlpTopSide.ResumeLayout(false);
            this.tlpTopSide.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay5)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay3)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay2)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay4)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.Main_TabControl.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_LightNumber)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpUnder;
        private System.Windows.Forms.Button btn_ToolSetUp;
        private System.Windows.Forms.Button btn_SystemSetup;
        private System.Windows.Forms.TableLayoutPanel tlpTopSide;
        private System.Windows.Forms.Label lb_Ver;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.Timer timer_Setting;
        private System.Windows.Forms.Button btn_Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.Label lb_CurruntModelName;
        public System.IO.Ports.SerialPort LightControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_CamSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label lb_Cam5_Result;
        private System.Windows.Forms.Label lb_Cam5Stats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label lb_Cam3_Result;
        private System.Windows.Forms.Label lb_Cam3Stats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lb_Cam2_Result;
        private System.Windows.Forms.Label lb_Cam2Stats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label lb_Cam4_Result;
        private System.Windows.Forms.Label lb_Cam4Stats;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl Main_TabControl;
        private System.Windows.Forms.Label lb_Cam5_InsTime;
        private System.Windows.Forms.Label lb_Cam3_InsTime;
        private System.Windows.Forms.Label lb_Cam2_InsTime;
        private System.Windows.Forms.Label lb_Cam4_InsTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label lb_Cam1Stats;
        private System.Windows.Forms.Label lb_Cam1_Result;
        private System.Windows.Forms.Label lb_Cam1_InsTime;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.Label lb_CAM5_NGRATE;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lb_CAM5_TOTAL;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lb_CAM5_NG;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label lb_CAM5_OK;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.Label lb_CAM4_NGRATE;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lb_CAM4_TOTAL;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lb_CAM4_NG;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lb_CAM4_OK;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Label lb_CAM3_NGRATE;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lb_CAM3_TOTAL;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lb_CAM3_NG;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lb_CAM3_OK;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Label lb_CAM2_NGRATE;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lb_CAM2_TOTAL;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lb_CAM2_NG;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lb_CAM2_OK;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label lb_CAM1_NGRATE;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lb_CAM1_TOTAL;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lb_CAM1_NG;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lb_CAM1_OK;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_IO;
        private System.Windows.Forms.Button btn_Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        public System.Windows.Forms.Button btn_Output17;
        public System.Windows.Forms.Button btn_Output7;
        public System.Windows.Forms.Button btn_Output16;
        public System.Windows.Forms.Button btn_Output15;
        public System.Windows.Forms.Button btn_Output6;
        public System.Windows.Forms.Button btn_Output14;
        public System.Windows.Forms.Button btn_Output13;
        public System.Windows.Forms.Button btn_Output5;
        public System.Windows.Forms.Button btn_Output12;
        public System.Windows.Forms.Button btn_Output4;
        public System.Windows.Forms.Button btn_Output0;
        public System.Windows.Forms.Button btn_Output3;
        public System.Windows.Forms.Button btn_Output2;
        public System.Windows.Forms.Button btn_Output11;
        public System.Windows.Forms.Button btn_Output10;
        public System.Windows.Forms.Button btn_Output9;
        public System.Windows.Forms.Button btn_Output8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textBoxIP2;
        private System.Windows.Forms.Label lbConnTitle;
        private System.Windows.Forms.TextBox textBoxIP3;
        private System.Windows.Forms.TextBox textBoxIP1;
        private System.Windows.Forms.TextBox textBoxIP0;
        private System.Windows.Forms.Label lb_Mode;
        private System.Windows.Forms.Label lb_PLCStats;
        private System.Windows.Forms.Button btn_Light;
        public System.IO.Ports.SerialPort LightControl2;
        public System.IO.Ports.SerialPort LightControl3;
        private System.Windows.Forms.NumericUpDown num_LightNumber;
        private System.Windows.Forms.Button btn_ReconnectCam;
        private KimLib.LogControl logControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btn_PC2;
        private System.Windows.Forms.Button btn_PC1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btn_Output1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button btn_INPUT17;
        public System.Windows.Forms.Button btn_INPUT16;
        public System.Windows.Forms.Button btn_INPUT15;
        public System.Windows.Forms.Button btn_INPUT14;
        public System.Windows.Forms.Button btn_INPUT13;
        public System.Windows.Forms.Button btn_INPUT12;
        public System.Windows.Forms.Button btn_INPUT11;
        public System.Windows.Forms.Button btn_INPUT10;
        public System.Windows.Forms.Button btn_INPUT9;
        public System.Windows.Forms.Button btn_INPUT8;
        public System.Windows.Forms.Button btn_INPUT0;
        public System.Windows.Forms.Button btn_INPUT1;
        public System.Windows.Forms.Button btn_INPUT2;
        public System.Windows.Forms.Button btn_INPUT3;
        public System.Windows.Forms.Button btn_INPUT4;
        public System.Windows.Forms.Button btn_INPUT5;
        public System.Windows.Forms.Button btn_INPUT6;
        public System.Windows.Forms.Button btn_INPUT7;
        private System.Windows.Forms.Timer timer_sandPLC;
        public System.ComponentModel.BackgroundWorker bk_Signal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

