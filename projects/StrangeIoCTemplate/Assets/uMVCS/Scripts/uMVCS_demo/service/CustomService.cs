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
using com.rmc.projects.umvcs.controller.events;
using com.rmc.projects.umvcs.service;
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
	public class CustomService : IService
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
		public CustomService( )
		{
			//Debug.Log ("CustomService.constructor()");
		}
		
		~CustomService()
		{
			
		}


		/// <summary>
		/// Dos the load favorite videogames.
		/// </summary>
		public void doLoadFavoriteVideogames ()
		{
			//
			List<string> favoriteVideogamesList_string = new List<string>();

			// A SERVICE SHOULD LOAD DATA FROM AN EXTERNAL SOURCE (see "Resources" folder)
			TextAsset textAsset = (TextAsset) Resources.Load("FavoriteVideogamesList", typeof(TextAsset));

			//CONVERT ARRAY TO LIST FOR EASIER USAGE
			string[] favoriteVideogamesArray_string = textAsset.text.Split ("\n"[0]);
			foreach (string s in favoriteVideogamesArray_string) {
				favoriteVideogamesList_string.Add (s);
			}
			
			//WHEN IT IS LOADED, SEND AN EVENT
			UMVCS.Instance.controller.eventDispatcher.dispatchEvent (new CustomServiceEvent (CustomServiceEvent.FAVORITE_VIDEOGAMES_LOADED, favoriteVideogamesList_string)); 


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
			UMVCS.Instance.controller.eventDispatcher.addEventListener (UMVCSEvent.APPLICATION_START, onApplicationStart); 
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the application start.
		/// </summary>
		/// <param name="aUMVCSEvent">A UMVCS event.</param>
		public void onApplicationStart (IEvent aIEvent)
		{

			//STRONG TYPE EVENT
			UMVCSEvent uMVCSEvent = aIEvent as UMVCSEvent;

			Debug.Log ("CustomService.onApplicationStart() uMVCSEvent: " + uMVCSEvent);
		
			doLoadFavoriteVideogames();

		}



	}
}
