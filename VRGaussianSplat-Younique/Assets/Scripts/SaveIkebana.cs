using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveIkebana : MonoBehaviour
{
    public GameObject currentIkebana;
    public bool saveCurrentIkebana;
    public string objName;

    public void Update()
    {
        if (saveCurrentIkebana)
        {
            SaveObj(objName);
        }
    }
    public void SaveObj(string objName)
    {
        StringBuilder objStringBuilder = new StringBuilder();

        objStringBuilder.AppendLine("# Exported from Unity");

        // Counter for the global index of vertices
        int vertexIndexOffset = 1;

        foreach (MeshFilter meshFilter in currentIkebana.GetComponentsInChildren<MeshFilter>())
        {
            Mesh mesh = meshFilter.sharedMesh;

            // Transform vertices from local space to world space and then to the object's space
            foreach (Vector3 vertex in mesh.vertices)
            {
                Vector3 worldVertex = meshFilter.transform.TransformPoint(vertex);
                objStringBuilder.AppendLine(string.Format("v {0} {1} {2}", worldVertex.x, worldVertex.y, worldVertex.z));
            }

            // Export UVs
            foreach (Vector2 uv in mesh.uv)
            {
                objStringBuilder.AppendLine(string.Format("vt {0} {1}", uv.x, uv.y));
            }

            // Export normals
            foreach (Vector3 normal in mesh.normals)
            {
                Vector3 worldNormal = meshFilter.transform.TransformDirection(normal);
                objStringBuilder.AppendLine(string.Format("vn {0} {1} {2}", worldNormal.x, worldNormal.y, worldNormal.z));
            }

            // Export faces
            for (int i = 0; i < mesh.triangles.Length; i += 3)
            {
                int vertex1 = mesh.triangles[i] + vertexIndexOffset;
                int vertex2 = mesh.triangles[i + 1] + vertexIndexOffset;
                int vertex3 = mesh.triangles[i + 2] + vertexIndexOffset;
                objStringBuilder.AppendLine(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", vertex1, vertex2, vertex3));
            }

            vertexIndexOffset += mesh.vertices.Length;
        }

        // Save the generated OBJ string to a file
        Debug.Log(Application.persistentDataPath);
        string filePath = Path.Combine(Application.persistentDataPath, objName);
        File.WriteAllText(filePath, objStringBuilder.ToString());

        Debug.Log("Ikebana model saved to " + filePath);
    }
}
