/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */

using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnrealFPS.Utility
{
    public static class ScritableObjectUtility
    {
        public static void CreatAsset<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(T).ToString() + ".asset");
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        public static void CreatAsset<T>(string path,string assetName)where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            string assetPathName = AssetDatabase.GenerateUniqueAssetPath(path+ assetName + ".asset");
            AssetDatabase.CreateAsset(asset,assetPathName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        public static void CreatAsset<T>(string path) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            string assetPathName = AssetDatabase.GenerateUniqueAssetPath(path + typeof(T).ToString()+ ".asset");
            AssetDatabase.CreateAsset(asset, assetPathName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        public static void CreatAsset(string name)
        {
            ScriptableObject asset = ScriptableObject.CreateInstance(name);
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + asset.ToString() + ".asset");
            AssetDatabase.CreateAsset(asset, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        public static void CreatAsset(string name,string path,string assetName)
        {
            ScriptableObject asset = ScriptableObject.CreateInstance(name);
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + assetName + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        public static void CreatAsset(string name, string path)
        {
            ScriptableObject asset = ScriptableObject.CreateInstance(name);
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + asset.ToString() + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        public static void CreatAsset(Behaviour behaviour,string name)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path)!="")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/"+ name + ".asset");
            AssetDatabase.CreateAsset(behaviour, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        public static void CreatAsset(Behaviour behaviour, string name, string path)
        {
            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + name + ".asset");
            AssetDatabase.CreateAsset(behaviour, assetPathAndName);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}