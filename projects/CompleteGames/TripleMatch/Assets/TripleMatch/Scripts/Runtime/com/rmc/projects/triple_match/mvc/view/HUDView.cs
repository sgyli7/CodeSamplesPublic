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
using com.rmc.projects.triple_match.mvc.view.view_components;
using com.rmc.core.managers;


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
		public Text _timeText;

		[SerializeField]
		public Text _scoreText;

		[SerializeField]
		public Text _instructionsText;
		
		[SerializeField]
		public Text _gameResetText;

		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor / Creation
		//--------------------------------------	

		/// <summary>
		/// Initialize the specified model and controller.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <param name="controller">Controller.</param>
		override public void Initialize (Model model, Controller controller)
		{
			base.Initialize (model, controller);

			_RenderInstructionsText (TripleMatchConstants.TEXT_EMPTY);
			
			_model.OnGameResetted += _OnGameResetted;
			_model.OnScoreChanged += _OnScoreChanged;
			_model.OnIsInputEnabledChanged += _OnIsInputEnabledChanged;
			_model.OnTimeLeftInRoundChanged += _OnTimeLeftInRoundChanged;
			_model.OnTimeLeftInRoundExpired += _OnTimeLeftInRoundExpired;
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
			_model.OnIsInputEnabledChanged -= _OnIsInputEnabledChanged;
			_model.OnScoreChanged -= _OnScoreChanged;
			_model.OnTimeLeftInRoundChanged -= _OnTimeLeftInRoundChanged;
			_model.OnTimeLeftInRoundExpired -= _OnTimeLeftInRoundExpired;
		}


		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// 	PUBLIC

		/// <summary>
		/// Rewards the one match.
		/// </summary>
		public void RewardOneMatch (int score_int, Vector3 initialPosition_vector3)
		{

			GameObject floatingScoreViewPrefab = Instantiate (Resources.Load (TripleMatchConstants.PATH_FLOATING_SCORE_VIEW_PREFAB)) as GameObject;;
			floatingScoreViewPrefab.gameObject.transform.SetParent (_canvas.gameObject.transform);
			FloatingScoreViewComponent floatingScoreView = floatingScoreViewPrefab.GetComponent<FloatingScoreViewComponent>();
			floatingScoreView.Initialize (score_int, initialPosition_vector3);
			_controller.SetScore (_model.Score + score_int, TripleMatchConstants.DURATION_FLOATING_SCORE_EXIT);

		}

		//	PRIVATE


		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderTitleText (string text_string)
		{
			_titleText.text = text_string;
		}

		/// <summary>
		/// _renders the time text.
		/// </summary>
		private void _RenderTimeText (int time_int)
		{
			_timeText.text = string.Format (TripleMatchConstants.TEXT_TIME_TOKEN, time_int);
		}

		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderScoreText (int score_int)
		{
			_scoreText.text = string.Format (TripleMatchConstants.TEXT_SCORE_TOKEN, score_int); 
		}
		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderGameResetText (string text_string)
		{
			_gameResetText.text = text_string; 
		}


		/// <summary>
		/// _renders the instructions text.
		/// </summary>
		private void _RenderInstructionsText (string text_string)
		{
			_instructionsText.text = text_string; 
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

			//This Animator State Machine will call OnCoverFadeInComplete()
			gameObject.GetComponent<Animator>().SetTrigger ("StartGameTrigger");


		}


		
		/// <summary>
		/// Raises the cover fade in complete event.
		/// 
		/// NOTE: Must be public for Unity 4.6.x State Machine Events
		/// 
		/// </summary>
		public void OnCoverFadeInComplete()
		{
			
			//Debug.Log ("HUD: Resetted");
			_controller.GameReset();
			

			
		}


		
		/// <summary>
		/// _ons the game resetted.
		/// </summary>
		private void _OnGameResetted ()
		{

			//	RENDER DISPLAY TEXT
			//		OPTIONAL: REPLACE STATIC CONST WITH STATIC METHOD TO ADD LOCALIZATION BY SPOKEN LANGUAGE
			_RenderGameResetText (TripleMatchConstants.TEXT_GAME_RESET_TEXT);
			_RenderTitleText (TripleMatchConstants.TEXT_TITLE );
			_RenderScoreText (0);
			_RenderInstructionsText (TripleMatchConstants.TEXT_INSTRUCTIONS_INPUT_ENABLED);
			
			//	HIDE GLOW ON RESTART BUTTON 
			gameObject.GetComponent<Animator>().SetBool ("IsGameOver", false);

		}

		/// <summary>
		/// _ons the game resetted.
		/// </summary>
		private void _OnIsInputEnabledChanged (bool isInputEnabled)
		{

			if (isInputEnabled)
			{
				_RenderInstructionsText (TripleMatchConstants.TEXT_INSTRUCTIONS_INPUT_ENABLED);
			}
			else
			{
				_RenderInstructionsText (TripleMatchConstants.TEXT_INSTRUCTIONS_INPUT_DISABLED);
			}
			
		}




		/// <summary>
		/// _s the on time left in round changed.
		/// </summary>
		/// <param name="timeLeft_int">Time left_int.</param>
		private void _OnTimeLeftInRoundChanged (int timeLeft_int)
		{
			_RenderTimeText (timeLeft_int);	
		}



		/// <summary>
		/// _s the on time left in round expired.
		/// </summary>
		private void _OnTimeLeftInRoundExpired ()
		{
			//	SOUND
			if (AudioManager.IsInstantiated())
			{
				AudioManager.Instance.PlayAudioResourcePath (TripleMatchConstants.PATH_TIME_LEFT_IN_ROUND_EXPIRED_AUDIO, TripleMatchConstants.VOLUME_SCALE_SFX_1);
			}

			//	SHOW GLOW ON RESTART BUTTON TO ATTRACT USER ATTENTION
			gameObject.GetComponent<Animator>().SetBool ("IsGameOver", true);

			//
			_RenderInstructionsText (TripleMatchConstants.TEXT_INSTRUCTIONS_GAME_OVER);

		}


		/// <summary>
		/// _s the on score changed.
		/// </summary>
		private void _OnScoreChanged (int score_int)
		{
			_RenderScoreText (score_int);	
		}

	}
}
