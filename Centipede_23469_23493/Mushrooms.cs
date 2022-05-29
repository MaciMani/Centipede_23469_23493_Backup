using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede_23469_23493
{
    class Mushrooms
    {
        bool isInstantiated;
        SpriteBatch spriteBatch;
        Texture2D mushTexture;
        ContentManager content;
        GraphicsDevice graphicsDevice;
        Vector2 mushPos;
        Random rand = new Random();
        Rectangle mushHitbox;

        public Mushrooms(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch;
            this.graphicsDevice = graphicsDevice;
            mushTexture = content.Load<Texture2D>("Content/Cogumelo");
            mushPos = new Vector2(rand.Next(450), rand.Next(450));
            Point p = new Point(mushTexture.Width, mushTexture.Height);
            mushHitbox = new Rectangle(mushPos.ToPoint(), p);
        }

        public Rectangle getHitbox()
        {
            return this.mushHitbox;
        }
        public bool colisao(Rectangle hitbox)
        {
            if (mushHitbox.Intersects(hitbox))
                return true;
            else return false;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            spriteBatch.Draw(mushTexture, mushPos, Color.White);
        }
    }
}
