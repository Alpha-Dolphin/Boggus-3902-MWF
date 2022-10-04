using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.Controller
{
    internal interface IController
    {
        List<Keys> update();
    }
}
