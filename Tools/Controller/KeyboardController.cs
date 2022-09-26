/*
 Implementation of IController to use a keyboard
 */

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework.Input;

using LOZ.Tools.PlayerObjects;


namespace LOZ.Tools.Controller
{

    public class KeyboardController : IController
    {
        KeyboardState keyState;
        public int lastKeyPressed { get; private set; } = 1;
        public DateTime lastInputTime;

        public List<Keys> pressed;

        public List<Keys> update()
        {
            pressed = new List<Keys>();

            keyState = Keyboard.GetState();

            foreach (Keys key in Link_Constants.LINK_KEYS){
                if(keyState.IsKeyDown(key))
                {
                    pressed.Add(key);
                }
            }

            return pressed;
        }

        //public int getLastPressed() { return lastKeyPressed; }

    }
}