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

    public float Distance;

    public Vector3 Direction {
        get => direction;
        set => direction = value;
    }
    public float Speed {
        get => speed;
        set => speed = value;
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
    }

    public void CalcDistance(Vector3 targetPos) {
        distance = (transform.position - targetPos).magnitude;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        direction = Vector2.Reflect(direction, other.contacts[0].normal); //TODO: composite normal from all contacts
    }
}
