using UnityEngine;

public class ChladniVal : MonoBehaviour
{
    public Material chladniMaterial;
    public float a = 1.0f;
    public float b = 1.0f;
    public float n = 1.0f;
    public float m = 1.0f;

    void Start()
    {
        if (chladniMaterial == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                chladniMaterial = renderer.material;
            }
            else
            {
                Debug.LogError("Chladni material not assigned and no Renderer component found.");
                return;
            }
        }

        UpdateChladniShaderProperties();
    }

    void Update()
    {
        // You can update the values based on your logic here
        // For example, you can use Time.time to create an animation effect

        // Example: Update n and m based on time
        //n = Mathf.Sin(Time.time);
        //m = Mathf.Cos(Time.time);

        // Update shader properties
        UpdateChladniShaderProperties();
    }

    void UpdateChladniShaderProperties()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 vertex = vertices[i];
                float x = vertex.x;
                float y = vertex.y;

                float value = CalculateChladniValue(x, y);
                vertices[i].z = value;
            }

            mesh.vertices = vertices;
            mesh.RecalculateNormals();
        }

        chladniMaterial.SetFloat("_A", a);
        chladniMaterial.SetFloat("_B", b);
        chladniMaterial.SetFloat("_N", n);
        chladniMaterial.SetFloat("_M", m);
    }

    float CalculateChladniValue(float x, float y)
    {
        // Use the Chladni plate formula to calculate the vertex height
        return a * Mathf.Sin(Mathf.PI * x * n) * Mathf.Sin(Mathf.PI * y * m) + b * Mathf.Sin(Mathf.PI * x * m) * Mathf.Sin(Mathf.PI * y * n);
    }
}

