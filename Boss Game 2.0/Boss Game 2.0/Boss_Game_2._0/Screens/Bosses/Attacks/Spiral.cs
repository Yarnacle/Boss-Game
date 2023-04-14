using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class Spiral : BossAttack
    {
        float angSpeed; // radians per second
        float totalAngDisp;
        float angSpacing;
        int centerX;
        int centerY;
        float xAccel;
        float yAccel;
        int projectileSize;

        public Spiral(SpriteBatch spriteBatch, int centerX, int centerY, float angSpacing, float angSpeed, int projectileSpeed, float xAccel, float yAccel, int projectileSize) : base(spriteBatch, projectileSpeed)
        {
            this.angSpeed = angSpeed;
            this.angSpacing = angSpacing;
            totalAngDisp = 0;
            this.centerX = centerX;
            this.centerY = centerY;
            this.xAccel = xAccel;
            this.yAccel = yAccel;
            this.projectileSize = projectileSize;
        }

        public override void Update(GameTime gameTime)
        {
            float angMoved = Math.Abs((float)timer.TotalSeconds * angSpeed);
            totalAngDisp += angMoved;
            
            if (angMoved >= angSpacing)
            {
                if (isAttacking)
                {
                    projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, centerX, centerY, projectileSpeed * (float)Math.Cos(totalAngDisp), projectileSpeed * (float)Math.Sin(totalAngDisp), xAccel, yAccel, projectileSize));
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
    }
}
