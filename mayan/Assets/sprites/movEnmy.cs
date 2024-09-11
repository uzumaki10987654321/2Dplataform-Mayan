using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movEnmy : MonoBehaviour
{
    public float speed;

    public GameObject municao;
    public Transform posicaoTiro;
    public float velocidadeTiro;
    public int delay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
        Destroy(gameObject,6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (transform.position.x-speed * Time.deltaTime,transform.position.y);
    }
    IEnumerator Delay(int tempo = 2)
    {
        yield return new WaitForSeconds (delay);
        Tiro();
        Debug.Log("Foi");
        StartCoroutine(Delay());
    }


    void Tiro()
    {
        GameObject temporario = Instantiate(municao);
        temporario.transform.position = posicaoTiro.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mun")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }



}
