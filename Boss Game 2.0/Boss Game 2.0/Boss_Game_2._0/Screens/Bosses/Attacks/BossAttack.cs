using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class BossAttack
    {
        public List<Projectile> projectiles;
        public SpriteBatch spriteBatch;
        public TimeSpan timer;
        public int projectileSpeed;
        public bool isAttacking;

        public int attackTime;

        public BossAttack(SpriteBatch spriteBatch, int projectileSpeed)
        {
            timer = new TimeSpan(0, 0, 0);
            this.spriteBatch = spriteBatch;
            this.projectileSpeed = projectileSpeed;
            projectiles = new List<Projectile>();
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                Projectile projectile = projectiles[i];
                projectile.Update(gameTime);
                if (projectile.x >= 800 || projectile.y >= 800 || projectile.x + projectile.rectangle.Width <= 0 || projectile.y + projectile.rectangle.Height <= 0)
                {
                    projectiles.RemoveAt(i);
                }
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

        public void Start()
        {
            isAttacking = true;
        }

        public void Stop()
        {
            isAttacking = false;
        }

        public Rectangle getList(int x)
        {
            return projectiles[x].rectangle;
        }

        public int getProjectilesCount()
        {
            return projectiles.Count;
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
