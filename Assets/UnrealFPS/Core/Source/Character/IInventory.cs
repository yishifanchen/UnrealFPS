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
    /// <summary>
    /// Interface describing the architecture of the inventory
    /// 描述库存结构的接口
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// 添加武器
        /// </summary>
        void AddWeapon(Weapon weapon);
        /// <summary>
        /// 扔掉武器
        /// </summary>
        void DropWeapon(Weapon weapon);
        /// <summary>
        /// 通过id激活武器
        /// </summary>
        /// <param name="id"></param>
        void ActivateWeapon(string id);
        /// <summary>
        /// 通过id消灭武器
        /// </summary>
        /// <param name="id"></param>
        void DeactivateWeapon(string id);
        /// <summary>
        /// Get weapon by unique identifier
        /// 通过唯一标识符获取武器 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Transform GetWeapon(string id);
        /// <summary>
        /// Get weapon by index in FPCamera child
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Transform GetWeapon(int index);
        /// <summary>
        /// Get current active weapon
        /// </summary>
        /// <returns></returns>
        Transform GetActiveWeapon();
    }

}
