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
namespace Lesson8NamingConventions
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
	public class ClassWithCSharpConventions 
	{
		

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		///<summary>
		///	This is a sample getter/setter property.
		///</summary>
		private string _samplePublicVariable;
		public string SamplePublicVariable { 
			get 
			{ 
				//OPTIONAL: CONTROL ACCESS TO PRIVATE VALUE
				return _samplePublicVariable; 
			}
			set 
			{ 
				//OPTIONAL: CONTROL ACCESS TO PRIVATE VALUE
				_samplePublicVariable = value; 
			}
		}
			
		
		// PUBLIC
		
		
		// PUBLIC STATIC
		/// <summary>
		/// Constant sample public static constant.
		/// </summary>
		public const string SamplePublicStaticConstant = "SamplePublicStaticConstant";
		
		// PRIVATE
		/// <summary>
		/// The _ sample private.
		/// </summary>
		private string _SamplePrivate;
		
		// PRIVATE STATIC
		/// <summary>
		/// The _ sample private static.
		/// </summary>
		private static string _SamplePrivateStatic;
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Lesson8NamingConventions.ClassWithCSharpConventions"/> class.
		/// </summary>
		public ClassWithCSharpConventions ()
		{
			//
			//Debug.Log ("ClassWithCSharpConventions.constructor()");
			
		}
		
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="Lesson8NamingConventions.ClassWithCSharpConventions"/> is reclaimed by garbage collection.
		/// </summary>
		~ClassWithCSharpConventions ( )
		{
			//Debug.Log ("ClassWithCSharpConventions.deconstructor()");
			
		}
		
		
		// PUBLIC
	
		/// <summary>
		/// Samples the public method.
		/// </summary>
		/// <returns>
		/// The public method.
		/// </returns>
		/// <param name='message'>
		/// Message.
		/// </param>
		public string SamplePublicMethod (string message) 
		{
			string sampleLocalVariable = " sample";
			return message + sampleLocalVariable;
			
		}
		
		// PUBLIC STATIC
		
		/// <summary>
		/// Samples the public static method.
		/// </summary>
		/// <returns>
		/// The public static method.
		/// </returns>
		/// <param name='message'>
		/// Message.
		/// </param>
		public static string SamplePublicStaticMethod (string message) 
		{
			return message;
			
		}
		
		// PRIVATE
		
		/// <summary>
		/// _s the sample private method.
		/// </summary>
		/// <returns>
		/// The sample private method.
		/// </returns>
		/// <param name='message'>
		/// Message.
		/// </param>
		private string _SamplePrivateMethod (string message) 
		{
			return message;
			
		}
		
		// PRIVATE STATIC
		
		/// <summary>
		/// _s the sample private static method.
		/// </summary>
		/// <returns>
		/// The sample private static method.
		/// </returns>
		/// <param name='message'>
		/// Message.
		/// </param>
		private static string _SamplePrivateStaticMethod (string message) 
		{
			return message;
			
		}
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Raises the sample event event.
		/// </summary>
		/// <param name='message'>
		/// Message.
		/// </param>
		public void OnSampleEvent (string message) 
		{
			Debug.Log ("OnSampleEvent(): " + message);
			
		}
	}
}
