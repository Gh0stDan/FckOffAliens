using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds; //items
    private float[] parallaxScales; //proportions
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;


    private void Awake()
    {
        cam = Camera.main.transform; 
    }
    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1; //go backwards
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++) //parallax is opposite of teh cam movement becuase the previous frame mult by scale
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 BackgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, BackgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPos = cam.position;
    }
}
