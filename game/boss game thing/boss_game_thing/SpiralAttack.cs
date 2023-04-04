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
    class SpiralAttack
    {
        List<Bullet> projectiles; // List containing all the current on screen projectiles
        Texture2D bulletTexture; // the texture of the projectile

        Color projColor; // the color of the projectile (constant)
        Vector2 spawnPos; // where i want the things to spawn
        int velocity; // how fast i want stuff to go

        int projSize;

        float theta;
        float angleIncrement;

        int x;
        int y;


        public SpiralAttack(Texture2D bulletTexture, Vector2 spawnPos, Color projColor, int projSize, int velocity)
        {
            this.bulletTexture = bulletTexture;
            this.spawnPos = spawnPos;
            this.projColor = projColor;
            this.projSize = projSize;
            this.velocity = velocity;

            theta = 0;
            angleIncrement = 197f; // tightness of the spiral (0.3f for nice spiral), 197 is awkward

            projectiles = new List<Bullet>();
        }

        public void addBullet()
        {
            float xVel = (float)(velocity * Math.Cos(theta));
            float yVel = (float)(velocity * Math.Sin(theta));

            projectiles.Add(new Bullet(x, y, xVel, yVel, projSize));
        }

        public void Update()
        {
            theta += angleIncrement;

            x = (int)(spawnPos.X + 55f * Math.Cos(theta)); // Float value is distance from the radius
            y = (int)(spawnPos.Y + 55f * Math.Sin(theta)); // ^ (55f for default)

            for (int i = 0; i < projectiles.Count; i++)
            {

                projectiles[i].Update();
            }

            offScreenCheck();
        }

        public void offScreenCheck()
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                if (projectiles[i].x > 800 + projSize || projectiles[i].x < 0 - projSize ||
                    projectiles[i].y > 800 + projSize || projectiles[i].y < 0 - projSize)
                    projectiles.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                spriteBatch.Draw(Game1.projectileTexture, projectiles[i].rectangle, projColor);
            }
        }

        public int getProjectilesCount()
        {
            return projectiles.Count;
        }

        public Rectangle getList(int x)
        {
            return projectiles[x].getRect();
        }
        
        public void remove(int i)
        {
            projectiles.RemoveAt(i);
        }

        public void clear()
        {
            projectiles.Clear();
        }
    }
}
