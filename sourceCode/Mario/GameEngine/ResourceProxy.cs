using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Audio;
using GameEngine.Interfaces;

namespace GameEngine
{
    public class ResourceProxy : IResources
    {
        private static IResources instance = null;

        private static IResources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Resources();
                }
                return instance;
            }
        }

        public void LoadTextureFromFile(string name, string path)
        {
			Instance.LoadTextureFromFile(name, path);
        }

        public Texture GetTexture(string name)
        {
			return Instance.GetTexture(name);
        }

        public void LoadSpriteSheetFromFile(string name, string path, int totalFrames)
        {
			Instance.LoadSpriteSheetFromFile(name, path, totalFrames);
        }

        public SpriteSheet GetSpriteSheet(string name)
        {
			return Instance.GetSpriteSheet(name);
        }


        public bool LoadSoundFromFile(string name, string path)
        {
			return Instance.LoadSoundFromFile(name, path);
        }

        public bool LoadFontFromFile(string name, string path)
        {
			return Instance.LoadFontFromFile(name, path);

        }


        public Sound GetSound(string name)
        {
			return Instance.GetSound(name);
        }

        public void PlaySound(string name)
        {
			Instance.PlaySound(name);
        }

        public void StopSound(string name)
        {
			Instance.StopSound(name);
        }

        public SoundStatus GetSoundStatus(string name)
        {
			return Instance.GetSoundStatus(name);
        }

        public Font GetFont(string name)
        {
			return Instance.GetFont(name);
        }


    }
}
