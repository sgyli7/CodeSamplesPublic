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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.umvcs
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
	public class UMVCS : MonoBehaviour
	{

		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		/// <summary>
		/// The Model.
		/// 
		/// NOTE: Current limitation: 0 or 1 model
		/// </summary>
		private IModel _model;
		public IModel model 
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
		/// The View.
		/// 
		/// NOTE: Current limitation: 0 or 1 View
		/// </summary>
		private IView _view;
		public IView view 
		{
			get 
			{
				return _view;
			}
			set 
			{
				_view = value;
			}
		}
		/// <summary>
		/// The Controller.
		/// 
		/// NOTE: Current limitation: 0 or 1 Controller
		/// </summary>
		private IController _controller;
		public IController controller 
		{
			get 
			{
				return _controller;
			}
			set 
			{
				_controller = value;
			}
		}



		/// <summary>
		/// The Service.
		/// 
		/// NOTE: Current limitation: 0 or 1 Service
		/// </summary>
		private IService _service;
		public IService service 
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
		///<summary>
		///	 NAME: GameObject contianing the UMVCS
		///</summary>
		private static string _NAME_UMVCS = "_UMVCS";
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		///<summary>
		///	 Persist Instance
		///</summary>
		public void Awake() 
		{ 
			//
			DontDestroyOnLoad (this);
		}
		
		
		///<summary>
		///	 Destroy Instance
		///</summary>
		public void OnApplicationQuit() 
		{ 
			//
			_Instance = null; //NOTE, ITS STILL SITTING IN HIERARCHY?
			
			//TODO, SHOULD IT DELETE FROM HIERARCHY?
		}

		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update() 
		{ 
			//Debug.Log ("Update");
		}
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		private UMVCS( )
		{
			//Debug.Log ("SimpleGameManagerComponent.constructor()");
		
			
		}
		
		public void destroy()
		{
			Debug.Log ("UMVCS.destroy(): " + gameObject);
			DestroyImmediate (gameObject);	
		}
		


		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			SINGLETON SETUP
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		
		///<summary>
		///	 Instance SETTER/GETTER
		///</summary>
		private static UMVCS _Instance;
		public static UMVCS Instance 
		{
			get 
			{
				
				//IF THERE IS NOT ALREADY AN INSTANCE CREATED
				if (_Instance == null) {
					
					//1. CREATE A GAME OBJECT (IF MISSING)
					GameObject tempInstance_umvcs =  GameObject.Find (UMVCS._NAME_UMVCS);
					if (tempInstance_umvcs == null) {
						tempInstance_umvcs = new GameObject (UMVCS._NAME_UMVCS);
					
						//2. ADD FLAGS TO HIDE EVERYTHING FROM HIERARCHY (OPTIONAL)
						tempInstance_umvcs.hideFlags = HideFlags.HideInHierarchy;
					}
					
					//3. CREATE A COMPONENT ON THE GAME OBJECT
					_Instance = tempInstance_umvcs.GetComponent<UMVCS>();
					if (_Instance == null) {
						_Instance = tempInstance_umvcs.AddComponent<UMVCS>(); 	
					}
					
					
				} 
				
				return _Instance;
			}
		}
		

		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		public void onFavoriteVideogamesLoaded ()
		{


		}
	}
}

