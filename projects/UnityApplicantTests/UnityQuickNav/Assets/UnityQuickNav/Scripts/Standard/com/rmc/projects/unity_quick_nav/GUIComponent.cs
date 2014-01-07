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
	public class GUIComponent : SuperMonoBehavior 
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
		private bool _isGUIEnabled_boolean;
		public bool isGUIEnabled { 
			get 
			{ 
				return _isGUIEnabled_boolean; 
			}
			set 
			{ 
				_isGUIEnabled_boolean = value; 
			}
		}

		
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
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			//Debug.Log("Update ()");
			
		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		private void OnGUI() 
		{

			//Debug.Log ("GUIComponent.OnGUI()");


			//SETUP LOWER LEFT ORIENTATION
			float leftX_float 			= 5;
			float buttonHeight_float 	= 20;
			float buttonWidth_float 	= 60;
			float buttonBigWidth_float 	= 110;
			float currentY_float 		= Screen.height - 6*buttonHeight_float - 5;

			//**************************
			//LOOP THROUGH WAYPOINTS AND MAKE A BUTTON FOR EACH
			//**************************
			if (_isGUIEnabled_boolean) {

				int wayPointIndex_int = 0;
				int totalWasVisited_uint = 0;
				//
				foreach (WayPointVO wayPointVO in simpleControllerComponent.wayPoints_list) {

					string buttonLabel_string;
					if (simpleControllerComponent.isCurrentWayPoint(wayPointVO)	){
						buttonLabel_string = ">Nav " + (wayPointIndex_int + 1) + "<";
					} else {
						buttonLabel_string = "Nav " + (wayPointIndex_int + 1);
					}

					//ADD BUTTON
					if (GUI.Button (new Rect (leftX_float, currentY_float, buttonWidth_float, buttonHeight_float), buttonLabel_string)){
						simpleControllerComponent.setTargetWayPointByIndex (wayPointIndex_int);
					}

					//COUNT INDEX UP 
					wayPointIndex_int++;
					//MOVE LAYOUT LOWER
					currentY_float += buttonHeight_float;
					//COUNT HOW MANY VISITED FOR USER DISPLAY 
					if (wayPointVO.wasVisited) {
						totalWasVisited_uint ++;
					}
				}

				//**************************
				// MAKE HISTORY NAVIGATION
				//**************************
				//
				if (GUI.Button(new Rect (leftX_float, currentY_float, buttonBigWidth_float, buttonHeight_float), "Clear History")) {
					simpleControllerComponent.doClearHistory();
				}

				GUI.TextField (new Rect (leftX_float + buttonBigWidth_float, currentY_float, buttonBigWidth_float, buttonHeight_float), "History: " + totalWasVisited_uint + " Visited ");
				
			}
			
		}
	}
}
