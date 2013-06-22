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
public class DebuggingDemoComponent : MonoBehaviour 
{
		

	//--------------------------------------
	//  Attributes
	//--------------------------------------
		

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
	/// Initializes a new instance of the <see cref="DebuggingDemoComponent"/> class.
	/// </summary>
	public DebuggingDemoComponent ()
	{
		
		
	}
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start ()
	{
	
		_doCauseExceptionManually();
		_doCauseExceptionByAccident();
		_doDemoDebugLog();
		_doDemoDebugDraw();
			

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update ()
	{
		
	}
	
	
	// PUBLIC STATIC
	
	// PRIVATE
	/// <summary>
	/// _dos the cause exception manually.
	/// </summary>
	private void _doCauseExceptionManually()
	{
		
		try {

            throw new System.DivideByZeroException();   

        }

        catch (System.Exception exception) {

            Debug.Log("Exception caught" + Time.time + " and " + exception);  
		}
		
	}

	
	/// <summary>
	/// _dos the cause exception by accident (almost).
	/// </summary>
	private void _doCauseExceptionByAccident()
	{
		
		try {

            int my_int = 7;
			int my_result = my_int/0;
			my_result++;

        }

        catch (System.Exception exception) {

            Debug.Log("Exception caught" + Time.time + " and " + exception);  
		}
		
	}
	
	/// <summary>
	/// _dos the demo debug class.
	/// </summary>
	private void _doDemoDebugLog ()
	{
		Debug.Log 			("This is a log, where Debug.isDebugBuild: " + Debug.isDebugBuild);
		Debug.LogWarning 	("This is a log warning.");
		Debug.LogError 		("This is a log error.");
		
	}
	
	/// <summary>
	/// _dos the demo debug draw.
	/// </summary>
	public void _doDemoDebugDraw ()
	{
		
		//TODO: I'M NOT SURE WHY BUT THE FOLLOWING LINES SHOULD WORK, BUT
		//		INSTEAD I SEE 'Error CS0117: `Debug' does not contain a definition for `DrawRay' (CS0117) (Assembly-CSharp)'
		//Vector3 forward = transform.forward;
   		//Debug.DrawRay(transform.position, forward);
    	//Debug.DrawLine(transform.position, transform.position + forward * 10000);

	}
	
	// PRIVATE STATIC
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	
	
}
