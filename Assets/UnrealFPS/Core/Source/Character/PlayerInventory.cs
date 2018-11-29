/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnrealFPS
{
    /// <summary>
    /// 武器划分
    /// </summary>
    [Serializable]
    public struct WeaponCompartment
    {
        public Weapon weapon;
        public KeyCode key;
    }
    [Serializable]
    public struct InventoryGroup
    {
        public string name;
        public List<WeaponCompartment> weaponCompartments;
    }
    public class PlayerInventory : MonoBehaviour, IInventory
    {
        [SerializeField]private Transform fpsCamera;
        [SerializeField]List<InventoryGroup> inventoryGroups = new List<InventoryGroup>();

        private bool isSelect;

        private void Update()
        {
            if(Input.anyKeyDown)
                SelectWeaponByKey();

            if (Input.GetButtonDown("Fire1") && GetActiveWeapon() != null)
                DropWeapon(GetActiveWeapon().GetComponent<WeaponIdentifier>().Weapon);
        }
        public void AddWeapon(Weapon weapon)
        {
            for(int i = 0; i < inventoryGroups.Count; i++)
            {
                if (inventoryGroups[i].name == weapon.Group)
                {
                    for(int j = 0; j < inventoryGroups[i].weaponCompartments.Count; j++)
                    {
                        if (inventoryGroups[i].weaponCompartments[j].weapon == null)
                        {
                            WeaponCompartment weaponCompartment = new WeaponCompartment
                            {
                                weapon = weapon,
                                key = inventoryGroups[i].weaponCompartments[j].key
                            };
                            inventoryGroups[i].weaponCompartments[j] = weaponCompartment;
                        }
                    }

                    if (GetActiveWeapon() == null)
                        return;

                    string curGroup = GetActiveWeapon().GetComponent<WeaponIdentifier>().Weapon.Group;

                    if (weapon.Group == curGroup)
                    {
                        for (int j = 0; j < inventoryGroups[i].weaponCompartments.Count; j++)
                        {
                            if (inventoryGroups[i].weaponCompartments[j].weapon == GetActiveWeapon().GetComponent<WeaponIdentifier>().Weapon)
                            {
                                WeaponCompartment weaponCompartment = new WeaponCompartment
                                {
                                    weapon = weapon,
                                    key = inventoryGroups[i].weaponCompartments[j].key
                                };
                                inventoryGroups[i].weaponCompartments[j] = weaponCompartment;
                                StartCoroutine(OnElementDrop(inventoryGroups[i].weaponCompartments[j].weapon));
                                return;
                            }
                        }
                    }
                    else
                    {
                        WeaponCompartment weaponCompartment = new WeaponCompartment
                        {
                            weapon = weapon,
                            key = inventoryGroups[i].weaponCompartments[inventoryGroups[i].weaponCompartments.Count - 1].key
                        };
                        inventoryGroups[i].weaponCompartments[inventoryGroups[i].weaponCompartments.Count - 1] = weaponCompartment;
                        StartCoroutine(OnElementDrop(GetActiveWeapon().GetComponent<WeaponIdentifier>().Weapon));
                        return;
                    }
                }
            }
        }

        public void DropWeapon(Weapon weapon)
        {
        }
        /// <summary>
        /// activate weapon by id
        /// </summary>
        /// <param name="id"></param>
        public void ActivateWeapon(string id)
        {
            for(int i = 0; i < fpsCamera.childCount; i++)
            {
                if (fpsCamera.GetChild(i).CompareTag("Weapon"))
                {
                    Transform weapon = fpsCamera.GetChild(i);
                    if (weapon.GetComponent<WeaponIdentifier>() != null && weapon.GetComponent<WeaponIdentifier>().Weapon.Id == id)
                        weapon.gameObject.SetActive(true);
                    else
                        weapon.gameObject.SetActive(false);
                }
            }
        }
        /// <summary>
        /// Deactivate weapon by id 
        /// </summary>
        /// <param name="id"></param>
        public void DeactivateWeapon(string id)
        {
            for(int i = 0; i < fpsCamera.childCount; i++)
            {
                if (fpsCamera.GetChild(i).CompareTag("Weapon"))
                {
                    Transform weapon = fpsCamera.GetChild(i);
                    if (weapon.GetComponent<WeaponIdentifier>().Weapon.Id == id)
                        weapon.gameObject.SetActive(false);
                }
            }
        }
        public void DeactivateAllWeapon()
        {
            for(int i = 0; i < fpsCamera.childCount; i++)
            {
                if (fpsCamera.GetChild(i).CompareTag("Weapon"))
                    fpsCamera.GetChild(i).gameObject.SetActive(false);
            }
        }

        public Transform GetWeapon(string id)
        {
            throw new NotImplementedException();
        }

        public Transform GetWeapon(int index)
        {
            throw new NotImplementedException();
        }

        public Transform GetActiveWeapon()
        {
            for(int i = 0; i < fpsCamera.childCount; i++)
            {
                if (fpsCamera.GetChild(i).CompareTag("Weapon") && fpsCamera.GetChild(i).gameObject.activeSelf)
                {
                    return fpsCamera.GetChild(i);
                }
            }
            return null;
        }
        private void SelectWeaponByKey()
        {
            for(int i = 0; i < inventoryGroups.Count; i++)
            {
                for(int j = 0; j < inventoryGroups[i].weaponCompartments.Count; j++)
                {
                    if (Input.GetKeyDown(inventoryGroups[i].weaponCompartments[j].key))
                    {
                        StartCoroutine(OnSelectWeapon(inventoryGroups[i].weaponCompartments[j].weapon));
                    }
                }
            }
        }
        public void SelectWeapon(Weapon weapon)
        {
            StartCoroutine(OnSelectWeapon(weapon));
        }
        public IEnumerator OnSelectWeapon(Weapon weapon)
        {
            isSelect = true;
            yield return new WaitForSeconds(0.1f);
            isSelect = false;
            yield return new WaitForSeconds(0.2f);
            ActivateWeapon(weapon.Id);
            yield break;
        }
        /// <summary>
        /// when weapon droped create weapon gameobject on scene
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        public IEnumerator OnElementDrop(Weapon weapon)
        {
            isSelect = true;
            yield return new WaitForSeconds(0.3f);
            Transform playerWeapon;
            playerWeapon = GetWeapon(weapon.Id);
            playerWeapon.gameObject.SetActive(false);
            Vector3 pos = fpsCamera.position + fpsCamera.forward * 1;
            GameObject dropWeapon = Instantiate(weapon.Drop, pos, Quaternion.identity);
            if (dropWeapon.GetComponent<Rigidbody>())
                dropWeapon.GetComponent<Rigidbody>().AddForce(fpsCamera.forward * 0.5f, ForceMode.Impulse);
        }
    }
}

