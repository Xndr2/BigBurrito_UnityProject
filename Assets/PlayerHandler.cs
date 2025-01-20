using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public DefaultPlayer defaultPlayer; // drag and drop the DefaultPlayer GameObject here, from the inspector
    public SpherePlayer spherePlayer; // drag and drop the SpherePlayer GameObject here
    private bool isDefaultPlayer = true; // a variable to keep track of which player is active

    void Start()
    {
        defaultPlayer.Show(); // show the default player on startup
        spherePlayer.Hide(); // hide the sphere player on startup
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // if the left shift key is pressed
        {
            if (isDefaultPlayer) // if the default player is active
            {
                defaultPlayer.Hide(); // hide the default player
                spherePlayer.Show(); // show the sphere player
                isDefaultPlayer = false; 
            }
            else
            {
                defaultPlayer.Show();
                spherePlayer.Hide();
                isDefaultPlayer = true;
            }
        }
    }
}
