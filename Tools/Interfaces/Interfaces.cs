/*
Interfaces for game

*/

using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

interface ISprite
{
    void Update(int x, int y);
    //void initialize();
    bool finished();
    void Draw(SpriteBatch spriteBatch);
}
    interface IEnvironment
    {
        void update();
        void draw(SpriteBatch spriteBatch);
        void load();

    Rectangle GetRectangle();
    }
