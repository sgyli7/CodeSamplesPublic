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
using strange.extensions.mediation.impl;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.bowling_strangeioc.mvc.view.ui
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
	public class GUIUI : View 
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The _instructions text_string.
		/// </summary>
		private string _instructionsText_string;
		public string instructionsText
		{ 
			get
			{
				return _instructionsText_string;
			}
			set
			{
				_instructionsText_string = value;
			}
		}

		private uint _totalPinsKnockedOver_uint;
		public uint totalPinsKnockedOver
		{ 
			get
			{
				return _totalPinsKnockedOver_uint;
			}
			set
			{
				_totalPinsKnockedOver_uint = value;
			}
		}

		
		// PUBLIC
		
		// PUBLIC STATIC
		
		// PRIVATE
		/// <summary>
		/// The _score_guitext.
		/// </summary>
		private GUIText _score_guitext = null;
		
		/// <summary>
		/// The _bowling pin prefabs_gameobject.
		/// </summary>
		private GameObject[] _bowlingPinPrefabs_gameobject = null;




		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------		
		///<summary>
		///	Use this for initialization
		///</summary>
		override protected void Start () 
		{
			
			base.Start();

			//
			GameObject scoreGUIText_gameobject	= GameObject.Find ("ScoreGUIText");
			_score_guitext = scoreGUIText_gameobject.GetComponent<GUIText>();
			
			//
			_bowlingPinPrefabs_gameobject = GameObject.FindGameObjectsWithTag ("BowlingPinPrefabTag");


		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		void Update () 
		{

		}


		
		// PUBLIC
		

		/// <summary>
		/// _dos the refresh display text.
		/// </summary>
		public void doRefreshDisplayText ()
		{
			_score_guitext.text  = "PINS HIT: " + _totalPinsKnockedOver_uint + "/10\n\nINSTRUCTIONS:\n" + _instructionsText_string;
		}


		/// <summary>
		/// _dos the update total pins knocked over.
		/// </summary>
		public uint doCalculateTotalPinsKnockedOver ()
		{

			uint totalPinsKnockedOver_uint = 0;
			
			//RECALCULATE
			foreach (GameObject bowlingPinPrefab in _bowlingPinPrefabs_gameobject) {
				
				//THROUGH TRIAL AND ERROR I FOUND A GOOD DETECTION FOR IF A PIN IS 'KNOCKED OVER'
				//
				//	METHOD: KNOCKED OVER IF ANGLE IS NOT '90' BETWEEN A PIN AND THE 'WORLD'
				int angle_int = (int) Quaternion.Angle (bowlingPinPrefab.transform.rotation, Quaternion.identity);
				bool knockedOver_boolean = !(angle_int == 90);
				
				//
				if (knockedOver_boolean) {
					totalPinsKnockedOver_uint++;
				}
					
			}
			return totalPinsKnockedOver_uint;
			
		}
		
		// PUBLIC STATIC
		
		// PRIVATE

		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events 
		//		(This is a loose term for -- handling incoming messaging)
		//
		//--------------------------------------

	}
	
}
