using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PrefabCreator : MonoBehaviour
{
    public bool createPrefab = false; // Control the prefab creation with this boolean.
    public GameObject specificGameObject; // Assign this in the inspector to the specific GameObject you want to save.
    public string customPrefabName = "CustomName"; // Set the custom name for your prefab here.

    void Update()
    {
        // Check if we should create the prefab.
        if (createPrefab)
        {
            CreateSpecificPrefab();
            createPrefab = false; // Reset the flag to prevent continuous prefab creation.
        }
    }

    void CreateSpecificPrefab()
    {
#if UNITY_EDITOR
        if (specificGameObject != null)
        {
            // Create folder Prefabs if it doesn't exist and set the path within the Prefabs folder.
            if (!Directory.Exists("Assets/Prefabs"))
                AssetDatabase.CreateFolder("Assets", "Prefabs");
            string localPath = $"Assets/Prefabs/{customPrefabName}.prefab";

            // Make sure the file name is unique, in case an existing Prefab has the same name.
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

            // Create the new Prefab and log whether Prefab was saved successfully.
            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAsset(specificGameObject, localPath, out prefabSuccess);
            if (prefabSuccess)
                Debug.Log($"Prefab '{customPrefabName}' was saved successfully");
            else
                Debug.Log($"Failed to save prefab '{customPrefabName}'");
        }
#endif
    }
}
