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
    class Boss
    {
        Texture2D BossTexture;
        Rectangle BossRect;
        Color BossColor;

        DrawBoundingBox box;

        int hp;
        int xp;

        int lvl;

        float speed;

        bool iFrames;
        int iFramesTimer;


        public Boss(Texture2D bossTexture, Color bossColor, int hp, Rectangle bossRect)
        {
            this.BossTexture = bossTexture;
            this.BossColor = bossColor;
            this.hp = hp;
            this.BossRect = bossRect;

            box = new DrawBoundingBox();


        }

        public void Update() // WASD + Arrow Keys, implement XBOX controller port later
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BossTexture, BossRect, BossColor);
        }

        public int Hp
        {
            get { return hp; }
        }

        public void changeBossHP(int x)
        {
        }

        public Rectangle returnRect()
        {
            return BossRect;
        }




    }
}
