using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Centipede_23469_23493
{
    class SpawnerC
    {
     
        SpriteBatch spriteBatch;
        Texture2D centTexture;
        GraphicsDevice graphicsDevice;
        ContentManager content;



        public List<Centopeia> centopeia;
        public SpawnerC(SpriteBatch spriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.spriteBatch = spriteBatch; 
            this.graphicsDevice = graphicsDevice; 
            this.content = content;
            centTexture = content.Load<Texture2D>("Content/Bixo");

            centopeia = new List<Centopeia>();

            spawncent();

        }

        public void spawncent()
        {

            for (int x = 0; x < 10; x++)
            {
                Centopeia c = new Centopeia(spriteBatch, content, graphicsDevice);
                c.position.X += x * 20;
                centopeia.Add(c);
            }
        }
        public void Update(GameTime gameTime)
        {

            foreach (Centopeia c in centopeia)
            {

                c.Movimento(gameTime);

            }

        }
        public void Draw()
        {
            foreach (Centopeia c in centopeia)
            {
                c.Draw();
            }
        }
    }
}
