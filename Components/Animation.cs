using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Components
{
    public class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount {  get; }

        public float FrameDuration { get; set; }
        public bool Looping { get; set; }
        public string Name { get; set; }
        private readonly Game game;
        public bool CurrentFrameIsLast
        {
            get
            {
                return CurrentFrame == FrameCount;
            }
        }


        private string Path { get; set; }
        private Texture2D[] Textures2D { get; set; }
        public Texture2D CurrentTexture => Textures2D[CurrentFrame];

        public Vector2 FrameSize => new(FrameWidth, FrameHeight);
        private int FrameWidth => CurrentTexture.Width;
        private int FrameHeight => CurrentTexture.Height;

        public Rectangle FrameRectangle()
        {
            return new Rectangle(Vector2.Zero.ToPoint(), FrameSize.ToPoint());
        }

        public Animation(Game game, string path, int frameCount, bool looping, float frameDuration)
        {
            CurrentFrame = 0;
            this.game = game;
            Path = path;
            FrameCount = frameCount;
            Looping = looping;
            FrameDuration = frameDuration;
            
            LoadTextures(FrameCount);
        }

        private void LoadTextures(int frameCount)
        {
            Textures2D = new Texture2D[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                Textures2D[i] = game.Content.Load<Texture2D>(string.Concat(Path,i));
                
            }
        }

        internal void NextFrame()
        {
            CurrentFrame++;
            CurrentFrame %= (FrameCount);

        }


    }
}
