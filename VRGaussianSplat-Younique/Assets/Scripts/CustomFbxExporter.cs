using UnityEngine;
using System;

// Ensure you have the necessary namespace that includes the FbxExporter and related classes.
namespace UnLogickFactory
{
    public class CustomFbxExporter : MonoBehaviour
    {
        public bool enableExport = false; // Controls whether to export the FBX file.
        public GameObject objectToExport; // GameObject to export.
        public string customExportName = "CustomExportedModel"; // Custom name for the exported FBX file.

        void Update()
        {
            if (enableExport && objectToExport != null)
            {
                ExportFbx();
                enableExport = false;
            }
        }

        void ExportFbx()
        {
            // Make a copy of the GameObject
            GameObject copy = Instantiate(objectToExport);

            // Reset the copy's transform
            copy.transform.position = Vector3.zero;
            copy.transform.rotation = Quaternion.Euler(-90, 0, 0);
            copy.transform.localScale = Vector3.one;

            // Update the path for exporting the copy
            string exportPath = $"D:\\Dropbox\\Dropbox\\Younique\\{customExportName}.fbx";

            Transform[] transforms = { copy.transform }; // Use the copy's transform for exporting

            Debug.Log("Custom Fbx Exporter - Starting export");

#if UNITY_EDITOR
            var filename = exportPath;
#else
            var filename = customExportName + ".fbx";
#endif

            if (!string.IsNullOrEmpty(filename))
            {
                var settings = new FbxExportSettings();
                settings.textureScheme = FbxTextureExportScheme.GetDefaultScheme();
                settings.OnFbxNodeCreated = OnFbxNodeCallback;
                settings.OnFbxMeshCreated = OnFbxMeshCallback;
                settings.OnFbxTerrainCreated = OnFbxTerrainCallback;
                settings.OnFbxSkinnedMeshCreated = OnFbxSkinnedMeshCallback;
                settings.OnFbxMaterialCreated = OnFbxMaterialCallback;
                settings.logLevel = 0;

                FbxExporter.Export(filename, settings, transforms);

#if UNITY_EDITOR
                UnityEditor.AssetDatabase.Refresh(UnityEditor.ImportAssetOptions.ForceSynchronousImport);
                UnityEditor.EditorGUIUtility.PingObject(UnityEditor.AssetDatabase.LoadMainAssetAtPath(filename));
#endif
                Debug.Log("Custom Fbx Exporter - Export Done");
            }
            else
            {
                Debug.LogError("Custom Fbx Exporter - No filename specified");
            }

            // Destroy the copy after exporting
            Destroy(copy);
        }

        void OnFbxNodeCallback(Transform transform, IntPtr fbxNode) { }
        void OnFbxMeshCallback(Transform transform, IntPtr fbxNode, MeshRenderer meshRenderer, IntPtr fbxMesh) { }
        void OnFbxTerrainCallback(Transform transform, IntPtr fbxNode, Terrain terrain, IntPtr fbxMesh) { }
        void OnFbxSkinnedMeshCallback(Transform transform, IntPtr fbxNode, SkinnedMeshRenderer skinnedMeshRenderer, IntPtr fbxMesh) { }
        void OnFbxMaterialCallback(Transform transform, IntPtr fbxNode, IntPtr fbxMaterial, IntPtr[] fbxTextures) { }
    }
}
