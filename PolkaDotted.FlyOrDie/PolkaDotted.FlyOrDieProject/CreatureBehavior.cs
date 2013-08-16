using System;
using System.Collections.Generic;
using System.Linq;
using PolkaDotted.FlyOrDieProject.CreatureBehaviors;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics3D;

namespace PolkaDotted.FlyOrDieProject
{
	public class CreatureBehavior : Behavior
	{
		private const float MaxImpulseLength = 10;

		[RequiredComponent]
		public RigidBody3D RigidBody = null;

		public IList<IBehaviorGroup> Behaviors { get; private set; }

		public CreatureBehavior() : base("CreatureBehavior", FamilyType.Physics)
		{
			Behaviors = new List<IBehaviorGroup>();
		}

		protected override void Update(TimeSpan gameTime)
		{
			var impulse = new Vector2();

			impulse = Behaviors.Aggregate(impulse, (current, behavior) => behavior.Apply(current));

			if (impulse.Length() > MaxImpulseLength)
			{
				impulse.Normalize();
				impulse = impulse*MaxImpulseLength;
			}

			RigidBody.ApplyLinearImpulse(new Vector3(impulse.X, 0, impulse.Y));
		}
	}
}