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

namespace CubicTechGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CubicTech : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        

        public CubicTech()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GlobalResources.resourceDictionary.Add("DefaultBlock", Texture2D.FromStream(graphics.GraphicsDevice, new FileStream("Content/DefaultBlock.png", FileMode.Open)));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        IndexedInput input = new IndexedInput();
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Update Input
            input.Update(gameTime);

            //Move Camera
            if (input.currentKeyboard.IsKeyDown(Keys.W))
                camera.position.Y--;
            if (input.currentKeyboard.IsKeyDown(Keys.S))
                camera.position.Y++;
            if (input.currentKeyboard.IsKeyDown(Keys.A))
                camera.position.X--;
            if (input.currentKeyboard.IsKeyDown(Keys.D))
                camera.position.X++;


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        //Draw

        Camera2D camera = new Camera2D();
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, camera.GetCameraMatrix(this.graphics.GraphicsDevice.Viewport));
            spriteBatch.Draw((Texture2D)GlobalResources.resourceDictionary["DefaultBlock"], Vector2.Zero, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
