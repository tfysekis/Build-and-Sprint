using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController playerController;
    public int objects;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        if (gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("obj",PlayerPrefs.GetInt("obj")+1);
        }

    }
}
