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
namespace com.rmc.projects.unity_state_management.states_by_interfaces
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	/// <summary>
	/// States.
	/// </summary>
	public enum StateType 
	{
		FIRST_STATE,
		SECOND_STATE
	}
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class StatesByInterfacesComponent : MonoBehaviour, IFirstState, ISecondState
	{
		

		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The type of the _state.
		/// </summary>
		private StateType _stateType;
		public StateType stateType { 
			get 
			{ 
				return _stateType; 
			}
			set 
			{ 
				_stateType = value; 
			}
		}
			
		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _current count_int.
		/// </summary>
		private int _currentCount_int = MAX_COUNT - 1; //IMMEDIATLY TRIGGER A CALL
		
		/// <summary>
		/// Constant MAX COUNT, HIGHER NUMBER MEANS LOWER FREQUENCY OF CALLS
		/// </summary>
		private const int MAX_COUNT = 50;
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------	
		// PUBLIC
		
		///<summary>
		///	 Constructor
		///</summary>
		public StatesByInterfacesComponent ()
		{
			//
			//Debug.Log ("StatesByInterfacesComponent.constructor()");
			
		}
		
		/// <summary>
		/// Deconstructor
		/// </summary>
		~StatesByInterfacesComponent ( )
		{
			//Debug.Log ("StatesByInterfacesComponent.deconstructor()");
			
		}
		
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start () 
		{
			
			stateType = StateType.FIRST_STATE;
			
		}
		

		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{
			//COUNT UP TO LIMIT FREQUENCY OF EXECUTION
			if (++_currentCount_int > MAX_COUNT) {
				if (stateType == StateType.FIRST_STATE) {
					(this as IFirstState).CustomUpdate();
				} else if (stateType == StateType.SECOND_STATE) {
					(this as ISecondState).CustomUpdate();
				}
				_currentCount_int = 0;
			}
			

			//MOUSE
			OnGetMouseButtonDown();
			
			
		}
		
		/// <summary>
		/// Raises the get mouse button down event.
		/// </summary>
		void OnGetMouseButtonDown () 
		{
			if (Input.GetMouseButtonDown(0)) {
				
				//CLICK MOUSE = CHANGE STATE
				switch (_stateType) {
					case StateType.FIRST_STATE:
						stateType = StateType.SECOND_STATE;
						break;
					case StateType.SECOND_STATE:
						stateType = StateType.FIRST_STATE;
						break;
				}
				
			}
			
		}
		
		

		/// <summary>
		/// Updates for FIRST_STATE
		/// </summary>
		void IFirstState.CustomUpdate () 
		{
			//DO UNIQUE CODE FOR THIS STATE
			Debug.Log ("UpdateFor_FIRST_STATE()");
			
		}

		/// <summary>
		/// Updates for SECOND_STATE
		/// </summary>
		void ISecondState.CustomUpdate () 
		{
			//DO UNIQUE CODE FOR THIS STATE
			Debug.Log ("UpdateFor_SECOND_STATE()");
			
		}
		
		// PUBLIC STATIC
		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// Ons the sample event.
		/// </summary>
		/// <param name='aMessage_str'>
		/// A message_str.
		/// </param>
		public void onSampleEvent (string aMessage_str) 
		{
			Debug.Log ("onSampleEvent(): " + aMessage_str);
			
		}
	}
}
