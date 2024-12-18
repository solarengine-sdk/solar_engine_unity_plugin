using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using SolarEngine.Build;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class PluginsEdtior : MonoBehaviour
{
   
   private const string SolorEngine = "[SolorEngine]";



   private const string PluginsSolarEnginePath = "Assets/Plugins/SolarEngine/";
   private const string RemoteConfigsCSPath = "Assets/SolarEngineSDK/RemoteConfigWrapper";
   private const string RemoteConfigXmlPath = SolarEngineNet+"SolarEnginePlugins/RemoteConfigSDK";
   
   private const string SolarEngineNet = "Assets/SolarEngineNet/";
   
   private const string IOS_SDK = SolarEngineNet + "iOS";
   private const string ANDROID_SDK = SolarEngineNet + "Android";

   private const string ANDROID_OAID_PATH = SolarEngineNet + "SolarEnginePlugins/Oaid";
   
   
   private const string REMOTECONFIG_PATH = SolarEngineNet + "SolarEnginePlugins/RemoteConfigSDK/";
   private const string ANDROID_REMOTECONFIG_PATH = REMOTECONFIG_PATH + "Android";
   private const string IOS_REMOTECONFIG_PATH = REMOTECONFIG_PATH + "iOS" ;
   
   
   
   private const string oaidPath = SolarEngineNet+"SolarEnginePlugins/Oaid";
   
   //minigamepath
   private const string MiniGameRemoteConfigsPathMiniCS = "Assets/SolarEngineSDK/RemoteConfigWrapper/SESDKRemoteConfigMiniGameWrapper.cs";
   private const string MiniGameRemoteConfigsPathMiniDll = PluginsSolarEnginePath+"MiniGame/MiniGameRemoteConfig.dll";

   
   //iospath
  private const string  RemoteConfigsPathiOSCS = "Assets/SolarEngineSDK/RemoteConfigWrapper/SESDKRemoteConfigiOSWrapper.cs";
   private const string RemoteConfigsPathiOSMM = PluginsSolarEnginePath+"iOS/wrappers/SESDKRemoteConfigUnityBridge.mm";
   private const string RemoteConfigsPathiOSH =  PluginsSolarEnginePath+"iOS/wrappers/SESDKRemoteConfigUnityBridge.h";
   private const string RemoteConfigsPathiOSXml = RemoteConfigXmlPath+"/iOS";
   //androidpath
   private const string RemoteConfigsPathAndroidCS = "Assets/SolarEngineSDK/RemoteConfigWrapper/SESDKRemoteConfigAndroidWrapper.cs";
   private const string ConfigsPathAndroidJar = PluginsSolarEnginePath+"Android/libs/se_remote_config_unity_bridge.jar";
   private const string RemoteConfigsPathAndroidXml = RemoteConfigXmlPath+"/Android";



   public static bool disableiOSSDK()
   {
       DefineSymbolsEditor.add_DISABLE_REMOTECONFIG(BuildTargetGroup.iOS);
       return
           HidePath(IOS_SDK);
   }
   public static bool disableAndroidSDK()
   {
     return  HidePath(ANDROID_SDK);
     
   }
   
   
   public static bool enableiOSSDK()
   {

       return ShowPath(IOS_SDK);


   }
   public static bool enableAndroidSDK()
   {
       return  ShowPath(ANDROID_SDK);

   }
   
   
   
  // [MenuItem(DisableAll, false, 0)]
   public static void disableAll ()
   {
      HidePath(RemoteConfigsCSPath);

   }
   public static void showAll ()
   {
      // showMiniGame();
      // showiOS();
      // showAndroid();
      ShowPath(RemoteConfigsCSPath);

   }
  
  // [MenuItem(DisableMiniGame, false, 0)]
   public static bool disableMiniGame ()
   {
       DefineSymbolsEditor.add_DISABLE_REMOTECONFIG(BuildTargetGroup.WebGL);

     return  HideFile(MiniGameRemoteConfigsPathMiniDll)&&
       HideFile(MiniGameRemoteConfigsPathMiniCS);
      
   }
   
   public static bool showMiniGame ()
   {
       DefineSymbolsEditor.delete_DISABLE_REMOTECONFIG(BuildTargetGroup.WebGL);

     return  ShowFile(MiniGameRemoteConfigsPathMiniDll)&&
       ShowFile(MiniGameRemoteConfigsPathMiniCS);
      
   }
  // [MenuItem(DisableiOS, false, 0)]
   public static bool disableiOS ()
   {
       DefineSymbolsEditor.add_DISABLE_REMOTECONFIG(BuildTargetGroup.iOS);
       return  
        HideFile(RemoteConfigsPathiOSCS)&&
       HideFile(RemoteConfigsPathiOSMM)&&
       HideFile(RemoteConfigsPathiOSH)&&
       HidePath(RemoteConfigsPathiOSXml);
   }
   public static bool showiOS ()
   {
       DefineSymbolsEditor.delete_DISABLE_REMOTECONFIG(BuildTargetGroup.iOS);
      return
       ShowFile(RemoteConfigsPathiOSCS)&&
       ShowFile(RemoteConfigsPathiOSMM)&&
       ShowFile(RemoteConfigsPathiOSH)&&
       ShowPath(RemoteConfigsPathiOSXml);
   }
   
   
  // [MenuItem(DisableAndroid, false, 0)]
   public static bool disableAndroid ()
   { 
       DefineSymbolsEditor.add_DISABLE_REMOTECONFIG(BuildTargetGroup.Android);
     return HideFile(RemoteConfigsPathAndroidCS)&&
       HideFile(ConfigsPathAndroidJar)&&
      HidePath(RemoteConfigsPathAndroidXml);
   }
   public static bool showAndroid ()
   {
       DefineSymbolsEditor.delete_DISABLE_REMOTECONFIG(BuildTargetGroup.Android);

    
       return ShowFile(RemoteConfigsPathAndroidCS)&&
       ShowFile(ConfigsPathAndroidJar)&&
       ShowPath(RemoteConfigsPathAndroidXml);
   }


   public static bool disableOaid()
   {
       return HidePath(oaidPath);
   }
   public static bool showOaid()
   {
     return  ShowPath(oaidPath);
   }

   
 
   public static bool HideFile(string path)
   {
      
       if (File.Exists(path))
       {

           if (File.Exists(path + "~"))
           {
               System.IO. File.Delete(path + "~");
           }
           System.IO. File.Move(path, path + "~");

           return true;
           //  Debug.LogWarning($"{SolorEngine} The file at path '{path}' is successfully hidden.");
       }
        if (File.Exists(path + "~"))
       {
           return true;
       }
       else
       {
           Debug.LogError(($"{SolorEngine}The file at path '{path}' does not exist"));
       }
      
       return false;
   }
   
   
   static bool IsDirectoryEmpty(string directoryPath)
   {
       return! System.IO.Directory.EnumerateFileSystemEntries(directoryPath).Any();
   }

   public static bool HidePath(string path)
   {
    
           if (System.IO.Directory.Exists(path))
           {
              
               if( System.IO.Directory.Exists(path + "~"))
                   System.IO.Directory.Delete(path + "~",true);
               System.IO.Directory.Move(path, path + "~");
               System.IO.File.Delete(path+".meta");
               return true;
           
         
           }

           if (System.IO.Directory.Exists(path + "~"))
               return true;
         
            
           else
           {
               Debug.LogError(($"{SolorEngine}The file at path '{path}' does not exist"));
           }
   

       return false;


   }

   public static bool ShowFile(string path)
   {
       try
       {
           if (File.Exists(path))
           {
               return true;
           }
           else if (File.Exists(path + "~"))
           {
               System.IO. File.Move(path + "~", path);
               return true;
           }
           else
           {
               
               Debug.LogError(($"{SolorEngine}The file at path '{path}' does not exist"));

           }
       }
       catch (Exception e)
       {
           Debug.LogError(SolorEngine+e);

           return false;
       }
    
     

       return false;
   }
 

   public static bool ShowPath(string path)
   {
       try
       {
           if (System.IO.Directory.Exists(path + "~"))
           {
             
               if (System.IO.Directory.Exists(path))
               {
                   System.IO.Directory.Delete(path,true) ;
               }
               System.IO.Directory.Move(path + "~", path);

               return true;
           }
           else if( System.IO.Directory.Exists(path))
           {
               return true;
           }
           else
           {
               Debug.LogError(($"{SolorEngine}The file at path '{path}' does not exist"));

               return false;
           }
      }
       catch (Exception e)
       {
          Debug.LogError(SolorEngine+e);
           return false;
          
   }
    
      
   }
  
   
   
   
}
