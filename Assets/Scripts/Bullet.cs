using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed =20f;
    public float lifeDuration = 3f;
    float lifeTimer;

    public bool shooByPlayer;

    private void OnEnable()
    {
        lifeTimer = lifeDuration;
    }

    private void Update()
    {

        lifeTimer -=Time.deltaTime;
        if(lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet choca = " + other.name);
        bool remove = true;
        IDamage damage = other.GetComponent<IDamage>();
        if(damage != null)
        {
            damage.DoDamage(10, shooByPlayer);
        }
       if(remove == true) gameObject.SetActive(true);

    }

}
