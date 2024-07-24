using UnityEngine;

public class MeshRippleEffect : MonoBehaviour
{
    public float rippleStrength = 0.1f;
    public float rippleSpeed = 2f;
    public float rippleFrequency = 1f;
    public float decayFactor = 0.98f;

    private Mesh originalMesh;
    private Mesh deformedMesh;
    private Vector3[] originalVertices;
    private Vector3[] deformedVertices;
    private Vector3 rippleOrigin;
    private bool rippleActive = false;
    private float rippleTime;

    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().mesh;
        deformedMesh = Instantiate(originalMesh);
        GetComponent<MeshFilter>().mesh = deformedMesh;
        originalVertices = originalMesh.vertices;
        deformedVertices = new Vector3[originalVertices.Length];
    }

    void Update()
    {
        if (rippleActive)
        {
            rippleTime += Time.deltaTime;
            for (int i = 0; i < originalVertices.Length; i++)
            {
                Vector3 vertex = originalVertices[i];
                float distance = Vector3.Distance(transform.TransformPoint(vertex), rippleOrigin);
                float wave = Mathf.Sin(distance * rippleFrequency - rippleTime * rippleSpeed) * rippleStrength;
                deformedVertices[i] = vertex + transform.InverseTransformDirection(Vector3.up) * wave;
            }
            deformedMesh.vertices = deformedVertices;
            deformedMesh.RecalculateNormals();
            rippleStrength *= decayFactor; // decay the ripple strength over time

            // Stop the ripple effect after it has decayed enough
            if (rippleStrength < 0.001f)
            {
                rippleActive = false;
                rippleStrength = 0.1f; // reset the ripple strength
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabber"))
        {
            rippleOrigin = other.ClosestPoint(transform.position);
            rippleTime = 0f;
            rippleActive = true;
        }

    }
}