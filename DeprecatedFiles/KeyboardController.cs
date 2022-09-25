/*
 Implementation of IController to use a keyboard
 */

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework.Input;

public class KeyboardController : IController
{
    KeyboardState keyState;
    public int lastKeyPressed { get; private set; } = 1;
    public DateTime lastInputTime;
    public void update()
    {
        keyState = Keyboard.GetState();

        if (keyState.IsKeyDown(Keys.D4) || keyState.IsKeyDown(Keys.NumPad4))
        {
            lastKeyPressed = 4;
            lastInputTime = DateTime.Now;
        }
        if (keyState.IsKeyDown(Keys.D3) || keyState.IsKeyDown(Keys.NumPad3))
        {
            lastKeyPressed = 3;
            lastInputTime = DateTime.Now;
        }
        if (keyState.IsKeyDown(Keys.D2) || keyState.IsKeyDown(Keys.NumPad2))
        {
            lastKeyPressed = 2;
            lastInputTime = DateTime.Now;
        }
        if (keyState.IsKeyDown(Keys.D1) || keyState.IsKeyDown(Keys.NumPad1))
        {
            lastKeyPressed = 1;
            lastInputTime = DateTime.Now;
        }
        if (keyState.IsKeyDown(Keys.D0) || keyState.IsKeyDown(Keys.NumPad0))
        {
            lastKeyPressed = 0;
            lastInputTime = DateTime.Now;
        }
    }

    public int getLastPressed() { return lastKeyPressed; }

}