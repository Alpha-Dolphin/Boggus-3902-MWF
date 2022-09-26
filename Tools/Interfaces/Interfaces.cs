/*
Interfaces for game

*/

using Microsoft.Xna.Framework.Graphics;

interface ISprite
{
    void Update(int x, int y);
    //void initialize();

<<<<<<< HEAD:Tools/Interfaces.cs
    void Draw(SpriteBatch spriteBatch);
=======
    void draw(SpriteBatch spriteBatch);
}

interface IEnvironment
{
    void update();
    void draw(SpriteBatch spriteBatch);
>>>>>>> b019a0ed3ef1143d86ffc0a63535bea97b9edca4:Tools/Interfaces/Interfaces.cs
}