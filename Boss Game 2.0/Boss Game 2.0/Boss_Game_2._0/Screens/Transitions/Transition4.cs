using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

// WORK IN PROGRESS. END RESULT WILL LOOK SICK BUT DO NOT HAVE ENOUGH TIME TO COMPLETE THIS RIGHT NOW

namespace Boss_Game_2._0.Screens.Transitions
{
    class Transition4 : Transition
    {
        public Transition4(SpriteBatch spriteBatch, int speed, Screen prevScreen) : base(spriteBatch, speed, prevScreen)
        {

        }

        public override void Draw()
        {
            int moved = (int) (speed * (float)timer.TotalSeconds);

            if (moved <= 1000)
            {
                prevScreen.Draw();
            }

            if (isRunning)
            {
                // Top half

                // Left half
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100, -1200 + i * 100 + moved, 100, 1200 - i * 200), Color.Black);
                }

                // Right half
                for (int i = 3; i >= 0; i--)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100 + 400, -1200 + (3 - i) * 100 + moved, 100, 1200 - (3 - i) * 200), Color.Black);
                }


                // ========================= Bottom half ===============================

                // Left half
                for (int i = 0; i < 4; i++)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100, 800 + i * 100 - moved, 100, 1200 - i * 200), Color.Black);
                }

                // Right half
                for (int i = 3; i >= 0; i--)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100 + 400, 800 + (3 - i) * 100 - moved, 100, 1200 - (3 - i) * 200), Color.Black);
                }
            }

            if (moved >= 2000) // If enough time has elapsed that none of the rectangles should be visible, stop the timer
            {
                Stop();
            }
        }
    }
}
