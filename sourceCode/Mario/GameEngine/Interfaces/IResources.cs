using SFML.Audio;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
	public interface IResources
	{
		void LoadTextureFromFile(string name, string path);

		Texture GetTexture(string name);

		void LoadSpriteSheetFromFile(string name, string path, int totalFrames);

		SpriteSheet GetSpriteSheet(string name);

		bool LoadSoundFromFile(string name, string path);

		bool LoadFontFromFile(string name, string path);

		Sound GetSound(string name);

		void PlaySound(string name);

		void StopSound(string name);

		SoundStatus GetSoundStatus(string name);

		Font GetFont(string name);
	}
}
