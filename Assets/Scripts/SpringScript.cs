using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig;
    private GameObject playerObjeto;
    [SerializeField] private float forcaPropulsao;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            rig.AddForce(new Vector2 (rig.velocity.x, forcaPropulsao), ForceMode2D.Impulse);
        }
    }
}
