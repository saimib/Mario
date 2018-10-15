using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using GameEngine;
using Mario.Characters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mario.Tests
{
	[TestClass]
	public class ObjectCreationTests
	{
		[TestMethod]
		public void ProperFacingDirection()
		{
			var game = new GameObject("Mario");
			new ResourceProxy().LoadSpriteSheetFromFile("sm-mario-sprites", @"resources\sm-mario-sprites.png", 10);
			new ResourceProxy().LoadFontFromFile("arial", @"resources\arial.ttf");
			var s = new MainScene(game) { Name = "play" };
			game.SceneManager.AddScene(s);
			var mario = new Characters.Mario(game);
			var facingDirection = mario.Facing;
			Assert.AreEqual(facingDirection, Direction.RIGHT);
		}

		/// <summary>
		/// Flag pole should be static object with collisions on.
		/// </summary>
		[TestMethod]
		public void FlagPoleCreationTest()
		{
			var game = new GameObject("Mario");
			new ResourceProxy().LoadSpriteSheetFromFile("sm-mario-sprites", @"resources\sm-mario-sprites.png", 10);
			new ResourceProxy().LoadFontFromFile("arial", @"resources\arial.ttf");
			var s = new MainScene(game) { Name = "play" };
			game.SceneManager.AddScene(s);

			var flagPole = new FlagPole(game);

			Assert.IsFalse(flagPole.HasUpwardVelocity, "Flag pole is moving upwards!");
			Assert.IsFalse(flagPole.IgnoreAllCollisions, "Flag pole is uncollidable!");
			Assert.IsFalse(flagPole.IgnorePlayerCollisions, "Flag pole is uncollidable by player!");
			Assert.IsFalse(flagPole.IsJumping, "Flag pole is jumping!");
			Assert.IsFalse(flagPole.IsMoving, "Flag pole is moving!");
			Assert.IsFalse(flagPole.IsPlayer, "Flag pole is player!");
			Assert.IsTrue(flagPole.IsStatic, "Flag pole is not static!");
			Assert.IsTrue(flagPole.Visible, "Flag pole is invisible!");
			Assert.IsTrue(flagPole.Acceleration == 0, "Flag pole is accelerating!");
			Assert.IsTrue(flagPole.Velocity == 0, "Flag pole has non-zero velocity!");
			Assert.IsFalse(flagPole.IsAffectedByGravity, "Flag pole shouldn't be affected by gravity until Mario touches it!");
		}

		/// <summary>
		/// Level file should be validated when loaded. Invalid file should cause an exception.
		/// </summary>
		[ExpectedException(typeof(Exception), "Invalid level file didn't cause an exception!")]
		[TestMethod]
		public void InvalidLevelLoadingTest()
		{
			// gets current level file
			var levelFilePath = Directory.GetCurrentDirectory() + @"\leveldata.xml";
			var levelText = File.ReadAllText(levelFilePath);
			var levelXml = XDocument.Parse(levelText);
			var tilemapNode = levelXml.XPathSelectElement("//tilemap");
			var rowsAttribute = tilemapNode.Attribute("rows");

			// corrupting rows attribute
			Assert.IsNotNull(rowsAttribute, "Missing rows attribute!");
			rowsAttribute.Value = "9999";

			// saves new temporary level file
			var tempLevelFilePath = Path.GetTempFileName();
			File.WriteAllText(tempLevelFilePath, levelXml.ToString());

			var level = new Level();
			level.LoadMap(tempLevelFilePath, 1);
		}
	}
}
