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

        private float gunReloadTime = 1.3f;
        private float time = 0;
        private bool isReloaded = false;
        private int damage;
        private string hp_str { get; set; }
        private string curr_ammo_str { get; set; }
        public TestPlayer()
        {
            hp = 20;
            ammo = 6;
            damage = 5;
            
            aimPosition = new Vector2(0);
            hp_str = hp + " HP";
            curr_ammo_str = "Ammo: " + ammo + " / 6";
        }

        public void shot(TouchCollection touches, ref List<Enemy> enemysList)
        {
            if (isReloaded)
                return;
            
            aimPosition = touches[0].Position - (new Vector2(textureAim.Width, textureAim.Height) / 2);


            if (touches[0].State == TouchLocationState.Released)
            {
                ammo--;
                foreach (var enemy in enemysList)
                {
                    Point touch_point = new Point((int)aimPosition.X, (int)aimPosition.Y);
                    if (enemy.rectangle.Intersects(new Rectangle(touch_point, new Point(1, 1))))
                    {
                        enemy.hp -= damage;
                        if (enemy.hp <= 0)
                        {
                            enemysList.Remove(enemy);
                            break;
                        }
                    }
                }
            }
            time = 0;
            if (ammo == 0)
                isReloaded = true;
          
        }

        public void Update (float elapsedTime)
        {
            time += elapsedTime;
            if (time >= gunReloadTime && isReloaded)
            {
                isReloaded = false;
                ammo = 6;
            }
         
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            hp_str = hp + " HP";
            if (isReloaded)
                curr_ammo_str = "RELOAD";
            else
                curr_ammo_str = "Ammo: " + ammo + " / 6";
            spriteBatch.DrawString(Game1.generalFont, hp_str, new Vector2(20, 700), Color.Red);
            spriteBatch.DrawString(Game1.generalFont, curr_ammo_str, new Vector2(400, 700), Color.Red);

            spriteBatch.Draw(textureAim, aimPosition);
        }

    }
}