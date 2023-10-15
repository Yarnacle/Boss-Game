using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using System;
using Microsoft.Xna.Framework.Input;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Boss2Screen : BossScreen
    {
        private Random rng;

        private int playerSelection;
        private bool isAttacking; // uhhhh this might have to be private

        private int dmgValue;
        Color damageDisplay;

        Rectangle[] timingZones;
        Rectangle[] timingDisplay;

        bool frameOne;

        private int sourceRectY;

        //gui shit
        private TimeSpan selectTimer;
        bool showSelectionUnderline;

        int stupidAssTimer;

        Rectangle attackBarPos;

        public Boss2Screen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            bossAttack = new RandomCircles(spriteBatch, 0, 0, (float)Math.PI / 12, (float)Math.PI / 12, 250, 0, 0, 15, 10, 240); // Can't leave null
            rng = new Random();
            bossHP = 40;
            bossDmg = 3;
            xpDrop = 15;
            playerSelection = 0;
            damageDisplay = Color.Red;

            shakeTimer = 90;
            bossX = 325;
            bossY = 150;

            sourceRectY = 384;

            bossXOrigin = 325;
            bossYOrigin = 150;


            timingZones = new Rectangle[]
            {
                new Rectangle(113, 630, 40, 40), // red
                new Rectangle(153, 630, 40, 40), // orange
                new Rectangle(193, 630, 40, 40), // green
                new Rectangle(233, 630, 40, 40), // orange
                new Rectangle(273, 630, 40, 40) // red
            };
            attackBarPos = new Rectangle(700, 635, 35, 35);

            timingDisplay = new Rectangle[] // just for visuals
             {
                new Rectangle(113, 610, 40, 80), // red
                new Rectangle(153, 610, 40, 80), // orange
                new Rectangle(193, 610, 40, 80), // green
                new Rectangle(233, 610, 40, 80), // orange
                new Rectangle(273, 610, 40, 80) // red
             };
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            if (stupidAssTimer % 30 == 0) // LMFAO
            {
                frameOne = !frameOne;

                if (frameOne)
                {
                    sourceRectY = 384;
                }
                if (!frameOne)
                {
                    sourceRectY = 0;
                }

            }
            stupidAssTimer++;

            if (isPaused)
            {
                base.Update(gameTime);
                return;
            }

            timer += gameTime.ElapsedGameTime;

            if (playerTurn && !isAttacking)
            {
                selectTimer += gameTime.ElapsedGameTime;
                if (selectTimer.Milliseconds >= 500)
                {
                    showSelectionUnderline = !showSelectionUnderline;
                    selectTimer = TimeSpan.Zero;
                }

                if (kb.IsKeyDown(Keys.Right) && Game1.oldKb.IsKeyUp(Keys.Right))
                {
                    playerSelection = Math.Min(2, playerSelection + 1);
                }
                else if (kb.IsKeyDown(Keys.Left) && Game1.oldKb.IsKeyUp(Keys.Left))
                {
                    playerSelection = Math.Max(0, playerSelection - 1);
                }
                else if (kb.IsKeyDown(Keys.Z) && Game1.oldKb.IsKeyUp(Keys.Z))
                {
                    if (playerSelection == 0)//Attack
                    {
                        damageDisplay = Color.Red;
                        attackBarPos = new Rectangle(700, 635, 30, 30); // where the change actually matters. up there is init
                        isAttacking = true;
                    }
                    else if (playerSelection == 1) //Heal
                    {
                        damageDisplay = damageDisplay * 0f;
                        if (base.player.GetHealsUsed() >= 3)
                        {
                            return;
                        }
                        base.player.Heal();
                        switchAttack();
                        playerTurn = false;
                    }
                    else if (playerSelection == 2)
                    {
                        ScreenManager.SetScreen(ScreenManager.BossMenu);
                    }
                    timer = TimeSpan.Zero;
                    playerSelection = 0;
                }
            }
            else if (isAttacking)
            {
                attackBarPos.X -= 10;
                if (kb.IsKeyDown(Keys.Z) && Game1.oldKb.IsKeyUp(Keys.Z))
                {
                    double multiplier = 0;
                    if (timingZones[2].Contains(attackBarPos)) // Bar is FULLY within green zone
                    {
                        multiplier = 2.5;
                    }
                    else
                    {
                        for (int i = 0; i < timingZones.Length; i++)
                        {
                            if (timingZones[i].Intersects(attackBarPos))
                            {
                                if (i == 0 || i == 4) { multiplier = 1; }
                                else if (i == 1 || i == 3) { multiplier = 1.5; }
                                else { multiplier = 2; }
                            }
                        }
                    }


                    dmgValue = (int)(player.strength * multiplier);

                    bossHP -= dmgValue;

                    shakeTimer = 90;
                    playerTurn = false;
                    isAttacking = false;
                    switchAttack();
                }

                if (attackBarPos.X < 100 - attackBarPos.Width)
                {
                    dmgValue = 0;
                    bossHP -= dmgValue;

                    shakeTimer = 0;
                    playerTurn = false;
                    isAttacking = false;
                    switchAttack();
                }
            }
            else // boss turn >:)
            {
                damageDisplay = damageDisplay * 0.97f;
                player.Update();
                bossAttack.Start();
                if (timer.TotalSeconds >= bossAttack.attackTime)
                { // Switch back to player's turn
                    bossAttack.Stop();
                    bossAttack.clear();
                    timer = TimeSpan.Zero;
                    player.setX(800 / 2 - 10);
                    player.setY(600);
                    playerTurn = true;
                }
            }
            base.Update(gameTime);
        }

        private void switchAttack()
        {
            int attack = rng.Next(0, 4);
            switch (attack)
            {
                case 0:
                    bossAttack = new TopBottom(spriteBatch, 0, -0, (float)Math.PI / 15, (float)Math.PI / 2, 200, 0, 0, 15, 10, 90);
                    break;
                case 1:
                    bossAttack = new Spiral(spriteBatch, 400, 250, (float)Math.PI / 31, (float)Math.PI / 2.2f, 250, 0, 0, 15, 10, 2);
                    break;
                case 2:
                    bossAttack = new MovingCircles(spriteBatch, 0, 0, (float)Math.PI / 12, (float)Math.PI / 2, 250, 100, -5, 15, 8, false);
                    break;
                case 3:
                    bossAttack = new RandomCircles(spriteBatch, 0, 0, (float)Math.PI / 12, (float)Math.PI / 12, 300, rng.Next(-100, 101), rng.Next(-100, 101), 15, 10, 240);
                    break;


            }



        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.Placeholder2, Window, Color.White * 0.2f);

            spriteBatch.Draw(TextureManager.Bosses.Boss2.IceBoss, new Rectangle(bossX - 126, bossY, 384, 384), new Rectangle(0, sourceRectY, 384, 384), Color.White); // TODO: make a boss class that will have its own .Draw() method with this code


            if (playerTurn)
            {
                if (!isAttacking)
                {
                    spriteBatch.Draw(TextureManager.Textures.TextBox, new Rectangle(100, 550, 600, 200), Color.White);
                    spriteBatch.DrawString(TextureManager.Message.Font, "Attack", new Vector2(195, 625 - 20), Color.White);
                    spriteBatch.DrawString(TextureManager.Message.Font, "Heal", new Vector2(365, 625 - 20), player.GetHealsUsed() < 3 ? Color.White : Color.Gray);
                    spriteBatch.DrawString(TextureManager.Message.Font, "Flee", new Vector2(525, 625 - 20), Color.White);


                    spriteBatch.DrawString(TextureManager.Message.Font, " Boss HP: " + bossHP.ToString() + "\nPlayer HP: " + player.GetHp(), new Vector2(318, 650), Color.White);
                    spriteBatch.DrawString(TextureManager.Message.Font, "Level: " + player.getLevel() + "    XP: " + player.getXP() + "/" + player.xpReqs[player.getLevel()], new Vector2(160, 715), Color.White);


                    spriteBatch.Draw(TextureManager.Textures.RightArrow, new Rectangle(150 + playerSelection * 160, 603, 25, 25), Color.White);

                    if (showSelectionUnderline)
                    {
                        spriteBatch.Draw(TextureManager.MainMenu.SelectionUnderline, new Rectangle(200 + playerSelection * 160, 630, 55, 5), Color.White);
                    }

                    if (showSelectionUnderline && playerSelection == 1)
                        spriteBatch.DrawString(TextureManager.Message.Font, (3 - player.GetHealsUsed()).ToString() + "/3 remaining", new Vector2(318, 580), player.GetHealsUsed() < 3 ? Color.White : Color.Gray);

                }
                else // attack stuff, dogshit Code
                {
                    spriteBatch.Draw(TextureManager.Textures.AttackBox, new Rectangle(100, 600, 600, 100), Color.White);

                    spriteBatch.Draw(TextureManager.Textures.SolidFill, timingDisplay[0], new Color(145, 68, 68)); // red
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, timingDisplay[1], new Color(158, 121, 70)); // orange
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, timingDisplay[2], new Color(56, 130, 68)); // green
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, timingDisplay[3], new Color(158, 121, 70)); // orange
                    spriteBatch.Draw(TextureManager.Textures.SolidFill, timingDisplay[4], new Color(145, 68, 68)); // red

                    spriteBatch.Draw(TextureManager.Textures.TimingCircle, timingZones[0], new Color(219, 102, 102)); // red
                    spriteBatch.Draw(TextureManager.Textures.TimingCircle, timingZones[1], new Color(240, 176, 86)); // orange
                    spriteBatch.Draw(TextureManager.Textures.TimingCircle, timingZones[2], new Color(102, 219, 121)); // green
                    spriteBatch.Draw(TextureManager.Textures.TimingCircle, timingZones[3], new Color(240, 176, 86)); // orange
                    spriteBatch.Draw(TextureManager.Textures.TimingCircle, timingZones[4], new Color(219, 102, 102)); // red

                    spriteBatch.Draw(TextureManager.Textures.AttackCircle, attackBarPos, Color.White);
                }

            }
            else
            {
                if (shakeTimer != 0)
                {
                    shakeTimer--; // i am so sorry for putting this here.
                    shakeBoss();
                }

                spriteBatch.DrawString(TextureManager.Message.BigFont, "-" + dmgValue.ToString(), new Vector2(rng.Next(445, 451), rng.Next(195, 201)), damageDisplay);

                player.DrawPlayer(spriteBatch);
            }
            base.Draw();
        }


    }
}
