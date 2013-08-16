using System.Collections.Generic;
using System.Linq;
using WaveEngine.Common.Math;

namespace PolkaDotted.FlyOrDieProject.CreatureBehaviors
{
	public class AlwaysBehavior : IBehaviorGroup
	{
		public IList<IBehaviorAction> Actions { get; private set; }

		public AlwaysBehavior()
		{
			Actions = new List<IBehaviorAction>();
		}

		public Vector2 Apply(Vector2 initiateImpulse)
		{
			var impulse = new Vector2();

			impulse = Actions.Aggregate(impulse, (current, behavior) => behavior.Apply(current));

			return impulse;
		}
	}
}