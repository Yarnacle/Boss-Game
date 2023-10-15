using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Dynamic;

namespace Boss_Game_2._0
{
    public static class TextureManager 
    {
        /* Class Description:
         * Initialize all textures using ExpandoObjects so they can be called from anywhere.
         */

        // Subdirectories of textures are represented by dynamic objects
        // EXAMPLE: To access a texture called "Texture" in the subdirectory "MainMenu", use "TextureManager.MainMenu.Texture"
        // NOTE: There can be more than 1 layer of subdirectories (it is possible to have "TextureManager.Layer1.Layer2.Layer3.Texture")
        public static dynamic MainMenu;
        public static dynamic SubMenu;
        public static dynamic Textures;
        public static dynamic BossMenu;
        public static dynamic Bosses;
        public static dynamic ShopMenu;
        public static dynamic Player;
        public static dynamic Message;
        public static dynamic Loser;
        public static dynamic Winner;

        public static void Initialize(ContentManager content)
        {

            // Subdirectory initialization
            MainMenu = new ExpandoObject();
            SubMenu = new ExpandoObject();
            Textures = new ExpandoObject();
            BossMenu = new ExpandoObject();
            ShopMenu = new ExpandoObject();
            Loser = new ExpandoObject();
            Winner = new ExpandoObject();

            Bosses = new ExpandoObject();
            Bosses.Boss1 = new ExpandoObject();
            Bosses.Boss2 = new ExpandoObject();
            Bosses.Boss3 = new ExpandoObject();



            Player = new ExpandoObject();

            Message = new ExpandoObject();


            // Texture initialization

            // This maps the reference "TextureManager.MainMenu.Menu" to the respective file in the content folder
            MainMenu.Menu = content.Load<Texture2D>("Textures\\MainMenu\\Menu"); // remember to include subdirectories in the path of the file
            MainMenu.SelectionUnderline = content.Load<Texture2D>("Textures\\MainMenu\\SelectionUnderline");
            MainMenu.PlayerModel = content.Load<Texture2D>("Textures\\MainMenu\\MainMenuPlayer");

            Textures.SolidFill = content.Load<Texture2D>("Textures\\SolidFill");
            Textures.RightArrow = content.Load<Texture2D>("Textures\\RightArrow");
            Textures.LeftArrow = content.Load<Texture2D>("Textures\\LeftArrow");
            Textures.Placeholder = content.Load<Texture2D>("Textures\\Placeholder");
            Textures.Placeholder2 = content.Load<Texture2D>("Textures\\Placeholder2");
            Textures.Placeholder3 = content.Load<Texture2D>("Textures\\Placeholder3");

            Textures.TextBox = content.Load<Texture2D>("Textures\\TextBox");
            Textures.AttackBox = content.Load<Texture2D>("Textures\\maniabox");
            Textures.IntroBG = content.Load<Texture2D>("Textures\\Intro");
            Textures.TimingCircle = content.Load<Texture2D>("Textures\\TimingCircle");
            Textures.AttackCircle = content.Load<Texture2D>("Textures\\AttackCircle");

            Loser.LoseBG = content.Load<Texture2D>("Textures\\Dead\\LoserBG");
            Winner.WinBG = content.Load<Texture2D>("Textures\\Win\\Win");

            

            BossMenu.Menu = content.Load<Texture2D>("Textures\\BossMenu\\Menu");
            Bosses.PauseOverlay = content.Load<Texture2D>("Textures\\Bosses\\PauseOverlay");
            Bosses.Boss1.Boss = content.Load<Texture2D>("Textures\\Bosses\\Boss1\\AcidBoss");

            Bosses.Boss2.IceBoss = content.Load<Texture2D>("Textures\\Bosses\\Boss2\\IceBoss");
            Bosses.Boss3.MagmaBoss= content.Load<Texture2D>("Textures\\Bosses\\Boss3\\MagmaBoss");






            Player.PlayerModel = content.Load<Texture2D>("Textures\\Player\\Player"); 




            Message.Font = content.Load<SpriteFont>("MessageFont"); // idk why this here but who cares
            Message.SlightlyBiggerFont = content.Load<SpriteFont>("SlightlyBiggerFont"); // 

            Message.BigFont = content.Load<SpriteFont>("BigFont"); // 


            SubMenu.Menu = content.Load<Texture2D>("Textures\\SubMenu\\SubMenuBG");
            SubMenu.Inventory = content.Load<Texture2D>("Textures\\SubMenu\\Inventory\\InvStorage");
            SubMenu.SelectionHighlightbox = content.Load<Texture2D>("Textures\\SubMenu\\Inventory\\Highlightedbox");
            SubMenu.GreenSword = content.Load<Texture2D>("Textures\\Items\\SwordGreen"); // OK sorry but this naming convention is terrible
            SubMenu.OrangeSword = content.Load<Texture2D>("Textures\\Items\\SwordOrange");
            SubMenu.BlueSword = content.Load<Texture2D>("Textures\\Items\\SwordBlue");
            SubMenu.font = content.Load<SpriteFont>("InvFont");

            ShopMenu.Menu = content.Load<Texture2D>("Textures\\SubMenu\\Shop\\Shop"); // OK sorry but this naming convention is terrible
            ShopMenu.GreenBox = content.Load<Texture2D>("Textures\\SubMenu\\Shop\\green box");
            ShopMenu.PurpleBox = content.Load<Texture2D>("Textures\\SubMenu\\Shop\\purple box");
            ShopMenu.X = content.Load<Texture2D>("Textures\\SubMenu\\Shop\\XMark");
        }
    }
}
