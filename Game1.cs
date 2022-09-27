﻿using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.ItemObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.Tools.Controller;



namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private ItemFactory itemFactory;
        private IPlayer link;
        private IController controller;
        private ICommand linkCommandHandler;

        public static Texture2D LINK_SPRITESHEET;

        public static Texture2D REGULAR_ENEMIES;

        private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";

        /*Declaration of controllers*/
        
        /*Container for sprites to draw in order*/
        private HashSet<ISprite> spritesToDraw = new HashSet<ISprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            LoadContent();

            Link_Constants.Initialize();

            link = new Link(Link_Constants.DEFAULT_X, Link_Constants.DEFAULT_Y, Link_Constants.DEFAULT_ITEMS, Link_Constants.MAX_HEALTH, 
                Link_Constants.DEFAULT_STATE, Link_Constants.DEFAULT_DIRECTION, Game1.LINK_SPRITESHEET);
            linkCommandHandler = new LinkCommand((Link) link);

            controller = new KeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ItemSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\Items");
            itemFactory = new ItemFactory(0, ItemSpriteSheet);
            itemFactory.CreateItem();

            LINK_SPRITESHEET = Content.Load<Texture2D>(Link_Constants.LINK_SPRITESHEET_NAME);
            REGULAR_ENEMIES = Content.Load<Texture2D>(@"SpriteSheets\Dungeon Enemies");
        }

        protected override void Update(GameTime gameTime)
        {
            
            /*
             * Update logic here, the objects here will 
             * also need to add the sprites to draw to 
             * the sprites to draw list
             * or will need to draw them themselves, IN ORDER AS APPROPRIATE
             */

            base.Update(gameTime);

            List<Keys> pressed = controller.update();

            linkCommandHandler.Execute(pressed);

            itemFactory.Update(pressed);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            itemFactory.CreateItem();
            itemFactory.Draw(spriteBatch);


            spritesToDraw.Clear();
            /*Sprites to draw need to be in order in spritesToDrawList by here*/
            //foreach (var item in spritesToDraw)
            //{
            //    item.Draw(spriteBatch);
            //}

            //spritesToDraw.Clear();
            link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}