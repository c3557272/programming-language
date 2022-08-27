using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// This is the interface in which the base methods are set for each shape function that will be elaborated on within the subsequent shape classes and shape factory.
    /// </summary>
    interface Shapes
    {
        /// <summary>
        /// This is the interface method in which shapes are able to set their colour and their various parameters or parameter in the case of a circle.
        /// </summary>
        /// <param name="c"> The colour of the shape's outline and/or fill. </param>
        /// <param name="list">The list which stores the parameters of the shape that will be created.</param>
        void set(Color c, params int[] list);
        
        /// <summary>
        /// This is the draw method that uses graphics as a parameter to draw to the canvas.
        /// </summary>
        /// <param name="g"> Graphics object parameter that will be used as a target canvas. </param>
        void draw(Graphics g);
        
        /// <summary>
        /// This is the draw method that will draw to the canvas and fill the object created.
        /// </summary>
        /// <param name="g"> Graphics object parameter that will be used as a target canvas. </param>
        void drawfill(Graphics g);
    }
}
