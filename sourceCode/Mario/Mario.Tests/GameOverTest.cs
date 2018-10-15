using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mario.Tests
{
	[TestClass]
	public class GameOverTest
	{
		[TestMethod]
		public void GameOverTriggered()
		{
			var game = new GameObject("Mario");
			new ResourceProxy().LoadSpriteSheetFromFile("sm-mario-sprites", @"resources\sm-mario-sprites.png", 10);
			new ResourceProxy().LoadFontFromFile("arial", @"resources\arial.ttf");
			var s = new MainScene(game) { Name = "play" };
			game.SceneManager.AddScene(s);
			var mario = new Characters.Mario(game);
			for (var i = 0; i < 3; i++)
			{
				mario.Die();
			}
			var currentScene = game.SceneManager.CurrentScene.Name;
			Assert.AreEqual(currentScene, "gameover");
		}
	}
}
