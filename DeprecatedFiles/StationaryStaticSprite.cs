/*
 Implementation of ISprite for sprites that are completely static and do not move
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

public class StationaryStaticSprite : ISprite
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




    /*
     Frame Counter
     */
    private int currentFrame = 0;
    private double timeFlag;

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

    public void updateCurrentFrame(GameTime gameTime)
    {
        double currentTime = gameTime.TotalGameTime.TotalMilliseconds;
        if (DEBUG)
        {
            Debug.WriteLine("UpdateCurrentFrame Called. Current Frame Prior to Check: " + currentFrame);
            Debug.WriteLine("Time Flag Prior to Check: " + timeFlag);
            Debug.WriteLine("gameTime Prior to Check: " + currentTime);

        }

        if (currentTime > timeFlag + 300)
        {
            currentFrame = (currentFrame + 1) % 3;
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