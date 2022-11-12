/*
Interfaces for game

*/

using LOZ;
using LOZ.Tools.EnvironmentObjects.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

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

    static Rectangle Appear(double time) {
        Rectangle[] cloudFrames = new[] { new Rectangle(138, 185, 16, 16), new Rectangle(155, 185, 16, 16), new Rectangle(172, 185, 16, 16) };
        return cloudFrames[(int) ((time)/ (Constants.enemyEntryExitTime / 3)) % 3];
    }

    static Rectangle Disappear(double time)
    {
        Rectangle[] explostionFrames = new[] { new Rectangle(0, 0, 16, 16), new Rectangle(0, 16, 16, 16), new Rectangle(35, 3, 9, 10), new Rectangle(51, 3, 9, 10) };
        return explostionFrames[(int)(time / (Constants.enemyEntryExitTime / 4)) % 4];
    }
}

//Can own projectiles
public interface ICharacter : ICollidable { }
