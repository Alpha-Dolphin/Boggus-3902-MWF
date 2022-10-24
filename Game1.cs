using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.ItemObjects;
using LOZ.Tools.NPCObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using LOZ.Tools.Controller;

using System;


using LOZ.Tools;
using LOZ.Tools.EnvironmentObjects.Helpers;
using LOZ.Tools.LevelManager;

namespace LOZ
{
    public class Game1 : Game
    {
        private List<IEnemy> enemyList;
        private List<IEnvironment> staticBlocks;
        private List<IEnvironment> dynamicBlocks;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private IPlayer link;
        private KeyboardController controller;
        private ICommand linkCommandHandler;
        private List<Room> rooms;
        private int currentRoom = 2;

        public static Texture2D LINK_SPRITESHEET;
        public static SpriteFont FONT;
        public static Texture2D ENVIRONMENT_SPRITESHEET;
        public static Texture2D REGULAR_ENEMIES;
        public static Texture2D BOSSES;
        public static Texture2D NPC_SPRITESHEET;
        public static Texture2D ITEM_SPRITESHEET;


        /* hanging onto to save time later
       private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";
        */

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

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 704;
            _graphics.ApplyChanges();

            BackgroundConstants.Initialize(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            link = new Link(LinkConstants.DEFAULT_X, LinkConstants.DEFAULT_Y, LinkConstants.DEFAULT_ITEMS, LinkConstants.MAX_HEALTH,
                LinkConstants.DEFAULT_STATE, LinkConstants.DEFAULT_DIRECTION,FONT);
            linkCommandHandler = new LinkCommand((Link) link);

            /*Declaration of controllers*/
            controller = new KeyboardController();


            LevelManager lm = new LevelManager();
            lm.initialize();
            rooms = lm.roomList;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LINK_SPRITESHEET = Content.Load<Texture2D>(LinkConstants.LINK_SPRITESHEET_NAME);
            FONT = Content.Load<SpriteFont>(@"textFonts\MainText");
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);
            BOSSES = Content.Load<Texture2D>(Constants.BossesSpriteSheetLocation);
            ITEM_SPRITESHEET = Content.Load<Texture2D>(Constants.ItemSpriteSheetLocation);
        }

        protected override void Update(GameTime gameTime)
        {
            //UpdateCollision();

            /*
             * Update logic here
             */

            base.Update(gameTime);

            List<Keys> pressed = controller.update();

            linkCommandHandler.Execute(pressed);

        }

        private void UpdateCollision()
        {
            enemyList = rooms[currentRoom].enemyList;
            staticBlocks = rooms[currentRoom].environmentList;
            dynamicBlocks = rooms[currentRoom].environmentList;
            foreach (IEnemy ene in enemyList)
            {
                if (Collision.Intersects(link.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(ene, link);
                foreach (IEnvironment sB in staticBlocks)
                {
                    if (Collision.Intersects(sB.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(sB, ene);
                }
                foreach (IEnvironment dB in dynamicBlocks)
                {
                    if (Collision.Intersects(dB.GetHurtbox(), ene.GetHurtbox())) Collision.CollisionChecker(dB, ene);
                }
                foreach (Rectangle weapon in link.GetHitboxes()) { 
                    if (Collision.Intersects(weapon, ene.GetHurtbox())) Collision.CollisionChecker(weapon, ene);
                }
            }
            foreach (IEnvironment sB in staticBlocks)
            {
                if (Collision.Intersects(link.GetHurtbox(), sB.GetHurtbox())) 
                    Collision.CollisionChecker(link, sB);
                foreach (IEnvironment dB in dynamicBlocks)
                {
                    if (Collision.Intersects(dB.GetHurtbox(), sB.GetHurtbox())) Collision.CollisionChecker(dB, sB);
                }
            }
            foreach (IEnvironment dB in dynamicBlocks)
            {
                if (Collision.Intersects(link.GetHurtbox(), dB.GetHurtbox())) Collision.CollisionChecker(link, dB);
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            rooms[currentRoom].Draw(spriteBatch);
            link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}