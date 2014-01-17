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
namespace com.rmc.projects.unity_car_racer
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
	public class GUIComponent : MonoBehaviour 
	{
		
		//--------------------------------------
		//  Attributes
		//--------------------------------------
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		
		// PUBLIC
		/// <summary>
		/// The car.
		/// </summary>
		public GameObject car;

		/// <summary>
		/// The button click_audioclip.
		/// </summary>
		public AudioClip buttonClick_audioclip;
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _car input component.
		/// </summary>
		private CarInputComponent _carInputComponent;

		/// <summary>
		/// The button click_audiosource.
		/// </summary>
		private AudioSource buttonClick_audiosource;

		
		// PRIVATE STATIC
		/// <summary>
		/// Sizing info
		/// </summary>
		private const int _GUI_WIDTH = 130;
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			_carInputComponent = car.GetComponent<CarInputComponent>();
			buttonClick_audiosource = GetComponent<AudioSource>();
			buttonClick_audiosource.clip = buttonClick_audioclip;
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			
			
		}

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI() 
		{
			//TEXT
			if (_carInputComponent.isInputEnabled) {
				GUI.Label ( new Rect (10, 35, _GUI_WIDTH, 20), "Status: Operational");
			} else {
				GUI.Label ( new Rect (10, 35, _GUI_WIDTH, 20), "Status: Crashed");
			}
			GUI.Label ( new Rect (10, 60, _GUI_WIDTH, 20), " --");


			//CHECKBOX
			_carInputComponent.isGravityRelative =  GUI.Toggle ( new Rect (10, 85, _GUI_WIDTH, 20), _carInputComponent.isGravityRelative,  "  Relative Gravity?");
			

			//BUTTONS
			if (GUI.Button ( new Rect (10, 110, _GUI_WIDTH, 20), "Reset Level")) {

				//AFTER SOUND COMPLETES, DO THE RESET
				//THIS WAY THE SOUND DOES NOT CUT OUT PREMATURELY
				buttonClick_audiosource.Play();
				Invoke ("doResetLevel", .5f);


			}
			if (GUI.Button ( new Rect (10, 130, _GUI_WIDTH, 20), "Reset Car")) {

				buttonClick_audiosource.Play();
				_carInputComponent.doResetCar();

				
			}




		}
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE

		/// <summary>
		/// Dos the reset level.
		/// </summary>
		private void doResetLevel () 
		{
			
			_carInputComponent.doResetLevel();
		}


		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------
	}
}
