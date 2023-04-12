using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Boss_Game_2._0.Screens
{
    class Screen
    {
        public static Rectangle Window = new Rectangle(0, 0, 800, 800);
        public static Rectangle ReturnFlag = new Rectangle(0, 95, 44, 54);

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

        public virtual void Reset()
        {

        }
    }
}
