using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, IDamage
{

    public Transform posGun;
    public Transform cam;
    public GameObject bulletPrefab;
    public LayerMask ignoreLayer;
    RaycastHit hit;
    public int life = 20;
    public int Municion = 12;

    public GameObject damageEffect;
    public float saveInterval = 0.5f;
    float saveTime;
    WaitForSeconds wait;

    void Start()
    {
        damageEffect.SetActive(false);
        saveTime = 0.0f;
        CanvasController.instance.AddTextHp(life);
        CanvasController.instance.AddTextMunicion(Municion);
        wait = new WaitForSeconds(0.2f);
    }

    private void Update()
    {
        Debug.DrawRay(cam.position, cam.forward * 100f, Color.red);
        Debug.DrawRay(posGun.position, cam.forward * 100f, Color.blue);

        if (Municion > 0 && Input.GetMouseButtonDown(0))
        {

            Vector3 direction = cam.TransformDirection(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), 1));
            Debug.DrawRay(cam.position, direction * 100f, Color.green, 5f);

            //GameObject bulletObj = Instantiate(bulletPrefab);
            GameObject bulletObj = ObjectPollingManager.instance.GetBullet(true);

            bulletObj.transform.position = posGun.position;
            if(Physics.Raycast(cam.position, direction, out hit, Mathf.Infinity, ~ignoreLayer))
            {
                bulletObj.transform.LookAt(hit.point);
            }
            else
            {
                //Vector3 dir = cam.position + cam.forward * 10f;
                Vector3 dir = cam.position + direction * 10f;
                bulletObj.transform.LookAt(dir);
            }
            Municion--;
            CanvasController.instance.AddTextMunicion(Municion);
        }
        saveTime -=Time.deltaTime;
    }

    public void DoDamage(int vld, bool isPlayer)
    {
        Debug.Log("He Recibido Daño = " + vld + "isPlayer = " +isPlayer);
        if (isPlayer);
        else
        {
            if (saveTime <= 0)
            {
                life -= vld;
                CanvasController.instance.AddTextHp(life);
                StartCoroutine(Effect());
            }
          
        }

       

    }
    IEnumerator Effect()
    {
        saveTime = saveInterval;
        damageEffect.SetActive(true);
        yield return wait;
        damageEffect.SetActive(false);
        if(life <=0)
        {
            GameManager.instance.FinGame(false);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        IBox box = other.GetComponent<IBox>();
        if(box != null)
        {
            int res = box.OpenBox();
            if(box.getID() == (int)BoxID.HEALTH)
            {
                life += res;
                CanvasController.instance.AddTextHp(life);
            }
            else if(box.getID() == (int)BoxID.AMMO)
            {

                Municion += res;
                CanvasController.instance.AddTextMunicion(Municion);
            }
            Destroy(other.gameObject);
        }
    }

}
