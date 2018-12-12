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
    public enum MarkItem { Grab,Ladder,Water,EnterWater}
    public class Marking : MonoBehaviour
    {
        [SerializeField]private MarkItem markItem;
        public MarkItem GetMark()
        {
            return markItem;
        }
        public bool CompareMark(MarkItem mark)
        {
            return (this.markItem == mark);
        }
    }
}
