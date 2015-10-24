﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace glitch
{
    public class InputHandler
    {
        public static InputHandler inputHandler = null;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        public InputHandler() { }

        public static InputHandler GetInstance()
        {
            if (inputHandler == null)
            {
                inputHandler = new InputHandler();
            }
            return inputHandler;
        }

        public void updateStates()
        {
            previousKeyboardState = currentKeyboardState;
            previousGamePadState = currentGamePadState;


            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
        }
        public void handlePlayerInput(PlayerObject playerObject)
        {

            if (currentKeyboardState.IsKeyDown(Keys.Space) || currentGamePadState.IsButtonDown(Buttons.A))
            {
                if (!playerObject.IsJumping)
                {
                    playerObject.physComp.velocity.Y = -10.0f;
                    playerObject.IsJumping = true;
                    //TODO: Change the Vertical velocity to a higher or lower based on play.
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                //if (!playerObject.IsJumping && playerObject.physComp.velocity.X < -playerObject.MaxHowizontalVelocity)
                {
                    playerObject.physComp.velocity.X = -playerObject.MaxHowizontalVelocity;
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                //if (!playerObject.IsJumping && playerObject.physComp.velocity.X < playerObject.MaxHowizontalVelocity)
                {
                    playerObject.physComp.velocity.X = playerObject.MaxHowizontalVelocity;
                }
            }

            if ((previousKeyboardState.IsKeyDown(Keys.Left) || previousGamePadState.DPad.Left == ButtonState.Pressed) && (currentKeyboardState.IsKeyUp(Keys.Left) || currentGamePadState.DPad.Left == ButtonState.Released))
            {
                playerObject.physComp.velocity.X = 0;
            }

            if ((previousKeyboardState.IsKeyDown(Keys.Right) || previousGamePadState.DPad.Right == ButtonState.Pressed) && (currentKeyboardState.IsKeyUp(Keys.Right) || currentGamePadState.DPad.Right == ButtonState.Released))
            {
                playerObject.physComp.velocity.X = 0;
            }


        }

    }
}
