using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    int[] test = {40,235,6123,4,7,912,88234,234,5,7,77,338,1,0,0,-1,10};
	    Debug.Log("Unsorted: ");
        LogList(test);
	    test = Sort(test);
	    Debug.Log("Sorted: ");
	    LogList(test);
    }
    private void LogList(int[] list) {
	    string s = "";
	    foreach (int i in list) {
		    s = s + i + ", ";
	    }
	    Debug.Log(s);
    }

   private int[] Sort(int[] array) {
	// function merge_sort(list m) is
    // // Base case. A list of zero or one elements is sorted, by definition.
    // if length of m ≤ 1 then
    //     return m

    // // Recursive case. First, divide the list into equal-sized sublists
    // // consisting of the first half and second half of the list.
    // // This assumes lists start at index 0.
    // var left := empty list
    // var right := empty list
    // for each x with index i in m do
    //     if i < (length of m)/2 then
    //         add x to left
    //     else
    //         add x to right

    // // Recursively sort both sublists.
    // left := merge_sort(left)
    // right := merge_sort(right)

    // // Then merge the now-sorted sublists.
    // return merge(left, right)
    	if (array.Length <= 1) return array; // TODO: Save array.length to variable?

        int[] left = new int[Mathf.CeilToInt(array.Length/2f)];
        int[] right = new int[array.Length/2];

        for (int i = 0; i < array.Length; i++) {
            if (i < left.Length) left[i] = array[i];
            else right[i-left.Length] = array[i];
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    private int[] Merge(int[] left, int[] right) {
        int[] result = new int[left.Length + right.Length];

        int leftIndex = 0, rightIndex = 0, resultIndex = 0;
        while (leftIndex < left.Length && rightIndex < right.Length ) {
            if (left[leftIndex] <= right[rightIndex]) {
                result[resultIndex] = left[leftIndex];
                leftIndex++;
            }
            else {
                result[resultIndex] = right[rightIndex];
                rightIndex++;
            }
            resultIndex++;
        }

        // Either left or right may have elements left; consume them.
        // (Only one of the following loops will actually be entered.)'
        while (leftIndex != left.Length) {
            result[resultIndex] = left[leftIndex];
            leftIndex++;
            resultIndex++;
        }

        while (rightIndex < right.Length) {
            result[resultIndex] = right[rightIndex];
            rightIndex++;
            resultIndex++;
        }

        return result;
    }
}