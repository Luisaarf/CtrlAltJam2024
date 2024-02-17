using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private Camera mainCamera;
    Vector3 positionCamera ;
    // Start is called before the first frame update
    void Start()
    {
        positionCamera = mainCamera.transform.position;
        InvokeRepeating("Spawn", 0f, 10f);
    }

    void Spawn()
    {
        Instantiate(enemy, new Vector3(positionCamera.x + 5, positionCamera.y + 5, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
