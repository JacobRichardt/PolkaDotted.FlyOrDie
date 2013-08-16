using WaveEngine.Common.Math;
using WaveEngine.Framework.Services;

namespace PolkaDotted.FlyOrDieProject.CreatureBehaviors
{
	public class RandomMovementAction : IBehaviorAction
	{
		public Vector2 Apply(Vector2 initiateImpulse)
		{
			return new Vector2((float)(WaveServices.Random.NextDouble() - .5) * 10, (float)(WaveServices.Random.NextDouble() - .5) * 10);
		}
	}
}