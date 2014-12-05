using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CubicTechGame.SceneManager
{
    public class GameScene
    {
        //Graphics
        public GraphicsDeviceManager graphics;
        public ContentManager content;

        //Constructor
        public GameScene(GraphicsDeviceManager g, ContentManager c)
        {
            this.graphics = g;
            this.content = c;
        }

        //Load Content
        public virtual void LoadContent() {


            //Loaded
            this.Loaded = true;
        }

        //Unload
        public virtual void UnloadContent()
        {


            //Loaded
            this.Loaded = false;
        }

        //Update
        public virtual void Update(GameTime gametime)
        {
            DoLoad();
        }

        //Do load
        public bool Loaded { get; private set; }
        public void DoLoad()
        {
            if (!Loaded)
                LoadContent();
        }

        //Draw
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
