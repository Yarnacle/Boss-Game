using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Win : Screen
    {


        public Win(SpriteBatch spriteBatch) : base(spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();

            if (Game1.IsKeyPressed(Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.BossMenu);
            }

        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.IntroBG, Window, Color.White);
            spriteBatch.Draw(TextureManager.MainMenu.PlayerModel, new Rectangle(650, 550, 186, 300), Color.White);
            spriteBatch.Draw(TextureManager.Winner.WinBG, Window, Color.White);
        }
    }
}
