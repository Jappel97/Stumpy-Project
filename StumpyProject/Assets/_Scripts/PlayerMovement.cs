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
            this.gameObject.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10);
        }
    }
}
