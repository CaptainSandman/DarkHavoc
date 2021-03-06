﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DarkHavoc.Engine;
using DarkHavoc.Engine.API;
using AssetLoader;

namespace DarkHavoc
{
    class Player : JoshoEntity
    {
        protected Vector2 InitialPosition;
        protected float Speed;

        public Player(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            InitialPosition = position;
            Speed = 5.10f;
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }

        public override void Update(GameTime gameTime)
        {
            //TODO: Implement lol
        }

        public void UpdateInput(InputState input, PlayerIndex? controllingPlayer)
        {
            // Look up inputs for the active player profile.
            int playerIndex = (int)controllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
			GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

			if (keyboardState.IsKeyDown(Keys.Left) || gamePadState.IsButtonDown(Buttons.DPadLeft))
            {
                Position.X -= Speed;
            }

			if (keyboardState.IsKeyDown(Keys.Right) || gamePadState.IsButtonDown(Buttons.DPadRight) )
            {
                Position.X += Speed;
            }

			if (keyboardState.IsKeyDown(Keys.Up) || gamePadState.IsButtonDown(Buttons.DPadUp))
            {
                Position.Y -= Speed;
            }

			if (keyboardState.IsKeyDown(Keys.Down) || gamePadState.IsButtonDown(Buttons.DPadDown))
            {
                Position.Y += Speed;
            }

			if (keyboardState.Equals(new KeyboardState()))
			{
				Vector2 thumbstick = gamePadState.ThumbSticks.Left;

				this.Position.X += thumbstick.X * this.Speed;
				this.Position.Y -= thumbstick.Y * this.Speed;
			}
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(MyTexture, Position, null, Color.White, 0f, this.TextureCenter, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
