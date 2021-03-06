#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Interfaces; 
using ILNumerics.Drawing.Controls; 

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// general label, drawn in world coords
    /// </summary>
    public class ILWorldLabel : ILLabelingElement {

        #region attributes
        private int m_padding; 
        private LabelAlign m_align; 
        private ILPoint3Df m_minPosition;
        private ILPoint3Df m_maxPosition; 
        #endregion

        #region properties 
        
        /// <summary>
        /// get/ set the minimum position for the label
        /// </summary>
        public ILPoint3Df PositionMin {
            get {
                return m_minPosition; 
            }
            set {
                m_minPosition = value; 
            }
        }
        /// <summary>
        /// get/ set the maximium position for the label
        /// </summary>
        public ILPoint3Df PositionMax {
            get {
                return m_maxPosition; 
            }
            set {
                m_maxPosition = value; 
            }
        }
        /// <summary>
        /// Alignment along the axis value range. Possible values: lower, center, upper
        /// </summary>
        public LabelAlign Alignment {
            get {
                return m_align; 
            }
            set {
                m_align = value; 
                OnChanged(); 
            }
        }

        /// <summary>
        /// Get/ set the padding used to seperate the label from the elements around it
        /// </summary>
        public int Padding {
            get {
                return m_padding; 
            }
            set {
                m_padding = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// create a label for rendering
        /// </summary>
        public ILWorldLabel (ILPanel panel) 
            : base(panel,new Font(FontFamily.GenericSansSerif,10.0f)
                    ,Color.DarkBlue,CoordSystem.World3D) {
            m_align = LabelAlign.Center; 
            m_padding = 3; 
        }
        #endregion

        #region abstract overrides

        /// <summary>
        /// draws the whole rendering queue
        /// </summary>
        public override void Draw(ILRenderProperties p) {
            if (m_expression != m_cachedExpression) 
                interprete(m_expression); 
            m_renderer.Begin(p);
            //offsetAlignment(m_size,ref m_position);
            m_renderer.Draw(m_renderQueue
                ,m_minPosition.X,m_minPosition.Y,m_minPosition.Z
                ,m_maxPosition.X,m_maxPosition.Y,m_maxPosition.Z
                ,m_color); 
            m_renderer.End(p); 
        }

        #endregion

        #region private helper


        #endregion
    }
}
