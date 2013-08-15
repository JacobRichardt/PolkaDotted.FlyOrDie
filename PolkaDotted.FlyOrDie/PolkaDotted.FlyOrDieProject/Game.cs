using WaveEngine.Common;
using WaveEngine.Framework.Services;

namespace PolkaDotted.FlyOrDieProject
{
	public class Game : WaveEngine.Framework.Game
	{
		public override void Initialize(IAdapter adapter)
		{
			base.Initialize(adapter);

			var screenLayers = WaveServices.ScreenLayers;
			screenLayers.AddScene<MyScene>();
			screenLayers.Apply();
		}
	}
}
