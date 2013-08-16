using PolkaDotted.FlyOrDieProject.CreatureBehaviors;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

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

			var level = new Level(100);

			EntityManager.Add(level);

			var creature = new Creature(level.StartPosition);

			creature.Behavior.Behaviors.Add(new AlwaysBehavior {Actions = {new RandomMovementAction()}});

			EntityManager.Add(creature.Entity);
		}
	}
}