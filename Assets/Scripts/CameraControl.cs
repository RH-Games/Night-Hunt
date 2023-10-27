using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Character;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Character.transform.position.x +2, Character.transform.position.y +1 , transform.position.z);
    }
}
