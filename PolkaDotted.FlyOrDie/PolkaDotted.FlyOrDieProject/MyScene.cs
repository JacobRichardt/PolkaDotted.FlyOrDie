using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Framework.Services;
using WaveEngine.Materials;

namespace PolkaDotted.FlyOrDieProject
{
	public class MyScene : Scene
	{
		protected override void CreateScene()
		{
			RenderManager.BackgroundColor = Color.CornflowerBlue;

			var camera = new FreeCamera("MainCamera", new Vector3(0, 10, 20), new Vector3(0, 5, 0));
			EntityManager.Add(camera);
			RenderManager.SetActiveCamera(camera.Entity);

			var ground = new Entity("Ground")
				.AddComponent(new Transform3D() { Position = new Vector3(0, -1, 0), Scale = new Vector3(100, 1, 100) })
				 .AddComponent(new BoxCollider())
				 .AddComponent(Model.CreateCube())
				 .AddComponent(new RigidBody3D() { IsKinematic = true })
				 .AddComponent(new MaterialsMap(new BasicMaterial(Color.White)))
				 .AddComponent(new ModelRenderer());

			EntityManager.Add(ground);

			var width = 10;
			var height = 10;
			var blockWidth = 2f;
			var blockHeight = 1f;
			var blockLength = 1f;

			var n = 0;
			for (var i = 0; i < width; i++)
			{
				for (var j = 0; j < height; j++)
				{
					n++;
					var toAdd = CreateBox("box" + n, new Vector3(i * blockWidth + .5f * blockWidth * (j % 2) - width * blockWidth * .5f, blockHeight * .5f + j * (blockHeight), 0),
																 new Vector3(blockWidth, blockHeight, blockLength), 10);
					EntityManager.Add(toAdd);
				}
			}

			var creature = new Entity("Creature")
				.AddComponent(new Transform3D() {Position = new Vector3(0, 0, 4) ,Scale = new Vector3(2)})
				.AddComponent(new MaterialsMap(new BasicMaterial(Color.BlueViolet)))
				.AddComponent(Model.CreateSphere())
				.AddComponent(new SphereCollider())
				.AddComponent(new RigidBody3D() {Mass = 3, EnableContinuousContact = true})
				.AddComponent(new ModelRenderer())
				.AddComponent(new CreatureBehavior());

			EntityManager.Add(creature);
		}

		private Entity CreateBox(string name, Vector3 position, Vector3 scale, float mass)
		{
			Entity primitive = new Entity(name)
				.AddComponent(new Transform3D() { Position = position, Scale = scale })
				.AddComponent(new MaterialsMap(new BasicMaterial(GetRandomColor())))
				.AddComponent(Model.CreateCube())
				.AddComponent(new BoxCollider())
				.AddComponent(new RigidBody3D() { Mass = mass })
				.AddComponent(new ModelRenderer());

			return primitive;
		}

		private Color GetRandomColor()
		{
			var random = WaveServices.Random;
			return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1f);
		}
	}
}
