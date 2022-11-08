/*
Interfaces for game

*/

using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public interface ISprite
{
    void Update(int x, int y);
    //void initialize();
    bool Finished();
    void Draw(SpriteBatch spriteBatch);
}

public interface IEnvironment : ICollidable
{
    void SetPlacement(int x, int y);
    void Draw(SpriteBatch spriteBatch);
}

public interface ICollidable{
    Rectangle GetHurtbox();
    void SetHurtbox(Rectangle rect);
}

public interface IHurtbox
{
    List<Rectangle> GetHitboxes();
}

public interface ICollision
{
    bool Intersects(Rectangle a, Rectangle b);

    void Collide(Object a, Object b);
}

public interface IEnemy : ICharacter
{
    void Attack(GameTime gameTime);
    void Die();
    void Move(GameTime gameTime);
    void Draw(SpriteBatch _spriteBatch);
    void Update(GameTime gameTime);

    static void Appear(GameTime gameTime)
    {

    }

    static void Die(GameTime gameTime)
    {

    }
}

//Can own projectiles
public interface ICharacter : ICollidable { }


public interface IGate:ICollidable
{
    void Open();
    void Close();
    Direction GetDirection();
    bool IsGateOpen();
    void Draw(SpriteBatch spriteBatch);
}
