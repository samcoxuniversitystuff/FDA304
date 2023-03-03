using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    [SerializeField] private GameObject p1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(p1, transform.position, quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
