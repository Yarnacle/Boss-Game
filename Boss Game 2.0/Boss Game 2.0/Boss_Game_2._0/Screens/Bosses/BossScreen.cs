using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class BossScreen : Screen
    {
        public BossAttack bossAttack; // TODO: store boss object instead of parts of the boss. 
        public TimeSpan timer;
        public Player player;

        public bool isPaused;
        public bool playerTurn;
        public bool playerKilled;

        public int bossX; // these 5 pivs are all for shake stuff
        public int bossY;
        public int bossXOrigin;
        public int bossYOrigin;
        public int shakeTimer;

        private Random rng;

        public int bossHP;
        public int bossDmg;
        public int xpDrop;

        public BossScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            player = new Player(new Rectangle(800 / 2 - 10, 600, 20, 20), 20, 2, spriteBatch);
            isPaused = false;
            timer = new TimeSpan(0, 0, 0);
            playerTurn = true;
            playerKilled = false;
            rng = new Random();

            bossX = 0;
            bossY = 0;

            bossXOrigin = 0;
            bossYOrigin = 0;

            shakeTimer = 90;
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            KeyboardState kb = Keyboard.GetState();


            if (Game1.IsKeyPressed(Keys.Escape))
            {
                isPaused = !isPaused;
            }

            if (Game1.IsKeyPressed(Keys.P) && Game1.oldKb.IsKeyUp(Keys.P))
            {
                player.ToggleGod();
            }


            if (!isPaused)
            {
                bossAttack.Update(gameTime);


                if (playerKilled)
                {
                    bossAttack.Stop();
                }
            }

            for (int i = bossAttack.getProjectilesCount() - 1; i >= 0; i--)
            {
                if (player.ReturnRect().Intersects(bossAttack.getList(i)) && player.iFrames == false)
                {
                    player.ChangePlayerHP(bossDmg); // change this to boss damage
                    bossAttack.remove(i);
                    if (player.GetHp() <= 0)
                    {
                        playerKilled = true;
                        bossAttack.Stop();
                        player.Despawn();
                        ScreenManager.SetScreen(ScreenManager.Dead);
                    }
                }
            }

            if (bossHP <= 0)
            {
                player.addXP(xpDrop);
                
                ScreenManager.SetScreen(ScreenManager.Win);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {   
            bossAttack.Draw();

            if (isPaused)
            {
                spriteBatch.Draw(TextureManager.Bosses.PauseOverlay, Window, Color.White);
            }

            if (player.godMode == true)
                spriteBatch.DrawString(TextureManager.Message.SlightlyBiggerFont, "Godmode toggled.", new Vector2(250, 500), Color.White);

        }

        public void shakeBoss()
        {
            bossX = rng.Next(bossXOrigin - 2, bossXOrigin + 2);
            bossY = rng.Next(bossYOrigin - 2, bossYOrigin + 2);
        }

        
    }
}
