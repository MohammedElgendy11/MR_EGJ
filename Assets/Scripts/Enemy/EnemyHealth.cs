using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public GameObject ashEffectPrefab; // اسحب هنا الـ Particle System بتاع الرماد
    public float dissolveSpeed = 0.5f;
    private MeshRenderer[] meshRenderers;
    private bool isDead = false;
    private float dissolveAmount = 0;

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
        Debug.Log("Hit By Sword");
        isDead = true;
        Destroy(gameObject);
    }
}