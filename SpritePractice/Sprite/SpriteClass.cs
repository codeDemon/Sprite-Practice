using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpritePractice.Sprite
{
    public class SpriteClass
    {
        private Texture2D m_Image;
        private Rectangle m_Source;
        private Rectangle m_Destination;

        private Rectangle m_Origin;

        private String m_Filename;

        // Animation Specific
        int m_NextUpdate = 0;
        int m_nMaxFrame = 2;
        int m_nFrameDelay = 200;
        int m_nCurrFrame = 3;

        AnimationSimple m_Blink;
        List<AnimationSimple> m_Animations;
        AnimationSimple m_CurrAnim;
        public SpriteClass(String filename)
        {
            m_Filename = filename;

            // Temp Init
            m_Source = new Rectangle(39 * m_nCurrFrame, 0, 39, 27);
            m_Origin = m_Source;
            m_Destination = new Rectangle(50, 50, 39, 27);

            m_Animations = new List<AnimationSimple>();
            
            m_Blink = new AnimationSimple("Blink", 200, 2, 39 * 3, 0, 39, 27);
            m_Animations.Add(m_Blink);
            AnimationSimple m_SwimRight = new AnimationSimple("Swim Right", 200, 5, 39 * 5, 40 * 8, 39, 27);
            m_Animations.Add(m_SwimRight);

            AnimationSimple m_SwimLeft = new AnimationSimple("Swim Left", 200, 5, 39 * 0, 40 * 8, 39, 27);
            m_Animations.Add(m_SwimLeft);

            m_CurrAnim = m_Blink;
        }
        public void Update(GameTime time)
        {
            
            m_CurrAnim.Update(time);
            m_Source = m_CurrAnim.GetSource();
            /*
            // Current time in milliseconds
            double currTime = time.TotalGameTime.TotalMilliseconds;
            if (m_NextUpdate < currTime)
            {
                m_nCurrFrame = m_nCurrFrame % m_nMaxFrame;
                m_Source.X =  m_Origin.X + m_Source.Width * (m_nCurrFrame);
                m_nCurrFrame++;

                m_NextUpdate = (int)(currTime + m_nFrameDelay); 
            }
             */
        }

        public void LoadResource(ContentManager content)
        {
            m_Image = content.Load<Texture2D>(@"Textures\" + m_Filename);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(m_Image, m_Destination, m_Source, Color.White);
        }
        public void PlayAnimation(String animationID)
        {
            for (int i = 0; i < m_Animations.Count; i++)
            {
                AnimationSimple temp = m_Animations[i];
                if (temp.GetID().Equals(animationID))
                    m_CurrAnim = temp;
            }
        }
    }
}
