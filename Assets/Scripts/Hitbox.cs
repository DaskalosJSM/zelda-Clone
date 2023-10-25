using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float weaponDamage;
    public float Potenciator;
     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStateMachine>().TakeDamage(weaponDamage,Potenciator);
        }
        
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Animator>().Play("Pain", 0, 0f);
        }
        
    }
}
