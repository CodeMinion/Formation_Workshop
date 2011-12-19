using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
namespace IsometricMap.Formations
{
    public class FormationFactory
    {
        private static FormationFactory m_Instance = null;

        private FormationFactory()
        {

        }

        public static FormationFactory GetInstance()
        {
            if (m_Instance == null)
                m_Instance = new FormationFactory();

            return m_Instance;
        }

        public Formation GetBoxFormation()
        {
            Formation form = new Formation("Box");
            // Add Captain Position, always 0,0
            form.AddFormationPosition(new Vector2(0,0));

            form.AddFormationPosition(new Vector2(-1, -1));
            form.AddFormationPosition(new Vector2(0, 1));
            form.AddFormationPosition(new Vector2(0, -1));
            form.AddFormationPosition(new Vector2(-1, 1));

            return form;
        }
        public Formation GetDiamondFormation()
        {
            Formation form = new Formation("Diamond");
            // Add Captain Position, always 0,0
            form.AddFormationPosition(new Vector2(0, 0));

            form.AddFormationPosition(new Vector2(-1, 0));
            form.AddFormationPosition(new Vector2(1, 0));
            form.AddFormationPosition(new Vector2(0, -2));
            form.AddFormationPosition(new Vector2(0, 2));

            return form;
        
        }
        public Formation GetFightingVFormation()
        {
            Formation form = new Formation("Fighting V");
            // Add Captain Position, always 0,0
            form.AddFormationPosition(new Vector2(0, 0));

            form.AddFormationPosition(new Vector2(0, -1));
            form.AddFormationPosition(new Vector2(-1, -1));
            form.AddFormationPosition(new Vector2(-1, -2));
            form.AddFormationPosition(new Vector2(1, -2));

            return form;
        }
        public Formation GetLineFormation()
        {
            Formation form = new Formation("Line");
            // Add Captain Position, always 0,0
            form.AddFormationPosition(new Vector2(0, 0));

            form.AddFormationPosition(new Vector2(0, 1));
            form.AddFormationPosition(new Vector2(-1, 1));
            form.AddFormationPosition(new Vector2(-2, 1));
            form.AddFormationPosition(new Vector2(1, 1));

            return form;
        
        }
        public Formation GetShieldFormation()
        {
            Formation form = new Formation("Shield");
            // Add Captain Position, always 0,0
            form.AddFormationPosition(new Vector2(0, 0));

            form.AddFormationPosition(new Vector2(0, 1));
            form.AddFormationPosition(new Vector2(-1, 0));
            form.AddFormationPosition(new Vector2(1, 0));
            form.AddFormationPosition(new Vector2(-1, 1));

            return form;

        }
    }
}
