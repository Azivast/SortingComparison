using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertSort : MonoBehaviour,ISortingAlgorithm
{
    private void LogList(int[] list) {
	    string s = "";
	    foreach (int i in list) {
		    s = s + i + ", ";
	    }
	    Debug.Log(s);
    }

    public SphereBehaviour[] Sort(SphereBehaviour[] spheres)
    {
    //     i ← 1
    //     while i < length(A)
    //         j ← i
    //         while j > 0 and A[j-1] > A[j]
    //             swap A[j] and A[j-1]
    //             j ← j - 1
    //         end while
    //         i ← i + 1
    //     end while
    //
    // TODO: Better implementation available on wikipedia
    
    int i = 1;
    while (i < spheres.Length) { // TODO: Replace with for-loop
	    int j = i;
	    while (j > 0 && spheres[j-1].Distance > spheres[j].Distance) {
		    // int tmp = sizes[j-1]; // swap j and j-1
		    // sizes[j-1] = sizes[j];
		    // sizes[j] = tmp;
		    (spheres[j-1], spheres[j]) = (spheres[j], spheres[j-1]);
		    j--;
	    }
	    i++;
	}

    return spheres;
    }
}
