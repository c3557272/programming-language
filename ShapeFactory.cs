using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGPE
{
    /// <summary>
    /// This is the Factory class that will create all shapes and will be the key class to call when creating shapes.
    /// </summary>
    
    class ShapeFactory
    {
        /// <summary>
        /// This method is called to create a shape and return the shape object. If the "if" statement is not fullfilled with any of it's conditions then the system throws an argument exception.
        /// </summary>
        /// <param name="shapeType"> This is where the shape type is determined base on what is read back into the system. If it is equal to a specific shape such as a circle, then a circle will be produced by the factory. </param>
        /// <returns> Using an if statement, a specific shape is returned depdning on what shapeType is equal to. </returns>
        public Shape getShape(String shapeType)
        {
            shapeType = shapeType.ToLower().Trim();
            if (shapeType.Equals("circle"))
            {
                return new Circle();
            }
            if (shapeType.Equals("rectangle"))
            {
                return new Rectangle();
            }
            if (shapeType.Equals("triangle"))
            {
                return new Triangle();
            }
            else
            {
                System.ArgumentException argEx = new System.ArgumentException("Factory error: " + shapeType + " does not exist.");
                throw argEx;
            }
        }
    }
}
