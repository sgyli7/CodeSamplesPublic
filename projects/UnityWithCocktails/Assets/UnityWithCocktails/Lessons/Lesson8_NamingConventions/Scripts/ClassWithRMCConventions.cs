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
namespace lesson_8_naming_conventions
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
	public class ClassWithRMCConventions 
	{
		

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		///<summary>
		///	This is a sample getter/setter property.
		///</summary>
		private string _samplePublicVariable_string;
		public string samplePublicVariable { 
			get 
			{ 
				//OPTIONAL: CONTROL ACCESS TO PRIVATE VALUE
				return _samplePublicVariable_string; 
			}
			set 
			{ 
				//OPTIONAL: CONTROL ACCESS TO PRIVATE VALUE
				_samplePublicVariable_string = value; 
			}
		}
			
		
		// PUBLIC
		
		
		// PUBLIC STATIC
		///<summary>
		///	This is a sample public static const.
		///</summary>
		public const string SAMPLE_PUBLIC_STATIC_CONSTANT = "SAMPLE_PUBLIC_STATIC_CONSTANT";
		
		// PRIVATE
		/// <summary>
		/// The _sample private_string.
		/// </summary>
		private string _samplePrivate_string;
		
		// PRIVATE STATIC
		/// <summary>
		/// The _ sample private static_string.
		/// </summary>
		private static string _SamplePrivateStatic_string;
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		/// <summary>
		/// Initializes a new instance of the <see cref="lesson_8_naming_conventions.ClassWithRMCConventions"/> class.
		/// </summary>
		public ClassWithRMCConventions ()
		{
			//
			//Debug.Log ("ClassWithRMCConventions.constructor()");
			
		}
		
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="lesson_8_naming_conventions.ClassWithRMCConventions"/> is reclaimed by garbage collection.
		/// </summary>
		~ClassWithRMCConventions ( )
		{
			//Debug.Log ("ClassWithRMCConventions.deconstructor()");
			
		}
		
		
		// PUBLIC
	
		/// <summary>
		/// Samples the public method.
		/// </summary>
		/// <returns>
		/// The public method.
		/// </returns>
		/// <param name='aMessage_string'>
		/// A message_string.
		/// </param>
		public string samplePublicMethod (string aMessage_string) 
		{
			string sampleLocalVariable_string = " sample";
			return aMessage_string + sampleLocalVariable_string;
			
		}
		
		// PUBLIC STATIC
		
		/// <summary>
		/// Samples the public static method.
		/// </summary>
		/// <returns>
		/// The public static method.
		/// </returns>
		/// <param name='aMessage_string'>
		/// A message_string.
		/// </param>
		public static string SamplePublicStaticMethod (string aMessage_string) 
		{
			return aMessage_string;
			
		}
		
		// PRIVATE
		
		/// <summary>
		/// _samples the private method.
		/// </summary>
		/// <returns>
		/// The private method.
		/// </returns>
		/// <param name='aMessage_string'>
		/// A message_string.
		/// </param>
		private string _samplePrivateMethod (string aMessage_string) 
		{
			return aMessage_string;
			
		}
		
		// PRIVATE STATIC
		
		/// <summary>
		/// _s the sample private static method.
		/// </summary>
		/// <returns>
		/// The sample private static method.
		/// </returns>
		/// <param name='aMessage_string'>
		/// A message_string.
		/// </param>
		private static string _SamplePrivateStaticMethod (string aMessage_string) 
		{
			return aMessage_string;
			
		}
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the sample event.
		/// </summary>
		/// <param name='aMessage_string'>
		/// A message_string.
		/// </param>
		public void onSampleEvent (string aMessage_string) 
		{
			Debug.Log ("onSampleEvent(): " + aMessage_string);
			
		}
	}
}
