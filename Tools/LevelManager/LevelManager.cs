using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.LevelManager
{
    internal class LevelManager
    {
        /*Location data for level files*/
        public String levelFileLocation { get; set; }


        /*Function to initialize level data structure and fill it in*/
        public void initialize()
        {
            /*Check for proper file location*/
            if (levelFileLocation == null) 
            {
                throw new InvalidOperationException("Level failed to load: Level file location NULL");
            }


            

        
        }

    }
}
