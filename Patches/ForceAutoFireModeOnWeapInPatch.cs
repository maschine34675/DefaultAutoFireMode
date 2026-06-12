using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace DefaultAutoFireMode.Patches
{
    internal class ForceAutoFireModeOnWeapInPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(Player.FirearmController), "IEventsConsumerOnWeapIn");
        }

        [PatchPostfix]
        static void Postfix(Player.FirearmController __instance)
        {
            FireModeUtil.TryApplyAutoFireMode(__instance, "OnWeapIn");
        }
    }
}
