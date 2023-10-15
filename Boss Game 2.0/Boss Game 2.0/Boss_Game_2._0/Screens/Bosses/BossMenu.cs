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
        string[] titles;


        public BossMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            bosses = new BossScreen[0];
            titles = new string[3];
            selection = 0;

            titles[0] = "  Tutorial Boss:\n Friendly Slime!\n  5 XP";
            titles[1] = "  Beginner Boss:\n   Evil Seal!\n 15 XP";
            titles[2] = "Intermediate Boss:\nMagma Salamander!\n 25 XP";
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            bosses = new BossScreen[] { new Boss1Screen(spriteBatch), new Boss2Screen(spriteBatch), new Boss3Screen(spriteBatch) };

            


            if (Game1.IsKeyPressed(Keys.Left))
            {
                selection = Math.Max(0, selection - 1);
            }
            else if (Game1.IsKeyPressed(Keys.Right))
            {
                selection = Math.Min(2, selection + 1);
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
            switch(selection)
            {
                case 0:
                    spriteBatch.Draw(TextureManager.Textures.Placeholder, new Rectangle(248, 111, 320, 320), Color.White); // TODO: thumbnail for each boss
                    break;
                case 1:
                    spriteBatch.Draw(TextureManager.Textures.Placeholder2, new Rectangle(248, 111, 320, 320), Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(TextureManager.Textures.Placeholder3, new Rectangle(248, 111, 320, 320), Color.White);
                    break;

            }

            spriteBatch.Draw(TextureManager.BossMenu.Menu, Window, Color.White);
            spriteBatch.Draw(TextureManager.Textures.TextBox, new Rectangle(100, 475, 600, 200), Color.White);

            spriteBatch.DrawString(TextureManager.Message.SlightlyBiggerFont, titles[selection], new Vector2(230, 500), Color.White);

            if (selection > 0)
            {
                spriteBatch.Draw(TextureManager.Textures.LeftArrow, new Rectangle(100, 220, 86, 86), Color.LightGray);
            }
            if (selection < bosses.Length - 1)
            {
                spriteBatch.Draw(TextureManager.Textures.RightArrow, new Rectangle(620, 220, 86, 86), Color.LightGray);
            }
        }
    }
}
