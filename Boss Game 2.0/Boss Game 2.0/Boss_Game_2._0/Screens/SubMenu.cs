using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens
{
    class SubMenu : Screen // This class was not made by me.
    {
        int selection;

        TimeSpan timer;
        bool showSelectionUnderline;
        Color SelectionColor;
        public SubMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            timer = new TimeSpan(0, 0, 0);

            SelectionColor = Color.Yellow;
            showSelectionUnderline = true;
            this.spriteBatch = spriteBatch;
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
            else if (Game1.IsKeyPressed( Keys.Down))
            {
                selection = Math.Min(2, selection + 1);
                showSelectionUnderline = true;
            }
            else if (Game1.IsKeyPressed( Keys.Z))
            {
                SelectionColor = Color.White;
                ScreenManager.SetScreen(new Screen[] { ScreenManager.ShopMenu, ScreenManager.Inventory, ScreenManager.Quit }[selection]); //placeholder for now
            }
            else if (Game1.IsKeyPressed( Keys.X))
            {
                SelectionColor = Color.White;
                ScreenManager.SetScreen(ScreenManager.MainMenu);
            }

            Game1.UpdateOldKb();

        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.SubMenu.Menu, Window, Color.White);
            spriteBatch.Draw(TextureManager.Textures.RightArrow, new Rectangle(515, 70 + selection * 315, 32, 32), SelectionColor);

            if (showSelectionUnderline) ///fix selection Y
            {
                spriteBatch.Draw(TextureManager.MainMenu.SelectionUnderline, new Rectangle(550, 120 + selection * 315, 150, 5), SelectionColor); //underline
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
