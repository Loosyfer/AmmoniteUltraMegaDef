using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StrangeEvents", menuName = "My Game/Strange Events")]
public class StrangeEvents : ScriptableObject
{
    public string[] strangeEvents = new string[] {

    "Enemy Ship (Neutral)",
    "Enemy Ship (Hostile)",
    "Eerie Cave",
    "Marine Graveyard",
    "Rescue Mission",
    "Dangerous Request",
    "Guarded Treasure",
    "Underwater Colony",
    "Submarine Wreck",
    "Mysterious Abduction",
    "Scrap Thieves",
    "Hospital",
    "Repair Facility",
    "Cemetery",
    "Boxing Ring",
    "Collector of Idiots",
    "Dangerous Cave",
    "Underwater Tavern",
    "Oceanic Gambler",
    "Nuclear Waste Dump",
    "Rapture City",
    "Forgotten Submarine",
    "Turtle Cave",
    "Pirate Shipwreck",
    "Violent Vortex",
    "Underwater Volcano",
    "Futuristic Colony",
    "Secret Tunnel",
    "Lost Islander Request",
    "Crustacean Colony",
    "Lost Seaman",
    "Zoo",
    "Arctic Rift",
    "Lava Tunnel",
    "Oceanic Jungle",
    "Loan from Friendly Ship"
    };

    public string[] sEventsDescription = new string[]
    {
        "They bribe you by offering 200 coins if you run away, but you can also battle, which has a 50% chance of receiving a reward of triple the bribe.",
    "Will kidnap 1-2 of your crew members (depending on how many total crew members you have) or steal 100-300 of your coins, and you can either run away or battle to get them/it back if you win.",
    "50% chance of having trapped O2 bubbles, 50% chance of having an Alpha enemy (has 15% more health and damage than usual).",
    "Receive 1-2 items of organic origin (sponge, disgusting sediment, etc).",
    "He’s being attacked by a monster, and if the battle isn’t over after X number of turns, he dies and there’s no reward.",
    "This fellow explorer has eyes on a nearby treasure, however, it is guarded by a powerful Alpha enemy and he’s not brave enough for the task, so he asks if you can fetch it for him and you can both share the loot. “Dangerous request: enemy” will appear nearby in the node map, and if you successfully win you’ll collect “Requested treasures”. You can choose to keep them to yourself, or go back to the fellow explorer using O2 to share them as promised. If you do the latter, you’ll only get 1 Treasure instead of 2 but the explorer and his module will join your crew.",
    "Guarded by an Alpha version of an enemy (has 15% more health and damage than usual). The reward is a Treasure.",
    "Stay a few nights with a friendly colony. A crew member decides to leave your crew and live there forever, but someone from the colony says they’re bored with their life and they ask to join your crew.",
    "Receive a random module, but it will always be flooded and every turn there’s a 3% chance it explodes.",
    "One crew member will be abducted and they’ll reappear after 2 battles, fully healed but with a different profession.",
    "They’ll steal a module from your ship and you’ll find it with the damaged status in a further down node.",
    "Heals up to 3 Crew Members (free or for a fee?).",
    "Heals up to 300 Ship HP and fixes Damaged modules for half the usual price.",
    "Simply mourn the dead, and usually nothing happens. But there’s secretly a 10% chance that a random crew member that died returns with “Zombie” in front of their name and with Reanimated as their trait.",
    "Two crew members fight to the death and whoever wins returns extra strong with +2 max HP.",
    "You can exchange a crew member with a bad trait (lowest cost) for 250 coins.",
    "Find 3 treasures in it, but will need an expedition of 3 crew members. Each crew member has a 33% chance of having Missing an arm and a leg as their secondary trait and a 33% chance of not coming back from the expedition.",
    "You can choose to spend the night at the tavern and all crew members will have +2 max HP for the next fight but have Drunkard as their secondary trait for the next fight.",
    "Gamble 100 to 1000 coins once, choosing any of the three options: (50% x2 / 50% x0,5) (33% x3 / 66% x0,33) (25% x4 / 75% x0,25).",
    "Will charge up your Module CDs by 50%, but will add Radioactive as a secondary trait to 1-2 crew members.",
    "Send 3 crew members to investigate and loot this mysterious city to receive 1-4 items, and each crew member will have a 25% chance of returning with Big Daddy as their secondary trait and a 25% chance of becoming Lunatic.",
    "Submarine that was trapped decades ago. His crew member, Morgan, still lives there as a Ghost, he will thank you for the rescue and both him and his ghostly module will join your crew.",
    "Defeat a Shell-less turtle to find Kame Jr living in a cave full of turtle shells, and he will join your crew.",
    "An alpha enemy is living in an abandoned pirate ship, defeat it to collect the loot from the ship: a Treasure and the Parrot crew member who will join your crew.",
    "You lose 1, 2 or 3  modules and the crew members that were in them, but they are secretly placed in other nodes further down so you might find them again.",
    "At the start of the next battle, 33% of your modules will be set on fire.",
    "They will fully heal your Ship for free, however the colony is so futuristic and perfect that 1 or 2 crew members will decide to abandon the mission and join the colony.",
    "Takes you to a random Explorer Node nearby, but you still can’t travel to other Explorer Nodes without 4 explorers.",
    "Dori is looking for their friend, who has got lost in a random enemy node nearby. If you defeat this enemy and find their friend, Dori will join your crew as a reward.",
    "Their leader, King Crustaceus III, will challenge you to a battle. If you win, Mr. Sebastian from the colony will be impressed and join your crew.",
    "Legendary Seaman Nemo hasn’t been to the island for decades. Thought to be dead, you find them living in the bottom of the ocean in an incredible Ship of their own, gone crazy. if you win the battle, they will abandon their ways and feel revitalised to join your crew.",
    "Fight any enemy that you desire from a list.",
    "Defeat 3 weak enemies but with 80% of your modules being frozen at random each time.",
    "Defeat 3 weak enemies with but 80% of your modules being set on fire at random each time",
    "Defeat a weak enemy but afterwards 20% of your modules are wild.",
    "You are lent a crew member of 60% base performance, and a in a random node after 3 battles, they will request them back. If the crew member died, they will cry in sadness and have no choice but to confront your ship, and if you win you don’t get any rewards"
    };

    public string[] ultraRareEvents = new string[] {

    "Mystical Temple Gate",
    "Mystery Portal",
    "Interdimensional Wormhole",
    "Oceanic Trespasser",
    "Sage of the Seas",
    "Unimaginable Treasure",
    "Atlantis",
    "Blacksmith of the Depths",
    "Spectral Ship of Old Tales",
    "Exchange with Fellow Captain",
    "Monstrous Advisor",
    "Draconic Chariot",
    "Impossible Fire",
    "Gigantic School of Fish",
    "Banished Engineer",
    "Selfless Whales",
    "Elite Mercenaries",
    "Geyser of Eternal Youth"
    };

    public string[] uRareEventsDescription = new string[]
    {
        "They always appear in pairs, in random Nodes of the same level. Enter one to reappear in the Node where the other gate is, at no O2 cost.",
        "Throw in up to 7 crew members, modules or items to get another random crew members, modules or items respectively.",
        "Choose to enter it to move to a parallel reality permanently, which resets all events in the Node Map.",
        "This powerful character can make you skip several nodes down the level in exchange for a great amount of coins. Price: straight down 5 nodes for 500 coins.",
        "This legend of the seas will challenge your ship to a very hard battle against his team of guardian tritons. This battle doesn’t affect your ship’s HP/lives after this battle. And you can return to this node to try again in the future. If you win, he will reveal two Ultra Rare Event locations that suddenly appear in nearby nodes.",
        "Find a legendary age-lost golden treasure that contains 1000 coins.",
        "Hidden city blooming with life, with the biggest market ever, loaded with items and 3 crew members of each profession.",
        "Mythical blacksmith hidden deep in the ocean that can craft the most unnatural armors. Select a crew member, and they will receive a special armor that will allow them to hold 3 items.",
        "Ship that has traveled the seas for centuries. If you beat this vessel, receive 3 Ghost crew members.",
        "A mysterious captain will offer you their ship in exchange for yours. Their ship is similar to yours, but has a different layout, and every type of module, every profession and trait are swapped for another random module type, profession and trait.",
        "For 100 coins, reveals the name and location of the boss in this level of the sea",
        "This mythical traveler of the seas will offer to carry your ship forward for 300 coins, saving you half the usual amount of O2",
        "Set on Fire 3 of your modules. This fire won’t harm your crew members, but will harm the enemy on hit as usual. The fire cannot be put out with flooding",
        "Receive 20 Tasty Fish Meals",
        "Engineer so crazy and deranged that he was banished from his society ages ago. Will build a revealed but randomly chosen Legendary module for 1000 coins",
        "Gain the module Selfless Whale.",
        "For 100 coins per battle, you can have 3 mercenaries which are crew members with 160% performance, 6 max HP and one Erudite Trait.",
        "If a crew member is about to die, send them into the geyser, and only once, they will return as an immortal with 80% base performance."
    };

    public string[] explorerEvents = new string[] {

        "Ancient Trench",
        "Trinket Merchant",
        "Bargain Marketplace",
        "Antique Shop",
        "Training Academy",
        "Explorer’s Tunnel",
        "Triton Colony",
        "Worried Ape Couple",
        "Colony of Manfish",
        "Supernatural Rift",
        "Shark Hunting Grounds",
        "Surprise Seller"
    };

    public string[] explorerEventsDescription = new string[]
    {

        "You find 1, 2, 3 or 4 Fossils.",
        "Give 50 coins to receive a random item.",
        "Will sell modules and crew members for half the usual price. However, the modules will have status problems often, and the crew members will often be Sick and have only 2 HP.",
        "Buy from a selection of 6 rare items for 50g each.",
        "For 150 coins, +30% performance to 3 crew members.",
        "You can teleport to a nearby Explorer Event.",
        "Gain 2 Selfless Triton crew members.",
        "An ape couple is worried because their son has been kidnapped by a nearby creature. If you defeat the creature and rescue their son, the father will feel indebted to you and join your crew, and you gain 1 Super Intelligent Ape crew member.",
        "Defeat lots of Manfish, and then their Lord Manfish will finally appear asking that you stop hurting his creatures, and in exchange he will join your crew.",
        "You can hire one of 3 supernatural creatures as a crew member for 300 coins: Burned Captain, Snow Mermaid, or Wild Coralman.",
        "Leave up to 5 crew members here. If you return after visiting at least 3 other nodes, each of them has a 50% chance of having died, and a 50% chance of being transformed into a Vicious Sharkman.",
        "Sells, for 600 coins, a mystery bundle of crew members, modules and items. You receive 3 things, with 2 items counting as one thing."
    };
}
