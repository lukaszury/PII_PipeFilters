using System;
using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel
{
    public class FilterConditional
    {
        private bool hasFace;
        
        public bool Filter(string path)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.YellowGreen);
            cog.Recognize(path);
            return FoundFace(cog);
        }
        


        private bool FoundFace(CognitiveFace cog)
        {
            if (cog.FaceFound)
            {
                Console.WriteLine("Face Found!");
                return true;
                /*
                if (cog.SmileFound)
                {
                    Console.WriteLine("Found a Smile :)");
                }
                else
                {
                    Console.WriteLine("No smile found :(");
                }
                */
            }
            else
                Console.WriteLine("No Face Found");
                return false;
        }
    }
}