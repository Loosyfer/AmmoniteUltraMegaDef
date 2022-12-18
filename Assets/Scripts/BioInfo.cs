using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BioInfo", menuName = "My Game/Bio Info")]
public class BioInfo : ScriptableObject
{
    public string[] names = new string[13] { "Excreel Pump", "Jellynfestor Babycrib", "Infectuna Guts", "Intellectopus Brain", "Sluugi Vessel", "Seabear Artic Exhaler", "Narwhal Horncannon", "Monstercrewed Module", 
    "Ophthalmonster Eye", "Bone Capsule", "Lobster Icicle Launcher", "Crusty Shield Weaponiser", "Monstrous Accumulator"};

    public string[] moduleDetails = new string[13] {"You are the one that can excrete turds now to Poison the enemy.",
"You are the one that sends Cannibal-inducing baby parasites now, which will make the enemies attack each other.",
"This module can be manned. Its crew member and any adjacent crew members will have Explosive Diarrhea from turn 1.",
"If this module gets hit by the enemy, he will suffer a great irritable explosion of 300 dmg.",
"Every now and then sends Sluugi that deal low damage to the enemy, but it’s a constant flow of +10 damage.",
"Freeze the enemy at the start of battle, or 1-2 enemies in a multi-battle.",
"Launch Narwhal horns at the enemy that penetrate and heavily damage shells.",
"You are the one that sends little monsters that attack the enemy.",
"Gain greater information on the types of events in nearby Nodes.",
"Crafted from many skeleton-related enemies. Protects the crew member inside from damage by physical hits.",
"If this or an adjacent module gets flooded, it turns the liquid into icicles and launches them into the enemy to deal +40 dmg with a chance of Freezing.",
"Uses the activated effect from an adjacent defensive module, and instead transforms that effect into an aggressive blast that deals +200 HP.",
"Crafted from small earlygame enemies. Every time you defeat a different creature species, +5 dmg."};

    public int[] cooldown = new int[13] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0};


    public string[] req = new string[13] { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0"};

    public ModuleRequirements[] randomReq = new ModuleRequirements[11] { (ModuleRequirements)0, (ModuleRequirements)1, (ModuleRequirements)2, (ModuleRequirements)3, (ModuleRequirements)4, (ModuleRequirements)5,
    (ModuleRequirements)6, (ModuleRequirements)7, (ModuleRequirements)8, (ModuleRequirements)9, (ModuleRequirements)10};

    public int[] modulePrice = new int[13] {200, 200, 200, 200, 200, 200, 200, 200, 200, 200,
                                            200, 200, 400};

}