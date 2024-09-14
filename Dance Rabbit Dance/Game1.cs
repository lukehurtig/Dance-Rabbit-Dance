using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Dance_Rabbit_Dance
{
    public class Game1 : Game
    {
        Random rnd = new Random();
        const int VIEWPORT_WIDTH = 840;
        const int VIEWPORT_HEIGHT = 480;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D logo;
        private List<Arrow> propArrows;
        private List<Arrow> arrows;
        private Wabbit wabbit = new Wabbit();
        private Dancer dancer = new Dancer();
        private Dancer dancer1 = new Dancer();
        private SpriteFont _font;

        private string _text = "Press Esc or Back Button to Exit\n" +
            "Press Enter or Start to Play!";
        private int score = 0;
        private bool start = false;
        private float initialInterval = 2.0f;
        private float minInterval = 0.2f;
        private float decreaseRate = 0.97f;
        private float currentInterval;
        private double launchTime = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            propArrows = new List<Arrow>()
            {

                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, VIEWPORT_HEIGHT - 60), Direction.Right, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), VIEWPORT_HEIGHT - 60), Direction.Up, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), VIEWPORT_HEIGHT - 60), Direction.Left, true),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), VIEWPORT_HEIGHT - 60), Direction.Down, true),
            };

            arrows = new List<Arrow>()
            {
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -120), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -120), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -120), Direction.Right, false),
                new Arrow(new Vector2(VIEWPORT_WIDTH / 8, -120), Direction.Right, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -120), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -120), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -120), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 3 / 8), -120), Direction.Up, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -120), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -120), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -120), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 5 / 8), -120), Direction.Left, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -120), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -120), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -120), Direction.Down, false),
                new Arrow(new Vector2((VIEWPORT_WIDTH * 7 / 8), -120), Direction.Down, false),
            };

            wabbit.Position = new Vector2(VIEWPORT_WIDTH / 2, VIEWPORT_HEIGHT * 0.66f);
            dancer.Position = new Vector2(VIEWPORT_WIDTH * 0.25f, VIEWPORT_HEIGHT / 2);
            dancer1.Position = new Vector2(VIEWPORT_WIDTH * 0.75f, VIEWPORT_HEIGHT / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach ( Arrow arrow in propArrows ) arrow.LoadContent(Content);
            foreach ( Arrow arrow in arrows ) arrow.LoadContent(Content);
            wabbit.LoadContent(Content);
            dancer.LoadContent(Content);
            dancer1.LoadContent(Content);
            background = Content.Load<Texture2D>("Proj0bg-1.png");
            logo = Content.Load<Texture2D>("DRD");
            _font = Content.Load<SpriteFont>("Bangers");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (!start)
            {
                score = 0;
                if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    start = true;
                    currentInterval = initialInterval;
                }
            }
            else
            {
                launchTime += gameTime.ElapsedGameTime.TotalSeconds;

                if (launchTime >= currentInterval)
                {
                    int random = rnd.Next(0, 16);
                    if (!arrows[random].Active) arrows[random].Active = true;
                    currentInterval = Math.Max(minInterval, currentInterval * decreaseRate);
                    launchTime = 0;
                }
            }

            foreach (var arrow in arrows)
            {
                if (arrow.Active)
                {
                    foreach (var prop in propArrows)
                    {
                        if (arrow.Bounds.CollidesWith(prop.Bounds))
                        {
                            if (arrow.Dir == Direction.Right) 
                            {
                                if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed
                                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
                                {
                                    arrow.Reset();
                                    score += 10;
                                    UpdateScores();
                                }
                            }
                            else if (arrow.Dir == Direction.Left)
                            {
                                if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
                                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
                                {
                                    arrow.Reset();
                                    score += 10;
                                    UpdateScores();
                                }
                            }
                            else if (arrow.Dir == Direction.Up)
                            {
                                if (Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed
                                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
                                {
                                    arrow.Reset();
                                    score += 10;
                                    UpdateScores();
                                }
                            }
                            else if (arrow.Dir == Direction.Down)
                            {
                                if (Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed
                                || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
                                {
                                    arrow.Reset();
                                    score += 10;
                                    UpdateScores();
                                }
                            }
                        }
                    }
                }
                arrow.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), new Rectangle(0, 0, 800, 480), Color.White);
            dancer.Draw(gameTime, _spriteBatch);
            dancer1.Draw(gameTime, _spriteBatch);
            wabbit.Draw(gameTime, _spriteBatch);
            foreach (Arrow arrow in propArrows) arrow.Draw(gameTime, _spriteBatch);
            foreach (Arrow arrow in arrows) arrow.Draw(gameTime, _spriteBatch);
            if (!start) _spriteBatch.Draw(logo, new Vector2(VIEWPORT_WIDTH * 0.5f - 220, 20), new Rectangle(0, 0, 400, 213), Color.White);
            if (!start) _spriteBatch.DrawString(_font, "Press Esc or Back Button to Exit\nPress Enter or Start to Play!", new Vector2(VIEWPORT_WIDTH * 0.5f - 170, VIEWPORT_HEIGHT * 0.74f), Color.WhiteSmoke);
            if (start) _spriteBatch.DrawString(_font, $"Score: {score}", new Vector2(20, 20), Color.Gold);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void UpdateScores ()
        {
            foreach ( Arrow arrow in arrows ) arrow.Score = score;
            wabbit.Score = score;
            dancer.Score = score;
            dancer1.Score = score;
        }
    }
}
