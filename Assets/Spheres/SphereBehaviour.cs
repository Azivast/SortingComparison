using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class SphereBehaviour : MonoBehaviour {
    private SpriteRenderer sr;

    
    private Vector3 direction = Vector3.down;
    private Vector3 initialDirection;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float speedVariety = 1f;

    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;

    private bool highlighted = false;
    private Vector2 movementRestriction;
    private const float deltaTimeSubtitute = 1 / 60f;

    [HideInInspector] public float Distance;

    public Vector3 Direction {
        get => direction;
        set => direction = value;
    }

    public Vector3 MovementSpace {
        set => movementRestriction = value/2;
    }

    public bool Highlighted {
        get => highlighted;
        set
        {
            sr.color = value == true ? highlightColor : normalColor;
            highlighted = value;
        }

    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Setup(Vector2 movementSpace)
    {
        movementRestriction = movementSpace;
        direction = Random.insideUnitCircle.normalized;
        speed = Random.Range(speed-speedVariety, speed+speedVariety);
        initialDirection = direction;
    }
    
    public void Move() {
        transform.position += direction * (speed * deltaTimeSubtitute);
        CheckCollision();
    }

    public void CalcDistance(Vector3 targetPos) {
        Distance = (targetPos-transform.position).sqrMagnitude; // sqr more effective, order will be the same
    }

    private void CheckCollision()
    {
        if (Math.Abs(transform.position.x) > movementRestriction.x)
        {
            direction.x = -direction.x;
        }
        if (Math.Abs(transform.position.y) > movementRestriction.y)
        {
            direction.y = -direction.y;
        }
    }

    public void Reset()
    {
        direction = initialDirection;
        transform.position = Vector3.zero;
    }
}
