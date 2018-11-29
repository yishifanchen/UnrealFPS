/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */
using UnityEngine;

namespace UnrealFPS
{
    public class WeaponIdentifier : MonoBehaviour
    {
        [SerializeField] Weapon weapon;

        public Weapon Weapon { get { return weapon; } }
    }
}
