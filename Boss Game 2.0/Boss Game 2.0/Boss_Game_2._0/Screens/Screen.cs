using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Boss_Game_2._0.Screens
{
    class Screen
    {
        public static Rectangle window = new Rectangle(0, 0, 800, 800);

        public SpriteBatch spriteBatch;

        public Screen(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
