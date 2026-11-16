namespace MSO_Practicum
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonMETRICS = new System.Windows.Forms.Button();
            this.buttonRUN = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.resultstatus = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.loadProgramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadProgramToolStripMenuItem
            // 
            this.loadProgramToolStripMenuItem.AccessibleName = "Load program";
            this.loadProgramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                        this.basicToolStripMenuItem,
                        this.advancedToolStripMenuItem,
                        this.expertToolStripMenuItem,
                        this.fromFileToolStripMenuItem});
            this.loadProgramToolStripMenuItem.Name = "loadProgramToolStripMenuItem";
            this.loadProgramToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.loadProgramToolStripMenuItem.Text = "Load program";
            this.loadProgramToolStripMenuItem.Click += new System.EventHandler(this.LoadProgramToolStripMenuItem_Click);
            // 
            // basicToolStripMenuItem
            // 
            this.basicToolStripMenuItem.Name = "basicToolStripMenuItem";
            this.basicToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.basicToolStripMenuItem.Text = "Basic";
            this.basicToolStripMenuItem.Click += new System.EventHandler(this.BasicToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.advancedToolStripMenuItem.Text = "Advanced";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.AdvancedToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.expertToolStripMenuItem.Text = "Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.ExpertToolStripMenuItem_Click);
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.fromFileToolStripMenuItem.Text = "From file";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel1.Controls.Add(this.buttonMETRICS);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRUN);
            this.splitContainer1.Panel1.Controls.Add(this.OutputBox);
            this.splitContainer1.Panel1.Controls.Add(this.InputBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 403;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonMETRICS
            // 
            this.buttonMETRICS.BackColor = System.Drawing.Color.LightCoral;
            this.buttonMETRICS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMETRICS.Location = new System.Drawing.Point(236, 257);
            this.buttonMETRICS.Name = "buttonMETRICS";
            this.buttonMETRICS.Size = new System.Drawing.Size(164, 102);
            this.buttonMETRICS.TabIndex = 3;
            this.buttonMETRICS.Text = "Metrics";
            this.buttonMETRICS.UseVisualStyleBackColor = false;
            this.buttonMETRICS.Click += new System.EventHandler(this.ButtonMETRICS_Click);
            // 
            // buttonRUN
            // 
            this.buttonRUN.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonRUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRUN.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonRUN.Location = new System.Drawing.Point(3, 257);
            this.buttonRUN.Name = "buttonRUN";
            this.buttonRUN.Size = new System.Drawing.Size(164, 102);
            this.buttonRUN.TabIndex = 2;
            this.buttonRUN.Text = "Run";
            this.buttonRUN.UseVisualStyleBackColor = false;
            this.buttonRUN.Click += new System.EventHandler(this.ButtonRUN_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(0, 372);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputBox.Size = new System.Drawing.Size(400, 75);
            this.OutputBox.TabIndex = 1;
            // 
            // InputBox
            // 
            this.InputBox.AcceptsTab = true;
            this.InputBox.BackColor = System.Drawing.Color.DimGray;
            this.InputBox.ForeColor = System.Drawing.SystemColors.Window;
            this.InputBox.Location = new System.Drawing.Point(3, 31);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputBox.Size = new System.Drawing.Size(403, 220);
            this.InputBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.resultstatus, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.769231F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.23077F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 416);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridPanel
            // 
            this.gridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(3, 27);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(384, 386);
            this.gridPanel.TabIndex = 1;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GridPanel_Paint_1);
            // 
            // resultstatus
            // 
            this.resultstatus.AutoSize = true;
            this.resultstatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultstatus.Location = new System.Drawing.Point(3, 0);
            this.resultstatus.Name = "resultstatus";
            this.resultstatus.Size = new System.Drawing.Size(384, 16);
            this.resultstatus.TabIndex = 2;
            this.resultstatus.Text = "label1";
            this.resultstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonMETRICS;
        private System.Windows.Forms.Button buttonRUN;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Label resultstatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}