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
using System.Collections;

//--------------------------------------
//  Class
//--------------------------------------
	
/*
 * NOTES FROM (http://answers.unity3d.com/questions/255647/yield-vs-update.html):
 * 
 * It depends; coroutines generate garbage which has to be collected at some point, but you generally save more time by 
 * not running something every frame than you lose by garbage collection. The less often something runs, the more likely 
 * it is to be more efficient as a coroutine. But the time it takes to write code is also a legitimate measure of 
 * efficiency, and coroutines can be much faster to write and debug than a bunch of spaghetti code in Update.
 * 
 * There's also InvokeRepeating, which should be used if something repeats at regular intervals, since it's the most efficient 
 * method of doing that and doesn't generate any garbage.
 * 
 * You can't use coroutines like that from Update. You can start coroutines in Update, but you can't yield on them (since 
 * using yield can only be done in a coroutine). Update happens once every frame regardless, and will never pause for anything. 
 * When scheduling a sequence of events with coroutines, it's much simpler just to avoid using Update entirely, since it's not 
 * appropriate for that kind of code.
 * 
*/

public class MoveRightComponent : MonoBehaviour 
{

	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	
	// PUBLIC
	
	// PUBLIC STATIC
	
	// PRIVATE
	
	// PRIVATE STATIC
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	// PUBLIC
	/// <summary>
	/// Initializes a new instance of the <see cref="MoveRightComponent"/> class.
	/// </summary>
	public MoveRightComponent ()
	{
		
		
	}
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start ()
	{
		
		//1. REPEAT CODE USING BUILT-IN TIME MANAGER, YOU MAY *NOT* STOP IT AT ANY TIME.
		//(SIMPLY USE UPDATE BELOW, NO SETUP REQUIRED)
		
		//2. REPEAT CODE AT REGULAR (UNCHANGING) INTERVAL, YOU MAY STOP IT AT ANY TIME.
		InvokeRepeating ("_doMoveRightRepeating", 0, 0.5f);
		
		//3. REPEAT CODE AT (MAYBE) CHANGING INTERVAL, YOU MAY STOP IT AT ANY TIME.
		StartCoroutine ("_doMoveUpCoroutine");
		
		
			
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update ()
	{
		//LOG
		//Debug.Log ("Update()");
		
		//MOVE
		transform.Translate ( new Vector3 (0, 0, 0.03f), Space.World ); //CALLED OFTEN, SO USE SMALL AMOUNT OF MOVEMENT
		
		//yield;
	}
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// _dos the move right repeating.
	/// </summary>
	private void _doMoveRightRepeating () 
	{
		//LOG
		//Debug.Log ("_doMoveRightRepeating()");
		
		//MOVE
		transform.Translate ( new Vector3 (0.3f, 0, 0), Space.World );
		
	}
	
	// PRIVATE COROUTINE
	///<summary>
	///	This is a private coroutine.
	///</summary>
	private IEnumerator _doMoveUpCoroutine () 
	{
		while (true) {
			
			//LOG
			//Debug.Log ("_doMoveUpCoroutine()");
			
			//MOVE
			transform.Translate ( new Vector3 (0, 0.3f, 0), Space.World );
			
			//NOTE, YOU CAN DYNAMICALLY CHANGE 'delay' IF DESIRED
			float delay_float = 0.5f;
	     	yield return new WaitForSeconds (delay_float);
		}
	}
	
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}
