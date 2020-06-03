using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour {

    public GameObject bulletHole;

    private int hitLayeMask;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        hitLayeMask = LayerMask.GetMask(new string[] { "Target", "Decoy", "Background" });
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;

        if (Input.GetButtonDown("Fire1"))
        {
            Collider2D hitColider = Physics2D.OverlapPoint(pos, hitLayeMask);

            if (hitColider != null)
            {
                GameObject newHole =  Instantiate(bulletHole, transform.position, transform.rotation);
                newHole.transform.parent = hitColider.transform;

                int sortorder = (hitColider.transform.GetComponent<SpriteRenderer>()).sortingOrder;
                (newHole.transform.GetComponent<SpriteRenderer>()).sortingOrder = sortorder+1;
                Destroy(newHole, 5);
            }            
        }
    }
}
