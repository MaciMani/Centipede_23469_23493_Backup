using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Centipede_23469_23493
{
    class Tiro
    {
        SpriteBatch spriteBatch;
        KeyboardManager Km;
        Texture2D tiroTexture;
        GraphicsDevice graphicsDevice;
        Vector2 tiroPos;
        const int TiroVel = 150;
        Nave nave;
        Vector2 Size;
        Rectangle TiroHitbox;




        bool isInstantiated = false;

        public Tiro(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice, Nave nave)
        {
            this.Km = km;

            this.spriteBatch = spriteBatch; this.graphicsDevice = graphicsDevice;
            tiroTexture = content.Load<Texture2D>("Content/Tiro");
            tiroPos = nave.GivePos();
            isInstantiated = true;
            Size = new Vector2(0.2f, tiroTexture.Height * 0.2f / tiroTexture.Width);
            Point p = new Point(tiroTexture.Width, tiroTexture.Height);
            TiroHitbox = new Rectangle(tiroPos.ToPoint(), p);

        }
        public void Update(GameTime gameTime)
        {
            if (!isInstantiated) return;
            tiroPos.Y += 1 * (float)gameTime.ElapsedGameTime.TotalSeconds * TiroVel;
            TiroHitbox.Location = tiroPos.ToPoint();
        }

        public void Draw()
        {
            if (!isInstantiated) return;

            spriteBatch.Draw(tiroTexture, ConvertToDrawPos(tiroPos), Color.White);

        }

        public bool colisao(Rectangle hitbox)
        {
            if (TiroHitbox.Intersects(hitbox))
                return true;
            else return false;
        }


        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }




    }
}
