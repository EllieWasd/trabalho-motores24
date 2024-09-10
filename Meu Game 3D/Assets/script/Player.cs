using System;
 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using  Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour

{

    public int velocidade = 5;
    private Rigidbody rb;
    public int forcaPulo = 3;
    public bool noChao = false;
    void Start()
    {
        Debug.Log("start");
        TryGetComponent(out rb);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (!noChao && collision.gameObject.tag == "chão")
        {
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message:"update");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(x:h, y:0, z:v);
        rb.AddForce(direcao * (velocidade * Time.deltaTime), ForceMode.Impulse);
       
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
            


        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
}