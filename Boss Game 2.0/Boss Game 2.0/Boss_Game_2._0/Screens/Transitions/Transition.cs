using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Transitions
{
    class Transition : Screen
        /*
         * Manages everything transition related. Used in ScreenManager
         */
    {
        public TimeSpan timer;
        public int speed; // in pixels per second; used in conjunction with seconds calculation to determine displacement
        public bool isRunning;
        public bool stopped;
        public Screen prevScreen;

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

        public void Stop()
        {
            isRunning = false;
            stopped = true;
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime;
        }
    }
}
