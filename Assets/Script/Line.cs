using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private float moveSpeed = 1000f;
    private float minX = -620f;
    private float maxX = 620f;
    private float direction;

    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        direction = Input.GetAxisRaw("Horizontal");

        float moveStep = moveSpeed * direction * Time.deltaTime;

        float newX = Mathf.Clamp(transform.position.x + moveStep, minX, maxX);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
