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
    class Bullet
    {
        public Rectangle rectangle;
        public float x;
        public float y;
        public float xVel;
        public float yVel;

        public Bullet(float x, float y, float xVel, float yVel, int size)
        {
            this.x = x;
            this.y = y;
            this.xVel = xVel;
            this.yVel = yVel;

            rectangle = new Rectangle((int)x, (int)y, size, size);
        }

        public void Update()
        {
            x += xVel;
            y += yVel;

            rectangle.X = (int)x;
            rectangle.Y = (int)y;
        }

        public Rectangle getRect()
        {
            return rectangle;
        }
    }
}

