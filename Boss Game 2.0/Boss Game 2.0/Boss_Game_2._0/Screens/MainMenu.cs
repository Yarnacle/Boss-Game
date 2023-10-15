using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens
{
    class MainMenu : Screen
        /*
         * Everything that has to do with the title screen
         */
    {
        int selection; // currently selected screen & used to calculate arrow position

        TimeSpan timer;
        bool showSelectionUnderline;
        Color SelectionColor;

        public MainMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            timer = new TimeSpan(0, 0, 0);

            SelectionColor = Color.Yellow;
            showSelectionUnderline = true;
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            
            // Countdown until switch toggle selection underline visibility
            timer += gameTime.ElapsedGameTime;
            if (timer.Milliseconds >= 500)
            {
                showSelectionUnderline = !showSelectionUnderline;
                timer = TimeSpan.Zero;
            }

            if (Game1.IsKeyPressed(Keys.Up))
            {
                selection = Math.Max(0, selection - 1);
                showSelectionUnderline = true; // If change selection, always show underline again
            }
            else if (Game1.IsKeyPressed(Keys.Down))
            {
                selection = Math.Min(2, selection + 1);
                showSelectionUnderline = true;
            }
            else if (Game1.IsKeyPressed(Keys.Z))
            {
                SelectionColor = Color.White;
                ScreenManager.SetScreen(new Screen[] { ScreenManager.BossMenu, ScreenManager.SubMenu, ScreenManager.Quit }[selection]);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.MainMenu.Menu, Window, Color.White);
            spriteBatch.Draw(TextureManager.Textures.RightArrow, new Rectangle(300, 500 + selection * 93, 32, 32), SelectionColor);
            spriteBatch.Draw(TextureManager.MainMenu.PlayerModel, new Rectangle(650, 550, 186, 300), Color.White);

            if (showSelectionUnderline)
            {
                spriteBatch.Draw(TextureManager.MainMenu.SelectionUnderline, new Rectangle(335, 550 + selection * 93, 136, 5), SelectionColor);
            }
        }

        public override void Reset()
        {
            SelectionColor = Color.Yellow;
            showSelectionUnderline = true;
            timer = TimeSpan.Zero;
            selection = 0;
        }
    }
}
