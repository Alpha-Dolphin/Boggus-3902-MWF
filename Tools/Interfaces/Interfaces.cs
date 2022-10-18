/*
Interfaces for game

*/

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
    void setPlacement(int x, int y);
    void update();
    void draw(SpriteBatch spriteBatch);
    void load();
}
