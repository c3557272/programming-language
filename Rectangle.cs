using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// Rectangle class that inherits from Shape and will be the key class called by the factory to create rectangles.
    /// </summary>
    class Rectangle : Shape
    {
        int width, height;
        /// <summary>
        /// The rectangle base-inherited constructor
        /// </summary>
        public Rectangle() : base()
        {
            width = 100;
            height = 100;
        }

        /// <summary>
        /// This is the main constructor of the rectangle that contains all the key parameters required to create a rectangle.
        /// </summary>
        /// <param name="colour"> the colour of the rectangle's outline or the colour of the rectangle's fill. </param>
        /// <param name="x"> The starting position of the X coordinate. </param>
        /// <param name="y"> The starting position of the Y coordinate. </param>
        /// <param name="width"> The width of the rectangle that will be drawn. </param>
        /// <param name="height"> The height of the rectangle that will be drawn. </param>
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// The override method that will set the colour and parameters of the rectangle that will be drawn.
        /// </summary>
        /// <param name="colour"> The colour of the rectangle's outline or the rectangle's fill colour. </param>
        /// <param name="list"> The list which stores the parameters that will be used to create the rectangle on the canvas. </param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        /// <summary>
        /// The override draw method that will create the rectangle's outline.
        /// </summary>
        /// <param name="g"> the graphics object that refers to the canvas where the shape will be drawn. </param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawRectangle(p, x, y, width, height);
        }

        /// <summary>
        /// The override draw fill method that will create the rectangle and fill it with a specified colour.
        /// </summary>
        /// <param name="g"> the graphics object that refers to what canvas the shape will be drawn on. </param>
        public override void drawfill(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);
            g.FillRectangle(b, x, y, width, height);
        }

        /// <summary>
        /// Method that returns the string of the object it is referring to.
        /// </summary>
        /// <returns> Returns the base values of width and height </returns>
        public override string ToString()
        {
            return base.ToString() + "   " + this.width + "," + this.height;
        }

    }
}
