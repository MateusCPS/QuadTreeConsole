using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    public enum MovementState
    {
        Idle,
        Right,
        Left,
        Down,
        Up
    }

    class DinamicObject : Objects 
    {
        Rectangle rectangle;
        Texture2D texture;
        Random random = new Random();
        MovementState currentState;
        Vector2 dimensions;
        float aiSpeed;

        public DinamicObject(Vector2 position) {

            currentState = MovementState.Idle;

            this.position = position;
            this.position.X = random.Next((int)position.X);
            this.position.Y = random.Next((int)position.Y);

            this.dimensions = new Vector2();
            this.dimensions.X = random.Next(20);
            this.dimensions.Y = random.Next(20);

            texture = Manager.contentManager.Load<Texture2D>("2d\\test");
            rectangle = new Rectangle((int)(this.position.X), (int)(this.position.Y), (int)this.dimensions.X, (int)this.dimensions.Y);
            this.speed = random.Next(1000);
        }  

        private void Movement(GameTime gameTime)
        {
            base.Movement(this.speed, this.destiny, gameTime);
            rectangle.Location = new Point((int)position.X, (int)position.Y);
        }

        private Vector2 RandomMovement()
        {
            if (random.NextDouble() < 0.02) // Chance de 2% de mudar o estado
            {
                switch (random.Next(4))
                {
                    case 0:
                        currentState = MovementState.Up;
                        break;
                    case 1:
                        currentState = MovementState.Down;
                        break;
                    case 2:
                        currentState = MovementState.Left;
                        break;
                    case 3:
                        currentState = MovementState.Right;
                        break;
                }
            }

            Vector2 newDestination = this.position;

            switch (currentState)
            {
                case MovementState.Up:
                    newDestination.Y--;
                    break;
                case MovementState.Down:
                    newDestination.Y++;
                    break;
                case MovementState.Left:
                    newDestination.X--;
                    break;
                case MovementState.Right:
                    newDestination.X++;
                    break;
            }
            return newDestination;
        }
        
        public void Update(GameTime gameTime)
        {
            this.destiny = RandomMovement();
            Movement(gameTime);
        }


        public void Draw()
        {
            Manager.spriteBatch.Draw(texture, rectangle, null, Color.Gray, 0.0f, new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), new SpriteEffects(), 0);
        }
    }
}
