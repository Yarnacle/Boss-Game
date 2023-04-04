using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boss_game_thing
{
    class Player
    {
        Texture2D playerTexture;
        Rectangle playerRect;
        Color playerColor;
        DrawBoundingBox box;

        int hp;
        int xp;

        int lvl;

        float speed;

        bool iFrames;
        int iFramesTimer;


        public Player(Texture2D plrTexture, Color plrColor, int hp, int xp, int lvl, float speed)
        {
            this.playerTexture = plrTexture;
            this.playerColor = plrColor;
            this.hp = hp;
            this.xp = xp;
            this.lvl = lvl;

            this.speed = speed;

            box = new DrawBoundingBox();
            // we attempted to pass in spritebatch through like 6 levels of constructors and it did not go anywhere
            // box.DrawBox(spriteBatch, Game1.projectileTexture);
            // avoid using spritebatch at all costs
            // no, making spritebatch a static game1 iv doesnt work

            playerRect = new Rectangle(800 / 2 - 10, 600, 20, 20);

            iFrames = false;
            iFramesTimer = 90;


        }

        public void Update() // WASD + Arrow Keys, implement XBOX controller port later
        {
            KeyboardState kb = Keyboard.GetState();
            if ((kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up)) && playerRect.Y - 5 > box.getTopY())
                playerRect.Y -= (int)speed;

            if ((kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down)) && playerRect.Y + playerRect.Height < box.getBotY())
                playerRect.Y += (int)speed;

            if ((kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left)) && playerRect.X - 5 > box.getLeftX())
                playerRect.X -= (int)speed;

            if ((kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right)) && playerRect.X + playerRect.Width < box.getRightX())
                playerRect.X += (int)speed;

            if (iFrames == true)
            {
                playerColor = new Color(playerColor.R, playerColor.G, playerColor.B, 0.6f);
                iFramesTimer--;

                if (iFramesTimer == 0)
                {
                    iFrames = false;
                    iFramesTimer = 90;
                    playerColor = new Color(playerColor.R, playerColor.G, playerColor.B);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, playerRect, playerColor);
        }

        public void xpGain(int x) // Call this when you kill an enemy
        {
            this.xp += x;
        }

        public void updateLevel() // Call this after xpGain
        {
            // something about how if xp > val than lvl++;
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public void changePlayerHP(int x)
        {
            if (iFrames == false)
            {
                iFrames = true;
                hp = hp - x;
            }
        }

        public Rectangle returnRect()
        {
            return playerRect;
        }




    }
}
