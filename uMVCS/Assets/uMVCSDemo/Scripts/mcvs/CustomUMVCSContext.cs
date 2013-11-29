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
	public class CustomUMVCSContext : AbstractContext
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
		/// <summary>
		/// Awake this instance.
		/// </summary>
		public void Awake() 
		{ 

		}
		

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start() 
		{ 

			//1. ALL OF YOUR *MVCS CUSTOM SETUP CODE** GOES HERE
			//
			//	NOTE: THE ORDER HERE MATTERS, SOME CONSTRUCTORS DEPEND ON THE OTHER CLASSES ALREADY BEING CREATED
			//
			UMVCS.Instance.model 		= new CustomModel();
			UMVCS.Instance.view 		= new CustomView();
			UMVCS.Instance.controller 	= new CustomController();
			UMVCS.Instance.service 		= new CustomService();


			//INITALIZE EACH OF THE 4 ACTORS LISTED JUST ABOVE
			doRegisterAllActors();

			//SENDS THE "UMVCSEvent.APPLICATION_START" EVENT
			doApplicationStart();

			
		}
		
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///			CONSTRUCTOR / DESTRUCTOR
		///////////////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////////////
		///<summary>
		///	 Constructor
		///</summary>
		public CustomUMVCSContext( )
		{
			//Debug.Log ("CustomUMVCSContext.constructor()");
			
		}

		~CustomUMVCSContext()
		{

		}

		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

