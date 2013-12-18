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
using System.Collections.Generic;
using com.rmc.projects.strangeioc_template.mvcs.controller.signals;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.strangeioc_template.mvcs.service
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
		[Inject]
		public CustomServiceLoadedSignal customServiceLoadedSignal {get;set;}
		
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
		/// Dos the load videogames.
		/// </summary>
		public void doLoadGameList ()
		{

			
			Debug.Log ("3. CustomService.doLoadGameList()");
			
			/*
			 * 
			 * FAKE A (MORE COMMON) ASYNCH CALL, JUST USE A SYNCH CALL TO LOAD THE TEXT
			 * 
			 * 
			**/
			_onLoadedGameList();

			
			
		}
		
		
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// _ons the loaded game list.
		/// </summary>
		private void _onLoadedGameList ()
		{
			
			Debug.Log ("4. CustomService._onLoadedGameList()");

			//
			List<string> gamesList_string = new List<string>();
			
			// A SERVICE SHOULD LOAD DATA FROM AN EXTERNAL SOURCE (see "Resources" folder)
			TextAsset textAsset = (TextAsset) Resources.Load("FavoriteVideogamesList", typeof(TextAsset));
			
			//CONVERT ARRAY TO LIST FOR EASIER USAGE
			string[] favoriteVideogamesArray_string = textAsset.text.Split ("\n"[0]);
			foreach (string s in favoriteVideogamesArray_string) {
				gamesList_string.Add (s);
			}
			
			//WHEN IT IS LOADED, SEND AN EVENT
			customServiceLoadedSignal.Dispatch (gamesList_string);
		}

		
	}
}
