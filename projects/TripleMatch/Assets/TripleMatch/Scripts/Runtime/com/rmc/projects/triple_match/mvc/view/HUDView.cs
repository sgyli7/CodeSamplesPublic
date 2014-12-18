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
using UnityEngine.UI;
using com.rmc.projects.triple_match.mvc.model;
using com.rmc.projects.triple_match.mvc.controller;



//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match.mvc.view
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
	public class HUDView : AbstractView 
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER

		
		// 	PUBLIC

		[SerializeField]
		public Canvas _canvas;

		[SerializeField]
		public Text _titleText;
		
		[SerializeField]
		public Text _scoreText;
		
		[SerializeField]
		public Text _gameResetText;

		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	


		override public void Initialize (Model model, Controller controller)
		{
			base.Initialize (model, controller);
			
			_model.OnGameResetted += _OnGameResetted;
			_model.OnScoreChanged += _OnScoreChanged;
		}
		
		//--------------------------------------
		// 	Unity Methods
		//--------------------------------------
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy () 
		{
			_model.OnGameResetted -= _OnGameResetted;
			_model.OnScoreChanged -= _OnScoreChanged;
		}


		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// 	PUBLIC

		/// <summary>
		/// Rewards the one match.
		/// </summary>
		public void RewardOneMatch (float score_float, Vector3 initialPosition_vector3, Vector3 targetPosition_vector3)
		{
			GameObject floatingScoreViewPrefab = Instantiate (Resources.Load (TripleMatchConstants.PATH_FLOATING_SCORE_VIEW_PREFAB)) as GameObject;
			floatingScoreViewPrefab.gameObject.transform.parent = _canvas.gameObject.transform;
			floatingScoreViewPrefab.transform.position = initialPosition_vector3;
			FloatingScoreView floatingScoreView = floatingScoreViewPrefab.GetComponent<FloatingScoreView>();
			floatingScoreView.Initialize (score_float, initialPosition_vector3, targetPosition_vector3);
		}

		//	PRIVATE


		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderTitleText (string titleText_string)
		{
			_titleText.text = titleText_string;
		}
		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderScoreText (int score_int)
		{
			_scoreText.text = TripleMatchConstants.TEXT_SCORE_LABEL + score_int;
		}
		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderGameResetText (string gameResetText_string)
		{
			_gameResetText.text = gameResetText_string; 
		}
		
		
		//	PRIVATE
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------
		/// <summary>
		/// Raises the game reset button clicked event.
		/// 
		/// NOTE: Must be public for Unity 4.6.x UI Event System
		/// 
		/// </summary>
		public void OnGameResetButtonClicked()
		{
			
			Debug.Log ("OnGameResetButtonClicked()");
			_controller.GameReset();
			
		}
		
		/// <summary>
		/// _ons the game resetted.
		/// </summary>
		private void _OnGameResetted ()
		{
			
			Debug.Log ("HUD: Resetted");
			
			//	RENDER DISPLAY TEXT
			//		OPTIONAL: REPLACE STATIC CONST WITH STATIC METHOD TO ADD LOCALIZATION BY SPOKEN LANGUAGE
			_RenderGameResetText (TripleMatchConstants.TEXT_GAME_RESET_TEXT);
			_RenderTitleText (TripleMatchConstants.TEXT_TITLE );
			_RenderScoreText (0);
		}
		
		/// <summary>
		/// _s the on score changed.
		/// </summary>
		private void _OnScoreChanged (int score)
		{
			
		}
	}
}
