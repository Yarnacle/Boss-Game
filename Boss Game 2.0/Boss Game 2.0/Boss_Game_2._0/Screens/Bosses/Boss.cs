using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Boss_Game_2._0.Screens.Bosses.Attacks;

namespace Boss_Game_2._0.Screens.Bosses
{
    class Boss : Screen
    {
        public Attack attack;

        public Boss(SpriteBatch spriteBatch) : base(spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {
            attack.Update(gameTime);
        }

        public override void Draw()
        {
            attack.Draw();
        }
    }
}
