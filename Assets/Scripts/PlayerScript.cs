using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript:MonoBehaviour
{
    #region variaveis
    private Rigidbody2D rig;
    private Vector2 movHorizontal;
    [SerializeField] private bool pdpula;
    [SerializeField] private float velPlayer;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float forcaBatida;
    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region move horizontal
        movHorizontal = new Vector2 (Input.GetAxisRaw("Horizontal") * velPlayer, rig.velocity.y);

        rig.velocity = movHorizontal;
        #endregion

        #region pular
        if (Input.GetAxis("Vertical")  > 0 && Input.GetButtonDown("Vertical") && pdpula)
        {
            rig.AddForce( new Vector2 (rig.velocity.x, forcaPulo), ForceMode2D.Impulse);
            pdpula = false;
        }
        #endregion

        if (Input.GetAxis("Vertical") < 0 && Input.GetButtonDown("Vertical"))
        {
            rig.AddForce(new Vector2(rig.velocity.x, forcaBatida), ForceMode2D.Impulse);
        }
    }

    #region verificar se ta no chao
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            pdpula = true;
        }
    }
    #endregion
}
