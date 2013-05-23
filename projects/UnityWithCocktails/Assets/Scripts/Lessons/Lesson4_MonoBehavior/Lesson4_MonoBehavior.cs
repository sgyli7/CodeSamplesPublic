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
public class Lesson4_MonoBehavior : MonoBehaviour 
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
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		// COROUTINE
		StartCoroutine ("_samplePrivateCoroutine", "Runs Every X Seconds");
		
		// INVOKE
		//Invoke ("_sampleInvokeMethod", 10f);
		InvokeRepeating ("_sampleInvokeMethod", 1, 5f);
		
		//	SEND MESSAGE 
		//		(THIS VERY CLASS LISTENS FAR BELOW, BUT TYPICALLY A CLASS SENDS 
		//			TO *ANOTHER* CLASS OR CLASSES
		SendMessage ("onInitialized", "This message goes to EVERY MonoBehavior in the scene.", SendMessageOptions.RequireReceiver);
		
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
	///<summary>
	///	This is a private coroutine.
	///</summary>
	private IEnumerator _samplePrivateCoroutine (string aMessage_str) 
	{
	    Debug.Log("_samplePrivateCoroutine (): " + aMessage_str);
	    
	     yield return new WaitForSeconds(3);
	
	    Debug.Log("_samplePrivateCoroutine (): " + aMessage_str);
		
		//STOP IT (TODO: Find out why this fails to do anything)
		//StopCoroutine ("_samplePrivateCoroutine");
	}
	
	
	// PRIVATE INVOKE
	///<summary>
	///	This is a private Invoke Method.
	///</summary>
	private void _sampleInvokeMethod () 
	{
	    Debug.Log("_sampleInvokeMethod (). Runs Every Y Seconds");
		
		//STOP IT (TODO: Find out why this fails to do anything)
		//CancelInvoke("_samplePrivateCoroutine");
		
	}
	
	
	//--------------------------------------
	//  Events 
	//		(This is a loose term for -- handling incoming messaging)
	//
	//--------------------------------------
	///<summary>
	///	Handles "onInitialized" 
	///</summary>
	public void onInitialized (string aMessage_str)
	{
		Debug.Log ("onInitialized() : " + aMessage_str);
		
	}
	
}
