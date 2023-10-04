using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    [SerializeField] private float timer = 5;
    private float bullettime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemyspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bullettime -= Time.deltaTime;

        if (bullettime > 0) return;

        bullettime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemyspeed);
        Destroy(bulletObj, 5f);
    }
}
