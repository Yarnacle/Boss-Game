using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Transitions
{
    class Transition3 : Transition // Vertical bars transition
    {
        public Transition3(SpriteBatch spriteBatch, int speed, Screen prevScreen) : base(spriteBatch, speed, prevScreen)
        {

        }

        public override void Draw()
        {
            int moved = (int)(speed * (float)timer.TotalSeconds);

            if (moved <= 1600)
            {
                prevScreen.Draw();
            }

            if (isRunning)
            {
                for (int i = 0; i < 8; i++)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(i * 100, -1600 - i * 100 + moved, 100,1600), Color.Black);
                }
            }

            if (moved >= 3200) // If enough time has elapsed that none of the rectangles should be visible, stop the timer
            {
                Stop();
            }
        }
    }
}
