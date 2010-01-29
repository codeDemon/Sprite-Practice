using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpritePractice.Sprite
{
    public class AnimationSimple
    {
        // Animation Specific
        private int m_NextUpdate;
        private int m_nMaxFrame;
        private int m_nFrameDelay;
        private int m_nCurrFrame;
        private Rectangle m_Source;
        private int m_SourceX;
        private String m_ID;

        public AnimationSimple(String id, int frameDelay, int maxFrames, int sourceX, int sourceY, int sourceW, int sourceH)
        {
            m_ID = id;
            m_Source = new Rectangle(sourceX, sourceY, sourceW, sourceH);
            m_SourceX = sourceX;
            m_nMaxFrame = maxFrames;
            m_nFrameDelay = frameDelay;
        }

        public void Update(GameTime time)
        {
            // Current time in milliseconds
            double currTime = time.TotalGameTime.TotalMilliseconds;
            if (m_NextUpdate < currTime)
            {
                m_nCurrFrame = m_nCurrFrame % m_nMaxFrame;
                m_Source.X = m_SourceX + m_Source.Width * (m_nCurrFrame);
                m_nCurrFrame++;

                m_NextUpdate = (int)(currTime + m_nFrameDelay);
            }
        }

        public Rectangle GetSource()
        {
            return m_Source;
        }
        public String GetID()
        {
            return m_ID;
        }
    }
}
