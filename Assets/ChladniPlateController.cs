using UnityEngine;

public class ChladniPlateController : MonoBehaviour
{
    public Material chladniMaterial;
    public float minA = -0.5f;
    public float maxA = 0.5f;
    public float b = 0.56f;
    public float a = -0.3f;
    public float N = 3;
    public float M = 9;

    public float scrollSpeed = 1.0f;
    public float pulseSpeed = 1.0f;
    public float Sensitivity = 1.0f;

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
        // Update N and M based on mouse scroll while holding down left or right mouse button
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            N += (int)Input.mouseScrollDelta.y * Sensitivity;
        }
        else if (Input.GetMouseButton(1)) // Right mouse button
        {
            M += (int)Input.mouseScrollDelta.y * Sensitivity;
        }

        // Pulse the 'a' value
        PulseA();

        // Update the other values based on the Chladni formulas
        UpdateChladniValues();

        // Update shader properties
        UpdateChladniShaderProperties();
    }

    void PulseA()
    {
        // Pulse 'a' between minA and maxA using Mathf.PingPong and Mathf.Lerp
        float t = Mathf.PingPong(Time.time * pulseSpeed, 1.0f);
        a = Mathf.Lerp(minA, maxA, t);
    }

    void UpdateChladniValues()
    {
        // Calculate the other values based on the Chladni formulas
        // You can modify this part based on your specific requirements
        b = -a * Mathf.Sin(Mathf.PI * N / M) / Mathf.Sin(Mathf.PI * M / N);
    }

    void UpdateChladniShaderProperties()
    {
        chladniMaterial.SetFloat("_A", a);
        chladniMaterial.SetFloat("_B", b);
        chladniMaterial.SetFloat("_N", N);
        chladniMaterial.SetFloat("_M", M);
    }
}










