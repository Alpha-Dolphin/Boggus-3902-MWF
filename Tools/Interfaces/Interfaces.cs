/*
Interfaces for game

*/

using Microsoft.Xna.Framework.Graphics;

interface ISprite
{
    void Update(int x, int y);
    //void initialize();
    void draw(SpriteBatch spriteBatch);
}

interface IEnvironment
{
    void update();
    void draw(SpriteBatch spriteBatch);
    void load();
}
