using EFT;
using EFT.InventoryLogic;

namespace DefaultAutoFireMode
{
    internal static class FireModeUtil
    {
        internal static bool TryApplyAutoFireMode(Player.FirearmController controller, string source)
        {
            if (!Plugin.Enabled.Value || controller == null)
                return false;

            var player = controller._player;
            if (player == null || !player.IsYourPlayer)
                return false;

            var weapon = controller.Item;
            if (weapon == null)
                return false;

            if (weapon.MalfState.State != Weapon.EMalfunctionState.None)
                return false;

            if (weapon.WeapFireType.Length <= 1)
                return false;

            var fireModeComponent = weapon.FireMode;
            var currentMode = fireModeComponent.FireMode;
            var targetMode = fireModeComponent.GetForceAutoFireMode();
            if (currentMode == targetMode)
                return false;

            fireModeComponent.SetFireMode(targetMode);

            var animator = controller.FirearmsAnimator;
            if (animator != null)
                animator.SetFireMode(targetMode, true);

            if (Plugin.DebugLog.Value)
            {
                Plugin.Log.LogInfo(
                    $"[{source}] {weapon.ShortName}: {currentMode} -> {targetMode}");
            }

            return true;
        }
    }
}
