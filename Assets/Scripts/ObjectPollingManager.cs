using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPollingManager : MonoBehaviour
{
    struct BulletInfo
    {
        public GameObject prefab;
        public Bullet scriptBullet;
    }

    public static ObjectPollingManager instance;
    public GameObject bulletPrefab;
    public int bulletAmount = 5;


    private List<BulletInfo> bullets;

    void Awake()
    {
        instance = this;
        bullets = new List<BulletInfo>(bulletAmount);
        for (int i = 0; i < bulletAmount; i++)
        {
            BulletInfo BPrefab;
            BPrefab.prefab =Instantiate(bulletPrefab);
            BPrefab.prefab.transform.SetParent(transform);
            BPrefab.prefab.SetActive(false);
            BPrefab.scriptBullet = BPrefab.prefab.GetComponent<Bullet>();
            bullets.Add(BPrefab);
            
            //---
            //GameObject prefabInstance = Instantiate(bulletPrefab);
            //prefabInstance.transform.SetParent(transform);
            //prefabInstance.SetActive(false);
            //bullets.Add(prefabInstance);
        }
    }

    public GameObject GetBullet(bool isPlayer)
    {
        int totalBullets = bullets.Count;
        for (int i=0; i<totalBullets; i++)
        {
            if (!bullets[i].prefab.activeInHierarchy)
            {
                bullets[i].prefab.SetActive(true);
                bullets[i].scriptBullet.shooByPlayer  =  isPlayer;

                return bullets[i].prefab;
            }
        }

        BulletInfo BPrefab;
        BPrefab.prefab = Instantiate(bulletPrefab);
        BPrefab.prefab.transform.SetParent(transform);
        BPrefab.prefab.SetActive(true);
        BPrefab.scriptBullet = BPrefab.prefab.GetComponent<Bullet>();
        BPrefab.scriptBullet.shooByPlayer = isPlayer;
        bullets.Add(BPrefab);

        //----
        //GameObject prefabInstance = Instantiate(bulletPrefab);
        //prefabInstance.transform.SetParent(transform);
        //prefabInstance.SetActive(true);
        //bullets.Add(prefabInstance);
        
        
        return BPrefab.prefab;

    }
}
