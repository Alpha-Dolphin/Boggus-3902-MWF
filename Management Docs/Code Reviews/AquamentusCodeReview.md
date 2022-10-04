Author: Aubert Li
Date: 10/3/22
Sprint#: 0
File Reviewed: ./Tools/EnemyObjects/Aquamentus.cs
File Author: Ben Elleman
Time Taken For Review: 25 Minutes

Readability:

	Good in readability, most of the code is clear on what exactly it's doing. The comments about the
	different update functions help a lot with understanding.

	The only bit of confusion was about what the different balls in the class are for. On this note,
	there were a few typos in the names of the variables, notably one spelling Aquamentus as Aquementus.


Code Quality:

	In terms of coupling this class does an okay job, coupling itself with GameTime, Game1, and SpriteBatch
	is mostly unavoidable but using global variables isn't always the best option. I will say that it seems 
	weird that the class does not contain a sprite but rather draws itself directly using SpriteBatch. I 
	think it would be better to use abstraction and hide the drawing/sprite aspect of the enemy in a separate class.

	The reusability is also limited by the handling of sprites and drawing, however this isn't too much of a 
	concern since the enemies themselves are very specific. The use of the Enemy interface is good to abstract
	logic away from Game1.

Conclusion:

	This class is okay, there aren't any huge causes for concern and will need some revamping to function as 
	a real boss in the game. I would argue that the changes needed are more due to the structure of the sprints.
	Overall good job adding random elements to the dragon AI and functions properly.