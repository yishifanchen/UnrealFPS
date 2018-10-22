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
    [RequireComponent(typeof(Animator))]
    public class FPSBody : MonoBehaviour
    {
        [SerializeField] private float default_Y;
        [SerializeField] private float crouch_Y;
        private FPController controller;
        private Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
            controller = transform.root.GetComponent<FPController>();
        }
        void Update()
        {
            float speed = Input.GetAxis("Vertical");
            float direction = Input.GetAxis("Horizontal");
            float amount = Mathf.Clamp01(Mathf.Abs(speed) + Mathf.Abs(direction));
            if (amount > 0)
            {
                if (controller.IsRunning)
                    speed = 2;
                animator.SetFloat("Speed",speed);
                animator.SetFloat("Direction", direction);
            }

            animator.SetBool("IsCrouching",controller.FPCrouch.IsCrouch);
            float fixedVerticalPosition;
            if(controller.FPCrouch.IsCrouch)
                fixedVerticalPosition = Mathf.MoveTowards(transform.localPosition.y,crouch_Y,7*Time.deltaTime);
            else
                fixedVerticalPosition = Mathf.MoveTowards(transform.localPosition.y, default_Y, 7 * Time.deltaTime);
            transform.localPosition = new Vector3(transform.localPosition.x,fixedVerticalPosition,transform.localPosition.z);
        }
        private void OnAnimatorIK(int layerIndex)
        {
            
        }
    }
}
