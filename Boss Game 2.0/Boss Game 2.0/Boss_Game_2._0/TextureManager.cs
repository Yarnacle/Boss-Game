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
        public static dynamic OptionsMenu;
        public static dynamic Textures;

        public static void Initialize(ContentManager content)
        {

            // Subdirectory initialization
            MainMenu = new ExpandoObject();
            OptionsMenu = new ExpandoObject();
            Textures = new ExpandoObject();


            // Texture initialization

            // This maps the reference "TextureManager.MainMenu.Menu" to the respective file in the content folder
            MainMenu.Menu = content.Load<Texture2D>("Textures\\MainMenu\\Menu"); // remember to include subdirectories in the path of the file
            MainMenu.SelectionArrow = content.Load<Texture2D>("Textures\\MainMenu\\SelectionArrow");
            MainMenu.SelectionUnderline = content.Load<Texture2D>("Textures\\MainMenu\\SelectionUnderline");

            OptionsMenu.Menu = content.Load<Texture2D>("Textures\\OptionsMenu\\Menu");

            Textures.SolidFill = content.Load<Texture2D>("Textures\\SolidFill");
        }
    }
}
