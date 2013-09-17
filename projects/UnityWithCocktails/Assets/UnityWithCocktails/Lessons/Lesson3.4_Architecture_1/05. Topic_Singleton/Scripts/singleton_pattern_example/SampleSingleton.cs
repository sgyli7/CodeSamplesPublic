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

//--------------------------------------
//  Namespace
//--------------------------------------
namespace singleton_pattern_example
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
	public class SampleSingleton
	{
	
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _count_uint.
		/// </summary>
		private uint _count_uint;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		///<summary>
		///	 Constructor
		///
		///		NOTE: The 'magic' of singletons is the *private* constructor
		///
		///
		///</summary>
		private SampleSingleton( )
		{
			//PROPERTIES
			_count_uint = 0;
		}
		
		
		// PUBLIC
		///<summary>
		///	 COUNT
		///</summary>
		public void countUp( )
		{
			_count_uint ++;
		}
		
		///<summary>
		///	 COUNT
		///</summary>
		public uint getCount( )
		{
			return _count_uint;
		}
		
		// PUBLIC STATIC
		///<summary>
		///	 
		///</summary>
		private static SampleSingleton _Instance;
		public static SampleSingleton Instance 
		{
			get 
			{
				if (_Instance == null) {
					_Instance = new SampleSingleton();
				} 
				return _Instance;
			}
		}
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}

