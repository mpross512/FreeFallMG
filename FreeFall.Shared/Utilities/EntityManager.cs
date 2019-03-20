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
                if (player.BoundingRectangle.Contains(entity.BoundingRectangle))
                    player.HandleCollision(entity);
            }
        }

        public void Draw(GameTime gameTime)
        {
            player.Draw(gameTime);
            foreach (Entity entity in entities)
                entity.Draw(gameTime);
        }
    }
}
