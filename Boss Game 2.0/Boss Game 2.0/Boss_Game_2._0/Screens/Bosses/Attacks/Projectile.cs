using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class Projectile // Basically entity
    {
        SpriteBatch spriteBatch;
        Texture2D texture;
        public Rectangle rectangle;
        public float x;
        public float y;
        float xVel; // PIXELS PER SECOND
        float yVel;
        float xAccel; // PIXELS PER SECOND SQUARED
        float yAccel;
        TimeSpan timer;

        public Projectile(SpriteBatch spriteBatch, Texture2D texture, float x, float y, float xVel, float yVel, float xAccel, float yAccel, int size)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.x = x;
            this.y = y;
            this.xVel = xVel;
            this.yVel = yVel;
            this.xAccel = xAccel;
            this.yAccel = yAccel;

            rectangle = new Rectangle((int)x, (int)y, size, size);

            timer = new TimeSpan(0, 0, 0);
        }

        public void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            x += xVel * time;
            y += yVel * time;

            xVel += xAccel * time;
            yVel += yAccel * time;

            rectangle.X = (int)x;
            rectangle.Y = (int)y;

            timer += gameTime.ElapsedGameTime;
        }

        public void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.SolidFill, rectangle, Color.White);
        }
    }
}