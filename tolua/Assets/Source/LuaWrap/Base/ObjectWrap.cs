﻿using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ObjectWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetInstanceID", GetInstanceID),
		new LuaMethod("Instantiate", Instantiate),
		new LuaMethod("Destroy", Destroy),
		new LuaMethod("DestroyImmediate", DestroyImmediate),
		new LuaMethod("FindObjectsOfType", FindObjectsOfType),
		new LuaMethod("FindObjectOfType", FindObjectOfType),
		new LuaMethod("DontDestroyOnLoad", DontDestroyOnLoad),
		new LuaMethod("DestroyObject", DestroyObject),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", Create),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("name", get_name, set_name),
		new LuaField("hideFlags", get_hideFlags, set_hideFlags),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Object obj = null;

		if (count == 0)
		{
			obj = new Object();
            LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Object.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Object", typeof(Object), regs, fields, "object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name name");
		}

		Object obj = (Object)o;
        LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hideFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hideFlags");
		}

		Object obj = (Object)o;
        LuaScriptMgr.Push(L, obj.hideFlags);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name name");
		}

		Object obj = (Object)o;
		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hideFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hideFlags");
		}

		Object obj = (Object)o;
		obj.hideFlags = (HideFlags)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Object obj = (Object)LuaScriptMgr.GetNetObject(L, 1);
        LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object obj = (Object)LuaScriptMgr.GetNetObject(L, 1);
		object arg0 = (object)LuaScriptMgr.GetNetObject(L, 2);
		bool o = obj.Equals(arg0);
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object obj = (Object)LuaScriptMgr.GetNetObject(L, 1);
		int o = obj.GetHashCode();
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstanceID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object obj = (Object)LuaScriptMgr.GetNetObject(L, 1);
		int o = obj.GetInstanceID();
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Instantiate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			Object o = Object.Instantiate(arg0);
            LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			Vector3 arg1 = (Vector3)LuaScriptMgr.GetNetObject(L, 2);
			Quaternion arg2 = (Quaternion)LuaScriptMgr.GetNetObject(L, 3);
			Object o = Object.Instantiate(arg0,arg1,arg2);
            LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Object.Instantiate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Destroy(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			Object.Destroy(arg0);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Object.Destroy(arg0,arg1);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Object.Destroy");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyImmediate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			Object.DestroyImmediate(arg0);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			Object.DestroyImmediate(arg0,arg1);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyImmediate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindObjectsOfType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = (Type)LuaScriptMgr.GetNetObject(L, 1);
		Object[] o = Object.FindObjectsOfType(arg0);
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindObjectOfType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = (Type)LuaScriptMgr.GetNetObject(L, 1);
		Object o = Object.FindObjectOfType(arg0);
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DontDestroyOnLoad(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
		Object.DontDestroyOnLoad(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			Object.DestroyObject(arg0);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else if (count == 2)
		{
			Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Object.DestroyObject(arg0,arg1);
			LuaScriptMgr.__gc(L);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyObject");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object obj = (Object)LuaScriptMgr.GetNetObject(L, 1);
		string o = obj.ToString();
        LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = (Object)LuaScriptMgr.GetNetObject(L, 1);
		Object arg1 = (Object)LuaScriptMgr.GetNetObject(L, 2);
		bool o = arg0 == arg1;
        LuaScriptMgr.Push(L, o);
		return 1;
	}
}

