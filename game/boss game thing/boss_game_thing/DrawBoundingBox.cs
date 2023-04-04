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
    class DrawBoundingBox
    {
        Texture2D line;

        Rectangle leftWall;
        Rectangle rightWall;
        Rectangle botWall;
        Rectangle topWall;

        public DrawBoundingBox()
        {
            this.line = line;

            leftWall = new Rectangle(275, 350 + 50, 5, 250);
            rightWall = new Rectangle(525, 350 + 50, 5, 250);
            botWall = new Rectangle(275, 600 + 50, 255, 5);
            topWall = new Rectangle(275, 350 + 50, 255, 5);

        }



        public void DrawBox(SpriteBatch spriteBatch, Texture2D line)
        {
            spriteBatch.Draw(line, leftWall, Color.White);
            spriteBatch.Draw(line, rightWall, Color.White);
            spriteBatch.Draw(line, topWall, Color.White);
            spriteBatch.Draw(line, botWall, Color.White);
        }

        public int getLeftX()
        {
            return leftWall.X;
        }

        public int getRightX()
        {
            return rightWall.X;
        }

        public int getTopY()
        {
            return topWall.Y;
        }

        public int getBotY()
        {
            return botWall.Y;
        }


    }
}
