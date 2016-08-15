using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Android.Content;
using Java.Util;
namespace Game1
{
    public class Enemy
    {
        public int hp { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int damage { get; private set; }
        public float attackSpeed { get; private set; } // One attack in N sec
        public float attackDelay { get; set; }
        public Texture2D textureEnemy { get; set; }

        public Color color_of_attack_info;
        public Rectangle rectangle { get
            {
                return new Rectangle((int)X, (int)Y, textureEnemy.Width, textureEnemy.Height);
            }
        }
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
        public void makeVisibleFont()
        {
            color_of_attack_info.A = 255;
        }
        public void makeInvisibleFont()
        {
            color_of_attack_info.A = 0;
        }
    }
}