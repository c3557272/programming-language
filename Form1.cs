using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGPE
{
    /// <summary>
    /// This is the main class of the application and where the form is generated.
    /// </summary>
    public partial class Form1 : Form
    {
        const int bitmapX = 400; 
        const int bitmapY = 400;
        Bitmap OutputBitmap = new Bitmap(bitmapX, bitmapY);
        public Canvass myCanvass;                          
        public CommandParser parser = new CommandParser(); 
        
        /// <summary>
        /// Constructor the for the form which is the main visual of the application. The form is initiated and canvas is created.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            myCanvass = new Canvass(Graphics.FromImage(OutputBitmap));
            
        }

        /// <summary>
        /// This is where the image is created and drawn using it's original physical size at the location specified.
        /// </summary>
        /// <param name="sender"> contains reference to the object that raised the event. </param> 
        /// <param name="e"> contains the event data. </param> 

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }
        /// <summary>
        /// Invokes the 'enter' key command using the parse method from the CommandParser class then reseting command line.
        /// </summary>
        /// <param name="sender"> contains reference to the object that raised the event. </param> 
        /// <param name="e"> contains the event data. </param> 

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                parser.parseCommand(commandLine.Text, programArea, consoleBox, myCanvass);
                commandLine.Text = "";
                Refresh();
            }
        }

        /// <summary>
        /// creates a dialog box to save the program as an RTF file to anywhere on user's system given they have access to specified saving area. 
        /// </summary>
        /// <param name="sender"> contains reference to the object that raised the event. </param> 
        /// <param name="e"> contains the event data. </param> 

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files | *.rtf";

            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                programArea.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /// <summary>
        /// creates dialog box of user's system that actively looks for RTF files and then loads file, if selected, into the program area(Rich Text Box).
        /// </summary>1
        /// <param name="sender"> contains reference to the object that raised the event. </param> 
        /// <param name="e"> contains the event data. </param> 

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files | *.rtf";
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
            {
                programArea.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        /// <summary>
        /// closes application.
        /// </summary>
        /// <param name="sender"> contains the reference to the object that raised the event. </param> 
        /// <param name="e"> contains the event data. </param> 

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// This method is to allow the menu at the top of the form to have an interactable drop down menu.
        /// </summary>
        /// <param name="sender"> contains the reference to the object that raised the event. </param>
        /// <param name="e"> contains the event data. </param>
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// Method that runs when the form is loaded and is vital to the execution of the form.
        /// </summary>
        /// <param name="sender"> contains the reference to the object that raised the event. </param>
        /// <param name="e"> contains the event data. </param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consoleClear_Click(object sender, EventArgs e)
        {
            consoleBox.Text = " ";
        }

        private void colourPicker_Click(object sender, EventArgs e)
        {
            myCanvass.penColorDialog();
        }
    }
}
