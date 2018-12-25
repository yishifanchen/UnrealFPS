/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnrealFPS.Utility;

namespace UnrealFPS
{
    public abstract class InputController : Singleton<InputController>
    {
        public abstract float GetAxis(string axisName);
        public abstract float GetAxisRaw(string axisName);
        public abstract bool GetButtonDown(string buttonName);
        public abstract bool GetButton(string buttonName);
        public abstract bool GetButtonUp(string buttonName);
    }
}
