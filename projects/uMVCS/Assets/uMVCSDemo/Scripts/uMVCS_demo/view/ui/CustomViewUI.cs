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
	public class CustomViewUI : MonoBehaviour
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

		private float _contentsGapHorizontal_float;
		private float _contentsGapVertical_float;
		private float _currentY_float;
		private float _windowWidth_float;
		private float _windowHeight_float;
		private float _windowX_float;
		private float _windowY_float;
		private float _contentsWidth_float;
		
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
		public CustomViewUI( )
		{
			//Debug.Log ("CustomViewUI.constructor()");
			
		}
		
		~CustomViewUI()
		{
			
		}
		
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
			_contentsGapHorizontal_float 	= 20;
			_contentsGapVertical_float		= 15;
			_currentY_float 				= 0;
			_windowWidth_float 				= 500;
			_windowHeight_float 			= 300;
			_windowX_float					= Screen.width/2 - _windowWidth_float/2;
			_windowY_float					= Screen.height/2 - _windowHeight_float/2;
			_contentsWidth_float			= _windowWidth_float - 2*_contentsGapHorizontal_float;
			
		}
		
		/// <summary>
		/// Raises the GU event.
		/// </summary>
		public void OnGUI ()
		{

			//SET SKIN FROM INSPECTOR
			GUI.skin = guiSkin;

			//RESET FOR NEXT FRAME WHEN THIS IS ALL REDRAWN AGAIN (PER UNITY'S GUI LIFECYCLE)
			_currentY_float = 0;

			//LAYOUT
			Rect windowRect = new Rect (_windowX_float, _windowY_float, _windowWidth_float, _windowHeight_float);
			windowRect = GUI.Window (0, windowRect, _onWindowContentCreationStart, "uMVCS Template Demo");

		}




		// PRIVATE

		
		/// <summary>
		/// _windows the function.
		/// </summary>
		/// <param name="windowID">Window I.</param>
		private void _onWindowContentCreationStart (int aWindowID_int) {


			//RESET TO '0' IN THE WINDOW
			_currentY_float = _contentsGapVertical_float*3;
			
			
			//LAYOUT
			GUI.Label (new Rect  (_contentsGapHorizontal_float, _currentY_float, _contentsWidth_float, 20), "TEXT OUTPUT");
			
			
			//
			//SPACING
			_currentY_float += _contentsGapHorizontal_float + 10;
			
			
			//LAYOUT
			//GUI.BeginScrollView()
			GUI.TextArea (new Rect (_contentsGapHorizontal_float, _currentY_float, _contentsWidth_float, 120),  _getFormattedList (_favoriteVideogamesList_string));
			//GUI.EndScrollView();
			
			
			//
			//SPACING
			_currentY_float += (_contentsGapHorizontal_float) + 120;
			
			
			//LAYOUT
			GUI.Label (new Rect (_contentsGapHorizontal_float, _currentY_float, _contentsWidth_float, 20), "BUTTON MENU");
			
			
			//
			//SPACING
			_currentY_float += _contentsGapHorizontal_float + 10;
			
			
			//LAYOUT
			if (GUI.Button(new Rect(_contentsGapHorizontal_float, _currentY_float, _contentsWidth_float/2, 50), "Clear Message")){
				Debug.Log("User Clicked: Clear Message");
				UMVCS.Instance.controller.eventDispatcher.dispatchEvent (new CustomViewUIEvent (CustomViewUIEvent.CLEAR_BUTTON_CLICK)); 
			}
			
			
			//
			//SPACING
			//(NO VERTICAL CHANGE)
			
			
			//LAYOUT
			if (GUI.Button(new Rect(_contentsGapVertical_float + _contentsWidth_float/2, _currentY_float, _contentsWidth_float/2, 50), "Load Message")){
				Debug.Log("User Clicked: Load Message");
				UMVCS.Instance.controller.eventDispatcher.dispatchEvent (new CustomViewUIEvent (CustomViewUIEvent.RELOAD_BUTTON_CLICK)); 
			}
			
		}


		
		/// <summary>
		/// _gets the formatted list.
		/// </summary>
		/// <returns>The formatted list.</returns>
		/// <param name="_favoriteVideogamesList_string">_favorite videogames list_string.</param>
		private string _getFormattedList (List<string> _favoriteVideogamesList_string)
		{
			string formatted_string = "";
			if (_favoriteVideogamesList_string != null) {
				//PRINT FULL INFO
				formatted_string += "Favorite Videogames Loaded From External Service:\n";
				//
				foreach (string s in _favoriteVideogamesList_string) {
					formatted_string += s + "\n";
				}
			} else {
				//PRINT NOTHING
				formatted_string += "";
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
