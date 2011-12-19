using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IsometricMap.Formations;
namespace IsometricMap.Squad
{
    /// <summary>
    /// Base class for the squad definition.
    /// </summary>
    public abstract class BaseSquad
    {
        protected Formation m_fCurrFormation;

        public void SetCurrentFormation(Formation curr)
        {
            m_fCurrFormation = curr;
        }

        public abstract void AddSquad(BaseSquad squad);
        public abstract void RemoveSquad(BaseSquad squad);
        public abstract void SetFormation(Formation form);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void MoveTo(Vector2 destinationIndex);
        public abstract void SetPosition(Vector2 position);
    }
}
