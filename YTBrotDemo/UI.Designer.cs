namespace YTBrotDemo
{
    partial class UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ControlsLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            MaxIterationsControl = new NumericUpDown();
            ViewOffsetAControl = new NumericUpDown();
            ViewOffsetBControl = new NumericUpDown();
            PaletteScaleControl = new NumericUpDown();
            ThreadsControl = new NumericUpDown();
            RenderButton = new Button();
            AbortButton = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            ZoomControl = new NumericUpDown();
            label7 = new Label();
            PreviewPanel = new Panel();
            PreviewControl = new PictureBox();
            ControlsLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MaxIterationsControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewOffsetAControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewOffsetBControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaletteScaleControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThreadsControl).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ZoomControl).BeginInit();
            PreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PreviewControl).BeginInit();
            SuspendLayout();
            // 
            // ControlsLayoutPanel
            // 
            ControlsLayoutPanel.ColumnCount = 3;
            ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            ControlsLayoutPanel.Controls.Add(label1, 1, 0);
            ControlsLayoutPanel.Controls.Add(label2, 1, 1);
            ControlsLayoutPanel.Controls.Add(label3, 1, 2);
            ControlsLayoutPanel.Controls.Add(label4, 1, 3);
            ControlsLayoutPanel.Controls.Add(label5, 1, 4);
            ControlsLayoutPanel.Controls.Add(label6, 1, 5);
            ControlsLayoutPanel.Controls.Add(MaxIterationsControl, 2, 0);
            ControlsLayoutPanel.Controls.Add(ViewOffsetAControl, 2, 1);
            ControlsLayoutPanel.Controls.Add(ViewOffsetBControl, 2, 2);
            ControlsLayoutPanel.Controls.Add(PaletteScaleControl, 2, 3);
            ControlsLayoutPanel.Controls.Add(ThreadsControl, 2, 5);
            ControlsLayoutPanel.Controls.Add(RenderButton, 2, 7);
            ControlsLayoutPanel.Controls.Add(AbortButton, 1, 7);
            ControlsLayoutPanel.Controls.Add(tableLayoutPanel2, 2, 4);
            ControlsLayoutPanel.Controls.Add(PreviewPanel, 0, 0);
            ControlsLayoutPanel.Dock = DockStyle.Fill;
            ControlsLayoutPanel.Location = new Point(0, 0);
            ControlsLayoutPanel.Margin = new Padding(5);
            ControlsLayoutPanel.Name = "ControlsLayoutPanel";
            ControlsLayoutPanel.RowCount = 8;
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle());
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ControlsLayoutPanel.Size = new Size(1858, 1136);
            ControlsLayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(1397, 0);
            label1.Name = "label1";
            label1.Size = new Size(172, 45);
            label1.TabIndex = 0;
            label1.Text = "Max Iterations";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(1407, 45);
            label2.Name = "label2";
            label2.Size = new Size(162, 45);
            label2.TabIndex = 0;
            label2.Text = "View Offset A";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Right;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(1408, 90);
            label3.Name = "label3";
            label3.Size = new Size(161, 45);
            label3.TabIndex = 0;
            label3.Text = "View Offset B";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Right;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(1416, 135);
            label4.Name = "label4";
            label4.Size = new Size(153, 45);
            label4.TabIndex = 0;
            label4.Text = "Palette Scale";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Right;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(1405, 180);
            label5.Name = "label5";
            label5.Size = new Size(164, 45);
            label5.TabIndex = 0;
            label5.Text = "Magnification";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Right;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1469, 225);
            label6.Name = "label6";
            label6.Size = new Size(100, 45);
            label6.TabIndex = 0;
            label6.Text = "Threads";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MaxIterationsControl
            // 
            MaxIterationsControl.AutoSize = true;
            MaxIterationsControl.Dock = DockStyle.Right;
            MaxIterationsControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            MaxIterationsControl.Location = new Point(1733, 3);
            MaxIterationsControl.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            MaxIterationsControl.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            MaxIterationsControl.Name = "MaxIterationsControl";
            MaxIterationsControl.Size = new Size(122, 39);
            MaxIterationsControl.TabIndex = 1;
            MaxIterationsControl.TextAlign = HorizontalAlignment.Right;
            MaxIterationsControl.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // ViewOffsetAControl
            // 
            ViewOffsetAControl.AutoSize = true;
            ViewOffsetAControl.DecimalPlaces = 16;
            ViewOffsetAControl.Dock = DockStyle.Right;
            ViewOffsetAControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ViewOffsetAControl.Location = new Point(1575, 48);
            ViewOffsetAControl.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ViewOffsetAControl.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            ViewOffsetAControl.Name = "ViewOffsetAControl";
            ViewOffsetAControl.Size = new Size(280, 39);
            ViewOffsetAControl.TabIndex = 1;
            ViewOffsetAControl.TextAlign = HorizontalAlignment.Right;
            ViewOffsetAControl.Value = new decimal(new int[] { 5, 0, 0, -2147418112 });
            // 
            // ViewOffsetBControl
            // 
            ViewOffsetBControl.AutoSize = true;
            ViewOffsetBControl.DecimalPlaces = 16;
            ViewOffsetBControl.Dock = DockStyle.Right;
            ViewOffsetBControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ViewOffsetBControl.Location = new Point(1575, 93);
            ViewOffsetBControl.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ViewOffsetBControl.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            ViewOffsetBControl.Name = "ViewOffsetBControl";
            ViewOffsetBControl.Size = new Size(280, 39);
            ViewOffsetBControl.TabIndex = 1;
            ViewOffsetBControl.TextAlign = HorizontalAlignment.Right;
            // 
            // PaletteScaleControl
            // 
            PaletteScaleControl.AutoSize = true;
            PaletteScaleControl.DecimalPlaces = 2;
            PaletteScaleControl.Dock = DockStyle.Right;
            PaletteScaleControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            PaletteScaleControl.Location = new Point(1701, 138);
            PaletteScaleControl.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            PaletteScaleControl.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PaletteScaleControl.Name = "PaletteScaleControl";
            PaletteScaleControl.Size = new Size(154, 39);
            PaletteScaleControl.TabIndex = 1;
            PaletteScaleControl.TextAlign = HorizontalAlignment.Right;
            PaletteScaleControl.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // ThreadsControl
            // 
            ThreadsControl.AutoSize = true;
            ThreadsControl.Dock = DockStyle.Right;
            ThreadsControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadsControl.Location = new Point(1775, 228);
            ThreadsControl.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadsControl.Name = "ThreadsControl";
            ThreadsControl.Size = new Size(80, 39);
            ThreadsControl.TabIndex = 1;
            ThreadsControl.TextAlign = HorizontalAlignment.Right;
            ThreadsControl.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // RenderButton
            // 
            RenderButton.BackColor = Color.FromArgb(64, 64, 64);
            RenderButton.Dock = DockStyle.Bottom;
            RenderButton.FlatStyle = FlatStyle.Flat;
            RenderButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            RenderButton.Location = new Point(1575, 1033);
            RenderButton.Name = "RenderButton";
            RenderButton.Size = new Size(280, 100);
            RenderButton.TabIndex = 3;
            RenderButton.Text = "Render";
            RenderButton.UseVisualStyleBackColor = false;
            RenderButton.Click += RenderButton_Click;
            // 
            // AbortButton
            // 
            AbortButton.BackColor = Color.FromArgb(64, 64, 64);
            AbortButton.Dock = DockStyle.Bottom;
            AbortButton.FlatStyle = FlatStyle.Flat;
            AbortButton.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            AbortButton.Location = new Point(1397, 1033);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(172, 100);
            AbortButton.TabIndex = 3;
            AbortButton.Text = "Abort";
            AbortButton.UseVisualStyleBackColor = false;
            AbortButton.Click += AbortButton_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(ZoomControl, 1, 0);
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(1572, 180);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(286, 45);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // ZoomControl
            // 
            ZoomControl.AutoSize = true;
            ZoomControl.DecimalPlaces = 2;
            ZoomControl.Dock = DockStyle.Right;
            ZoomControl.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ZoomControl.Location = new Point(185, 3);
            ZoomControl.Maximum = new decimal(new int[] { 87, 0, 0, 0 });
            ZoomControl.Minimum = new decimal(new int[] { 87, 0, 0, int.MinValue });
            ZoomControl.Name = "ZoomControl";
            ZoomControl.Size = new Size(98, 39);
            ZoomControl.TabIndex = 1;
            ZoomControl.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Right;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(135, 0);
            label7.Name = "label7";
            label7.Size = new Size(44, 45);
            label7.TabIndex = 0;
            label7.Text = "2^";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // PreviewPanel
            // 
            PreviewPanel.Controls.Add(PreviewControl);
            PreviewPanel.Dock = DockStyle.Fill;
            PreviewPanel.Location = new Point(0, 0);
            PreviewPanel.Margin = new Padding(0);
            PreviewPanel.Name = "PreviewPanel";
            ControlsLayoutPanel.SetRowSpan(PreviewPanel, 8);
            PreviewPanel.Size = new Size(1394, 1136);
            PreviewPanel.TabIndex = 5;
            // 
            // PreviewControl
            // 
            PreviewControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PreviewControl.BackColor = Color.Black;
            PreviewControl.BackgroundImageLayout = ImageLayout.Zoom;
            PreviewControl.Cursor = Cursors.Cross;
            PreviewControl.Location = new Point(0, 0);
            PreviewControl.Margin = new Padding(0);
            PreviewControl.Name = "PreviewControl";
            PreviewControl.Size = new Size(1394, 1136);
            PreviewControl.TabIndex = 2;
            PreviewControl.TabStop = false;
            PreviewControl.SizeChanged += PreviewControl_SizeChanged;
            PreviewControl.MouseClick += PreviewControl_MouseClick;
            PreviewControl.MouseLeave += PreviewControl_MouseLeave;
            PreviewControl.MouseMove += PreviewControl_MouseMove;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(1858, 1136);
            Controls.Add(ControlsLayoutPanel);
            ForeColor = Color.White;
            KeyPreview = true;
            Name = "UI";
            Text = "YouTube Mandelbrot Demo";
            Shown += UI_Shown;
            KeyDown += UI_KeyDown;
            ControlsLayoutPanel.ResumeLayout(false);
            ControlsLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MaxIterationsControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewOffsetAControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewOffsetBControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaletteScaleControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThreadsControl).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ZoomControl).EndInit();
            PreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PreviewControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel ControlsLayoutPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private NumericUpDown MaxIterationsControl;
        private NumericUpDown ViewOffsetAControl;
        private NumericUpDown ViewOffsetBControl;
        private NumericUpDown PaletteScaleControl;
        private NumericUpDown ZoomControl;
        private NumericUpDown ThreadsControl;
        private PictureBox PreviewControl;
        private Button RenderButton;
        private Button AbortButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label7;
        private Panel PreviewPanel;
    }
}