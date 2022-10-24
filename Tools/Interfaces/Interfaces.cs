/*
Interfaces for game

*/

using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
    Rectangle GetHurtbox();
    void SetHurtbox(int x, int y);
    void Draw(SpriteBatch spriteBatch);
}

interface ICollidable{
    Rectangle GetHurtbox();
    void SetHurtbox(int x, int y);
}

interface IHurtbox
{
    List<Rectangle> GetHitboxes();
}

internal interface ICollision
{
    bool Intersects(Rectangle a, Rectangle b);

    void Collide(Object a, Object b);
}

internal interface IEnemy : ICollidable
{
    void Attack(GameTime gameTime);
    void Die();
    void Move(GameTime gameTime);
    void Draw(SpriteBatch _spriteBatch);
    void Update(GameTime gameTime);
}
