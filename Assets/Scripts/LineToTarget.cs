using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from:
// https://answers.unity.com/questions/1255334/drawing-a-custom-graphics-line-between-two-objects.html
// https://answers.unity.com/questions/1312246/how-to-set-startwidth-and-endwidth-of-linerenderer.html
public class LineToTarget : MonoBehaviour
{
    public GameObject lineTarget;

    private LineRenderer line; 

    // Start is called before the first frame update
    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0, 0.05f);
        curve.AddKey(1, 0.05f);

        line.widthCurve = curve;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the GameObjects are not null
        if (lineTarget != null) {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, transform.position);
            line.SetPosition(1, lineTarget.transform.position);
        }
    }
}
