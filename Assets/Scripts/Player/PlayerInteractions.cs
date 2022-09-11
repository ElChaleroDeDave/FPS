using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public Transform startPosition;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun Ammo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;


            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("DeathFloor"))
        {
            GameManager.Instance.LoseHealth(50);
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.LoseHealth(5);

        }
    }

}