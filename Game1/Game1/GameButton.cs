using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace Game1
{
    public class GameButton 
    {
        public delegate void ButtonEnable();
        public event ButtonEnable Eneble;

        private Point location {get; set;}
        private Rectangle rectangle
        {
            get
            {
                return new Rectangle(location.X, location.Y, textureButton.Width, textureButton.Height);
            }
        }

        public Texture2D textureButton { get; set; }
        
        public bool isPressed  { get; set; }
        public bool isReleased { get; set; }
        public bool isEnabled  { get; set; }
       

        public GameButton(int _x, int _y)
        {
            Reset();
            location = new Point(_x, _y);
        }
        public GameButton(Point _location)
        {
            Reset();
            location = _location;
        }
        public void Update (TouchCollection touches)
        {
            if (isEnabled && Eneble != null)
                Eneble();
            if (touches.Count == 0)
                return;
            Point touchLoc = new Point((int) touches[0].Position.X, (int) touches[0].Position.Y);
            if (rectangle.Intersects(new Rectangle(touchLoc, new Point(2, 2))))
            {
                if (touches[0].State == TouchLocationState.Pressed)
                    isPressed = true;
                else if (touches[0].State == TouchLocationState.Released)
                    isReleased = true;
                if (isReleased && isPressed)
                    isEnabled = true;
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureButton, new Vector2(location.X, location.Y));
        }

        public void Reset()
        {
            isPressed  = false;
            isReleased = false;
            isEnabled  = false;
        }
    }
}