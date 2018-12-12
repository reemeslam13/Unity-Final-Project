using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingStones : MonoBehaviour
{
    public GameObject g;
    public Transform t;
    int randTime;
    GameObject rock;
    // Use this for initialization
    void Start()
    {
        randTime = (int)Random.Range((int)Time.time + 1, (int)Time.time + 20);
        Debug.Log(randTime);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (randTime == (int)Time.time)
        {
            createRockObst();
        }

    }
   

    void  createRockObst(){
        rock = Instantiate(g) as GameObject;
        rock.tag = "Rock";
        rock.transform.position = new Vector3(t.position.x,9, this.t.position.z);
        randTime = (int)Random.Range((int)Time.time + 5, (int)Time.time + 25);
        Debug.Log(randTime);

    }
}
