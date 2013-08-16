using System;
using System.Security.Cryptography.X509Certificates;
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
	public class Level : BaseDecorator
	{
		private readonly float _size;
		public float Size { get { return _size; } }

		private const int MinNumObstacles = 20;
		private const int MaxNumObstacles = 40;
		private const int MinObstaclesLength = 2;
		private const int MaxObstaclesLenght = 20;

		public Vector2 StartPosition { get; private set; }
		public Vector2 EndPosition { get; private set; }

		public Level(float size)
		{
			_size = size;

			entity = new Entity("Level");

			Entity.AddComponent(new Transform3D() { Position = new Vector3(0, -1, 0), Scale = new Vector3(Size, 1, Size) })
				.AddComponent(new BoxCollider())
				.AddComponent(Model.CreateCube())
				.AddComponent(new RigidBody3D() { IsKinematic = true })
				.AddComponent(new MaterialsMap(new BasicMaterial(Color.Coral)))
				.AddComponent(new ModelRenderer());

			AddWall(-Size / 2, 0, Size, 0);
			AddWall(Size / 2, 0, Size, 0);
			AddWall(0, -Size / 2, Size, (float)Math.PI / 2);
			AddWall(0, Size / 2, Size, (float)Math.PI / 2);

			AddObsticles();

			StartPosition = new Vector2(-Size / 2 + 5, Size / 2 - 5);
			EndPosition = new Vector2(Size / 2 - 5, -Size / 2 + 5);

			Entity.AddChild(new Marker(StartPosition).Entity);
			Entity.AddChild(new Marker(EndPosition).Entity);
		}

		private void AddWall(float x, float y, float size, float rotation)
		{
			Entity.AddChild(new Wall(new Vector2(x, y), size, rotation).Entity);
		}

		private void AddObsticles()
		{
			var random = WaveServices.Random;
			var halfSize = (int)Size/2;

			var numOfObstacles = random.Next(MinNumObstacles, MaxNumObstacles);

			for (var i = 0; i < numOfObstacles; i++)
			{
				AddWall(random.Next(-halfSize, halfSize),
						random.Next(-halfSize, halfSize),
						random.Next(MinObstaclesLength, MaxObstaclesLenght),
						(float)(random.NextDouble() * Math.PI));
			}
		}
	}
}