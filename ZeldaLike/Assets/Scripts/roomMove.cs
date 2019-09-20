using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomMove : MonoBehaviour
{

    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    public string placeName;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&&other.isTrigger)
        {
            
            cam.maxPosition += cameraChange;
            cam.minPosition += cameraChange;
            other.transform.position += playerChange;
            if(text != null)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        text.GetComponent<Text>().text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
