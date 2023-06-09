﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Boss_Game_2._0.Screens
{
    class Shop : Screen
    {
        public Shop(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();

            if (Game1.IsKeyPressed(Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.MainMenu);
            }

            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Shop.Menu, Window, Color.White);
        }
    }
}
