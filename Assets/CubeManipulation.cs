using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CubeManipulation : MonoBehaviour
{
    /*This script is to be placed on the cube that wants to be manipulated
     this script is to also be referenced on all buttons in the UI

    LEGEND for setting direction and coords:

    Accpeted Values for Move and Scale:
     X
    -X
     Y
    -Y
     Z
    -Z

    Accpeted Values for Rotate:
    Left
    Right
    Roll Left
    Roll Right
    Up
    Down

     */

    //value in which everything would be multiplied by for rotation, movement, and scale.
    public int multiplierValue = 1;
    
    //value to disallow zero
    float transformValue;

    private Transform cubeTransform;

    // Start is called before the first frame update
    void Start()
    {
        transformValue = 1 * multiplierValue;
        cubeTransform = this.transform;
    }
    /*
     This method Resets all the cubes local values to 0 centering it infront of the camera
     */
    public void ResetTransform()
    {
        cubeTransform.localPosition = new Vector3(0, 0, 0);
        cubeTransform.localRotation = new Quaternion(0, 0, 0, 0);
        cubeTransform.localScale = new Vector3(1, 1, 1);
    }
    /*
     This method takes in a direction coord and then Moves the object based on the coordinate given by the transformScale value
     */
    public void MoveCube(string coord)
    {
        if (coord.Equals("-X")){
            cubeTransform.Translate(new Vector3(-transformValue, 0, 0));
        }
        else if (coord.Equals("X")){
            cubeTransform.Translate(new Vector3(transformValue, 0, 0));
        }
        else if (coord.Equals("-Y")){
            cubeTransform.Translate(new Vector3(0, -transformValue, 0));
        }
        else if (coord.Equals("Y")){
            cubeTransform.Translate(new Vector3(0, transformValue, 0));
        }
        else if (coord.Equals("-Z")){
            cubeTransform.Translate(new Vector3(0, 0, -transformValue));
        }
        else if (coord.Equals("Z")){
            cubeTransform.Translate(new Vector3(0, 0, transformValue));
        }
        else
        {
            Debug.LogError("Incorrect String Coord for Move \n Try: X, -X, Y, -Y, Z, -Z");
        }
    }
    /*
     This method takes in a direction coord and then Scales the object based on the coordinate given by the transformScale value
     */
    public void ScaleCube(string coord)
    {
        if (coord.Equals("-X"))
        {
            cubeTransform.localScale -= new Vector3(transformValue, 0, 0);
        }
        else if (coord.Equals("X"))
        {
            cubeTransform.localScale += new Vector3(transformValue, 0, 0);
        }
        else if (coord.Equals("-Y"))
        {
            cubeTransform.localScale -= new Vector3(0, transformValue, 0);
        }
        else if (coord.Equals("Y"))
        {
            cubeTransform.localScale += new Vector3(0, transformValue, 0);
        }
        else if (coord.Equals("-Z"))
        {
            cubeTransform.localScale -= new Vector3(0, 0, transformValue);
        }
        else if (coord.Equals("Z"))
        {
            cubeTransform.localScale += new Vector3(0, 0, transformValue);
        }
        else
        {
            Debug.LogError("Incorrect String Coord for Scale \n Try: X, -X, Y, -Y, Z, -Z");
        }
    }
    /*
     This method takes in a direction coord and then Rotates the object based on the coordinate given by the transformScale value
     (fixed to rotate based on arrows not on actual axis)
     */
    public void RotateCube(string coord)
    {
        //tempValue to make rotation more sensitive
        var tempTransform = transformValue * 5;
        if (coord.Equals("Down"))
        {
            cubeTransform.Rotate(-tempTransform, 0, 0);
        }
        else if (coord.Equals("Up"))
        {
            cubeTransform.Rotate(tempTransform, 0, 0);
        }
        else if (coord.Equals("Right"))
        {
            cubeTransform.Rotate(0, -tempTransform, 0);
        }
        else if (coord.Equals("Left"))
        {
            cubeTransform.Rotate(0, tempTransform, 0);
        }
        else if (coord.Equals("Roll Right"))
        {
            cubeTransform.Rotate(0, 0, -tempTransform);
        }
        else if (coord.Equals("Roll Left"))
        {
            cubeTransform.Rotate(0, 0, tempTransform);
        }
        else
        {
            Debug.LogError("Incorrect String Coord for Rotation \n Try: Up, Down, Right, Left, Roll Right, Roll Left");
        }
    }
}
