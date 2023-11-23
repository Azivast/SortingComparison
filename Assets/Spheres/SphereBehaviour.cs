using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class SphereBehaviour : MonoBehaviour {
    private SpriteRenderer sr;
    
    private Vector3 direction = Vector3.down;
    private float speed = 0.1f;

    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;

    private bool highlighted = false;
    private float distance;
    private Vector2 movementSpace;

    public float Distance;

    public Vector3 Direction {
        get => direction;
        set => direction = value;
    }
    public float Speed {
        get => speed;
        set => speed = value;
    }
    
    public Vector3 MovementSpace {
        get => movementSpace;
        set => movementSpace = value;
    }

    public bool Highlighted {
        get => highlighted;
        set {
            highlighted = value;
            if (value == true) sr.color = highlightColor;
            else sr.color = normalColor;
        }

    }

    private void Start() {
        direction = Random.insideUnitCircle; //TODO: Randomize with seed
    }
    
    public void Move() {
        transform.position += direction * speed; // TODO: No deltaTime since it would affect timing results?
        CheckCollision();
    }

    public void CalcDistance(Vector3 targetPos) {
        distance = (transform.position - targetPos).magnitude;
    }

    private void CheckCollision() //TODO make pretty
    {
        if (transform.position.x < -movementSpace.x/2)
        {
            direction.x = Mathf.Abs(direction.x);
        }
        else if (transform.position.x > movementSpace.x/2)
        {
            direction.x = -Mathf.Abs(direction.x);
        }
        if (transform.position.y < -movementSpace.y/2)
        {
            direction.y = Mathf.Abs(direction.y);
        }
        else if (transform.position.y > movementSpace.y/2)
        {
            direction.y = -Mathf.Abs(direction.y);
        }
    }
}
