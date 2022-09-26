/*Statue object*/

using LOZ;
using LOZ.Tools.EnvironmentObjects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


class Statue : IEnvironment
{
    public EnviroSprite enviroSprite;

    
    public void draw(SpriteBatch spriteBatch)
    {
        enviroSprite.loadSpriteSheet(Game1.Dungeon_SpriteSheet);

        enviroSprite.draw(spriteBatch);
    }

    public void update()
    {
        throw new System.NotImplementedException();
    }
}