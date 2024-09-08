using BepInEx;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Path = System.IO.Path;

namespace ChangeItemTemplate
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    public class ChangeItemTemplatePlugin : BaseUnityPlugin
    {

        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "You";
        public const string PluginName = "ChangeItemTemplate";
        public const string PluginVersion = "1.0.0";

        private static ItemDef itemDef;

        public static AssetBundle assetBundle;

        public const string bundleName = "itemBundle";

        public static PluginInfo PInfo { get; private set; }

        public static string AssetBundlePath => System.IO.Path.Combine(Path.GetDirectoryName(PInfo.Location), "assetBundle");

        public void Awake()
        {
            PInfo = ((BaseUnityPlugin)this).Info;
            assetBundle = AssetBundle.LoadFromFile(AssetBundlePath);
            itemDef = Addressables.LoadAssetAsync<ItemDef>((object)"*itemPath*").WaitForCompletion();
            itemDef.pickupIconSprite = assetBundle.LoadAsset<Sprite>("Assets/icon.png");

        }

    }
}
