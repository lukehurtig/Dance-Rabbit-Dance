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

        private double directionTimer;

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

            //Update animation frame
            if (animationTimer > (0.05 + (.5 - (Score + 1 / 2 * Score))))
            {
                animationFrame++;
                if (animationFrame > 3) animationFrame = 0;
                animationTimer -= (0.05 + (.5 - (Score + 1 / 2 * Score)));
            }

            var source = new Rectangle(animationFrame * 90, 0, 90, 90);
            //spriteBatch.Draw(texture, Position, source, Color.White);
            spriteBatch.Draw(texture, Position, source, Color.White, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
        }
    }
}
