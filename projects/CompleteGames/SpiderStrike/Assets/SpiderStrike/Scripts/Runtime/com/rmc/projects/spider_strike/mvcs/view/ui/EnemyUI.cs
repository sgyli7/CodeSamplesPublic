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
using com.rmc.exceptions;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.utilities;


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
		//public UIAnimationCompleteSignal uiAnimationCompleteSignal {set; get;}




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
		/// The _particle system.
		/// </summary>
		private ParticleSystem _particleSystem;

		/// <summary>
		/// The _health current_float.
		/// </summary>
		private float _healthCurrent_float;
		
		/// <summary>
		/// The _target turret U.
		/// </summary>
		private TurretUI _targetTurretUI;
		public TurretUI targetTurretUI
		{ 
			get{
				return _targetTurretUI;
			}
			set
			{
				_targetTurretUI = value;
			}
		}


		/// <summary>
		/// Gets a value indicating whether this <see cref="com.rmc.projects.spider_strike.mvcs.view.ui.EnemyUI"/> is alive.
		/// </summary>
		/// <value><c>true</c> if is alive; otherwise, <c>false</c>.</value>
		public bool isAlive {
			get {
				return animationType != AnimationType.DIE;

			}

		}

		/// <summary>
		/// The _animation binder.
		/// 
		/// NOTE: Notifies when an animation is complete
		/// 
		/// </summary>
		public AnimationMonitor animationMonitor;

		
		/// <summary>
		/// The attack radius.
		/// NOTE: SET FROM OUTSIDE
		/// </summary>
		private float _attackRadius;

		/// <summary>
		/// The _move speed_float.
		/// </summary>
		private float _moveSpeed_float;




		// PRIVATE STATIC
		/// <summary>
		/// The _ ROTATIO n_ SPEE.
		/// </summary>
		private const float _ROTATION_SPEED = 1.0f;

		/// <summary>
		/// The ANIMATIO NAMES
		/// </summary>
		private const string ANIMATION_NAME_IDLE 		= "idle";	
		private const string ANIMATION_NAME_WALK 		= "walk";	
		private const string ANIMATION_NAME_ATTACK_1 	= "attack1";
		private const string ANIMATION_NAME_ATTACK_2	= "attack2";
		private const string ANIMATION_NAME_HIT_1 		= "hit1";
		private const string ANIMATION_NAME_HIT_2 		= "hit2";
		private const string ANIMATION_NAME_DEATH_1 	= "death1";
		private const string ANIMATION_NAME_DEATH_2 	= "death2";

		//--------------------------------------
		//  Methods
		//--------------------------------------	

		/// <summary>
		/// Init this instance.
		/// </summary>
		public void init ()
		{
			animationMonitor = new AnimationMonitor (gameObject);


		}

		/// <summary>
		/// Sets the parameters.
		/// </summary>
		/// <param name="aTargetGameObject">A target game object.</param>
		/// <param name="aAttackRadius_float">A attack radius_float.</param>
		/// <param name="aHealth_float">A health_float.</param>
		public void setParameters (TurretUI aTargetGameObject, float aAttackRadius_float, float aHealth_float, float aMoveSpeed_float)
		{
			_targetTurretUI 		= aTargetGameObject;
			_attackRadius			= aAttackRadius_float;
			_healthCurrent_float	= aHealth_float;
			_moveSpeed_float		= aMoveSpeed_float;


		}

		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();
			animation 		= GetComponentInChildren<Animation>();
			_particleSystem = GetComponentInChildren<ParticleSystem>();
			
			
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
			Debug.Log ("3. EnemyUI.OnDestroy()");
			
		}
		
		// PUBLIC

		/// <summary>
		/// _ises at attacking distance.
		/// </summary>
		/// <returns><c>true</c>, if at attacking distance was _ised, <c>false</c> otherwise.</returns>
		public bool isAtAttackingDistance ()
		{
			return Vector3.Distance (transform.position, _targetTurretUI.transform.position) < _attackRadius;
		}
		
		/// <summary>
		/// _dos the face target.
		/// </summary>
		public void doFaceTarget ()
		{
			transform.rotation = Quaternion.Slerp
				(
					transform.rotation,
					Quaternion.LookRotation(_targetTurretUI.transform.position - transform.position),
					_ROTATION_SPEED
				);
		}
		
		/// <summary>
		/// _dos the move to target.
		/// </summary>
		public void doMoveToTarget ()
		{
			transform.position += transform.forward * _moveSpeed_float * Time.deltaTime;
			
		}

		/// <summary>
		/// Dos the play animation.
		/// </summary>
		/// <param name="aAnimationType">A animation type.</param>
		public void doPlayAnimation (AnimationType aAnimationType) 
		{
			//
			animationType 	= aAnimationType;
			float  animationDuration_float; 

			//
			switch (animationType) {
			case AnimationType.WALK:
				animationDuration_float 	= animationMonitor.setAnimationIfNotYetSetTo (ANIMATION_NAME_WALK, WrapMode.Loop);
				break;
			case AnimationType.ATTACK:
				animationDuration_float 	= animationMonitor.setAnimationIfNotYetSetTo (_getRandomStringFrom( new string[] {ANIMATION_NAME_ATTACK_1, ANIMATION_NAME_ATTACK_2}), WrapMode.Loop);
				break;
			case AnimationType.TAKE_HIT:
				animationDuration_float 	= animationMonitor.setAnimationIfNotYetSetTo (_getRandomStringFrom(new string[] {ANIMATION_NAME_HIT_1, ANIMATION_NAME_HIT_2}), WrapMode.Default);
				break;
			case AnimationType.DIE:
				animationDuration_float 	= animationMonitor.setAnimationIfNotYetSetTo (_getRandomStringFrom(new string[] {ANIMATION_NAME_DEATH_1, ANIMATION_NAME_DEATH_2}), WrapMode.Default);
				break;
			case AnimationType.IDLE:
				animationDuration_float 	= animationMonitor.setAnimationIfNotYetSetTo (ANIMATION_NAME_IDLE, WrapMode.Default);
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}


			//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
			CancelInvoke("onAnimationComplete");
			InvokeRepeating ("onAnimationComplete", animationDuration_float, animationDuration_float);


		}


		/// <summary>
		/// Dos the stop animation.
		/// </summary>
		public void doStopAnimation()
		{
			animation.Stop();


		}

		/// <summary>
		/// Dos the take damage.
		/// </summary>
		/// <param name="aDamageAmount_float">A damage amount_float.</param>
		public void doTakeDamage (float aDamageAmount_float)
		{
			//DECREMENT
			_healthCurrent_float -= aDamageAmount_float;

			//SMOKE
			_particleSystem.Emit (1);

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
		/// _gets the random string from.
		/// </summary>
		/// <returns>The random string from.</returns>
		/// <param name="aString_array">A string_array.</param>
		private string _getRandomStringFrom (string[] aString_array)
		{
			return aString_array[Random.Range (0, aString_array.Length)];
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
		/// 
		/// 
		/// NOTE: Method must be ***public*** due to InvokeRepeating
		/// TODO: PACK THIS 'ON COMPLETE' FUNCTIONALITY INTO THE EXTENSION METHODS FOR 'Animation'
		/// 
		/// 
		/// </summary>
		public void onAnimationComplete ()
		{
			if (animation.wrapMode != WrapMode.Loop) {
				CancelInvoke("onAnimationComplete");
			}
			//Debug.Log ("onAnimationComplete: " + animationType.ToString());
			animationMonitor.uiAnimationCompleteSignal.Dispatch (animationType.ToString());
		}

	}
}

