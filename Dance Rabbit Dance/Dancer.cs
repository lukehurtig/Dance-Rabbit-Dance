using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace Dance_Rabbit_Dance
{
    public class Dancer
    {
        private Texture2D texture;

        private double animationTimer;

        private short animationFrame = 0;

        public Vector2 Position;

        public int Score;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("DancingBoy (1)");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            double progressionFactor = (0.05 + (0.2 / (1 + Math.Log((Score / 10) + 1))));
            //Update animation frame
            if (animationTimer > progressionFactor)
            {
                animationFrame++;
                if (animationFrame > 5) animationFrame = 0;
                animationTimer -= progressionFactor;
            }

            var source = new Rectangle(animationFrame * 90, 0, 90, 90);
            //spriteBatch.Draw(texture, Position, source, Color.White);
            spriteBatch.Draw(texture, Position, source, Color.White, 0, new Vector2(57, 57), 1.5f, SpriteEffects.None, 0);
        }
    }
}
