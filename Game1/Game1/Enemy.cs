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
        public Texture2D textureEnemy { get; set; }

        public Rectangle rectangle { get
            {
                return new Rectangle((int)X, (int)Y, textureEnemy.Width, textureEnemy.Height);
            }
        }
        public Enemy(float _x, float _y)
        {
            hp = 10;
            X = _x;
            Y = _y;
            damage = 4;
            
        }

    }
}