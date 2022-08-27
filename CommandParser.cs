using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGPE
{
    /// <summary>
    /// This class is where the method to pass user input through the application is checked. A method is created to check the user's input and process it appropriately using multiple arrays and methods. This method is vital to the program as it allows for the creation of variables, loops, if statements and other various functions that are all tied and triggered based on user input.
    /// </summary>
    public class CommandParser 
    {
        Canvass canvass = new Canvass();
        List<string> varNames = new List<string>();
        List<int> varValues = new List<int>();
        ArrayList methods = new ArrayList();
        int methodLineCount = 0;
        int lineNumber = 1;
        bool running = true;
        /// <summary>
        /// parseCommand method is where every input is processed. This handles both the program area's code as well as the command line's. 
        /// </summary>
        /// <param name="commandLine"> this is the textbox used that can process single lines of code to manipulate the canvas. </param>
        /// <param name="programArea"> this is the richtextbox which allows mulitple lines of code to be entered and be recursively executed one at a time </param>
        /// <param name ="consoleBox"> this is a richtextbox that allows the user to view the console output of the program specifically identifying correct execution and errors </param>
        /// <param name="myCanvass"> this canvas parameter allows for the original canvas from the form class to be accessed and fully functional </param>
        public void parseCommand(string commandLine, RichTextBox programArea, RichTextBox consoleBox, Canvass myCanvass)
        {
            if (running == true)
            {
                string[] commands = new string[] { "moveto", "drawto", "circle", "rect", "triangle", "run", "redpen", "bluepen", "blackpen", "greenpen", "clear", "reset", "shapefill", "noshapefill", "save", "load", "endfor", "loop", "endif" }; //Commands list
                commandLine = commandLine.ToLower().Trim(); // Trims the command entered and lowers it to lower case to avoid case sensitivity issues. 
                string[] userInput = commandLine.Split();   // Creates a list which holds all the user's inputs and it is split.
                if (userInput.Length == 2)                                   //If userinput list holds 2 values, then the following takes place:
                {
                    string instruction = userInput[0];                              // - The first item in the list is stored in the string variable "command" which will be the action word
                    string[] parameter = userInput[1].Split(',');              // - Creates a parameters list to hold the second input of the userinput list which is split further
                    int count = parameter.Length;
                    int[] parameters = new int[count];

                    for (int i = 0; i < parameter.Length; i++)                              // For Loop to check through the parameters and creating a list of their individual values 
                    {
                        try
                        {
                            if (varNames.Contains(parameter[i]))
                            {
                                int a = varNames.IndexOf(parameter[i]);
                                parameters[i] = varValues[a];
                            }
                            else
                            {

                                parameters[i] = Convert.ToInt32(parameter[i]);

                            }

                        }
                        catch (FormatException)
                        {
                            int pos = lineNumber;
                            consoleBox.AppendText("Syntax Error! Invalid Parameter Conversion for: " + instruction + " on Line: " + pos + Environment.NewLine);
                            lineNumber++;
                            return;
                        }
                    }

                    if (instruction.Equals("drawto"))                                       //command is passed through an if statement to check if it is correct and then the corresponding parameters are passed through the method called as a result.
                    {

                        if (parameters.Length != 2 | parameters[1].Equals(0))
                        {
                            consoleBox.AppendText("Invalid Parameter given for " + instruction + "! " + Environment.NewLine);
                        }

                        else
                        {
                            myCanvass.DrawTo(parameters[0], parameters[1]);
                        }
                    }
                    if (instruction.Equals("moveto"))
                    {
                        if (parameters.Length != 2)
                        {
                            consoleBox.AppendText("Invalid Parameters for " + instruction + "! " + Environment.NewLine);
                        }
                        else
                        {
                            myCanvass.MoveTo(parameters[0], parameters[1]);
                        }
                    }
                    if (instruction.Equals("circle"))
                    {

                        if (parameters.Length != 1 | parameters[0] < -1)
                        {
                            consoleBox.AppendText("Invalid Parameters for " + instruction + "! ");
                            lineNumber++;
                        }
                        else
                        {
                            myCanvass.Circle(parameters[0]);
                            consoleBox.AppendText("Circle drawn with radius of: " + parameter[0] + Environment.NewLine);
                        }
                    }
                    if (instruction.Equals("rect"))
                    {
                        if (parameters.Length != 2)
                        {
                            consoleBox.AppendText("Invalid Parameters for " + instruction + "! " + Environment.NewLine);
                            lineNumber++;
                        }
                        else
                        {
                            myCanvass.drawRectangle(parameters[0], parameters[1]);
                            consoleBox.AppendText("Rectangle drawn with parameters: " + parameter[0] +" and " +parameters[1] + Environment.NewLine);
                        }
                    }

                    if (instruction.Equals("triangle"))
                    {
                        if (parameters.Length != 4)
                        {
                            consoleBox.AppendText("Invalid Parameters for " + instruction + "! " + Environment.NewLine);
                            lineNumber++;
                        }
                        else
                        {
                            myCanvass.drawTriangle(parameters[0], parameters[1], parameters[2], parameters[3]);
                            consoleBox.AppendText("Triangle drawn with parameters: " + parameters[0] + ", " + parameters[1] + ", " + parameters[2] + " and " + parameters[3] + Environment.NewLine);
                        }
                    }
                }
                if (userInput.Length == 1)                                              // This if statement is specifically for all the inputs that have no parameters or only 1. If it has one parameter, it is recursively called.
                {                                                                               //instructions are identified using an if statement for each and then their respective methods from the canvass class are called.
                    string instruction = userInput[0];                                          //A message is also displayed at the end of each statement to provide visual output to the user to tell them their command was successful.
                    if (instruction.Equals("run"))
                    {
                        if (running == true)
                        {
                            lineNumber = 1;
                            int lines = programArea.Lines.Length;
                            String s = String.Empty;
                            try
                            {
                                foreach (string str in programArea.Lines)
                                {
                                    s = str;
                                    try
                                    {
                                        parseCommand(s, programArea, consoleBox, myCanvass);
                                    }
                                    catch (ArgumentException argEx)
                                    {
                                        int o;
                                        o = str.IndexOf(s);
                                        consoleBox.AppendText("Error found on line: " + o + Environment.NewLine);
                                        throw argEx;
                                    }
                                }
                            }

                            catch
                            {

                            }
                            lineNumber = 1;
                        }
                        else
                        {

                        }
                    }

                    if (instruction.Equals("black") | instruction.Equals("red") | instruction.Equals("green") | instruction.Equals("blue"))
                    {
                        myCanvass.changeColour(instruction);
                        consoleBox.AppendText("Pen colour is now " + instruction + Environment.NewLine);
                    }

                    if (instruction.Equals("shapefill"))
                    {
                        myCanvass.shapeFill();
                        consoleBox.AppendText("Shape fill is now On. " + Environment.NewLine);
                    }

                    if (instruction.Equals("noshapefill"))
                    {
                        myCanvass.noShapeFill();
                        consoleBox.AppendText("Shape fill is now Off. " + Environment.NewLine);
                    }

                    if (instruction.Equals("clear"))
                    {
                        myCanvass.clearCanvas();
                        consoleBox.AppendText("Canvas Cleared! " + Environment.NewLine);
                    }
                    if (instruction.Equals("reset"))
                    {
                        myCanvass.resetPoint();
                        consoleBox.AppendText("Point reset to 0,0! " + Environment.NewLine);
                    }
                    if (instruction.Equals("save"))
                    {
                        SaveFileDialog saveFile1 = new SaveFileDialog();
                        saveFile1.DefaultExt = "*.rtf";
                        saveFile1.Filter = "RTF Files | *.rtf";

                        if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
                        {
                            programArea.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                        }
                        consoleBox.AppendText("File Saved. " + Environment.NewLine);
                    }

                    if (instruction.Equals("load"))
                    {
                        OpenFileDialog openFile1 = new OpenFileDialog();
                        openFile1.DefaultExt = "*.rtf";
                        openFile1.Filter = "RTF Files | *.rtf";
                        if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
                        {
                            programArea.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                        }
                        consoleBox.AppendText("File loaded. " + Environment.NewLine);
                    }

                    if (commands.Contains(instruction))
                    {
                        return;
                    }
                    else
                    {
                        consoleBox.AppendText("Command not valid, found on Line: " + lineNumber + Environment.NewLine);
                    }

                }
                // VARIABLES            
                if (userInput.Length == 3 & userInput.Contains("="))                                        //If Statement that allows users to create variables during the course of the program and is able to store and update values.
                {
                    int varValue = Convert.ToInt32(userInput[2]);
                    if (varNames.Contains(userInput[0]))
                    {
                        int a = varNames.IndexOf(userInput[0]);
                        varValues[a] = varValue;
                    }
                    else
                    {
                        varValues.Add(varValue);
                        varNames.Add(userInput[0]);
                    }
                }

                if (userInput.Length == 5 & userInput.Contains("+"))                                         //This If statement allows users to add values onto already existing variables and increase their values. 
                {
                    try
                    {
                        if (varNames.Contains(userInput[4]))
                        {
                            int varValue;
                            int a = varNames.IndexOf(userInput[4]);
                            varValue = varValues[a];
                            int o = varNames.IndexOf(userInput[0]);
                            varValues[o] = varValues[o] + varValue;

                        }
                        else
                        {
                            int varValue = Convert.ToInt32(userInput[4]);
                            int a = varNames.IndexOf(userInput[0]);
                            varValues[a] = varValues[a] + varValue;
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        consoleBox.AppendText("Variable does not exist in data. " + "Error found Line: " + lineNumber + Environment.NewLine);

                    }
                    catch (FormatException)
                    {
                        consoleBox.AppendText("Variable has incorrect parameter given. " + Environment.NewLine);
                    }
                }

                if (userInput.Length == 5 & userInput.Contains("-"))                                         //This If statement allows users to add values onto already existing variables and increase their values. 
                {
                    try
                    {
                        if (varNames.Contains(userInput[4]))
                        {
                            int varValue;
                            int a = varNames.IndexOf(userInput[4]);
                            varValue = varValues[a];
                            int o = varNames.IndexOf(userInput[0]);
                            varValues[o] = varValues[o] - varValue;

                        }
                        else
                        {
                            int varValue = Convert.ToInt32(userInput[4]);
                            int a = varNames.IndexOf(userInput[0]);
                            varValues[a] = varValues[a] - varValue;
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        consoleBox.AppendText("Variable does not exist in data. " + "Error found Line: " + lineNumber + Environment.NewLine);

                    }
                    catch (FormatException)
                    {
                        consoleBox.AppendText("Variable has incorrect parameter given. " + Environment.NewLine);
                    }
                }
                // IF STATEMENTS
                if (userInput[0] == "if" & userInput.Length == 6)                                                               //Single Line If Statement by taking in user input and creating an if within the code to compare the values provided.
                {

                    int secondVal = Convert.ToInt32(userInput[3]);
                    int a = varNames.IndexOf(userInput[1]);
                    int firstVal = varValues[a];
                    string b = string.Empty;
                    if (userInput[2] == "<")
                    {
                        if (firstVal < secondVal)
                        {
                            b = (userInput[4] + " " + userInput[5]);
                            parseCommand(b, programArea, consoleBox, myCanvass);
                        }
                    }
                    if (userInput[2] == ">")
                    {
                        if (firstVal > secondVal)
                        {
                            b = (userInput[4] + " " + userInput[5]);
                            parseCommand(b, programArea, consoleBox, myCanvass);
                        }
                    }
                }

                if (userInput[0] == "if" & userInput.Length == 4)                                                           //If Block - Not Working At the Moment
                {
                    if (userInput[2] == "<")
                    {
                        int firstVal = 0;
                        if (varNames.Contains(userInput[1]))
                        {
                            int a = varNames.IndexOf(userInput[1]);
                            varValues[a] = firstVal;
                        }
                        else
                        {
                            Console.WriteLine("Variable does not exist.");
                        }
                        int secondVal = Convert.ToInt32(userInput[3]);
                        int pos1word = programArea.Find("if", RichTextBoxFinds.MatchCase);
                        int pos1 = programArea.GetLineFromCharIndex(pos1word);
                        int pos2word = programArea.Find("endif", RichTextBoxFinds.MatchCase);
                        int pos2 = programArea.GetLineFromCharIndex(pos2word);

                        if (firstVal < secondVal)
                        {
                            String z = String.Empty;
                            for (int g = pos1 + 1; g < pos2; g++)
                            {
                                z = programArea.Lines[g];
                                parseCommand(z, programArea, consoleBox, myCanvass);
                            }
                        }
                        else
                        {
                            running = false;
                        }
                    }
                    if (userInput[2] == ">")
                    {
                        int firstVal = 0;
                        if (varNames.Contains(userInput[1]))
                        {
                            int a = varNames.IndexOf(userInput[1]);
                            varValues[a] = firstVal;
                        }
                        else
                        {
                            Console.WriteLine("Variable does not exist.");
                        }
                        int secondVal = Convert.ToInt32(userInput[3]);
                        int pos1word = programArea.Find("if", RichTextBoxFinds.MatchCase);
                        int pos1 = programArea.GetLineFromCharIndex(pos1word);
                        int pos2word = programArea.Find("endif", RichTextBoxFinds.MatchCase);
                        int pos2 = programArea.GetLineFromCharIndex(pos2word);

                        if (firstVal > secondVal)
                        {
                            String z = String.Empty;
                            for (int g = pos1 + 1; g < pos2; g++)
                            {
                                z = programArea.Lines[g];
                                parseCommand(z, programArea, consoleBox, myCanvass);
                            }
                        }
                    }

                }

                //LOOPS
                if (userInput.Contains("loop") & (userInput.Length == 3))                                    //This is where users can create For Loops by providing a value that represents how many times they want to loop the code.
                {
                    int secondVal = Convert.ToInt32(userInput[2]);
                    int pos1word = programArea.Find("loop", RichTextBoxFinds.MatchCase);
                    int pos1 = programArea.GetLineFromCharIndex(pos1word);
                    int pos2word = programArea.Find("endfor", RichTextBoxFinds.MatchCase);
                    int pos2 = programArea.GetLineFromCharIndex(pos2word);
                    for (int i = 0; i < secondVal - 1; i++)
                    {
                        String z = String.Empty;
                        for (int g = pos1 + 1; g < pos2; g++)
                        {
                            z = programArea.Lines[g];
                            parseCommand(z, programArea, consoleBox, myCanvass);
                        }
                    }

                }

                //METHODS - Not working
                if (userInput[0] == "method")
                {
                    List<string> method1 = new List<string>();
                    int position1word = programArea.Find("method", RichTextBoxFinds.MatchCase);
                    int position1 = programArea.GetLineFromCharIndex(position1word);
                    int position2word = programArea.Find("endmethod", RichTextBoxFinds.MatchCase);
                    int position2 = programArea.GetLineFromCharIndex(position2word);
                    string s = String.Empty;


                    methods.Add(method1);
                    for (int m = position1 + 1; m < position2; m++)
                    {
                        s = programArea.Lines[m];
                        method1.Add(s);

                        methodLineCount++;
                    }

                }

                if (methods.Contains(userInput[0]))
                {
                    List<string> method = new List<string>();
                    string s = string.Empty;
                    string x = string.Empty;
                    List<string> a = (List<string>)methods[0];
                    int f = a.Count;

                    for (int i = 0; i < methodLineCount; i++)
                    {
                        for (int k = 0; k < f; k++)
                        {
                            x = a[k];
                            method.Add(x);
                        }
                        s = method[i];
                        parseCommand(s, programArea, consoleBox, myCanvass);
                    }
                }
                lineNumber++;
            }

        }
    }
}
