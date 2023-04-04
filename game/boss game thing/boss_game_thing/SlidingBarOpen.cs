using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boss_game_thing
{
    class SlidingBarOpen
    {
        Texture2D slidingBar;

        Rectangle[] bars;

        bool animPlaying;

        int timer;

        public SlidingBarOpen(Texture2D slidingBar)
        {
            this.slidingBar = slidingBar;

            bars = new Rectangle[8];
            animPlaying = false;

            timer = 90;
        }

        public void reset() // Spawn the bars off screen to prep for the animation
        {
            if (animPlaying == false)
            {
                timer = 90;
                for (int i = 0; i < bars.Length; i++)
                {
                    bars[i] = new Rectangle(-i * 100, i * 100, 1600, 100);
                }
            }
        }

        public void DrawBars(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bars.Length; i++)
            {
                spriteBatch.Draw(slidingBar, bars[i], Color.White);
            }
        }

        public void barAnimation()
        {
            if (timer != 0)
            {
                animPlaying = true;

                for (int i = 0; i < bars.Length; i++)
                {
                    bars[i].X -= i + 1 * 40;
                }
                timer--;
            }
            else
                animPlaying = false;
        }

        public int timerAnimation() // transition in black screen?
        {
            return timer;
        }


       



        
    }
}
