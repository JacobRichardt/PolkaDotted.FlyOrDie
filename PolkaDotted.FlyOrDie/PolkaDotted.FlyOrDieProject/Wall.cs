using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Framework.Services;
using WaveEngine.Materials;

namespace PolkaDotted.FlyOrDieProject
{
	public class Wall : BaseDecorator
	{
		private static uint _wallNumber;

		private const float Width = 2;
		private const float Height = 5;

		public Wall(Vector2 position, float length, float rotation)
		{
			entity = new Entity("Wall" + _wallNumber++);

			Entity
				.AddComponent(new Transform3D
								{
									Position = new Vector3(position.X, Height/2 - 1, position.Y),
									Scale = new Vector3(Width, Height, length),
									Rotation = new Vector3(0, rotation, 0)
								})
				.AddComponent(new MaterialsMap(new BasicMaterial(GetRandomColor())))
				.AddComponent(Model.CreateCube())
				.AddComponent(new BoxCollider())
				.AddComponent(new RigidBody3D() { IsKinematic = true})
				.AddComponent(new ModelRenderer());
		}

		private Color GetRandomColor()
		{
			var random = WaveServices.Random;
			return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1f);
		}
	}
}