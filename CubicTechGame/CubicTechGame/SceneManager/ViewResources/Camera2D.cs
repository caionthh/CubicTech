using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CubicTechGame.SceneManager.ViewResources
{
    public class Camera2D
    {

        //Camera Matrix
        public Matrix matrix;

        //Global Camera Position
        public Vector2 position;

        //Scale
        public float scale = 1;

        //Rotation
        public Vector3 rotation = Vector3.Zero;
        
        //Zoom
        public float zoom = 1f;

        //Get Matrix
        public Matrix GetCameraMatrix(Viewport viewport)
        {
            //Create Basic Camera
            matrix = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0))
                * Matrix.CreateRotationX(rotation.X) * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateRotationZ(rotation.Z)
                * Matrix.CreateTranslation(new Vector3((viewport.X + viewport.Width)/2, (viewport.Y + viewport.Height)/2, 0))
                * Matrix.CreateScale(scale) * Matrix.CreateScale(zoom);


            //Return
            return matrix;
        }


    }
}
