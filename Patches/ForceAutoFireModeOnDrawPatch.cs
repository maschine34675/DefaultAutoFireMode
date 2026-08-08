using EFT;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace DefaultAutoFireMode.Patches
{
    internal class ForceAutoFireModeOnDrawPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(Player.FirearmController),
                nameof(Player.FirearmController.SetAnimatorValues));
        }

        [PatchPostfix]
        static void Postfix(Player.FirearmController __instance)
        {
            FireModeUtil.TryApplyAutoFireMode(__instance, "OnDrawInit");
        }
    }
}
