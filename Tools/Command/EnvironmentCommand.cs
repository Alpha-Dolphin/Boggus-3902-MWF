using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace LOZ.Tools.Command
{
    public class EnvironmentCommandHandler : ICommand
    {
        public int environmentBlockIndex = 0;
        int numOfEnvironmentTypes = Constants.numEnviroObjectsAvailable;

        void ICommand.Execute(List<Keys> currentlyPressedKeys)
        {
            
            /*General execution on any key down*/
            
        }
        /*Execution on only keys that are not held from last update*/
        public void executeNewPressedOnly(List<Keys> currentlyPressedKeys, List<Keys> heldKeys)
        {
            var x = environmentBlockIndex;
            if (currentlyPressedKeys.Contains(Keys.Y) && !heldKeys.Contains(Keys.Y)) /*Increment with rollover*/
            {
                environmentBlockIndex = (environmentBlockIndex + 1) % numOfEnvironmentTypes;
            }
            if (currentlyPressedKeys.Contains(Keys.T) && !heldKeys.Contains(Keys.T)) /*Decrement with rollover*/
            {
                environmentBlockIndex = (numOfEnvironmentTypes+(environmentBlockIndex - 1)) % numOfEnvironmentTypes;
            }

        }
    }
}