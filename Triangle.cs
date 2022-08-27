using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// Triangle class that inherits from Shape and will be the key class called by the factory to create triangles.
    /// </summary>
    class Triangle : Shape
    {
        int x1,x2,y1,y2;

        /// <summary>
        /// Base constructor of the triangle that inherits from base method set in prior classes triangle inherits from.
        /// </summary>
        public Triangle() : base()
        {
            
        }

        /// <summary>
        /// Triangle contructor class which will be the main method which will be called to create a triangle given the specific parameters of colour and scale.
        /// </summary>
        /// <param name="colour"> This will determine the colour of the triangle's outline or the fill colour of the filled triangle. </param>
        /// <param name="x1"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="y1"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="x2"> This will determine how big the equilateral triangle will be when drawn. </param>
        /// <param name="y2"> This will determine how big the equilateral triangle will be when drawn. </param>
        public Triangle(Color colour, int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        /// <summary>
        /// Override method for the set function for the triangle object which allows object traits to be set.
        /// </summary>
        /// <param name="colour"> where the colour of the triangle can be set. </param>
        /// <param name="list"> the list which stores the triangle's construction parameter. </param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.x1 = list[2];
            this.y1 = list[3];
            this.x2 = list[4];
            this.y2 = list[5];
        }

        /// <summary>
        /// The override draw method for the triangle's construction using a set of points.
        /// </summary>
        /// <param name="g"> the parameter which indicates the graphics object that refers to the canvas where the shape will be drawn.</param>
        public override void draw(Graphics g)
        {
            Point[] openPoints =
            {
                new Point(x, y),
                new Point(x1,y1),
                new Point(x2,y2),
            };

            Pen p = new Pen(colour);
            g.DrawPolygon(p, openPoints);
        }

        /// <summary>
        /// The override drawfill method that draws a filled triangle based on parameters given.
        /// </summary>
        /// <param name="g"> the parameter that indicates the graphics object that refers to the canvas where the shape will be drawn. </param>
        public override void drawfill(Graphics g)
        {
            Point[] openPoints =
            {
                new Point(x, y),
                new Point(x1,y1),
                new Point(x2,y2),
            };

            SolidBrush b = new SolidBrush(colour);
            g.FillPolygon(b, openPoints);
        }

        /// <summary>
        /// Method that returns the string of the object it is referring to.
        /// </summary>
        /// <returns> Returns the base value of the triangle's scale factor. </returns>
        public override string ToString()
        {
            return base.ToString() + "  " + this.x1 + ","+ this.x2 + "," +this.y1 + "," + this.y2;
        }
    }
}
