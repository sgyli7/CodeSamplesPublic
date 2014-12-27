﻿/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
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

//--------------------------------------
//  Namespace
//--------------------------------------
using UnityEngine;


namespace com.rmc.core.support
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
	public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : MonoBehaviour
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		//	GETTER / SETTER
		/// <summary>
		/// Do not call this from another scope within OnDestroy(). Instead use IsInstantiated()
		/// </summary>
		private static T _Instance; //harmless warning
		public static T Instance
		{
			get
			{
				if (!IsInstantiated())
				{
					Instantiate();
				}
				return _Instance;
			}
			set
			{
				_Instance = value;
			}
			
		}


				
		/// <summary>
		/// Determines if is instantiated.
		/// </summary>
		/// <returns><c>true</c> if is instantiated; otherwise, <c>false</c>.</returns>
		public static bool IsInstantiated()
		{
			return _Instance != null;
		}
		
		
		// 	PUBLIC

		/// <summary>
		/// The on instantiate completed.
		/// </summary>
		public delegate void OnInstantiateCompletedDelegate (T instance);
		public static OnInstantiateCompletedDelegate OnInstantiateCompleted;
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	

		
		/// <summary>
		/// Instantiate this instance. Creates new model
		/// </summary>
		public static T Instantiate ()
		{
			
			if (!IsInstantiated())
			{
				GameObject go = new GameObject ();
				_Instance = go.AddComponent<T>();
				go.name = _Instance.GetType().FullName;
				DontDestroyOnLoad (go);

				if (OnInstantiateCompleted != null)
				{
					OnInstantiateCompleted (_Instance);
				}
			}
			return _Instance;
		}

		/// <summary>
		/// Destroys all memory/references associated with the instance
		/// </summary>
		public static void Destroy()
		{
			
			if (IsInstantiated())
			{
				// NOTE: Use 'DestroyImmediate'. At runtime its less important, but occasionally editor classes will call Destroy();
				DestroyImmediate (_Instance.gameObject);
				_Instance = null;
			}


		}
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------

		//	PUBLIC
		
		
		//	PRIVATE
		
		
		
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}
