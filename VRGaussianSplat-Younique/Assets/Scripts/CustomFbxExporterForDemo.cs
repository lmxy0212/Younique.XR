using UnityEngine;
using System;
using System.Collections;
using TinyGiantStudio.Text;

namespace UnLogickFactory
{
    public class CustomFbxExporterForDemo : MonoBehaviour
    {
        public GameObject saveText;
        public bool enableExport = false;
        public GameObject objectToExport;
        public GameObject tag;

        public string customExportName = "CustomExportedModel";
        void Update()
        {
            if (enableExport && objectToExport != null)
            {
                StartCoroutine(ExportFbx());
                enableExport = false;
            }
        }

        IEnumerator ExportFbx()
        {
            tag.transform.parent = objectToExport.transform;

            GameObject copy = Instantiate(objectToExport);

            //tag.transform.parent = copy.transform;

            copy.transform.position = Vector3.zero;
            copy.transform.rotation = Quaternion.Euler(-90, 0, 180);
            copy.transform.localScale = Vector3.one;
            copy.GetComponent<SnappablePlate>().isSnaped = false;

            string exportPath = $"C: \\Users\\lmxyi\\Dropbox\\Younique\\{customExportName}.fbx";
        

         Transform[] transforms = { copy.transform };

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

                // Perform export asynchronously if possible
                yield return null; // This line simulates the asynchronous behavior
                FbxExporter.Export(filename, settings, transforms);

#if UNITY_EDITOR
                UnityEditor.AssetDatabase.Refresh(UnityEditor.ImportAssetOptions.ForceSynchronousImport);
                UnityEditor.EditorGUIUtility.PingObject(UnityEditor.AssetDatabase.LoadMainAssetAtPath(filename));
#endif
                Debug.Log("Custom Fbx Exporter - Export Done");
                saveText.SetActive(true);

                // Wait for 5 seconds before hiding the saveText
                yield return new WaitForSeconds(5);
                saveText.SetActive(false);
            }
            else
            {
                Debug.LogError("Custom Fbx Exporter - No filename specified");
            }

            //Destroy(copy);
        }

        void OnFbxNodeCallback(Transform transform, IntPtr fbxNode) { }
        void OnFbxMeshCallback(Transform transform, IntPtr fbxNode, MeshRenderer meshRenderer, IntPtr fbxMesh) { }
        void OnFbxTerrainCallback(Transform transform, IntPtr fbxNode, Terrain terrain, IntPtr fbxMesh) { }
        void OnFbxSkinnedMeshCallback(Transform transform, IntPtr fbxNode, SkinnedMeshRenderer skinnedMeshRenderer, IntPtr fbxMesh) { }
        void OnFbxMaterialCallback(Transform transform, IntPtr fbxNode, IntPtr fbxMaterial, IntPtr[] fbxTextures) { }
    }
}
