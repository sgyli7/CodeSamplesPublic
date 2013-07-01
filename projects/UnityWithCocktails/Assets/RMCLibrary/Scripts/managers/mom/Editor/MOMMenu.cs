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
 */
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using UnityEditor;
using System.Collections;
using com.rmc.utilities;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.managers.mom.Editor
{
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class MOMMenu 
	{
			
	
		//--------------------------------------
		//  Attributes
		//--------------------------------------
			
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
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
		/// Shows the window.
		/// </summary>
		[MenuItem("RMC/MOM/Show Editor", false, 50)]
		public static void ShowEditorWindow()
		{
			//Show existing window instance. If one doesn't exist, make one.
			bool isUtility_boolean 		= false; //false means dockable
			EditorWindow.GetWindow		(	typeof(MOMEditorWindow), isUtility_boolean, "MOM Editor");
		}
		
		
		/// <summary>
		/// Creates the asset from selected.
		/// </summary>
		[MenuItem("RMC/MOM/Create ScriptableObject From Project Selection", false, 50)]
		public static void CreateAssetFromSelected ()
		{
			ScriptableObjectUtility.CreateAssetFromProjectSelection ();
			
		}
		
		
		/// <summary>
		/// Creates the asset from selected validate function.
		/// </summary>
		/// <returns>
		/// The asset from selected validate function.
		/// </returns>
		[MenuItem("RMC/MOM/Create ScriptableObject From Project Selection", true, 50)]
		public static bool CreateAssetFromSelectedValidateFunction ()
		{
			return ScriptableObjectUtility.hasValidProjectSelection ();
			
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
	}
}
