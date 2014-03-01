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
using com.rmc.exceptions;
using System.Collections;
using com.rmc.projects.animation_monitor;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.components
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	public enum AnimationType
	{
		WALK,
		ATTACK,
		TAKE_HIT,
		DIE,
		IDLE,
		JUMP
		
	}
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class PaddleComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		
		/// <summary>
		/// When the type of the _animation.
		/// </summary>
		public AnimationType animationType; 
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		
		/// <summary>
		/// When the animation.
		/// </summary>
		new private Animation animation;
		
		/// <summary>
		/// When the _animation binder.
		/// 
		/// NOTE: Notifies when an animation is complete
		/// 
		/// </summary>
		public AnimationMonitor animationMonitor;
		
		/// <summary>
		/// When the ANIMATION NAMES
		/// </summary>
		public const string ANIMATION_NAME_IDLE 		= "idle";	
		public const string ANIMATION_NAME_JUMP 		= "jump";
		public const string ANIMATION_NAME_WALK 		= "walk";	
		public const string ANIMATION_NAME_ATTACK_1 	= "attack1";
		public const string ANIMATION_NAME_ATTACK_2		= "attack2";
		public const string ANIMATION_NAME_HIT_1 		= "hit1";
		public const string ANIMATION_NAME_HIT_2 		= "hit2";
		public const string ANIMATION_NAME_DEATH_1 		= "death1";
		public const string ANIMATION_NAME_DEATH_2 		= "death2";
		
		
		/// <summary>
		/// When the _move speed_float.
		/// </summary>
		private float _moveSpeed_float;
		
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		public void Start () 
		{
			
			animation 			= GetComponentInChildren<Animation>();
			animationMonitor 	= GetComponentInChildren<AnimationMonitor>();
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		

		
		// PUBLIC

		/// <summary>
		/// Do move to target.
		/// </summary>
		public void doMoveToTarget (Transform aTarget_transform)
		{
			transform.position = new Vector3 (transform.position.x, aTarget_transform.position.y, transform.position.z);
			
		}
		
		/// <summary>
		/// Do play animation.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public void doPlayAnimation (AnimationType aAnimationType, float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{
			//
			animationType 	= aAnimationType;
			
			doStopAnimation();
			
			//
			switch (animationType) {
			case AnimationType.JUMP:
				animationMonitor.playRequest ( new AnimationMonitorRequestVO (ANIMATION_NAME_JUMP, WrapMode.Default));
				break;
			case AnimationType.WALK:
				animationMonitor.playRequest ( new AnimationMonitorRequestVO (ANIMATION_NAME_WALK, WrapMode.Loop));
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
			
			
		}
		
		
		
		/// <summary>
		/// Do stop animation.
		/// </summary>
		public void doStopAnimation()
		{
			animation.Stop();
			
			
		}

		
		/// <summary>
		/// Do tween to fall from sky.
		/// </summary>
		public void doTweenToFallFromSky ()
		{
			//
			//
			Hashtable moveTo_hashtable 					= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.y,			0);
			moveTo_hashtable.Add(iT.MoveTo.delay,  		0);
			moveTo_hashtable.Add(iT.MoveTo.time,  		1);
			moveTo_hashtable.Add(iT.MoveTo.easetype, 	iTween.EaseType.linear);
			iTween.MoveTo (gameObject, 					moveTo_hashtable);
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

