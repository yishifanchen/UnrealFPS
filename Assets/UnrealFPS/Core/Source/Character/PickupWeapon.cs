/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEngine;
using UnityEngine.UI;

namespace UnrealFPS
{
    [System.Serializable]
    public class PickupWeapon
    {
        [SerializeField]private float radius;
        [SerializeField]private bool destroyOnPickUp;

        private Transform player;
        private PlayerInventory playerInventory;
        private float lastDistance;
        private WeaponIdentifier weaponID;

        public void Init(Transform player, PlayerInventory playerInventory)
        {
            this.player = player;
            this.playerInventory = playerInventory;
            lastDistance = radius;
        }
        public void Handler()
        {
            Collider[] colliders = Physics.OverlapSphere(player.position, radius);
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.CompareTag("Weapon"))
                {
                    Transform weapon = colliders[i].transform;
                    lastDistance = Vector3.Distance(player.position,weapon.position);
                    if(Vector3.Distance(player.position, weapon.position) <= lastDistance)
                    {
                        weaponID = colliders[i].GetComponent<WeaponIdentifier>();
                    }
                }
            }
            if(weaponID!=null)
            {
                ShowWeaponInfo(weaponID.Weapon.DisplayName);
                //todo  后期统一修改
                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerInventory.AddWeapon(weaponID.Weapon);
                    playerInventory.SelectWeapon(weaponID.Weapon);
                    if (destroyOnPickUp) { Object.Destroy(weaponID.Weapon.Drop); }
                    HideWeaponInfo();
                }
            }
            if (lastDistance > radius)
            {
                HideWeaponInfo();
                weaponID = null;
            }
        }
        private void ShowWeaponInfo(string message)
        {
            //todo
        }
        private void HideWeaponInfo()
        {
            //todo
        }
    }
}

