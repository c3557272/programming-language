
namespace AssignmentGPE
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.commandLine = new System.Windows.Forms.TextBox();
            this.graphicsArea = new System.Windows.Forms.PictureBox();
            this.programArea = new System.Windows.Forms.RichTextBox();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consoleClear = new System.Windows.Forms.Button();
            this.colourPicker = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphicsArea)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandLine
            // 
            this.commandLine.Location = new System.Drawing.Point(12, 411);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(363, 20);
            this.commandLine.TabIndex = 0;
            this.commandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLine_KeyDown);
            // 
            // graphicsArea
            // 
            this.graphicsArea.BackColor = System.Drawing.SystemColors.Window;
            this.graphicsArea.Location = new System.Drawing.Point(391, 31);
            this.graphicsArea.Name = "graphicsArea";
            this.graphicsArea.Size = new System.Drawing.Size(400, 374);
            this.graphicsArea.TabIndex = 4;
            this.graphicsArea.TabStop = false;
            this.graphicsArea.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // programArea
            // 
            this.programArea.Location = new System.Drawing.Point(12, 31);
            this.programArea.Name = "programArea";
            this.programArea.Size = new System.Drawing.Size(363, 253);
            this.programArea.TabIndex = 7;
            this.programArea.Text = "";
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.SystemColors.Info;
            this.consoleBox.Location = new System.Drawing.Point(12, 290);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(363, 61);
            this.consoleBox.TabIndex = 8;
            this.consoleBox.Text = "";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // consoleClear
            // 
            this.consoleClear.Location = new System.Drawing.Point(12, 357);
            this.consoleClear.Name = "consoleClear";
            this.consoleClear.Size = new System.Drawing.Size(363, 48);
            this.consoleClear.TabIndex = 9;
            this.consoleClear.Text = "Clear Console";
            this.consoleClear.UseVisualStyleBackColor = true;
            this.consoleClear.Click += new System.EventHandler(this.consoleClear_Click);
            // 
            // colourPicker
            // 
            this.colourPicker.Location = new System.Drawing.Point(390, 414);
            this.colourPicker.Name = "colourPicker";
            this.colourPicker.Size = new System.Drawing.Size(400, 30);
            this.colourPicker.TabIndex = 10;
            this.colourPicker.Text = "Colour Picker";
            this.colourPicker.UseVisualStyleBackColor = true;
            this.colourPicker.Click += new System.EventHandler(this.colourPicker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.colourPicker);
            this.Controls.Add(this.consoleClear);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.programArea);
            this.Controls.Add(this.graphicsArea);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphicsArea)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.PictureBox graphicsArea;
        private System.Windows.Forms.RichTextBox programArea;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button consoleClear;
        private System.Windows.Forms.Button colourPicker;
    }
}

