/*
Interfaces for game

*/

using Microsoft.Xna.Framework.Graphics;

interface IController{
    void update();

}

interface ISprite
{
    void update();
    void initialize();

    void draw(SpriteBatch spriteBatch);
}

interface IEnvironment
{
    void update();
    void draw(SpriteBatch spriteBatch);
}