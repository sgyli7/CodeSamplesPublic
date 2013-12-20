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
	public class Beer : Beverage
	{

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		///<summary>
		///	The number of calories in this particular beer.
		///</summary>
		private uint _calories_uint = 200;
		public uint calories { 
			get 
			{ 
				//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
				return _calories_uint; 
			}
			set 
			{ 
				//OPTIONAL: CONTROLL ACCESS TO PRIVATE VALUE
				_calories_uint = value; 
			}
		}
			
		
		// PUBLIC
		
		///<summary>
		///	This is a sample public property.
		///</summary>
		public string containerType = CONTAINER_TYPE_BOTTLE;


		// PUBLIC STATIC
		///<summary>
		///	This is a sample public static property.
		///</summary>
		public static string CONTAINER_TYPE_BOTTLE = "CONTAINER_TYPE_BOTTLE";
		
		///<summary>
		///	This is a sample public static property.
		///</summary>
		public static string CONTAINER_TYPE_CAN = "CONTAINER_TYPE_CAN";
		
		// PRIVATE
		
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
		public Beer (string aName_string, string containerType_string)  : base (aName_string)
		{

			//Debug.Log ("Beer Constructor ------------");


			//	PROPERTIES
			name = aName_string;
			containerType = containerType_string;
			
		}

		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------

		public string getMyName ()
		{
			return name;
		}
	}
}
