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
        private PlayerInventory playerInventory;
        private Vector3 def;
        private Dictionary<string, bool> states;
        private bool[] stateValue;
        private string[] stateName;

        private void Start()
        {
            animator = GetComponent<Animator>();
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
            
        }
        /// <summary>
        /// Initializing the state
        /// </summary>
        /// <returns></returns>
        protected virtual string[] InitStates()
        {
            return new string[11] {"Idle", "Walk", "Run", "Fire", "Sight", "Reload", "Fall", "Jump", "TakeOut", "Crouch", "TakeUp" };
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