using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create a menu in the Editor that you can use to create EventChannel classes
[CreateAssetMenu(menuName = "Events/EventChannel/IntEventChannel")]

public class IntEventChannel : EventChannel<int> { }
