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
using com.rmc.projects.coins_and_platforms.components.core;
using UnityEngine;

//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.managers;
using System.Collections;


namespace com.rmc.projects.coins_and_platforms.components.super
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
	[RequireComponent (typeof (BoxCollider2D), typeof (Rigidbody2D))]
	public class CoinComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PRIVATE STATIC
		/// <summary>
		/// The POINT s_ PE r_ COI.
		/// </summary>
		private static uint POINTS_PER_COIN = 100;

		/// <summary>
		/// The _ SCAL e_ U p_ DURATIO.
		/// </summary>
		private static float _SCALE_UP_DURATION = 0.3f;

		/// <summary>
		/// The _ SCAL e_ U p_ DURATIO.
		/// </summary>
		private static float _SCALE_DOWN_DURATION = 0.3f;


		/// <summary>
		/// The _was collected_boolean.
		/// </summary>
		private bool _wasCollected_boolean = false;


		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public CoinComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~CoinComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
		}
		
		
		
		/// <summary>
		/// Called once per frame
		/// </summary>
		void Update()
		{
			
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// _dos the fade out.
		/// </summary>
		private void _doScaleUp ()
		{
			//
			//
			Hashtable scaleUp_hashtable 				= new Hashtable();
			scaleUp_hashtable.Add(iT.ScaleTo.x,			1.8);
			scaleUp_hashtable.Add(iT.ScaleTo.y,			1.8);
			scaleUp_hashtable.Add(iT.ScaleTo.time,  	_SCALE_UP_DURATION);
			scaleUp_hashtable.Add(iT.ScaleTo.easetype, 	iTween.EaseType.easeInExpo);
			scaleUp_hashtable.Add(iT.ScaleTo.oncompletetarget, 	gameObject);
			scaleUp_hashtable.Add(iT.ScaleTo.oncomplete, 		"_doScaleDown");
			iTween.ScaleTo (gameObject, 				scaleUp_hashtable);


		}

		/// <summary>
		/// _dos the fade out.
		/// </summary>
		public void _doScaleDown ()
		{

			SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.COIN_COLLECTED);


			//
			//
			Hashtable scaleDown_hashtable 					= new Hashtable();
			scaleDown_hashtable.Add(iT.ScaleTo.x,			0);
			scaleDown_hashtable.Add(iT.ScaleTo.y,			0);
			scaleDown_hashtable.Add(iT.ScaleTo.time,  		_SCALE_DOWN_DURATION);
			scaleDown_hashtable.Add(iT.ScaleTo.easetype, 	iTween.EaseType.easeInExpo);
			scaleDown_hashtable.Add(iT.ScaleTo.oncomplete, 	"_doRewardPoints");
			iTween.ScaleTo (gameObject, 					scaleDown_hashtable);
			
			
		}

		/// <summary>
		/// _dos the reward points.
		/// </summary>
		public void _doRewardPoints ()
		{
			SimpleGameManager.Instance.gameManager.score += POINTS_PER_COIN;
			DestroyImmediate (gameObject);


		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the trigger enter2 d event.
		/// </summary>
		/// <param name="collider2D">Collider2 d.</param>
		public void OnTriggerEnter2D (Collider2D collider2D)
		{
			//
			if (collider2D.gameObject.tag == MainConstants.PLAYER_TAG) {

				if (!_wasCollected_boolean) {
					_wasCollected_boolean = true;
					_doScaleUp();
				}
			}
			
		}
		
	}
}