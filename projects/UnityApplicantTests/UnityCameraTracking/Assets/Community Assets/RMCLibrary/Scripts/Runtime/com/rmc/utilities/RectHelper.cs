/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:                                            
 *                                                                      
 * The above copyright notice and this permission notice shall be       
 * included in all copies or substantial portions of the Software.      
 *                                                                      
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.     
 * 
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using System;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.utilities
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Bounds helper.
	/// 
	/// NOTE: Alternatively an extension method on Bounds
	/// 		Could have been added.
	/// 
	/// </summary>
	public static class RectHelper
	{
		
		//--------------------------------------
		//  Attributes 
		//--------------------------------------
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		//--------------------------------------
		//  Methods
		//--------------------------------------

		/// <summary>
		/// Converts the bounds to rect.
		/// </summary>
		/// <param name="aBounds">A bounds.</param>
		/// <param name="aZPlaneCoordinate_float">A Z plane coordinate_float.</param>
		public static Rect ConvertBoundsToRect (Bounds aBounds, float aZPlaneCoordinate_float)
		{
			//
			Vector3 localLowerLeft_float = new Vector3 (aBounds.center.x - aBounds.extents.x , aBounds.center.y - aBounds.extents.y, aBounds.center.z);
			Vector3 localUpperRight_vector = new Vector3 (aBounds.center.x + aBounds.extents.x , aBounds.center.y + aBounds.extents.y, aBounds.center.z);
			
			float localWidth_float   	= localUpperRight_vector.x - localLowerLeft_float.x;
			float localHeight_float 	= localUpperRight_vector.y - localLowerLeft_float.y;
			
			return new Rect (localLowerLeft_float.x, localLowerLeft_float.y, localWidth_float, localHeight_float);


		}

		/// <summary>
		/// Ises the aInner_rect completely within aOuter_rect.
		/// </summary>
		/// <returns><c>true</c>, if rect within rect was ised, <c>false</c> otherwise.</returns>
		/// <param name="aOuter_rect">A outer_rect.</param>
		/// <param name="aInner_rect">A inner_rect.</param>
		public static bool isRectWithinRect (Rect aOuter_rect, Rect aInner_rect) 
		{

			if (aOuter_rect.Contains (new Vector2 (aInner_rect.xMin, aInner_rect.yMin)) &&
			    aOuter_rect.Contains (new Vector2 (aInner_rect.xMax, aInner_rect.yMax)) ){

				return true;

			} else {

				return false;
			}



		}

		//--------------------------------------
		//  Events
		//--------------------------------------



	}
}


