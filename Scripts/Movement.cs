using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool speedIncreased = false;
    // Update is called once per frame
    void Update()
    {
        if (MenuManager.instance.currentScore > 50 && !speedIncreased)
        {
            speed++;
            speedIncreased = true; // Set the flag to true to indicate that the speed has been increased
        }
        transform.position += Vector3.down * speed * Time.deltaTime;

    }
}
