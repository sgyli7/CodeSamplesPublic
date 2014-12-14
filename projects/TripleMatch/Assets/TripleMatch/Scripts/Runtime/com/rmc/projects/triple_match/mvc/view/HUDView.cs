using UnityEngine;
using UnityEngine.UI;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;


namespace com.rmc.projects.triple_match.view
{


	public class HUDView : AbstractView
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
			_model.OnScoreChanged += _OnScoreChanged;
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
			_model.OnScoreChanged -= _OnScoreChanged;
		}


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

		/// <summary>
		/// Raises the game reset button clicked event.
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
