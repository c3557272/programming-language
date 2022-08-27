using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentGPE
{
    /// <summary>
    /// This class allows for the testing of the moveTo function.
    /// </summary>
    public class moveTo 
    {
        int startX, startY;
        /// <summary>
        /// This method allows for the testing of the moveTo method by showing it update it's position.
        /// </summary>
        /// <param name="endX"> The x coordinate of the endpoint for the function. </param>
        /// <param name="endY"> The y coordinate of the endpoint for the function. </param>
        public moveTo(int endX, int endY)
        {
            startX = endX;
            startY = endY;
        }
    }
}
