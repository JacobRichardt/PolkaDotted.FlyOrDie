using System;
using System.IO;
using System.Reflection;
using PolkaDotted.FlyOrDieProject;
using WaveEngine.Adapter;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;

namespace PolkaDotted.FlyOrDie
{
	public class App : Application
	{
		private Color backgroundSplashColor;
		private Game game;
		private Vector2 position;
		private Texture2D splashScreen;
		private bool splashState = true;
		private SpriteBatch spriteBatch;
		private TimeSpan time;

		public App()
		{
			Width = 1024;
			Height = 768;
			FullScreen = false;
			WindowTitle = "Fly or Die";
		}

		public override void Initialize()
		{
			game = new Game();
			game.Initialize(Adapter);

			#region WAVE SOFTWARE LICENSE AGREEMENT

			backgroundSplashColor = new Color(32, 32, 32, 255);
			spriteBatch = new SpriteBatch(WaveServices.GraphicsDevice);

			string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
			string name = string.Empty;

			foreach (string item in resourceNames)
			{
				if (item.Contains("SplashScreen.wpk"))
				{
					name = item;
					break;
				}
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				throw new InvalidProgramException("License terms not agreed.");
			}

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
			{
				splashScreen = WaveServices.Assets.Global.LoadAsset<Texture2D>(name, stream);
			}

			position = new Vector2 {X = (Width/2.0f) - (splashScreen.Width/2.0f), Y = (Height/2.0f) - (splashScreen.Height/2.0f)};

			#endregion
		}

		public override void Update(TimeSpan elapsedTime)
		{
			if (game != null && !game.HasExited)
			{
				if (WaveServices.Input.KeyboardState.F10 == ButtonState.Pressed)
				{
					FullScreen = !FullScreen;
				}

				if (splashState)
				{
					#region WAVE SOFTWARE LICENSE AGREEMENT

					time += elapsedTime;
					if (time > TimeSpan.FromSeconds(2))
					{
						splashState = false;
					}

					#endregion
				}
				else
				{
					if (WaveServices.Input.KeyboardState.Escape == ButtonState.Pressed)
					{
						Exit();
						game.Unload();
					}
					else
					{
						game.UpdateFrame(elapsedTime);
					}
				}
			}
		}

		public override void Draw(TimeSpan elapsedTime)
		{
			if (game != null && !game.HasExited)
			{
				if (splashState)
				{
					#region WAVE SOFTWARE LICENSE AGREEMENT

					WaveServices.GraphicsDevice.RenderTargets.SetRenderTarget(null);
					WaveServices.GraphicsDevice.Clear(ref backgroundSplashColor, ClearFlags.Target, 1);
					spriteBatch.Begin();
					spriteBatch.Draw(splashScreen, position, Color.White);
					spriteBatch.End();

					#endregion
				}
				else
				{
					game.DrawFrame(elapsedTime);
				}
			}
		}
	}
}