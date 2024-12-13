using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palladax : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float imageWidth;

    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       float space =  speed * Time.time;
       float spaceRest = space % imageWidth;
       transform.position = initialPosition + spaceRest * direction;
    }
}
