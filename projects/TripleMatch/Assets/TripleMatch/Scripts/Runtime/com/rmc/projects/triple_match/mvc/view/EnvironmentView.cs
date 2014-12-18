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
		private List<GemView> _gemViews;
		
		
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

			foreach (GemView gemView in _gemViews)
			{
				gemView.OnClicked -= _OnGemViewClicked;
				
			}
		}
		
		
		//--------------------------------------
		// 	Methods
		//--------------------------------------
		
		
		// PUBLIC



		
		//	PRIVATE
		
		


		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _DoLayoutGems (GemVO[,] gemVOs)
		{
			
			//	CLEAR OUT GEMS
			if (_gemViews != null)
			{
				foreach (GemView gemView in _gemViews)
				{
					gemView.Destroy();
					gemView.OnClicked -= _OnGemViewClicked;
					
				}
			}
			
			_gemViews = new List<GemView>();
			
			
			//
			GemVO nextGemVO;
			GameObject nextGemViewPrefab;
			GemView nextGemView;
			Vector3 spawnPointForGemsVector3 = new Vector3 
				(
					(TripleMatchConstants.MAX_ROWS/2 - 0.5f)*TripleMatchConstants.ROW_SIZE, 
					(TripleMatchConstants.MAX_COLUMNS/2 - 0.5f)*TripleMatchConstants.COLUMN_SIZE, 
					transform.localPosition.z
					);
			
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
					nextGemView = nextGemViewPrefab.GetComponent<GemView>();
					
					
					//
					nextGemView.Initialize (nextGemVO, spawnPointForGemsVector3);
					nextGemView.OnClicked += _OnGemViewClicked;
					_gemViews.Add (nextGemView);
				}
			}
			
			
		}
		

		/// <summary>
		/// _s the is gem VO swappable with selected gem V.
		/// </summary>
		private bool _IsGemVOSwappableWithSelectedGemVO (GemVO gemVO)
		{
			bool isGemVOSwappableWithSelectedGemVO = false;
			
			//	Are Neighbors?
			//		off by exactly one in EITHER row OR column
			//
			//	Use if/else-if to ease debugging of each axis indivisually
			//
			if (_model.SelectedGemVO.RowIndex == gemVO.RowIndex &&
			    Mathf.Abs (_model.SelectedGemVO.ColumnIndex - gemVO.ColumnIndex) == 1)
			{
				isGemVOSwappableWithSelectedGemVO = true;
			}
			else if (_model.SelectedGemVO.ColumnIndex == gemVO.ColumnIndex &&
			         Mathf.Abs (_model.SelectedGemVO.RowIndex - gemVO.RowIndex) == 1) 
			{
				isGemVOSwappableWithSelectedGemVO = true;
			}
			
			return isGemVOSwappableWithSelectedGemVO;
		}
		
		
		/// <summary>
		/// _s the get gem view for gem vo.
		/// </summary>
		private GemView _GetGemViewForGemVo (GemVO gemVO)
		{
			GemView gemViewFound = null;
			foreach (GemView gemView in _gemViews)
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
		private void _SwapTwoGemVOs (GemVO gemVO1, GemVO gemVO2)
		{
			int rowIndex = gemVO1.RowIndex;
			int columnIndex = gemVO1.ColumnIndex;
			//
			gemVO1.RowIndex = gemVO2.RowIndex;
			gemVO1.ColumnIndex = gemVO2.ColumnIndex;
			_GetGemViewForGemVo (gemVO1).TweenToNewPosition();
			//
			gemVO2.RowIndex = rowIndex;
			gemVO2.ColumnIndex = columnIndex;
			_GetGemViewForGemVo (gemVO2).TweenToNewPosition();
		}

		/// <summary>
		/// Reward one match.
		/// </summary>
		private void _RewardOneMatch (List<GemView> gemViewsInOneMatch)
		{
			//	TODO: find center point of all 3+ gems
			Debug.Log ("ok: " + gemViewsInOneMatch.Count);
			Debug.Log ("ok: " + gemViewsInOneMatch[1]);
			Vector3 centerPointOfMatch_vector3 = gemViewsInOneMatch[0].gameObject.transform.localPosition;

			//	CREATE AND REPARENT
			_hudView.RewardOneMatch (999, centerPointOfMatch_vector3, new Vector3 (0,0, centerPointOfMatch_vector3.z));


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
		}
		
		/// <summary>
		/// _s the on score changed.
		/// </summary>
		private void _OnScoreChanged (int score)
		{
			
		}
		
		/// <summary>
		/// _s the on gem clicked.
		/// </summary>
		/// <param name="gemView">Gem view.</param>
		private void _OnGemViewClicked (GemView gemView)
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
			else if (_IsGemVOSwappableWithSelectedGemVO (gemView.GemVO))
			{


				//	TODO: Move this based on model input NOT here in the view
				List<GemView> gemViewsInOneMatch = new List<GemView>();
				Debug.Log ("tt: " + _model.SelectedGemVO);
				Debug.Log ("tt: " + _GetGemViewForGemVo (_model.SelectedGemVO));
				gemViewsInOneMatch.Add (_GetGemViewForGemVo (_model.SelectedGemVO));
				gemViewsInOneMatch.Add (gemView);
				_RewardOneMatch (gemViewsInOneMatch);

				//	3. SWAP FIRST & SECOND GEM IN A PAIR
				_SwapTwoGemVOs (_model.SelectedGemVO, gemView.GemVO);
				_controller.SelectedGemVO = null;

			}
			else 
			{
				//	4. DESELECTED ALL
				_controller.SelectedGemVO = null;
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
				foreach (GemView gemView in _gemViews)
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
		private void _OnGemVOsMarkedForDeletionChanged (List<GemVO> gemVOs)
		{

			//	1. deselect all
			foreach (GemView gemView in _gemViews)
			{
				
				gemView.SetIsHighlighted (false);
			}

			//	2. select some
			foreach (GemVO gemVO in gemVOs)
			{
				
				_GetGemViewForGemVo(gemVO).SetIsHighlighted (true);
			}
		}
		


	}
}

