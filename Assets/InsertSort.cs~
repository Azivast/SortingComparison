using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    int[] test = {40,235,6,4,7,92,88234,234,5,7,77,8,1,0,10};
	    Debug.Log("Unsorted: ");
	    LogList(test);
	    Sort(test);
	    Debug.Log("Sorted: ");
	    LogList(test);
    }
	    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void LogList(int[] list) {
	    string s = "";
	    foreach (int i in list) {
		    s = s + i + ", ";
	    }
	    Debug.Log(s);
    }

    public void Sort(int[] sizes)
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
    while (i < sizes.Length) { // TODO: Replace with for-loop
	    int j = i;
	    while (j > 0 && sizes[j-1] > sizes[j]) {
		    int tmp = sizes[j-1]; // swap j and j-1
		    sizes[j-1] = sizes[j];
		    sizes[j] = tmp;
		    j--;
	    }
	    i++;
	}
}
}
