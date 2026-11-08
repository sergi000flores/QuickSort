#nullable disable
namespace QuickSortWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.flowTipos = new System.Windows.Forms.FlowLayoutPanel();
            this.rbInt = new System.Windows.Forms.RadioButton();
            this.rbDouble = new System.Windows.Forms.RadioButton();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbChar = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblManual = new System.Windows.Forms.Label();
            this.txtManual = new System.Windows.Forms.TextBox();
            this.btnManual = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblPivote = new System.Windows.Forms.Label();
            this.flowPivote = new System.Windows.Forms.FlowLayoutPanel();
            this.rbPivFirst = new System.Windows.Forms.RadioButton();
            this.rbPivLast = new System.Windows.Forms.RadioButton();
            this.rbPivRandom = new System.Windows.Forms.RadioButton();
            this.rbPivMedian = new System.Windows.Forms.RadioButton();
            this.lblCompare = new System.Windows.Forms.Label();
            this.lvCompare = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colParts = new System.Windows.Forms.ColumnHeader();
            this.colComps = new System.Windows.Forms.ColumnHeader();
            this.colSwaps = new System.Windows.Forms.ColumnHeader();
            this.lblBest = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabStep = new System.Windows.Forms.TabPage();
            this.arrayPanel = new QuickSortWinForms.ArrayPanel();
            this.legend = new QuickSortWinForms.LegendPanel();
            this.lblStepTitle = new System.Windows.Forms.Label();
            this.lstSteps = new System.Windows.Forms.ListBox();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblHeadline = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            this.btnResult = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.tabFinal = new System.Windows.Forms.TabPage();
            this.tlpFinal = new System.Windows.Forms.TableLayoutPanel();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblOriginal = new System.Windows.Forms.Label();
            this.finalOriginal = new QuickSortWinForms.ArrayPanel();
            this.lblSorted = new System.Windows.Forms.Label();
            this.finalSorted = new QuickSortWinForms.ArrayPanel();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.flowTipos.SuspendLayout();
            this.flowPivote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabStep.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).BeginInit();
            this.tabFinal.SuspendLayout();
            this.tlpFinal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(232, 228, 218);
            this.pnlTop.Controls.Add(this.lblTipo);
            this.pnlTop.Controls.Add(this.flowTipos);
            this.pnlTop.Controls.Add(this.lblCantidad);
            this.pnlTop.Controls.Add(this.nudCount);
            this.pnlTop.Controls.Add(this.btnGenerate);
            this.pnlTop.Controls.Add(this.lblManual);
            this.pnlTop.Controls.Add(this.txtManual);
            this.pnlTop.Controls.Add(this.btnManual);
            this.pnlTop.Controls.Add(this.lblPivote);
            this.pnlTop.Controls.Add(this.flowPivote);
            this.pnlTop.Controls.Add(this.lblHint);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 178);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipo.Location = new System.Drawing.Point(12, 16);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo de dato:";
            // 
            // flowTipos
            // 
            this.flowTipos.Controls.Add(this.rbInt);
            this.flowTipos.Controls.Add(this.rbDouble);
            this.flowTipos.Controls.Add(this.rbString);
            this.flowTipos.Controls.Add(this.rbChar);
            this.flowTipos.Controls.Add(this.rbDate);
            this.flowTipos.Location = new System.Drawing.Point(120, 8);
            this.flowTipos.Name = "flowTipos";
            this.flowTipos.Size = new System.Drawing.Size(900, 42);
            this.flowTipos.WrapContents = false;
            // 
            // rbInt
            // 
            this.rbInt.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbInt.Checked = true;
            this.rbInt.Name = "rbInt";
            this.rbInt.Size = new System.Drawing.Size(165, 34);
            this.rbInt.TabStop = true;
            this.rbInt.Text = "Enteros (int)";
            this.rbInt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbInt.CheckedChanged += new System.EventHandler(this.TypeRadio_CheckedChanged);
            // 
            // rbDouble
            // 
            this.rbDouble.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDouble.Name = "rbDouble";
            this.rbDouble.Size = new System.Drawing.Size(165, 34);
            this.rbDouble.Text = "Decimales (double)";
            this.rbDouble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDouble.CheckedChanged += new System.EventHandler(this.TypeRadio_CheckedChanged);
            // 
            // rbString
            // 
            this.rbString.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(165, 34);
            this.rbString.Text = "Texto (string)";
            this.rbString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbString.CheckedChanged += new System.EventHandler(this.TypeRadio_CheckedChanged);
            // 
            // rbChar
            // 
            this.rbChar.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbChar.Name = "rbChar";
            this.rbChar.Size = new System.Drawing.Size(165, 34);
            this.rbChar.Text = "Caracteres (char)";
            this.rbChar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbChar.CheckedChanged += new System.EventHandler(this.TypeRadio_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(165, 34);
            this.rbDate.Text = "Fechas (DateTime)";
            this.rbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDate.CheckedChanged += new System.EventHandler(this.TypeRadio_CheckedChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(12, 66);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(120, 62);
            this.nudCount.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.nudCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(70, 29);
            this.nudCount.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(206, 58);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(220, 36);
            this.btnGenerate.Text = "Generar lista aleatoria";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblManual
            // 
            this.lblManual.AutoSize = true;
            this.lblManual.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblManual.Location = new System.Drawing.Point(448, 66);
            this.lblManual.Name = "lblManual";
            this.lblManual.Text = "Mis datos:";
            // 
            // txtManual
            // 
            this.txtManual.Location = new System.Drawing.Point(534, 62);
            this.txtManual.Name = "txtManual";
            this.txtManual.Size = new System.Drawing.Size(360, 29);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(906, 58);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(160, 36);
            this.btnManual.Text = "Usar mis datos";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(91, 100, 112);
            this.lblHint.Location = new System.Drawing.Point(12, 148);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "";
            // 
            // lblPivote
            // 
            this.lblPivote.AutoSize = true;
            this.lblPivote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPivote.Location = new System.Drawing.Point(12, 112);
            this.lblPivote.Name = "lblPivote";
            this.lblPivote.Text = "Pivote:";
            // 
            // flowPivote
            // 
            this.flowPivote.Controls.Add(this.rbPivFirst);
            this.flowPivote.Controls.Add(this.rbPivLast);
            this.flowPivote.Controls.Add(this.rbPivRandom);
            this.flowPivote.Controls.Add(this.rbPivMedian);
            this.flowPivote.Location = new System.Drawing.Point(120, 104);
            this.flowPivote.Name = "flowPivote";
            this.flowPivote.Size = new System.Drawing.Size(900, 42);
            this.flowPivote.WrapContents = false;
            // 
            // rbPivFirst
            // 
            this.rbPivFirst.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPivFirst.Name = "rbPivFirst";
            this.rbPivFirst.Size = new System.Drawing.Size(200, 34);
            this.rbPivFirst.Text = "Primer elemento";
            this.rbPivFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPivFirst.CheckedChanged += new System.EventHandler(this.PivotRadio_CheckedChanged);
            // 
            // rbPivLast
            // 
            this.rbPivLast.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPivLast.Checked = true;
            this.rbPivLast.TabStop = true;
            this.rbPivLast.Name = "rbPivLast";
            this.rbPivLast.Size = new System.Drawing.Size(200, 34);
            this.rbPivLast.Text = "Último elemento";
            this.rbPivLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPivLast.CheckedChanged += new System.EventHandler(this.PivotRadio_CheckedChanged);
            // 
            // rbPivRandom
            // 
            this.rbPivRandom.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPivRandom.Name = "rbPivRandom";
            this.rbPivRandom.Size = new System.Drawing.Size(200, 34);
            this.rbPivRandom.Text = "Selección aleatoria";
            this.rbPivRandom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPivRandom.CheckedChanged += new System.EventHandler(this.PivotRadio_CheckedChanged);
            // 
            // rbPivMedian
            // 
            this.rbPivMedian.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbPivMedian.Name = "rbPivMedian";
            this.rbPivMedian.Size = new System.Drawing.Size(200, 34);
            this.rbPivMedian.Text = "Mediana de tres";
            this.rbPivMedian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbPivMedian.CheckedChanged += new System.EventHandler(this.PivotRadio_CheckedChanged);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabStep);
            this.tabMain.Controls.Add(this.tabFinal);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabMain.Location = new System.Drawing.Point(0, 178);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 542);
            this.tabMain.TabIndex = 0;
            // 
            // tabStep
            // 
            this.tabStep.Controls.Add(this.arrayPanel);
            this.tabStep.Controls.Add(this.legend);
            this.tabStep.Controls.Add(this.lblStepTitle);
            this.tabStep.Controls.Add(this.lstSteps);
            this.tabStep.Controls.Add(this.pnlMessage);
            this.tabStep.Controls.Add(this.pnlControls);
            this.tabStep.Name = "tabStep";
            this.tabStep.Text = "Paso a paso";
            this.tabStep.UseVisualStyleBackColor = true;
            // 
            // arrayPanel
            // 
            this.arrayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrayPanel.Name = "arrayPanel";
            // 
            // legend
            // 
            this.legend.Dock = System.Windows.Forms.DockStyle.Top;
            this.legend.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(700, 34);
            // 
            // lblStepTitle
            // 
            this.lblStepTitle.BackColor = System.Drawing.Color.FromArgb(246, 244, 239);
            this.lblStepTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStepTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblStepTitle.Size = new System.Drawing.Size(700, 48);
            this.lblStepTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstSteps
            // 
            this.lstSteps.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstSteps.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstSteps.FormattingEnabled = true;
            this.lstSteps.IntegralHeight = false;
            this.lstSteps.Name = "lstSteps";
            this.lstSteps.Size = new System.Drawing.Size(300, 300);
            this.lstSteps.SelectedIndexChanged += new System.EventHandler(this.lstSteps_SelectedIndexChanged);
            // 
            // pnlMessage
            // 
            this.pnlMessage.BackColor = System.Drawing.Color.FromArgb(255, 253, 248);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.lblHeadline);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlMessage.Size = new System.Drawing.Size(1000, 140);
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblMessage.Name = "lblMessage";
            // 
            // lblHeadline
            // 
            this.lblHeadline.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeadline.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHeadline.ForeColor = System.Drawing.Color.FromArgb(217, 102, 31);
            this.lblHeadline.Name = "lblHeadline";
            this.lblHeadline.Size = new System.Drawing.Size(970, 44);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnFirst);
            this.pnlControls.Controls.Add(this.btnPrev);
            this.pnlControls.Controls.Add(this.btnPlay);
            this.pnlControls.Controls.Add(this.btnNext);
            this.pnlControls.Controls.Add(this.btnLast);
            this.pnlControls.Controls.Add(this.lblSpeed);
            this.pnlControls.Controls.Add(this.trackSpeed);
            this.pnlControls.Controls.Add(this.btnResult);
            this.pnlControls.Controls.Add(this.lblCounter);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1000, 100);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(12, 10);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(90, 42);
            this.btnFirst.Text = "Inicio";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(108, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(110, 42);
            this.btnPrev.Text = "< Anterior";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(224, 10);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(130, 42);
            this.btnPlay.Text = "Reproducir";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(360, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 42);
            this.btnNext.Text = "Siguiente >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(476, 10);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(90, 42);
            this.btnLast.Text = "Final";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(590, 20);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Text = "Velocidad:";
            // 
            // trackSpeed
            // 
            this.trackSpeed.Location = new System.Drawing.Point(678, 10);
            this.trackSpeed.Maximum = 10;
            this.trackSpeed.Minimum = 1;
            this.trackSpeed.Name = "trackSpeed";
            this.trackSpeed.Size = new System.Drawing.Size(150, 45);
            this.trackSpeed.Value = 5;
            this.trackSpeed.Scroll += new System.EventHandler(this.trackSpeed_Scroll);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(850, 10);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(180, 42);
            this.btnResult.Text = "Ver resultado final";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(14, 66);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Text = "";
            // 
            // tabFinal
            // 
            this.tabFinal.AutoScroll = true;
            this.tabFinal.Controls.Add(this.tlpFinal);
            this.tabFinal.Name = "tabFinal";
            this.tabFinal.Text = "Resultado final";
            this.tabFinal.UseVisualStyleBackColor = true;
            // 
            // tlpFinal
            // 
            this.tlpFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpFinal.ColumnCount = 1;
            this.tlpFinal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinal.Controls.Add(this.lblStats, 0, 0);
            this.tlpFinal.Controls.Add(this.lblOriginal, 0, 1);
            this.tlpFinal.Controls.Add(this.finalOriginal, 0, 2);
            this.tlpFinal.Controls.Add(this.lblSorted, 0, 3);
            this.tlpFinal.Controls.Add(this.finalSorted, 0, 4);
            this.tlpFinal.Controls.Add(this.lblCompare, 0, 5);
            this.tlpFinal.Controls.Add(this.lvCompare, 0, 6);
            this.tlpFinal.Controls.Add(this.lblBest, 0, 7);
            this.tlpFinal.Location = new System.Drawing.Point(0, 0);
            this.tlpFinal.Name = "tlpFinal";
            this.tlpFinal.RowCount = 8;
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpFinal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFinal.Size = new System.Drawing.Size(1060, 828);
            // 
            // lblStats
            // 
            this.lblStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStats.Name = "lblStats";
            this.lblStats.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            // 
            // lblOriginal
            // 
            this.lblOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOriginal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblOriginal.Text = "Lista original (desordenada)";
            // 
            // finalOriginal
            // 
            this.finalOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalOriginal.Name = "finalOriginal";
            // 
            // lblSorted
            // 
            this.lblSorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSorted.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSorted.Name = "lblSorted";
            this.lblSorted.Padding = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.lblSorted.Text = "Lista ordenada con Quicksort";
            // 
            // finalSorted
            // 
            this.finalSorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalSorted.Name = "finalSorted";
            // 
            // lblCompare
            // 
            this.lblCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompare.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Padding = new System.Windows.Forms.Padding(10, 12, 0, 0);
            this.lblCompare.Text = "Comparación de pivotes con esta misma lista (gana el que hace menos comparaciones)";
            // 
            // lvCompare
            // 
            this.lvCompare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colName, this.colParts, this.colComps, this.colSwaps });
            this.lvCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCompare.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lvCompare.FullRowSelect = true;
            this.lvCompare.GridLines = true;
            this.lvCompare.HideSelection = false;
            this.lvCompare.Name = "lvCompare";
            this.lvCompare.UseCompatibleStateImageBehavior = false;
            this.lvCompare.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Estrategia de pivote";
            this.colName.Width = 430;
            // 
            // colParts
            // 
            this.colParts.Text = "Particiones";
            this.colParts.Width = 130;
            // 
            // colComps
            // 
            this.colComps.Text = "Comparaciones";
            this.colComps.Width = 150;
            // 
            // colSwaps
            // 
            this.colSwaps.Text = "Intercambios";
            this.colSwaps.Width = 150;
            // 
            // lblBest
            // 
            this.lblBest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBest.ForeColor = System.Drawing.Color.FromArgb(63, 125, 88);
            this.lblBest.Name = "lblBest";
            this.lblBest.Padding = new System.Windows.Forms.Padding(10, 8, 0, 0);
            // 
            // timerPlay
            // 
            this.timerPlay.Interval = 850;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1060, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quicksort genérico QuickSort<T> - paso a paso";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.flowTipos.ResumeLayout(false);
            this.flowPivote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabStep.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).EndInit();
            this.tabFinal.ResumeLayout(false);
            this.tlpFinal.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.FlowLayoutPanel flowTipos;
        private System.Windows.Forms.RadioButton rbInt;
        private System.Windows.Forms.RadioButton rbDouble;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.RadioButton rbChar;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.TextBox txtManual;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabStep;
        private QuickSortWinForms.ArrayPanel arrayPanel;
        private QuickSortWinForms.LegendPanel legend;
        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.ListBox lstSteps;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblHeadline;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TrackBar trackSpeed;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.TabPage tabFinal;
        private System.Windows.Forms.TableLayoutPanel tlpFinal;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblOriginal;
        private QuickSortWinForms.ArrayPanel finalOriginal;
        private System.Windows.Forms.Label lblSorted;
        private QuickSortWinForms.ArrayPanel finalSorted;
        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Label lblPivote;
        private System.Windows.Forms.FlowLayoutPanel flowPivote;
        private System.Windows.Forms.RadioButton rbPivFirst;
        private System.Windows.Forms.RadioButton rbPivLast;
        private System.Windows.Forms.RadioButton rbPivRandom;
        private System.Windows.Forms.RadioButton rbPivMedian;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.ListView lvCompare;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colParts;
        private System.Windows.Forms.ColumnHeader colComps;
        private System.Windows.Forms.ColumnHeader colSwaps;
        private System.Windows.Forms.Label lblBest;
    }
}
