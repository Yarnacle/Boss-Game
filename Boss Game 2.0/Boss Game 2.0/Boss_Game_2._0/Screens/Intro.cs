using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Boss_Game_2._0.Screens
{
    class Intro : Screen
    {
        private List<string> messages;
        private string currentText;
        private string textToDisplay;

        private int currentIndex;
        int selection;

        private bool textFullyDisplayed;

        private Vector2 placement;

        SpriteFont font;

        KeyboardState oldKB;

        TimeSpan timer;

        public Intro(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            timer = new TimeSpan(0, 0, 0);
            this.font = TextureManager.Message.Font;
            selection = 0;

            currentText = "";
            textToDisplay = "";

            messages = new List<String>();

            placement = new Vector2(50, 50);

            currentIndex = 0;

            textFullyDisplayed = false;


            messages.Add("You've been living in the village of Arathia for 15 years now.");
            messages.Add("It is the 34th Coming of Rite Ceremony and the village elder has \n       chosen YOU to be the hero from your village.");
            messages.Add("Now, you must unsheath your blade and slay the evils that lay\n           on the other side of the mountain.");

            // manual centering aids

            oldKB = Keyboard.GetState();
        }

        

        public override void Update(GameTime gameTime)
        {
            Game1.kb = Keyboard.GetState();
            timer += gameTime.ElapsedGameTime;


            if (messages.Count != 0)
            {
                if (currentIndex < messages[0].Length)
                {
                    textFullyDisplayed = false;
                    textToDisplay = messages[0];
                    currentText += textToDisplay[currentIndex];
                    currentIndex++;
                }
                // -------------------- Check to make sure if text is fully displayed, this is set to true  -------------------- // 

                if (currentIndex == messages[0].Length)
                    textFullyDisplayed = true;

                // -------------------- SKIP HANDLING  -------------------- // 
                if (Game1.IsKeyPressed(Keys.Z) && textFullyDisplayed == false)
                {
                    currentIndex = messages[0].Length;
                    currentText = messages[0];
                }
                // -------------------- At the end of the message, go to next message if there is more  -------------------- // 
                else if (Game1.IsKeyPressed(Keys.Z) && textFullyDisplayed == true && messages.Count > 1) // If there are more than one messages!!
                {
                    messages.RemoveAt(0);
                    textFullyDisplayed = false;

                    currentText = "";
                    textToDisplay = messages[0];
                    currentIndex = 0;
                }
                // -------------------- At the end of the message, remove if there is no more  -------------------- // 
                else if (Game1.IsKeyPressed(Keys.Z) && textFullyDisplayed == true && messages.Count == 1) // Last message
                {
                    messages.RemoveAt(0);
                    textFullyDisplayed = false;
                    currentText = "";
                    textToDisplay = "";
                    currentIndex = 0;
                    ScreenManager.SetScreen(new Screen[] { ScreenManager.MainMenu }[selection]);
                }
                else if(Game1.IsKeyPressed(Keys.Space))
                {
                    ScreenManager.SetScreen(ScreenManager.MainMenu);
                }
            }
            Game1.UpdateOldKb();
        }

        public override void Draw()
        {
            spriteBatch.Draw(TextureManager.Textures.SolidFill, new Rectangle(0, 0, 800, 800), Color.Black);
            spriteBatch.DrawString(font, currentText, placement, Color.White);
            spriteBatch.DrawString(font, "Press Z to interact. Space to SKIP intro", new Vector2(0, 800 - 25), Color.DarkGray);


        }
        public string getCurrentText()
        {
            return currentText;
        }
        public int getRemainingMessages()
        {
            return messages.Count;
        }

    }
}
