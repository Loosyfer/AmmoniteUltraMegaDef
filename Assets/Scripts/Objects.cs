using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "My Game/Objects")]
public class Objects : ScriptableObject
{

    public Sprite[] sprites = new Sprite[166];

    public string[] names = new string[166]
    {
        "Lobster Claw",
"Shell Shield",
"Treasure",
"Anchor",
"Bombs",
"Pirate Prosthetic Hook",
"Poisonous Seaweed",
"Drowned Islander",
"Octo Ink Sack",
"Hallucinogenic Anemone",
"Antifreeze",
"Sponge",
"Tasty Fish Meal",
"Butchers Knife",
"Ancient Coins",
"Explosive Vest",
"Juicy Bait",
"Disgusting Residue",
"Barrel of Apples",
"Box of Chocolates",
"Nappies",
"Game Console",
"Soap",
"Monkey Pet",
"Steroids",
"Treadmill",
"Anti-stress Ball",
"Doctor Kit",
"Antidote",
"Fishing Rod",
"Surprise Gift",
"Enhancement Microchip",
"Cursed Vase",
"Lifebuoy",
"Telescope",
"Message in a Bottle",
"Treasure Map",
"Hip Flask",
"Golden Tooth",
"Goggles",
"Expired Sushi",
"Old Pistol",
"Ancient Volume of Wisdom",
"Pearl",
"Lost Page",
"Summoning Rune",
"Human Skeleton",
"Energy Drink",
"Scalpel",
"Vitamin Supplements",
"Protein Powder",
"Comfy Pillow",
"Magic Wand",
"Float",
"Bean and Cabbage Soup",
"Heavy Dumbbells",
"Gunpowder",
"Batteries",
"Toaster",
"Blood Bag",
"Pack of Cigarettes",
"Dung Beetle",
"Tool Kit",
"Medicinal Herb",
"University Diploma",
"Sacrificial Katana",
"Love Letter",
"Suspicious Magazines",
"Lucky Pants",
"Saw-in-half Box",
"Violin of Death",
"Sack of Cement",
"Starfish Shurikens",
"Harp of Harmony",
"Ultra-sensory Blindfold",
"Cuddly Teddy Bear",
"Blood Curse",
"Penetrating Maggots",
"Pendant of Cursed Water",
"Notice of Termination",
"Salary Increase",
"Electric Toolkit",
"Delicate Scorpion Tank",
"Recipe Book",
"Bucket",
"Reckless Enhancer",
"Glue",
"Cup of Hot Coffee",
"Irresistible Nectar",
"Holiday Tickets",
"Military Propaganda",
"Pipe and Monocle",
"Mindless Juice",
"Uncomfortable Chair",
"Stinky Poo",
"Shoddy Toilet",
"Malevolent Mask",
"Precious Ring",
"Fossil",
"Maracas of Insanity",
"Make-a-submarine Kit",
"Magic Trousers",
"Vampire Fangs",
"Lifesteal Dagger",
"Mind Controller",
"Teleport Pads",
"Umbilical Cord",
"Mutational Gills",
"Leading Drums",
"Egg",
"Ticking Time Bomb",
"Flaming Bag of Poop",
"Jar of Farts",
"Fire Extinguisher",
"Harmless Brain Parasite",
"Possessing Brain Parasite",
"Time Machine",
"Hacking Peripheral",
"Crystal Ball",
"Item Magnet",
"3D Printer",
"Lobster Tank",
"Superhero Cape",
"Acid Lemons",
"Ship in a Bottle",
"Frozen Explorer",
"Rubik Cube",
"Shopping Bag",
"Brain-enhancing Parasite",
"Little Oyster",
"Corrupted Pearl",
"Enchanted Shoes",
"Itelligence Reverser",
"Extra Brain",
"Marine Disguise",
"Devil�s Pact",
"Brainwasher",
"Dumb Potion",
"Welcome Mat",
"Little Robohelper",
"Personal Diary",
"Slot Machine",
"Football",
"Comfy Bed",
"Water Tap",
"Freezer",
"Lighter",
"Garden Shears",
"Tasty Pizza",
"Wood",
"Fertiliser",
"Module Repair Kit",
"Webcam",
"Christmas Tree",
"Whip",
"Deck of Magic Cards",
"Book of the Dead",
"Normal Pills",
"Dangerous Chainsword",
"Chamber Pot",
"Pen and Paper",
"Waste Converter",
"Sacrificial Altar",
"Impossibly Stacked Stones",
"Most Loyal Companion",
"Donation Jar"


    };

    public string[] description = new string[166]
    {

        "When hit, the crew member will pinch the enemy for 50 damage.",
"Protects the crew member from enemy hit damage, but after each hit there�s a 33% chance it breaks.",
"If equipped, it opens at the end of 2 battles and grants 2 random items.",
"The crew member cannot be moved from this module in battle.",
"If hit, there�s a 50% chance of -1 HP and dealing 100 damage to the enemy.",
"Only works when not full HP. If hit by the enemy, there�s a high chance they hit the same module again. For every hit, 50% chance you receive a Tasty Fish Meal.",
"The crew member becomes Poisoned, but so does the enemy if it hits them.",
"The crew member becomes Sick, but if they�re a Doctor or Scientist, after 2 battles the islander becomes a random crew member.",
"Once per battle, if the crew member gets hit and the ship has an empty module, they avoid the hit and move to the nearest empty module.",
"The crew member will have a random trait every battle.",
"Prevents the module from freezing.",
"Fixes any flooding in the module after 4 turns.",
"+1HP, single use.",
"When hit by the enemy, deal 50 damage and produce one Tasty Fish Meal.",
"Can be sold at the shop for 200, 300, 400 or 500 coins, decided at random.",
"When hit by the enemy, 33% chance the module explodes and you deal 500 damage.",
"Often attracts attacks from the enemy.",
"Enemies avoid hitting the residue, but it also makes the crew member Sick.",
"+1HP/4turns, but there�s a 20% chance of -1HP and becoming Sick.",
"+1HP, but the crew member becomes Glutton.",
"Prevents the module from becoming Excrement-flooded.",
"-30% performance.",
"If the module is flooded, +1HP and cures/prevents Sick.",
"Every battle, 50% chance of +30% performance and 50% chance of -30% performance.",
"Every battle, +1HP and +10% Performance, but it only lasts for 3 battles, after which the crew member will have 3 max HP.",
"Every 2 battles, +1HP and +5% Performance to the crew member in it.",
"Prevents its holder from becoming Lunatic.",
"+1HP and cures Poisoned and Sick, single use.",
"Cures Poisoned and Sick, single use.",
"When the module is flooded, 50% chance you get a Tasty Fish Meal by the end of the battle.",
"Can be any item, only known after it�s equipped and the battle starts.",
"+30% performance, but if the module is flooded, the crew member will lose 3 HP from an electric shock and the item is destroyed.",
"Every battle, the crew member will have a random Ailment.",
"If another crew member dies, there�s a 50% chance they�re rescued from the water with 1HP, single use.",
"If the holder is in the first column of the layout, see what type of enemy lures in an adjacent map node.",
"At the end of the battle, reveals a nearby stranded crew member in the Node Map, who might be dead or alive and joins your crew (50% chance for each), single use.",
"At the end of each battle, it has a 33% chance of revealing a nearby Guarded Treasure or Dangerous Cave event in the Node Map, single use.",
"-20% performance.",
"+1HP. If its holder dies, +200 coins.",
"+30% performance if the module is flooded.",
"50% of +1HP and 50% chance of the holder having Has Explosive Diarrhea as their secondary trait.",
"If the holder is undisturbed for 8 turns, shoot the enemy for 150 damage.",
"If held by a crew member during a battle, it�s consumed and reveals secret information that players would likely not know without it, for example the instructions to summon the Eye of the Calamity module. Still useful for those that already know all the secrets because it sells for 50 coins.",
"Can be crushed during a battle to heal everyone 1HP and +100 Ship HP, or saved for other purposes.",
"If you have all 5 pages, consume all pages to build the Millennial Explorer module at the end of the battle, single use.",
"If you have all 5 runes, consume the runes to summon Dennis the Demon at the end of the battle, single use.",
"If placed in an empty module that�s undisturbed for 1 battle, transforms into crew member Skullo.",
"Prevents the holder from being Sleepy or Asleep.",
"The holder has Amateur Surgeon as their secondary trait.",
"+1HP and immune to Sick.",
"The holder has Bodybuilder as their trait, however if the module is water-flooded, the item dissolves into the surrounding water and increases enemy damage by 20.",
"Every turn, there�s a 5% chance the holder becomes Sleepy, but if the holder is Asleep, they heal 1HP/2turns.",
"Every 6 turns, there�s a 33% chance the holder swaps places with someone else, a 33% chance a random module explodes, and a 33% chance they heal 4HP, heal 400 Ship HP and deal 300 damage to the enemy.",
"The holder is not affected by a water-flooded module.",
"Single use. For the next 4 battles, the holder�s secondary trait will be Uncontrollable Flatulences.",
"Can�t be unequipped. The holder has Bodybuilder as their trait, however they can�t be moved to another module.",
"If the module is set on fire, it explodes and deals 200 damage to the enemy.",
"The module will charge its CD 33% faster.",
"+1HP/4turns, but if the module is water-flooded, lose 3 HP and there�s no HP recovery.",
"If the holder loses health, after 2 turns, a random crew member that�s not full HP will heal +1 HP.",
"The holder has Heavy Smoker as their trait.",
"Prevents the module from becoming excrement-flooded.",
"It�s consumed to randomly change the requirements of the module.",
"Prevents all Ailments, but if the module is flooded or set on fire, it�s destroyed.",
"The holder will count as having a second profession, but only as count for stacking bonus.",
"The holder can be sacrificed instantly at any moment.",
"The holder and a random crew member will gain In Love as their secondary trait.",
"The holder has Chronic Masturbator as their primary trait and Porn Addict as their secondary trait.",
"+50% chance of lucky effects occurring to the holder, and 33% chance the holder evades damage upon being hit.",
"At the end of the battle, 50% chance the holder is cut in half and dies, and 50% chance you gain a duplicate of the crew member, after which the item is gone.",
"+80% performance, but at the end of each battle, there�s a 25% chance the holder dies.",
"If the module is water-flooded, this item is consumed and the holder cannot be moved from its module ever again.",
"If the module is water-flooded, every 4 turns the holder will throw starfish shurikens at the enemy dealing 100 dmg.",
"Once per battle, if the holder is about to die, they will fully heal instead, but the enemy will also heal 400 HP.",
"-40% performance, however, the holder will have a 75% chance of dodging enemy damage.",
"+10% performance.",
"If the holder dies, the item is consumed and heals the Ship for 300 HP.",
"Can�t be unequipped. The holder becomes Sick, however if they die, they return from the dead with the trait Reanimated.",
"This item must be equipped as long as you have a crew member. -1 max HP.If the crew member dies, Cursed Water returns to your inventory.",
"Allows you to fire a crew member; -20% performance, and after 1 battle, the next time you enter a shop or market, this crew member will leave and a random one will replace them.",
"+20% performance, but -10% performance to all adjacent crew members that don�t hold Salary Increase.",
"Prevents the module from exploding, but this item will be destroyed if the module is flooded.",
"If the module is hit, 50% chance the holder loses 1 HP and 50% chance the enemy loses 100 HP.",
"If undisturbed, produce food at the end of the battle: 33% Tasty Fish Meal, 33% Tasty Pizza, 33% Expired Sushi.",
"If this module is flooded, you can flood an adjacent module instead.",
"Can�t be unequipped. +40% performance and +3 max HP, but after 4 battles, the holder gains Doomed as their secondary trait.",
"The holder has Stoned as their secondary trait, and they can�t be separated from their module.",
"+1 max HP at the end of each battle, but every time the holder is disturbed, they scald themselves and -1HP.",
"If the holder is hit by the enemy, the enemy will attack the same module for its next 4 attacks.Single use.",
"Every turn, there�s a 5% chance the holder disappears, and will return after 2 battles with +20% performance and +1 max HP. Single use.",
"At the end of every battle, the holder has a 33% chance of becoming a cadet, and a 10% chance of becoming a General Officer.",
"Can�t be unequipped.For every undisturbed battle, +10% performance, and a 10% chance of gaining Posh Millionaire as their secondary trait.",
"-40% performance, but +1HP/4turns.",
"Every 2 turns there�s a 20% chance the holder swaps places and items with a nearby crew member.",
"Adjacent crew members will try to move away from the holder. If hit, 33% chance of inflicting Poison to the enemy.",
"Prevents flooding, but if hit, there�s a 33% chance this and adjacent modules become excrement-flooded.",
"Can�t be unequipped.The holder will attack nearby crew members dealing 1dmg/4turns.",
"Can�t be unequipped. +1HP/4turns, however adjacent crew members will attack the holder dealing 1dmg/4turns with a 20% chance of swapping items.",
"If disturbed, it breaks. If undisturbed for a whole battle in a scientific module or held by a scientist or biologist, it turns into a random Organic A module.",
"After every battle, +20% performance but -1 max HP unless the holder has 1 max HP.",
"If undisturbed for a battle, it turns into a random module. If the holder had less than 50% performance, the module created will be permanently flooded.",
"Every time the holder changes modules during battle, +30% performance for that battle.",
"If the holder isn�t max HP, every 4 turns they will steal 1 HP from an adjacent crew member.",
"If the holder is going to die, instead of dying they murder another random crew member.",
"Can�t be unequipped.When equipped, change the holder�s trait to the trait of another crew member.",
"When equipped, a second Teleport Pads appears.Once per battle, you can swap around crew members with Teleport pads.",
"Can�t be unequipped.When equipped, designate another holder, they will also receive Umbilical Cord. The HP of both holders of Umbilical Cord will be averaged.",
"If the holder is in a water-flooded module, +1HP/4turns, if they�re in an excrement-flooded module, -1HP/4turns.",
"-40% performance, but +20% performance to each adjacent crew member.",
"If disturbed, it breaks. If undisturbed for 2 battles, it hatches and you receive the crew member Vicious Dinosaur.",
"It automatically passes from one crew member to another before each enemy attack.If a hit lands in this item�s module or an adjacent one, there�s a 15% chance it explodes, dealing 400 damage to the enemy and exploding the module it was in.",
"It automatically passes from one crew member to another.If hit by the enemy it�s destroyed, dealing 200 dmg and setting the module on fire.Destroyed by flooding.",
"If hit by the enemy, it deals 50 damage.Every time this item is passed to another crew member in battle, the damage is increased by 100.",
"Prevents this and adjacent modules from being set on fire.",
"Can�t be unequipped.After 10 turns, a Harmless Brain Parasite will appear in a random adjacent crew member.",
"Can�t be unequipped.The host has Monstrous as their secondary trait.After 10 turns, a Possessing Brain Parasite will appear in a random adjacent crew member.",
"When activated, the holder will travel to the future, and will return after 3-5 battles full HP but with Centenarian as their secondary trait.",
"The module that this item is in will have no requirements.",
"Will foresee the outcome of random effects in adjacent modules.",
"Every other item in the ship moves closer to the holder at a rate of 1 module every 4 turns.",
"If undisturbed for one battle, gain a random item that will have a 25% chance of being destroyed at the end of each battle due to bad quality. If water-flooded, 3D Printer is destroyed.",
"If undisturbed for a battle, produce one Lobster claw, but if the module is flooded, this item is destroyed and -3 HP.",
"Can�t be unequipped.The holder�s secondary trait has an 80% chance of changing to Geek, and a 20% chance of changing to Hero Mindset.",
"The holder will have Constipated as their secondary trait, and every time they�re hit deal 50 damage.",
"Sells for 100 coins.",
"If the module is set on fire, this item turns into a random crew member that goes to the bench.",
"-40% performance, but at the end of each battle there�s a 15% chance the item disappears and the holder�s trait becomes Genius.",
"If this item was held during a battle, at the start of the next shop or market, you will lose 50 coins and you�ll gain a random item.",
"+10% performance after every battle, but the holder will die if they stop holding this item.",
"If the holder is hit by the enemy, the item is destroyed and there�s a 50% chance you receive Pearl, and a 50% chance you receive Corrupted Pearl.",
"Can�t be unequipped. -1HP/6turns, but if they survive for 2 battles, Corrupted Pearl turns into Pearl.",
"Every 2 turns, the holder will move to a random adjacent module.",
"Reverses any performance gains and losses of its holder.",
"+10% performance.The holder has a performance cap of 150.",
"Less likely to get hit by the enemy, but if it does, Marine Disguise is consumed and the enemy heals 100 HP.",
"After 1 battle, the item is consumed and the holder gains +40% performance and 2 max HP, however, they will constantly attract enemy attacks.",
"Can�t be unequipped.The holder�s profession and traits will be copied from an adjacent crew member.",
"-20% performance, and ignore the effects of the holder�s traits.",
"New recruits will have +10% performance for their first battle if adjacent to its holder.",
"+20% Performance.Destroyed if flooded.",
"Can�t be unequipped manually. +20% performance, but If this item is swapped to a different crew member, its original holder will have -20% performance instead.",
"-70% performance, and you lose 50 coins at the start of every battle.However, there�s a 10% chance at the end of each battle that you receive 700, 800, 900 or 1000 coins.",
"Every 2 turns, it�s swapped to a random adjacent crew member.",
"The holder is permanently Asleep.",
"You can choose to water-flood this module at any moment.",
"You can choose to freeze this module at any moment.",
"You can choose to set this module on fire at any moment.",
"Prevents the module from becoming Wild.",
"+1HP, single use.",
"If the module is set on fire, +1HP/4turns.",
"After being in the same module for 2 battles in a row, the module becomes Wild.",
"Fix a Damaged module, single use.",
"+40% performance in Detached modules.",
"After every battle, 50% chance you receive a Surprise Gift. Destroyed if flooded or set on fire.",
"The holder deals 1dmg to an adjacent crew member but also increases their performance +20% for the rest of the battle.",
"The holder will either have the trait Magic Trick Enthusiast or Uncontrolled Illusionist.",
"The holder will have their trait changed to Necromancy Enthusiast, Funeral Organiser, Bone Architect, Corpse Looter or Frankenstein Fan.",
"Consume this item to permanently turn the holder�s trait to Normal.",
"If hit, will deal 100 damage to the enemy, but there�s a 33% chance of -1HP, the item is destroyed, and their trait changes to Missing an Arm and a Leg.",
"If the holder is hit, the enemy is Poisoned, this item is destroyed and this and X nearby modules become excrement-flooded, where X = the amount of turns this item was held divided by 4.",
"If the holder has 60% or more performance and is undisturbed, at the end of the battle there�s a 50% chance they produce Recipe Book (0-10), Book of the Dead(11-20), Ancient Volume of Wisdom(21-30), Lost Page(31-40), Treasure Map(41-50), Love Letter(51-60), Suspicious Magazines(61-70), Military Propaganda(71-80), Notice of Termination(81-90) or University Diploma(91-100).",
"If this module becomes excrement-flooded, undo the flooding after 2 turns and produce one Tasty Fish Meal or Tasty Pizza.",
"If the holder is adjacent to 4 crew members and another crew member is about to die, the holder dies instead, and Sacrificial Altar is consumed.",
"If this module is disturbed, this item is destroyed.After 3 battles undisturbed, this item is consumed and you gain the crew member Golem Helper.",
"Can�t be unequipped.Every time the holder is about to take damage, instead it�s blocked by Most Loyal Companion, but with every block it has a 25% chance of being destroyed.",
"At the end of battle, this item disappears and grants you 50 coins +100 extra coins for every other crew member that held this item.",

    };
}