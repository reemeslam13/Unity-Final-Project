using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingStones : MonoBehaviour
{
    public GameObject r;
    public GameObject w;
    public Transform t;
    int randTime;
    GameObject rock;
    GameObject wall;
    bool oRock = false;
    int randObst;
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
            randObst = (int)Random.Range(0, 2);
            if (randObst == 0)
                createObstWall();
            else
            {
               oRock= true;
                createRockObst();
            }

            randTime -= 1;
        }
        if(rock!=null){
            if (rock.transform.position.y < 1)
            {
                Destroy(rock);
                randTime = (int)Random.Range((int)Time.time + 5, (int)Time.time + 25);
                Debug.Log(randTime);
                oRock = false;
            }
        }
        else if(wall!=null){
            if (t.position.z > wall.transform.position.z + 3)
            {
                Destroy(wall);
                randTime = (int)Random.Range((int)Time.time + 5, (int)Time.time + 25);
                Debug.Log(randTime);

            }
        }
        else if(oRock && rock==null){
            randTime = (int)Random.Range((int)Time.time + 5, (int)Time.time + 25);
            Debug.Log(randTime);
            oRock = false;
        }

    }


    void  createRockObst(){
        rock = Instantiate(r) as GameObject;
        rock.tag = "Rock";
        rock.transform.position = new Vector3(t.position.x,9, t.position.z);
    }
    void createObstWall()
    {
        wall = Instantiate(w) as GameObject;
        wall.tag = "Wall";
        wall.transform.position = new Vector3(t.position.x, 2.16f, t.position.z+2);
    }

}
