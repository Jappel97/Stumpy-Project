using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject myPlayer;
    

    private void LateUpdate()
    {
        this.gameObject.transform.position = new Vector3(myPlayer.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    
}
