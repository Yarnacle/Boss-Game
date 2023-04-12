using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class BossMenu : Screen
    {
        int selection;
        Boss[] bosses;

        public BossMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            bosses = new Boss[0];
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            bosses = new Boss[] { ScreenManager.Bosses.Boss1 };

            if (Game1.IsKeyPressed(kb, Keys.Right))
            {
                selection = Math.Max(0, selection - 1);
            }
            else if (Game1.IsKeyPressed(kb, Keys.Left))
            {
                selection = Math.Min(2, selection + 1);
            }
            else if (Game1.IsKeyPressed(kb, Keys.Z))
            {
                ScreenManager.SetScreen(bosses[selection]); // TODO: make it so you can access screens other than options
            }
            else if (Game1.IsKeyPressed(kb, Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.MainMenu);
            }

            Game1.oldKb = kb;
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
