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
    /// An atomic squad is that which holds 
    /// a single game entity.
    /// </summary>
    public class AtomicSquad:BaseSquad
    {

        GameEntity m_geSquadEntity;

        public AtomicSquad(ref GameEntity ent)
        {
            m_geSquadEntity = ent;
        }

        /// <summary>
        /// Atomic squads are a single memeber squad
        /// thus there is no need to implement the add/remove
        /// methods.
        /// </summary>
        /// <param name="squad"></param>
        public override void AddSquad(BaseSquad squad)
        {}
        public override void RemoveSquad(BaseSquad squad)
        {}


        public override void SetFormation(Formation form)
        {
            m_fCurrFormation = form;
        }

        public override void Update(GameTime gameTime)
        {
            if (m_geSquadEntity == null)
                return;

            m_geSquadEntity.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (m_geSquadEntity == null)
                return;

            m_geSquadEntity.Draw(spriteBatch);
        }

        public override void MoveTo(Vector2 destinationIndex)
        {
            if (m_geSquadEntity == null)
                return;

            if (m_geSquadEntity is GoblinLumberjack)
                ((GoblinLumberjack)m_geSquadEntity).GetStateMachine().ChangeState(Logic.States.Goblin.Lumberjack.GLumberjack_MOVE.GetInstance());

            m_geSquadEntity.MoveTo(Map.MapHandler.GetInstance().GetTilePosition(destinationIndex));

        }

        public override void SetPosition(Vector2 position)
        {
            m_geSquadEntity.SetWorldPosition(position);
            m_geSquadEntity.SetDrawPosition(position);
        }
    }
}
