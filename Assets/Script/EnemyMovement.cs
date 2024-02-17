using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    private Transform player; // Referência para o player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Jogador não encontrado na cena!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direcao = player.position - transform.position;
            direcao.Normalize(); 
            transform.Translate(direcao * enemySpeed * Time.deltaTime);
        }
    }
}
