using System.Linq;
using UnityEngine;
using System;
using System.Collections;

public class SMUtils
{
	public static void log(params object[] args)
	{
		UnityEngine.Debug.Log( toSpaceString(args) );
	}

	public static string toSpaceString(params object[] args)
	{
		return toString(" ", args);
	}

	public static string toString(string sep, params object[] args)
	{
		return string.Join(sep, args.Select( o => ( null == o? "null" : o.ToString() ) ).ToArray() );
	}
}
