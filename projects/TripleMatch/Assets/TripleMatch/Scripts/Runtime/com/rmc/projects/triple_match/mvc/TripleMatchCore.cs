/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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
using System.Collections.Generic;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;
using com.rmc.projects.triple_match.view;
using com.rmc.support;
using System.Collections;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.view
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
	public class TripleMatchCore : SingletonMonobehavior<TripleMatchCore>  
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		/// <summary>
		/// All views for the game
		/// </summary>
		[SerializeField]
		private List<AbstractView> _abstractViews;

		
		// 	PUBLIC
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	
		
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{
			
			//	MODEL
			Model.Instantiate();
			
			//	CONTROLLER
			Controller.Instantiate();
			Controller.Instance.Initialize (Model.Instance);
			
			
			//	VIEW
			foreach (AbstractView abstractview in _abstractViews)
			{
				abstractview.Initialize (Model.Instance, Controller.Instance);
			}
			
			//	Mimic 'Game Reset' Click
			//	After short delay ...
			//		1. of 1 frame or more for View to be 'ready'
			//		2. and its also a delay for cosmetics
			StartCoroutine (_StartGame_Coroutine());
		}

		
		///<summary>
		///	Called once per frame
		///</summary>
		protected void Update () 
		{
			
			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC
		
		
		//	PRIVATE
		


		//--------------------------------------
		// 	Coroutines
		//--------------------------------------

		/// <summary>
		/// Starts the game after short delay.
		/// </summary>
		private IEnumerator _StartGame_Coroutine ()
		{
			yield return new WaitForSeconds (TripleMatchConstants.DELAY_TO_START_GAME);
			
			//	Mimic 'Game Reset' Click
			Controller.Instance.GameReset();
			
			yield return 0;
		}
		
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}

