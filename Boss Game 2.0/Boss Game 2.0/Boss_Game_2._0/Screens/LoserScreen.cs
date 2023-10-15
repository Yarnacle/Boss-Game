using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Boss_Game_2._0.Screens
{
    class LoserScreen : Screen
    {
        Rectangle screenRect;

        public LoserScreen(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            screenRect = new Rectangle(0, 0, 800, 800);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.Loser.lose, screenRect, Color.White);
        }
    }
}
