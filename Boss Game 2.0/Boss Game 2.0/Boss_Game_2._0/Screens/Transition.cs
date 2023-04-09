using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens
{
    class Transition : Screen
    {
        TimeSpan timer;
        int speed;
        public bool isRunning;
        public bool stopped;
        Screen prevScreen;

        public Transition(SpriteBatch spriteBatch, int speed, Screen prevScreen) : base(spriteBatch)
        {
            timer = new TimeSpan(0, 0, 0);
            this.speed = speed;
            isRunning = false;
            stopped = false;
            this.prevScreen = prevScreen;
        }

        public void Start()
        {
            isRunning = true;
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime;
        }

        public override void Draw()
        {
            double moved = speed * timer.TotalMilliseconds / 1000;

            if (moved <= 1600)
            {
                prevScreen.Draw();
            }

            if (isRunning)
            {
                for (int i = 0; i < 8; i++)
                {
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle((int)(1600 - i * 100 - moved), i * 100, 1600, 100), Color.Black);
                }
            }

            if (moved >= 3200) // If enough time has elapsed that none of the rectangles should be visible, stop the timer
            {
                isRunning = false;
                stopped = true;
            }
        }
    }
}
