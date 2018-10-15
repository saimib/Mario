using System.Diagnostics;
using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mario.Tests
{
	[TestClass]
	public class PerformanceTests
	{
		/// <summary>
		/// Game should start within 500ms
		/// </summary>
		[TestMethod]
		public void StartupTest()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var game = new GameObject("Mario");
			new ResourceProxy().LoadSpriteSheetFromFile("sm-mario-sprites", @"resources\sm-mario-sprites.png", 10);
			new ResourceProxy().LoadFontFromFile("arial", @"resources\arial.ttf");
			var s = new MainScene(game) { Name = "play" };
			game.SceneManager.AddScene(s);

			stopwatch.Stop();

			Assert.IsTrue(stopwatch.Elapsed.Milliseconds < 500, @"Game didn't started within 500ms! Start time was {stopwatch.Elapsed.Milliseconds}ms.");
		}

		/// <summary>
		/// First level should load within 400ms
		/// </summary>
		[TestMethod]
		public void LevelLoadingTest()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var level = new Level();
			level.LoadMap(System.IO.Directory.GetCurrentDirectory() + @"\leveldata.xml", 1);

			stopwatch.Stop();

			Assert.IsTrue(stopwatch.Elapsed.Milliseconds < 400, $"Level wasn't loaded within 200ms! Load time was {stopwatch.Elapsed.Milliseconds}ms.");
		}
	}
}
