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
    public DateTime lastInputTime = DateTime.Now;
    public void Update()
    {
        mouseState = Mouse.GetState();
        

        if (mouseState.LeftButton==ButtonState.Pressed)
        {
            if ((int)(DateTime.Now - lastInputTime).TotalSeconds > 2)
            {
                Game1.currentRoom++;
                if (Game1.currentRoom > 18) Game1.currentRoom -= 18;
                lastInputTime = DateTime.Now;
            }
        }
        if (mouseState.RightButton == ButtonState.Pressed)
        {
            if ((int)(DateTime.Now - lastInputTime).TotalSeconds > 2)
            {
                Game1.currentRoom++;
                if (Game1.currentRoom == 0) Game1.currentRoom += 18;
                lastInputTime = DateTime.Now;
            }
        }
    }


}