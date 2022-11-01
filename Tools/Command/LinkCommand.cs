﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework.Input;
using static LOZ.Tools.PlayerObjects.PlayerConstants;

namespace LOZ.Tools.Command
{
    internal class LinkCommand : ICommand
    {
        private Link link;
        bool attacked = false;
        bool moved = false;
        bool bombLastFrame = false;

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
                bombLastFrame = false;
            }

            foreach (Keys key in keys)
            {
                if (PlayerConstants.MOVEMENT_KEYS.Contains(key))
                {
                    switch (key)
                    {
                        case PlayerConstants.MOVE_UP_KEY: ExecuteMove(PlayerConstants.Direction.Up); break;
                        case PlayerConstants.MOVE_UPARROW_KEY: ExecuteMove(PlayerConstants.Direction.Up); break;
                        case PlayerConstants.MOVE_LEFT_KEY: ExecuteMove(PlayerConstants.Direction.Left); break;
                        case PlayerConstants.MOVE_LEFTARROW_KEY: ExecuteMove(PlayerConstants.Direction.Left); break;
                        case PlayerConstants.MOVE_RIGHT_KEY: ExecuteMove(PlayerConstants.Direction.Right); break;
                        case PlayerConstants.MOVE_RIGHTARROW_KEY: ExecuteMove(PlayerConstants.Direction.Right); break;
                        case PlayerConstants.MOVE_DOWN_KEY: ExecuteMove(PlayerConstants.Direction.Down); break;
                        case PlayerConstants.MOVE_DOWNARROW_KEY: ExecuteMove(PlayerConstants.Direction.Down); break;
                    }
                }
                else if (PlayerConstants.SWORD_ATTACK_KEYS.Contains(key))
                {
                    ExecuteAttack();
                }
                else if (PlayerConstants.ITEM_KEYS.Contains(key))
                {
                    int input = 0;

                    switch (key)
                    {
                        case PlayerConstants.ITEM_1: input = 1; break;
                        case PlayerConstants.ITEM_PAD1: input = 1; break;
                        case PlayerConstants.ITEM_2: input = 2; break;
                        case PlayerConstants.ITEM_PAD2: input = 2; break;
                        case PlayerConstants.ITEM_3: input = 3; break;
                        case PlayerConstants.ITEM_PAD3: input = 3; break;
                        case PlayerConstants.ITEM_4: input = 4; break;
                        case PlayerConstants.ITEM_PAD4: input = 4; break;
                        case PlayerConstants.ITEM_5: input = 5; break;
                        case PlayerConstants.ITEM_PAD5: input = 5; break;
                        case PlayerConstants.ITEM_6: input = 6; break;
                        case PlayerConstants.ITEM_PAD6: input = 6; break;
                        case PlayerConstants.ITEM_7: input = 7; break;
                        case PlayerConstants.ITEM_PAD7: input = 7; break;
                        case PlayerConstants.ITEM_8: input = 8; break;
                        case PlayerConstants.ITEM_PAD8: input = 8; break;
                        case PlayerConstants.ITEM_9: input = 9; break;
                        case PlayerConstants.ITEM_PAD9: input = 9; break;
                        case PlayerConstants.ITEM_0: input = 0; break;
                        case PlayerConstants.ITEM_PAD0: input = 0; break;
                    }

                    if (!(input == 5 && bombLastFrame))
                    {
                        ExecuteChangeItem(input);
                    }
                }
                else if (PlayerConstants.DAMAGE_KEYS.Contains(key))
                {
                    ExecuteDamage();
                }
            }

            CheckBombLastFrame(keys);
            link.UpdateVisual();
        }

        private void ExecuteMove(PlayerConstants.Direction direction)
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

        public void ExecuteDamage()
        {
            link.UpdateState(Link_States.Damaged, link.GetDirection());
            link.Damage();
        }

        private void CheckBombLastFrame(List<Keys> keys)
        {
            this.bombLastFrame = (keys.Contains(PlayerConstants.ITEM_5) || keys.Contains(PlayerConstants.ITEM_PAD5)) ? true : false;
        }
    }
}
