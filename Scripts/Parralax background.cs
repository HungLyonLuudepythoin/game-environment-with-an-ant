using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralaxbackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffectMultiplayer;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        // Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        // Texture2D texture = sprite.texture;
        // textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplayer;
        lastCameraPosition = cameraTransform.position;

        // if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        // {
        //     float offSetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
        //     transform.position = new Vector3(cameraTransform.position.x + offSetPositionX, transform.position.y);
        // }
    }

}
