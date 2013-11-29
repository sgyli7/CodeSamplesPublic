/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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
using System.Collections;
using System.Collections.Generic;
using com.rmc.projects.umvcs;
using com.rmc.projects.event_dispatcher;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.umvcs_demo
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
	public class CustomViewComponent : MonoBehaviour
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The _favorite videogames list_string.
		/// </summary>
		private List<string> _favoriteVideogamesList_string;
		public List<string> favoriteVideogamesList
		{
			get 
			{
				return _favoriteVideogamesList_string;
			}
			set 
			{
				_favoriteVideogamesList_string = value;
			}
		}

		
		// PUBLIC
		/// <summary>
		/// The GUI skin.
		/// </summary>
		public GUISkin guiSkin;


		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public CustomViewComponent( )
		{
			//Debug.Log ("CustomViewComponent.constructor()");
			
		}
		
		~CustomViewComponent()
		{
			
		}


		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{


		}

		/// <summary>
		/// Raises the GU event.
		/// </summary>
		public void OnGUI ()
		{
			GUI.skin = guiSkin;

			float width_float = 500;
			float gapHorizontal_float = 10;
			float gapVertical_float = 20;
			float currentY_float = 0;


			//
			//SPACING
			currentY_float += gapHorizontal_float;
			
			//LAYOUT
			GUI.Label (new Rect  (gapHorizontal_float, currentY_float, width_float, 20), "INSTRUCTIONS");
			
			//
			//SPACING
			currentY_float += gapHorizontal_float + 20;
			
			
			//LAYOUT
			GUI.TextArea (new Rect (gapHorizontal_float, currentY_float, width_float, 80), "Use the menu buttons to test a complete, simple use case for the the uMVCS framework. The flow is...\n\nUI(Button)->View->Controller->Service->Model->View->UI(TextArea)");


			//
			//SPACING
			currentY_float += (gapHorizontal_float*3) + 80;

			//LAYOUT
			GUI.Label (new Rect  (gapHorizontal_float, currentY_float, width_float, 20), "TEXT OUTPUT");


			//
			//SPACING
			currentY_float += gapHorizontal_float + 20;


			//LAYOUT
			//GUI.BeginScrollView()
			GUI.TextArea (new Rect (gapHorizontal_float, currentY_float, width_float, 120), "Favorite Videogames Loaded From External Service:\n"+  _getFormattedList (_favoriteVideogamesList_string));
			//GUI.EndScrollView();


			//
			//SPACING
			currentY_float += (gapHorizontal_float*2) + 120;
			
			
			//LAYOUT
			GUI.Label (new Rect (gapHorizontal_float, currentY_float, width_float, 20), "BUTTON MENU");


			//
			//SPACING
			currentY_float += gapHorizontal_float + 20;
			
			
			//LAYOUT
			if (GUI.Button(new Rect(gapHorizontal_float, currentY_float, width_float/2, 50), "CLEAR DISPLAY")){
				//Debug.Log("You clicked the button!");
				UMVCS.Instance.controller.eventDispatcher.dispatchEvent (new CustomEvent (CustomEvent.CLEAR_BUTTON_CLICK)); 
			}


			//
			//SPACING
			//(NO VERTICAL CHANGE)
			
			
			//LAYOUT
			if (GUI.Button(new Rect(gapVertical_float + width_float/2, currentY_float, width_float/2, 50), "RELOAD DISPLAY")){
				Debug.Log("You clicked the button!" + UMVCS.Instance.controller.eventDispatcher);
				UMVCS.Instance.controller.eventDispatcher.dispatchEvent (new CustomEvent (CustomEvent.RELOAD_BUTTON_CLICK)); 
			}



		}
		
		// PRIVATE
		/// <summary>
		/// _gets the formatted list.
		/// </summary>
		/// <returns>The formatted list.</returns>
		/// <param name="_favoriteVideogamesList_string">_favorite videogames list_string.</param>
		private string _getFormattedList (List<string> _favoriteVideogamesList_string)
		{
			string formatted_string = "";
			if (_favoriteVideogamesList_string != null) {
				foreach (string s in _favoriteVideogamesList_string) {
					formatted_string += s + "\n";
				}
			} else {
				formatted_string += "[NO DATA AVAILABLE]";
			}
			return formatted_string;
		}
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------


	}
}
