using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class BossMenu : Screen
    {
        int selection;
        BossScreen[] bosses;

        public BossMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            bosses = new BossScreen[0];
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            bosses = new BossScreen[] { ScreenManager.Bosses.Boss1 };

            if (Game1.IsKeyPressed(Keys.Left))
            {
                selection = Math.Max(0, selection - 1);
            }
            else if (Game1.IsKeyPressed(Keys.Right))
            {
                selection = Math.Min(0, selection + 1);
            }
            else if (Game1.IsKeyPressed(Keys.Z))
            {
                ScreenManager.SetScreen(bosses[selection]); // TODO: make it so you can access screens other than options
            }
            else if (Game1.IsKeyPressed(Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.MainMenu);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.Placeholder, new Rectangle(248, 111, 320, 320), Color.White); // TODO: thumbnail for each boss
            spriteBatch.Draw(TextureManager.BossMenu.Menu, Window, Color.White);
            spriteBatch.Draw(TextureManager.Textures.TextBox, new Rectangle(100, 475, 600, 200), Color.White);

            if (selection > 0)
            {
                spriteBatch.Draw(TextureManager.Textures.LeftArrow, new Rectangle(100, 220, 86, 86), Color.LightGray);
            }
            if (selection < bosses.Length - 1)
            {
                spriteBatch.Draw(TextureManager.Textures.RightArrow, new Rectangle(692, 220, 86, 86), Color.LightGray);
            }
        }
    }
}
