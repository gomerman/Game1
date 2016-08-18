using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Enemy
    {
        public int hp { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Texture2D textureEnemy { get; set; }

        public Color color_of_attack_info;
        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)X, (int)Y, textureEnemy.Width, textureEnemy.Height);
            }
        }

        private int damage { get; set; }
        private float attackSpeed { get; set; } // One attack in N sec
        private float attackDelay { get; set; }
        private string enemy_shot_str = "PIU-PIU!!!";


        public Enemy(float _x, float _y)
        {
            System.Random rand = new System.Random();
            attackSpeed = rand.Next(4, 8);
            attackDelay = attackSpeed;
            hp = 10;
            X = _x;
            Y = _y;
            damage = 1;

            color_of_attack_info = Color.Green;
            color_of_attack_info.A = 0;
        }

        public void Update(float elapsedTime)
        {
            attackDelay -= elapsedTime;
            if (attackDelay <= 0)
            {
                TestPlayer.hp -= damage;
                attackDelay = attackSpeed;
                makeVisibleFont();
            }
            if (attackDelay <= attackSpeed - 1)
                makeInvisibleFont();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureEnemy, new Vector2(X, Y));
            spriteBatch.DrawString(Game1.generalFont, enemy_shot_str, new Vector2(X, Y), color_of_attack_info);
        }
        private void makeVisibleFont()
        {
            color_of_attack_info.A = 255;
        }
        private void makeInvisibleFont()
        {
            color_of_attack_info.A = 0;
        }
    }
}