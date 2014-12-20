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
using com.rmc.projects.triple_match.mvc.model;
using com.rmc.projects.triple_match.mvc.controller;
using com.rmc.projects.triple_match.mvc.model.data;
using System.Collections.Generic;



//--------------------------------------
//  Namespace
//--------------------------------------
using com.rmc.core.audio;
using System.Linq;
using com.rmc.projects.triple_match.mvc.view.view_components;


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
	public class EnvironmentView : AbstractView
	{
		
		
		//--------------------------------------
		//  Properties
		//--------------------------------------
		
		// GETTER / SETTER



		// 	PUBLIC


		/// <summary>
		/// The _gems parent.
		/// </summary>
		[SerializeField]
		public GameObject _gemsParent;

		/// <summary>
		/// The _hud view.
		/// </summary>
		[SerializeField]
		public HUDView _hudView;
		
		/// <summary>
		/// The _gem views.
		/// </summary>
		private List<GemViewComponent> _gemViews;
		
		
		// 	PRIVATE
		
		
		//--------------------------------------
		// 	Constructor
		//--------------------------------------	

		/// <summary>
		/// Initialize the specified model and controller.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <param name="controller">Controller.</param>
		override public void Initialize (Model model, Controller controller)
		{
			base.Initialize (model, controller);
			
			_model.OnGameResetted += _OnGameResetted;
			_model.OnScoreChanged += _OnScoreChanged;
			_model.OnSelectedGemVOChanged += _OnSelectedGemVOChanged;
			_model.OnGemVOsMarkedForDeletionChanged += _OnGemVOsMarkedForDeletionChanged;
		}
		


		
		//--------------------------------------
		// 	Unity Methods
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

		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy () 
		{
			_model.OnGameResetted -= _OnGameResetted;
			_model.OnSelectedGemVOChanged -= _OnSelectedGemVOChanged;
			_model.OnGemVOsMarkedForDeletionChanged -= _OnGemVOsMarkedForDeletionChanged;
			_model.OnScoreChanged -= _OnScoreChanged;

			foreach (GemViewComponent gemView in _gemViews)
			{
				gemView.OnClicked -= _OnGemViewClicked;
				
			}
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// 	PUBLIC



		
		//	PRIVATE
		
		


		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _DoLayoutGems (GemVO[,] gemVOs)
		{
			
			//	CLEAR OUT GEMS
			if (_gemViews != null)
			{
				foreach (GemViewComponent gemView in _gemViews)
				{
					gemView.Destroy();
					gemView.OnClicked -= _OnGemViewClicked;
					
				}
			}
			
			_gemViews = new List<GemViewComponent>();
			
			
			//
			GemVO nextGemVO;
			GameObject nextGemViewPrefab;
			GemViewComponent nextGemView;
			Vector3 spawnPointForGemsVector3;
			
			//
			for (int rowIndex_int = 0; rowIndex_int < gemVOs.GetLength(0); rowIndex_int += 1) 
			{
				for (int columnIndex_int = 0; columnIndex_int < gemVOs.GetLength(1); columnIndex_int += 1) 
				{
					nextGemVO = gemVOs[rowIndex_int,columnIndex_int];
					
					//	CREATE AND REPARENT
					nextGemViewPrefab = Instantiate (Resources.Load (TripleMatchConstants.PATH_GEM_VIEW_PREFAB)) as GameObject;
					nextGemViewPrefab.transform.parent = _gemsParent.transform;
					
					//	INITIALIZE WITH DATA VO
					nextGemView = nextGemViewPrefab.GetComponent<GemViewComponent>();
					

					//
					spawnPointForGemsVector3 = new Vector3 
						(
							TripleMatchConstants.COLUMN_SIZE * columnIndex_int, 
							5, 
							transform.localPosition.z
						);
					//
					nextGemView.Initialize (nextGemVO, spawnPointForGemsVector3);
					nextGemView.OnClicked += _OnGemViewClicked;
					_gemViews.Add (nextGemView);
				}
			}
			
			
		}
		

		
		
		/// <summary>
		/// _s the get gem view for gem vo.
		/// </summary>
		private GemViewComponent _GetGemViewForGemVo (GemVO gemVO)
		{
			GemViewComponent gemViewFound = null;
			foreach (GemViewComponent gemView in _gemViews)
			{
				if (gemView.GemVO == gemVO)
				{
					gemViewFound = gemView;
				}
			}
			
			return gemViewFound;
			
		}
		
		
		/// <summary>
		/// _s the swap two gem V os.
		/// </summary>
		private void _AttemptSwapTwoGemVOs (GemVO gemVO1, GemVO gemVO2)
		{
			int rowIndex = gemVO1.RowIndex;
			int columnIndex = gemVO1.ColumnIndex;
			//
			gemVO1.RowIndex = gemVO2.RowIndex;
			gemVO1.ColumnIndex = gemVO2.ColumnIndex;
			_GetGemViewForGemVo (gemVO1).TweenToNewPositionSwap(0);
			//
			gemVO2.RowIndex = rowIndex;
			gemVO2.ColumnIndex = columnIndex;
			_GetGemViewForGemVo (gemVO2).TweenToNewPositionSwap(0);

			//NO MATCH, THEN SWAP BACK
			if (!_model.IsThereAMatchContainingEitherGemVO(gemVO1, gemVO2))
			{

				//local variable used for code-readability
				float delayToStart_float = TripleMatchConstants.DURATION_GEM_TWEEN_SWAP;

				int rowIndex2 = gemVO1.RowIndex;
				int columnIndex2 = gemVO1.ColumnIndex;
				//
				gemVO1.RowIndex = gemVO2.RowIndex;
				gemVO1.ColumnIndex = gemVO2.ColumnIndex;
				_GetGemViewForGemVo (gemVO1).TweenToNewPositionSwap(delayToStart_float);
				//
				gemVO2.RowIndex = rowIndex2;
				gemVO2.ColumnIndex = columnIndex2;
				_GetGemViewForGemVo (gemVO2).TweenToNewPositionSwap(delayToStart_float);
			}
			else 
			{
				//TODO, CHECK FOR MATCHES?
			
			}

		}

		/// <summary>
		/// Reward one match.
		/// </summary>
		private void _RewardOneMatchFromGemVOList (List<GemVO> gemVOs)
		{
			List<GemViewComponent> gemViews = new List<GemViewComponent>();

			//TODO: replace with linq for brevity
			foreach (GemVO gemVO in gemVOs)
			{
				gemViews.Add (_GetGemViewForGemVo (gemVO));
			}

			//	TODO: find center point of all 3+ gems
			Vector3 centerPointOfMatch_vector3 = gemViews[0].gameObject.transform.position;


			//	CREATE AND REPARENT
			_hudView.RewardOneMatch 
				(
					TripleMatchConstants.GetScoreRewardForMatchOfLength (gemViews.Count), 
					centerPointOfMatch_vector3
				);

			foreach (GemViewComponent gemView in gemViews)
			{
				gemView.TweenToNewPositionExit();
			}

		}
		
		
		
		//--------------------------------------
		// 	Event Handlers
		//--------------------------------------

		
		/// <summary>
		/// _ons the game resetted.
		/// </summary>
		private void _OnGameResetted ()
		{
			
			//	RENDER
			_DoLayoutGems (_model.GemVOs);

			//	SOUND
			if (AudioManager.IsInstantiated())
			{
				AudioManager.Instance.StopAudioResourcePath (TripleMatchConstants.PATH_GAME_RESET_AUDIO);
				AudioManager.Instance.PlayAudioResourcePath (TripleMatchConstants.PATH_GAME_RESET_AUDIO, TripleMatchConstants.VOLUME_SCALE_SFX_1);

				AudioManager.Instance.StopAudioResourcePath (TripleMatchConstants.PATH_BACKGROUND_MUSIC_AUDIO);
				AudioManager.Instance.PlayAudioResourcePath (TripleMatchConstants.PATH_BACKGROUND_MUSIC_AUDIO, TripleMatchConstants.VOLUME_SCALE_MUSIC);
			}

		}
		
		/// <summary>
		/// _s the on score changed.
		/// </summary>
		private void _OnScoreChanged (int score_int)
		{
			//	SOUND
			if (AudioManager.IsInstantiated() && score_int > 0)
			{
				AudioManager.Instance.PlayAudioResourcePath (TripleMatchConstants.PATH_SCORE_INCREASE_AUDIO, TripleMatchConstants.VOLUME_SCALE_SFX_2);
			}
		}
		
		/// <summary>
		/// _s the on gem clicked.
		/// </summary>
		/// <param name="gemView">Gem view.</param>
		private void _OnGemViewClicked (GemViewComponent gemView)
		{

			Debug.Log ("clicked: " + gemView.GemVO);

			//TODO: ONLY EXIT AFTER A MATCH, NOT HERE
			gemView.TweenToNewPositionExit();
			return;




			//
			if (_model.GameState == GameState.PLAYING)
			{

				if (_model.SelectedGemVO == null)
				{
					//	1. SELECT FIRST GEM IN A PAIR
					_controller.SelectedGemVO = gemView.GemVO;
				}
				else if (_model.SelectedGemVO == gemView.GemVO)
				{
					//	2. DESELECT FIRST GEM IN A PAIR
					_controller.SelectedGemVO = null;
					
				}
				else if (Model.AreGemVOsSwappable (_model.SelectedGemVO, gemView.GemVO))
				{
					//	3. SWAP FIRST & SECOND GEM IN A PAIR
					_AttemptSwapTwoGemVOs (_model.SelectedGemVO, gemView.GemVO);
					_controller.SelectedGemVO = null;

				}
				else 
				{
					//	4. DESELECTED ALL
					_controller.SelectedGemVO = null;
				}

			}
		}
		
		/// <summary>
		/// _s the on selected gem VO changed.
		/// </summary>
		/// <param name="gemVO">Gem V.</param>
		private void _OnSelectedGemVOChanged (GemVO gemVO)
		{
			if (_gemViews != null)
			{
				foreach (GemViewComponent gemView in _gemViews)
				{
					//	1. DESELECT EXACTLY ALL GEMS (EXCEPT 1)
					gemView.SetIsHighlighted (false);
				}
				
				if (gemVO != null)
				{
					//	2. SELECT EXACTLY ONE GEM
					_GetGemViewForGemVo(gemVO).SetIsHighlighted (true);
				}
			}
		}
		
		
		/// <summary>
		/// _s the on gem V os marked for deletion changed.
		/// </summary>
		/// <param name="gemVOs">Gem V os.</param>
		private void _OnGemVOsMarkedForDeletionChanged (List<List<GemVO>> gemVOListOfLists)
		{

			//	1. deselect all
			foreach (GemViewComponent gemView in _gemViews)
			{
				
				gemView.SetIsHighlighted (false);
			}

			//	2. select some
			foreach (List<GemVO> gemVOList in gemVOListOfLists)
			{

				_RewardOneMatchFromGemVOList (gemVOList);


				//TODO: REMOVE HIGHLIGHTING, ITS FOR DEBUGGING ONLY
				foreach (GemVO gemVO in gemVOList)
				{
					_GetGemViewForGemVo(gemVO).SetIsHighlighted (true);
				}
			}
		}
		


	}
}

