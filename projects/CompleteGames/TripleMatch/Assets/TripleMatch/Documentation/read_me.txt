/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com               
 */
// Marks the right margin of code ************************************************************************************

//--------------------------------------------------------------------------------------------------------------------
//  OVERVIEW
//--------------------------------------------------------------------------------------------------------------------
• The 'Triple Match' game is complete
• Target resolution is 755 x 600.
* Playing? Entry point is the Scene "TripleMatchFullGame.unity"
* CodeReview? Entry point is the class ("com.rmc.projects.triple_match.mvc.TripleMatchCore.cs").

//--------------------------------------------------------------------------------------------------------------------
//  CODE OWNERSHIP
//--------------------------------------------------------------------------------------------------------------------
• Folder (/Assets/TripleMatch/) - All code is by Sam Rivello. Created from scratch for this project.
• Folder (/Assets/TripleMatch/) - All non-code (assets) were given by assigner or found by Sam Rivello
• Folder (/Assets/Standard Assets/) - All contents provided by Unity Technologies via Asset Store
• Folder (/Assets/Community Assets/) - All contents provided by 3rd Parties via Asset Store

//--------------------------------------------------------------------------------------------------------------------
//  FEATURES REQUIRED: By Assigners' Documentation
//--------------------------------------------------------------------------------------------------------------------
--
• 8x8 grid of objects - [Sam: Done!]
• The objects can swap place [Sam: Done!]
• If Swap makes no matches, reverse the swap. [Sam: Done!]
• Match is 3 or more horizontal or vertical. Remove matches & new objects fall from top [Sam: Done!]
--
• 1 minute long [Sam: Done!]
• 5 colours [Sam: Done!]
• Drag or click objects to swap [Sam: Done, via click.!]
• Use a game like Midas Miner for reference (www.king.com) [Sam: Done!]
--
• Submitting: Please send the test back as a .zip file or package to a Google doc link, [Sam: Done!]
• Timeframe: Complete in 7 days, or request time via email. [Sam: Done! I requested 8 days (Dec 20 to 28, 2014)]

//--------------------------------------------------------------------------------------------------------------------
//  FEATURES NOT-REQUIRED: Added For Fun
//--------------------------------------------------------------------------------------------------------------------
• Added: MVC (Model-View-Controller) framework. I created it as a playful, custom architecture for prototyping   :)
• Added: MVC Project Diagram in Folder (/Assets/TripleMatch/Documentation/). I call it "Loose MVC"   :)
• Added: Particle effects added
• Added: Sound effects added
• Added: Unity 4.3.x Sprites for all gameplay elements 
• Added: Unity 4.6.x 'New' Unity UI for all GUI elements 
• Added: Suspensful visual 'timer' of fuse, dynamite explosion 
• Added: Dynamic Instruction Text for better UX and to tease user's personal 'high score'
• Added: Ex. UnitTest. Open Unity->Menu->UnityTesting->UnitTestRunner! (See 'com.rmc.core.grid_system.GridSystemTest.cs')
• Added: Centralized text, settings, animation durations,... (See 'com.rmc.projects.triple_match.TripleMatchConstants.cs')
• Added: 
• Added: 
• Added: 
• Added: 
• Added: 



//--------------------------------------------------------------------------------------------------------------------
//  TODO: Before Submission
//--------------------------------------------------------------------------------------------------------------------
* Change all model delegates to consistent form of OnGemAdded(), OnGemPositionUpdated(), OnGemRemoved...
* Change GridSpotVO to iGridSpotVO interface. Nice! Remove 'gemtype' or not since it depends on the view (vice versa?)
* Vector3 centerPointOfMatch_vector3 = gemViews[0].gameObject.transform.position;

// DO THIS LAST
If you click reset and DO NOT have any matches automatically on the fresh board (happens rarely) then the gems are not clickable. That is a bug I will fix.
If you click reset and DO NOT have any matches automatically on the fresh board (happens rarely) then the gems are not clickable. That is a bug I will fix.
If you click reset and DO NOT have any matches automatically on the fresh board (happens rarely) then the gems are not clickable. That is a bug I will fix.
If you click reset and DO NOT have any matches automatically on the fresh board (happens rarely) then the gems are not clickable. That is a bug I will fix.
* initialize everything in start (not in declaration). Is that a good readability upgrade?
* add comment to every class. Fit within 3 lines of overview; model, view, controller
* Revisit all commented out Debug.log statements. Keep some? Wrap some in a special debug log? Remove all? TBD
* Update 100% of comments
* Move all ‘usings’ to the // IMPORT section (some are a few lines below
* Remove 100% of warnings and errors
* Update diagram
* Folder (/Assets/TripleMatch/Documentation/) includes simple 2-minute overview of gameplay and gamecode.
• Added: Dynamic Instruction Text for better UX and to tease user's personal 'high score'

//--------------------------------------------------------------------------------------------------------------------
//  TODO: Theoretical Future-Features That Are Not Yet Added 
//--------------------------------------------------------------------------------------------------------------------
* Production: Replace 100% of art. Just to revisit the views flexibility to handle different size, layouts, (# of gemtypes), etc...
* View: Handle common screen layouts (iPhone 6, 4, etc...) without simply resizing gracefully as currently happens.
* Gameplay: Show a hint to user of what match is best to make next
* Gameplay: End the game if there are no possible matches that can be made via swap
* Gameplay: Add a 'combo meter' that drains slowly, but gains with each match made. A 100% meter will reward bonus for next matches
* Optimization: Use 'pooling' to create between 64 and 128 Gem prefab instances upon game-start for reuse.


