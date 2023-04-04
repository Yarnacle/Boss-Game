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
    class BattleSystem // Battle Manager
    {
        enum Turn
        {
            PlayerChoice,
            Attacking,
            BossAttacking,
        }

        Turn currState;
        public Player player;

        int option;

        public BattleSystem(Texture2D plrTexture)
        {
            player = new Player(plrTexture, Color.White, 20, 0, 0, 2);
        }

        public void Update(SpriteBatch spriteBatch)
        {
            player.Update();
            player.Draw(spriteBatch);
            switch (currState)
            {
                case Turn.PlayerChoice:






                    break;


                case Turn.BossAttacking:



                    break;

            }
        }


        

    }
}
