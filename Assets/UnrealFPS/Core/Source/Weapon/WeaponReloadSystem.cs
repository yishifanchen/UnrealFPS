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
        [SerializeField] private float iterationTime;//重复反复
        private bool isReloading;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)&&!ClipsIsEmpty)
            {
                isReloading = true;
                switch (reloadType)
                {
                    case ReloadType.Default:
                        DefaultReload();
                        break;
                    case ReloadType.Sequential:
                        SequentialReload();
                        break;
                }
            }
        }
        /// <summary>
        /// 重新计算弹药数量
        /// </summary>
        public virtual void ReCalculateAmmo()
        {
            if (clipCount >= maxBulletCount)
            {
                clipCount -= (maxBulletCount - bulletCount);
                bulletCount = maxBulletCount;
            }
            else if(clipCount<maxBulletCount)
            {
                bulletCount = clipCount + bulletCount;
                clipCount = 0;
            }
        }
        public virtual void DefaultReload()
        {
            if (!BulletsIsEmpty)
                StartCoroutine(Reload(reloadTime));
            else
                StartCoroutine(Reload(emptyReloadTime));
        }
        public virtual void SequentialReload()
        {
            StartCoroutine(Reload(CalculateMaxTime(bulletCount, maxBulletCount, startTime, iterationTime)));
        }
        /// <summary>
        /// calculate bullet and clip count after a specified time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerator Reload(float time)
        {
            yield return new WaitForSeconds(time);
            ReCalculateAmmo();
            isReloading = false;
            yield break;
        }
        /// <summary>
        /// Calculates the maximum time required for recharging
        /// </summary>
        /// <param name="bulletCount"></param>
        /// <param name="maxBulletCount"></param>
        /// <param name="startTime"></param>
        /// <param name="interationTime"></param>
        /// <returns></returns>
        public virtual float CalculateMaxTime(float bulletCount,float maxBulletCount,float startTime,float iterationTime)
        {
            float totalTime;
            float requiredBullet = maxBulletCount - bulletCount;
            totalTime = iterationTime * requiredBullet;
            totalTime += startTime;
            return totalTime;
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
        public int MaxClipCount
        {
            get { return maxClipCount; }
            set { maxClipCount = value; }
        }
        /// <summary>
        /// 弹夹是否为空
        /// </summary>
        public bool ClipsIsEmpty
        {
            get
            {
                return clipCount <= 0;
            }
        }
        public bool BulletsIsEmpty
        {
            get
            {
                return bulletCount <= 0;
            }
        }
    }
}