using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject squarePrefab;
    GameObject[] squareArray = new GameObject[8];
    public float maxScale;
    public float posSens = 1f;

    public float widthSquares = 10f;
    void Start()
    {
        for(int i = 0; i<8; i++)
        {
            GameObject thesquare = (GameObject)Instantiate(squarePrefab);
            thesquare.transform.position = this.transform.position +  Vector3.right * posSens * i; ;
            thesquare.transform.parent = this.transform;
            thesquare.name = "Square" + i;
            squareArray[i] = thesquare;
        }
    }

    void Update()
    {
        for(int i = 0; i < 8; i++)
        {
            if(squareArray != null)
            {
                squareArray[i].transform.localScale = new Vector3(widthSquares, (AudioPeer.bandBuffer[i] * maxScale) + 2, 0);
            }
        }
    }
}
