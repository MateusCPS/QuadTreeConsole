using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadTree
{
    abstract class Objects
    {
        protected Vector2 position, destiny, dimensions;
        protected float speed;
        protected Rectangle rectangle;
        protected bool isColliding = false;
        protected Objects[] obj;

        protected virtual void Movement(float speed, Vector2 destiny, GameTime gameTime)
        {
            Vector2 direction = destiny - position;
            float distance = direction.Length();

            if (distance > 0)
            {
                direction.Normalize();
                Vector2 displacement = direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (displacement.Length() > distance)
                {
                    position = destiny;
                }
                else
                {
                    position += displacement;
                }
            }
        }

        public virtual Rectangle GetBounds()
        {
            rectangle = new Rectangle((int)(this.position.X), (int)(this.position.Y), (int)this.dimensions.X, (int)this.dimensions.Y);
            return rectangle;
        }
    }
}
