using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens
{
    static class ScreenManager // 🐐
    {
        static SpriteBatch spriteBatch;

        public static MainMenu MainMenu;
        public static OptionsMenu OptionsMenu;

        public static Screen currentScreen;
        static Transition transition;

        public static void Initialize(SpriteBatch spriteBatch)
        {
            ScreenManager.spriteBatch = spriteBatch;
            MainMenu = new MainMenu(spriteBatch);
            OptionsMenu = new OptionsMenu(spriteBatch);
        }
        public static void SetScreen(Screen screen)
        {
            if (currentScreen != null)
            {
                transition = new Transition(spriteBatch, 5000, currentScreen);
            }
            currentScreen = screen;
        }
        
        public static void Update(GameTime gameTime)
        {
            if (transition == null) // if no transition at the moment, allow updates (like keyboard input)
            {
                currentScreen.Update(gameTime);
            }
            else if (!transition.isRunning && !transition.stopped) // if transition exists but nothing has happened yet, start transition
            {
                transition.Start();
            }
            else // if a transition is running, keep updating it
            {
                transition.Update(gameTime);

                if (transition.stopped) // if transition stops, get rid of it
                {
                    transition = null;
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
