using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform meleeAttackPos, distanceAttackPos;
    public LayerMask whatIsEnemies;
    public float meleeAttackRange;
    public Vector3 distanceAttackSize;
    public float damage;


    private void Awake()
    {
        timeBtwAttack  = startTimeBtwAttack;
    }

    private void Update()
    {
        timeBtwAttack -= Time.deltaTime;
    }
    public void MeleeAttack()
    {
        if(timeBtwAttack <= 0)
        {
            Debug.Log("meleeAttack");
            Collider[] enemiesToDamge = Physics.OverlapSphere(meleeAttackPos.position, meleeAttackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamge.Length; i++)
            {
                enemiesToDamge[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
    }

    public void DistanceAttack()
    {
        if (timeBtwAttack <= 0)
        {
            Debug.Log("meleeAttack");
            Collider[] enemiesToDamge = Physics.OverlapBox(distanceAttackPos.position, distanceAttackSize, distanceAttackPos.rotation, whatIsEnemies);
            for (int i = 0; i < enemiesToDamge.Length; i++)
            {
                enemiesToDamge[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(meleeAttackPos.position, meleeAttackRange);
        Gizmos.DrawWireCube(distanceAttackPos.position, distanceAttackSize);
    }
}
