/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using System.Collections.Generic;
using UnityEngine;

namespace UnrealFPS
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class FPController : MonoBehaviour
    {
        [SerializeField]private bool isWalking;
        [SerializeField]private float walkSpeed;
        [SerializeField]private float runSpeed;
        [SerializeField]private float runstepLengthen;
        [SerializeField]private float jumpSpeed;
        [SerializeField]private float stickToGroundForce;
        [SerializeField]private float gravityMutiplier;
        [SerializeField]private Camera cam;
        [SerializeField]private NGMouseLook mouseLook;
        [SerializeField] private FPCrouch fPCrouch=new FPCrouch();

        private bool lockMovement;
        private float fpSpeed;
        private bool jump;
        private bool jumping;
        private float wasWalkSpeed;
        private float yRotation;
        private Vector2 input;
        private Vector3 moveDir = Vector3.zero;
        private Vector3 originalCameraPosition;
        private AudioSource audioSource;
        private CharacterController characterController;
        private Rigidbody rigid;
        protected virtual void Start()
        {
            wasWalkSpeed = walkSpeed;
            originalCameraPosition = cam.transform.localPosition;
            jumping = false;
            characterController = GetComponent<CharacterController>();
            audioSource = GetComponent<AudioSource>();
            rigid = GetComponent<Rigidbody>();
            mouseLook.Init(transform,cam.transform);
            fPCrouch.Init(transform, characterController);
        }
        protected virtual void Update()
        {
            if (lockMovement) return;//如果锁定移动，直接返回
            RotateView();

            fPCrouch.UpdateCrouch();
            if (!jump)
            {
                jump = Input.GetButtonDown("Jump");
            }
        }
        protected virtual void FixedUpdate()
        {
            if (lockMovement) return;
            float speed;
            GetInput(out speed);
            if (true)
            {
                //总是沿着摄像机向前移动，因为它是瞄准它的方向。 
                Vector3 desiredMove = transform.forward * input.y + transform.right * input.x;

                //为被触摸的表面取一个常态以沿着它移动 
                RaycastHit hitInfo;
                Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hitInfo, 
                    characterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
                desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

                moveDir.x = desiredMove.x * speed;
                moveDir.z = desiredMove.z * speed;

                if (characterController.isGrounded)
                {
                    moveDir.y = -stickToGroundForce;
                    if (jump)
                    {
                        moveDir.y = jumpSpeed;
                        jump = false;
                        jumping = true;
                    }
                }
                else
                {
                    moveDir += Physics.gravity * gravityMutiplier * Time.fixedDeltaTime;
                }
                characterController.Move(moveDir*Time.fixedDeltaTime);
            }
        }
        private void GetInput(out float speed)
        {
            //读取输入
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            bool wasWalking = isWalking;
            isWalking = !Input.GetKey(KeyCode.LeftShift);

            //设置步行或跑步所需的速度 
            walkSpeed = fPCrouch.IsCrouch?fPCrouch.Speed:wasWalkSpeed;
            speed = (isWalking || (vertical < 0) || (horizontal != 0)||fPCrouch.IsCrouch) ? walkSpeed : runSpeed;
            input = new Vector2(horizontal,vertical);
            fpSpeed = speed;
            //如果组合长度超过1，则输入正常化
            if (input.sqrMagnitude>1)
            {
                input.Normalize();
            }
        }
        /// <summary>
        /// Player Rotation Handler
        /// </summary>
        private void RotateView()
        {
            mouseLook.LookRotation(transform, cam.transform);
        }
        public bool IsRunning
        {
            get { return fpSpeed == runSpeed ? true : false; }
        }
        public FPCrouch FPCrouch
        {
            get { return fPCrouch; }
        }
    }
}
