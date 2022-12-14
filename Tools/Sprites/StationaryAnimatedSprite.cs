/*
 Implementation of ISprite for non mobile animated sprites
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

public class StationaryAnimatedSprite //: ISprite
{
    /*
     Debug switch
     */
    private bool DEBUG = true;
    /*
     * Data for source of sprite information for each frame to animate
     */
    public string sourceFileDirectory;
    public int sourceX1;
    public int sourceY1;
    public int sourceWidth1;
    public int sourceHeight1;

    public int sourceX2;
    public int sourceY2;
    public int sourceWidth2;
    public int sourceHeight2;

    public int sourceX3;
    public int sourceY3;
    public int sourceWidth3;
    public int sourceHeight3;

    /*
     * Data for where to place sprite in window
     */


    public int positionX;
    public int positionY;
    public int width;
    public int height;




    /*
     Frame Counter
     */
    public int currentFrame = 0;
    private double timeFlag;

    Texture2D spriteSheet;


    public void initialize()
    {
        this.sourceFileDirectory = "";
        this.sourceX1 = 0;
        this.sourceY1 = 0;
        this.sourceWidth1 = 0;
        this.sourceHeight1 = 0;

        this.sourceX2 = 0;
        this.sourceY2 = 0;
        this.sourceWidth2 = 0;
        this.sourceHeight2 = 0;

        this.sourceX3 = 0;
        this.sourceY3 = 0;
        this.sourceWidth3 = 0;
        this.sourceHeight3 = 0;

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

    }

    public void loadSpriteSheet(Texture2D newSpriteSheet)
    {
        spriteSheet = newSpriteSheet;
    }
    public void draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(spriteSheet, getPositionRectangle(), getSourceRectangle(), Color.White);
    }

    public Rectangle getPositionRectangle()
    {

        return new Rectangle(positionX, positionY, width, height);

    }

    public Rectangle getSourceRectangle()
    {
        if (DEBUG)
        {
            Debug.WriteLine("get source rectangle called. Current Frame: " + currentFrame);
        }

        switch (currentFrame)
        {
            case 0: return new Rectangle(sourceX1, sourceY1, sourceWidth1, sourceHeight1);

            case 1: return new Rectangle(sourceX2, sourceY2, sourceWidth2, sourceHeight2);

            default: return new Rectangle(0, 0, 0, 0);

        }
    }

    public void setPositionRectangle(int x, int y, int w, int h)
    {
        this.positionX = x;
        this.positionY = y;
        this.width = w;
        this.height = h;
    }

    public void setFrame1Rectangle(int x, int y, int w, int h)
    {
        this.sourceX1 = x;
        this.sourceY1 = y;
        this.sourceWidth1 = w;
        this.sourceHeight1 = h;
    }
    public void setFrame2Rectangle(int x, int y, int w, int h)
    {
        this.sourceX2 = x;
        this.sourceY2 = y;
        this.sourceWidth2 = w;
        this.sourceHeight2 = h;
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

    public void updateCurrentFrame(GameTime gameTime)
    {
        double currentTime = gameTime.ElapsedGameTime.TotalMilliseconds;
        if (DEBUG)
        {
            Debug.WriteLine("UpdateCurrentFrame Called. Current Frame Prior to Check: " + currentFrame);
            Debug.WriteLine("Time Flag Prior to Check: " + timeFlag);
            Debug.WriteLine("gameTime Prior to Check: " + currentTime);

        }

        if (currentTime > 100)
        {
            currentFrame = (currentFrame + 1) % 2;
            timeFlag = currentTime;
        }
        if (DEBUG)
        {
            Debug.WriteLine("Current Frame after Check: " + currentFrame);
            Debug.WriteLine("Time Flag after Check: " + timeFlag);
            Debug.WriteLine("gameTime after Check: " + gameTime.TotalGameTime.TotalMilliseconds);
        }
    }
}
