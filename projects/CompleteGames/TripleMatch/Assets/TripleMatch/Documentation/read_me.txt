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



//------------------------------------------------------------------------------
//  FEATURES REQUIRED: By Documentation
//------------------------------------------------------------------------------




//------------------------------------------------------------------------------
//  FEATURES NOT-REQUIRED: Added For Fun
//------------------------------------------------------------------------------


//------------------------------------------------------------------------------
//  CODE OWNERSHIP
//------------------------------------------------------------------------------
* Folder (/Assets/TripleMatch/) - All code is by Sam Rivello 
* Folder (/Assets/TripleMatch/) - All non-code (assets) were given by assigner or found by Sam Rivello
* Folder (/Assets/Standard Assets/) - Code provided by Unity Technologies
* Folder (/Assets/Standard Assets/) - Code provided by Unity Technologies

//------------------------------------------------------------------------------
//  TODO: Before Submission
//------------------------------------------------------------------------------

* Change all model delegates to consistent form of OnGemAdded(), OnGemPositionUpdated(), OnGemRemoved...
* remove pooling library or not?
* Revisit all commented out Debug.log statements. Keep some? Wrap some in a special debug log? Remove all? TBD
* fix the 'prevent matches upon reset game' functionality
* add comment to every class. Fit within 3 lines of overview; model, view, controller
* initialize everything in start (not in declaration). Is that a good readability upgrade?
* Remove 'gem' from grid system naming/comments
* Change GridSpotVO to iGridSpotVO interface. Nice! Remove 'gemtype' or not since it depends on the view (vice versa?)
* use maxrows/maxcolums ONLY when creting grid. otherwise use getlength()
* show users all time high score
* make a 'bonk' noise if you click a gem but the gem cannot accept a move (like when the matches are blowing up)

// DO THIS LAST
* Update 100% of comments
* Move all ‘usings’ to the // IMPORT section (some are a few lines below
* Remove 100% of warnings and errors
* Update diagram


//------------------------------------------------------------------------------
//  TODO: Theoretical Future-Features That Are Not Yet Added 
//------------------------------------------------------------------------------
* Replace 100% of art. Just to revisit the views flexibliity to handle different size, shapes, layouts, (# of gemtypes), etc...
* Show a hint to user of what match is best to make next
* End the game if there are no possible matches that can be made via swap
* Optimization: Use 'pooling' to create between 64 and 128 Gem prefab instances upon game-start and then never create/destroy more.


