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
        }
    }
}
