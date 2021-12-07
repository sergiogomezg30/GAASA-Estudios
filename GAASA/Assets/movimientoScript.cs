using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    Vector2 clickPos;
    bool moving;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
          
        }

        if (moving && (Vector2)transform.position != clickPos)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            clickPos, speed * Time.deltaTime);
        }

        else
        {
            moving = false;
        }
    }
}
