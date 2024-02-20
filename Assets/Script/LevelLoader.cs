using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Vector2 newPosition;
    public Animator anim;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          collision.gameObject.transform.position = LoadNextLevel();
        }
    }

    private Vector2 LoadNextLevel()
    {
        StartCoroutine("LoadLevel");
        return newPosition;
    }

    IEnumerator LoadLevel()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        

    }
}
