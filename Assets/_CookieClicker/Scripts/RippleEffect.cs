using UnityEngine;

public class RippleEffect : MonoBehaviour
{
    public Material rippleMaterial;
    public float rippleStrength = 10f;
    public float rippleSpeed = 5f;

    private Vector3 rippleOrigin;
    private float timeOffset;

    void Start()
    {
        if (rippleMaterial == null)
        {
            Debug.LogError("Ripple material not assigned!");
        }
    }

    void Update()
    {
        // Update shader properties
        rippleMaterial.SetVector("_RippleOrigin", rippleOrigin);
        rippleMaterial.SetFloat("_RippleStrength", rippleStrength);
        rippleMaterial.SetFloat("_RippleSpeed", rippleSpeed);
        rippleMaterial.SetFloat("_TimeOffset", timeOffset);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Get the point of impact
        rippleOrigin = collision.contacts[0].point;
        // Reset the time offset to start the ripple effect
        timeOffset = Time.time;
    }
}