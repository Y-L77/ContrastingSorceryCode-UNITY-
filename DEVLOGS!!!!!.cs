using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script contains devlog comments documenting the development process.
/// </summary>
public class Devlogs : MonoBehaviour
{

}
//PRINCIPALS:
//for making new spells, please do the following
//copy paste fireballDestroy script as the child of the prefab
//make the tag of the unity spell UI the spell name and then make the logic in spellcasting script in the switch part
//need to create button function in the buyspells



//2024-07-02
//im making devlogs to organize my thoughts better. today I fixed an inventory glitch where all the children of the inventory UI would trigger the openinventoryscript and close the UI.
//I made this functionality by removing the children components out of the button so they wouldn't registed and continue the reference method in the openinv script to keep the regular functionality without the bug.
//now I'm going to make UIs like health and coins.
//i've created the health ui and it has 3 health, now i will make the coins and player event system gameobject script handler so i can go in, reference the health ui and make a integer variable for playerHealth. <--- (I've learned that you should use camelCase for naming variables, methods and more.)
//I've created the healthbar and coin UI and now I need to create coins for the UI to update and then the coin number text script will take the value of the coins in the script from the game logic scripts gameobject and transfer it into text.
//I'm going to stop for today, I'm pretty happy with the quality of work i outputted but I can definentely do more. Good luck future me please make sick ass game and upload to a company11!!!1

//2024/07/04
//i added the coin game logic and the coin UI updater and I also fixed the z layer fighting between the inventory UIs and the health & coin ui.
//i worked on the buyspells script, originally it was only buyFireball but i made it more modular so it can handle all spells in the future.
//coins now work, created a warning sign when you don't have enough money.
//tomorrow I'll need to make the function in the buySpells things to make it so that when I do have the money and click the button I actually get the spell and then i need to make a function to choose whether I want it in left or right side.

//2024/07/08
//I'm going to maker tje get spell logic now!!! I'm going to make the Q and E spells seperate exclusively with a text
//I want to make a game theme like maybe the q ability is hot fire and the E ability is cold tundra ill think of something after I make the spell logic
//im not sure but I think that the fireball_spell is the tag i put on the spell prefab to register damage on entities (yes i checked i believe this is how it works)
//add function to deactivate all other children of the spell UI when i equip something else and then when I have 2 spells I need to make a equip function for already bought spells
//the buy button was in the locked fireball and when i made the locked fireball disappear i can't buy it anymore so I accidentally saved myself some work. in the future I'll need to add a button to the unlocked fireball so I can re-equip.

//2024/07/09
//I need to make sure that the button logic, switching spells, buying spells all work flawlessly and able to be modular enough for me to add as many spells as I want
//I might not do it today but I also need to create a home screen for the play and controls menu
//I created the icicle spell UI with the tag "icicle", I need to run that through the spellcasting script in the switch and make sure it's working because it isn't enumerated.
//don't forget to reference prefab inside of the wizard gameobject which holds the spellcastingscript
//I made the icicle spell now I need to put it in the shop
//this confused me when making the icicle shop function, i have 2 gameobjects named the same thing, when referencing the spellUI put the gameobject that is the child of the utilityUIs

//2024/07/10
//I'm going to make another spell which is necromancy and I'm going to make it pretty strong
//I'm putting the necromancy spell logic (some of it) in the necromancyDestroy script because global calls and instiantion is confusing.
//I've created the spell logic for the necromancy spell but I haven't made the shop logic.
//I'm working on overhaulign the shop UI logic, remember the spellUI (not spellUILocked or spellUIUnlocked) is the one that activates the spell in the utility UI which makes it fire.
//I will make it so i can unlock it and then equip it and only one thing can be equipped.

//2024/07/11
//I'm working on the shop UI and I'm going to make the spells equip and unequip.
//I deleted this line, GameObject necromancy = GameObject.FindGameObjectWithTag("necromancy_spell"); because I don't know what it does and the script works without it
//I'm going to create the equip script logic in the spellOptions gameobject because it makes sense and the fireball gameobject script is getting too full
//After this im going to make healthbar into a real integer number and then I'm going to make another script in the gamelogic script, create a text object, put it near the bottom of the screen and everytime you kill a monster you get either more hp or more coins and it will pop up Enemy Slain! + 25coins on your screen.
//in the future for adding more spells for the equip, just make a button, drag the spellOptions object, the object that holds the script into the object place and find the function for the spell

//2024/07/12
//work on the dungeon agent dialogue and UI later
//right now I'm going to make the map better and bigger then more interactive later e.g ladders, jump orb, spikes, more
//I also created dragon spell today I forgot to document in the morning.
//After I make the map bigger and more interactive (put interactive maps inside of the map gameobject folder) I'll make a more advanced enemy AI
//Then I'll make dungeon and for the 5-7 dungeon I might give 10 free runs but then 0.05 cents per run for 1 pass and you can buy multiple passes. you can also get free passes from rare drop and then make a pass GUI in the agent dungeon select UI.
//my tilemaps have a rendering issue and a offset issue. if it doesn't work by tomorrow i will delete the entire thing and find a new tilemap.

//2024/07/13
//next time i work on this game i need to splice the tilemaps all 16x16

//2024/07/14
//I'm working on the map right now I think I'm going to do the health logic today and maybe make spikes
//when health goes to zero make player respawn at spawn location, then make a spawn location
//the gameplay loop will be get strong enough and get enough hearts for dungeons > dungeons > go to locked rooms, unlocl the locked rooms for money and fight bosses. hard bosses and hard dungeon bosses will give money.
//i finished the health logic
//i will try to use some particles now
//next i will make enemy ai and homesecreen, include restart screen and how to play screen

//2024/07/15
//I make enemy ai now
//i created ui that scales with the screen
//i made more particles
//i added a blinking animation to the player
//im working on enemy ai even further and i'm going to make a player take damage soon and once ill probably copy paste the enemy take damage and make it do a >.< face animation on hit.
//tomorrow work on the player taking damage ai and also make a spawner

//2024/07/16
//working on player taking damage and further enemy ai now
//when making another enemy put the enemyai script inside of it and don't change anything. add another script if you want it to have more functionality
//damage taking and enemy spawns work great. don't forget to not change the enemy ai script and spawner script.
//next time work on making the game better and less buggy e.g fixing tilemap ground collisions, sound, animations, making the mobs hit registration better, adding sky, adding map movement, adding interactable map features.
//create spells that can change movement like double jump pulse spell

//2024/07/17
//btw the dates on these since ive been in vancouver were extended by 1 day beacuse my pc has china time or something but wont matter too much
//I'm going to make a spell called shadow step, it teleports the player a few blocks forward with a woosh sound effect and then it will leave a shadow figure of the player which will explode in a few seconds.
//I will implement this by making a prefab of the shadow figure which explodes by expanding in size, releasing particles that will do damage, putting the prefab in the spellcastingscript and adding player teleporting like 5 blocks forward logic in the castShadowStep
//I created the shadow spell and it works great! i need to add even more movements next and i need to make mobs better.

//2024/07/18
//i will fix enemy ai damage hitting script and i will make a new enemy called warrior
//yipppeee i made the enemy and it very easy to make, now im going to focus on game feel and map!!

//2024/07/20
//im going to make dungeon and make game feel better
//I'm planning on making 1-7 buttons in the dungeon menu, 6-7 being red because you need a lot of coins to buy the access. put a small descreption of text to the right of the button like very hard! do not enter
//in the dungeon when you complete it at the end there will be a chest with loot and at the entrance of the dungeon the background will have a carving of the possible loot you can get like 70% chance gold, 20% hearts and 10% spell
//I changed my mind i think ill only have 4 or 5 dungeons.

//2024/07/21
//i made the dungeon menu ui better and im only adding 3 for now
//im making a boss for the overworld and i think ill be finished up with the overworld soon
//for the dungeon im going to make the dungeon very detailed and the enemies will have actual good animations
//after that ill make a starting screen and saving data method
//after that ill polish up the game, make the overworld and gamefeel better than start uploading and advertising.
//just put the date you completed the thing next to the list e.g make map bigger || COMPLETED 2024/07/24
//this is a list of things ill need to do before uploading (cs sugar operation) DUE BEFORE 30TH
//ILL MAKE THE DUNGEON SPELL A BLOOD THEME SPELL THAT TAKES YOUR HEARTS FOR A SUPER STRONG SPELL

/*
-make animation for the wizard when it gets hit
-(COMPLETE) make healthbar go down when it gets hit 2024/07/24 COMPLETE!!!!
-(COMPLETE) make map bigger 2024/07/23 COMPLETE!!!!
-(COMPLETE) make more mobs for easy farming (4 mud arms, 3 skeletons, 2 reapers) 2024/07/23 COMPLETE!!!!
-make background scale when you jump
-make 3 more spells, 2 on the first inventory screen, then add a next button for a next page and then the next page another spell that says ??? which can be unlocked from a dungeon
-for the dungeon spell make it so if(dungeon boss killed) spellunlocked = true; which you can reference in the buySpells script located in the fireball in the UIS. when the boss is killed give like +125 hp to the player and also when the boss is killed reference the enemykilled text in the UIS and make it say "spell unlocked! "spellname"".
-(COMPLETE) another spell should be healing yourself and a double jump which you can double jump in the air whilst healing yourself 2024/07/24 COMPLETE!!!! (i did this at 1am so basically 23rd but technically 24th)
-another spell should be one that has good animation.



-when making dungeons make it so there will be no wasted rendering so the game doesn't lag, all the mobs should spawn together without a spawner when the player enters the dungeon and they should all despawn when the player dies


-
*/