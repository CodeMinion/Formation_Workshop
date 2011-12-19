using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IsometricMap.Entities;
using IsometricMap.Formations;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace IsometricMap.Squad
{
    /// <summary>
    /// Composite squads are composed of a single leader 
    /// and a list of sub-squads. This subsquads can be 
    /// single atomic squads or can be composite squads.
    /// </summary>
    public class CompositeSquad:BaseSquad
    {
        GameEntity m_geSquadLeader;
        List<BaseSquad> m_lstSquad;

        public CompositeSquad(GameEntity squadLeader)
        {
            m_geSquadLeader = squadLeader;
            m_lstSquad = new List<BaseSquad>();
        }
        /// <summary>
        /// Adds the desired squad.
        /// </summary>
        /// <param name="squad"></param>
        public override void AddSquad(BaseSquad squad)
        {
            m_lstSquad.Add(squad);
        }

        /// <summary>
        /// Removes the desired squad.
        /// </summary>
        /// <param name="squad"></param>
        public override void RemoveSquad(BaseSquad squad)
        {
            m_lstSquad.Remove(squad);
        }
        
        public override void SetFormation(Formation form)
        {
            m_fCurrFormation = form;
            Vector2 leaderIndex = Map.MapHandler.GetInstance().GetTileIndex(m_geSquadLeader.GetWorldPosition());
            for (int i = 0; i < m_fCurrFormation.GetFormationSize()-1 && i < m_lstSquad.Count; i++)
            {
                FormationPosition formation = m_fCurrFormation.GetFormationPosition(i + 1);
                Vector2 minionPos = Vector2.Add(leaderIndex, formation.GetPositionIndex());
                //m_lstSquad[i].MoveTo(minionPos);
                m_lstSquad[i].SetPosition(Map.MapHandler.GetInstance().GetTilePosition(minionPos));
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (m_geSquadLeader == null)
                return;

            m_geSquadLeader.Update(gameTime);

            for (int i = 0; i < m_lstSquad.Count; i++)
            {
                m_lstSquad[i].Update(gameTime);
                
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (m_geSquadLeader == null)
                return;

            m_geSquadLeader.Draw(spriteBatch);

            for (int i = 0; i < m_lstSquad.Count; i++)
            {
                m_lstSquad[i].Draw(spriteBatch);
            }
        }

        public override void MoveTo(Vector2 destinationIndex)
        {
            if (m_geSquadLeader == null)
                return;

            /*
            for (int i = 0; i < m_lstSquad.Count; i++)
            {
                if (m_fCurrFormation == null)
                    break;
                // The first position in the formation must always be the leader.
                m_lstSquad[i].MoveTo(m_fCurrFormation.GetFormationPosition(i + 1).GetPositionIndex());
            }*/

            m_geSquadLeader.MoveTo(Map.MapHandler.GetInstance().GetTilePosition(destinationIndex));
            Vector2 leaderIndex = destinationIndex;
            for (int i = 0; i < m_fCurrFormation.GetFormationSize() - 1 && i < m_lstSquad.Count; i++)
            {
                FormationPosition formation = m_fCurrFormation.GetFormationPosition(i + 1);
                Vector2 minionPos = Vector2.Add(leaderIndex, formation.GetPositionIndex());
                m_lstSquad[i].MoveTo(minionPos);
                //m_lstSquad[i].SetPosition(Map.MapHandler.GetInstance().GetTilePosition(minionPos));
            }
        }

        public override void SetPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
