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
			WaveServices.Random.Reinitialise(20);
			
			RenderManager.BackgroundColor = Color.CornflowerBlue;

			var camera = new FreeCamera("MainCamera", new Vector3(0, 80, 80), new Vector3(0, 0, 10));
			EntityManager.Add(camera);
			RenderManager.SetActiveCamera(camera.Entity);

			EntityManager.Add(new Level(100));

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
	}
}