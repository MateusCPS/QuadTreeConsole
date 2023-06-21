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
    class StaticObject : Objects
    {
        Rectangle rectangle;
        Texture2D texture;
        Random random = new Random();
        Vector2 dimensions;
        bool staticObject;
        
        public  StaticObject(Vector2 position) {
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
        
        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw()
        {
            Manager.spriteBatch.Draw(texture, rectangle, Color.Yellow);
        }
    }
}
