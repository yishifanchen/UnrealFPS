/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEngine;
using System;


namespace UnrealFPS
{
    [Serializable]
    public class NGMouseLook
    {
        [Range(0.0f, 50.0f)] public float XSensitivity = 2f;
        [Range(0.0f, 50.0f)] public float YSensitivity = 2f;
        [Range(-360.0f, 360.0f)] public float MinimumX = -90F;
        [Range(-360.0f, 360.0f)] public float MaximumX = 90F;
        [Range(0.0f,50.0f)]public float smoothTime = 5f;
        [HideInInspector]public Quaternion characterTargetRot;
        [HideInInspector]public Quaternion cameraTargetRot;
        public bool clampVerticalRotation = true;
        public bool smooth;
        public bool lockCursor = true;
        public bool cursorIsLocked = true;

        /// <summary>
        /// 初始化人物和摄像机的旋转
        /// </summary>
        /// <param name="character"></param>
        /// <param name="camera"></param>
        public void Init(Transform character,Transform camera)
        {
            characterTargetRot = character.localRotation;
            cameraTargetRot = camera.localRotation;
        }
        /// <summary>
        /// 控制人物和摄像机的旋转
        /// </summary>
        /// <param name="character"></param>
        /// <param name="camera"></param>
        public void LookRotation(Transform character,Transform camera)
        {
            float yRot = Input.GetAxis("Mouse X") * XSensitivity;
            float xRot = Input.GetAxis("Mouse Y") * YSensitivity;
            characterTargetRot *= Quaternion.Euler(0,yRot,0);
            cameraTargetRot *= Quaternion.Euler(-xRot, 0, 0);

            if (clampVerticalRotation)
                cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);

            if (smooth)
            {
                character.localRotation = Quaternion.Slerp(character.localRotation, characterTargetRot, smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp(camera.localRotation, cameraTargetRot, smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = characterTargetRot;
                camera.localRotation = cameraTargetRot;
            }
            UpdateCursorLock();
        }
        /// <summary>
        /// 设置光标锁定
        /// </summary>
        /// <param name="value">是否锁定</param>
        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if (!lockCursor)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        private void UpdateCursorLock()
        {
            if (lockCursor)
                InternalLockUpdate();
        }
        /// <summary>
        /// 内部锁定更新
        /// </summary>
        private void InternalLockUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorIsLocked = true;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                cursorIsLocked = true;
            }
            if (cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if(!cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        /// <summary>
        /// 限制上下旋转角度
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }
    }
}

