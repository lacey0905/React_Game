using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    Rigidbody2D rigidbody;
    public GameObject eftEnemy;
    public LayerMask layerMask;

    public float damage = 0f;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((layerMask.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            Vector3 newPos;
            if(collision.gameObject.tag != "Floor")
            {
                newPos = new Vector3(collision.transform.position.x, collision.transform.position.y, -10f);
            }
            else
            {
                newPos = new Vector3(transform.position.x, transform.position.y, -10f);
            }

            if (collision.gameObject.tag == "Enemy")
            {
                collision.GetComponent<CharacterController>().Hit(damage);
            }

            Instantiate(eftEnemy, newPos, Quaternion.identity);
            this.gameObject.SetActive(false);
            Invoke("Remove", 1.5f);

            
        }
    }

    private void Remove()
    {
        GameManager.ChangeCameraTarget(GameManager.PlayerStatic.transform);
        Destroy(this.gameObject);
        GameManager.isShut = false;
    }

}
