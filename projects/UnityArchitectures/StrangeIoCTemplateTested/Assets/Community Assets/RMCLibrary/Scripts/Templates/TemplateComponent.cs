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
public class TemplateComponent : MonoBehaviour 
{
	
	//--------------------------------------
	//  Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Properties
	//--------------------------------------
	
	// GETTER / SETTER
	///<summary>
	///	This is a sample getter/setter property.
	///</summary>
	private string samplePublic2_str;
	public string samplePublic2 { 
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
	///<summary>
	///	This is a sample public property.
	///</summary>
	public string samplePublic_str;
	
	// PUBLIC STATIC
	///<summary>
	///	This is a sample public static property.
	///</summary>
	public static string SamplePublicStatic_str;
	
	// PRIVATE
	///<summary>
	///	This is a sample private property.
	///</summary>
	private string _samplePrivate_str;
	
	// PRIVATE STATIC
	///<summary>
	///	This is a sample private static property.
	///</summary>
	private static string SamplePrivateStatic_str;
	
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	///<summary>
	///	Use this for initialization
	///</summary>
	void Start () 
	{
		
		// TEST PRIVATE
		samplePrivateMethod ("test6");
		
		// TEST PRIVATE STATIC
		TemplateComponent.SamplePrivateStaticMethod ("test7");
		
		// TEST EVENT HANDLER (SEND MESSAGE TO ITSELF AS A SILLY TEST)
		gameObject.SendMessage ("onSampleEvent", "test8", SendMessageOptions.RequireReceiver);
		
		// COROUTINE
		StartCoroutine ("_samplePrivateCoroutine", "test9");
		
		// INVOKE
		//Invoke ("_sampleInvokeMethod", 10f);
		InvokeRepeating ("_sampleInvokeMethod", 1, 10);
		
	}
	
	
	///<summary>
	///	Called once per frame
	///</summary>
	void Update () 
	{
		
		//Debug.Log("Update ()");
		
	}
	
	// PUBLIC
	
	///<summary>
	///	This is a public method.
	///</summary>
	public string samplePublicMethod (string aMessage_str) 
	{
		return aMessage_str;
		
	}
	
	// PUBLIC STATIC
	
	///<summary>
	///	This is a public static method.
	///</summary>
	public static string SamplePublicStaticMethod (string aMessage_str) 
	{
		return aMessage_str;
		
	}
	
	// PRIVATE
	
	///<summary>
	///	This is a private method.
	///</summary>
	private string samplePrivateMethod (string aMessage_str) 
	{
		return aMessage_str;
		
	}
	
	// PRIVATE STATIC
	
	///<summary>
	///	This is a private static method.
	///</summary>
	static string SamplePrivateStaticMethod (string aMessage_str) 
	{
		return aMessage_str;
		
	}
	
	
	// PRIVATE COROUTINE
	///<summary>
	///	This is a private coroutine.
	///</summary>
	private IEnumerator _samplePrivateCoroutine (string aMessage_str) 
	{
	    Debug.Log("_samplePrivateCoroutine (): " + aMessage_str);
	    
	     yield return new WaitForSeconds(3);
	
	    Debug.Log("_samplePrivateCoroutine (): " + aMessage_str);
	}
	
	
	// PRIVATE INVOKE
	///<summary>
	///	This is a private Invoke Method.
	///</summary>
	private void _sampleInvokeMethod () 
	{
	    Debug.Log("_sampleInvokeMethod ()");
	}
	
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	///<summary>
	///	This is a public method.
	///</summary>
	public void onSampleEvent (string aMessage_str) 
	{
		Debug.Log ("onSampleEvent(): " + aMessage_str);
		
	}
}
