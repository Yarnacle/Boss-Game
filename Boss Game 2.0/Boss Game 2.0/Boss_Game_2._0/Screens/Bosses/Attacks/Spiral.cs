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
        float xAccel; // Would make sense for both these to be called xVel and yVel
        float yAccel; //     unless the bullets in the spiral accelerate.
        int projectileSize;
        int numSpirals;

        public Spiral(SpriteBatch spriteBatch, int centerX, int centerY, float angSpacing, float angSpeed, int projectileSpeed, float xAccel, float yAccel, int projectileSize, int attackTime, int numSpirals) : base(spriteBatch, projectileSpeed)
        {
            this.angSpeed = angSpeed;
            this.angSpacing = angSpacing;
            totalAngDisp = 0;
            this.centerX = centerX;
            this.centerY = centerY;
            this.xAccel = xAccel;
            this.yAccel = yAccel;
            this.projectileSize = projectileSize;
            this.attackTime = attackTime;
            this.numSpirals = numSpirals;
        }

        public override void Update(GameTime gameTime)
        {
            float angMoved = Math.Abs((float)timer.TotalSeconds * angSpeed);
            totalAngDisp += angMoved;

            
            if (angMoved >= angSpacing)
            {
                if (isAttacking)
                {
                    for(int i = 0; i < numSpirals; i++)
                    {
                        projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, centerX, centerY, projectileSpeed * ((float)Math.Cos(totalAngDisp + (2*Math.PI/numSpirals*i))), projectileSpeed * ((float)Math.Sin(totalAngDisp + (2 * Math.PI / numSpirals * i))), xAccel, yAccel, projectileSize));
                    }
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
