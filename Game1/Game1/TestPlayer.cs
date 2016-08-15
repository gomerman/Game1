using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Game1
{

    public class TestPlayer
    {
        public int hp { get; set; }
        public int ammo { get; set; }
        public Vector2 aimPosition { get; set; }
        public Texture2D textureAim { get; set; }
        public TestPlayer()
        {
            hp = 20;
            ammo = 6;
            aimPosition = new Vector2(0);
        }


    }
}