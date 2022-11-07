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
    public bool leftButtonPressed;
    public bool rightButtonPressed;
    public bool leftButtonHeld;
    public bool rightButtonHeld;
    public void Update()
    {
        mouseState = Mouse.GetState();


        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (leftButtonPressed) {
                leftButtonHeld = true;
            }
            if (!leftButtonPressed)
            {
                leftButtonPressed = true;
            }

        }
        else
        {
            if (leftButtonHeld)
            {
                leftButtonHeld=false;
            }
            if (leftButtonPressed)
            {
                leftButtonPressed=false;
            }

            leftLastPressed = true;
        }

        if (mouseState.RightButton == ButtonState.Pressed)
        {
            if (rightButtonPressed)
            {
                rightButtonHeld = true;
            }
            if (!rightButtonPressed)
            {
                rightButtonPressed = true;
            }

        }
        else
        {
            if (rightButtonHeld)
            {
                rightButtonHeld = false;
            }
            if (rightButtonPressed)
            {
                rightButtonPressed = false;
            }
        }
        executeNewPressedOnly();
    }

    private void executeNewPressedOnly()
    {

        if (rightButtonPressed && !rightButtonHeld) /*Increment with rollover*/
        {
            Game1.currentRoom = (Game1.currentRoom+1) % Constants.numRooms;
        }
        if (leftButtonPressed && !leftButtonHeld) /*Decrement with rollover*/
        {
            Game1.currentRoom = (19+(Game1.currentRoom - 1)) % Constants.numRooms;
        }

    }


}