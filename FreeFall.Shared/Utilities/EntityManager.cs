using System;
using System.Collections.Generic;
using FreeFall.Shared.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Shared.Utilities
{
    public class EntityManager
    {

        private Player player;
        public List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
            player = new Player();
        }

        public void Initialize()
        {
            entities.Add(new Drone());
            entities.Add(new Drone());
            entities.Add(new Drone());
            foreach (Entity entity in entities)
                entity.Initialize();
            player.Initialize();
        }

        public void LoadContent(ContentManager content)
        {
            player.LoadContent(content);
            foreach (Entity entity in entities)
                entity.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
                if (player.BoundingRectangle.Intersects(entity.BoundingRectangle))
                    player.HandleCollision(entity);
            }
            //Console.WriteLine("\nDrone 1 Distance: {0}\nDrone 2 Distance: {1}\nDrone 3 Distance: {2}", 
                //entities[1].BoundingRectangle.X - entities[0].BoundingRectangle.X, 
                //entities[2].BoundingRectangle.X - entities[1].BoundingRectangle.X, 
                //entities[0].BoundingRectangle.X - entities[2].BoundingRectangle.X);
        }

        public void Draw(GameTime gameTime)
        {
            player.Draw(gameTime);
            foreach (Entity entity in entities)
                entity.Draw(gameTime);
        }
    }
}
