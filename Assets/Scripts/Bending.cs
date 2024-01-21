using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bending : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Rock;
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
            StartCoroutine(Banding_Fire());
        }
    }

    public void Bending_Rock()
    {
        if (Vector3.Distance(Player.transform.position, Fire.transform.position) < 400)
        {
            Rock.transform.position = new Vector2(Player.position.x, Player.position.y);
            Rock.SetActive(true);
        }
    }

    IEnumerator Banding_Fire()
    {
        Fire.transform.position = new Vector2(Player.position.x, Player.position.y);
        Fire.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Fire.transform.position = new Vector2(Player.position.x, Player.position.y);
        Fire.SetActive(false);
    }
}
