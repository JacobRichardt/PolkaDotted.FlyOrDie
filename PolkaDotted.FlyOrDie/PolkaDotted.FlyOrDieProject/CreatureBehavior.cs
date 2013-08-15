using System;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics3D;

namespace PolkaDotted.FlyOrDieProject
{
	public class CreatureBehavior : Behavior
	{
		[RequiredComponent]
		public RigidBody3D RigidBody = null;

		private readonly Random _random;

		public CreatureBehavior() : base("CreatureBehavior", FamilyType.Physics)
		{
			_random = new Random();
		}

		protected override void Update(TimeSpan gameTime)
		{
			if (_random.Next(5) == 0)
			{
				var jump = _random.Next(20) == 0 ? 50 : 0;

				var x = (float) (_random.NextDouble() - 0.5) * 10;
				var y = (float) (_random.NextDouble() - 0.5) * 10;

				RigidBody.ApplyLinearImpulse(new Vector3(x, jump, y));
			}
		}
	}
}