using UnityEngine;
using System;
public class EnemyHealth : MonoBehaviour
{
    //public GameObject ashEffectPrefab; // اسحب هنا الـ Particle System بتاع الرماد
    public float dissolveSpeed = 0.5f;
    private MeshRenderer[] meshRenderers;
    private bool isDead = false;
    private float dissolveAmount = 0;
    public static event Action OnEnemyDied;

    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    // دي الدالة اللي هتناديها لما تضرب العدو
    public void TakeDamage()
    {
        if (isDead) return;
        Die();
    }

    void Die()
    {
        OnEnemyDied?.Invoke();     
        Debug.Log("Hit By Sword");
        isDead = true;
        Destroy(gameObject);
    }
}