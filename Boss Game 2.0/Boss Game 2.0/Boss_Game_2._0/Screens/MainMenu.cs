using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens
{
    class MainMenu : Screen
    {
        int selection; // currently selected screen & used to calculate arrow position

        TimeSpan timer;
        bool showSelectionUnderline;

        //static string[] options = new string[]{ScreenManager.SelectLevel, ScreenManager.Options, ScreenManager.Quit};

        public MainMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            timer = new TimeSpan(0, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            
            // Countdown until switch toggle selection underline visibility
            timer += gameTime.ElapsedGameTime;
            if (timer.Milliseconds >= 500)
            {
                showSelectionUnderline = !showSelectionUnderline;
                timer = TimeSpan.Zero;
            }

            if (Game1.IsKeyPressed(kb, Keys.Up))
            {
                selection = Math.Max(0, selection - 1);
                showSelectionUnderline = true; // If change selection, always show underline again
            }
            else if (Game1.IsKeyPressed(kb, Keys.Down))
            {
                selection = Math.Min(2, selection + 1);
                showSelectionUnderline = true;
            }
            else if (Game1.IsKeyPressed(kb, Keys.Z))
            {
                ScreenManager.SetScreen(ScreenManager.OptionsMenu); // TODO: make it so you can access screens other than options
            }

            Game1.oldKb = kb;
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.MainMenu.Menu, window, Color.White);
            spriteBatch.Draw(TextureManager.MainMenu.SelectionArrow, new Rectangle(300, 500 + selection * 93, 32, 32), Color.Yellow);

            if (showSelectionUnderline)
            {
                spriteBatch.Draw(TextureManager.MainMenu.SelectionUnderline, new Rectangle(335, 550 + selection * 93, 136, 5), Color.Yellow);
            }
        }
    }
}
