// 
// Copyright (c) SunnyMonster
//

using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Rigidbody2D rigidbody;

    public static GravitySwitch instance { get; private set; }

    public bool gravityIsFlipped = false;

    private GUIStyle buttonStyle = new GUIStyle();
    private GUIStyle labelStyle = new GUIStyle();
    private void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        buttonStyle = new GUIStyle("button")
        {
            fontSize = 25
        };
        labelStyle = new GUIStyle("label")
        {
            fontSize = 20,
            alignment = TextAnchor.MiddleCenter
        };
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 180, 80), "Flip Gravity", buttonStyle))
        {
            gravityIsFlipped = !gravityIsFlipped;
            Switch(gravityIsFlipped);
        }
        var labelContent = new GUIContent("Current Gravity: " + (gravityIsFlipped ? "Flipped" : "Normal"));
        var labelSize = labelStyle.CalcSize(labelContent);
        GUI.Label(new Rect(200, 10, labelSize.x, 80), labelContent, labelStyle);
    }

    public void Switch(bool gravityIsFlipped)
    {
        rigidbody.gravityScale = gravityIsFlipped ? -Mathf.Abs(rigidbody.gravityScale) : Mathf.Abs(rigidbody.gravityScale);
        transform.localScale = new Vector3(transform.localScale.x, gravityIsFlipped ? -Mathf.Abs(transform.localScale.y) : Mathf.Abs(transform.localScale.y));
    }
}
