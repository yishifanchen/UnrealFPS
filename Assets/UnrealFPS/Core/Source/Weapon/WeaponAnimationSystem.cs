/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEngine;
using System.Collections.Generic;

namespace UnrealFPS
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAnimationSystem : MonoBehaviour
    {
        [SerializeField]private float amount = 0.02f;
        [SerializeField]private float maxAmount = 0.03f;
        [SerializeField]private float smooth = 3;
        [SerializeField]private float smoothRotation = 2;
        [SerializeField]private float tiltAngle = 2;
        [SerializeField]private float staticY;
        [SerializeField]private float maxYPosJump;
        [SerializeField]private float smoothJump;
        [SerializeField]private float smoothLand;
        [SerializeField] private bool useSway;

        private Animator animator;
        private CharacterController characterController;
        private WeaponReloadSystem weaponReloadSystem;
        private PlayerInventory playerInventory;
        private Vector3 def;
        private Dictionary<string, bool> states;
        private bool[] stateValue;
        private string[] stateName;

        private void Start()
        {
            animator = GetComponent<Animator>();
            weaponReloadSystem = GetComponent<WeaponReloadSystem>();
            characterController = transform.root.GetComponent<CharacterController>();
            playerInventory = transform.root.GetComponent<PlayerInventory>();
            def = transform.localPosition;
            stateName = InitStates();
            stateValue = new bool[stateName.Length];
            stateValue[8] = false;
            stateValue[10] = true;
        }
        private void Update()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)//按下上下左右键   跑
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0)//按下跑，左右键没有按下，前键按下   走
                {
                    animator.SetInteger("Movement", 2);
                    stateValue[2] = true;
                    stateValue[1] = false;
                }
                else
                {
                    animator.SetInteger("Movement", 1);
                    stateValue[1] = true;
                    stateValue[2] = false;
                    stateValue[0] = false;
                }
            }
            else if (!Input.GetMouseButtonDown(0)&&!Input.GetButton("Jump")&&!stateValue[6])//站立
            {
                animator.SetInteger("Movement", 0);
                stateValue[0] = true;
                stateValue[1] = false;
            }

            //Fire
            if (Input.GetButtonDown("Fire")&&!weaponReloadSystem.BulletsIsEmpty)
            {
                stateValue[3] = true;
            }
        }
        /// <summary>
        /// Initializing the state
        /// </summary>
        /// <returns></returns>
        protected virtual string[] InitStates()
        {
            return new string[11] {"Idle", "Walk", "Run", "Fire", "Sight", "Reload", "Fall", "Jump", "TakeOut", "Crouch", "TakeUp" };
            //站立，行走，跑，开火，瞄准，装弹，倒下，跳，扔下，蹲下，拿起
        }
        /// <summary>
        /// Current Active state
        /// </summary>
        public string ActiveState
        {
            get
            {
                for (int i = 0; i < stateValue.Length; i++)
                    if (stateValue[i])
                        return stateName[i];
                return "No active state";
            }
        }
    }
}