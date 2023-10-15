using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using System;
using Boss_Game_2._0.Screens;
using Microsoft.Xna.Framework.Input;

namespace Boss_Game_2._0
{
    public class Player
    {
        public Rectangle playerRect;
        Color playerColor;
        int hp;
        int maxhp;
        float speed;
        public bool iFrames;
        int iFramesTimer;
        int numHealsUsed;

        public static int XP;
        public static int level;

        public int[] xpReqs;
        public int[] hpLevel;
        public int[] baseDamage;

        public int strength;

        public bool godMode; // for testing purposes;

        float opacMult; // opacity multiplier


        public Player(Rectangle playerRect, int hp, float speed, SpriteBatch spriteBatch)
        {
            playerColor = Color.White;
            this.hp = hp;
            this.maxhp = hp;
            this.speed = speed;
            this.playerRect = playerRect;
            //hp = 20;
            //speed = 2;
            //playerRect = new Rectangle(800 / 2 - 10, 600, 20, 20);
            iFrames = false;
            iFramesTimer = 90;


            opacMult = 0.5f;

            xpReqs = new int[5];
            hpLevel = new int[5];
            baseDamage = new int[5];

            godMode = false; // testing purposes

            // level stat requirement stuff???
            xpReqs[0] = 5;
            xpReqs[1] = 20;
            xpReqs[2] = 35;
            xpReqs[3] = 50;
            xpReqs[4] = 75;

            // hp values per level
            hpLevel[0] = 20;
            hpLevel[1] = 30;
            hpLevel[2] = 40;
            hpLevel[3] = 50;
            hpLevel[4] = 60;

            // base damage per level
            baseDamage[0] = 2;
            baseDamage[1] = 3;
            baseDamage[2] = 4;
            baseDamage[3] = 5;
            baseDamage[4] = 6;


            strength = baseDamage[level];

        }

        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up))
            {
                playerRect.Y -= (int)speed;
            }
            if (kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down))
            {
                playerRect.Y += (int)speed;
            }
            if (kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right))
            {
                playerRect.X += (int)speed;
            }
            if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left))
            {
                playerRect.X -= (int)speed;
            }                        
            if (iFrames == true)
            {
                if (iFramesTimer % 5 == 0) // iFrame flicker 
                    flicker();

                iFramesTimer--;

                if (iFramesTimer == 0)
                {
                    iFrames = false;
                    iFramesTimer = 90;
                    playerColor = Color.White;
                }
            }

            if(playerRect.X < 0) { playerRect.X = 0;  }
            if(playerRect.X > 780) { playerRect.X = 780; }
            if(playerRect.Y < 0) { playerRect.Y = 0; }
            if(playerRect.Y > 780) { playerRect.Y = 780; }


            
        }

        public void LevelChecker()
        {
            if (XP >= xpReqs[level] && level < 4)
            {
                XP = XP - xpReqs[level];
                level++;

                LevelChecker(); // wow! it calls itself :O
            }
        }

        public void addXP(int x)
        {
            XP += x;
            LevelChecker();
        }

        public void ChangePlayerHP(int x)
        {
            if (iFrames == false)
            {
                iFrames = true;
                hp -= x;
            }
        }

        public void Heal()
        {
            hp += 10;
            if(hp > maxhp) { hp = maxhp; }
            numHealsUsed++;
        }

        public Rectangle ReturnRect()
        {
            return playerRect;
        }

        public int ReturnX()
        {
            return playerRect.X;
        }

        public int ReturnY()
        {
            return playerRect.Y;
        }
        public int GetHp()
        {
            return hp;
        }

        public void setX(int x)
        {
            playerRect.X = x;
        }

        public void setY(int y)
        {
            playerRect.Y = y;
        }

        public Rectangle Despawn()
        {
            return playerRect = new Rectangle(playerRect.X, playerRect.Y, 0, 0);
        }

        public int GetHealsUsed()
        {
            return numHealsUsed;
        }

        public void ToggleGod()
        {
            godMode = !godMode;

            if (godMode == true)
                strength = 999;

            if (godMode == false)
                strength = baseDamage[level];
        }

        public void flicker() // iframes thing
        {
            playerColor = Color.White * opacMult;

            if (opacMult == 0.5f)
                opacMult = 1f;
            else
                opacMult = 0.5f;
        }

        public int getXP()
        {
            return XP;
        }

        public int getLevel()
        {
            return level;
        }
    
        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Player.PlayerModel, playerRect, playerColor);

        }




    }
}
