
using System;
using UnityEngine;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;

namespace com.rmc.projects.triple_match.view
{
	public abstract class AbstractView : MonoBehaviour
	{

		protected Model _model;
		protected Controller _controller;

		virtual public void Initialize (Model model, Controller controller)
		{
			_model = model;
			_controller = controller;
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		virtual protected void Start () 
		{
			
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		virtual protected void Update () 
		{
			
		}

		/// <summary>
		/// Raises the destroy event.
		/// </summary>
		virtual protected void OnDestroy () 
		{
			
		}

	}
}

