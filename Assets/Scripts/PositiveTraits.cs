using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PositiveTraits", menuName = "My Game/Positive Traits")]
public class PositiveTraits : ScriptableObject
{


    public string[] names = new string[]
    {
        "Genius", "CopyCat", "Competitive", "War Fanatic", "Pacifist", "Has an Imaginary Friend", "Lucky", "Sadistic", "Mr. Moneybags", "Selfless", "Hero Mindset", "Best Buddies", "Spiritual Meditator",
        "Necromancy Enthusiast", "Has Gross Eating Habits", "Puppeteering Enthusiast", "Snitch", "Massage Expert", "Escape Artist", "Speaks Fish Language", "Heavy Snoring", "Sushi Chef", "Bone Architect",
        "Corpse Looter", "Unleashed Power", "Sushi Lover", "Home Chef", "Also a Lawyer", "Frankestein Fan", "A Karen", "Loves Rainbows", "Professor", "Loves Fireworks", "Posh Millionaire", 
        "Gifted", "Recycling Fanatic", "Hypothermic", "Big Daddy"
    };

    public string[] description = new string[]
    {
        "+30% Performance, but always comes paired with Moody, Psychopath, Fussy, Geek or Vain.",
        "Copies the most common Trait of adjacent Crew Members",
        "20% Performance if alone, but it will increase to match the best-performing adjacent Crew Member.",
        "60% Performance in Offensive Modules, and 30% Performance in Defensive Modules.",
        "60% Performance in Defensive Modules, and 30% Performance in Offensive Modules.",
        "If they?re not adjacent to an empty Module for 10 turns, they turn into a Lunatic. One adjacent empty Module will count as manned.",
        "20% chance that a battle even turns out to be a rare treasure.",
        "Every time a Crew Member loses Health, they gain +10% Performance.",
        "40% Performance, but 50% chance you gain 100 coins after each battle.",
        "If a Crew Member is about to die, they sacrifice their own life instead.",
        "Attracts the Hero Hideout Module. If you lose a battle, they sacrifice themselves to avoid the defeat.",
        "This Trait always appears in pairs in the Shop. They can only be recruited if both applicants are. +10% Performance when adjacent to each other.",
        "Upon death, they will revive with 30% Performance and Ghost Trait.",
        "20% chance that if a Crew Member dies, they are revived with 40% Performance and the Reanimated Trait.",
        "If there?s an Excrement-flooded Module, they will swap places with this Module, clean it up, and gain 1 Health.",
        "Will create a 30% Performance clone of himself without a Trait in an adjacent Module, but if this Module becomes Flooded the clone will die.",
        "If placed adjacent to the Captain, they will reveal who is a Serial Killer or Undercover Competitor, as well as who is a Liar, Traitor or Cheeky Undergrad in the Shop.",
        "+10% Performance to the Crew Member adjacent to the left.",
        "If their module explodes, they escape to the nearest empty module or to the bench right before the explosion.",
        "At the start of battle, there?s a 50% chance they talk a small enemy creature into not attacking.",
        "If they become Asleep, they snore heavily, waking up any other Asleep Crew Members, but adjacent Crew Members -10% Performance.",
        "Will heal 1 Health after defeating an enemy creature, but has also a 30% chance of starting the next battle Sick.",
        "For every 2 Crew Members that die, they will build 1 Bone Capsule.",
        "For every Crew Member that dies, they heal 1 Health and give you 100 coins. If the corpse was of a Businessman, they give you 200 coins.",
        "If their module explodes, they survive and unleash newfound power changing their Trait to Blastman. If a Crew Member is about to die, Blastman will always rescue them and return them to the bench with 1 health. After rescuing 4 Crew Members, they quit the Dive to help in other places.",
        "If they?re attacked by a Monstrous crew member, he will eat them. They will also eat enemy parasites or babies that invade the Ship, and not be affected by them.",
        "After every battle, any adjacent members will have a 50% chance of gaining the Glutton trait.",
        "If in the last battle a Crew Member died or a Module exploded, there?s a 50% chance you get 100 coins.",
        "If a Crew Member dies, there?s a 40% chance they return after the battle without a Profession and with the Thick Trait.",
        "You can activate Karen to have a 50% chance of rerolling the contents of the Shop. After rerolling the Shop 3 times this way, Karen gets tired and their Trait will change to Argumentative.",
        "If you have 1 of each type of Module, +40% Performance.",
        "If adjacent to a Cadet for 15 turns, the Cadet will copy their Profession.",
        "If a Module explodes, +15% Performance.",
        "Can?t be placed in any Module that doesn?t cost at least 300 coins, but if their Module was undisturbed, they will pay a rent of 50 coins after every battle.",
        "Only applies to men. If a woman is in the Ship, no matter how far, she will gain the Pregnant Trait after 15 turns.",
        "Each Shop event, you can sell back 1 Module in your bench for half its original coin value.",
        "Operates and performs normally even if their Module is Frozen.",
        "If an adjacent crew member is damaged by an enemy, they deal 50 damage to that enemy."
    };


}
