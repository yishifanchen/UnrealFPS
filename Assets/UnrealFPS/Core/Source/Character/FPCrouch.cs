/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */
using System;
using UnityEngine;

namespace UnrealFPS
{
    [Serializable]
    public class FPCrouch 
    {
        [SerializeField]private float speed;
        [SerializeField] private float smooth;
        [SerializeField] private float crouchHeight;

        private Transform player;
        private CharacterController characterController;
        private float wasControllerHeight;
        private bool isCrouch;

        public void Init(Transform player,CharacterController characterController)
        {
            this.player = player;
            this.characterController = characterController;
            wasControllerHeight = characterController.height;
        }
        public void UpdateCrouch()
        {
            float fpHeight = wasControllerHeight;
            isCrouch = Input.GetKey(KeyCode.LeftControl);

            if (isCrouch)
                fpHeight = wasControllerHeight * crouchHeight;


        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public bool IsCrouch
        {
            get { return isCrouch; }
            set { isCrouch = value; }
        }
        public float CrouchHeight
        {
            get { return crouchHeight; }
            set { crouchHeight = value; }
        }
        public float Smooth { get { return smooth; } }
    }
}

