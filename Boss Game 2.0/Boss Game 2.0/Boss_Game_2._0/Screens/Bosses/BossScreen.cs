using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class BossScreen : Screen
    {
        public BossAttack bossAttack; // TODO: store boss object instead of parts of the boss
        public bool isPaused;
        public TimeSpan timer;
        public bool playerTurn;

        public BossScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            isPaused = false;
            timer = new TimeSpan(0, 0, 0);
            playerTurn = false;
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();

            if (Game1.IsKeyPressed(Keys.Escape))
            {
                isPaused = !isPaused;
            }


            if (!isPaused)
            {
                bossAttack.Update(gameTime);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            if (isPaused)
            {
                spriteBatch.Draw(TextureManager.Bosses.PauseOverlay, Window, Color.White);
                return;
            }
            
            bossAttack.Draw();
            spriteBatch.Draw(TextureManager.Bosses.Boss1.Boss, new Rectangle(325, 150, 150, 150), Color.White); // TODO: make a boss class that will have its own .Draw() method with this code
        }
    }
}
