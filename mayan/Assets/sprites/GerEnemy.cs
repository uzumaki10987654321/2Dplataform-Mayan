using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerEnemy : MonoBehaviour
{
    public Transform ePosSpawn;
    public GameObject e1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    void Gerador()
    {
        Instantiate(e1,ePosSpawn.position,Quaternion.identity);
    }
    IEnumerator timer(int tempo = 6)
    {
        yield return new WaitForSeconds(tempo);
        Gerador();
        StartCoroutine(timer());
    }
}
