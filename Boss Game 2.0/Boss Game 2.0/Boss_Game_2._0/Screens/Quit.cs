using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens
{
    class Quit : Screen 
    {
        Game1 game1;

        public Quit(SpriteBatch spriteBatch,Game1 game1) : base(spriteBatch)
        {
            this.game1 = game1;   
        }

        public override void Update(GameTime gameTime)
        {
            game1.Exit();
        }
    }
}
