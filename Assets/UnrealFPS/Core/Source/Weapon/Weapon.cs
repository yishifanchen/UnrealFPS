/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using UnityEngine;
using System;
using UnityEngine.UI;

namespace UnrealFPS
{
    [Serializable]
    public class Weapon : ScriptableObject
    {
        [SerializeField] private string id = Guid.NewGuid().ToString();
        [SerializeField] private string displayName;
        [SerializeField] private string description;
        [SerializeField] private string group;
        [SerializeField] private int space;
        [SerializeField] private Sprite image;
        [SerializeField] private GameObject drop;

        public string Id { get { return id; } set { id = value; } }
        public string DisplayName { get { return displayName; } set { displayName = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Group { get { return group; }set { group = value; } }
        public int Space { get { return space; } set { space = value; } }
        public Sprite Image { get { return image; } set { image = value; } }
        public GameObject Drop { get { return drop; }set { drop = value; } }
    }
}

