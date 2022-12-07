Current State: Sprint 4 functionality almost entirely implemented.

Key mappings
	
	LINK:
	WASD/Arrow keys for link. 1, 2, 3, 4, and 5 for link's items. Z and N to swing the sword.
	E to simulate taking damage.
	X to use special weapon.

	GAME:
	Left click to advance room, right click to go back a room.
	Q to quit game.
	P to Pause.
	R to restart the game when in state of win, pause or game over, 
	Escape to open inventory and see a more detailed map.
	
Refactoring:
	Link: Took out all projectile information into a different LinkProjectiles class to make Link shorter.
	LinkConstants: Renamed into PlayerConstants to fit with the rest of the format, grouped up constants related to each other to make it easier to find information.
	Interfaces split to separate files


Link to Sprint reflection(2 and 3): 
https://docs.google.com/document/d/1mNnZDQ94atO60pZl9hHuoXX9RfT58vaueJyTJLCh6hU/edit?usp=sharing
