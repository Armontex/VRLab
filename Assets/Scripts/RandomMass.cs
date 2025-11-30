using UnityEngine;

public class RandomMass : MonoBehaviour
{
    [SerializeField] private float minMass = 0.1f;
    [SerializeField] private float maxMass = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null )
        {
            rb.mass = Random.Range(minMass, maxMass);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
