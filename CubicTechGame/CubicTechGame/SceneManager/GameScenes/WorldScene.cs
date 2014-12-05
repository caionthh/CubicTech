using CubicTechGame.InputManager;
using CubicTechGame.ResourcesManager;
using CubicTechGame.SceneManager.ViewResources;
using CubicTechGame.WorldGenerator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubicTechGame.SceneManager.GameScenes
{
    public class WorldScene : GameScene
    {
        //Camera
        public Camera2D camera;
        //Keyboard
        public KeyboardInput keyboard;

        //World
        public World world;

        //Construtor
        public WorldScene(GraphicsDeviceManager g, ContentManager c) : base(g, c)
        {
            g.PreferredBackBufferWidth = 800;
            g.PreferredBackBufferHeight = 600;
            g.ApplyChanges();
        }

        //Load
        public override void LoadContent()
        {
            //Create Default Camera
            camera = new Camera2D();
            //Keyboard
            keyboard = new KeyboardInput();

            //World
            world = new World();
            for (int x = 0; x < 2; x++)
                world.CreateChunkAt(new Vector2(x * 16 * 100, 0));

                base.LoadContent();
        }

        //Update
        public override void Update(GameTime gametime)
        {
            //Do Begin Load
            DoLoad();
            //Input
            keyboard.Update(gametime);

            //Move Camera
            if (keyboard.currentKeyboard.IsKeyDown(Keys.W))
                camera.position.Y -= 12;
            if (keyboard.currentKeyboard.IsKeyDown(Keys.S))
                camera.position.Y += 12;
            if (keyboard.currentKeyboard.IsKeyDown(Keys.A))
                camera.position.X -= 12;
            if (keyboard.currentKeyboard.IsKeyDown(Keys.D))
                camera.position.X += 12;

            //World
            world.UpdateWorld(gametime, camera);

        }

        //Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Camera max Boundaries
            if (camera.position.X < camera.viewport.Width / 2)
                camera.position.X = camera.viewport.Width / 2;
            if (camera.position.Y < camera.viewport.Height / 2)
                camera.position.Y = camera.viewport.Height / 2;
            if (camera.position.X > (world.chunks.Count * 16 * 100) - (camera.viewport.Width / 2))
                camera.position.X = (world.chunks.Count * 16 * 100) - (camera.viewport.Width / 2);
            if (camera.position.Y > (16 * 1000) - (camera.viewport.Height / 2))
                camera.position.Y = (16 * 1000) - (camera.viewport.Height / 2);

            //Camera0 Spritebatch
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, camera.GetCameraMatrix(this.graphics.GraphicsDevice.Viewport));

            //Draw World
            world.DrawWorld(spriteBatch, camera);

            //END camera0
            spriteBatch.End();


            //HUD
            spriteBatch.Begin();
            spriteBatch.DrawString((SpriteFont)GlobalResources.resourceDictionary["FontArial"], "Cam: " + camera.position.ToString(), new Vector2(0, 20), Color.Red);
            spriteBatch.End();


            //Base
            base.Draw(spriteBatch);
        }
    }
}
