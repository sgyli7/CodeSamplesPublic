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
using com.rmc.projects.triple_match.mvc.model.data.vo;
using UnityEngine;
using com.rmc.core.exceptions;


//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.triple_match
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
	public class TripleMatchConstants 
	{ 



		public enum Frequency
		{
			Always,
			Sometimes,
			Never
			
		}
		



		//--------------------------------------
		//  Properties
		//--------------------------------------

		//
		public static Frequency SETTING_GAMEPLAY_WILL_ALLOW_INSTANT_MATCHES_ON_GAME_RESET = Frequency.Sometimes; //TODO: setting to false 'works' but not well.


		// 	PUBLIC
		
		public const int MAX_ROWS = 8; //For Production, 8
		public const int MAX_COLUMNS = 8; //For Production, 8
		public const int MAX_GEM_TYPE_INDEX = 5; //For Production, 5
		public const int MIN_MATCHES_PER_VERTICAL_AXIS_FOR_REWARD = 3; //axis-specific for easy debugging
		public const int MIN_MATCHES_PER_HORIZONTAL_AXIS_FOR_REWARD = 3; //axis-specific for easy debugging

		//
		public static float ROW_SIZE = 0.4f;
		public static float COLUMN_SIZE = 0.4f;

		//
		public static float DURATION_DELAY_TO_START_GAME = 0.25f;
		public static float DURATION_DELAY_BEFORE_CHECK_FOR_MATCHES = 0.25f;
		public static float DURATION_DELAY_BEFORE_FILL_GAPS_IN_GEMS = 0.25f;
		public static float DURATION_GEM_TWEEN_SWAP = 0.5f;
		public static float DURATION_GEM_TWEEN_ENTRY = 0.5f;
		public static float DURATION_GEM_TWEEN_EXIT = 0.5f;
		public static float DURATION_FLOATING_SCORE_EXIT = 0.5f;
		public static float DURATION_DELAY_AFTER_MATCH_FOUND_BEFORE_INPUT_ENABLED = 2f;
		public static float DURATION_SCORE_NUMBER_CHANGES_OVER_TIME_TO_TARGET_VALUE = 1.25f;
		//
		public static int DURATION_TIME_TOTAL_IN_ROUND  = 60;	//For Production: Use 60 SECONDS
		public static float DURATION_TIME_LEFT_IN_ROUND_TICK = 1; //easily accelerate time for debugging
		public static float TIME_LEFT_IN_ROUND_DECREMENT_PER_TICK = 1;//easily accelerate time for debugging
		//
		public static string SORTING_LAYER_PARTICLE_EFFECTS = "ParticleEffectsSortingLayer";

		//

		public static string TEXT_EMPTY = ""; //easy programmatic search for references for debugging
		public static string TEXT_TITLE = "Triple Match";
		public static string TEXT_GAME_RESET_TEXT = "Reset Game!";
		public static string TEXT_SCORE_TOKEN = "Score: {0}";
		public static string TEXT_TIME_TOKEN = "Time: {0}";
		public static string TEXT_POINTS_TOKEN = "{0} Pts";
		//
		public static string TEXT_INSTRUCTIONS_INPUT_ENABLED = "Click 2 adjacent gems to swap. Enjoy!";
		public static string TEXT_INSTRUCTIONS_INPUT_DISABLED = "Rewarding Points! Please Wait...";


		public static string TEXT_INSTRUCTIONS_GAME_OVER = "Click '"+ TripleMatchConstants.TEXT_GAME_RESET_TEXT+"' to try again.";



		//PATH REQUIRED FOR Instantiate() calls. Those are deprecated in this game.
		//NAME REQUIRED FOR PoolingSystem calls.
		public static string PATH_GEM_VIEW_PREFAB = "Prefabs/GemViewPrefab";
		public static string PATH_GEM_EXPLOSION_PREFAB = "Prefabs/GemExplosionPrefab";
		public static string PATH_FLOATING_SCORE_VIEW_PREFAB = "Prefabs/FloatingScoreViewPrefab";
		//
		//
		public static string PATH_BACKGROUND_MUSIC_AUDIO = "Audio/Music/BackgroundMusic01";
		//
		public static string PATH_BUTTON_CLICK_AUDIO = "Audio/SoundEffects/ButtonClick01";
		public static string PATH_GAME_RESET_AUDIO = "Audio/SoundEffects/GameStart01";
		public static string PATH_SCORE_INCREASE_AUDIO = "Audio/SoundEffects/ScoreIncrease01";
		public static string PATH_GEM_SWAP_AUDIO = "Audio/SoundEffects/GemSwap01";
		public static string PATH_GEM_EXPLOSION_AUDIO = "Audio/SoundEffects/GemExit01";
		public static string PATH_DYNAMITE_EXPLOSION_AUDIO = "Audio/SoundEffects/DynamiteExplosion01";
		public static string PATH_TIME_LEFT_IN_ROUND_EXPIRED_AUDIO = "Audio/SoundEffects/TimeLeftInRoundExpired01";



		//

		public static float VOLUME_SCALE_SFX_1 = 0.25f;
		public static float VOLUME_SCALE_SFX_2 = 0.05f; //quieter
		public static float VOLUME_SCALE_MUSIC = 0.10f;

		//
		public static float POSITION_OFFSET_FLOATING_SCORE_VIEW_Y = 30;

		//
		public static int SCORE_POINTS_PER_GEM = 50;
		public static int SCORE_MULTIPLYER_PER_GEM = 2;


		//--------------------------------------
		//  Methods
		//--------------------------------------


		//	PUBLIC STATIC

		/// <summary>
		/// Gets the length of the score reward for match of.
		/// </summary>
		public static int GetScoreRewardForMatchOfLength (int gemCount_int)
		{
			return gemCount_int * TripleMatchConstants.SCORE_POINTS_PER_GEM * TripleMatchConstants.SCORE_MULTIPLYER_PER_GEM;
		}

		/// <summary>
		/// Gets the gem tween entry delay.
		/// </summary>
		public static float GetGemTweenEntryDelay (GemVO gemVO)
		{
			return (TripleMatchConstants.MAX_ROWS - gemVO.RowIndex) * 0.1f;
		}

		/// <summary>
		/// Gets the gem exit physics force.
		/// </summary>
		/// <returns>The gem exit physics force.</returns>
		public static Vector2 GetGemExitPhysicsForce ()
		{
			int sign_int;
			if (Random.Range (0, 2) == 1)
			{
				sign_int = 1;
			}
			else
			{
				sign_int = -1;
			}
			
			return new Vector2 (sign_int* 30, 70);
		}

		/// <summary>
		/// Gets the gem color by gem V. Since our list of gems is finite and permanent, manually listing the colors is fast/fun.
		/// 
		/// Option: Alternative, Pass GemViewComponent instance instead and take a sample of its pixel colors dynamically.
		/// 
		/// </summary>
		/// <returns>The gem color by gem V.</returns>
		/// <param name="_gemVO">_gem V.</param>
		public static Color GetGemColorByGemVO (GemVO _gemVO)
		{
			Color colorByGemVO = new Color(0,0,0); //create non-null default

			if (_gemVO != null)
			{
				switch (_gemVO.GemTypeIndex)
				{
				case 0:
					//	blue
					colorByGemVO = Color.blue;
					break;
				case 1:
					//	green
					colorByGemVO = Color.green;
					break;
				case 2:
					//	purple
					colorByGemVO = Color.magenta;
					break;
				case 3:
					//	red
					colorByGemVO = Color.red;
					break;
				case 4:
					//	yellow
					colorByGemVO = Color.yellow;
					break;
				default:
					#pragma warning disable 0162
					throw new SwitchStatementException ();
					#pragma warning restore 0162
					break;

				}
			}

			return colorByGemVO;

		}

		/// <summary>
		/// Initializes the particle system for unity4.6.x.
		/// 	FOR (UNITY'S NATIVE) SHURIKEN PARTICLE EFFECTS ON TOP OF UNITY 4.6.X 2D, WE MUST ADJUST SORTING
		/// </summary>
		/// <param name="particlesystem">Particlesystem.</param>
		public static void InitializeParticleSystemForUnity46X (ParticleSystem particlesystem)
		{
			particlesystem.renderer.sortingLayerName = TripleMatchConstants.SORTING_LAYER_PARTICLE_EFFECTS;
			particlesystem.renderer.sortingOrder = 1;
		}
	}

}
