using WaveEngine.Common.Math;

namespace PolkaDotted.FlyOrDieProject.CreatureBehaviors
{
	public interface IBehaviorAction
	{
		Vector2 Apply(Vector2 initiateImpulse);
	}
}