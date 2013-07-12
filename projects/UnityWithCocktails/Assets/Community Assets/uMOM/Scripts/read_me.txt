/**
 * Copyright (C) 2005-2013 by Rivello Multimedia Consulting (RMC).                    
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


************************
** TODO
************************

* allow MULTIPLE selection in project to convert to scriptable assets

* consider adding "[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]"

* REMOVE or have optional WORKAROUNDS for all iphone-bad code. no delegates, no generics

* do really good cleanup on OnApplicationQuit. Since (some) RAM persists from play/edit mode, its FAR MORE important than flash to clean up.

* currently the MOM editor is really coupled to PROJECT (i.e. enabled?) not each scene. I think that is good. Right?

* add unit testing (and learn unit testing for unity)

************************
** POSSIBLE MANAGERS TO CREATE (ME OR OTHER PEOPLE)
************************

MORE UNIVERSAL

* AspectManager: when initialized, gets the current screen size, then calculates and stores all size-dependent properties. Also sets the textures resolution, depending on the screen’s pixels. All GUI related code relies heavily on it to know where to place stuff, allowing for a liquid layout that will fit any existing display.
* Notificator: all event dispatching goes through this singleton. This way, listening to an event simply consists of linking to a Notificator event. Maintaining a single global event dispatcher can be a little tricky, but if you do it correctly it is very powerful, and allows total separation of objects (since objects don’t need to be conscious of each other to access specific events).
* LevelManager: each time a new scene/level is loaded, this manager detects its level-specific configuration, and sets it.
* SaveManager: takes care of saving and loading user preferences and achievements. Relies on the wonderfully straightforward Easy Save 2 for its internal methods.
* SoundManager: caches all sounds. Playing a sound when needed simply consists in calling SoundManager.Play(SoundEnumValue).
* ThreadingMananger: ease the use of coroutines and invokes. 

MORE PROJECT-SPECIFIC
* MenuManager: controls all menus, managing their animations, their contents, and their behaviors.
* ScoreManager: keeps track of all the scores and stars, with methods that let me quickly get single level as well as world scores, and compare them with older ones.
* GameManager: the core of the engine. As soon as its one-time initialization takes place, it loads the basic game settings (set via Journeyballs in-editor panels) and the user-specific data (via the SaveManager). After that, any other object can just query it to know game-specific settings to apply.




