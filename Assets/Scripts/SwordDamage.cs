using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    private AudioSource audioSource;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                audioSource.Play();
                enemy.TakeDamage();
            }
        }
    }
}
