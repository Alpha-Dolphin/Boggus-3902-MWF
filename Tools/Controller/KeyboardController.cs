/*
 Implementation of IController to use a keyboard
 */

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna;
using Microsoft.Xna.Framework.Input;

using LOZ.Tools.PlayerObjects;


namespace LOZ.Tools.Controller
{

    public class KeyboardController : IController
    {
        KeyboardState keyState;
        public int lastKeyPressed { get; private set; } = 1;
        public DateTime lastInputTime;

        public List<Keys> pressed =  new List<Keys>();
        public List<Keys> held = new List<Keys>();

        public List<Keys> update()
        {
            

            keyState = Keyboard.GetState();


            foreach (Keys key in Enum.GetValues(typeof(Keys))){
                if(keyState.IsKeyDown(key))
                {
                    if (pressed.Contains(key))
                    {
                        held.Add(key);
                    }

                    if (!pressed.Contains(key))
                    {
                        pressed.Add(key);
                    }
                    
                }
                else
                {
                    if (held.Contains(key))
                    {
                        held.Remove(key);
                        
                    }
                    if (pressed.Contains(key))
                    { 
                        pressed.Remove(key);
                    }
                }
            }

            return pressed;
        }

        //public int getLastPressed() { return lastKeyPressed; }

    }
}