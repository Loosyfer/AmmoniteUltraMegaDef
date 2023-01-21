using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialTraits", menuName = "My Game/Special Traits")]
public class SpecialTraits : ScriptableObject
{


    public string[] names = new string[]
    {
        "Human Calculator", "Circuitry Specialist", "Plumbing Expert", "Skilled Hacker", "Avid Learner", "Expert Investor", "Multidisciplinary", "Born Leader", "Expert Negotiator", "Excellent Teamworker", "Multitasker", "Maximum Concentration", "Tough", "First Aid Expert", "Expert repairman",
        "Teleportation", "Spark Aura", "Telekinesis", "Waterbender", "Telepathic", "Omega Brain", "Transcended", "Luckmancer", "Mind Controller", "Colossal Strength", "Firebender", "Naturebender", "Shitbender", "Icebender", "Rogue Warrior", "Uncontrollable Power", "Power Drainer", "Controller of Elements"
    };

    public string[] description = new string[]
    {
    "Can predict the outcome of any %-based events for their or adjacent Modules.",
    "The Module that they’re in and adjacent ones cannot explode or become unstable.",
    "The Module that they’re in and adjacent ones cannot be Flooded, nor can parasites, spores or gases invade their Module.",
    "Ignore the requirements of the module they’re in.",
    "Only once, if left in a Module for 20 turns, they will be able to change his Profession to GO/Scientist/Biologist depending on the type of module (Off/Sci/Org).",
    "If you go to a Shop event without buying anything, increase your savings by 15%.",
    "At the start of battle, offers the chance of choosing between two Professions.",
    "Prevents other Crew Members from being Stunned.",
    "50% chance you get +100 currency at the start of a Shop.",
    "0/10/20/30/50% Performance based on whether he has 0/1/2/3/4 adjacent Crew Members.",
    "+30% performance if they hold an item.",
    "Works under any condition; immune to Flooding, Set on Fire, Wild and Frozen.",
    "Immune to all Ailments.",
    "Once per battle, fix the Ailment of a random adjacent crew member after 2 turns.",
    "If placed in a damaged module, they will fix it after 1 battle.",
    "Once per battle, can be teleported to another Module, even if it’s swapping with another Crew Member.",
    "If their module is attacked, they will take half the damage (minimum 1 Health) and deal 200 dmg to the enemy.",
    "Once per battle, you can swap around two Modules in your ships as long as it meets their requirements.",
    "Once per battle, you can water-flood any module, or undo a water-flooded module. If their module is water-flooded, they’re immune to it and them and adjacent crew members will have a 60% chance of being protected from enemy hit by water shields.",
    "Every Crew Member in the ship counts as adjacent.",
    "Will always reach their Performance cap.",
    "Once per battle, can change their own primary Trait to a random one guaranteed to be positive.",
    "They and adjacent Crew Members have a 50% chance of avoiding unlucky effects from happening.",
    "Once per battle, can make an adjacent Crew Member change their Profession and Trait to that of another Crew Member in the ship.",
    "If you lose all of your Ship Health, they will hold the Ship together with their own Health, taking 1 Health for every 200 dmg to the Ship, and if you win the battle your Ship will be back with Ship Health.",
    "Once per battle, you can set on fire any module, or undo a set on fire module. If their module is set on fire,they’re immune to it and  +80% performance and +1HP/4turns.",
    "Once per battle, you can make a module Wild or undo Wild in a module. If their module is Wild, they’re immune to it and +1HP/8turns to everyone in the ship.",
    "Once per battle, you can excrement-flood any module, or undo an excrement-flooded module. If their module is excrement-flooded, they’re immune to it and the enemy will be poisoned // -50HP/turn.",
    "Once per battle, freeze this and an adjacent module, and both their crew members are immune to the negative effects of freezing.",
    "At the start of battle, their module becomes detached and they gain +60% performance, and the module returns to the ship at the end of the battle.",
    "+100% performance but their module is unstable. If the module explodes, they’re returned to the bench.",
    "All adjacent modules are disabled. For each adjacent disabled module, deal +20 extra dmg with every attack to the enemy.",
    "Once per battle, move one module status to a different module in the ship.",


    };


}
