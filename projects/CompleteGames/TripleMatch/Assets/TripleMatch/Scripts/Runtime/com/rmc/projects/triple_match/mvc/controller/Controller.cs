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
using com.rmc.projects.triple_match.mvc.model;
using com.rmc.projects.triple_match.mvc.model.data.vo;
using com.rmc.core.support;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.mvc.controller
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
	public class Controller: SingletonMonobehavior<Controller>
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------

		//	SETTER/GETTER
		
		// 	PUBLIC
		
		
		// 	PRIVATE
		/// <summary>
		/// MVC Reference
		/// </summary>
		private Model _model;
			
		
		//--------------------------------------
		//  Constructor / Creation
		//--------------------------------------	
		
			
		/// <summary>
		/// Initialize the specified instance.
		/// </summary>
		/// <param name="instance">Instance.</param>
		public void Initialize (Model model)
		{
			_model = model;
		}

		//--------------------------------------
		//  Unity Methods
		//--------------------------------------
		
		///<summary>
		///	Use this for initialization
		///</summary>
		protected void Start () 
		{
			
			
		}
		
		
		///<summary>
		///	Called once per frame
		///</summary>
		protected void Update () 
		{
			
			
		}
		
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		
		// 	PUBLIC
			
		/// <summary>
		/// Resets the game.
		/// </summary>
		public void GameReset ()
		{
			
			_model.GameReset();
		}

		/// <summary>
		/// Checks for matches.
		/// </summary>
		public void CheckForMatches ()
		{
			_model.CheckForMatches();
		}


		/// <summary>
		/// Adds the gems to fill gaps.
		/// </summary>
		public void DoFillGapsInGems ()
		{
			_model.DoFillGapsInGems();
		}


		/// <summary>
		/// Sets the score.
		/// </summary>
		/// <param name="score_int">Score_int.</param>
		/// <param name="delayUntilSet_float">Delay until set_float.</param>
		public void SetScore (int score_int, float delayUntilSet_float)
		{
			_model.SetScore (score_int, delayUntilSet_float);
		}


		/// <summary>
		/// Sets the is input enabled to false.
		/// </summary>
		public void SetIsInputEnabledToFalse()
		{
			_model.IsInputEnabled = false;
		}

		
		/// <summary>
		/// Sets the is input enabled to false.
		/// </summary>
		public void SetIsInputEnabledToTrue()
		{
			_model.IsInputEnabled = true;
		}
	
		
		/// <summary>
		/// Selecteds the gem V.
		/// </summary>
		public GemVO SelectedGemVO 
		{
			set
			{
				_model.SelectedGemVO = value;
			}
		}
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		//  Events
		//--------------------------------------




	}
}
