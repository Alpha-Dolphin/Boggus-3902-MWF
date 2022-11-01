/*
 Implementation of IController to use a keyboard
 */

using System;
using System.Collections.Generic;
using System.Data;
using LOZ;
using Microsoft.Xna.Framework.Input;

public class MouseController //: IController
{
    MouseState mouseState;
    bool leftLastPressed = false;
    bool rightLastPressed = false;
    public DateTime lastInputTime = DateTime.Now;
    public void Update()
    {
        mouseState = Mouse.GetState();


        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (!leftLastPressed)
            {
                Game1.currentRoom++;
                if (Game1.currentRoom > 18) Game1.currentRoom -= 19;
            }

            leftLastPressed = true;
        }
        else leftLastPressed = false;
        if (mouseState.RightButton == ButtonState.Pressed)
        {
            if (!rightLastPressed)
            {
                Game1.currentRoom--;
                if (Game1.currentRoom < 0) Game1.currentRoom += 19;
            }

            rightLastPressed = true;
        }
        else rightLastPressed = false;
    }


}