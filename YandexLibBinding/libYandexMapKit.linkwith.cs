using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libYandexMapKit.a", LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true)]
