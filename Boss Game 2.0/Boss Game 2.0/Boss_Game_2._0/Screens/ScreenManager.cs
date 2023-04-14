using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Boss_Game_2._0.Screens.Transitions;
using Boss_Game_2._0.Screens.Bosses;
using System.Dynamic;

namespace Boss_Game_2._0.Screens
{
    static class ScreenManager // 🐐
    {
        static SpriteBatch spriteBatch;

        public static MainMenu MainMenu;
        public static Shop Shop;
        public static Quit Quit;
        public static BossMenu BossMenu;
        public static dynamic Bosses;

        public static Screen currentScreen;
        public static Screen prevScreen;
        static Transition transition;

        public static void Initialize(SpriteBatch spriteBatch,Game1 game1)
        {
            ScreenManager.spriteBatch = spriteBatch;

            MainMenu = new MainMenu(spriteBatch);
            Shop = new Shop(spriteBatch);
            Quit = new Quit(spriteBatch, game1);

            BossMenu = new BossMenu(spriteBatch);
            Bosses = new ExpandoObject();
            Bosses.Boss1 = new Boss1Screen(spriteBatch);
        }
        public static void SetScreen(Screen screen)
        {
            prevScreen = currentScreen;
            currentScreen = screen;
            if (prevScreen != null) // If the game has not freshly been booted
            {
                if (currentScreen.GetType().IsSubclassOf(typeof(BossScreen)))
                {
                    transition = new Transition2(spriteBatch, 4000, prevScreen);
                }
                else {
                    transition = new Transition3(spriteBatch, 5000, prevScreen); // 5000 default speed
                }
            }
        }
        
        public static void Update(GameTime gameTime)
        {
            if (transition == null) // if no transition at the moment, allow updates (like keyboard input)
            {
                currentScreen.Update(gameTime);
            }
            else if (!transition.isRunning && !transition.stopped) // if transition exists but nothing has happened yet, start transition, then reset previous screen
            {
                transition.Start();
            }
            else // if a transition is running, keep updating it
            {
                transition.Update(gameTime);

                if (transition.stopped) // if transition stops, get rid of it
                {
                    transition = null;
                    prevScreen.Reset();
                }
            }
        }

        public static void Draw()
        {
            currentScreen.Draw();

            if (transition != null) // if a transition exists, draw it
            {
                transition.Draw();
            }
        }
    }
}
