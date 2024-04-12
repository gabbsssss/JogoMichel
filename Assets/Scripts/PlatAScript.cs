using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class PlatAScript : MonoBehaviour
{
    [SerializeField] private GameObject Alvo;
    [SerializeField] private GameObject posA, posB;
    [SerializeField] private float velMov;

    private void Start()
    {
        posA = GameObject.Find("PosA");
        posB = GameObject.Find("PosB");
        Alvo = posA;


    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Alvo.transform.position, velMov * Time.deltaTime);

        if (Vector2.Distance(transform.position, Alvo.transform.position) <= 0.1f)
        {
            Alvo = posB;
        }

        if (Vector2.Distance(transform.position, Alvo.transform.position) <= 0.1f)
        {
            Alvo = posA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
