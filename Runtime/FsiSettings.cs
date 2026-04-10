using UnityEngine;

namespace Fsi.Settings
{
    public class FsiSettings<T> : ScriptableObject
        where T : ScriptableObject
    {
        public static T GetOrCreateSettings(string resourcePath, string fullPath)
        {
            T s = Resources.Load<T>(resourcePath);

            #if UNITY_EDITOR
            if (!s)
            {
                if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    UnityEditor.AssetDatabase.CreateFolder("Assets", "Resources");
                }

                if (!UnityEditor.AssetDatabase.IsValidFolder("Assets/Resources/Settings"))
                {
                    UnityEditor.AssetDatabase.CreateFolder("Assets/Resources", "Settings");
                }

                s = CreateInstance<T>();
                UnityEditor.AssetDatabase.CreateAsset(s, fullPath);
                UnityEditor.AssetDatabase.SaveAssets();
            }
            #endif

            return s;
        }
    }
}