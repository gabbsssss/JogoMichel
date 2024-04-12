using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private float tempoParaCair;
    [SerializeField] private float tempoParaVoltar;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.transform);
            StartCoroutine(DelayParaCair());

        }
    }

    IEnumerator DelayParaCair()
    {
        yield return new WaitForSeconds(tempoParaCair);
        rig.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(DelayParaVoltar());
    }

    IEnumerator DelayParaVoltar()
    {
        yield return new WaitForSeconds(tempoParaVoltar);
        rig.bodyType = RigidbodyType2D.Kinematic;
        rig.velocity = new Vector2(rig.velocity.x, 0);
        transform.localPosition = new Vector2(11.8966f, -0.9051f);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }


}
