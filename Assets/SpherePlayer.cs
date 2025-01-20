using UnityEngine;
using UnityEngine.UIElements;

public class SpherePlayer : MonoBehaviour
{
    // we add this so we can reference it in the inspector without making it public
    // making it public would allow other scripts to change it
    [SerializeField]
    private Camera camera; // only this value will be "serialized" in the inspector
    private bool isHidden = false; // this value can be used to check if the sphere is hidden, before doing any logic
    private MeshRenderer meshRenderer;
    private CharacterController cr;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        cr = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (isHidden) return;

        // do your ball logic here
        cr.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * 30);

        // apply gravity
        cr.Move(Vector3.down * Time.deltaTime * 9.81f);
    }

    public void Hide() // Hide the sphere player
    {
        meshRenderer.enabled = false;
        camera.enabled = false;
        camera.GetComponent<AudioListener>().enabled = false; // Disable audio listener to remove warning in console
        isHidden = true;
    }

    public void Show()
    {
        meshRenderer.enabled = true;
        camera.enabled = true;
        camera.GetComponent<AudioListener>().enabled = true; // Enable audio listener
        isHidden = false;
    }
}
