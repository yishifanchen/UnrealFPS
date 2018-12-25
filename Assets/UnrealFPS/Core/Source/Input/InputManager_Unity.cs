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
    public partial class InputManager : MonoBehaviour
    {
        public static Vector3 acceleration { get { return Input.acceleration; } }
        public static int accelerationEventCount { get { return Input.accelerationEventCount; } }
        public static AccelerationEvent[] accelerationEvents { get { return Input.accelerationEvents; } }
        public static bool anyKey { get { return Input.anyKey; } }
        public static bool anyKeyDown { get { return Input.anyKeyDown; } }
        public static Compass compass { get { return Input.compass; } }
        public static string compositionString { get { return Input.compositionString; } }
        public static DeviceOrientation deviceOrientation { get { return Input.deviceOrientation; } }
        public static Gyroscope gyro { get { return Input.gyro; } }
        public static bool imeIsSelected { get { return Input.imeIsSelected; } }
        public static string inputString { get { return Input.inputString; } }
        public static LocationService location { get { return Input.location; } }
        public static Vector2 mousePosition { get { return Input.mousePosition; } }
        public static bool mousePresent { get { return Input.mousePresent; } }
        public static bool touchSupported { get { return Input.touchSupported; } }
        public static int touchCount { get { return Input.touchCount; } }
        public static Touch[] touches { get { return Input.touches; } }
        public static bool compensateSensors
        {
            get { return Input.compensateSensors; }
            set { Input.compensateSensors = value; }
        }
        public static Vector2 compositionCursorPos
        {
            get { return Input.compositionCursorPos; }
            set { Input.compositionCursorPos = value; }
        }
        public static IMECompositionMode imeCompositionMode
        {
            get { return Input.imeCompositionMode; }
            set { Input.imeCompositionMode = value; }
        }
        public static bool multiTouchEnabled
        {
            get { return Input.multiTouchEnabled; }
            set { Input.multiTouchEnabled = value; }
        }
        public static AccelerationEvent GetAccelerationEvent(int index)
        {
            return Input.GetAccelerationEvent(index);
        }
        //public static float GetAxis(string name,)
    }
}
