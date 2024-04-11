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
            string exportPath = $"D:\\Dropbox\\Dropbox\\Younique\\{customExportName}.fbx"; // Construct the export path.

            Transform[] transforms = { objectToExport.transform }; // Prepare the transform array.

            Debug.Log("Custom Fbx Exporter - Starting export");

#if UNITY_EDITOR
            var filename = exportPath;
#else
            var filename = customExportName + ".fbx"; // Use only the file name in runtime if needed.
#endif

            if (!string.IsNullOrEmpty(filename))
            {
                var settings = new FbxExportSettings();
                settings.textureScheme = FbxTextureExportScheme.GetDefaultScheme();
                // Define callbacks as needed or reuse existing ones.
                settings.OnFbxNodeCreated = OnFbxNodeCallback;
                settings.OnFbxMeshCreated = OnFbxMeshCallback;
                settings.OnFbxTerrainCreated = OnFbxTerrainCallback;
                settings.OnFbxSkinnedMeshCreated = OnFbxSkinnedMeshCallback;
                settings.OnFbxMaterialCreated = OnFbxMaterialCallback;
                // Assuming logLevel is a part of FbxExportSettings and is relevant.
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
        }

        // Callbacks are reused from the provided example. You might want to adjust or extend these based on your export needs.
        void OnFbxNodeCallback(Transform transform, IntPtr fbxNode) { /* Your custom logic here */ }
        void OnFbxMeshCallback(Transform transform, IntPtr fbxNode, MeshRenderer meshRenderer, IntPtr fbxMesh) { /* Your custom logic here */ }
        void OnFbxTerrainCallback(Transform transform, IntPtr fbxNode, Terrain terrain, IntPtr fbxMesh) { /* Your custom logic here */ }
        void OnFbxSkinnedMeshCallback(Transform transform, IntPtr fbxNode, SkinnedMeshRenderer skinnedMeshRenderer, IntPtr fbxMesh) { /* Your custom logic here */ }
        void OnFbxMaterialCallback(Transform transform, IntPtr fbxNode, IntPtr fbxMaterial, IntPtr[] fbxTextures) { /* Your custom logic here */ }
    }
}
