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
    bool Finished();
    void Draw(SpriteBatch spriteBatch);
}

interface IEnvironment
{
    void SetPlacement(int x, int y);
    Rectangle GetRectangle();
    void Update();
    void Draw(SpriteBatch spriteBatch);
    void Load();
}

interface IHitbox{
    List<Rectangle> GetHitboxes();
}
