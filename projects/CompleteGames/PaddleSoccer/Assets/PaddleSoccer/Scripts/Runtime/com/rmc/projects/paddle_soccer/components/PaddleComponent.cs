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
using System.Collections;
using com.rmc.utilities;
using com.rmc.projects.paddle_soccer.mvcs;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.paddle_soccer.components
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
	public class PaddleComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		
		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="com.rmc.projects.paddle_soccer.components.PaddleComponent"/> is spinning.
		/// </summary>
		/// <value><c>true</c> if is spinning; otherwise, <c>false</c>.</value>
		public bool isSpinning
		{ 
			get{
				return _animator.GetBool ("isSpinning_boolean");
			}
			set
			{
				_animator.SetBool ("isSpinning_boolean", value);
			}
		}



		/// <summary>
		/// The _target y_float.
		/// </summary>
		public float targetY
		{ 
			get{
				return _yPosition_lerptarget.targetValue;
			}
			set
			{
				_yPosition_lerptarget.targetValue = value;
				
			}
		}


		
		// PUBLIC
		
		/// <summary>
		/// The velocity.
		/// </summary>
		public Vector2 velocity;

		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _y position_lerptarget.
		/// </summary>
		private LerpTarget _yPosition_lerptarget;

		
		/// <summary>
		/// When the ANIMATION NAMES
		/// </summary>
		public const string ANIMATION_NAME_PADDLE_RED_ANIMATION 		= "PaddleRedAnimation";	
		public const string ANIMATION_NAME_PADDLE_BLUE_ANIMATION 		= "PaddleBlueAnimation";	
		
		/// <summary>
		/// Gets or sets the acceleration y.
		/// </summary>
		/// <value>The acceleration y.</value>
		public float accelerationY
		{ 
			get{
				return _yPosition_lerptarget.acceleration;
			}
			set
			{
				_yPosition_lerptarget.acceleration = value;
				
			}
		}





		/// <summary>
		/// The _last position_vector3.
		/// </summary>
		private Vector3 _lastPosition_vector3;

		/// <summary>
		/// The _position at start_vector3.
		/// </summary>
		private Vector3 _positionAtStart_vector3;

		/// <summary>
		/// The _animator.
		/// </summary>
		private Animator _animator;
		
		
		/// <summary>
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		
		///<summary>
		///	Use this for initialization
		///</summary>
		public void Start () 
		{
			
			_yPosition_lerptarget 			= new LerpTarget (0, 0, Constants.PADDLE_Y_LERP_MINIMUM, Constants.PADDLE_Y_LERP_MAXIMUM, Constants.PADDLE_Y_LERP_ACCELERATION_DEFAULT);
			_animator = GetComponent <Animator>();
			_positionAtStart_vector3 = gameObject.transform.position;

			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		public void OnDestroy ()
		{


		}


		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

			//ROTATE THE BARREL IF FIRING
			_yPosition_lerptarget.lerpCurrentToTarget (Time.deltaTime);
			_doMoveToTarget();



		}
		

		
		// PUBLIC

		/// <summary>
		/// Do the reset Y position.
		/// </summary>
		public void doResetYPosition ()
		{
			targetY =  _positionAtStart_vector3.y;
		}

		
		/// <summary>
		/// Do the tween to starting position.
		/// </summary>
		public void doTweenToStartingPosition ()
		{
			//
			Hashtable moveTo_hashtable 					= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.x,			_positionAtStart_vector3.x);
			moveTo_hashtable.Add(iT.MoveTo.delay,  		0);
			moveTo_hashtable.Add(iT.MoveTo.time,  		0.25f);
			moveTo_hashtable.Add(iT.MoveTo.easetype, 	iTween.EaseType.linear);
			iTween.MoveTo (gameObject, 					moveTo_hashtable);
		}

		/// <summary>
		/// Do the tween to starting position.
		/// </summary>
		/// <param name="aOffsetX_float">A offset x_float.</param>
		public void doTweenToOffscreenPosition (float aOffsetX_float)
		{

			//
			gameObject.transform.position 				= new Vector3 (_positionAtStart_vector3.x, gameObject.transform.position.y, gameObject.transform.position.z);
			Hashtable moveTo_hashtable 					= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.x,			_positionAtStart_vector3.x + aOffsetX_float);
			moveTo_hashtable.Add(iT.MoveTo.delay,  		0);
			moveTo_hashtable.Add(iT.MoveTo.time,  		0.25f);
			moveTo_hashtable.Add(iT.MoveTo.easetype, 	iTween.EaseType.linear);
			iTween.MoveTo (gameObject, 					moveTo_hashtable);
		}

		/// <summary>
		/// Do the spin once.
		/// </summary>
		public void doSpinOnce () 
		{
			
			StartCoroutine (doSpinOnce_Coroutine());
			
		}


		/// <summary>
		/// Do the spin once.
		/// 
		/// NOTE:  Animator hinges on the parameter isSpinning_boolean
		/// 		So we toggle that true, then upon animation completion, false
		/// 
		/// </summary>
		/// <returns>The spin once.</returns>
		private IEnumerator doSpinOnce_Coroutine () 
		{
			
			isSpinning = true;
			
			yield return new WaitForSeconds (_animator.GetCurrentAnimatorStateInfo(0).length);
			
			isSpinning = false;
			
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// Do move to target.
		/// </summary>
		private void _doMoveToTarget ()
		{
			//
			transform.position = new Vector3 (
				transform.position.x, 
				_getNewYPositionOnscreen(), 
				transform.position.z);

			//STORE FOR VELOCITY CHECK
			velocity = transform.position - _lastPosition_vector3;
			_lastPosition_vector3 = transform.position;
		}


		/// <summary>
		/// _gets the new Y position onscreen.
		/// 
		/// NOTE: We also 'reset' the lerp target 
		/// 
		/// </summary>
		private float _getNewYPositionOnscreen ()
		{
			//GET & CORRECT CURRENT
			float newYPosition_float = _yPosition_lerptarget.current;
			if (newYPosition_float < Constants.PADDLE_Y_TARGET_MINIMUM) {
				newYPosition_float = Constants.PADDLE_Y_TARGET_MINIMUM;
			} else if (newYPosition_float > Constants.PADDLE_Y_TARGET_MAXIMUM) {
				newYPosition_float = Constants.PADDLE_Y_TARGET_MAXIMUM;
			}

			//RETURN CURRENT
			return newYPosition_float;
		}
		
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

