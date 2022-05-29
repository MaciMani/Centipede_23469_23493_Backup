﻿using System;
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
    class Centopeia
    {
        SpriteBatch spriteBatch;
        Texture2D centTexture;
        GraphicsDevice graphicsDevice;
        ContentManager content;
        SoundEffect centsound;
        Vector2 velocity;
        Vector2 position;
        Rectangle centHitbox;

        public Centopeia(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.content = content;
            this.spriteBatch = spriteBatch; 
            this.graphicsDevice = graphicsDevice;
            this.velocity = velocity;
            centTexture = content.Load<Texture2D>("Content/Bixo");
            //centsound = content.Load<SoundEffect>("Content/Shooting_Sound");

        }

        public Rectangle gethitbox()
        {
            return this.centHitbox;
        }

        public void Movimento(GameTime gameTime)
        {            
            position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 200;
            centHitbox.Location = position.ToPoint();
            if (position.X >= graphicsDevice.Viewport.Width / 2)
            {
                this.position += new Vector2(0, 1);
                this.velocity = velocity * -1;
            }
            if (position.X < -graphicsDevice.Viewport.Width / 2)
            {
                this.position += new Vector2(0, 1);
                this.velocity = velocity * -1;
            }
        }

        public void Update(GameTime gameTime)
        {
            Movimento(gameTime);
            GivePos();
        }

        public void Draw()
        {
            
            spriteBatch.Draw(centTexture, ConvertToDrawPos(position, centTexture), Color.White);

        }

        Vector2 ConvertToDrawPos(Vector2 pos, Texture2D centopeia)
        {
            pos.X -= centopeia.Width / 2;
            pos.Y += centopeia.Height / 2;
            return position;
        }

        public Vector2 GivePos()
        {
            return (new Vector2(position.X, position.Y));
        }
    }
}
