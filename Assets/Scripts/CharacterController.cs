using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    public float myHP = 0f;
    public float myStamina = 0f;
    public float staminaMinus = 10f;

    public float power = 0f;
    public float powerMax = 30f;
    public float powerPlus = 10f;
    public float speed = 0f;
    public float angleSpeed = 0f;
    public float stamina = 0f;
    public float movementAxis;
    public float angleAxis;

    public Transform angleTarget;
    public Missile missile;

    public Image UIhp;
    public Image UIpower;
    public Image UIstamina;

    Rigidbody2D rigidbody;

    public SpriteRenderer model;

    private bool isAttack = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UIpower.fillAmount = power / powerMax;
        UIhp.fillAmount = myHP / 100f;
        UIstamina.fillAmount = myStamina / 100f;
    }

    public void PlayerEnter() {
        
    }

    public void PlayerUpdate()
    {

        if (GameManager.isShut) return;

        movementAxis = Input.GetAxis("Horizontal");
        angleAxis = Input.GetAxis("Vertical");

        if(movementAxis != 0f)
        {
            myStamina -= staminaMinus * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = 0f;
            isAttack = true;
            movementAxis = 0f;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            power = Mathf.Clamp(power + powerPlus * Time.deltaTime, 0f, powerMax);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Missile shot = Instantiate(missile, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().AddForce((Vector2)angleTarget.right * power, ForceMode2D.Impulse);
            GameManager.ChangeCameraTarget(shot.transform);
            GameManager.isShut = true;
            isAttack = false;
        }

        // Angle
        angleTarget.Rotate(new Vector3(0f, 0f, angleAxis * angleSpeed * Time.deltaTime));
    }

    public void PlayerFixedUpdate() 
    {
        if (isAttack || GameManager.isShut || myStamina <= 0f) return; 
        // Movement
        Vector2 newPos = new Vector2(movementAxis, 0f);
        rigidbody.MovePosition((Vector2)transform.position + newPos * Time.deltaTime * speed);
    }

    public void PlayerExit() {

    }

    public void ResetStat()
    {
        myStamina = 100f;
    }

    public void Hit(float damage)
    {
        myHP -= damage;
        if (myHP <= 0f)
        {
            myHP = 0f;
            this.gameObject.SetActive(false);
            GameManager.UnityCall();
        }
    }

}
