using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
namespace Game1
{
  
    public class Game1 : Game
    {
        //static public int characterType;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textureBackground;

        TestPlayer player;
        List<Enemy> enemysList;

        TouchCollection touches;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            enemysList = new List<Enemy>();
            player = new TestPlayer();
            enemysList.Add(new Enemy(20, 250));
            enemysList.Add(new Enemy(220, 250));
            enemysList.Add(new Enemy(473, 250));

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textureBackground = Content.Load<Texture2D>("BackgroundBar");
            player.textureAim = Content.Load<Texture2D>("aim");
            foreach (var enemy in enemysList)
                enemy.textureEnemy = Content.Load<Texture2D>("enemy");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            touches = TouchPanel.GetState();
            
            if (touches.Count == 1)
            {
                
                player.shot(touches, ref (enemysList));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
            spriteBatch.Draw(textureBackground, new Rectangle(0, 0, textureBackground.Width, textureBackground.Height), Color.White);
            foreach (var enemy in enemysList)
                spriteBatch.Draw(enemy.textureEnemy, new Vector2(enemy.X, enemy.Y));
            spriteBatch.Draw(player.textureAim, player.aimPosition);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
