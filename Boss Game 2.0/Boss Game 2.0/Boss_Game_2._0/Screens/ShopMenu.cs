using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Boss_Game_2._0.Screens
{
    class ShopMenu : Screen // i did NOT make this clas.
    {
        int selection;
        int gold = 10;
        int xp = 10;
        TimeSpan timer;
        bool showSelectionUnderline;
        Color SelectionColor;
        Rectangle selectBox;
        Rectangle[,] boxes = new Rectangle[4, 2];

        Boolean[,] itemChoose = new Boolean[4, 2];

        int[,] chosen = new int[4, 2];
        public ShopMenu(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selection = 0;
            timer = new TimeSpan(0, 0, 0);
            selectBox = new Rectangle(-275, 50, 750, 750);

            SelectionColor = Color.Yellow;
            showSelectionUnderline = true;
            this.spriteBatch = spriteBatch;
        }


        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();

            // Countdown until switch toggle selection underline visibility
            for (int i = 0; i < 4; i++)
            {
                boxes[i, 0] = new Rectangle(-275 + (i * 200), 50, 750, 750);
                boxes[i, 1] = new Rectangle(-275 + (i * 200), 250, 750, 750);

                itemChoose[i, 0] = false;
                itemChoose[i, 1] = false;
            }


            timer += gameTime.ElapsedGameTime;
            if (timer.Milliseconds >= 500)
            {
                showSelectionUnderline = !showSelectionUnderline;
                timer = TimeSpan.Zero;
            }

            if (Game1.IsKeyPressed( Keys.Up) && selection > 3)
            {
                selectBox.Y -= 200;
                selection -= 4;
                showSelectionUnderline = true; // If change selection, always show underline again
            }
            else if (Game1.IsKeyPressed( Keys.Down) && selection < 4)
            {
                selectBox.Y += 200;
                selection += 4;
                showSelectionUnderline = true;
            }
            if (Game1.IsKeyPressed( Keys.Left) && selection != 0 && selection != 4)
            {
                selectBox.X -= 200;
                selection--;
                showSelectionUnderline = true; // If change selection, always show underline again
            }
            else if (Game1.IsKeyPressed( Keys.Right) && selection != 3 && selection != 7)
            {
                selectBox.X += 200;
                selection++;
                showSelectionUnderline = true;
            }
            else if (Game1.IsKeyPressed( Keys.Z))
            {
                if (selection < 4)
                    chosen[selection, 0] = 1;
                else
                    chosen[selection - 4, 1] = 1;
                if (selection < 4)
                    itemChoose[selection, 0] = true;
                else
                    itemChoose[selection - 4, 1] = true;

            }
            else if (Game1.IsKeyPressed( Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.SubMenu);
            }

            Game1.UpdateOldKb();
        }


        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.ShopMenu.Menu, Window, Color.White);
            for (int i = 0; i < 4; i++)
            {
                spriteBatch.Draw(TextureManager.ShopMenu.PurpleBox, boxes[i, 0], Color.White);
                spriteBatch.Draw(TextureManager.ShopMenu.PurpleBox, boxes[i, 1], Color.White);

                if (chosen[i, 0] == 1)
                    spriteBatch.Draw(TextureManager.ShopMenu.X, boxes[i, 0], Color.White);
                if (chosen[i, 1] == 1)
                    spriteBatch.Draw(TextureManager.ShopMenu.X, boxes[i, 1], Color.White);
            }
            spriteBatch.Draw(TextureManager.ShopMenu.GreenBox, selectBox, Color.White);

        }
        public override void Reset()
        {
            selectBox.X = -275;
            selectBox.Y = 50;
            timer = TimeSpan.Zero;
            selection = 0;
        }
    }
}
