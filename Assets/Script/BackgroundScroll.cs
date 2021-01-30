using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPosition;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        previousCamPosition = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        previousCamPosition = cam.position;
    }

        /*public Player character;

        public float parallaxSpeed = 0.1f;

        private float old_pos;

        private Vector2 movement;


        // Start is called before the first frame update
        void Start()
        {
            old_pos = character.transform.position.x;
        }

        // Update is called once per frame
        void Update()
        {

            if (character.x > 0)
            {
                movement = new Vector2(character.speed * parallaxSpeed * -1, 0);
                movement *= Time.deltaTime;
                transform.Translate(movement);
                print("moving right");
            }
            if (character.x < 0)
            {
                movement = new Vector2(character.speed * parallaxSpeed, 0);
                movement *= Time.deltaTime;
                transform.Translate(movement);
                print("moving left");
            }
            old_pos = character.transform.position.x;

            /*
            if(character.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            {
                Debug.Log("IS MOVING");
            }

        }*/
    }
