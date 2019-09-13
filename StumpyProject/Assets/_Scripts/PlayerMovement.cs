using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity - new Vector2((1 / speed) * Time.deltaTime, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10);
        }
    }
}
