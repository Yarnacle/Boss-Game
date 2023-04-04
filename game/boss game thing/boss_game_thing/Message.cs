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
    class Message
    {
        private List<string> messages;

        private string currentText; // current item on the list
        private string textToDisplay;

        private int animSpeed; // how fast letters appear. higher speed = slower
        private int currentIndex; // keep track of index of string

        private bool textFullyDisplayed;

        SpriteFont font;
        SpriteBatch spriteBatch;

        KeyboardState oldKB;


        public Message(SpriteFont font, SpriteBatch spriteBatch)
        {
            this.font = font;
            this.spriteBatch = spriteBatch;

            currentText = "";
            textToDisplay = "";

            messages = new List<String>();

            animSpeed = 5;
            currentIndex = 0;


            textFullyDisplayed = false;


            oldKB = Keyboard.GetState();
        }
        public void AddMessage(string message)
        {
            messages.Add(message);
        }

        public void Update()
        {
            KeyboardState kb = Keyboard.GetState();

            // -------------------- Regular Animation for Text -------------------- //
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
                if (kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z) && textFullyDisplayed == false)
                {
                    currentIndex = messages[0].Length;
                    currentText = messages[0];
                }
                // -------------------- At the end of the message, go to next message if there is more  -------------------- // 
                else if (kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z) && textFullyDisplayed == true && messages.Count > 1) // If there are more than one messages!!
                {
                    messages.RemoveAt(0);
                    textFullyDisplayed = false;

                    currentText = "";
                    textToDisplay = messages[0];
                    currentIndex = 0;
                }
                // -------------------- At the end of the message, remove if there is no more  -------------------- // 
                else if (kb.IsKeyDown(Keys.Z) && !oldKB.IsKeyDown(Keys.Z) && textFullyDisplayed == true && messages.Count == 1) // Last message
                {
                    messages.RemoveAt(0);
                    textFullyDisplayed = false;
                    currentText = "";
                    textToDisplay = "";
                    currentIndex = 0;
                }
            }

            oldKB = Keyboard.GetState();
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
