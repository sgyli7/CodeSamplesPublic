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
		public Text _titleText;
		
		[SerializeField]
		public Text _scoreText;
		
		[SerializeField]
		public Text _gameResetText;
		
		
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
