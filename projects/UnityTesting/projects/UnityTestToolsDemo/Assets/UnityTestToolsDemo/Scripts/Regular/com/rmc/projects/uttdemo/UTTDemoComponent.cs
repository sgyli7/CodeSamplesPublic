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
//  Namespace
//--------------------------------------
namespace com.rmc.projects.uttdemo
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
	public class UTTDemoComponent : MonoBehaviour 
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

			//Debug.Log ("UTTDemoComponent.Start()");
			_doRunDemo();

		}
		
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			

		}
		
		// PUBLIC
		/// <summary>
		/// _dos the run demo.
		/// </summary>
		public void _doRunDemo() 
		{

			//HERE IN THE 'REGULAR' TREE OF OUR CODE WE WOULD BE MAKING OUR
			//	GAME AND 'USING' OUR CLASSES LIKE NORMAL, WHATEVER 
			//	TYPE THEY MIGHT BE

			//NOTHING SPECIAL HAPPENING HERE...
			Beer beer = new Beer ("Pilsner", Beer.CONTAINER_TYPE_BOTTLE);
			Debug.Log ("beer: " + beer.calories);

			//NOR HERE...
			Soda soda = new Soda ("GreenLightening");
			Debug.Log ("soda: " + soda.name);



		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
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