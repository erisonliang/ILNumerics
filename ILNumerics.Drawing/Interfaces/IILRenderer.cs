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
using ILNumerics.Drawing; 
using ILNumerics.Drawing.Controls; 
using ILNumerics.Drawing.Labeling; 

namespace ILNumerics.Drawing.Interfaces {
    /// <summary>
    /// interface for all classes capable of renderung (device 
    /// dependent) texts into plot panels 
    /// </summary>
    /// <remarks>class definitions should also implement the ILRendererAttribute. See <see cref="ILNumerics.Drawing.Platform.OpenGL.ILOGLRenderer"/> for an example.</remarks>
    /// <seealso cref="ILNumerics.Drawing.Platform.OpenGL.ILOGLRenderer"/>
    public interface IILRenderer {
        /// <summary>
        /// The name of the TextRenderer instance (implementation dependant)
        /// </summary>
        string Name { get; }
        /// <summary>
        /// A more descriptive name to be displayed into GUI's (implementation dependant)
        /// </summary>
        string NameLong { get; } 
        /// <summary>
        /// Get the graphics device type this TextRenderer instance 
        /// is capable to use for drawing 
        /// </summary>
        GraphicDeviceType DeviceType { get; }
        /// <summary>
        /// Determine, if the text is to be drawn after the rendering 
        /// backbuffer has been swapped and presented to the screen. (implementation dependent)
        /// </summary>
        bool DrawAfterBufferSwapped { get; } 
        /// <summary>
        /// Determine, if this renderer chaches the output (implementation dependent) 
        /// </summary>
        bool Cached { get; }
        /// <summary>
        /// begins drawing, to be called before Draw()!
        /// </summary>
        /// <param name="g">graphics object (from OnPaint event)</param>
        /// <returns>The finally selected font. The font may be different 
        /// from the one requested.</returns>
        void Begin (Graphics g); 
        /// <summary>
        /// Draw the text 
        /// </summary>
        /// <param name="renderQueue">contains items to be drawn</param>
        /// <param name="location">location relative to surface, starting point for drawing</param>
        /// <param name="orientation">orientation for item</param>
        /// <remarks>
        /// <para>Before calling Draw(), the TextRenderer must have been initialized with Prepare(g)!</para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">on attempt to draw any text without previous initialization</exception>
        void Draw (ILRenderQueue renderQueue, System.Drawing.Point position, TextOrientation orientation, Color color); 
        /// <summary>
        /// finalizes the drawing (must prepare it again before drawing!)
        /// </summary>
        void End(); 
        /// <summary>
        /// Cache single item into the renderer cache. 
        /// </summary>
        /// <param name="key">key used to uniquely identify the item in cache</param>
        /// <param name="bmp">item bitmap data</param>
        /// <param name="rect">section in bmp to be transfered into the cache</param>
        void Cache(string key, Bitmap bmp, RectangleF rect); 
        /// <summary>
        /// test if an item for a specific key is already cached
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool ExistsKey(string key); 
        /// <summary>
        /// test if the key exists and return the size of corresponding item on success
        /// </summary>
        /// <param name="key">key identifying the item</param>
        /// <param name="size">if the key was found: the size of the corresponding item</param>
        /// <returns>true, if the key exist, false otherwise</returns>
        bool TryGetSize(string key, ref Size size); 

        /// <summary>
        /// for cached renderers, fires if the internal cache was cleared
        /// </summary>
        event EventHandler CacheCleared; 

    }
}