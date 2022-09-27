using LOZ.Tools.Command;
using LOZ.Tools.PlayerObjects;
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
        private IPlayer link;
        private KeyboardController controller;
        private ICommand linkCommandHandler;
        private EnvironmentCommandHandler environmentCommandHandler;

        public static Texture2D LINK_SPRITESHEET;
        public static Texture2D ENVIRONMENT_SPRITESHEET;
        public static Texture2D REGULAR_ENEMIES;

        private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";

        /*Declaration of controllers*/

        /*Lists for various things to cycle through for sprint 2*/

        List<IEnvironment> environmentObjectList = new List<IEnvironment>();

        /*Factories for mass object generation*/

        EnvironmentFactory environmentFactory = new EnvironmentFactory();

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

            /*Here we will fill in the environment object list with one of every completed environment object*/
            environmentObjectList.Add(environmentFactory.getEnvironment(Environment.Statues));
            environmentObjectList.Add(environmentFactory.getEnvironment(Environment.SquareBlock));

            /*Here we create the command handler for the environment display management*/

            environmentCommandHandler = new EnvironmentCommandHandler();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LINK_SPRITESHEET = Content.Load<Texture2D>(Link_Constants.LINK_SPRITESHEET_NAME);
            ENVIRONMENT_SPRITESHEET = Content.Load<Texture2D>(Constants.DungeonSpriteSheetLocation);
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
             * Update logic here, the objects here will 
             * also need to add the sprites to draw to 
             * the sprites to draw list
             * or will need to draw them themselves, IN ORDER AS APPROPRIATE
             */

            /*Here we update the environment placement for existing environment objects*/
            

            base.Update(gameTime);

            List<Keys> pressed = controller.update();

            linkCommandHandler.Execute(pressed);
            environmentCommandHandler.executeNewPressedOnly(pressed, controller.held);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            environmentObjectList[environmentCommandHandler.environmentBlockIndex].draw(spriteBatch);


            link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}