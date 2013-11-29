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

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.event_dispatcher;


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
	public class CustomView : IView
	{
		
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

		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public CustomView( )
		{
			//Debug.Log ("CustomController.constructor()");
	
		}
		
		~CustomView()
		{
			
		}

		
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			MCVS LIFECYCLE
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Actor is added to MCVS
		/// </summary>
		public void onRegister ()
		{
			UMVCS.Instance.controller.eventDispatcher.addEventListener (CustomEvent.FAVORITE_VIDEOGAMES_CHANGED, onFavoriteVideogamesChanged); 

			
		}

		/// <summary>
		/// Dos the render layout.
		/// </summary>
		/// <param name="favoriteVideogamesList">Favorite videogames list.</param>
		void doRenderLayout (List<string> aFavoriteVideogamesList_string)
		{
			Debug.Log ("VIEW: " + aFavoriteVideogamesList_string);

			CustomViewComponent customViewComponent = GameObject.Find ("CustomViewUI").GetComponent<CustomViewComponent>();

			if (customViewComponent) {

				customViewComponent.favoriteVideogamesList = aFavoriteVideogamesList_string;

			}
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the favorite videogames changed.
		/// </summary>
		/// <param name="aIEvent">A I event.</param>
		public void onFavoriteVideogamesChanged (IEvent aIEvent)
		{
			
			CustomEvent customEvent = aIEvent as CustomEvent;
			
			Debug.Log ("CustomController.onFavoriteVideogamesChanged() customEvent: " + customEvent.favoriteVideogamesList);
			
			doRenderLayout(customEvent.favoriteVideogamesList);
			
		}
	}
}
