using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    class Player : Objects
    {
        
        private Texture2D player;
        private Vector2 dimensions;

        public Player(string path, Vector2 position, Vector2 dimensions) {

            player = Manager.contentManager.Load<Texture2D>(path);
            this.speed = 500;
            this.position = position;
            this.destiny = position;
            this.dimensions = dimensions;
        }

        public void Movement(GameTime gameTime)
        {
            Input();
            base.Movement(this.speed, this.destiny, gameTime);
        }

        private Vector2 Input()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                this.destiny.Y--;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                this.destiny.X--;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                this.destiny.Y++;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                this.destiny.X++;
            }

            return this.destiny;
        }

        public void Update(GameTime gameTime) {
            Movement(gameTime);
        }

        public void Draw()
        {
            if(player != null) {
                Manager.spriteBatch.Draw(player, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, 0.0f, new Vector2(player.Bounds.Width/2, player.Bounds.Height/2), new SpriteEffects(), 0);
            }
        }
    }
}
