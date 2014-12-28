/**
 * Copyright (C) 2005-2015 by Rivello Multimedia Consulting (RMC).                    
 * code [at] RivelloMultimediaConsulting [dot] com               
 */
// Marks the right margin of code ************************************************************************************



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
• Added: Ex. UnitTest ('com.rmc.core.grid_system.GridSystemTest.cs'). Open Unity->Menu->UnityTesting->UnitTestRunner!


//--------------------------------------------------------------------------------------------------------------------
//  CODE OWNERSHIP
//--------------------------------------------------------------------------------------------------------------------
* Folder (/Assets/TripleMatch/) - All code is by Sam Rivello 
* Folder (/Assets/TripleMatch/) - All non-code (assets) were given by assigner or found by Sam Rivello
* Folder (/Assets/Standard Assets/) - All contents provided by Unity Technologies via Asset Store
* Folder (/Assets/Community Assets/) - All contents provided by 3rd Parties via Asset Store

//--------------------------------------------------------------------------------------------------------------------
//  TODO: Before Submission
//--------------------------------------------------------------------------------------------------------------------

* Change all model delegates to consistent form of OnGemAdded(), OnGemPositionUpdated(), OnGemRemoved...
* Change GridSpotVO to iGridSpotVO interface. Nice! Remove 'gemtype' or not since it depends on the view (vice versa?)
* use maxrows/maxcolums ONLY when creting grid. otherwise use getlength()
* show users all time high score
* make a 'bonk' noise if you click a gem but the gem cannot accept a move (like when the matches are blowing up)

// DO THIS LAST
* initialize everything in start (not in declaration). Is that a good readability upgrade?
* add comment to every class. Fit within 3 lines of overview; model, view, controller
* Revisit all commented out Debug.log statements. Keep some? Wrap some in a special debug log? Remove all? TBD
* Update 100% of comments
* Move all ‘usings’ to the // IMPORT section (some are a few lines below
* Remove 100% of warnings and errors
* Update diagram
* Folder (/Assets/TripleMatch/Documentation/) includes simple 2-minute overview of gameplay and gamecode.

//--------------------------------------------------------------------------------------------------------------------
//  TODO: Theoretical Future-Features That Are Not Yet Added 
//--------------------------------------------------------------------------------------------------------------------
* Replace 100% of art. Just to revisit the views flexibliity to handle different size, layouts, (# of gemtypes), etc...
* Show a hint to user of what match is best to make next
* End the game if there are no possible matches that can be made via swap
* Optimization: Use 'pooling' to create between 64 and 128 Gem prefab instances upon game-start for reuse.


