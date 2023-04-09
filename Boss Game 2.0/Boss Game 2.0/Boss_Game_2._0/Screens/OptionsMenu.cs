using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Boss_Game_2._0.Screens
{
    class OptionsMenu : Screen
    {
        public OptionsMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();

            if (Game1.IsKeyPressed(kb, Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.MainMenu);
            }

            Game1.oldKb = kb;
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.OptionsMenu.Menu, window, Color.White);
        }
    }
}
