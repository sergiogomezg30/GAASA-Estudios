using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestructScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    public int tiempo = 3;

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(tiempo, gameObject));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(tiempo);
        obj.SetActive(false);
    }

}
