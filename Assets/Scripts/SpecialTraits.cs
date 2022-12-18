using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialTraits", menuName = "My Game/Special Traits")]
public class SpecialTraits : ScriptableObject
{


    public string[] names = new string[]
    {
        "Human Calculator", "Circuitry Specialist", "Plumbing Expert", "Skilled Hacker", "Avid Learner", "Expert Investor", "Multidisciplinary", "Born Leader", "Expert Negotiator", "Excellent Teamworker",
        "Teleportation", "Spark Aura", "Telekinesis", "Waterbender", "Telepathic", "Omega Brain", "Transcended", "Luckmancer", "Mind Controller", "Colossal Strength" 
    };

    public string[] description = new string[]
    {
    "Can predict the outcome of any %-based events for their or adjacent Modules.",
    "The Module that they’re in and adjacent ones cannot explode.",
    "The Module that they’re in and adjacent ones cannot be Flooded, nor can parasites, spores or gases invade their Module.",
    "Ignore the requirements of the module they’re in.",
    "Only once, if left in a Module for 20 turns, they will be able to change his Profession to GO/Scientist/Biologist depending on the type of module (Off/Sci/Org).",
    "If you go to a Shop event without buying anything, increase your savings by 15%.",
    "At the start of battle, offers the chance of choosing between two Professions.",
    "Prevents other Crew Members from being Stunned.",
    "50% chance you get +100 currency at the start of a Shop.",
    "20/35/50/65/90% Performance based on whether he has 0/1/2/3/4 adjacent Crew Members.",
    "Once per battle, can be teleported to another Module, even if it’s swapping with another Crew Member.",
    "If their module is attacked, they will take half the damage (minimum 1 Health) and deal 200 dmg to the enemy.",
    "Once per battle, you can swap around two Modules in your ships as long as it meets their requirements.",
    "Twice per battle, they can make a Module become Flooded or drain a Flooded Module.",
    "Every Crew Member in the ship counts as adjacent.",
    "Will always reach their Performance cap.",
    "Once per battle, can change their own primary Trait to a random one guaranteed to be positive.",
    "They and adjacent Crew Members have a 50% chance of avoiding unlucky effects from happening.",
    "Once per battle, can make an adjacent Crew Member change their Profession and Trait to that of another Crew Member in the ship.",
    "If you lose all of your Ship Health, they will hold the Ship together with their own Health, taking 1 Health for every 200 dmg to the Ship, and if you win the battle your Ship will be back with Ship Health."
    };


}
