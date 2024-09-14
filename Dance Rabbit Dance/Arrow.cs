using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Dance_Rabbit_Dance.Collisions;
using System.Reflection.Metadata;

namespace Dance_Rabbit_Dance
{
    public enum Direction
    {
        Right,
        Up,
        Left,
        Down
    }

    public class Arrow
    {
        private Texture2D texture;

        private Vector2 position;

        public Direction Dir;

        private bool prop;

        private BoundingRectangle bounds;

        public bool Active = false;

        public int Score = 0;

        public Color Color { get; set; } = Color.White;

        public BoundingRectangle Bounds => bounds;

        public Arrow(Vector2 Position, Direction Dir, bool Prop)
        {
            this.position = Position;
            this.Dir = Dir;
            this.prop = Prop;
            this.bounds = new BoundingRectangle(position, 40, 40);
        }

        public void LoadContent(ContentManager content)
        {
            if(prop)
            {
                texture = Dir switch
                {
                    Direction.Up => content.Load<Texture2D>("UP"),
                    Direction.Left => content.Load<Texture2D>("Left"),
                    Direction.Down => content.Load<Texture2D>("Down"),
                    _ => content.Load<Texture2D>("Right"),
                };
            }

            else texture = content.Load<Texture2D>("DirectionArrows");
        }

        public void Update(GameTime gameTime)
        {
            if (Active)
            {
                position.Y += (3 + Score / 10);        
                bounds.Y = position.Y;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var source = new Rectangle(0, 0, 80, 80);
            if (!prop) source = Dir switch
            {
                Direction.Up => new Rectangle(0, 80, 80, 80),
                Direction.Left => new Rectangle(0, 160, 80, 80),
                Direction.Down => new Rectangle(0, 240, 80, 80),
                _ => new Rectangle(0, 0, 80, 80),
            };
            //spriteBatch.Draw(texture, Position, source, Color.White);
            spriteBatch.Draw(texture, position, source, Color.White, 0, new Vector2(49, 49), 1.5f, SpriteEffects.None, 0);
        }

        public void Reset()
        {
            bounds.Y = -120;
            position.Y = -120;
            Active = false;
        }
    }
}