using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class TopBottom : BossAttack
    {
        //float angSpeed; // radians per second (We Don't Actually Need This)
        //float totalAngDisp; // We Don't Need This Lol
        //float angSpacing; // We Don't Need This Lol
        int xPos;
        int yPos;
        float xAccel;
        float yAccel;
        int projectileSize;
        int spawnIntervalMs;

        Random rng;

        public TopBottom(SpriteBatch spriteBatch, int xPos, int yPos, float angSpacing, float angSpeed, int projectileSpeed, float xAccel, float yAccel, int projectileSize, int attackTime, int spawnIntervalMs) : base(spriteBatch, projectileSpeed)
        {
            this.xPos = xPos; 
            this.yPos = yPos; 
            this.xAccel = xAccel;
            this.yAccel = yAccel;
            this.projectileSize = projectileSize;
            this.attackTime = attackTime;
            this.spawnIntervalMs = spawnIntervalMs;

            rng = new Random();
        }

        public override void Update(GameTime gameTime)
        {

            if (timer.Milliseconds % spawnIntervalMs == 0) // just leaving this for now because the timer is kind of nice
            {
                if (isAttacking)
                {
                    projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, returnWithinBoundary(), -projectileSize , 0, projectileSpeed, xAccel, yAccel, projectileSize)); 
                    projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, returnWithinBoundary(), 800, 0, -projectileSpeed, xAccel, yAccel, projectileSize));
                    projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, -projectileSize, returnWithinBoundary(), projectileSpeed, 0, xAccel, yAccel, projectileSize));
                    projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, 800, returnWithinBoundary(), -projectileSpeed, 0, xAccel, yAccel, projectileSize));
                }
                timer = TimeSpan.Zero;
            }

            base.Update(gameTime);
        }

        public override void Draw()
        {
            // stuff

            base.Draw();
        }

        public int returnWithinBoundary() // Returns a random multiple of 10
        {
            int rand = projectileSize; // multiples of projectile size
            int mult = rng.Next(0, 53); // 0 - 52
            return rand * mult;
        }

    }
}
