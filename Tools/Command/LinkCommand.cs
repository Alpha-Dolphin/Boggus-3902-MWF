using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework.Input;
using static LOZ.Tools.PlayerObjects.LinkConstants;

namespace LOZ.Tools.Command
{
    internal class LinkCommand : ICommand
    {
        private Link link;
        bool attacked = false;
        bool moved = false;

        public LinkCommand(Link link)
        {
            this.link = link;
        }

        public void Execute(List<Keys> keys)
        {
            moved = false;
            attacked = false;

            if (keys.Count == 0)
            {
                link.UpdateState(Link_States.Normal, link.GetDirection());
            }

            foreach (Keys key in keys)
            {
                if (LinkConstants.MOVEMENT_KEYS.Contains(key))
                {
                    switch (key)
                    {
                        case LinkConstants.MOVE_UP_KEY: ExecuteMove(LinkConstants.Direction.Up); break;
                        case LinkConstants.MOVE_UPARROW_KEY: ExecuteMove(LinkConstants.Direction.Up); break;
                        case LinkConstants.MOVE_LEFT_KEY: ExecuteMove(LinkConstants.Direction.Left); break;
                        case LinkConstants.MOVE_LEFTARROW_KEY: ExecuteMove(LinkConstants.Direction.Left); break;
                        case LinkConstants.MOVE_RIGHT_KEY: ExecuteMove(LinkConstants.Direction.Right); break;
                        case LinkConstants.MOVE_RIGHTARROW_KEY: ExecuteMove(LinkConstants.Direction.Right); break;
                        case LinkConstants.MOVE_DOWN_KEY: ExecuteMove(LinkConstants.Direction.Down); break;
                        case LinkConstants.MOVE_DOWNARROW_KEY: ExecuteMove(LinkConstants.Direction.Down); break;
                    }
                }
                else if (LinkConstants.SWORD_ATTACK_KEYS.Contains(key))
                {
                    ExecuteAttack();
                }
                else if (LinkConstants.ITEM_KEYS.Contains(key))
                {
                    int input = 0;

                    switch (key)
                    {
                        case LinkConstants.ITEM_1: input = 1; break;
                        case LinkConstants.ITEM_PAD1: input = 1; break;
                        case LinkConstants.ITEM_2: input = 2; break;
                        case LinkConstants.ITEM_PAD2: input = 2; break;
                        case LinkConstants.ITEM_3: input = 3; break;
                        case LinkConstants.ITEM_PAD3: input = 3; break;
                        case LinkConstants.ITEM_4: input = 4; break;
                        case LinkConstants.ITEM_PAD4: input = 4; break;
                        case LinkConstants.ITEM_5: input = 5; break;
                        case LinkConstants.ITEM_PAD5: input = 5; break;
                        case LinkConstants.ITEM_6: input = 6; break;
                        case LinkConstants.ITEM_PAD6: input = 6; break;
                        case LinkConstants.ITEM_7: input = 7; break;
                        case LinkConstants.ITEM_PAD7: input = 7; break;
                        case LinkConstants.ITEM_8: input = 8; break;
                        case LinkConstants.ITEM_PAD8: input = 8; break;
                        case LinkConstants.ITEM_9: input = 9; break;
                        case LinkConstants.ITEM_PAD9: input = 9; break;
                        case LinkConstants.ITEM_0: input = 0; break;
                        case LinkConstants.ITEM_PAD0: input = 0; break;
                    }
                    ExecuteChangeItem(input);
                }
                else if (LinkConstants.DAMAGE_KEYS.Contains(key))
                {
                    ExecuteDamage();
                }
            }

            link.UpdateVisual();
        }

        private void ExecuteMove(LinkConstants.Direction direction)
        {
            if (!moved)
            {
                link.UpdateState(Link_States.Walking, direction);
                link.Move(direction);
                moved = true;
            }
        }

        private void ExecuteAttack()
        {
            if (!attacked)
            {
                link.UpdateState(Link_States.Attacking, link.GetDirection());
                link.Attack();
                attacked = true;
            }
        }

        private void ExecuteChangeItem(int input)
        {
            link.UpdateState(Link_States.UseItem, link.GetDirection());
            link.UseItem(input);
        }

        private void ExecuteDamage()
        {
            link.UpdateState(Link_States.Damaged, link.GetDirection());
            link.Damage();
        }
    }
}
