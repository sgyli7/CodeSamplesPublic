/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
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
namespace com.rmc.projects.coins_and_platforms.components.tiles
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
	public class SnapMeComponent : MonoBehaviour 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		
		// PUBLIC
		/// <summary>
		/// The enabled.
		/// </summary>
		public bool isSnapping = true;

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		/// <summary>
		/// The _ SNA p_ FACTO.
		/// 
		/// NOTE: Larger value is more dramatic movement when snapping
		/// 
		/// </summary>
		private static float _SNAP_FACTOR = 0.1f; 
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public SnapMeComponent ()
		{


		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~SnapMeComponent ( )
		{


		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			

			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
		}
		
		// PUBLIC
		

		/// <summary>
		/// Snap Position of 2D Tiles to save time during manual layout.
		/// 
		/// NOTE: We may want to do more here.
		/// 
		/// NOTE: The SnapMeComponentEditor helps and calls this during update during EDIT & PLAY mode
		/// 
		/// NOTE: Todo:This is constant update is NOT EFFICIENT, AND NOT OPTIMIZED YET. But it makes level design a 'snap' (hahahahaha. Pun intended)
		/// 
		/// </summary>
		public void doSnapMe () 
		{
			if (isSnapping) {
				float xPos = transform.position.x;
				float yPos = transform.position.y;
				float zPos = transform.position.z;
				xPos = Mathf.Round(xPos * _SNAP_FACTOR) / _SNAP_FACTOR;
				yPos = Mathf.Round(yPos * _SNAP_FACTOR) / _SNAP_FACTOR;
				zPos = Mathf.Round(zPos * _SNAP_FACTOR) / _SNAP_FACTOR;
				transform.position = new Vector3 (xPos, yPos, zPos);
			}
			
		}

		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
