using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSlide : MonoBehaviour
{

    private Vector3 target_position;
    // Start is called before the first frame update
    void Start()
    {
        target_position = transform.position;
        transform.position = target_position + new Vector3(-10,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target_position, 4 * Time.deltaTime);
    }
}
