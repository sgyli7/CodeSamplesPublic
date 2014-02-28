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
using System.Collections.Generic;
using com.rmc.projects.strangeioc_template2.mvcs.controller.signals;
using com.rmc.projects.strangeioc_template2.mvcs.model;
using com.rmc.projects.property_change_signal.vo;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.strangeioc_template2.mvcs.model
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
	public class CustomModel : ICustomModel
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The _favorite videogames list_string.
		/// </summary>
		private List<string> _gameList;
		public List<string> gameList 
		{
			get 
			{
				return _gameList;
			}
			set 
			{
				//TODO: CONSIDER ALTERNATIVE THAT CHECKS "_gameList != value" BEFORE DISPATCHING
				_gameList = value;
				Debug.Log ("6. CustomModel.gameList = " + _gameList );
				gameListPropertyChangeSignal.Dispatch (new PropertyChangeSignalVO(PropertyChangeType.UPDATED, _gameList) );
			}
		}


		/// <summary>
		/// Gets or sets the custom model updated signal.
		/// </summary>
		/// <value>The custom model updated signal.</value>
		[Inject]
		public GameListPropertyChangeSignal gameListPropertyChangeSignal {set;get;}

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
		public CustomModel( )
		{
			//Debug.Log ("CustomModel.constructor()");

		}
		
		~CustomModel()
		{
			
		}
		
		/// <summary>
		/// CLEAR ALL DATA
		/// </summary>
		/// 
		public void doClearGameList ()
		{
			gameList = null;
		}	

		/// <summary>
		/// Do refresh game list.
		/// </summary>
		public void doRefreshGameList () 
		{

			//TWO MUTUALLY EXCLUSIVE WAYS TO REFRESH...

			//1. REFRESH VALUE
			//FORCE THE MODEL TO RE-SEND 'UPDATED' (WITH NO CHANGE)
			//THIS IS VERY COMMON IN APPS (E.G. A TEMPORARY A DIALOG PROMPT)
			gameList = gameList;

			//2. AN ALTERNAIVE APPROACH WOULD BE *NOT* 
			//	TO SET THE VALUE, BUT INSTEAD, JUST DISPATCH 'UPDATED' FROM HERE
			//...

		}

		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			STRANGEIOC LIFECYCLE
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		[PostConstruct]
		public void postConstruct( )
		{
			//Debug.Log ("CustomModel.PostConstruct()");
			
		}
		
		
		// PRIVATE
		/// <summary>
		/// CLEAR ALL DATA
		/// </summary>
		/// 
		private void _doClearAllData ()
		{
			//CALL A 'CLEAR' METHOD FOR EACH PIECE OF DATA
			//(HERE, WE HAVE JUST ONE DATA)
			doClearGameList();
		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
