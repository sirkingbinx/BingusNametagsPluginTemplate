using BingusNametagsPlusPlus.Attributes;
using BingusNametagsPlusPlus.Classes;
using BingusNametagsPlusPlus.Interfaces;

namespace BingusNametagsPluginTemplate;

/*
 * Thanks for wanting to make a cool nametag!
 * All code here is well commented so even if you're new to C#, it should be very straightforward.
 * When done building a nametag, build this project by pressing Ctrl + Shift + B (Visual Studio) and it will be automatically added to your nametags folder.
 *
 * Share your nametags! I like to see cool things: https://discord.gg/TYvMnt9KtC
 */

// Arguments (in order):
//      name (string): Name of the plugin, usually the name of your mod
//      author (string): Your name. Hi!
//      description (string): A tiny description of what the nametag is. eg. "Adds a speed counter in m/s"
//      unsupported nametags (string[]): If you know the name of a nametag that interferes with your nametag, add it's name to this list to have it automatically disabled.
[BingusNametagsPlugin("My First Nametag", "John Doe", "Write a short description of your plugin. (actually short)")]
public class Main : IBaseNametag
{
    // This attribute defines what the actual nametag is. You can add multiple nametags to your plugin
    // by adding this attribute above methods and changing up the arguments.
    // Arguments (in order):
    //      name (string): The name of this nametag (eg. "speed counter" or "fps counter")
    //      offset (float): The amount of space inbetween the default nametag offset and your nametag. The default nametag's offset is 0f.
    [BingusNametagsNametag("My First Nametag", 0.5f)]
    public static void Update(PlayerNametag nametag)
    {
        // The owner of the nametag is nametag.Owner. Here's some shortcuts I made for you
        var ownerRig = nametag.Owner;
        var ownerNetPlayer = nametag.Owner.OwningNetPlayer;
        var ownerPhotonPlayer = nametag.Owner.OwningNetPlayer.GetPlayerRef();

        // Here's some common things you would want on a nametag
        var speed = $"{ownerRig.LatestVelocity().magnitude:F1} m/s"; // :F1 tells C# to round the velocity to 1 decimal place
        var nickname = $"{ownerNetPlayer.NickName}"; // Username of the player
        var safeNickname = $"{ownerRig.playerNameVisible}"; // Username that is shown on the gorilla's chest (filtered for curse words, bad names, etc).

        // Some basics of changing nametags
        nametag.Size = 1f; // Size of the nametag. Think of this as a percentage of the user's chosen nametag scale, eg. 0.75 is 75% of the normal nametag size.

        // TextMeshPro styles are supported!
        // See https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/RichText.html
        nametag.AddStyle("b"); // Add a TMP tag
        nametag.AddStyle("color", "\"red\""); // You can also add tags with values

        // When done with a style, remove it like this. Works for both plain and valued tags!
        nametag.RemoveStyle("b");
        nametag.RemoveStyle("color");

        // now the important part: nametag
        nametag.Text = $"Speed: {speed} | Name: {nickname}"; // Here's where the text is actually set. Do this last!
    }
}
