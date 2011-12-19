using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
namespace IsometricMap.Formations
{
    public class Formation
    {
        List<FormationPosition> m_lstFormation;
        String m_sFormationName;
        public Formation()
        {
            m_lstFormation = new List<FormationPosition>();
        }

        public Formation(String formationName)
        {
            m_sFormationName = formationName;
            m_lstFormation = new List<FormationPosition>();
        }
        public void AddFormationPosition(Vector2 posIndex)
        {
            FormationPosition pos = new FormationPosition(posIndex);
            m_lstFormation.Add(pos);
        }

        public FormationPosition GetFormationPosition(int formationIndex)
        {
            if (m_lstFormation == null)
                return null;
            if (formationIndex >= m_lstFormation.Count)
                return null;

            return m_lstFormation[formationIndex];
        }
        public int GetFormationSize()
        {
            if (m_lstFormation == null)
                return 0;

            return m_lstFormation.Count;
        }
        public String GetFromationName()
        {
            return m_sFormationName;
        }
    }
}
