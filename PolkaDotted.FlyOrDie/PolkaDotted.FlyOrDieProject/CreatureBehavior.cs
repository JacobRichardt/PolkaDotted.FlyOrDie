using System;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Framework.Services;

namespace PolkaDotted.FlyOrDieProject
{
	public class CreatureBehavior : Behavior
	{
		[RequiredComponent]
		public RigidBody3D RigidBody = null;

		public CreatureBehavior() : base("CreatureBehavior", FamilyType.Physics)
		{
		}

		protected override void Update(TimeSpan gameTime)
		{
			var random = WaveServices.Random;
			if (random.Next(5) == 0)
			{
				var x = (float) (random.NextDouble() - 0.5) * 20;
				var y = (float) (random.NextDouble() - 0.5) * 20;

				RigidBody.ApplyLinearImpulse(new Vector3(x, 0, y));
			}
		}
	}
}