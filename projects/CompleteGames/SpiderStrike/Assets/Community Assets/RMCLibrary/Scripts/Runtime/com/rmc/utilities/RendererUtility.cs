/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
 */
// Marks the right margin of code *******************************************************************

//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.utilities
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Utility
	/// </summary>
	public class RendererUtility
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		/// <summary>
		/// Initializes the <see cref="com.rmc.utilities.RendererUtility"/> class.
		/// </summary>
		/// <param name="aRenderer">A renderer.</param>
		/// <param name="aIsVisible_boolean">If set to <c>true</c> a is visible_boolean.</param>
		public static void SetMaterialVisibility (Material aMaterial, bool aIsVisible_boolean)
		{
			float alpha_float;
			if (aIsVisible_boolean) {
				alpha_float = 1;
			} else {
				alpha_float = 0;
			}
			SetMaterialAlpha (aMaterial, alpha_float);;
		}

		/// <summary>
		/// Sets the material alpha.
		/// </summary>
		/// <param name="aMaterial">A material.</param>
		/// <param name="aNewAlpha_bool">If set to <c>true</c> a new alpha_bool.</param>
		public static void SetMaterialAlpha (Material aMaterial, float aNewAlpha_float)
		{
			Color color = aMaterial.color;
			aMaterial.color = new Color(color.r, color.g, color.b, aNewAlpha_float);
		}


		/// <summary>
		/// Sets the GUI texture visibility.
		/// </summary>
		/// <param name="aGUITexture">A GUI texture.</param>
		/// <param name="aIsVisible_boolean">If set to <c>true</c> a is visible_boolean.</param>
		public static void SetGUITextureVisibility (GUITexture aGUITexture, bool aIsVisible_boolean)
		{
			float alpha_float;
			if (aIsVisible_boolean) {
				alpha_float = 1;
			} else {
				alpha_float = 0;
			}
			Color color = aGUITexture.color;
			aGUITexture.color = new Color(color.r, color.g, color.b, alpha_float);
		}

		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
		

	}
}

