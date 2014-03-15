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


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.coins_and_platforms.components
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
	public class DetectHeadBumpFromPlayerComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		///<summary>
		///	This is a sample getter/setter property.
		///</summary>
		private string samplePublic2_str;
		private string samplePublic2 { 
			get 
			{ 
				//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
				return samplePublic2_str; 
			}
			set 
			{ 
				//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
				samplePublic2_str = value; 
			}
		}
		
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		private Animation _animation;

		private float _originalY_float;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public DetectHeadBumpFromPlayerComponent ()
		{

			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~DetectHeadBumpFromPlayerComponent ( )
		{
			
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			//_animation = GetComponent <Animation>();
			//_animation.Play ();
			//Debug.Log ("ok: " + _animation);

			_originalY_float = gameObject.transform.position.y;

			 
			
		}



		void doTweenUpStart()
		{


			Hashtable tweenHash = new Hashtable();
			tweenHash.Add(iT.MoveBy.y, _originalY_float + 0.5);
			tweenHash.Add(iT.MoveBy.delay, 0);
			tweenHash.Add(iT.MoveBy.time, 0.25f);
			//tweenHash.Add(iT.MoveBy.easetype, iTween.EaseType.easeOutSine);
			tweenHash.Add(iT.MoveBy.oncomplete, "onTweenUpComplete");
			iTween.MoveTo(gameObject, tweenHash);
			
			
		}

		void onTweenUpComplete ()
		{
			Hashtable tweenHash = new Hashtable();
			tweenHash.Add(iT.MoveBy.delay, 0);
			Debug.Log ("Move: " + _originalY_float);
			tweenHash.Add(iT.MoveBy.y, _originalY_float);
			tweenHash.Add(iT.MoveBy.time, 0.25f);
			//tweenHash.Add(iT.MoveBy.easetype, iTween.EaseType.easeInExpo);
			iTween.MoveTo(gameObject, tweenHash);

		}
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		void OnTriggerEnter2D(Collider2D collider2D) 
		{
			if (collider2D.gameObject.layer == LayerMask.NameToLayer ("PlayerLayer")) {
				//WORKS!
				Debug.Log ("head hit OOO");
				doTweenUpStart();
			}
			
		}
	}
}
