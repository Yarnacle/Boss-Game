using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boss_Game_2._0.Screens
{
    class StartScreen : Screen
    {
        int selection; // currently selected screen & used to calculate arrow position
        string text;
        SpriteFont font;
        Vector2 placement;
        TimeSpan timer;

        public StartScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {

            text = "Press ENTER to start!";
            font = TextureManager.Message.Font;
            placement = new Vector2(0, 800 - 25);
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime;

            Game1.kb = Keyboard.GetState();

            if (Game1.IsKeyPressed(Keys.Enter))
            {
                ScreenManager.SetScreen(new Screen[] { ScreenManager.Message }[selection]);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.IntroBG, Window, Color.White * 0.5f);
            spriteBatch.DrawString(font, text, placement, Color.White);
        }

    }
}
