/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.exceptions;
using com.rmc.projects.spider_strike.mvcs.controller.signals;
using strange.extensions.signal.impl;
using com.rmc.projects.spider_strike.mvcs.view.signals;


namespace com.rmc.projects.spider_strike.mvcs.view.ui
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
		IDLE

	}
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class EnemyUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC

		/// <summary>
		/// Gets or sets the user interface animation complete.
		/// </summary>
		/// <value>The user interface animation complete.</value>
		public UIAnimationCompleteSignal uiAnimationCompleteSignal {set; get;}


		/// <summary>
		/// The target_game object.
		/// </summary>
		public GameObject target_gameObject;


		/// <summary>
		/// The attack radius.
		/// </summary>
		public float attackRadius = 3;


		/// <summary>
		/// The type of the _animation.
		/// </summary>
		public AnimationType animationType; 


		// PUBLIC STATIC
		/// <summary>
		/// The LAYE r_ NAM.
		/// </summary>
		public static string LAYER_NAME = "EnemyLayer";
		
		// PRIVATE
		/// <summary>
		/// The animation.
		/// </summary>
		new private Animation animation;

		/// <summary>
		/// The _health current_float.
		/// </summary>
		private float _healthCurrent_float = 11;


		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			uiAnimationCompleteSignal = new UIAnimationCompleteSignal();
		}


		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			animation = GetComponentInChildren<Animation>();
			
			//NO ANIMATION -- WAIT FOR MEDIATOR TO PLAY THINGS
			doPlayAnimation (AnimationType.IDLE);
			
			
			//SHOW ALL ANIMATIONS AVAILABLE
			//Debug.Log ("-----");
			foreach (AnimationState clip in animation) {
				// do initialisation or something on clip
				//Debug.Log ("clip: " + clip.clip.name);
			}

			
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
		/// _ises at attacking distance.
		/// </summary>
		/// <returns><c>true</c>, if at attacking distance was _ised, <c>false</c> otherwise.</returns>
		public bool isAtAttackingDistance ()
		{
			return Vector3.Distance (transform.position, target_gameObject.transform.position) < attackRadius;
		}
		
		/// <summary>
		/// _dos the face target.
		/// </summary>
		public void doFaceTarget ()
		{
			float rotationSpeed = 1.0f;
			
			transform.rotation = Quaternion.Slerp
				(
					transform.rotation,
					Quaternion.LookRotation(target_gameObject.transform.position - transform.position),
					rotationSpeed
				);
		}
		
		/// <summary>
		/// _dos the move to target.
		/// </summary>
		public void doMoveToTarget ()
		{
			float moveSpeed = 1.0f;
			
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			
		}

		/// <summary>
		/// Dos the play animation.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		public void doPlayAnimation (AnimationType aAnimationType) 
		{
			//
			animationType = aAnimationType;

			//
			switch (animationType) {
				case AnimationType.WALK:
					//_setAnimationIfNotYetSetTo ("walk", WrapMode.ClampForever);
					break;
				case AnimationType.ATTACK:
					_setAnimationIfNotYetSetTo (_getRandomStringFrom( new string[] {"attack1","attack2"}), WrapMode.Default);
					break;
				case AnimationType.TAKE_HIT:
					_setAnimationIfNotYetSetTo (_getRandomStringFrom(new string[] {"hit1","hit2"}), WrapMode.Default);
					break;
				case AnimationType.DIE:
					_setAnimationIfNotYetSetTo (_getRandomStringFrom(new string[] {"death1","death2"}), WrapMode.ClampForever);
					break;
				case AnimationType.IDLE:
					_setAnimationIfNotYetSetTo ("idle", WrapMode.Loop);
					break;
				default:
					#pragma warning disable 0162
					throw new SwitchStatementException();
					break;
					#pragma warning restore 0162
			}

		}

		/// <summary>
		/// Dos the take damage.
		/// </summary>
		/// <param name="aDamageAmount_float">A damage amount_float.</param>
		public void doTakeDamage (float aDamageAmount_float)
		{
			//DECREMENT
			_healthCurrent_float -= aDamageAmount_float;

			//PLAY ANIMATION
			if (_healthCurrent_float > 0) {
				doPlayAnimation (AnimationType.TAKE_HIT);
			} else {
				_healthCurrent_float = 0;
				if (animationType != AnimationType.DIE) {
					doPlayAnimation (AnimationType.DIE);
				}
			}
		}

		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _sets the animation if not yet set to.
		/// </summary>
		/// <param name="aAnimationName_string">A animation name_string.</param>
		private void _setAnimationIfNotYetSetTo (string aAnimationName_string, WrapMode aWrapMode)
		{

			if (animation.clip.name != aAnimationName_string) {
				animation.clip.name = aAnimationName_string;

				//NOT SURE WHICH TO SET HERE
				animation.clip.wrapMode = aWrapMode;

				//
				//animation.PlayQueued (animation.clip.name);
				animation.Play(animation.clip.name);

				//
				Debug.Log ("AnimStart: " + animationType +  " dur: " + animation.clip.length);

				//TRIGGER WHEN ANIMATION IS COMPLETE (NOTE: ONE ANIMATION AT A TIME MAXIMUM)
				//NOTE: THERE IS NO 'AUTOMATIC' WAY TO LISTEN FOR ANIMATION COMPLETION
				CancelInvoke("onAnimationComplete");
				InvokeRepeating ("onAnimationComplete", animation.clip.length, animation.clip.length);
			}
		}


		/// <summary>
		/// _gets the random string from.
		/// </summary>
		/// <returns>The random string from.</returns>
		/// <param name="aString_array">A string_array.</param>
		private string _getRandomStringFrom (string[] aString_array)
		{
			return aString_array[Random.Range (0, aString_array.Length-1)];
		}


		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------
		/// <summary>
		/// Ons the animation complete.
		/// NOTE: Method be public for InvokeRepeating
		/// </summary>
		public void onAnimationComplete ()
		{
			if (animation.clip.wrapMode != WrapMode.Loop) {
				CancelInvoke("onAnimationComplete");
			}
			uiAnimationCompleteSignal.Dispatch (animationType);
		}

	}
}

