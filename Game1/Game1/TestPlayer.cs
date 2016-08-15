using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;


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

        public void shot(TouchCollection touches, ref List<Enemy> enemysList)
        {
            aimPosition = touches[0].Position - (new Vector2(textureAim.Width, textureAim.Height) / 2);
            //ammo--;
            if (touches[0].State == TouchLocationState.Released)
                foreach (var enemy in enemysList)
                {
                    Point touch_point = new Point((int)touches[0].Position.X, (int)touches[0].Position.Y);
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


    }
}