using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monsters", menuName = "My Game/Monsters")]
public class Monsters : ScriptableObject
{
    public Sprite[] icons = new Sprite[56];

    public string[] names = new string[56]
    {
        "Trapped Sluugi",
"Baby Shark",
"Leech",
"Shellcrab",
"Trilobite",
"Blastshell",
"Octocute",
"Crustcoral",
"Drakguardian",
"Sharpfish",
"Ammonite",
"Tapeworms",
"Shell-less Turtle",
"Manfish",
"Ophthalmonster",
"Puffers",
"Psychic Starfish",
"Sunfish",
"Moonfish",
"Gigantopod",
"Brave Knight Crustaceous III",
"Excreel",
"Corrupted Ammonite",
"Muscufish",
"Snake&Whale",
"Vengeful Oyster",
"Infectuna",
"Kameman",
"Caged Waterape",
"Chomper",
"Rodapallo",
"Netfish",
"Anchoctopus",
"Whalenormous",
"Living Fishcorpse",
"Clamtasm",
"Blasteel",
"Turtlearth",
"Blind Crocofish",
"Scrutifish",
"Semishark",
"Seaswine",
"Narwhevil",
"Winter Gigalobster",
"Intellekraken",
"Polar Seabear",
"Mystic Squid",
"Monstercrewed Shipwreck",
"Jellynfester",
"Headless Ghoulfish",
"Cuadruplangler",
"Rift Overlord",
"Gigagoldfish",
"Witch of the Depths",
"Karrcharomancer",
"Tyrannus of the Abyss"

    };

    public string[] instructions = new string[56]
    {
        "100HP. 10dpt. 300HP shell.",
        "400HP. 80dpt.",
        "600HP. 30dpt. If it hits a module with a Crew Member in it, it heals 70HP.",
        "300HP. 50dpt. 300HP shell.",
"600HP. 50dpt.",
"200HP. 50dpt. 400HP shell. Any module hit becomes flooded.",
"300HP. 30dpt.",
"700HP. 30dpt.",
"1000HP. 50dpt.",
"700HP. 80dpt. Any module hit becomes flooded.",
"200HP. 50dpt. 500HP shell.",
"600HP. 50dpt.",
"800HP. 50dpt.",
"700HP. 50dpt.",
"600HP. 70dpt.",
"900HP. 30dpt. After 10 turns, every turn there?s a 25% chance it explodes and dies, and then it splashes everyone in the Ship with diarrhoea, causing 50% of Modules to be Excrement-flooded for the next battle.",
"600HP. 50dpt. 3 Crew Members will have another random trait for the rest of this battle.",
"800HP. 50dpt.",
"800HP. 50dpt.",
"700HP. 50dpt. 700HP shell. After the shell is cracked, every attack makes any Crew Member in and adjacent to the hit Module Sick.",


"1000HP. 50dpt. Every attack from your ship has a 25% chance of getting blocked by his shield, and a 25% chance of being deflected and parried back onto your ship.",
"1000HP. 70dpt. Water-flooded modules instantly turn into Excrement-flooded. Any module hit has a 50% chance of becoming Excrement-flooded.",
"200. 70dpt. 500HP shell.",
"800HP. 80dpt.",
"1000HP. 50dpt.",
"300HP. 70dpt. 500HP shell. When you kill it, the creepy pearl with an eye in its interior is released and shot into a random module that explodes with a vengeance.",
"700HP. 50dpt. At turn 3, every Crew Member has a 40% chance of having the trait Explosive Diarrhoea for the rest of the battle, and a 40% chance of becoming sick.",
"800HP. 50dpt. Every time he?s attacked, there?s a 25% chance he hides inside his shell and completely blocks the attack.",
"800HP. 70dpt.",
"800HP. 100dpt. Every attack has a 20% chance of missing and losing 50HP instead.",
"800HP. 50dpt.The nearest crew member to this monster has a 50% chance of becoming Lunatic every 4 turns.",
"800HP. 70dpt.",
"1400HP. 70dpt.",
"2500HP. 40dpt.",
"800HP. 100dpt.",
"500HP. 80dpt. 300HP shell. At turn 15, the ghostly traumatic scary face inside it attacks and transverses the whole ship, and every Crew Member has a 25% chance of becoming Lunatic.",
"1400HP. 40dpt. Any Module that?s hit twice will explode, and cause Blasteel to lose 100HP.",
"2000HP. 30dpt.",
"800HP. 150dpt. Every one of its attacks has a 50% chance of missing.",
"800HP. 80dpt. Will prioritise modules with crew members with 1 Health left, and then those that were more expensive.",
"1500HP. 120dpt. Every 2 turns, it loses 100HP.",
"1500HP. 50dpt. Any hit module becomes instantly Water-flooded. At turn 9, it shoots a beam of brown vomit that turns any Water-flooded modules into Excrement-flooded.",
"1000HP. 100dpt. When a Module is hit, there?s a 80% chance it becomes Water-flooded and a 20% chance it explodes and the Narwhal?s horn is damaged, after which it no longer has any of the former effects, and the Narwhals dpt is halved.",
"1500HP. 50dpt. Every time it hits a module, it becomes Water-flooded. Any Water-flooded module that?s hit or adjacent to a hit becomes a Frozen Coffin.",
"2000HP. 100dpt. Every 4 turns, throws an electric beam that stuns 50% of crew members, while the other 50% have their trait randomly changed for this battle.",
"2000HP. 80dpt. At turn 1, it exhales an arctic breath that freezes a whole area of your ship: 40% of your modules on one side of the Ship become Frozen Coffins.",
"1500HP. 100dpt. Every 5 turns, one random Crew Member becomes a Centenarian forever.",
"2000HP. 70dpt. Every 4 turns, a 0% Performance crew member with the Monstrous trait will invade your ship.",
"2000HP. 0dpt. At the start of battle, it sends baby parasites into a random external Module. Every turn, the parasites move into an adjacent Module, instantly turning crew members Cannibal until the battle ends.",
"1200HP. 60dpt. After dying, it revives with full health and 120dpt.",
"2000HP. 120dpt.",
"2400HP. 100dpt.",
"3000HP. 80dpt. Every time a Crew Member dies, there?s a 50% chance that it?s satisfied and swims away from the fight, granting you a victory.",
"2000HP. 100dpt. Every crew member hit will forget their profession for the rest of the fight.",
"3000HP. 100dpt. Every 4 turns, a cannonball is fired and hits a random module, Water-floods it and the Crew Member in it becomes Sick. Once its Health gets below 1000HP, it becomes Berserk: its dpt increases to 150, cannonballs now fire every 2 turns, and automatically loses 40HP every time it attacks.",
"3000HP. 150dpt."
    };

    public string[] flavour = new string[56]
    {
        "Little Sluugi is trapped in a bottle that serves as a defensive carapace, without which Sluugi will tremble and panic.",
"Cute baby shark that munches at the ship because it thinks it?s food. It boasts a surprising amount of strength for its tiny size, which is a warning for how powerful the adults will be.",
"Fat greedy  leech that sucks vitality from its prey.",
"Insecure about its own carapace, it hides in its shell most of the time. If exposed, it tries to look cute in the hopes that it will save its life.",
"Ancient critter that has survived eons of natural selection, but might not survive a blast to its face.",
"Crafty being that stores urchins inside its shell and shoots them like bullets into unsuspecting enemies.",
"Cute baby that looks for their mother. Its eyesight hasn?t developed yet so it just bumps into bigger objects.",
"This piece of coral got tired of being anchored to bedrock, and imitated the form and movement of nearby crabs to free itself in search of food.",
"A noble creature that guards the entrance to the depths of the sea from intruders that haven?t proved worthy to access its secrets.",
"This spiny creature has become insane. It enjoys poking and torturing its pray, and it can?t find a mate because it pokes surrounding fish to death.",
"Basic and common good old ammonite.",
"These tapeworms were too weak to infect a creature individually, so instead they formed a menacing ball.",
"This turtle had its carapace removed and somehow still survives in a zombie-like state.",
"Manfish was assumed to be a myth told by hallucinating fishermen. However it is here in all its glory and mysteriousness.",
"Ancient sea lizard with enormous eyes that can see very far through the depths of the sea.",
"This creature seems to have one same orifice for eating and excreting. It?s so inflated it looks like it could explode at any moment.",
"Mysterious starfish that uses psychic powers to confuse its enemy.",
"This elegant fish appears during the day, and shines like the sun. At dusk, they look for Moonfish to mate with.",
"This elegant fish appears at night, and shines like moonlight. At dusk, they look for Sunfish to mate with.",
"Gigantic sea bug with a very hard shell, curled up in a ball. After the shell is cracked, it opens in all of its grossness and throws its guts at the enemy.",
"Brave sea warrior that wears as his armour the body part of countless defeated enemies, and uses both offensive and defensive techniques in battle.",
"This monstrous eel uses the power of excrements to disturb and infect its enemies.",
"Good old ammonite has been corrupted by a parasite and now exhibits aggressive tendencies.",
"Muscular, bodybuilder fish that is as proud as it is tough.",
"A crafty snake has formed an unusual partnership with this whale, feeding it enough to survive in exchange for the protection of its sturdy body.",
"An oyster bursting with rage that conceals a corrupted malevolent pearl.",
"Diseased but somehow still alive tuna that releases a nauseating stench.",
"Mr. Kamura was a strange man from Ammonite Town. It was known that he was obsessed and loved the sea. It had a collection of 32 sea turtles in his home. He always wished he was born at sea. He disappeared 10 years ago, and most assumed he just drowned while cherishing the ocean.",
"His owner must have discarded him because he was too much work to take care of. The ape has somehow survived and adapted to his new life, using his long arms to claw at prey foolish enough to laugh at him being trapped in a cage.",
"Its chomping teeth are designed to smash even the toughest of carapaces, but its bite is so strong that if it misses, he?ll shatter its own bones and get a horrible headache.",
"A rare being that appears to have a human face. However, each person sees a different face.",
"This fish has lived trapped in a net for so long that removing it would do more harm than good.",
"When an anchor landed on its head and nearly killed it, it adapted and took over it, now using it as a daunting weapon to dominate its environment.",
"A whale so massive that it can?t change direction or stop moving, it just charges forward destroying or eating any obstacles in its path.",
"Its rotting flesh is somehow being kept alive, and the corpse is enjoying its newfound life.",
"This giant clam has been invaded by a ghostly spirit.",
"Crazy monster with explosives at the end of its tail. It won?t hesitate to use its tail even at the cost of its own flesh.",
"A turtle so gigantic that it has grown its own ecosystem. It is unknown if the turtle is alive or if the ecosystem continues on a dead shell.",
"This creature might miss its chomps every now and again, but when they land they?re sure to smash its prey.",
"Its eyes can see through the flesh of its prey, which allow it to target its inner weak spots.",
"Formerly a magnificent huge shark, this mutilated corpse now transverses the seas full of rage, destroying everything in its path as its flesh disintegrates.",
"This pestilent abomination pukes onto its prey to melt their flesh into faeces before consuming them.",
"This ferocious angry narwhal might be too reckless for its own good.",
"A smart lobster that enjoys taunting its enemies while they freeze to death.",
"This octopus has a brain that never stopped growing. After centuries, it became so big and powerful that it learned to subdue other creatures with mentally-charged electric blasts.",
"This colossal polar bear became too heavy to live on the surface, and thus delved into the ocean, where it transformed into an even bigger monstrosity.",
"Mysterious squid that doesn?t look like it belongs to this world. Whoever is captivated by the curves of the squid for too long will be hypnotised and have their whole life elapse within minutes.",
"The crew from this ship didn?t die when it sank. Now, they roam the abyss endlessly in their shipwreck, with the only goal of bringing others to their same doom.",
"Enigmatic jellyfish that uses its offspring to infest its enemies before consuming them.",
"This abomination lures other creatures with its own head and claims their life force to maintain its dead corpse.",
"This monster uses its light to lure its prey into his mouth. However, it has also grown limbs to chase bigger prey through the bottom of the sea.",
"This majestic beast overflies and watches the rifts of the ocean, as it chooses which bottom creature will be sacrificed next.",
"Flushed down the toilet by its owner decades ago, this only made it stronger. Its sole purpose is to exact revenge upon its owner, and it looks like it found him in your crew.",
"A witch from centuries ago. In search of more power, she became one with the ocean and embraced the corruption of her form. All magical transformations and curses that plague both people and creatures in the seas can be attributed to the Witch of the Depths.",
"The biggest shark of the ocean is fused into a pirate ship. Its flesh is disintegrating and it?s fired through cannons, causing destruction and pestilence. Once a legendary beast, it is now in great pain, screaming and twisting in a berserk rage.",
"A species thought extinct millions of years ago was alive in the depths of the ocean and had terrorised its inhabitants for ages, creating a cycle of violence that impacted all marine creatures."

    };

}