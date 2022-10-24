/*Statue object*/

using LOZ;
using Microsoft.Xna.Framework.Graphics;using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using LOZ.Tools.EnvironmentObjects.Helpers;

/*Call update at least once before drawing*/
class Statue : IEnvironment
{
    private EnviroSprite enviroSprite = new EnviroSprite();
    private int xPosition = Constants.enviroDefaultX;
    private int yPosition = Constants.enviroDefaultY;
    public void SetPlacement(int x, int y)
    {
        xPosition = x;
        yPosition = y;
    }

    /*Update must be called at least once before drawing*/
    public void Draw(SpriteBatch spriteBatch)
    {
        enviroSprite.Draw(spriteBatch);
    }
    /*Sets the source and location rectangles*/
    public void Update()
    {

        enviroSprite.setFrameRectangle(1018, 11, 16, 16);

        enviroSprite.setPositionRectangle(xPosition, yPosition, 16 * Constants.objectScale, 16 * Constants.objectScale);
    }
    public void Load()
    {
        enviroSprite.loadSpriteSheet(Game1.ENVIRONMENT_SPRITESHEET);
    }
    public Rectangle GetRectangle()
    {
        return new Rectangle(enviroSprite.positionX, enviroSprite.positionY, enviroSprite.width, enviroSprite.height);
    }
}