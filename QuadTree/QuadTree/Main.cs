using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace QuadTree
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player _player;
        Objects[] _objects;
        DinamicObject[] _dinamicObject;
        StaticObject[] _staticObjects;
        int maxGameObject = 50;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Manager.contentManager = this.Content;
            Manager.spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player("2d\\test", new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2), new Vector2(10, 10));
            _dinamicObject = new DinamicObject[maxGameObject];
            _staticObjects = new StaticObject[maxGameObject];
            _objects = new Objects[maxGameObject * 2 + 1];

            for (int i = 0; i < maxGameObject; i++)
            {
                _dinamicObject[i] = new DinamicObject(new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
                _staticObjects[i] = new StaticObject(new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update(gameTime);
            for (int i = 0; i < maxGameObject; i++)
            {
                _dinamicObject[i].Update(gameTime);
                _staticObjects[i].Update(gameTime);

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Manager.spriteBatch.Begin();

            _player.Draw();
            for (int i = 0; i < maxGameObject; i++)
            {
                _dinamicObject[i].Draw();
                _staticObjects[i].Draw();
            }

            Manager.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}