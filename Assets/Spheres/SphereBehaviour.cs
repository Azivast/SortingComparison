using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SphereBehaviour : MonoBehaviour {
    private SpriteRenderer sr;
    
    private Vector3 direction = Vector3.down;
    private float speed = 1f;

    private Color normalColor = Color.white;
    private Color highlightColor = Color.yellow;

    private bool highlighted = false;

    public Vector2 Direction {
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
    
    private void FixedUpdate() {
        transform.position += direction * speed; // No deltaTime since it would affect timing results?
    }
}
