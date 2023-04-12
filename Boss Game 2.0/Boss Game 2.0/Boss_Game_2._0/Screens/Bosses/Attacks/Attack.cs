using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class Attack
    {
        public List<Projectile> projectiles;
        public SpriteBatch spriteBatch;
        public TimeSpan timer;
        public int projectileSpeed;

        public Attack(SpriteBatch spriteBatch, int projectileSpeed)
        {
            timer = new TimeSpan(0, 0, 0);
            this.spriteBatch = spriteBatch;
            this.projectileSpeed = projectileSpeed;
            projectiles = new List<Projectile>();
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gameTime);
            }

            timer += gameTime.ElapsedGameTime;
        }

        public virtual void Draw()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw();
            }
        }
    }
}
