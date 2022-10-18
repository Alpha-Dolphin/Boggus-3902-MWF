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
using LOZ.Tools.Interfaces;


namespace LOZ
{
    public class Game1 : Game
    {
        private IEnemy[] enemyList;
        private IEnvironment[] staticBlocks;
        private IEnvironment[] dynamicBlocks;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private ItemFactory itemFactory;
        private NPCFactory NPCFactory;
        private EnemySpriteFactory enemySpriteFactory;
        private IPlayer link;
        private KeyboardController controller;
        private ICommand linkCommandHandler;
        private EnvironmentCommandHandler environmentCommandHandler;

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
        IEnemy enemy;



        /*Lists for various things to cycle through for sprint 2*/

        List<IEnvironment> environmentObjectList = new List<IEnvironment>();

        /*Factories for mass object generation*/

        EnvironmentFactory environmentFactory = new EnvironmentFactory();

        List<IItem> itemObjectList = new List<IItem>();


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

            LinkConstants.Initialize();

            link = new Link(LinkConstants.DEFAULT_X, LinkConstants.DEFAULT_Y, LinkConstants.DEFAULT_ITEMS, LinkConstants.MAX_HEALTH,
                LinkConstants.DEFAULT_STATE, LinkConstants.DEFAULT_DIRECTION,FONT);
            linkCommandHandler = new LinkCommand((Link) link); 

            /*Declaration of controllers*/
            controller = new KeyboardController();

            /*Here we will fill in the environment object list with one of every completed environment object*/
            foreach (Environment environment in Enum.GetValues(typeof(Environment)))
            {
            environmentObjectList.Add(environmentFactory.getEnvironment(environment));
            }
            

            /*Here we create the command handler for the environment display management*/

            environmentCommandHandler = new EnvironmentCommandHandler();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D ItemSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\Items");
            Texture2D NPCSpriteSheet = Content.Load<Texture2D>(@"SpriteSheets\NPCs");
            itemFactory = new ItemFactory(ItemSpriteSheet);
            NPCFactory = new NPCFactory(0, NPCSpriteSheet);
            enemySpriteFactory = new();
            itemObjectList.Add(itemFactory.CreateItem(Item.Compass, 600, 400));
            NPCFactory.CreateNPC();
            enemy = enemySpriteFactory.CreateKeese();

            LINK_SPRITESHEET = Content.Load<Texture2D>(LinkConstants.LINK_SPRITESHEET_NAME);
            FONT = Content.Load<SpriteFont>(@"textFonts\MainText");
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);
            BOSSES = Content.Load<Texture2D>(Constants.BossesSpriteSheetLocation);
            ITEM_SPRITESHEET = Content.Load<Texture2D>(Constants.ItemSpriteSheetLocation);

            foreach (IEnvironment environmentObject in environmentObjectList)
            {
                environmentObject.load();
                environmentObject.update();
            }
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

            if (enemySpriteFactory.Update(pressed, controller.held)) enemy = enemySpriteFactory.NewEnemy();
            else
            {
                enemy.Update(gameTime);
                enemy.Move(gameTime);
            }
            NPCFactory.Update(pressed, controller.held, gameTime);

            /*Here we update the environment placement for existing environment objects*/
            environmentCommandHandler.executeNewPressedOnly(pressed, controller.held);
        }

        private void UpdateCollision()
        {
            foreach (IEnemy ene in enemyList)
            {
                //if (Collision.Intersects(link, ene.GetRectangle())) Collision.CollisionChecker(link, ene);
                foreach (IEnvironment sB in staticBlocks)
                {
                    if (Collision.Intersects(sB.GetRectangle(), ene.GetRectangle())) Collision.CollisionChecker(sB, ene);
                }
                foreach (IEnvironment dB in dynamicBlocks)
                {
                    if (Collision.Intersects(dB.GetRectangle(), ene.GetRectangle())) Collision.CollisionChecker(dB, ene);
                }
            }
            foreach (IEnvironment sB in staticBlocks)
            {
                //if (Collision.Intersects(link, sB.GetRectangle())) Collision.CollisionChecker(link, sB);
                foreach (IEnvironment dB in dynamicBlocks)
                {
                    if (Collision.Intersects(dB.GetRectangle(), sB.GetRectangle())) Collision.CollisionChecker(dB, sB);
                }
            }
            foreach (IEnvironment dB in dynamicBlocks)
            {
                //if (Collision.Intersects(link, dB.GetRectangle())) Collision.CollisionChecker(link, dB);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin();

            /*Draw Environment*/
            environmentObjectList[environmentCommandHandler.environmentBlockIndex].draw(spriteBatch);
            
            enemy.Draw(spriteBatch);
            
            /*Draw items*/
            itemFactory.CreateItem(Item.Clock, 600, 400);
            foreach(IItem i in itemObjectList)
            {
                i.Draw(spriteBatch);
            }
            
            /*Draw NPCs*/
            NPCFactory.CreateNPC();
            NPCFactory.Draw(spriteBatch);

            //spritesToDraw.Clear();
            /*Sprites to draw need to be in order in spritesToDrawList by here*/
            //foreach (var item in spritesToDraw)
            //{
            //    item.Draw(spriteBatch);
            //}

            environmentObjectList[environmentCommandHandler.environmentBlockIndex].draw(spriteBatch);

            link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}