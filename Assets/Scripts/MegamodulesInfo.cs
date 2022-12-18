using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MegaModInfo", menuName = "My Game/Mega Modules Info")]
public class MegamodulesInfo : ScriptableObject
{
    public string[] names = new string[14] { "Visceral Execution", "Modublast Bomber", "Soul Crusher", "Body Splicer", "Cryogenic Lab", "Absolute Assembly", "Flesh Buffer", "Duplex Ship", "Destiny Portal",
    "Megabrain Core", "Clone Lab", "Colossal Expansion", "Cathedral of the Depths", "Life-Absorbing Krakencore"};

    public string[] moduleDetails = new string[14] {"If a creature has less than 500HP, you can execute it, but will be utterly disintegrated and you won’t be able to harvest it for any organic effects or modules. Charges up after 5 battles. If operated by a General Officer, it can be executed at 700 HP.",
"Twice per battle, you can select a module from your ship, destroy it and turn into a Modublast Bomb that will deal 400 dmg to the enemy.",
"For each crew member that died, this module has 1 Soul Bullet. Once per battle, shoot a Soul Bullet that will deal 600 dmg to the enemy. The Soul Bullet will carry the name of the deceased owner of the soul.",
"Fuse two crew members into one mega crew member of 100% performance, extra HP and high level, and having both professions and both their first Traits. Takes 5 battles to recharge.",
"Cryo-preserve a crew member when they die. If you have 2 Doctors adjacent to this capsule, you can bring this person back to life. Takes 5 battles to fully charge. Flooding will disable this module’s effect.",
"Once per battle, during your turn, you can pause time and rearrange your modules, except for this one.",
"The crew member in this module will take damage instead of the ship, losing 1 HP for every 200 Ship HP lost.",
"All of your other modules except for this one are rerolled into random ones until the end of the fight. If you lose the battle, all your original modules return and you can continue with battle with the same amount of Ship HP you started with.",
"Cannot place a crew member in it. At the beginning of the fight, the portal will open, to reveal the otherworldly return of the first Crew Member that ever died this Dive, exactly as you remembered him, except that he will have an HP bar of 12 Points, and will always take aggro from the monster for as long as he’s alive.",
"Every other module in the ship will work even if unmanned. Charges up in 4 battles.",
"It will take 15 turns to create a clone of a crew member that’s in it. If the module is disturbed during the cloning process, the resulting clone will be a random abomination.",
"This module counts as 4 Defensive modules for all effects and purposes. Only once per Dive, duplicate your Ship HP, and any amount above your original Ship HP will stay as a shield into future battles.",
"Summon an Abyssal Beast that will fight by your side during this battle. Takes 4 battles to recharge.",
"If you kill a creature, the squid capsule redirects his life energy into the crew, healing by 1HP every crew member." };

    public int[] cooldown = new int[14] { 50, 0, 0, 50, 50, 0, 0, 0, 0, 40, 15, 0, 40, 0 };


    public ModuleType[] moduleType = new ModuleType[14] { (ModuleType)1, (ModuleType)1, (ModuleType)1, (ModuleType)3, (ModuleType)3, (ModuleType)4, (ModuleType)2, (ModuleType)3, (ModuleType)4, (ModuleType)3,
    (ModuleType)3, (ModuleType)2, (ModuleType)4, (ModuleType)0 };

    public string[] req = new string[14] { "0", "0", "0", "0", "0", "Can only be manned by an Architect", "0", "Must have 8x Engineers, and can only be manned by one", "Can only be used once, during an Abyssal Beast battle",
        "Can only be manned by a Developer", "Adjacent to a scientist", "0", "Only works when manned and adjacent to another 6 crew members", "Adjacent to a scientific module"};

    public Sprite[] sprites = new Sprite[14];

}
