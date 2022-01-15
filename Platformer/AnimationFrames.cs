using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer
{
    class AnimationFrames
    {
        public List<int> Frames { get; set; }
        private int _currentFrame;
        private int _currentFrameIndex;

        public AnimationFrames(List<int> frames)
        {
            Frames = frames;
            _currentFrameIndex = 0;
            _currentFrame = Frames[_currentFrameIndex];
        }

        public void Update()
        {
            _currentFrameIndex++;
            if(_currentFrameIndex == Frames.Count)
            {
                _currentFrameIndex = 0;
            }
            _currentFrame = Frames[_currentFrameIndex];
        }

        public int GetCurrentFrame()
        {
            return _currentFrame;
        }
    }
}
