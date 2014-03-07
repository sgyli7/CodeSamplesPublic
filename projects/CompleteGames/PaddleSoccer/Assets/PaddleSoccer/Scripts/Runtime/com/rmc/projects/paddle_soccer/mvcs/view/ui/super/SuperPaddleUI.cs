/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
using strange.extensions.mediation.impl;
using com.rmc.projects.paddle_soccer.components;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.mvcs.view.ui.super
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Paddle position.
	/// </summary>
	public enum PaddlePosition
	{
		ScreenLeft,
		ScreenRight

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	[RequireComponent (typeof(Animator))]
	public class SuperPaddleUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		/// <summary>
		/// The _target y_float.
		/// </summary>
		public float targetY
		{ 
			get{
				return _paddleComponent.targetY;
			}
			set
			{
				_paddleComponent.targetY = value;
				
			}
		}

		
		// PUBLIC
		
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="com.rmc.projects.paddle_soccer.mvcs.view.ui.PlayerPaddleUI"/> is
		/// running update.
		/// 
		/// NOTE: This is set by mediator based on GameState.
		/// NOTE: Defaults to false
		/// 
		/// </summary>
		/// <value><c>true</c> if is running update; otherwise, <c>false</c>.</value>
		public bool isRunningUpdate {get;set;}


		
		// PUBLIC STATIC
		
		// PRIVATE

		/// <summary>
		/// The _paddle component.
		/// </summary>
		protected PaddleComponent _paddleComponent;


		/// <summary>
		/// The _ paddle position.
		/// 
		/// NOTE: for Subclasses
		/// 
		/// </summary>
		protected PaddlePosition _paddlePosition;



		
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		/// <summary>
		/// Init this instance.
		/// </summary>
		public virtual void init ()
		{
		}
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			_paddleComponent = GetComponent<PaddleComponent>();

			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			
		}
		
		
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy ()
		{
			//
			base.OnDestroy();
			
		}
		
		// PUBLIC
		/// <summary>
		/// Do the reset Y position.
		/// </summary>
		public void doResetYPosition ()
		{
			_paddleComponent.doResetYPosition();
		}

		/// <summary>
		/// Do the tween to starting position.
		/// </summary>
		public void doTweenToStartingPosition ()
		{
			_paddleComponent.doTweenToStartingPosition ();
		}

		/// <summary>
		/// Do the tween to starting position.
		/// </summary>
		public void doTweenToOffscreenPosition ()
		{
			//
			if (_paddlePosition == PaddlePosition.ScreenLeft) {
				_paddleComponent.doTweenToOffscreenPosition(-1f);
			} else {
				_paddleComponent.doTweenToOffscreenPosition(1f);
			}
		}



		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		
		
	}
}

