using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Boss_Game_2._0.Screens.Bosses.Attacks
{
    class ChaseCircles : BossAttack
    {

        float angSpeed; // radians per second
        float totalAngDisp;
        float angSpacing;
        int centerX; // going to be set anyway
        int centerY; // going to be set anyway
        float xAccel; // Would make sense for both these to be called xVel and yVel
        float yAccel; //     unless the bullets in the spiral accelerate.
        int projectileSize;
        int spawnIntervalMs;


        Random rng;

        public ChaseCircles(SpriteBatch spriteBatch, int centerX, int centerY, float angSpacing, float angSpeed, int projectileSpeed, float xAccel, float yAccel, int projectileSize, int attackTime, int spawnIntervalMs) : base(spriteBatch, projectileSpeed)
        {

            this.angSpeed = angSpeed;
            this.angSpacing = angSpacing;
            totalAngDisp = 0;
            this.centerX = 0; 
            this.centerY = -500; // shittiest hard fix ever
            this.xAccel = xAccel;
            this.yAccel = yAccel;
            this.projectileSize = projectileSize;
            this.attackTime = attackTime;
            this.spawnIntervalMs = spawnIntervalMs;



            rng = new Random();
        }

        public override void Update(GameTime gameTime)
        {
            float angMoved = Math.Abs((float)timer.TotalSeconds * angSpeed);


            if (timer.Milliseconds % spawnIntervalMs == 0)
            {
                
                if (isAttacking)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        totalAngDisp += angMoved;
                        projectiles.Add(new Projectile(spriteBatch, TextureManager.Textures.SolidFill, centerX, centerY, projectileSpeed * (float)Math.Cos(totalAngDisp), projectileSpeed * (float)Math.Sin(totalAngDisp), xAccel, yAccel, projectileSize));
                    }

                }

                // GET PLAYER POSITION SOMEHOW!
                centerX = 50;
                centerY = 50;

                timer = TimeSpan.Zero;

            }

            base.Update(gameTime);
        }

        public override void Draw()
        {
            
            if (isAttacking)
                spriteBatch.Draw(TextureManager.Textures.AttackCircle, new Rectangle(centerX, centerY, 15, 15), Color.Red);


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
