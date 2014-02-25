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
using System.Collections;
using com.rmc.projects.animation_monitor;



//--------------------------------------
//  Namespace
//--------------------------------------
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
		IDLE,
		JUMP

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


		/// <summary>
		/// HEIGHT OFF GROUND UPON CREATION
		/// </summary>
		public static float DEFAULT_Y_POSITION = 5;



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
		/// The ANIMATION NAMES
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
		/// The _ MOV e_ BAC k_ WHE n_ HI t_ AMOUN.
		/// </summary>
		private const float _MOVE_BACK_WHEN_HIT_AMOUNT = 1;


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
		/// Ises the ready to attack.
		/// </summary>
		/// <returns><c>true</c>, if ready to attack was ised, <c>false</c> otherwise.</returns>
		public bool isReadyToAttack ()
		{

			return (animationType != AnimationType.ATTACK && animationType != AnimationType.DIE);

		}

		/// <summary>
		/// Ises the fit to walk.
		/// </summary>
		/// <returns><c>true</c>, if fit to walk was ised, <c>false</c> otherwise.</returns>
		public bool isFitToWalk (){

			return animationType != AnimationType.TAKE_HIT && animationType != AnimationType.JUMP;
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
		/// <param name="aDelayBeforeAnimation_float">A delay before animation_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public void doPlayAnimation (AnimationType aAnimationType, float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{
			//
			animationType 	= aAnimationType;

			doStopAnimation();

			//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
			StartCoroutine (doPlayAnimationCoroutine(aDelayBeforeAnimation_float, aDelayAfterAnimation_float));

		}

		/// <summary>
		/// Dos the play animation coroutine.
		/// </summary>
		/// <returns>The play animation coroutine.</returns>
		/// <param name="aAnimationType">A animation type.</param>
		public IEnumerator doPlayAnimationCoroutine (float aDelayBeforeAnimation_float, float aDelayAfterAnimation_float) 
		{

			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationType.ToString(), AnimationMonitorEventType.PRE_START));


			//WAIT
			yield return new WaitForSeconds(aDelayBeforeAnimation_float);


			//

			float  animationDuration_float; 
			
			//
			switch (animationType) {
			case AnimationType.JUMP:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (ANIMATION_NAME_JUMP, WrapMode.Default);
				break;
			case AnimationType.WALK:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (ANIMATION_NAME_WALK, WrapMode.Loop);
				break;
			case AnimationType.ATTACK:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (_getRandomStringFrom( new string[] {ANIMATION_NAME_ATTACK_1, ANIMATION_NAME_ATTACK_2}), WrapMode.Default);
				break;
			case AnimationType.TAKE_HIT:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (_getRandomStringFrom(new string[] {ANIMATION_NAME_HIT_1, ANIMATION_NAME_HIT_2}), WrapMode.Default);
				break;
			case AnimationType.DIE:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (_getRandomStringFrom(new string[] {ANIMATION_NAME_DEATH_1, ANIMATION_NAME_DEATH_2}), WrapMode.Default);
				break;
			case AnimationType.IDLE:
				animationDuration_float 	= animationMonitor.setAnimationAndPlay (ANIMATION_NAME_IDLE, WrapMode.Default);
				break;
			default:
				#pragma warning disable 0162
				throw new SwitchStatementException();
				break;
				#pragma warning restore 0162
			}
			

			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationType.ToString(), AnimationMonitorEventType.START));


			//SET TIMER TO KNOW WHEN ANIMATION IS COMPLETE
			StartCoroutine ( onAnimationComplete (animationDuration_float, aDelayAfterAnimation_float));


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

			//MOVE BACKWARDS A LITTLE BIT
			transform.position -= transform.forward * _MOVE_BACK_WHEN_HIT_AMOUNT;

			//PLAY ANIMATION
			if (_healthCurrent_float > 0) {
				doPlayAnimation (AnimationType.TAKE_HIT, 0, 0);
			} else {
				_healthCurrent_float = 0;
				if (animationType != AnimationType.DIE) {
					doPlayAnimation (AnimationType.DIE, 0, 0);
				}
			}
		}

		/// <summary>
		/// Dos the tween to fall from sky.
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

		/// <summary>
		/// Dos the tween to fall from sky.
		/// </summary>
		public void doTweenToSinkIntoGround ()
		{
			//
			Hashtable moveTo_hashtable 					= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.y,			-1);
			moveTo_hashtable.Add(iT.MoveTo.delay,  		0.25);
			moveTo_hashtable.Add(iT.MoveTo.time,  		2);
			moveTo_hashtable.Add(iT.MoveTo.easetype, 	iTween.EaseType.easeOutExpo);
			iTween.MoveTo (gameObject, 					moveTo_hashtable);


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
		/// </summary>
		/// <returns>The animation complete.</returns>
		/// <param name="aAnimationDuration_float">A animation duration_float.</param>
		/// <param name="aDelayAfterAnimation_float">A delay after animation_float.</param>
		public IEnumerator onAnimationComplete (float aAnimationDuration_float, float aDelayAfterAnimation_float)
		{

			//WAIT
			yield return new WaitForSeconds (aAnimationDuration_float);

			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationType.ToString(), AnimationMonitorEventType.COMPLETE));

			//THEN TACK ON SOME EXTRA DELAY FOR COSMETIC TWEAKING
			yield return new WaitForSeconds (aDelayAfterAnimation_float);
			if (animation.wrapMode == WrapMode.Loop) {
				Debug.Log ("onAnimationComplete: " + animation.name + " , " + animation.wrapMode);
//				StartCoroutine ( onAnimationComplete (aAnimationDuration_float, aDelayAfterAnimation_float)); 
			}


			//SEND SIGNAL
			animationMonitor.uiAnimationMonitorSignal.Dispatch (new AnimationMonitorEventVO (animation, animationType.ToString(), AnimationMonitorEventType.POST_COMPLETE));

		}

	}
}

