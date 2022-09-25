/*
Interfaces for game
TODO:
1. Make file for IController interface and add headers for update
2. Make file for ISprite interface and add headers for update and loadContent
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