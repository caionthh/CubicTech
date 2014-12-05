using CubicTechGame.ResourcesManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubicTechGame.WorldGenerator
{
    public class Block
    {
        //Visible
        public bool isVisible = false;

        //Position
        public Vector2 position;

        //Rectangle
        public Rectangle rectangle;

        //Draw
        public virtual void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw((Texture2D)GlobalResources.resourceDictionary["DefaultBlock"], position, Color.White);
        }

    }
}
