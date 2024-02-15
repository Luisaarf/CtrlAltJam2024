using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private float camSmoothing;
    [SerializeField]private Transform target;
    [SerializeField]private float xOffset, yOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      //  transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), camSmoothing);
    }
}
