using System;
using System.Collections.Generic;
using FreeFall.Shared.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FreeFall.Shared.Utilities
{
    public class EntityManager
    {


        public List<Entity> entities;

        public EntityManager()
        {
            entities = new List<Entity>();
        }

        public void Initialize()
        {
            entities.Add(new Player());
            foreach (Entity entity in entities)
                entity.Initialize();
        }

        public void LoadContent(ContentManager content)
        {
            foreach (Entity entity in entities)
                entity.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
                entity.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Entity entity in entities)
                entity.Draw(gameTime);
        }
    }
}
