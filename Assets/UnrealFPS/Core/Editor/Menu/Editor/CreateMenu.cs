/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEditor;
using UnrealFPS.Utility;

namespace UnrealFPS.Editor
{
    public static class CreateMenu
    {
        [MenuItem("Unreal FPS/Create/Weapon",false,21)]
        public static void CreateWeapon()
        {
            ScritableObjectUtility.CreatAsset<Weapon>();
        }
    }
}