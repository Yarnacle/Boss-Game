using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Dead : Screen
    {


        public Dead(SpriteBatch spriteBatch) : base(spriteBatch)
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
            spriteBatch.Draw(TextureManager.Loser.LoseBG, Window, Color.White);
        }
    }
}
