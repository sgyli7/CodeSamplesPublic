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
using com.rmc.projects.bowling_strangeioc.mvc.controller.signals;
using com.rmc.projects.bowling_strangeioc.mvc.model;
using com.rmc.projects.bowling_strangeioc.mvc.model.vo;
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using strange.extensions.mediation.impl;
using com.rmc.projects.spider_strike.mvcs.view.ui;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.spider_strike.mvcs.view
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
	public class EnemyUIMediator : Mediator
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------

		/// <summary>
		/// Gets or sets the view.
		/// </summary>
		/// <value>The view.</value>
		[Inject]
		public EnemyUI view 	{ get; set;}

		/// <summary>
		/// Gets or sets the turret do move signal.
		/// </summary>
		/// <value>The turret do move signal.</value>
		//[Inject]
		//public TurretDoMoveSignal turretDoMoveSignal 		{ get; set;}

		// PUBLIC

		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Raises the register event.
		/// </summary>
		public override void OnRegister()
		{

			//turretDoMoveSignal.AddListener (onInputModeChangedSignal);



		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			//turretDoMoveSignal.RemoveListener (onInputModeChangedSignal);
		}


		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{


		}

		
		//	PUBLIC
		
		
		// PRIVATE

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------

	}
}

