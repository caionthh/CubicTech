using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CubicTechGame.InputManager
{
    public class KeyboardInput
    {
        //Keyboard
        public KeyboardState currentKeyboard, lastKeyboard;

        //Update
        public void Update(GameTime gametime)
        {
            //Update Keyboard
            lastKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();
        }

    }
}
