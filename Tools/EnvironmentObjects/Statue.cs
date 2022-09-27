/*Statue object*/

using LOZ;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LOZ.Tools.EnvironmentObjects.Helpers;

/*Call update at least once before drawing*/
class Statue : IEnvironment
{
    private EnviroSprite enviroSprite = new EnviroSprite();

    /*Update must be called at least once before drawing*/
    public void draw(SpriteBatch spriteBatch)
    {
        enviroSprite.draw(spriteBatch);
    }
    /*Sets the source and location rectangles*/
    public void update()
    {

        enviroSprite.setFrameRectangle(1018, 11, 16, 16);

        enviroSprite.setPositionRectangle(400,400,16 * Constants.objectScale, 16 * Constants.objectScale);
    }
    public void load()
    {
        enviroSprite.loadSpriteSheet(Game1.ENVIRONMENT_SPRITESHEET);
    }
}