using UnityEngine;
using UnityEngine.UI;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;
using com.rmc.projects.triple_match.model.data;

namespace com.rmc.projects.triple_match.view
{
	
	
	public class EnvironmentView : AbstractView
	{
		
		[SerializeField]
		public GameObject _gemsParent;
		
		
		/// <summary>
		/// Start this instance.
		/// </summary>
		override protected void Start () 
		{
			
		}
		
		
		override public void Initialize (Model model, Controller controller)
		{
			base.Initialize (model, controller);
			
			_model.OnGameResetted += _OnGameResetted;
		}
		
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		override protected void Update () 
		{
			
		}
		
		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		override protected void OnDestroy () 
		{
			_model.OnGameResetted -= _OnGameResetted;
		}
		
		
		/// <summary>
		/// _renders the title text.
		/// </summary>
		private void _RenderGems (GemVO[,] gemVOs)
		{

			GemVO nextGemVO;
			GameObject nextGemViewPrefab;
			GemView nextGemView;
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
					nextGemView.Initialize (nextGemVO);
				}
			}


		}
		
		/// <summary>
		/// _ons the game resetted.
		/// </summary>
		private void _OnGameResetted ()
		{
			
			Debug.Log ("Env: Resetted");
			
			//	RENDER
			_RenderGems (_model.GemVOs);
		}
		
		/// <summary>
		/// _s the on score changed.
		/// </summary>
		private void _OnScoreChanged (int score)
		{
			
		}
	}
	
}
