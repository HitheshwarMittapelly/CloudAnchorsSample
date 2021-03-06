﻿using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class DatabaseHandlerScript : MonoBehaviour {
    ArrayList Users = new ArrayList();
    private string playerName,IPAddress;
    private int hitCounter=1;
    private int roomNumber;
    private float treeScale=1f;
    const int kMaxLogSize = 16382;
    const int MaxScores = 5;
    const string document = "Anchors";
    public GameObject treeObject;
    public Text SnackBar;
    private TreeScript treeScript;
    Dictionary<string, object> newNameMap;

    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    // Use this for initialization
   protected virtual void Start () {
        treeScript = treeObject.GetComponent<TreeScript>();
        newNameMap = new Dictionary<string, object>();
        Users.Clear();
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });


    }
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://greenar-c9b8e.firebaseio.com/");
   
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);

        StartListener();
       
    }

    protected void StartListener()
    {
       
        //FirebaseDatabase.DefaultInstance
          //              .GetReference(document)
          //.ValueChanged += (object sender2, ValueChangedEventArgs e2) => {
          //    if (e2.DatabaseError != null)
          //    {
          //        Debug.LogError(e2.DatabaseError.Message);
          //        return;
          //    }
          //    Debug.Log("Received values for Users.");
          //    string title = Users[0].ToString();
          //      Users.Clear();
          //      Users.Add(title);
          //    if (e2.Snapshot != null && e2.Snapshot.ChildrenCount > 0)
          //    {
          //        foreach (var childSnapshot in e2.Snapshot.Children)
          //        {
          //            if (childSnapshot.Child("hitCounter") == null
          //          || childSnapshot.Child("hitCounter").Value == null)
          //            {
          //                Debug.LogError("Bad data in sample.  Did you forget to call SetEditorDatabaseUrl with your project id?");
          //                break;
          //            }
          //            else
          //            {
          //                Debug.Log("Leaders entry : " +
                      
          //              childSnapshot.Child("hitCounter").Value.ToString());
          //                Users.Insert(1, childSnapshot.Child("hitCounter").Value.ToString()
          //              + "  " );
          //            }
          //        }
          //    }
          //};
    }

    // A realtime database transaction receives MutableData which can be modified
    // and returns a TransactionResult which is either TransactionResult.Success(data) with
    // modified data or TransactionResult.Abort() which stops the transaction with no changes.
    TransactionResult AddAnchorTransaction(MutableData mutableData)
    {
        List<object> Anchors = mutableData.Value as List<object>;

        if (Anchors == null)
        {
            Anchors = new List<object>();
        }
        //else if (mutableData.ChildrenCount >= MaxScores)
        //{
        //    // If the current list of scores is greater or equal to our maximum allowed number,
        //    // we see if the new score should be added and remove the lowest existing score.
        //    long minScore = long.MaxValue;
        //    object minVal = null;
        //    foreach (var child in users)
        //    {
        //        if (!(child is Dictionary<string, object>))
        //            continue;
        //        long childScore = (long)((Dictionary<string, object>)child)["hitCounter"];
        //        if (childScore < minScore)
        //        {
        //            minScore = childScore;
        //            minVal = child;
        //        }
        //    }
        //    // If the new score is lower than the current minimum, we abort.
        //    if (minScore > hitCounter)
        //    {
        //        return TransactionResult.Abort();
        //    }
        //    // Otherwise, we remove the current lowest to be replaced with the new score.
        //    users.Remove(minVal);
        //}

        // Now we add the new score as a new entry that contains the email address and score.
      
        //newNameMap["hitCounter"] =hitCounter;
       
        //newNameMap["scale"] = treeScale;
        newNameMap["Room"] = roomNumber;
        newNameMap["IP"] = IPAddress;
        newNameMap["playerName"] = playerName;

        Anchors.Add(newNameMap);

        // You must set the Value to indicate data at that location has changed.
        mutableData.Value = Anchors;
        return TransactionResult.Success(mutableData);
    }
    //TransactionResult AddRoomTransaction(MutableData mutableData)
    //{
    //    List<object> roomAndAddress = mutableData.Value as List<object>;

    //    if (roomAndAddress == null)
    //    {
    //        roomAndAddress = new List<object>();
    //    }


    //    // Now we add the new score as a new entry that contains the email address and score.
    //    Dictionary<string, object> newRoomMap = new Dictionary<string, object>();
    //    newRoomMap["roomNumber"] = roomNumber;
    //    newRoomMap["IPAddress"] = IPAddress;

    //    roomAndAddress.Add(newRoomMap);

    //    // You must set the Value to indicate data at that location has changed.
    //    mutableData.Value = roomAndAddress;
    //    return TransactionResult.Success(mutableData);
    //}

    public void AddRoomValue(int roomNumber){
        this.roomNumber = roomNumber;
        if (this.roomNumber == 0 )
        {

            return;
        }
        //DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");


        //// Use a transaction to ensure that we do not encounter issues with
        //// simultaneous updates that otherwise might create more than MaxScores top scores.
        //reference.RunTransaction(AddRoomTransaction)
          //.ContinueWith(task => {
          //    if (task.Exception != null)
          //    {
          //        Debug.Log(task.Exception.ToString());
          //        SnackBar.text = "Exception raised"; 
          //    }
          //    else if (task.IsCompleted)
          //    {
          //        Debug.Log("Transaction complete.");
          //    }
          //});
        

    }
    public void SetIPValue(string ip){
        Debug.Log("called setIpValue");
        IPAddress = ip;
    }

    public void AddName(string playerName)
    {
        Debug.Log("Called AddName with  :" + playerName);
        this.playerName = playerName;
        //if (hitCounter == 0 || string.IsNullOrEmpty(playerName))
        //{
          
        //    return;
        //}
       




        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more than MaxScores top scores.

    }
    //public void GoOnline(float treeScale,int hitCounter){
       
    //    this.hitCounter = hitCounter;
    //    this.treeScale = treeScale;
       
    //    DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(document);
    //    reference.RunTransaction(AddAnchorTransaction)
    //      .ContinueWith(task => {
    //          if (task.Exception != null)
    //          {
    //              Debug.Log(task.Exception.ToString());
    //          }
    //          else if (task.IsCompleted)
    //          {
    //              Debug.Log("Transaction complete.");
    //          }
    //      });
    //    //FirebaseDatabase.DefaultInstance.GoOnline();

    //}
   
    public void SetOnline(){
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference(document);
        reference.RunTransaction(AddAnchorTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
                  Debug.Log(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
                  Debug.Log("Transaction complete.");
              }
          });
        FirebaseDatabase.DefaultInstance.GoOnline();
    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            if (treeScale < 1.5f)
            {
                treeScale *= 1.2f;

                hitCounter++;
            }

        }
    }
}
