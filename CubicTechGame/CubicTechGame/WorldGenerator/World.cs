using CubicTechGame.SceneManager.ViewResources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubicTechGame.WorldGenerator
{
    public class World
    {
        //List Chunks
        public List<Chunk> chunks = new List<Chunk>();
        public List<Chunk> chunksInView = new List<Chunk>();
        public List<Rectangle> chunkRectangles = new List<Rectangle>();

        //Seed
        int seed = 0;

        //Create Chunk
        public void CreateChunkAt(Vector2 where)
        {
            Chunk c = new Chunk();
            c.chunkPosition = where;
            c.CreateChunk(seed);
            chunkRectangles.Add(new Rectangle((int)where.X, (int)where.Y, 16 * 100, 16 * 1000));
            chunks.Add(c);
        }

        //Update World
        public void UpdateWorld(GameTime gametime, Camera2D camera)
        {
            //Clear List of chunks
            chunksInView.Clear();
            //Add Chunks in range of view to the update and draw
            foreach (Rectangle r in chunkRectangles)
            {
                if (r.Intersects(new Rectangle((int)camera.position.X - camera.viewport.Bounds.Width, (int)camera.position.Y - camera.viewport.Bounds.Height, camera.viewport.Bounds.Width * 2, camera.viewport.Bounds.Height * 2)))
                    chunksInView.Add(chunks[chunkRectangles.IndexOf(r)]);
            }


        }

        //Draw World
        public void DrawWorld(SpriteBatch spriteBatch, Camera2D camera)
        {
            foreach (Chunk c in chunksInView)
            {
                c.DrawChunk(spriteBatch, camera);
            }
        }

    }
}
