/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEngine;
using System.Collections;

namespace UnrealFPS
{
    public enum ReloadType { Default,Sequential}

    public class WeaponReloadSystem : MonoBehaviour
    {
        [SerializeField]private ReloadType reloadType;
        [SerializeField]private int bulletCount;
        [SerializeField]private int clipCount;
        [SerializeField]private int maxBulletCount;
        [SerializeField]private int maxClipCount;
        //Default
        [SerializeField]private float reloadTime;
        [SerializeField]private float emptyReloadTime;
        //Sequential
        [SerializeField]private float startTime;
        [SerializeField] private float iterationTime;
        private bool isReloading;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        public int BulletCount
        {
            get { return bulletCount; }
            set
            {
                if (value <= maxBulletCount)
                    bulletCount = value;
                else
                    bulletCount = maxBulletCount;
            }
        }
    }
}