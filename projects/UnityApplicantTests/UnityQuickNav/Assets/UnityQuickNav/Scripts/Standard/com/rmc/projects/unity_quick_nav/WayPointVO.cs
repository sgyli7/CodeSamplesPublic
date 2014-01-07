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
using com.rmc.exceptions;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.unity_quick_nav
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
	public class WayPointVO 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// Gets or sets the target game object.
		/// </summary>
		/// <value>The target game object.</value>
		public GameObject gameObject {set; get;}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="com.rmc.projects.unity_quick_nav.WayPointVO"/> was visited.
		/// </summary>
		/// <value><c>true</c> if was visited; otherwise, <c>false</c>.</value>
		public bool wasVisited {set; get;}


		// PUBLIC

		
		// PRIVATE STATIC

		//--------------------------------------
		//  Constructor
		//--------------------------------------		
		public WayPointVO (GameObject aGameObject) 
		{
			gameObject = aGameObject;
			wasVisited = false;
		}

		//--------------------------------------
		//  Methods
		//--------------------------------------
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		
		
	}
}
