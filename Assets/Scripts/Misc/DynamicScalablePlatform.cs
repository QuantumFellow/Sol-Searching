using UnityEngine;

public class DynamicScalablePlatform : MonoBehaviour
{
    public float scrollSensitivity = 1.0f;
    public float sensitivity = 1f;
    public float interactionDistance = 3f;
    public GameObject player;
    public Vector3 minScale = new Vector3(1f, 1f, 1f);
    public Vector3 maxScale = new Vector3(5f, 5f, 5f);
    public float smoothness = 0.1f;
    public float decayFactor = 0.95f;
    public Rigidbody2D playerRigidbody;
    public Vector3 originalScale;


    private bool isLeftMouseButtonDown = false;
    private bool wasLeftMouseButtonDown = false;

    private void Start()
    {
        originalScale = transform.localScale;

        if (player == null)
        {
            FindPlayer();
        }
    }

    private void Update()
    {
        //scroll val
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        //LMB held
        isLeftMouseButtonDown = Input.GetMouseButton(0);

        //if lmb was let go
        bool leftMouseButtonReleased = wasLeftMouseButtonDown && !isLeftMouseButtonDown;

        //scale based on scrll inp
        Vector3 targetScaleChange = Vector3.one + Mathf.Pow(Mathf.Abs(scrollInput), sensitivity) * scrollSensitivity * Vector3.one;

        //interpolate to scale
        Vector3 scaleChange = Vector3.Lerp(Vector3.one, targetScaleChange, smoothness);

        //lmb let go return to og size
        if (leftMouseButtonReleased)
        {
            transform.localScale *= decayFactor;
            transform.localScale = ClampScale(transform.localScale, minScale, maxScale);
        }
        else if (isLeftMouseButtonDown)
        {
            //apply scale
            transform.localScale = Vector3.Scale(transform.localScale, scaleChange);
            transform.localScale = ClampScale(transform.localScale, minScale, maxScale);
        }

        //If player close :
        if (Vector3.Distance(transform.position, player.transform.position) <= interactionDistance)
        {
            //apply scale
            transform.localScale = Vector3.Scale(transform.localScale, scaleChange);
            transform.localScale = ClampScale(transform.localScale, minScale, maxScale);
        }

        //Update scale
        wasLeftMouseButtonDown = isLeftMouseButtonDown;
    }

    public void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject;
            playerRigidbody = player.GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    private Vector3 ClampScale(Vector3 scale, Vector3 min, Vector3 max)
    {
        scale.x = Mathf.Clamp(scale.x, min.x, max.x);
        scale.y = Mathf.Clamp(scale.y, min.y, max.y);
        scale.z = Mathf.Clamp(scale.z, min.z, max.z);
        return scale;
    }
}


