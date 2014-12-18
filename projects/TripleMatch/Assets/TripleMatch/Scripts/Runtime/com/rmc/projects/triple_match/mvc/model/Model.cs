/**
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
using UnityEngine;
using com.rmc.support;
using com.rmc.projects.triple_match.mvc.model.data;
using System.Collections.Generic;

//--------------------------------------
//  Namespace
//--------------------------------------

namespace com.rmc.projects.triple_match.mvc.model
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
	public class Model: SingletonMonobehavior<Model>
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER
		/// <summary>
		/// The _gem V os.
		/// </summary>
		private GemVO[,] _gemVOs;
		public GemVO[,] GemVOs
		{
			get
			{
				return _gemVOs;
			}
			
		}

		
		/// <summary>
		/// 
		/// SelectedGemVO
		/// 
		/// 	Model - stores it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - updates it
		/// 
		/// </summary>
		public delegate void OnSelectedGemVOChangedDelegate (GemVO gemVO);
		public OnSelectedGemVOChangedDelegate OnSelectedGemVOChanged;
		private GemVO _selectedGemVO;
		public GemVO SelectedGemVO {
			get
			{
				return _selectedGemVO;
			}
			set
			{
				_selectedGemVO = value;
				
				if (OnSelectedGemVOChanged != null)
				{
					OnSelectedGemVOChanged (_selectedGemVO);
				}
				
			}
		}
		
		//
		public delegate void OnGameResettedDelegate ();
		public OnGameResettedDelegate OnGameResetted;

		public delegate void OnGemVOsMarkedForDeletionChangedDelegate (List<GemVO> gemVOs);
		public OnGemVOsMarkedForDeletionChangedDelegate OnGemVOsMarkedForDeletionChanged;

		
		/// <summary>
		/// 
		/// Score
		/// 
		/// 	Model - stores it
		/// 	View - displays it (via delegate listening)
		/// 	Controller - updates it
		/// 
		/// </summary>
		public delegate void OnScoreChangedDelegate (int newScore);
		public OnScoreChangedDelegate OnScoreChanged;
		private int _score;
		public int Score 
		{
			get
			{
				return _score;
			}
			set
			{
				_score = value;
				if (OnScoreChanged != null)
				{
					OnScoreChanged (_score);
				}
			}
		}
		
		// 	PUBLIC
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		protected void Start () 
		{
			Debug.Log ("Model.Start()");
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
		}



		/// <summary>
		/// Debug only
		/// </summary>
		private bool _debugging_HasCheckedForMatches = false;


		///<summary>
		///	Called once per frame
		///</summary>
		protected void Update () 
		{


			
			if (Input.GetKeyDown (KeyCode.Space))
			{
				if (!_debugging_HasCheckedForMatches)
				{
					_CheckForMatches();
				}
				else
				{
					//CLEAR THOSE MARKED
					List<GemVO> gemVOsMarkedForDeletion = new List<GemVO>();
					if (OnGemVOsMarkedForDeletionChanged != null)
					{
						OnGemVOsMarkedForDeletionChanged (gemVOsMarkedForDeletion);
					}
				}
				_debugging_HasCheckedForMatches = ! _debugging_HasCheckedForMatches;
				
			}

			
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC
		
		
		/// <summary>
		/// Resets the game.
		/// </summary>
		public void GameReset ()
		{
			
			Score = 0;
			SelectedGemVO = null;
			
			
			//	CLEAR EXISTING GEMS
			foreach (GemVO gemVO in _gemVOs)
			{
				//	TODO: CLEAR EACH
			}
			_gemVOs = new GemVO[TripleMatchConstants.MAX_ROWS, TripleMatchConstants.MAX_COLUMNS];
			
			
			//	CREATE ALL NEW GEMS
			GemVO nextGemVO;
			int nextGemTypeIndex;
			//
			for (int rowIndex_int = 0; rowIndex_int < TripleMatchConstants.MAX_ROWS; rowIndex_int++)
			{
				for (int columnIndex_int = 0; columnIndex_int < TripleMatchConstants.MAX_COLUMNS; columnIndex_int++)
				{
					//	SET INDEX (THIS MEANS THE COLOR)
					nextGemTypeIndex = Random.Range (0, TripleMatchConstants.MAX_GEM_TYPE_INDEX);
					
					//	CREATE 1 NEW GEM
					nextGemVO = new GemVO (rowIndex_int, columnIndex_int, nextGemTypeIndex);
					_gemVOs[rowIndex_int, columnIndex_int] = nextGemVO;
				}
			}
			
			
			Debug.Log (this);
			
			if (OnGameResetted != null)
			{
				OnGameResetted ();
			}
		}
		
		
		
		
		/// <summary>
		/// Show nice debuggable output
		/// </summary>
		override public string ToString ()
		{
			string s = "";
			s+= "[Model] (Single Click For *Gem* Grid Output)";
			s+= "\n";
			for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					s += _gemVOs[rowIndex_int,columnIndex_int].GemTypeIndex;
				}
				s += "\n";
			}
			return s;
			
		}

	
		
		//	PRIVATE
		private void _CheckForMatches ()
		{
			Debug.Log ("_CheckForMatches()");

			List<GemVO> gemVOsMarkedForDeletion = new List<GemVO>();
			GemVO prevGemVO;
			GemVO nextGemVO;
			//HORIZONTAL
			for (int rowIndex_int = 0; rowIndex_int < _gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				//VERTICAL (Start at index 1)
				for (int columnIndex_int = 1; columnIndex_int < _gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					nextGemVO = _gemVOs[rowIndex_int,columnIndex_int];
					prevGemVO = _gemVOs[rowIndex_int,columnIndex_int-1];

					//TODO: CHECK FOR MORE THAN 2
					if (nextGemVO.GemTypeIndex == prevGemVO.GemTypeIndex)
					{

						if (!gemVOsMarkedForDeletion.Contains (prevGemVO))
						{
							gemVOsMarkedForDeletion.Add (prevGemVO);
						}
						if (!gemVOsMarkedForDeletion.Contains (nextGemVO))
						{
							gemVOsMarkedForDeletion.Add (nextGemVO);
						}

					}
				}
			}

			if (OnGemVOsMarkedForDeletionChanged != null)
			{
				OnGemVOsMarkedForDeletionChanged (gemVOsMarkedForDeletion);
			}

		}	
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
	}
}

