/**
 * Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com                                                  
 *                                                                      
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the      
 * "Software"), to deal in the Software without restriction, including  
 * without limitation the rights to use, copy, modify, merge, publish,  
 * distribute, sublicense, and#or sell copies of the Software, and to   
 * permit persons to whom the Software is furn
 * 
 * ished to do so, subject to
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
namespace com.rmc.projects.paddle_soccer.mvcs
{
	
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	/// <summary>
	/// Sound type.
	/// </summary>
	public enum SoundType
	{
		BUTTON_CLICK,
		GAME_OVER_LOSS,
		GAME_OVER_WIN,
		GOAL_LOSS,
		GOAL_WIN,
		PADDLE_HIT,
		ROUND_START
	}

	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	
	
	//--------------------------------------
	//  Class
	//--------------------------------------
	/// <summary>
	/// Store constant values (ex. text for display)
	/// 
	/// </summary>
	public class Constants
	{
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER
		
		// PUBLIC
		
		// PUBLIC STATIC
		//
		public const string PROMPT_ROUND_START      = "Score {0} Goals To Win";
		public const string PROMPT_DROP_BALL_START  = "Get Ready!";

		//
		public const string PROMPT_GAME_END_WIN 	= "You Won The Game!";
		public const string PROMPT_GAME_END_LOSS	= "You Lost The Game!";
		//
		public const string HUD_CLICK_ANYWHERE      		= "Tap/Click Anywhere To Continue\n\n<size=15>Up Arrow, Down Arrow</size>\n<size=15>Return To Reset</size>";
		public const string HUD_CLICK_RESTART_KEYBOARD     	= "Press 'Return' To Reset";
		public const string HUD_CLICK_RESTART_VIRTUAL     	= "Press 'Reset' Buttton";

		//
		public const string HUD_RIGHT_SCORE      	= "CPU: {0}";
		public const string HUD_LEFT_SCORE      	= "Player: {0}";


		//
		public static float PADDLE_Y_TARGET_MINIMUM		= -3; //GOVERNS ACTUAL POSITION LIMITS
		public static float PADDLE_Y_TARGET_MAXIMUM		= 3;  //GOVERNS ACTUAL POSITION
		public static float PADDLE_Y_LERP_MINIMUM		= PADDLE_Y_TARGET_MINIMUM - 1;  //GOVERNS ACCELERATION TO LIMITS
		public static float PADDLE_Y_LERP_MAXIMUM		= PADDLE_Y_TARGET_MAXIMUM + 1;  //GOVERNS ACCELERATION TO LIMITS
		public static float PADDLE_Y_LERP_ACCELERATION_DEFAULT  = 2.5f; //FOR PLAYER
		public static float PADDLE_Y_LERP_ACCELERATION_DEFAULT_MINIMUM  = 2.5f; //FOR CPU RANGE
		public static float PADDLE_Y_LERP_ACCELERATION_DEFAULT_MAXIMUM  = 3f; //FOR CPU RANGE


		//
		public static string VIRTUAL_CONTROLLER_BUTTON_LABEL_UP 	= "Up";
		public static string VIRTUAL_CONTROLLER_BUTTON_LABEL_DOWN 	= "Down";
		public static string VIRTUAL_CONTROLLER_BUTTON_LABEL_RESET 	= "Reset";


		//
		public static string AUDIO_BACKGROUND_MUSIC_01 	= "BackgroundMusic01";
		public static string AUDIO_BUTTON_CLICK_01 		= "ButtonClick01";
		public static string AUDIO_GAME_OVER_LOSS_01 	= "GameOverLoss01";
		public static string AUDIO_GAME_OVER_WIN_01 	= "GameOverWin01";
		public static string AUDIO_GOAL_LOSS_01 		= "GoalLoss01";
		public static string AUDIO_GOAL_WIN_01 			= "GoalWin01";
		public static string AUDIO_PADDLE_HIT_01 		= "PaddleHit01";
		public static string AUDIO_PADDLE_HIT_02 		= "PaddleHit02";
		public static string AUDIO_ROUND_START_01 		= "RoundStart01";


		
		// PRIVATE
		
		// PRIVATE STATIC
		
		//--------------------------------------
		//  Methods
		//--------------------------------------
		
		// PRIVATE STATIC
		
		// PRIVATE COROUTINE
		
		// PRIVATE INVOKE
		
		//--------------------------------------
		//  Events
		//--------------------------------------


	}
}

