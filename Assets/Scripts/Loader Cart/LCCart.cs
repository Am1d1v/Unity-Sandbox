using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LCCart : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] List<LCItem> items = new List<LCItem>();

    [Header("Data")]
    [SerializeField] int totalValue;

    [Header("Elements")]
    [SerializeField] Rigidbody rb;

    [Header("Input Actions")]
    [SerializeField] InputActionReference MoveInput;

    private void Update()
    {
        GetInput();

        if (Input.GetKeyDown(KeyCode.C))
        {
            CalculateItemsValue();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        moveDirection.x = MoveInput.action.ReadValue<Vector2>().x;
    }

    void Move()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, 0f);
    }

    void CalculateItemsValue()
    {
        foreach(LCItem item in items)
        {
            totalValue += item.totalValue;
         
            Destroy(item.gameObject);
        }

        items.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<LCItem>(out LCItem item))
        {
            items.Add(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<LCItem>(out LCItem item))
        {
            items.Remove(item);
        }
    }
}