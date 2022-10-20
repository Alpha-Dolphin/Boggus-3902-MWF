using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnvironmentObjects.Helpers
{
    public class EnviroSprite : ISprite
    {
        /*
        Debug switch
        */
        private bool DEBUG = false;
        /*
         * Data for source of sprite information for each frame to animate
         */
        public string sourceFileDirectory;
        public int sourceX;
        public int sourceY;
        public int sourceWidth;
        public int sourceHeight;
        /*
         * Data for where to place sprite in window
         */
        public int positionX;
        public int positionY;
        public int width;
        public int height;

        Texture2D spriteSheet;

        public void initialize()
        {
            sourceFileDirectory = "";
            sourceX = 0;
            sourceY = 0;
            sourceWidth = 0;
            sourceHeight = 0;


            /*
             * Data for where to place sprite in window
             */


            positionX = 0;
            positionY = 0;
            width = 0;
            height = 0;
        }

        public void Update(int x, int y)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, getPositionRectangle(), getSourceRectangle(), Color.White);
        }
        public void loadSpriteSheet(Texture2D newSpriteSheet)
        {
            spriteSheet = newSpriteSheet;
        }
        public Rectangle getPositionRectangle()
        {

            return new Rectangle(positionX, positionY, width, height);

        }

        public Rectangle getSourceRectangle()
        {
            if (DEBUG)
            {
                Debug.WriteLine("get source rectangle called.");
            }

            return new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);


        }

        public void setPositionRectangle(int x, int y, int w, int h)
        {
            positionX = x;
            positionY = y;
            width = w;
            height = h;
        }

        public void setFrameRectangle(int x, int y, int w, int h)
        {
            sourceX = x;
            sourceY = y;
            sourceWidth = w;
            sourceHeight = h;
        }

        public void setSourceDirectory(string directory)
        {
            sourceFileDirectory = directory;
        }
        public string getSourceDirectory()
        {
            if (DEBUG)
            {
                Debug.WriteLine("getSourceDirectory called on moving animated sprite, Directory returned: " + sourceFileDirectory);
            }

            return sourceFileDirectory;
        }

        public bool finished()
        {
            return true;
        }


    }
}
