
//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System.Collections;
using com.rmc.events;

//--------------------------------------
//  Class
//--------------------------------------
public class TestEventDispatcher : MonoBehaviour
{
	
	//--------------------------------------
	//  Properties
	//--------------------------------------
	// PRIVATE
	private EventDispatcher eventDispatcher;
	
	//--------------------------------------
	//  Methods
	//--------------------------------------		
	
	// PUBLIC
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{

		//CREATE
		eventDispatcher = new EventDispatcher (this);

		//ADD 0, 1, 2, OR MORE LISTENERS...
		eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent1); //default is EventDispatcherAddMode.DEFAULT
		eventDispatcher.addEventListener 			(TestEvent.TEST_EVENT_NAME, _onCustomEvent2, EventDispatcherAddMode.SINGLE_SHOT);
		
		//TEST REMOVE
		//eventDispatcher.removeAllEventListeners();
		//eventDispatcher.removeEventListener (TestEvent.TEST_EVENT_NAME, _onCustomEvent1);
		
		//TEST HAS
		//Debug.Log ("	hasEventListener(): " + 	eventDispatcher.hasEventListener 	(TestEvent.TEST_EVENT_NAME, _onCustomEvent1));
		
		//TEST EVENT SETUP FROM 3 DIFFERENT SCOPES
		eventDispatcher.dispatchEvent (new TestEvent (TestEvent.TEST_EVENT_NAME));

	}
	
	//--------------------------------------
	//  Events
	//--------------------------------------
	public void _onCustomEvent1 (IEvent iEvent) 
	{
		Debug.Log ("	1. _onCustomEvent1(): " + iEvent);
	}
	
	public void _onCustomEvent2 (IEvent iEvent) 
	{
		Debug.Log ("	2. _onCustomEvent2(): " + iEvent);
	}
	
	
}





