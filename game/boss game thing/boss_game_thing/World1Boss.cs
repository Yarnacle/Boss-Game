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
    class World1Boss : BattleSystem
    {
        bool drawBullet;

        Boss boss;
        SpiralAttack spiralAttack;

        public World1Boss(Texture2D bossTexture, Texture2D playerTexture) : base(playerTexture)
        {
            boss = new Boss(bossTexture, Color.White, 200, new Rectangle(325,150,150,150));
            spiralAttack = new SpiralAttack(Game1.projectileTexture, new Vector2(400 - 9, 200), Color.White, 20, 3);
            drawBullet = true;
        }

        new public void Update(SpriteBatch spriteBatch)
        {
            spiralAttack.Draw(spriteBatch);
            boss.Draw(spriteBatch);

            base.Update(spriteBatch);
            spiralAttack.Update();
            if (drawBullet)
            {
                spiralAttack.addBullet();
            }
            drawBullet = !drawBullet;

            for (int i = spiralAttack.getProjectilesCount() - 1; i >= 0; i--)
            {
                if (player.returnRect().Intersects(spiralAttack.getList(i)))
                {
                    player.changePlayerHP(2);
                    spiralAttack.remove(i);
                    if (player.Hp <= 0)
                    {
                        Game1.setState(10);
                        player.Hp = 20;
                        spiralAttack.clear();
                        break;
                    }
                }
            }
            spriteBatch.DrawString(Game1.fontOne, player.Hp.ToString(), new Vector2(100, 100), Color.White);
        }
    }
}
