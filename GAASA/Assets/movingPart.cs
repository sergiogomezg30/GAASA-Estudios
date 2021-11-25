using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPart : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    Vector3 startPoint;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;

    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;

        //Conections check
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) {

                UpdateWire(collider.transform.position);

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    collider.GetComponent<movingPart>()?.Done();
                    Done();
                }

                return;
            }
        }

        UpdateWire(newPosition);
    }

    void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    void Done()
    {
        Destroy(this);
        
    }

    void UpdateWire(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
