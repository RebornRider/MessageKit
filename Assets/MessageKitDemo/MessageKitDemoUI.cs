using Prime31.MessageKit;
using UnityEngine;


// define your messageTypes (which are ints) preferably as const so they can be easily referenced
// and will benefit from code completion
public class MessageTypes
{
    public const int stuffHappened = 0;
    public const int twoParamsEvent = 1;
}


public class MessageKitDemoUI : MonoBehaviour
{
    void OnGUI()
    {
        if (GUILayout.Button("Add Observer (no params)"))
        {
            MessageKit.addObserver(MessageTypes.stuffHappened, stuffHappened);
        }

        if (GUILayout.Button("Add other Observer (no params)"))
        {
            MessageKit.addObserver(MessageTypes.stuffHappened, otherStuffHappened);
        }

        if (GUILayout.Button("Fire (no params)"))
        {
            MessageKit.post(MessageTypes.stuffHappened);
        }


        if (GUILayout.Button("Remove Observer (no params)"))
        {
            MessageKit.removeObserver(MessageTypes.stuffHappened, stuffHappened);
        }

        if (GUILayout.Button("Remove other Observer (no params)"))
        {
            MessageKit.removeObserver(MessageTypes.stuffHappened, stuffHappened);
            MessageKit.removeObserver(MessageTypes.stuffHappened, otherStuffHappened);
        }

        if (GUILayout.Button("Debug.Log Observer (no params)"))
        {
            MessageKit.LogObservers(MessageTypes.stuffHappened);
        }


        GUILayout.Space(50);

        if (GUILayout.Button("Add Observer (two params)"))
        {
            MessageKit<string, GameObject>.addObserver(MessageTypes.twoParamsEvent, twoParamsEvent);
        }

        if (GUILayout.Button("Add other Observer (two params)"))
        {
            MessageKit<string, GameObject>.addObserver(MessageTypes.twoParamsEvent, otherTwoParamsEvent);
        }


        if (GUILayout.Button("Fire (two params)"))
        {
            MessageKit<string, GameObject>.post(MessageTypes.twoParamsEvent, "string param", gameObject);
        }


        if (GUILayout.Button("Remove Observer (two params)"))
        {
            MessageKit<string, GameObject>.removeObserver(MessageTypes.twoParamsEvent, twoParamsEvent);
        }

        if (GUILayout.Button("Remove other Observer (two params)"))
        {
            MessageKit<string, GameObject>.removeObserver(MessageTypes.twoParamsEvent, otherTwoParamsEvent);
        }

        if (GUILayout.Button("Debug.Log Observer (no params)"))
        {
            MessageKit<string, GameObject>.LogObservers(MessageTypes.twoParamsEvent);
        }
    }


    void stuffHappened()
    {
        Debug.Log("stuffHappened fired");
    }
    void otherStuffHappened()
    {
        Debug.Log("otherStuffHappened fired");
    }


    void twoParamsEvent(string firstParam, GameObject secondParam)
    {
        Debug.Log("twoParamsEvent: firstParam: " + firstParam + ", secondParam: " + secondParam);
    }

    void otherTwoParamsEvent(string otherFirstParam, GameObject otherSecondParam)
    {
        Debug.Log("twoParamsEvent: otherFirstParam: " + otherFirstParam + ", otherSecondParam: " + otherSecondParam);
    }
}
