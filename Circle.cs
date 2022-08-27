using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// Circle class that inherits from Shape and will be the key class called by the factory to create circles.
    /// </summary>
    class Circle : Shape
    {
        
        int radius;
        /// <summary>
        /// Circle constructor class that inherits from base class.
        /// </summary>
        public Circle() : base()
        {

        }
        
        /// <summary>
        /// Circle method constructor class that uses the parameters of colour and radius which are the two core and integral components of a circle's construction.
        /// </summary>
        /// <param name="colour"> the colour of the pen or brush that draws the circle.</param>
        /// <param name="radius"> the radius of the circle that will be drawn. </param>
        public Circle(Color colour, int radius) 
        {
            this.radius = radius;
            
        }

        /// <summary>
        /// Override method for set that takes the prior set methods from the inherited classes and defines them properly to fit the circle object.
        /// </summary>
        /// <param name="colour"> the colour of the pen or brush that draws the circle. </param>
        /// <param name="list"> the list which stores the parameters of the circle's starting x and y positions as well as the radius. </param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.radius = list[2];
        }

        /// <summary>
        /// Override method for the drawfill class from prior classes in which the Circle class has inherited from. This will draw the circle and fill the shape with a colour.
        /// </summary>
        /// <param name="g"> the graphics object that refers to the canvas the shape will be drawn on</param>
        public override void drawfill(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);
            g.FillEllipse(b, x, y, radius * 2 , radius * 2);
        }

        /// <summary>
        /// Override method for the draw class which was set abstractly in prior classes inherited from. This will draw the outline of the circle with the parameters given.
        /// </summary>
        /// <param name="g"> the graphics object that refers to the canvas the shape will be drawn on</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        /// <summary>
        /// Method that returns the string of the object it is referring to.
        /// </summary>
        /// <returns> Returns the base value of radius </returns>
        public override string ToString()
        {
            return base.ToString() + "  " + this.radius;
        }
    }
}
