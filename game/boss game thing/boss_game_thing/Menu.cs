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
    class Menu
    {
        SlidingBarOpen barAnim;

        Rectangle arrowRect;

        Texture2D background;
        Texture2D rightArrowTexture; // right
        Texture2D blackBar;

        KeyboardState oldKB;


        int option;

        bool chosePlay;
        bool choseMenu;

        public Menu(Texture2D background, Texture2D arrowTexture, Texture2D blackBar)
        {
            this.background = background;
            this.rightArrowTexture = arrowTexture;

            arrowRect = new Rectangle(300, 500, 50, 50);

            oldKB = Keyboard.GetState();

            option = 0;
            chosePlay = false;
            choseMenu = false;

            barAnim = new SlidingBarOpen(blackBar);

        }

        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();


            if (kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down) && option != 2)
            {
                if (option == 0)
                    arrowRect.Y += 70;

                if (option == 1)
                    arrowRect.Y += 110;

                option++;
            } // Arrow updates

            if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up) && option != 0)
            {
                if (option == 1)
                    arrowRect.Y -= 70;

                if (option == 2)
                    arrowRect.Y -= 110;


                option--;
            } // Arrow updates


          

            oldKB = kb;
        }



        

        public void DrawBG(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 800), Color.White);
        }

        public void DrawArrow(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rightArrowTexture, arrowRect, Color.White);
        }

        public void resetStuff()
        {
            choseMenu = false;
            chosePlay = false;

            option = 0;

            arrowRect = new Rectangle(300, 500, 50, 50);

        }

        public int chooseOption()
        {
            return option;
        }
     
    }
}
