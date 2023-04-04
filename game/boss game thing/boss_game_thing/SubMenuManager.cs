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
    class SubMenuManager
    {
        Texture2D bg;
        Texture2D arrowTexture;

        Rectangle bgRect;
        Rectangle arrowRect;

        KeyboardState oldKB;

        SpriteFont font;
        int option;

        public SubMenuManager(Texture2D bg, Texture2D arrowTexture, SpriteFont font)
        {
            this.bg = bg;
            this.arrowTexture = arrowTexture;
            this.font = font;

            bgRect = new Rectangle(0, 0, 800, 800);
            arrowRect = new Rectangle(500, 50, 50, 50);


            oldKB = Keyboard.GetState();

        }



        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();


            if (kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down) && option != 2)
            {
                arrowRect.Y += 315;

                option++;
            } // Arrow updates

            if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up) && option != 0)
            {
                arrowRect.Y -= 315;


                option--;
            } // Arrow updates




            oldKB = kb;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, bgRect, Color.White);
            spriteBatch.DrawString(font, "Press X to return", new Vector2(0, 800 - 25), Color.DarkGray);
            spriteBatch.Draw(arrowTexture, arrowRect, Color.White);

        }

    }


}
