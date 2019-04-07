using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FreeFall.Shared.Utilities;
using System.Collections.Generic;

namespace FreeFall.Shared.Entities
{
    public class Cloud : Entity
    {
        private Random random;

        private string CLOUD_PATH_1 = "Images/Cloud_1", CLOUD_PATH_2 = "Images/Cloud_2", CLOUD_PATH_3 = "Images/Cloud_3";
        private int CLOUD_VELOCITY = 10;
        private Texture2D texture2, texture3;
        private int cloudNum;

        private static List<Cloud> clouds = new List<Cloud>();


        public Cloud()
        {
            random = new Random();
            cloudNum = random.Next(3);
            clouds.Add(this);
            EntityType = EntityTypes.CLOUD;
            boundingRectangle = new Rectangle();
        }

        public override void Draw(GameTime gameTime)
        {
            switch(cloudNum)
            {
                case 0: spriteBatch.Draw(texture, boundingRectangle, Color.White); break;
                case 1: spriteBatch.Draw(texture2, boundingRectangle, Color.White); break;
                case 2: spriteBatch.Draw(texture3, boundingRectangle, Color.White); break;
            }
        }

        public override void Initialize()
        {
            switch(cloudNum)
            {
                case 0: boundingRectangle.Width = texture.Width; boundingRectangle.Height = texture.Height; break;
                case 1: boundingRectangle.Width = texture2.Width; boundingRectangle.Height = texture2.Height; break;
                case 2: boundingRectangle.Width = texture3.Width; boundingRectangle.Height = texture3.Height; break;
            }
            boundingRectangle.X = random.Next(UtilityManager.SCREEN_WIDTH + boundingRectangle.Width) - boundingRectangle.Width;
            boundingRectangle.Y = random.Next(UtilityManager.SCREEN_HEIGHT);
            Console.WriteLine("Screen Height: " + UtilityManager.SCREEN_HEIGHT);
            //for(int i = 1; i < clouds.Count; i++)
            //{
            //    while(boundingRectangle.Intersects(clouds[i].BoundingRectangle))
            //    {
            //        boundingRectangle.X = random.Next(UtilityManager.SCREEN_WIDTH + boundingRectangle.Width) - boundingRectangle.Width;
            //        boundingRectangle.Y = random.Next(UtilityManager.SCREEN_HEIGHT + boundingRectangle.Height) - boundingRectangle.Height;
            //    }
            //}
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(CLOUD_PATH_1);
            texture2 = content.Load<Texture2D>(CLOUD_PATH_2);
            texture3 = content.Load<Texture2D>(CLOUD_PATH_3);
            Console.WriteLine("Hey bb");
        }

        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);
            position.Y -= (float) (CLOUD_VELOCITY * gameTime.ElapsedGameTime.TotalSeconds);
            boundingRectangle.Y = (int) position.Y;
        }
    }
}
