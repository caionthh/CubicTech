using CubicTechGame.ResourcesManager;
using CubicTechGame.SceneManager.ViewResources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicTechGame.WorldGenerator
{
    public class Chunk
    {
        //Chunk Size
        private int sizeX = 100, sizeY = 1000;

        //Chunk Position
        public Vector2 chunkPosition = Vector2.Zero;

        //Block Array
        public Block[,] blocks;

        //Create Chunk
        public void CreateChunk(int seed)
        {
            //Create Chunk
            blocks = new Block[sizeX, sizeY];

            //First Chunk Gen Pass - Create All DefaultBlocks
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Block b = new Block();
                    b.position = new Vector2(i * 16 + chunkPosition.X, j * 16 + chunkPosition.Y);
                    b.rectangle = new Rectangle((int)b.position.X, (int)b.position.Y, 16, 16);
                    blocks[i, j] = b;
                }
            }
        }

        //Draw Chunk
        public void DrawChunk(SpriteBatch spriteBatch, Camera2D camera)
        {
            //Draw Min/Max
            int drawMinX = (int)((camera.position.X - camera.viewport.Width - chunkPosition.X) / 16);
            if (drawMinX < 0) drawMinX = 0;
            int drawMaxX = (int)((camera.position.X  - chunkPosition.X + (camera.viewport.Width * 2)) / 16);
            if (drawMaxX > 100) drawMaxX = 100;
            int drawMinY = (int)((camera.position.Y - camera.viewport.Height) / 16);
            if (drawMinY < 0) drawMinY = 0;
            int drawMaxY = (int)((camera.position.Y + (camera.viewport.Height * 2)) / 16);
            if (drawMaxY > 1000) drawMaxY = 1000;

            //Draw All Elements
            for (int i = drawMinX; i < drawMaxX; i++)
            {
                for (int j = drawMinY; j < drawMaxY; j++)
                {
                    blocks[i, j].Draw(spriteBatch);
                }
            }

        }
    }
}
