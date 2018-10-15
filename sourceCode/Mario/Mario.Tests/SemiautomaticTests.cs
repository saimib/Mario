using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mario.Tests
{
	[TestClass]
	public class SemiautomaticTests
	{
		/// <summary>
		/// All goombas should became coinbox in this run.
		/// </summary>
		[TestMethod]
		public void GoombaIsCoinboxTest()
		{
			var game = new GameObject("Mario");

			new ResourceProxy().LoadSpriteSheetFromFile("sm-mario-sprites", @"resources\sm-mario-sprites.png", 10);
			new ResourceProxy().LoadFontFromFile("arial", @"resources\arial.ttf");

			// gets current level file
			var levelFilePath = Directory.GetCurrentDirectory() + @"\leveldata.xml";
			var levelText = File.ReadAllText(levelFilePath);
			var levelXml = XDocument.Parse(levelText);
			var rows = levelXml.XPathSelectElements("//row");

			// replaces all goombas (50) with coinboxes (3)
			foreach (var row in rows.Where(row => row.Value.Contains("50")))
			{
				row.Value = row.Value.Replace("50", "3");
			}

			// saves new temporary level file
			var tempLevelFilePath = Path.GetTempFileName();
			File.WriteAllText(tempLevelFilePath, levelXml.ToString());

			var s = new MainScene(game, tempLevelFilePath) { Name = "play" };
			game.SceneManager.AddScene(s);

			var s2 = new StartScene(game) { Name = "start" };
			game.SceneManager.AddScene(s2);

			var s3 = new GameOverScene(game) { Name = "gameover" };
			game.SceneManager.AddScene(s3);

			game.SceneManager.StartScene("play");
		}
	}
}
