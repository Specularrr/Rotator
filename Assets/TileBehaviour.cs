using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{

    public float labelOffset = 1.0f;

    private Transform tile;
    BoxCollider2D col;

    Vector3 zAxis = new Vector3(0, 0, 1);

    // Use this for initialization
    void Start()
    {
        tile = transform;
        col = tile.GetComponent<BoxCollider2D>();
        //GenerateTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (col.OverlapPoint(mousePosition))
            {
                Debug.Log("Collider clicked!");
                StartCoroutine(RotateMe(zAxis * -90, 1.0f));
            }
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = tile.rotation;
        var toAngle = Quaternion.Euler(tile.eulerAngles + byAngles - new Vector3(0,0,0.529f));
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            tile.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        
    }

    void GenerateTile()
    {
        Vector3 northSidePos = new Vector3(tile.position.x, tile.position.y + labelOffset, tile.position.z);
        Vector3 eastSidePos = new Vector3(tile.position.x + labelOffset, tile.position.y, tile.position.z);
        Vector3 southSidePos = new Vector3(tile.position.x, tile.position.y - labelOffset, tile.position.z);
        Vector3 westSidePos = new Vector3(tile.position.x - labelOffset, tile.position.y, tile.position.z);
    }
}
