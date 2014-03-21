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
using System.Collections;
using UnityEngine;

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
	public class RisingPointsPrefabComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		
		// PRIVATE STATIC
		
		/// <summary>
		/// TIMING FOR ANIMATION
		/// </summary>
		private static float _MOVE_DURATION = 0.2f;

		/// <summary>
		/// TIMING FOR ANIMATION
		/// </summary>
		private static float _MOVE_Y_AMOUNT = 7;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public RisingPointsPrefabComponent ()
		{
			
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~RisingPointsPrefabComponent ( )
		{
			
			
		}
		
		
		
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_doMoveUp();
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
		private void _doMoveUp ()
		{

			Vector2 destination_vector2 = gameObject.transform.position + new Vector3 (0, _MOVE_Y_AMOUNT, 0);
			
			//
			//
			Hashtable moveTo_hashtable 						= new Hashtable();
			moveTo_hashtable.Add(iT.MoveTo.x,				destination_vector2.x);
			moveTo_hashtable.Add(iT.MoveTo.y,				destination_vector2.y);
			moveTo_hashtable.Add(iT.ScaleTo.time,  			_MOVE_DURATION);
			moveTo_hashtable.Add(iT.ScaleTo.easetype, 		iTween.EaseType.linear);
			moveTo_hashtable.Add(iT.ScaleTo.oncomplete, 	"_doMoveUpComplete");
			iTween.MoveTo (gameObject, 						moveTo_hashtable);
			
			return;
			
		}
		
		/// <summary>
		/// Does move up complete.
		/// </summary>
		public void _doMoveUpComplete ()
		{
			DestroyImmediate (gameObject);
			
			
		}
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------

		
	}
}