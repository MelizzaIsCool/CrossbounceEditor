using UnityEngine;

public class Bounciness : MonoBehaviour
{
    public float objectBounciness;
    public void Start()
    {
        //sets the bounciness in the inspector to the colliders bounciness
        GetComponent<Collider2D>().sharedMaterial.bounciness = objectBounciness;
    }
}
