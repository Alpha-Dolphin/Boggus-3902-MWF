using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using LOZ.Tools.Controller;
using System;

namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private IPlayer link;
        private KeyboardController controller;
        private ICommand linkCommandHandler;
        private EnvironmentCommandHandler environmentCommandHandler;

        public static Texture2D LINK_SPRITESHEET;
        public static Texture2D ENVIRONMENT_SPRITESHEET;
        public static Texture2D REGULAR_ENEMIES;
        public static Texture2D BOSSES;
        public static Texture2D NPC_SPRITESHEET;

        /* hanging onto to save time later
       private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";
        */


        /*Lists for various things to cycle through for sprint 2*/

        List<IEnvironment> environmentObjectList = new List<IEnvironment>();

        /*Factories for mass object generation*/

        EnvironmentFactory environmentFactory = new EnvironmentFactory();


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

            link = new Link(LinkConstants.DEFAULT_X, LinkConstants.DEFAULT_Y, LinkConstants.DEFAULT_ITEMS, LinkConstants.MAX_HEALTH, 
                LinkConstants.DEFAULT_STATE, LinkConstants.DEFAULT_DIRECTION, Game1.LINK_SPRITESHEET, FONT);
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

            LINK_SPRITESHEET = Content.Load<Texture2D>(Link_Constants.LINK_SPRITESHEET_NAME);
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
            NPC_SPRITESHEET = Content.Load<Texture2D>(Constants.NPCSpriteSheetLocation);
            REGULAR_ENEMIES = Content.Load<Texture2D>(Constants.RegEnemySpriteSheetLocation);

            foreach (IEnvironment environmentObject in environmentObjectList)
            {
                environmentObject.load();
                environmentObject.update();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            
            /*
             * Update logic here
             */

            base.Update(gameTime);

            List<Keys> pressed = controller.update();

            linkCommandHandler.Execute(pressed);

            itemFactory.Update(pressed, gameTime);

            NPCFactory.Update(pressed, gameTime);

            /*Here we update the environment placement for existing environment objects*/
            environmentCommandHandler.executeNewPressedOnly(pressed, controller.held);
        }

        protected override void Draw(GameTime gameTime)
        {
            /*Clean display*/
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Initialize sprite drawing*/
            spriteBatch.Begin();

            /*Draw Environment*/
            environmentObjectList[environmentCommandHandler.environmentBlockIndex].draw(spriteBatch);

            /*Draw items*/
            itemFactory.CreateItem();
            itemFactory.Draw(spriteBatch);

            /*Draw NPCs*/
            NPCFactory.CreateNPC();
            NPCFactory.Draw(spriteBatch);

            /*Draw PC*/
            link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}