using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGPE
{
    /// <summary>
    /// Canvass class where canvas methods are created including the important drawing commands that will be vital to the application's operation. 
    /// </summary>
    public class Canvass
    {
        List<Shape> shapes = new List<Shape>();
        Pen myPen;         
        Graphics g = null;      
        int startX, startY;      
        bool penFill = false;    
        Color a;                 
        SolidBrush fillBrush;    
        ShapeFactory factory = new ShapeFactory();

        /// <summary>
        /// Canvas method that will hold the graphics displayed to the user. g is used as a placeholder parameter. This initiates the starting points for the objects previously stated as well as all the drawing tools such as the pen and brush.
        /// </summary>
        /// <param name="g"> Encapsulates the GDI drawing surface. </param> 
        public Canvass(Graphics g)
        {
            this.g = g;
            startX = startY = 0;
            myPen = new Pen(Color.Black, 1);
            a = myPen.Color;
            fillBrush = new SolidBrush(a);            
        }

        /// <summary>
        /// base Canvas method.
        /// </summary>
        public Canvass()
        {

        }

        /// <summary>
        /// This method allows for the modification of the colour for the Pen object.
        /// </summary>
        /// <param name="instruction"> the word that will be used to determine the colour requested. </param>
        public void changeColour(string instruction)
        {
            myPen.Color = Color.FromName(instruction);
        }



        /// <summary>
        /// Method that turns the boolean type shape filling to true so any shapes made will not be an outline but the fully filled in polygon.
        /// </summary>

        public void shapeFill()
        {
            penFill = true;
        }

        /// <summary>
        /// Method that turns boolean type shape filling to false so any shapes made will not be filled in, just an outline.
        /// </summary>

        public void noShapeFill()
        {
            penFill = false;
        }

        /// <summary>
        /// DrawTo method that draws a line from one point to another. Points are determined by the starting X and Y variables and the end X and Y variables; the end points are the points that are passed through the command line by the user.
        /// </summary>
        /// <param name="endX"> X coordinate of where the user wants the line to draw to. </param> 
        /// <param name="endY"> Y coordinate of where the user wants the line to draw to. </param> 
        public void DrawTo(int endX, int endY)
        {
            g.DrawLine(myPen, startX, startY, endX, endY);
            startX = endX;
            startY = endY;
        }

        /// <summary>
        /// MoveTo method that moves the invisible cursor from one point to another. Points are determined by the starting X and Y variables and the end X and Y variables; end points are the points passed through by the user via the command line.
        /// </summary>
        /// <param name="endX"> X coordinate of where the user wants to move the cursor. </param> 
        /// <param name="endY"> Y coordinate of where the user wants to move the cursor. </param> 
        public void MoveTo(int endX, int endY)
        {
            startX = endX;
            startY = endY;
        }
        
        /// <summary>
        /// Circle method that creates the circle on the canvas when called. An if statement is used to determined whether or not the shape will be filled when created.
        /// </summary>
        /// <param name="radius"> parameter to determine the radius of the circle created on the canvas. </param> 
        public void Circle(int radius)
        {           
            if (penFill == true)
            {
                Shape c;
                c = factory.getShape("circle");
                c.set(myPen.Color, startX, startY, radius);
                shapes.Add(c);
                c.drawfill(g);
            }
            if (penFill == false)
            {
                Shape c;
                c = factory.getShape("circle");
                c.set(myPen.Color, startX, startY, radius);
                c.draw(g);
            }
        }

        /// <summary>
        /// Rectangle method that creates the circle on the canvas when called. An if statement is used to determined whether or not the shape will be filled when created.
        /// </summary>
        /// <param name="x"> parameter for the x coordinate of the opposite corner from the starting coordinates. </param> 
        /// <param name="y"> parameter for the y coordinate of the opposite corner from the starting coordinates. </param> 
        public void drawRectangle(int x, int y)
        {
            if (penFill == true)
            {
                Shape r;
                r = factory.getShape("rectangle");
                r.set(myPen.Color, startX, startY, x, y);
                shapes.Add(r);
                r.drawfill(g);
            }
            if (penFill == false)
            {
                Shape r;
                r = factory.getShape("rectangle");
                r.set(myPen.Color, startX, startY, x, y);
                r.draw(g);
            }
        }

        /// <summary>
        /// A triangle is created using this method when called. Points are designated using the starting point and pre-determined sides that can be modified using the scale parameter.
        /// </summary>
        /// <param name="x1"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="y1"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="x2"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="y2"> This will determine how big the equilateral triangle will be when drawn. </param> 
        public void drawTriangle(int x1, int y1, int x2, int y2)
        {
            Point[] openPoints =
            {
                new Point(startX, startY),
                new Point(x1, y1),
                new Point(x2, y2),
            };
            if (penFill == true)
            {
                Shape t;
                t = factory.getShape("triangle");
                t.set(myPen.Color, startX, startY, x1, y1, x2, y2);
                shapes.Add(t);
                t.drawfill(g);
            }
            if (penFill == false)
            {
                Shape t;
                t = factory.getShape("triangle");
                t.set(myPen.Color, startX, startY, x1, x2, y1, y2);
                shapes.Add(t);
                t.draw(g);
            }
        }

        /// <summary>
        /// clear command that clears the canvas 
        /// </summary>

        public void clearCanvas()
        {
            g.Clear(Color.Transparent);
        }

        /// <summary>
        /// resets the position of the invisible cursor where draw commands begin. position is returned to 0,0.
        /// </summary>

        public void resetPoint()
        {
            startX = 0;
            startY = 0;
        }

        /// <summary>
        /// This method allows for a colour dialog box to open and help the user visually choose what colour they want to use.
        /// </summary>
        public void penColorDialog()
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.FullOpen = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                myPen.Color = MyDialog.Color;
                
            }
        }

    }
}

