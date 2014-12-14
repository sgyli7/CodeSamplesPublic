using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.rmc.projects.triple_match.model;
using com.rmc.projects.triple_match.controller;
using com.rmc.projects.triple_match.view;

public class TripleMatchCore : MonoBehaviour 
{


	[SerializeField]
	private List<AbstractView> _abstractViews;



	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		Model.Instantiate();
		Controller.Instantiate();
	}


	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () 
	{
	
	}
}
