/*
Interfaces for game

*/

using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
    Rectangle GetRectangle();
    void update();
    void draw(SpriteBatch spriteBatch);
    void load();
}

interface IHitbox{
    List<Rectangle> GetHitboxes();
}
