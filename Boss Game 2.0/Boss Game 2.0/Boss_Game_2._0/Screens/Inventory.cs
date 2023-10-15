using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Boss_Game_2._0.Screens
{
    class Inventory : Screen // i did not write this.
    {
        Texture2D[,] INVItems = new Texture2D[4, 3];



        //0,1,2,3
        //4,5,6,7
        //9,10,11,12

        int selectionX, selectionY;
        TimeSpan timer;
        bool showSelectionHighlight;
        bool isEquipped;
        Color SelectionColor;
        int PickerX, PickerY;
        Rectangle[] Items = new Rectangle[12];
        bool[] ItemslotChecker = new bool[12]; //Checks if item is in slots
        Rectangle[] Itemschecker = new Rectangle[12];



        public Inventory(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            selectionX = 0;
            selectionY = 0;
            timer = new TimeSpan(0, 0, 0);
            SelectionColor = new Color(0, 255, 0, 0.5f);
            showSelectionHighlight = true;
            isEquipped = false;
            for (int i = 0; i < 12; i++)
            {
                ItemslotChecker[i] = false;
            }
            Itemschecker[0] = new Rectangle(100 + 0 * 175, 350 + 0 * 150, 75, 75);
            Itemschecker[1] = new Rectangle(100 + 1 * 175, 350 + 0 * 150, 75, 75);
            Itemschecker[2] = new Rectangle(100 + 2 * 175, 350 + 0 * 150, 75, 75);
            Itemschecker[3] = new Rectangle(100 + 3 * 175, 350 + 0 * 150, 75, 75);
            Itemschecker[4] = new Rectangle(100 + 0 * 175, 350 + 1 * 150, 75, 75);
            Itemschecker[5] = new Rectangle(100 + 1 * 175, 350 + 1 * 150, 75, 75);
            Itemschecker[6] = new Rectangle(100 + 2 * 175, 350 + 1 * 150, 75, 75);
            Itemschecker[7] = new Rectangle(100 + 3 * 175, 350 + 1 * 150, 75, 75);
            Itemschecker[8] = new Rectangle(100 + 0 * 175, 350 + 2 * 150, 75, 75);
            Itemschecker[9] = new Rectangle(100 + 1 * 175, 350 + 2 * 150, 75, 75);
            Itemschecker[10] = new Rectangle(100 + 2 * 175, 350 + 2 * 150, 75, 75);
            Itemschecker[11] = new Rectangle(100 + 3 * 175, 350 + 2 * 150, 75, 75);


            Items[0] = new Rectangle(100 + 0 * 175, 350 + 0 * 150, 75, 75);
            Items[1] = new Rectangle(100 + 1 * 175, 350 + 0 * 150, 75, 75);
            Items[2] = new Rectangle(100 + 2 * 175, 350 + 0 * 150, 75, 75);
            Items[3] = new Rectangle(100 + 3 * 175, 350 + 0 * 150, 75, 75);
            Items[4] = new Rectangle(100 + 0 * 175, 350 + 1 * 150, 75, 75);
            Items[5] = new Rectangle(100 + 1 * 175, 350 + 1 * 150, 75, 75);
            Items[6] = new Rectangle(100 + 2 * 175, 350 + 1 * 150, 75, 75);
            Items[7] = new Rectangle(100 + 3 * 175, 350 + 1 * 150, 75, 75);
            Items[8] = new Rectangle(100 + 0 * 175, 350 + 2 * 150, 75, 75);
            Items[9] = new Rectangle(100 + 1 * 175, 350 + 2 * 150, 75, 75);
            Items[10] = new Rectangle(100 + 2 * 175, 350 + 2 * 150, 75, 75);
            Items[11] = new Rectangle(100 + 3 * 175, 350 + 2 * 150, 75, 75);

            this.spriteBatch = spriteBatch;
        }

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            timer += gameTime.ElapsedGameTime;
            if (timer.Milliseconds >= 500)
            {
                showSelectionHighlight = !showSelectionHighlight;
                timer = TimeSpan.Zero;
            }

            if (Game1.IsKeyPressed( Keys.Up))
            {
                selectionY = Math.Max(0, selectionY - 1);
                showSelectionHighlight = true;
            }
            else if (Game1.IsKeyPressed( Keys.Down))
            {
                selectionY = Math.Min(2, selectionY + 1);
                showSelectionHighlight = true;

            }
            else if (Game1.IsKeyPressed( Keys.Right))
            {
                selectionX = Math.Min(3, selectionX + 1);
                showSelectionHighlight = true;
            }
            else if (Game1.IsKeyPressed( Keys.Left))
            {
                selectionX = Math.Max(0, selectionX - 1);
                showSelectionHighlight = true;

            }
            else if (Game1.IsKeyPressed( Keys.X))
            {
                ScreenManager.SetScreen(ScreenManager.SubMenu);
            }
            else if (Game1.IsKeyPressed( Keys.Z))
            {
                if (!isEquipped)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (PickerX.Equals(Items[i].X) && PickerY.Equals(Items[i].Y))
                        {
                            Items[i] = new Rectangle(300, 75, 200, 200);
                            isEquipped = true;
                        }

                    }
                }
                else if (isEquipped) //if there is an item equiped, then dont move anything else to equip slot
                {
                    for (int i = 0; i < 12; i++)
                    {
                        Items[i] = Items[i];

                    }
                }
            }
            else if (Game1.IsKeyPressed(Keys.C))
            {
                for (int i = 0; i < 12; i++)
                {
                    if (isEquipped)
                    {
                        if (Items[i].X == 300 && Items[i].Y == 75)//checks if something is in hat bar
                        {
                            Items[i] = new Rectangle(100 + selectionX * 175, 350 + selectionY * 150, 75, 75);
                            isEquipped = false;
                        }
                    }
                }
            }

            PickerX = 100 + (selectionX * 175);
            PickerY = 350 + (selectionY * 150);
                        Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.SubMenu.Inventory, Window, Color.White);

            spriteBatch.Draw(TextureManager.SubMenu.GreenSword, Items[0], Color.White);
            ItemslotChecker[0] = true;
            spriteBatch.Draw(TextureManager.SubMenu.OrangeSword, Items[1], Color.White);
            ItemslotChecker[1] = true;
            spriteBatch.Draw(TextureManager.SubMenu.BlueSword, Items[2], Color.White);
            ItemslotChecker[2] = true;
            spriteBatch.DrawString(TextureManager.SubMenu.font, "Press C to Unequip", new Vector2(50, 50), Color.Black);

            if (showSelectionHighlight)
            {
                spriteBatch.Draw(TextureManager.SubMenu.SelectionHighlightbox, new Rectangle(100 + selectionX * 175, 350 + selectionY * 150, 75, 75), SelectionColor);
            }
        }

        public override void Reset()
        {
            if(isEquipped)
            {
                isEquipped = true;
            }
            else
            {
                isEquipped = false;
            }
            showSelectionHighlight = true;
            timer = TimeSpan.Zero;
            selectionX = 0;
            selectionY = 0;

        }
    }
}
