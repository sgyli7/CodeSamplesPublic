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
using strange.extensions.mediation.impl;
using com.rmc.projects.spider_strike.mvcs.view.ui;


//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using UnityEngine;


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
		/// Gets or sets the turret health change signal.
		/// </summary>
		/// <value>The turret health change signal.</value>
		[Inject]
		public TurretHealthChangeSignal turretHealthChangeSignal 		{ get; set;}

		
		
		/// <summary>
		/// The enemy died signal.
		/// </summary>
		[Inject]
		public EnemyDiedSignal enemyDiedSignal {set; get;}

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
			view.init();
			view.uiAnimationCompleteSignal.AddListener (_onUIAnimationCompleteSignal);

		}

		/// <summary>
		/// Raises the remove event.
		/// </summary>
		public override void OnRemove()
		{
			view.uiAnimationCompleteSignal.AddListener (_onUIAnimationCompleteSignal);
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
						
			/*
			 * KLUGE: WE CALL BOTH IMMEDIATLY TO MAKE IT 'WALK'
			 * 
			 **/
			view.doPlayAnimation (AnimationType.IDLE);
			view.doPlayAnimation (AnimationType.WALK);

		}

		/// <summary>
		/// Update this instance.
		/// </summary>
		public void Update()
		{

			//*************************************************
			//******* MIGRATE THIS LOGIC TO MEDIATOR **********
			//*************************************************
			//************* SO, USE PUBLIC METHODS HERE  ******
			//*************************************************
			if (view.animationType == AnimationType.WALK) {

				//
				if (!view.isAtAttackingDistance()) {

					view.doFaceTarget();
					view.doMoveToTarget();

				} else {

					if (view.animationType != AnimationType.ATTACK && view.animationType != AnimationType.DIE) {
						view.doPlayAnimation (AnimationType.ATTACK);
					}
				}

			}
			//*************************************************
			//*************************************************
			//*************************************************
			


		}
		
		//	PUBLIC
		
		
		// PRIVATE
		/// <summary>
		/// _dos the inflict damage.
		/// </summary>
		private void _doInflictDamage ()
		{
			turretHealthChangeSignal.Dispatch (-1f);


		}

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// _ons the user interface animation complete signal.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		private void _onUIAnimationCompleteSignal (AnimationType aAnimationType)
		{
			//Debug.Log ("AnimEnd: " + aAnimationType);
			if (aAnimationType == AnimationType.DIE) {
				enemyDiedSignal.Dispatch (view.gameObject);
			} else if (aAnimationType == AnimationType.ATTACK) {
				
				//TODO, INFLICT DAMAGE LESS, ONLY WHEN ANIMATION 'LOOPS'
				_doInflictDamage();
			}

		}
	}
}

