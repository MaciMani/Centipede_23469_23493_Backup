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
    class Nave
    {
        Tiro tiro;
        SpriteBatch spriteBatch;
        KeyboardManager Km;
        Vector2 playerpos;
        const int playerVel = 200;
        Texture2D naveTexture;
        GraphicsDevice graphicsDevice;
        ContentManager content;
        SoundEffect bulletsound;



        public List<Tiro> tiros;

        public Nave(KeyboardManager km, SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.content = content;
            tiros = new List<Tiro>();
            this.Km = km;
            this.spriteBatch = spriteBatch; 
            this.graphicsDevice = graphicsDevice;
            naveTexture = content.Load<Texture2D>("Content/Nave");
            bulletsound = content.Load<SoundEffect>("Content/Shooting_Sound");
            playerpos = new Vector2(0, naveTexture.Height / 2);

        }

        public void Movimento(GameTime gameTime)
        {

            foreach (Tiro b in tiros)
                b.Update(gameTime);

            if (Km.isKeyHeld(Keys.D))
            {
                playerpos = playerpos + new Vector2(1, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds * playerVel;
            }
            if (Km.isKeyHeld(Keys.A))
            {
                playerpos = playerpos + new Vector2(-1, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds * playerVel;
            }

        }

        public void Dispara(GameTime gameTime)
        {
            if (Km.IsKeyPressed(Keys.Space))
            {
                tiros.Add(new Tiro(Km, spriteBatch, content, graphicsDevice, this));
                bulletsound.Play();
            }
        }

        public void Update(GameTime gameTime)
        {
            Movimento(gameTime);
            Dispara(gameTime);
        }

        public void Draw()
        {
            spriteBatch.Draw(naveTexture, ConvertToDrawPos(playerpos, naveTexture), Color.White);


            foreach (Tiro b in tiros)
                b.Draw();

        }

        Vector2 ConvertToDrawPos(Vector2 pos)
        {
            return new Vector2(graphicsDevice.Viewport.Width / 2 + pos.X, graphicsDevice.Viewport.Height - pos.Y);
        }

        Vector2 ConvertToDrawPos(Vector2 pos, Texture2D nave)
        {
            pos.X -= nave.Width / 2;
            pos.Y += nave.Height / 2;
            return ConvertToDrawPos(pos);
        }

        public Vector2 GivePos()
        {
            return (new Vector2(playerpos.X, playerpos.Y));
        }
    }
}
