using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boss_game_thing
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static SpriteFont fontOne;

        string currentText;

        Message message;
        SlidingBarOpen menuAnim;
        Menu menu;
        WorldSelectManager wsManager;
        SubMenuManager subManager;
        World1Boss world1boss;
        Loser loser;
        public static Texture2D projectileTexture;

        int timer;

        enum GameState
        {
            StartScreen, Intro, Menu, SubMenu,
            WorldSelect,
            World1, World2, World3, World4, World5,
            Loser
        }

        static GameState currState;

        public static KeyboardState oldKB;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currState = GameState.StartScreen;
            oldKB = Keyboard.GetState();

            message = new Message(fontOne, spriteBatch);
            menuAnim = new SlidingBarOpen(this.Content.Load<Texture2D>("black square"));
            menu = new Menu(this.Content.Load<Texture2D>("menu image"), this.Content.Load<Texture2D>("rightArrow"), this.Content.Load<Texture2D>("black square"));
            wsManager = new WorldSelectManager(this.Content.Load<SpriteFont>("fontOne"), this.Content.Load<Texture2D>("worldSelectBorder"), this.Content.Load<Texture2D>("lockedBorder"),
                new Rectangle(0, 0, 800, 800), this.Content.Load<Texture2D>("temp image"), this.Content.Load<Texture2D>("leftArrow"), this.Content.Load<Texture2D>("rightArrow"));
            subManager = new SubMenuManager(this.Content.Load<Texture2D>("subMenuBg"), this.Content.Load<Texture2D>("rightArrow"), this.Content.Load<SpriteFont>("fontOne"));
            world1boss = new World1Boss(this.Content.Load<Texture2D>("boss1"), this.Content.Load<Texture2D>("player"));
            loser = new Loser(this.Content.Load<Texture2D>("loser"));

            projectileTexture = this.Content.Load<Texture2D>("bullet");
            





            currentText = "";


            base.Initialize();
        }

    

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            menuAnim.reset();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fontOne = this.Content.Load<SpriteFont>("fontOne");

            message.AddMessage("You've been living in the village of Arathia for 15 years now.");


            message.AddMessage("It is the 34th Coming of Rite Ceremony and the village elder has \n chosen YOU to be the hero from your village.");


            message.AddMessage("Now, you must unsheath your blade and slay the evils that lay\n on the other side of the mountain.");


            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState kb = Keyboard.GetState();

            // TODO: Add your update logic here
            switch (currState)
            {
                case GameState.StartScreen:
                    if (kb.IsKeyDown(Keys.Enter))
                        currState++;
                    break;

                case GameState.Intro:
                    currentText = message.getCurrentText();
                    message.Update();
                    if (message.getRemainingMessages() == 0 || kb.IsKeyDown(Keys.Space))
                        currState = GameState.Menu;

                    timer = 60;

                    break;

                case GameState.Menu:
                    if (timer != 0)
                    {
                        menuAnim.barAnimation();
                        timer--;
                    }

                    if (timer == 0)
                    {
                        if (menu.chooseOption() == 0 && kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z))
                        {
                            timer = 60;
                            menu.resetStuff();
                            menuAnim.reset();
                            currState = GameState.WorldSelect;
                        }

                        if (menu.chooseOption() == 1 && kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z))
                        {
                            timer = 60;
                            menu.resetStuff();
                            currState = GameState.SubMenu;
                        }

                        if (menu.chooseOption() == 2 && kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z))
                        {
                            this.Exit();
                        }


                        menu.Update();
                    }

                    

                    break;

                case GameState.SubMenu:

                    subManager.Update();

                    if (kb.IsKeyDown(Keys.X))
                    {
                        menuAnim.reset();
                        menu.resetStuff();
                        currState = GameState.Menu;
                    }

                    break;

                case GameState.WorldSelect:
                    wsManager.Update();

                    if (kb.IsKeyDown(Keys.X))
                    {
                        menuAnim.reset();
                        menu.resetStuff();
                        currState = GameState.Menu;
                    }

                    break;

                case GameState.World1:
                    
                    break;


                case GameState.Loser:
                    loser.Update();

                    if (kb.IsKeyDown(Keys.X))
                    {
                        setState(2);
                    }
                    break;
            }

            
            oldKB = kb;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (currState)
            {
                case GameState.StartScreen:
                    spriteBatch.DrawString(fontOne, "Press ENTER to start!", new Vector2(0, GraphicsDevice.Viewport.Height - 25), Color.White);
                    break;

                case GameState.Intro:
                    spriteBatch.DrawString(fontOne, "Press Z to interact. Space to SKIP intro", new Vector2(0, GraphicsDevice.Viewport.Height - 25), Color.DarkGray);
                    spriteBatch.DrawString(fontOne, currentText, new Vector2(50, 50), Color.White);

                    break;

                case GameState.Menu:
                    menu.DrawBG(spriteBatch);
                    menuAnim.DrawBars(spriteBatch);
                    menuAnim.barAnimation();

                    if (timer == 0)
                    {
                        menu.DrawArrow(spriteBatch);
                    }
                    break;

                case GameState.SubMenu:

                    subManager.Draw(spriteBatch);


                    break;

                case GameState.WorldSelect:
                    wsManager.Draw(spriteBatch);


                    break;

                case GameState.World1:
                    world1boss.Update(spriteBatch);
                    break;

                case GameState.Loser:
                    loser.Draw(spriteBatch);
                    break;

            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        public static void setState(int state)
        {
            currState = (GameState) state;
        } 
    }
}
