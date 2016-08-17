using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;


namespace Game1
{

    public class TestPlayer
    {
        static public int hp { get; set; }
        public int ammo { get; set; }
        public Vector2 aimPosition { get; set; }
        public Texture2D textureAim { get; set; }

        private string hp_str { get; set; }
        private string curr_ammo_str { get; set; }
        public TestPlayer()
        {
            hp = 20;
            ammo = 6;
            aimPosition = new Vector2(0);
            hp_str = hp + " HP";
            curr_ammo_str = "Ammo: " + ammo + " / 6";
        }

        public void shot(TouchCollection touches, ref List<Enemy> enemysList)
        {
            aimPosition = touches[0].Position - (new Vector2(textureAim.Width, textureAim.Height) / 2);
            ammo--;

            if (touches[0].State == TouchLocationState.Released)
                foreach (var enemy in enemysList)
                {
                    Point touch_point = new Point((int)aimPosition.X, (int)aimPosition.Y);
                    if (enemy.rectangle.Intersects(new Rectangle(touch_point, new Point(1, 1))))
                    {

                        enemy.hp -= 5;
                        if (enemy.hp <= 0)
                        {
                            enemysList.Remove(enemy);
                            return;
                        }
                    }


                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.generalFont, hp_str, new Vector2(20, 700), Color.Red);
            spriteBatch.DrawString(Game1.generalFont, curr_ammo_str, new Vector2(400, 700), Color.Red);

            spriteBatch.Draw(textureAim, aimPosition);
        }

    }
}