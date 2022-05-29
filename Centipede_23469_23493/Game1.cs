using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Centipede_23469_23493
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _backgroundTexture;
        Nave nave;
        Centopeia centopeia;
        Colision colision;
        SpawnerC centopeiac;
        KeyboardManager Km;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Km = new KeyboardManager();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Resolução do jogo
            _graphics.PreferredBackBufferWidth = 470; // Width
            _graphics.PreferredBackBufferHeight = 550; // Height
            _graphics.ApplyChanges();

            base.Initialize();

        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here

            _backgroundTexture = Content.Load<Texture2D>("Content/Background");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            nave = new Nave(Km, _spriteBatch, Content, GraphicsDevice);
            centopeia = new Centopeia(_spriteBatch, Content, GraphicsDevice);
            centopeiac = new SpawnerC(_spriteBatch, Content, GraphicsDevice);
            colision = new Colision(nave.tiros,centopeiac.centopeia);
        }

        protected override void Update(GameTime gameTime)
        {
            Km.Update();

            // TODO: Add your update logic here
            nave.Movimento(gameTime);
            nave.Dispara(gameTime);
            centopeia.Movimento(gameTime);
            centopeia.GivePos();
            colision.colision();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            // TODO: Add your drawing code here
            _spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            nave.Draw();
            centopeia.Draw();
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
