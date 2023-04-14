using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Boss1Screen : BossScreen
    {
        public Boss1Screen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            bossAttack = new Spiral(spriteBatch, 400, 400, (float)Math.PI / 15, (float)Math.PI / 2, 100, 0, 0, 15);
        }

        public override void Update(GameTime gameTime)
        {
            if (isPaused)
            {
                base.Update(gameTime);
                return;
            }

            timer += gameTime.ElapsedGameTime;

            if (playerTurn)
            {
                bossAttack.Stop();
                if (timer.TotalSeconds >= 10) // time's up!
                {
                    timer = TimeSpan.Zero;
                    playerTurn = false;
                }
            }
            else // boss turn >:)
            {
                bossAttack.Start();
                if (timer.TotalSeconds >= 15) // now my turn!
                {
                    timer = TimeSpan.Zero;
                    playerTurn = true;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.Placeholder, Window, Color.White * 0.2f);

            base.Draw();
        }
    }
}
