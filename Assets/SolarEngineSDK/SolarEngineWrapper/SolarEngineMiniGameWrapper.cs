﻿#if (SOLARENGINE_BYTEDANCE||SOLARENGINE_WECHAT||SOLARENGINE_KUAISHOU)&&(!UNITY_EDITOR||SOLORENGINE_DEVELOPEREDITOR)

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AOT;
using Newtonsoft.Json;

using SolaEngine.MiniGames.Enum;
using SolarEngine.MiniGames;
using SolarEngine.MiniGames.info;
using SolarEngine.MiniGames.Wrapper.SDKWrapper;
using UnityEngine;

namespace SolarEngine
{
    public partial class Analytics : MonoBehaviour
    {
     
        private static Dictionary<string, object> GetPresetProperties()
        {
            return SolarEngineSDK4MiniGames.getPresetProperties();
        }

        private static void PreInitSeSdk(string appKey)
        {
            SolarEngineSDK4MiniGames.prevInit(appKey);
        }


        private static void Init(string appKey, string userId, SEConfig config)
        {
            InitParams initParams = new InitParams();

            if (config.initCompletedCallback != null)
            {
                SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback initCompletedCallback =
                    (SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback)Delegate.CreateDelegate(
                        typeof(SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback),
                        config.initCompletedCallback.Target, config.initCompletedCallback.Method);
                initParams.miniGameInitCompletedCallback = initCompletedCallback;
            }

            if (config.attributionCallback != null)
            {
                SolarEngineSDK4MiniGames.MiniGameAttributionCallback attributionCallback =
                    (SolarEngineSDK4MiniGames.MiniGameAttributionCallback)Delegate.CreateDelegate(
                        typeof(SolarEngineSDK4MiniGames.MiniGameAttributionCallback), config.attributionCallback.Target,
                        config.attributionCallback.Method);
                initParams.miniGameAttributionCallback = attributionCallback;
            }

            if (config.miniGameInitParams != null)
            {
                initParams.miniGameInitParams = new MiniGames. MiniGameInitParams();

#if SOLARENGINE_WECHAT
                initParams.miniGameInitParams.anonymous_openid = "";
#else
                initParams.miniGameInitParams.anonymous_openid = config.miniGameInitParams.anonymous_openid;
#endif
              

                initParams.miniGameInitParams.openid = config.miniGameInitParams.openid;
                initParams.miniGameInitParams.unionid = config.miniGameInitParams.unionid;

            }
            initParams.debugModel = config.isDebugModel;
            initParams.logEnabled = config.logEnabled;
            initParams.sublibVersion = sdk_version;
#if  SOLARENGINE_WECHAT
            SEAdapterInterface _adapter = new SolarEngine.Platform. WeChatAdapter();
#elif SOLARENGINE_BYTEDANCE
            SEAdapterInterface _adapter = new SolarEngine.Platform.ByteDanceAdapter();
#elif SOLARENGINE_KUAISHOU
            SEAdapterInterface _adapter = new KuaiShouAdapter();

#endif
            SolarEngineSDK4MiniGames.init(appKey, initParams, _adapter);
        }
      
        private static void Init(string appKey, string userId, SEConfig config, RCConfig rcConfig)
        {
            InitParams initParams = new InitParams();

            if (config.initCompletedCallback != null)
            {
                SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback initCompletedCallback =
                    (SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback)Delegate.CreateDelegate(
                        typeof(SolarEngineSDK4MiniGames.MiniGameInitCompletedCallback),
                        config.initCompletedCallback.Target, config.initCompletedCallback.Method);
                initParams.miniGameInitCompletedCallback = initCompletedCallback;
            }

            if (config.attributionCallback != null)
            {
                SolarEngineSDK4MiniGames.MiniGameAttributionCallback attributionCallback =
                    (SolarEngineSDK4MiniGames.MiniGameAttributionCallback)Delegate.CreateDelegate(
                        typeof(SolarEngineSDK4MiniGames.MiniGameAttributionCallback), config.attributionCallback.Target,
                        config.attributionCallback.Method);
                initParams.miniGameAttributionCallback = attributionCallback;
            }

            if (config.miniGameInitParams != null)
            {
                initParams.miniGameInitParams = new MiniGames.MiniGameInitParams();
#if SOLARENGINE_WECHAT
            initParams.miniGameInitParams.anonymous_openid = "";
 #else
            initParams.miniGameInitParams.anonymous_openid = config.miniGameInitParams.anonymous_openid;
#endif
              

                initParams.miniGameInitParams.openid = config.miniGameInitParams.openid;
                initParams.miniGameInitParams.unionid = config.miniGameInitParams.unionid;

            }
            
            initParams.debugModel = config.isDebugModel;
            initParams.logEnabled = config.logEnabled;
            initParams.sublibVersion = sdk_version;

            MiniGameRCConfig minircConfig = new MiniGameRCConfig();
            minircConfig.enable = rcConfig.enable;
            minircConfig.mergeType = (MiniRCMergeType)(int)rcConfig.mergeType;
            minircConfig.customIDEventProperties = rcConfig.customIDEventProperties;
            minircConfig.customIDProperties = rcConfig.customIDProperties;
            minircConfig.customIDUserProperties = rcConfig.customIDUserProperties;


#if SOLARENGINE_WECHAT
            SEAdapterInterface _adapter = new SolarEngine.Platform. WeChatAdapter();
#elif SOLARENGINE_BYTEDANCE
            SEAdapterInterface _adapter = new SolarEngine.Platform.ByteDanceAdapter();
#elif SOLARENGINE_KUAISHOU
            SEAdapterInterface _adapter = new KuaiShouAdapter();

#endif
            SolarEngineSDK4MiniGames.init(appKey, initParams, _adapter, minircConfig);
        }

  


        private static void SetVisitorID(string visitorId)
        {
            SolarEngineSDK4MiniGames.setVisitorId(visitorId);
        }

        private static string GetVisitorID()
        {
            return SolarEngineSDK4MiniGames.getVisitorId();
        }

        private static void Login(string accountId)
        {
         
            SolarEngineSDK4MiniGames.login(accountId);
        }
        private static void SetReferrerTitle(string referrerTitle)
        {
            SolarEngineSDK4MiniGames.setReferrerTitle(referrerTitle);
        }

        public static void SetXcxPageTitle(string xcxPageTitle)
        {
            SolarEngineSDK4MiniGames.setXcxPageTitle(xcxPageTitle);
        }

        public static void setSASS(string receiverDomain, string ruleDomain, string openIdDomain)
        {
            SolarEngineSDK4MiniGames.setSASS(receiverDomain, ruleDomain, openIdDomain);
        }


        private static string GetAccountId()
        {
            return SolarEngineSDK4MiniGames.getAccountId();
        }

        private static void Logout()
        {
            SolarEngineSDK4MiniGames.logout();
        }

   
        private static void SetChannel(string channel)
        {
            SolarEngineSDK4MiniGames.setChannel(channel);
        }

        private static void SetGDPRArea(bool isGDPRArea)
        {
              Debug.Log($"{SolorEngine}minigame not support");
        }


        private static void GetDistinctId(Action<Distinct> distinct)
        {
            Action<SolarEngine.MiniGames.info.Distinct> miniGamesDistinctAction = (arg) => distinct?.Invoke(ConvertToCustomDistinct(arg));

            SolarEngineSDK4MiniGames.getDistinct(miniGamesDistinctAction);
        }
        private static Distinct ConvertToCustomDistinct(SolarEngine.MiniGames.info.Distinct source)
        {
            Distinct target = new Distinct();
            target.distinct_id = source.distinct_id;
            target.distinct_id_type = source.distinct_id_type;
            return target;
        }
     
        private static void SetSuperProperties(Dictionary<string, object> userProperties)
        {
            SolarEngineSDK4MiniGames.setSuperProperties(userProperties);
        }

        private static void UnsetSuperProperty(string key)
        {
           

            SolarEngineSDK4MiniGames.unsetSuperProperty(key);
        }

        private static void ClearSuperProperties()
        {
            SolarEngineSDK4MiniGames.clearSuperProperties();
        }


        private static void EventStart(string timerEventName)
        {
         

            SolarEngineSDK4MiniGames.eventStart(timerEventName);
        }

        private static void EventFinish(string timerEventName, Dictionary<string, object> attributes)
        {
          

            SolarEngineSDK4MiniGames.eventFinish(timerEventName, attributes);
        }


        private static void UserUpdate(Dictionary<string, object> userProperties)
        {
            SolarEngineSDK4MiniGames.userUpdate(userProperties);
        }

        private static void UserInit(Dictionary<string, object> userProperties)
        {
          
            SolarEngineSDK4MiniGames.userInit(userProperties);
        }

        private static void UserAdd(Dictionary<string, object> userProperties)
        {
            SolarEngineSDK4MiniGames.userAdd(userProperties);
        }

        private static void UserAppend(Dictionary<string, object> userProperties)
        {
            SolarEngineSDK4MiniGames.userAppend(userProperties);
        }

        private static void UserUnset(string[] keys)
        {
        
            SolarEngineSDK4MiniGames.userUnset(keys);
        }

        private static void UserDelete(SEUserDeleteType deleteType)
        {
            miniGameUserDeleteType miniGameUserDeleteType = (miniGameUserDeleteType)(int)deleteType;
            SolarEngineSDK4MiniGames.userDelete(miniGameUserDeleteType);
        }

        private static string  GetAttribution()
        {
            return SolarEngineSDK4MiniGames.getAttribution();
        
        }
        private static void TrackFirstEvent(SEBaseAttributes attributes)
        {
              Debug.Log($"{SolorEngine}minigame not support");
        }

        private static void ReportIAPEvent(ProductsAttributes attributes)
        {
        
            SolarEngineSDK4MiniGames.trackIAP(getIAPDic(attributes,false), attributes.customProperties);
        }

        private static void ReportIAIEvent(AppImpressionAttributes attributes)
        {
           
            SolarEngineSDK4MiniGames.trackAdImpression(getIAIDic(attributes,false), attributes.customProperties);
        }

        private static void ReportAdClickEvent(AdClickAttributes attributes)
        {
         
            SolarEngineSDK4MiniGames.trackAdClick(getAdClickDic(attributes,false), attributes.customProperties);
        }

        private static void ReportRegisterEvent(RegisterAttributes attributes)
        {
          
            SolarEngineSDK4MiniGames.trackRegister(getRegisterDic(attributes,false), attributes.customProperties);
        }

        private static void ReportLoginEvent(LoginAttributes attributes)
        {
            SolarEngineSDK4MiniGames.trackLogin(getLoginDic(attributes,false), attributes.customProperties);
        }

        private static void ReportOrderEvent(OrderAttributes attributes)
        {
        
            SolarEngineSDK4MiniGames.trackOrder(getOrderDic(attributes,false), attributes.customProperties);
        }

        private static void AppAttrEvent(AppAttributes attributes)
        {
            SolarEngineSDK4MiniGames.trackAppAttr(getAttrDic(attributes,false), attributes.customProperties);
        }


        private static void SetPresetEvent(SEConstant_Preset_EventType eventType, Dictionary<string, object> attributes)
        {
            miniGamePreset_EventType miniGamePresetEvent = (miniGamePreset_EventType)(int)eventType;

            SolarEngineSDK4MiniGames.setPresetEvent(miniGamePresetEvent, attributes);
        }

        private static void ReportCustomEvent(string customEventName, Dictionary<string, object> attributes)
        {
            SolarEngineSDK4MiniGames.track(customEventName, null, attributes);
        }

        private static void ReportCustomEventWithPreAttributes(string customEventName,
            Dictionary<string, object> customAttributes, Dictionary<string, object> preAttributes)
        {
            SolarEngineSDK4MiniGames.track(customEventName, preAttributes, customAttributes);
        }

        private static void ReportEventImmediately()
        {
            SolarEngineSDK4MiniGames.reportEventImmediately();
        }

        private static void HandleDeepLinkUrl(string url)
        {
              Debug.Log($"{SolorEngine}Only Android can use , minigame not support");
        }
        private  static void SetOaid(string oaid)
        {
            Debug.Log($"{SolorEngine}Only Android can use , minigame not support");
        }

        #region  not support function

        private static void DeeplinkCompletionHandler(SESDKDeeplinkCallback callback)
        {
              Debug.Log($"{SolorEngine}MiniGame not support");
        }

        private static void DelayDeeplinkCompletionHandler(SESDKDelayDeeplinkCallback callback)
        {
              Debug.Log($"{SolorEngine}MiniGame not support");
        }

        private static string GetDistinctId()
        {
              Debug.Log($"{SolorEngine}MiniGame not support");
            return "";
        }
        private static void RequestTrackingAuthorizationWithCompletionHandler(SESDKATTCompletedCallback callback) {
               Debug.Log($"{SolorEngine}Current on MiniGame,requestTrackingAuthorizationWithCompletionHandler only iOS");
         }

         /// <summary>
         /// 仅支持iOS
         /// SolarEngine 封装系统updatePostbackConversionValue
         /// </summary>
         private static void UpdatePostbackConversionValue(int conversionValue, SKANUpdateCompletionHandler callback)
         {

               Debug.Log($"{SolorEngine}Current on MiniGame,requestTrackingAuthorizationWithCompletionHandler only iOS");


         }
         /// <summary>
         /// 仅支持iOS
         /// SolarEngine 封装系统updateConversionValueCoarseValue
         /// </summary>
         private static void UpdateConversionValueCoarseValue(int fineValue, String coarseValue, SKANUpdateCompletionHandler callback)
         {
               Debug.Log($"{SolorEngine}Current on MiniGame,requestTrackingAuthorizationWithCompletionHandler only iOS");

         }
         /// 仅支持iOS
         /// SolarEngine 封装系统updateConversionValueCoarseValueLockWindow
         /// </summary>
         private static void UpdateConversionValueCoarseValueLockWindow(int fineValue, String coarseValue, bool lockWindow, SKANUpdateCompletionHandler callback)
         {
               Debug.Log($"{SolorEngine}Current on MiniGame,requestTrackingAuthorizationWithCompletionHandler only iOS");

         }
         
         private static void SetGaid(string gaid)
         {
               Debug.Log($"{SolorEngine}Current on MiniGame，Only Android can set gaid");
         }
         
         
        #endregion
    }
}
#endif