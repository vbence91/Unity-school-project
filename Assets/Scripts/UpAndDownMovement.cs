using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    [SerializeField]private float amp;
    [SerializeField]private float freq;
    private Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPosition.x, Mathf.Sin(Time.time * freq) * amp + initPosition.y, 0);
    }
}
