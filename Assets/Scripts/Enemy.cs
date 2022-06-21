using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyDeathVFX;
    [SerializeField] ParticleSystem enemyHitVFX;
    [SerializeField] int amountToAdd = 10;
    [SerializeField] int hitPoints;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Awake() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void Start()
    {
        AddRigidbody();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        DestroyEnemy();
    }

    void DestroyEnemy()
    {
        if(hitPoints <= 0)
        {
            ParticleSystem vfx = Instantiate(enemyDeathVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            scoreBoard.IncreaseScore(amountToAdd);
            Destroy(gameObject);
        }
    }

    void ProcessHit()
    {   
        ParticleSystem vfx = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
    }
}
