using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnvironmentObjects
{
    internal class EnviroSprite : ISprite
    {
        /*
        Debug switch
        */
        private bool DEBUG = true;
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
            this.sourceFileDirectory = "";
            this.sourceX = 0;
            this.sourceY = 0;
            this.sourceWidth = 0;
            this.sourceHeight = 0;


            /*
             * Data for where to place sprite in window
             */


            this.positionX = 0;
            this.positionY = 0;
            this.width = 0;
            this.height = 0;
        }

        public void update()
        {
            throw new NotImplementedException();
        }
        public void draw(SpriteBatch spriteBatch)
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
            this.positionX = x;
            this.positionY = y;
            this.width = w;
            this.height = h;
        }

        public void setFrameRectangle(int x, int y, int w, int h)
        {
            this.sourceX = x;
            this.sourceY = y;
            this.sourceWidth = w;
            this.sourceHeight = h;
        }

        public void setSourceDirectory(string directory)
        {
            this.sourceFileDirectory = directory;
        }
        public string getSourceDirectory()
        {
            if (DEBUG)
            {
                Debug.WriteLine("getSourceDirectory called on moving animated sprite, Directory returned: " + this.sourceFileDirectory);
            }

            return this.sourceFileDirectory;
        }
    }
}
