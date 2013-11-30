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
	public class CustomController : IController
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The IEventDispatcher.
		/// </summary>
		private IEventDispatcher _eventDispatcher;
		public IEventDispatcher eventDispatcher 
		{
			get 
			{
				return _eventDispatcher;
			}
			set 
			{
				_eventDispatcher = value;
			}
		}


		// GETTER / SETTER
		/// <summary>
		/// The Model.
		/// 
		/// NOTE: Current limitation: 0 or 1 model
		/// </summary>
		private CustomModel _model;
		public CustomModel model 
		{
			get 
			{
				return _model;
			}
			set 
			{
				_model = value;
			}
		}

		/// <summary>
		/// The Service.
		/// 
		/// NOTE: Current limitation: 0 or 1 Service
		/// </summary>
		private CustomService _service;
		public CustomService service 
		{
			get 
			{
				return _service;
			}
			set 
			{
				_service = value;
			}
		}


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
		public CustomController( )
		{

			//Debug.Log ("CustomController.constructor()");
			eventDispatcher = new EventDispatcher (this);

		}
		
		~CustomController()
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

			//STORE STRONG TYPED REFERENCE - ITS 'OK' FOR CONTROLLER TO CALL ON MODEL
			model = UMVCS.Instance.model as CustomModel;
			service = UMVCS.Instance.service as CustomService;
			
			//LISTEN
			UMVCS.Instance.controller.eventDispatcher.addEventListener (CustomServiceEvent.FAVORITE_VIDEOGAMES_LOADED, 	onFavoriteVideogamesLoaded); 
			UMVCS.Instance.controller.eventDispatcher.addEventListener (CustomViewUIEvent.RELOAD_BUTTON_CLICK, 			onReloadButtonClick); 
			UMVCS.Instance.controller.eventDispatcher.addEventListener (CustomViewUIEvent.CLEAR_BUTTON_CLICK, 			onClearButtonClick); 


		}



		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// When games are loaded from the service
		/// </summary>
		/// <param name="aUMVCSEvent">A UMVCS event.</param>
		public void onFavoriteVideogamesLoaded (IEvent aIEvent)
		{

			CustomServiceEvent customServiceEvent = aIEvent as CustomServiceEvent;

			Debug.Log ("CustomController.onFavoriteVideogamesLoaded() customServiceEvent: " + customServiceEvent.favoriteVideogamesList);

			//CONTROLLER IS BOUND TO MODEL
			model.favoriteVideogamesList = customServiceEvent.favoriteVideogamesList;
			
		}



		/// <summary>
		/// Ons the clear button click.
		/// </summary>
		/// <param name="aIEvent">A I event.</param>
		public void onClearButtonClick (IEvent aIEvent)
		{
			
			//CALL MODEL DIRECTLY, THAT IS 'OK'
			model.doClearAllData();
			
		}

		/// <summary>
		/// Ons the reload button click.
		/// </summary>
		/// <param name="aIEvent">A I event.</param>
		public void onReloadButtonClick (IEvent aIEvent)
		{
			
			//CALL SERVICE DIRECTLY, THAT IS 'OK'
			service.doLoadFavoriteVideogames();
			
		}


	}
}
