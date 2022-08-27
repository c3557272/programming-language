using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// This class is to allow for testing of the drawTo command
    /// </summary>
    public class drawTo
    {
        
        int startX, startY;
        /// <summary>
        /// This method updates the values of the starting coordinates to the coordinated input by the user. 
        /// </summary>
        /// <param name="endX"> This is the ending point for the x coordinate of where the line draws to. </param>
        /// <param name="endY"> This is the ending point for the y coordinate of where the line draws to. </param>
        public drawTo(int endX, int endY)
        {
            startX = endX;
            startY = endY;     
        }
    }
}
