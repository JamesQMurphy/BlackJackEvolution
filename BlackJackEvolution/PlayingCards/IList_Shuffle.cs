using System;
using System.Collections.Generic;

// TODO: put in shared library, possibly a JamesQMurphy Random library

public static class ExtensionMethods
{
    public static void Shuffle<T>(this IList<T> theList, int startIndex = 0)
    {
        int N = theList.Count;
        for ( int i = N-1; i > startIndex; i--)
        {
            int j = CryptoRandom.Generator.Next(i + 1 - startIndex) + startIndex;
            T tmp = theList[i];
            theList[i] = theList[j];
            theList[j] = tmp;
        }
    }
}