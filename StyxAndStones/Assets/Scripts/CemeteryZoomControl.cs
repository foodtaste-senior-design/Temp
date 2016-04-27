using UnityEngine;
using System.Collections;

public class CemeteryZoomControl : MonoBehaviour
{

    public float zoomSize = 7.5f;
    private SimplePlatformController player;
    public GameObject background;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<SimplePlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z") || Input.GetButton("Fire2"))
        {
            if ((zoomSize < 28f))
            {
                // Scale camera up
                zoomSize += 0.45f;
                background.gameObject.transform.localScale += new Vector3(0.12f, 0.12f, 0); ;
                background.gameObject.transform.position += new Vector3(0.05f, -0.28f, 0); ;
                GetComponent<Camera>().transform.position += new Vector3(0.05f, -0.28f, 0);
                
            }
        }

        else
        {
            if (zoomSize > 7.5f)
            {
                // Scale background back down
                zoomSize -= 0.45f;
                background.gameObject.transform.localScale -= new Vector3(0.12f, 0.12f, 0);
                background.gameObject.transform.position -= new Vector3(0.05f, -0.28f, 0); ;

                GetComponent<Camera>().transform.position -= new Vector3(0.05f, -0.28f, 0);
            }

        }

        GetComponent<Camera>().orthographicSize = zoomSize;



    }

}
