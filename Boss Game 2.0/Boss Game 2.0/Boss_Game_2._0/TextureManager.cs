using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Dynamic;

namespace Boss_Game_2._0
{
    public static class TextureManager
    {

        // Subdirectories of textures are represented by dynamic objects
        // EXAMPLE: To access a texture called "Texture" in the subdirectory "MainMenu", use "TextureManager.MainMenu.Texture"
        // NOTE: There can be more than 1 layer of subdirectories (it is possible to have "TextureManager.Layer1.Layer2.Layer3.Texture")
        public static dynamic MainMenu;
        public static dynamic Shop;
        public static dynamic Textures;
        public static dynamic BossMenu;

        public static void Initialize(ContentManager content)
        {

            // Subdirectory initialization
            MainMenu = new ExpandoObject();
            Shop = new ExpandoObject();
            Textures = new ExpandoObject();
            BossMenu = new ExpandoObject();


            // Texture initialization

            // This maps the reference "TextureManager.MainMenu.Menu" to the respective file in the content folder
            MainMenu.Menu = content.Load<Texture2D>("Textures\\MainMenu\\Menu"); // remember to include subdirectories in the path of the file
            MainMenu.SelectionUnderline = content.Load<Texture2D>("Textures\\MainMenu\\SelectionUnderline");

            Shop.Menu = content.Load<Texture2D>("Textures\\Shop\\Menu");

            Textures.SolidFill = content.Load<Texture2D>("Textures\\SolidFill");
            Textures.RightArrow = content.Load<Texture2D>("Textures\\RightArrow");
            Textures.LeftArrow = content.Load<Texture2D>("Textures\\LeftArrow");
            Textures.Placeholder = content.Load<Texture2D>("Textures\\Placeholder");
            Textures.TextBox = content.Load<Texture2D>("Textures\\TextBox");

            BossMenu.Menu = content.Load<Texture2D>("Textures\\BossMenu\\Menu");
        }
    }
}
