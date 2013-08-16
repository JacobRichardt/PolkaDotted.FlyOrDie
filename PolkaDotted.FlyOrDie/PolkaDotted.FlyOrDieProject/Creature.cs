using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Materials;

namespace PolkaDotted.FlyOrDieProject
{
	public class Creature : BaseDecorator
	{
		private static uint _creatureCount;
		public CreatureBehavior Behavior { get; private set; }

		public Creature(Vector2 startPosition)
		{
			var collisionGroup = new Physic3DCollisionGroup();
			//collisionGroup.DefineCollisionWith(Physic3DCollisionGroup.DefaulCollisionGroup);

			Behavior = new CreatureBehavior();

			entity = new Entity("Creature" + _creatureCount++)
				.AddComponent(new Transform3D {Position = new Vector3(startPosition.X, 0, startPosition.Y), Scale = new Vector3(2)})
				.AddComponent(new MaterialsMap(new BasicMaterial(Color.BlueViolet)))
				.AddComponent(Model.CreateSphere())
				.AddComponent(new SphereCollider())
				.AddComponent(new RigidBody3D {Mass = 3, EnableContinuousContact = true, CollisionGroup = collisionGroup})
				.AddComponent(new ModelRenderer())
				.AddComponent(Behavior);
		}
	}
}