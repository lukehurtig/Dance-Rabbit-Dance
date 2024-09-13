using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Dance_Rabbit_Dance
{
    public class Game1 : Game
    {
        const int VIEWPORT_WIDTH = 840;
        const int VIEWPORT_HEIGHT = 480;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Arrow> arrows;
        private Wabbit wabbit = new Wabbit();
        private Dancer dancer = new Dancer();
        private Dancer dancer1 = new Dancer();
        private SpriteFont _font;
        private int score = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            arrows = new List<Arrow>()
            {
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, VIEWPORT_WIDTH - 60), Direction.Right, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), VIEWPORT_WIDTH - 60), Direction.Up, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), VIEWPORT_WIDTH - 60), Direction.Left, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), VIEWPORT_WIDTH - 60), Direction.Down, true),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -40), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -40), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -40), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -40), Direction.Right, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -40), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -40), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -40), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -40), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -40), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -40), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -40), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -40), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -40), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -40), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -40), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -40), Direction.Down, false),
            };

            wabbit.Position = new Vector2(VIEWPORT_WIDTH / 2, VIEWPORT_HEIGHT * 0.66f);
            dancer.Position = new Vector2(VIEWPORT_WIDTH * 0.25f, VIEWPORT_HEIGHT/2);
            dancer1.Position = new Vector2(VIEWPORT_WIDTH * 0.75f, VIEWPORT_HEIGHT / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach ( Arrow arrow in arrows )
            {
                arrow.LoadContent(Content);
            }

            wabbit.LoadContent(Content);
            dancer.LoadContent(Content);
            dancer1.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
