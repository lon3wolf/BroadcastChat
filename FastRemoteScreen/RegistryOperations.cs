using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace XRegistryOperations
{
    //This class provide functions to modify registry keys, to allow/ban auto start of XBC
    //Can be modified to do some other registry changes
    public class RegistryOperations
    {
        //AddKey:  Adds a key to windows registry
        //Returns False on failure, True on Success
        public static bool AddKey(RegistryHive Type, string Machine, string Key, string Name, object Value)
        {
            try
            {
                RegistryKey RegKey = RegistryKey.OpenRemoteBaseKey(Type,Machine);
                RegistryKey NewKey = RegKey.CreateSubKey(Key);
                NewKey.SetValue(Name,Value);
                NewKey.Flush(); //Store the value
                NewKey.Close(); // Store and close
                RegKey.Close();
                return true;
            }
            catch(Exception  ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public static bool RemoveKey(RegistryHive Type, string Machine, string Key, string Name)
        {
            try
            {
                RegistryKey RegKey = RegistryKey.OpenRemoteBaseKey(Type,Machine);
                RegistryKey OpenKey = RegKey.OpenSubKey(Key, true);
                OpenKey.DeleteValue(Name);
                RegKey.Close();
                return true;
            }
            catch
            {
                return false;
            }   
        }

        //returns null, if Name key doesn't exist
        public static object GetKeyValue(RegistryHive Type, string Machine,string Key, string Name)
        {
            try
            {
                RegistryKey RegKey = RegistryKey.OpenRemoteBaseKey(Type, Machine);
                RegistryKey OpenKey = RegKey.OpenSubKey(Key, true);
                object RetObj = OpenKey.GetValue(Name, null);
                RegKey.Close();
                return RetObj;
            }
            catch
            {
                return null;
            }   
        }
    }
}
