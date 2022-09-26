using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework.Input;
using static LOZ.Tools.PlayerObjects.Link_Constants;

namespace LOZ.Tools.Command
{
    internal class LinkCommand : ICommand
    {
        private Link link;
        public LinkCommand(Link link)
        {
            this.link = link;
        }

        public void Execute(List<Keys> keys)
        {
            foreach(Keys key in keys)
            {
                if (Link_Constants.MOVEMENT_KEYS.Contains(key))
                {
                    switch (key)
                    {
                        case Link_Constants.MOVE_DOWN_KEY: ExecuteMove(Link_Constants.Direction.Down); break;
                        case Link_Constants.MOVE_LEFT_KEY: ExecuteMove(Link_Constants.Direction.Left); break;
                        case Link_Constants.MOVE_RIGHT_KEY: ExecuteMove(Link_Constants.Direction.Right); break;
                        case Link_Constants.MOVE_UP_KEY: ExecuteMove(Link_Constants.Direction.Up); break;
                    }
                } else if (Link_Constants.SWORD_ATTACK_KEYS.Contains(key))
                {
                    ExecuteAttack();
                } else if (Link_Constants.ITEM_KEYS.Contains(key))
                {
                    int input = 0;

                    switch (key)
                    {
                        case Link_Constants.ITEM_1: input = 1; break;
                        case Link_Constants.ITEM_PAD1: input = 1; break;
                        case Link_Constants.ITEM_2: input = 2; break;
                        case Link_Constants.ITEM_PAD2: input = 2; break;
                        case Link_Constants.ITEM_3: input = 3; break;
                        case Link_Constants.ITEM_PAD3: input = 3; break;
                        case Link_Constants.ITEM_4: input = 4; break;
                        case Link_Constants.ITEM_PAD4: input = 4; break;
                        case Link_Constants.ITEM_5: input = 5; break;
                        case Link_Constants.ITEM_PAD5: input = 5; break;
                        case Link_Constants.ITEM_6: input = 6; break;
                        case Link_Constants.ITEM_PAD6: input = 6; break;
                        case Link_Constants.ITEM_7: input = 7; break;
                        case Link_Constants.ITEM_PAD7: input = 7; break;
                        case Link_Constants.ITEM_8: input = 8; break;
                        case Link_Constants.ITEM_PAD8: input = 8; break;
                        case Link_Constants.ITEM_9: input = 9; break;
                        case Link_Constants.ITEM_PAD9: input = 9; break;
                        case Link_Constants.ITEM_0: input = 0; break;
                        case Link_Constants.ITEM_PAD0: input = 0; break;
                    }
                    ExecuteChangeItem(input);
                } else if (Link_Constants.DAMAGE_KEYS.Contains(key))
                {
                    ExecuteDamage();
                }
            }
        }

        private void ExecuteMove(Link_Constants.Direction direction)
        {
            link.Move(direction);
        }

        private void ExecuteAttack()
        {
            link.Attack();
        }

        private void ExecuteChangeItem(int input)
        {
            link.ChangeItem(input);
        }

        private void ExecuteDamage()
        {
            link.Damage();
        }
    }
}
