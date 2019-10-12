using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Position Variables")]
    public Transform target;
    public float smoother;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header("Animator")]
    public Animator anim;

    [Header("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    // Start is called before the first frame update
    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;

        anim = GetComponent <Animator>();
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }

    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoother);
        }
    }

    public void BeginKick()
    {
        anim.SetBool("kickActive", true);
        StartCoroutine(KickCo());
    }

    public IEnumerator KickCo()
    {
        yield return new WaitForSeconds(0.13f);
        anim.SetBool("kickActive", false);
    }
}
