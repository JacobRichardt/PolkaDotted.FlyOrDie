using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Materials;

namespace PolkaDotted.FlyOrDieProject
{
	public class Marker : BaseDecorator
	{
		private static uint _markNumber;
		private const uint Size = 3;

		public Marker(Vector2 position)
		{
			entity = new Entity("Mark" + _markNumber++);

			Entity
				.AddComponent(new Transform3D
				{
					Position = new Vector3(position.X, Size/2, position.Y),
					Scale = new Vector3(Size)
				})
				.AddComponent(new MaterialsMap(new BasicMaterial(Color.Crimson) {Alpha = .01f}))
				.AddComponent(Model.CreatePyramid())
				.AddComponent(new ModelRenderer());
		}
	}
}