using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace boss_game_thing
{
    class WorldSelectManager
    {
        SpriteFont font;

        string[] worldNames = new string[5];
        bool[] unlockedWorlds = new bool[5];

        Texture2D[] worldIcons = new Texture2D[5]; // increase this later

        Texture2D worldBorder;
        Texture2D worldBorderLocked;

        Texture2D lArrow;
        Texture2D rArrow;

        Rectangle worldBorderRect; // this does not need to be in the constructor lol

        int displayIndex;


        Rectangle lArrowRect;
        Rectangle rArrowRect;

        Texture2D worldIconTemp;


        public WorldSelectManager(SpriteFont font, Texture2D worldBorder, Texture2D worldBorderLocked, Rectangle worldBorderRect, Texture2D temp, Texture2D lArrow, Texture2D rArrow)
        {
            this.worldBorder = worldBorder;
            this.worldBorderLocked = worldBorderLocked;
            this.worldBorderRect = worldBorderRect;

            this.font = font;

            this.lArrow = lArrow;
            this.rArrow = rArrow;

            this.worldIconTemp = temp; // delete  later

            displayIndex = 0;

            unlockedWorlds[0] = true;

            worldNames[0] = "World1 Placehold";
            worldNames[1] = "World2 Placehold";
            worldNames[2] = "World3 Placehold";
            worldNames[3] = "World4 Placehold";
            worldNames[4] = "World5 Placehold";

            lArrowRect = new Rectangle(50, 250, 100, 100);
            rArrowRect = new Rectangle(650, 250, 100, 100);
        }

        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Right) && !Game1.oldKB.IsKeyDown(Keys.Right) && displayIndex < worldNames.Length - 1)
                displayIndex++;

            if (kb.IsKeyDown(Keys.Left) && !Game1.oldKB.IsKeyDown(Keys.Left) && displayIndex > 0)
                displayIndex--;

            if (kb.IsKeyDown(Keys.Z) && !Game1.oldKB.IsKeyDown(Keys.Z))
            {
                Game1.setState(5 + displayIndex);
            }

            Game1.oldKB = kb;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(worldIconTemp, new Rectangle(100, 100, 600, 600), Color.White * 1f);

            if (unlockedWorlds[displayIndex] == true)
                spriteBatch.Draw(worldBorder, worldBorderRect, Color.White);

            if (unlockedWorlds[displayIndex] == false)
                spriteBatch.Draw(worldBorderLocked, worldBorderRect, Color.White);

            spriteBatch.DrawString(font, worldNames[displayIndex], new Vector2(300, 600), Color.White);
            spriteBatch.DrawString(font, "Press X to return", new Vector2(0, 800 - 25), Color.DarkGray);

            if (displayIndex != 0)
                spriteBatch.Draw(lArrow, lArrowRect, Color.White);

            if (displayIndex != worldNames.Length - 1)
                spriteBatch.Draw(rArrow, rArrowRect, Color.White);

        }


    }
}
