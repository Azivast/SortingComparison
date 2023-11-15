using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void Sort(int[] array) {
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
    	if (array.Length <= 1) return array.Length // TODO: Save array.length to variable?

        int[] left = Mathf.CeilToInt(array.Length/2f)
        int[] right = array.Length/2;

        for (int i = 0; i < Array.Legth; i++) {
            (i <= left.Lengt) ? left[i] = array[i] : right[i-left.Length] = array[i];
            }
        }

        Sort(left);
        Sort(right);

        return merge(left, right);
    }

    private void Merge(int[] left, int[] right) {
        int[] result = new int[left.Length + right.Length;

        int leftIndex, rightIndex;
        while (leftIndex < left.Length-1 && rightIndex < right.Length ) {
            if (left[0] <= right[0]) {
            
        }
    }

    }
}
