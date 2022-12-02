using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.HUDObjects
{
    internal class Map : IEnumerable
    {
        Sprite[] sprites;
        bool top;
        bool[] roomsVisited;

        public Map(Texture2D spriteSheet, bool top)
        {
            this.top = top;

            //These will all be automatically initialised to false
            roomsVisited = new bool[HUDConstants.NUMROOMS];

            if (top) sprites = CreateMapTop(spriteSheet);
            else sprites = CreateMapFull(spriteSheet);
        }

        public void Update(int roomNumber)
        {
            if (roomNumber != 0 && roomNumber < HUDConstants.NUMROOMS + 1)
            {
                roomsVisited[roomNumber - 1] = true;
            }
        }

        private Sprite[] CreateMapTop(Texture2D HUDSpriteSheet)
        {
            Sprite[] returnVal = new Sprite[HUDConstants.MAPTOP_ROWS * HUDConstants.MAPTOP_COLUMNS];

            for (int i = 0; i < HUDConstants.MAPTOP_ROWS; i++)
            {
                for (int j = 0; j < HUDConstants.MAPTOP_COLUMNS; j++)
                {
                    Rectangle sourceRectangle = new Rectangle();
                    switch (HUDConstants.MAPTOP_INFO[i * HUDConstants.MAPTOP_COLUMNS + j])
                    {
                        case 0: sourceRectangle = HUDConstants.BLACK_PIXEL; break;
                        case 1: sourceRectangle = HUDConstants.MAP_BLUE_TOP; break;
                        case 2: sourceRectangle = HUDConstants.MAP_BLUE_BOT; break;
                        case 3: sourceRectangle = HUDConstants.MAP_BLUE_TWO; break;
                    }

                    returnVal[i * HUDConstants.MAPTOP_COLUMNS + j] = new Sprite(HUDSpriteSheet,
                        HUDConstants.MAPTOP_X + j * HUDConstants.MAP_BLUE_TOP.Width, HUDConstants.MAPTOP_Y + i * HUDConstants.MAP_BLUE_TOP.Height,
                        new List<Rectangle>() { sourceRectangle });
                }
            }

            return returnVal;
        }

        private Sprite[] CreateMapFull(Texture2D HUDSpriteSheet)
        {
            Sprite[] returnVal = new Sprite[HUDConstants.MAPFULL_ROWS * HUDConstants.MAPFULL_COLUMNS];

            for (int i = 0; i < HUDConstants.MAPFULL_ROWS; i++)
            {
                for (int j = 0; j < HUDConstants.MAPFULL_COLUMNS; j++)
                {
                    Rectangle sourceRectangle = new Rectangle();
                    switch (HUDConstants.MAPFULL_INFO[i * HUDConstants.MAPFULL_COLUMNS + j])
                    {
                        case 0: sourceRectangle = HUDConstants.MAP_PIXEL; break;
                        case 1: sourceRectangle = HUDConstants.MAP_FULL_NONE; break;
                        case 2: sourceRectangle = HUDConstants.MAP_FULL_E; break;
                        case 3: sourceRectangle = HUDConstants.MAP_FULL_W; break;
                        case 4: sourceRectangle = HUDConstants.MAP_FULL_EW; break;
                        case 5: sourceRectangle = HUDConstants.MAP_FULL_S; break;
                        case 6: sourceRectangle = HUDConstants.MAP_FULL_SE; break;
                        case 7: sourceRectangle = HUDConstants.MAP_FULL_SW; break;
                        case 8: sourceRectangle = HUDConstants.MAP_FULL_SEW; break;
                        case 9: sourceRectangle = HUDConstants.MAP_FULL_N; break;
                        case 10: sourceRectangle = HUDConstants.MAP_FULL_NE; break;
                        case 11: sourceRectangle = HUDConstants.MAP_FULL_NW; break;
                        case 12: sourceRectangle = HUDConstants.MAP_FULL_NEW; break;
                        case 13: sourceRectangle = HUDConstants.MAP_FULL_NS; break;
                        case 14: sourceRectangle = HUDConstants.MAP_FULL_NSE; break;
                        case 15: sourceRectangle = HUDConstants.MAP_FULL_NSW; break;
                        case 16: sourceRectangle = HUDConstants.MAP_FULL_NSEW; break;
                    }

                    returnVal[i * HUDConstants.MAPFULL_COLUMNS + j] = new Sprite(HUDSpriteSheet,
                        HUDConstants.MAPFULL_X + j * HUDConstants.MAP_FULL_NONE.Width, HUDConstants.MAPFULL_Y + i * HUDConstants.MAP_FULL_NONE.Height,
                        new List<Rectangle>() { sourceRectangle });
                }
            }

            return returnVal;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (top) DrawMapTop(spriteBatch);
            else DrawMapFull(spriteBatch);
        }

        private void DrawMapTop(SpriteBatch spriteBatch)
        {
            foreach(Sprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }

        private void DrawMapFull(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < HUDConstants.MAPFULL_ROWS; i++)
            {
                for(int j = 0; j < HUDConstants.MAPFULL_COLUMNS; j++)
                {
                    int roomNumber = 0;
                    if(HUDConstants.ARRAY_TO_ROOMNUMBER.TryGetValue((i, j), out roomNumber)) {
                        if (roomsVisited[roomNumber - 1])
                        {
                            sprites[i * HUDConstants.MAPFULL_ROWS + j].Draw(spriteBatch);
                        }
                    } else
                    {
                        sprites[i * HUDConstants.MAPFULL_ROWS + j].Draw(spriteBatch);
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return sprites.GetEnumerator();
        }
    }
}
