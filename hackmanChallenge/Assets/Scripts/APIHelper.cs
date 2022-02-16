using UnityEngine;
using System.Net;
using System.IO;

public static class APIHelper
{
    public const string API_URL = "https://clemsonhackman.com/api/word?key=";

    // Not the actual key, but a base64 encoded version of it.
    // This is just to make it a tiny bit harder to find if
    // someone is trying to find it clientside by decompiling
    // the source code. (Although, if they can do that, this is
    // likely not going to stop them, haha.)
    public const string API_KEY = "NUVGODM=";

    // List of words incase the API is down or rate limited
    public static readonly string[] BONUS_FUN_WORDS = {
        "Ahoy",
        "Avast",
        "Bilge",
        "Bilgerat",
        "Freebooter",
        "Swashbuckler",
        "Seadog",
        "Captain",
        "Booty",
        "Brig",
        "Brigand",
        "Brigandine",
        "Bounty",
        "Privateer",
        "Pirate",
        "Plunder",
        "Plundering",
        "Pillage",
        "Plank",
        "Keelhaul",
        "Cannon",
        "Cannonball",
        "Ship",
        "Shipmate",
        "Shipwreck",
        "Shipwrecked",
        "Sunken",
        "Treasure",
        "Map",
        "Hull",
        "Rum",
        "Swashbuckled",
        "Leviathan",
        "Quarter",
        "Seas",
        "Seasick",
        "Scurvy",
        "Sails",
        "Sail",
        "Sailor",
        "Blackbeard",
        "Skull",
        "Crossbones",
        "Corsair",
        "Scimitar",
        "Cutlass",
        "Gangplank",
        "Alestorm",
        "Albatross",
        "Compass",
        "Rudder",
        "Shanty",
        "Crew",
        "Gold",
        "Banjaxed",
        "Island",
        "Isle",
        "Grapeshot",
        "Kraken",
        "Horizon",
        "Waves",
        "Hangover",
        "Keelhauled",
        "Mutany",
        "Landlubber",
        "Depths",
        "Yohoho",
        "Eyepatch",
        "Parrot",
        "FlyingDutchman",
        "DavyJones",
        "Besieged",
        "Honor",
        "Quest",
        "Land",
        "Turncoat",
        "Glory",
        "Fragment",
        "Shackles",
        "Crowsnest",
        "Storm",
        "Stormy",
        "Storms",
        "Circumnavigation",
        "Curse",
        "Cursed",
        "Thieves",
        "Thief",
        "Voyage",
    };


    // Decodes string from Base64 to UTF8.
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    // Gets a random word from BONUS_FUN_WORDS and returns it.
    // Would store the words in a file but this keeps it simpler for WebGL compatibility.
    // Bonus points for creative function naming?
    public static string GetRandomWordIncaseTheClemsonHackmanAPIDoesNotWorkForSomeReason()
    {
        return BONUS_FUN_WORDS[Random.Range(0, BONUS_FUN_WORDS.Length)].ToLower();
    }
}
