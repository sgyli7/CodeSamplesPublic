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
using com.rmc.projects.coins_and_platforms.constants;
using com.rmc.projects.coins_and_platforms.managers;
using System.Collections;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components.coins
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
	public class CoinComponent : SuperTriggerComponent 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PRIVATE STATIC
		/// <summary>
		/// POINTS
		/// </summary>
		private static uint POINTS_PER_COIN = 100;

		/// <summary>
		/// ANIMATION TIMING
		/// </summary>
		private static float _SCALE_UP_DURATION = 0.1f;


		/// <summary>
		/// ANIMATION TIMING
		/// </summary>
		private static float _MOVE_DURATION = 0.4f;

		/// <summary>
		/// OFFSET FOR POINTS '100 PTS' MESSAGE
		/// </summary>
		private static float _POINTS_PREFAB_STARTING_Y_DELTA = 7;


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
		/// Does fade out.
		/// </summary>
		private void _doScaleUp ()
		{
			//
			//
			Hashtable scaleUp_hashtable 						= new Hashtable();
			scaleUp_hashtable.Add(iT.ScaleTo.x,					.8);
			scaleUp_hashtable.Add(iT.ScaleTo.y,					.8);
			scaleUp_hashtable.Add(iT.ScaleTo.time,  			_SCALE_UP_DURATION);
			scaleUp_hashtable.Add(iT.ScaleTo.easetype, 			iTween.EaseType.easeInExpo);
			scaleUp_hashtable.Add(iT.ScaleTo.oncompletetarget, 	gameObject);
			scaleUp_hashtable.Add(iT.ScaleTo.oncomplete, 		"_doScaleDown");
			iTween.ScaleTo (gameObject, 						scaleUp_hashtable);


		}

		/// <summary>
		/// Does fade out.
		/// </summary>
		public void _doScaleDown ()
		{

			SimpleGameManager.Instance.audioManager.doPlaySound (AudioClipType.COIN_COLLECTED);



			Vector2 coinDestination_vector2 = SimpleGameManager.Instance.gameManager.getCollectedCoinDestination(gameObject.transform);

			//
			//
			Hashtable moveTo_hashtable 						= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.x,				coinDestination_vector2.x);
			moveTo_hashtable.Add(iT.MoveTo.y,				coinDestination_vector2.y);
			moveTo_hashtable.Add(iT.ScaleTo.time,  			_MOVE_DURATION);
			moveTo_hashtable.Add(iT.ScaleTo.easetype, 		iTween.EaseType.linear);
			moveTo_hashtable.Add(iT.ScaleTo.oncomplete, 	"_doRewardPoints");
			iTween.MoveTo (gameObject, 						moveTo_hashtable);

			return;

		}

		/// <summary>
		/// Does reward points.
		/// </summary>
		public void _doRewardPoints ()
		{
			//center the rising points with the coin, and put it higher onscreen than the coin
			Vector3 risingPointsPrefabPosition_vector3 = gameObject.transform.position + new Vector3 ( - gameObject.transform.localScale.x*2, _POINTS_PREFAB_STARTING_Y_DELTA, 0);
			SimpleGameManager.Instance.gameManager.doRewardScore (POINTS_PER_COIN, risingPointsPrefabPosition_vector3);
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

				if (!_wasTriggered) {
					_wasTriggered = true;
					_doScaleUp();
				}
			}
			
		}
		
	}
}