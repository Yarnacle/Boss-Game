using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;
using System;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Boss1 : Boss
    {
        public Boss1(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            attack = new Spiral(spriteBatch, 400, 400, (float)Math.PI / 15, (float)Math.PI / 2, 100, 0, 0, 15);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.Placeholder, Window, Color.White * 0.2f);

            base.Draw();
        }
    }
}
