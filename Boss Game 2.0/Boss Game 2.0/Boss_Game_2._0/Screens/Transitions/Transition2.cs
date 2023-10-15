using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Transitions
{
    class Transition2 : Transition // wave transition thing (left to right)
    {

        public Transition2(SpriteBatch spriteBatch, int speed, Screen prevScreen) : base(spriteBatch, speed, prevScreen)
        {

        }

        public override void Draw()
        {
            int moved = (int)(speed * (float)timer.TotalSeconds);

            if (moved <= 1200)
            {
                prevScreen.Draw();
            }

            if (isRunning) {
                for (int i = 0; i < 8; i++)
                {
                    // Andrew's shapes magic
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100, -i * 100 - 800 + moved, 100, 800), Color.Black);
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100, 800 + i * 100 - moved, 100, 800), Color.Black);
                }

            }
            if (moved >= 2400)
            {
                Stop();
            }
        }
    }
}
