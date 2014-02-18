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

//--------------------------------------
//  Namespace
//--------------------------------------
using UnityEngine;


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
	public static class DebugDraw
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
		/// Draws the rect.
		/// </summary>
		/// <param name="aRect">A rect.</param>
		/// <param name="zCoordinate_float">Z coordinate_float.</param>
		public static void DrawRect (Rect aRect, float aZPlaneCoordinate_float, Color aColor)
		{
	
			//Debug.Log ("x: " + aRect.x + " ,y= " + aRect.y);
			//DRAW BOX FROM BOTTOM LEFT AND GO CLOCKWISE
			Debug.DrawLine (new Vector3 (aRect.x, aRect.y, aZPlaneCoordinate_float), 								new Vector3 (aRect.x, aRect.y + aRect.height, aZPlaneCoordinate_float), aColor);
			Debug.DrawLine (new Vector3 (aRect.x, aRect.y + aRect.height, aZPlaneCoordinate_float), 				new Vector3 (aRect.x + aRect.width, aRect.y + aRect.height, aZPlaneCoordinate_float), aColor);
			Debug.DrawLine (new Vector3 (aRect.x + aRect.width, aRect.y + aRect.height, aZPlaneCoordinate_float), new Vector3 (aRect.x + aRect.width, aRect.y, aZPlaneCoordinate_float), aColor	);
			Debug.DrawLine (new Vector3 (aRect.x + aRect.width, aRect.y, aZPlaneCoordinate_float), 				new Vector3 (aRect.x, aRect.y, aZPlaneCoordinate_float), aColor);

		}


		/// <summary>
		/// Draws the center point crosshairs for rect.
		/// </summary>
		/// <param name="rect">Rect.</param>
		/// <param name="_zPlaneCoordinate_float">_z plane coordinate_float.</param>
		public static void DrawCenterPointCrosshairsForRect (Rect aRect, float aZPlaneCoordinate_float, Color aColor)
		{
			//Debug.Log ("DRAW" + aRect);
			float crossHairLength_float = 0.5f;

			//LOWER LEFT TO UPPER RIGHT
			Debug.DrawLine 	(
				new Vector3 (aRect.center.x - crossHairLength_float/2, aRect.center.y - crossHairLength_float/2, aZPlaneCoordinate_float), 								
				new Vector3 (aRect.center.x + crossHairLength_float/2, aRect.center.y + crossHairLength_float/2, aZPlaneCoordinate_float),
				aColor
				);

			//UPPER LEFT TO LOWER LEFT
			Debug.DrawLine 	(
				new Vector3 (aRect.center.x - crossHairLength_float/2, aRect.center.y + crossHairLength_float/2, aZPlaneCoordinate_float), 								
				new Vector3 (aRect.center.x + crossHairLength_float/2, aRect.center.y - crossHairLength_float/2, aZPlaneCoordinate_float),
				aColor
				);



		}


		/// <summary>
		/// Dos the draw line between crosshairs.
		/// </summary>
		/// <param name="aRect1">A rect1.</param>
		/// <param name="aRect2">A rect2.</param>
		/// <param name="aZPlaneCoordinate_float">A Z plane coordinate_float.</param>
		/// <param name="color">Color.</param>
		public static void DrawLineBetweenCrosshairs (Rect aRect1, Rect aRect2, float aZPlaneCoordinate_float, Color aColor)
		{
			Debug.DrawLine 	(
				new Vector3 (aRect1.center.x, aRect1.center.y, aZPlaneCoordinate_float), 								
				new Vector3 (aRect2.center.x, aRect2.center.y, aZPlaneCoordinate_float), 
				aColor
				);
		}

		/// <summary>
		/// Draws the center point cross.
		/// </summary>
		/// <param name="aRect">A rect.</param>
		/// <param name="aZPlaneCoordinate_float">A Z plane coordinate_float.</param>
		/// <param name="aColor">A color.</param>
		public static void DrawCenterPointCross (Rect aRect, float aZPlaneCoordinate_float, Color aColor)
		{
			//Debug.Log ("DRAW" + aRect);
			float crossHairLength_float = 2;
			
			//LOWER LEFT TO UPPER RIGHT
			Debug.DrawLine 	(
				new Vector3 (aRect.center.x - crossHairLength_float/2, aRect.center.y, aZPlaneCoordinate_float), 								
				new Vector3 (aRect.center.x + crossHairLength_float/2, aRect.center.y, aZPlaneCoordinate_float),
				aColor
				);
			
			//UPPER LEFT TO LOWER LEFT
			Debug.DrawLine 	(
				new Vector3 (aRect.center.x, aRect.center.y + crossHairLength_float/2, aZPlaneCoordinate_float), 								
				new Vector3 (aRect.center.x, aRect.center.y - crossHairLength_float/2, aZPlaneCoordinate_float),
				aColor
				);
			
			
			
		}


		//--------------------------------------
		//  Events
		//--------------------------------------




	}
}


