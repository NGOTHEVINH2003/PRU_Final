using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera MainCamera;
    public Transform p1;
    public Transform p2;

    private float minOrthographicSize = 9.0f;
    private float maxOrthographicSize = 13.0f;

    public float zoomSpeed = 1.0f;
    private void LateUpdate()
    {
        if(p1 != null && p2 != null)
        {
            FollowPlayers();
            AdjustCameraSize();
        }
    }
    private void AdjustCameraSize()
    {
        float distanceBetweenPlayers = Mathf.Abs(p1.position.x - p2.position.x);
        float targetOrthographicSize = Mathf.Clamp(distanceBetweenPlayers * zoomSpeed,minOrthographicSize,maxOrthographicSize);

        MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, targetOrthographicSize, Time.deltaTime);
    }


    private void FollowPlayers()
    {
        float xpos = (p1.position.x + p2.position.x)/2f;
        Vector3 viewpos = new Vector3(xpos, transform.position.y,transform.position.z) ;
        
        transform.position = viewpos;
    }
}
