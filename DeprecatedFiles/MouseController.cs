/*
 Implementation of IController to use a keyboard
 */

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework.Input;

public class MouseController : IController
{
    MouseState mouseState;
    public int lastMousePosition { get; private set; } = 1;
    public DateTime lastInputTime;
    public void update()
    {
        mouseState = Mouse.GetState();
        

        if (mouseState.LeftButton==ButtonState.Pressed && mouseState.X>400 && mouseState.Y > 200)
        {
            lastMousePosition = 4;
            lastInputTime = DateTime.Now;
        }
        if (mouseState.LeftButton == ButtonState.Pressed && mouseState.X < 400 && mouseState.Y > 200)
        {
            lastMousePosition = 3;
            lastInputTime = DateTime.Now;
        }
        if (mouseState.LeftButton == ButtonState.Pressed && mouseState.X > 400 && mouseState.Y < 200)
        {
            lastMousePosition = 2;
            lastInputTime = DateTime.Now;
        }
        if (mouseState.LeftButton == ButtonState.Pressed && mouseState.X < 400 && mouseState.Y < 200)
        {
            lastMousePosition = 1;
            lastInputTime = DateTime.Now;
        }
        if (mouseState.RightButton == ButtonState.Pressed)
        {
            lastMousePosition = 0;
            lastInputTime = DateTime.Now;
        }
    }

    public int getLastPressed() { return lastMousePosition; }

}