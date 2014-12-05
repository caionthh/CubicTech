#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion
using CubicTechGame.ResourcesManager;
using CubicTechGame.SceneManager;
using System.IO;
using CubicTechGame.SceneManager.ViewResources;
using CubicTechGame.InputManager;
using CubicTechGame.SceneManager.GameScenes;

namespace CubicTechGame
{
    //Main Game
    public class CubicTech : Game
    {
        //Resources
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game Scenes
        GameState gameState = GameState.World;
        WorldScene worldScene;

        public CubicTech()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Initialize
        protected override void Initialize()
        {
            //Mouse
            IsMouseVisible = true;

            base.Initialize();
        }

        //Load
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GlobalResources.viewport = this.graphics.GraphicsDevice.Viewport;
            GlobalResources.resourceDictionary.Add("DefaultBlock", Texture2D.FromStream(graphics.GraphicsDevice, new FileStream("Content/DefaultBlock.png", FileMode.Open)));
            GlobalResources.resourceDictionary.Add("FontArial", Content.Load<SpriteFont>("Fonts/Arial"));

            //Scenes
            worldScene = new WorldScene(graphics, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update Scenes
            if (gameState == GameState.World)
            {
                worldScene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        //Draw
        protected override void Draw(GameTime gameTime)
        {
            //Clear
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Draw Scenes
            if (gameState == GameState.World)
            {
                worldScene.Draw(spriteBatch);
            }

            //FrameRate
            float framerate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.Begin();
            spriteBatch.DrawString((SpriteFont)GlobalResources.resourceDictionary["FontArial"], framerate.ToString(), Vector2.Zero, Color.Red, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
