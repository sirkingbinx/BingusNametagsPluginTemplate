using BepInEx;
using BingusNametags.Plugins;
using TMPro;
using UnityEngine;

public class MyNametag : MonoBehaviour
{
    void Start() =>
        PluginManager.AddPluginUpdate(NametagUpdate);

    void NametagUpdate(TextMeshPro textObject, VRRig playerRig) {
        NetPlayer netPlayer = playerRig.OwningNetPlayer;
        textObject.Text = netPlayer.NickName;
    }
}

[BepInDependency("bingus.nametags", DependencyFlags.HardDependency)]
[BepInPlugin("myname.mynametag", "MyNametag", "1.0.0")]
public class NametagLoader : BaseUnityPlugin
{
    void Start() => new GameObject(Info.Metadata.GUID, typeof(MyNametag));
}