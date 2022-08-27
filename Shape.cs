using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// Abstract shape class that inherits from the Shapes interface. Here the shape's traits are expanded upon further adding additoinal depth to the methods that will be fully fleshed out within each specific shape class.
    /// </summary>
    abstract class Shape : Shapes
    {
        protected Color colour;
        protected int x, y;

        /// <summary>
        /// Base method of the shape object that stores the placeholder values of the three key parameters, the colour and x and y positions.
        /// </summary>
        public Shape()
        {
            colour = Color.Red;
            x = y = 100;
        }

        /// <summary>
        /// This is the shape method that contains the parameters that will be used to assign the various values to variables.
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="x"> The x parameter that stores the x coordinate. </param>
        /// <param name="y"> The y parameter that stores the y corrdinate. </param>
        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Abstract draw method that pulls from the interface and will subsequently be passed onto the shape-specific draw command. 
        /// </summary>
        /// <param name="g"> the graphics parameter that refers to the canvas.</param>
        public abstract void draw(Graphics g);

        /// <summary>
        /// Abstract draw fill method that pulls from the interface and will subsequently be passed onto the shape-specific draw command.
        /// </summary>
        /// <param name="g"> the graphics parameter that refers to the canvas. </param>
        public abstract void drawfill(Graphics g);

        /// <summary>
        /// Virtual method of the set function that will allow the specific shape to set it's colour and parameters using a list to store them.
        /// </summary>
        /// <param name="colour"> the colour in which the shape will be drawn whether that is the outline or filled shape. </param>
        /// <param name="list"> the list where the parameters will be stored and eventually used as parameters for shape draw functions. </param>
        public virtual void set(Color colour, params int[] list)
        {
            this.colour = colour;
            this.x = list[0];
            this.y = list[1];
        }

        /// <summary>
        /// Method that returns the string of the object it is referring to.
        /// </summary>
        /// <returns> Returns the base values of x and y </returns>
        public override string ToString()
        {
            return base.ToString()+"     "+ this.x + "," + this.y + " : ";
        }
    }
}
