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
        protected Vector2 position, destiny;
        protected float speed;

        protected virtual void Movement(float speed, Vector2 destiny, GameTime gameTime)
        {
            Vector2 direction = destiny - position;
            float distance = direction.Length();

            if (distance > 0){
                direction.Normalize();
                Vector2 displacement = direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(displacement.Length() > distance)
                {
                    position = destiny;
                }
                else
                {
                    position += displacement;
                }
            }
        }

        protected virtual void OnCollisionEnter(Rectangle rectangle)
        {
            rectangle.Intersects(rectangle);
        }

        protected virtual bool OnCollisionExit()
        {
            bool offCollision = false;
            return offCollision;
        }

        protected virtual void OnCollisionStay()
        {

        }
    }
}
