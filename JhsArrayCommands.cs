using System;
using System.Collections.Generic;
using System.Text;


namespace JHS.Framework
{


    public static class JhsArrayCommands
    {


        public static arrayValueType GetArrayMaxValue<arrayValueType>(arrayValueType[] array)
        {

            // Sort array in ascending order
            System.Array.Sort(array);

            // The last value, should be the greatest
            arrayValueType maxValue = array[array.GetUpperBound(0)];
            return maxValue;

        }


        public static arrayValueType[] RemoveArrayStartingValues<arrayValueType>(arrayValueType[] sourceArray, int removeValueCount)
        {

            // Dimension new array to hold the results/return
            arrayValueType[] destArray = null;
            System.Array.Resize<arrayValueType>(ref destArray, sourceArray.Length - removeValueCount);

            // Copy values from source to dest array, except the values at the start that we want to skep
            System.Array.ConstrainedCopy(sourceArray, removeValueCount, destArray, 0, sourceArray.Length - removeValueCount);

            return destArray;

        }


        public static bool ArrayHasValues<arrayValueType>(arrayValueType[] array)
        {
            if (array == null)
                return false;
            else
                return array.Length > 0;
        }


    }


}
