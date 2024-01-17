using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bending : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] GameObject Fire;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BendingController();
    }

    public void BendingController()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Bending_Fire();
        }

        //Bending ranges
        //Fire
        if (Vector3.Distance(Player.transform.position, Fire.transform.position) >= 400)
        {
            Fire.transform.position = new Vector2(Player.position.x, Player.position.y);
            Fire.SetActive(false);
        }
    }

    public void Bending_Fire()
    {
        if (Vector3.Distance(Player.transform.position, Fire.transform.position) < 400)
        {
            Fire.transform.position = new Vector2(Player.position.x, Player.position.y);
            Fire.SetActive(true);
        }
    }
}
