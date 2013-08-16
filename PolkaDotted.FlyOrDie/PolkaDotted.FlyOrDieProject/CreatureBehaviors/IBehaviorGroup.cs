using System.Collections.Generic;
using WaveEngine.Common.Math;

namespace PolkaDotted.FlyOrDieProject.CreatureBehaviors
{
	public interface IBehaviorGroup
	{
		IList<IBehaviorAction> Actions { get; }

		Vector2 Apply(Vector2 initiateImpulse);
	}
}