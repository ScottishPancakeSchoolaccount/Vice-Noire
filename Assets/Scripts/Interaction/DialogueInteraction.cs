using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueInteraction : MonoBehaviour
{

    public Text InteractionText;

    float InteractionDistance = 5f;

    public bool CanInteract = true;

    public InputManager fpsController;
    public PlayerLook cameralook;

    //Look at 
    public CinemachineVirtualCamera PlayerVcam;
    public CinemachineVirtualCamera TalkZoomVcam;

    void Start()
    {

    }

    void Update()
    {

        if (CanInteract == true)
        {
            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit1;

            if (Physics.Raycast(ray1, out hit1, InteractionDistance))
            {
                if (hit1.collider.CompareTag("Talkable"))
                {
                    InteractionText.text = "Talk";

                    //To talk
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        CanInteract = false;
                        StartCoroutine(TalkToPerson());
                    }
                }
                else
                {
                    InteractionText.text = "";
                }
            }
            else
            {
                InteractionText.text = "";
            }
        }

    }

    IEnumerator TalkToPerson()
    {
        InteractionText.text = "";

        fpsController.enabled = false;
        TalkZoomVcam.enabled = true;
        PlayerVcam.enabled = false;

        yield return new WaitForSeconds(5f);

        fpsController.enabled = true;
        PlayerVcam.enabled = true;
        TalkZoomVcam.enabled = false;

        CanInteract = true;
    }
}
