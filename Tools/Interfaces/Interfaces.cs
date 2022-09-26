/*
Interfaces for game

*/

using Microsoft.Xna.Framework.Graphics;

interface ISprite
{
    void Update(int x, int y);
    //void initialize();

    void Draw(SpriteBatch spriteBatch);
}