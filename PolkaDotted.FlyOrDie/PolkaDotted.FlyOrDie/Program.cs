using System;

namespace PolkaDotted.FlyOrDie
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new App())
			{
				game.Run();
			}
		}
	}
}

