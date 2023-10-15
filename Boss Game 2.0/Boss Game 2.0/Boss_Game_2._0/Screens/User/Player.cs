using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Boss_Game_2._0
{
    class Player
    {
        Rectangle playerRect;
        Color playerColor;
        int hp;
        float speed;
        bool iFrames;
        int iFramesTimer;


        public Player(Rectangle _playerRect, int _hp, float _speed, SpriteBatch spriteBatch)
        {
            playerColor = Color.White;
            this.hp = _hp;
            this.speed = _speed;
            this.playerRect = _playerRect;
            //hp = 20;
            //speed = 2;
            //playerRect = new Rectangle(800 / 2 - 10, 600, 20, 20);
            iFrames = false;
            iFramesTimer = 90;
        }

        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.W))
            {
                playerRect.Y -= (int)speed;
            }
            if (kb.IsKeyDown(Keys.S))
            {
                playerRect.Y += (int)speed;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                playerRect.X += (int)speed;
            }
            if (kb.IsKeyDown(Keys.A))
            {
                playerRect.X -= (int)speed;
            }
            if (iFrames == true)
            {
                playerColor = new Color(playerColor.R, playerColor.G, playerColor.B, 0.1f);
                iFramesTimer--;

                if (iFramesTimer == 0)
                {
                    iFrames = false;
                    iFramesTimer = 90;
                    playerColor = new Color(playerColor.R, playerColor.G, playerColor.B);
                }
            }

            ReturnX();
            ReturnY();

        }

        public void ChangePlayerHP(int x)
        {
            if (iFrames == false)
            {
                iFrames = true;
                hp -= x;
            }
        }

        public int AttackBoss()
        {
            Random rng = new Random();
            int attackDmg = rng.Next(1, 10);
            return attackDmg;
        }

        public int HealPlayer()
        {
            Random rng = new Random();
            int heal = rng.Next(1, 10);
            return heal;
        }

        public int GetPlayerHp()
        {

            return hp;

        }

        public Rectangle ReturnRect()
        {
            return playerRect;
        }

        public int ReturnX()
        {
            int UserX = playerRect.X;

            return UserX;
        }

        public int ReturnY()
        {
            int UserY = playerRect.Y;
            return UserY;
        }

        public int ReturnWidth()
        {
            return playerRect.Width;
        }

        public int ReturnHeight()
        {
            return playerRect.Height;
        }

        public Rectangle Respawn()
        {
            return playerRect = new Rectangle(800 / 2 - 10, 600, 20, 20);
        }

        public int GetHp()
        {
            return hp;
        }

        public Rectangle Despawn()
        {
            return playerRect = new Rectangle(playerRect.X, playerRect.Y, 0, 0);
        }

        public void DrawPlayer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Player.playerModel, playerRect, playerColor);
        }


    }
}
