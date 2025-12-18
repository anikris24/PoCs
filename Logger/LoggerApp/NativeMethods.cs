//-----------------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="AVEVA Software, LLC">
//     Copyright © 2018 AVEVA Group plc and its subsidiaries. All rights reserved.
// </copyright>
// <summary>
// This class provides a static wrapper to call into logger methods.
// Log messages will be logged to .Net Logger if an ILoggerFactory is injected by the host application.
// If not, then it will log to ArchestrA logger if it is installed in the local machine.
// </summary>
//
// This cs file is distributed with the VCP.Utils.Common.LoggerClient NuGet package so consuming projects
// can leverage this static helper.
//
// -------------------------------------------------------------------------------------------------------------

namespace AvevaApp
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    ///  The native methods. This class is private and cannnot be used consuming projects. Private, not exposed to consumers.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal static class NativeMethods
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("kernel32")]
        internal static extern IntPtr LoadLibraryW([MarshalAs(UnmanagedType.LPWStr)] string lpModule);

        /// <summary>
        ///     The register logger client.
        /// </summary>
        /// <param name="hIdentity">
        ///     The identity.
        /// </param>
        /// <returns>
        ///     int value denoting success or failure.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "REGISTERLOGGERCLIENT", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RegisterLoggerClient(ref int hIdentity);

        /// <summary>
        ///     The unregister logger client.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <returns>
        ///     int value denoting success or failure.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "UNREGISTERLOGGERCLIENT", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UnregisterLoggerClient(int hIdentity);

        /// <summary>
        ///     The set identity name.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="strIdentity">
        ///     The str identity.
        /// </param>
        /// <returns>
        ///     int value denoting success or failure.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "SETIDENTITYNAME", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetIdentityName(int hIdentity, string strIdentity);

        /// <summary>
        ///     The internal log error.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGERROR", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogError(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log warning.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGWARNING", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogWarning(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log info.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGINFO", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogInfo(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log trace.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGTRACE", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogTrace(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log start stop.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGSTARTSTOP", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogStartStop(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log entry exit.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGENTRYEXIT", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogEntryExit(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log thread start stop.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGTHREADSTARTSTOP", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogThreadStartStop(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log sql.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGSQL", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogSQL(int hIdentity, [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log connection.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGCONNECTION", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogConnection(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log ctor dtor.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGCTORDTOR", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogCtorDtor(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The internal log ref count.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="message">
        ///     The message.
        /// </param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGREFCOUNT", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogRefCount(
            int hIdentity,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        ///     The register log flag.
        /// </summary>
        /// <param name="hIdentity">
        ///     The h identity.
        /// </param>
        /// <param name="nCustomFlag">
        ///     The n custom flag.
        /// </param>
        /// <param name="strFlag">
        ///     The str flag.
        /// </param>
        /// <returns>
        ///     int value denoting success or failure.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "REGISTERLOGFLAG", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr RegisterLogFlag(int hIdentity, int nCustomFlag, [MarshalAs(UnmanagedType.LPWStr)] string strFlag);

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGCUSTOM2", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void LogCustom(
            int hIdentity,
            IntPtr customFlag,
            [MarshalAs(UnmanagedType.LPWStr)] string message);

        /// <summary>
        /// The get log flag.
        /// </summary>
        /// <param name="hIdentity">
        /// The h identity.
        /// </param>
        /// <param name="nFlag">
        /// The n flag.
        /// </param>
        /// <returns>
        /// integer pointer
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "GETLOGFLAG", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetLogFlag(int hIdentity, int nFlag);

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGFLAGLOG", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool LogFlagLog(int hIdentity, IntPtr logflag, int nFlag);

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Method does not have to be used by all clients of the Logger.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "LOGSTART", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int LogStart(int hIdentity);

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "This is shared code, not all consumers use all methods.")]
        [DllImport("LoggerDLL.dll", CharSet = CharSet.Unicode, EntryPoint = "GETLOGGERSTATS", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLoggerStats(
            [MarshalAs(UnmanagedType.LPWStr)] string hostName,
            ref int errorCount,
            ref long ftLastError,
            ref int warningCount,
            ref long ftLastWarning);
    }
}
