using UnityEngine;

public class SpwanBall : MonoBehaviour
{
    public GameObject prefab_Obj;
    public float Spwanspeed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RHand))
        {
            GameObject spwanedBall = Instantiate(prefab_Obj, transform.position, Quaternion.identity);
            Rigidbody spwanedBallRB = spwanedBall.GetComponent<Rigidbody>();
            spwanedBallRB.linearVelocity = transform.forward * Spwanspeed;
        }
    }
}
