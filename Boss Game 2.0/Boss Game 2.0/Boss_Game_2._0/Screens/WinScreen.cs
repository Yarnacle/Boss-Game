using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Boss_Game_2._0.Screens
{
    class WinScreen : Screen
    {
        Rectangle screenRect;
        String text;
        SpriteFont font;
        Vector2 position;

        public WinScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            screenRect = new Rectangle(0, 0, 800, 800);
            text = "Press Z to continue";
            font = TextureManager.Message.Font;
            position = new Vector2(5, 775);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Winner.win, screenRect, Color.White);
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
