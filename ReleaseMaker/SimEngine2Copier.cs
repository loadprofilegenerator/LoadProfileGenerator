﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace ReleaseMaker {
    public class SimEngine2Copier : CopierBase {
        public static void CopySimEngine2Files([NotNull] string src, [NotNull] string dst)
        {
            List<string> programFiles = new List<string>();
            Copy(programFiles, src, dst, "api-ms-win-core-console-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-datetime-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-debug-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-errorhandling-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l2-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-handle-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-heap-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-interlocked-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-libraryloader-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-localization-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-memory-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-namedpipe-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processenvironment-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processthreads-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processthreads-l1-1-1.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-profile-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-rtlsupport-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-string-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-synch-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-synch-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-sysinfo-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-timezone-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-util-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-conio-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-convert-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-environment-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-filesystem-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-heap-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-locale-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-math-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-multibyte-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-private-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-process-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-runtime-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-stdio-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-string-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-time-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-utility-l1-1-0.dll");
            Copy(programFiles, src, dst, "Autofac.dll");
            Copy(programFiles, src, dst, "Automation.dll");
            Copy(programFiles, src, dst, "CalcPostProcessor.dll");
            Copy(programFiles, src, dst, "CalculationController.dll");
            Copy(programFiles, src, dst, "CalculationEngine.dll");
            Copy(programFiles, src, dst, "clrcompression.dll");
            Copy(programFiles, src, dst, "clretwrc.dll");
            Copy(programFiles, src, dst, "clrjit.dll");
            Copy(programFiles, src, dst, "Common.dll");
            Copy(programFiles, src, dst, "coreclr.dll");
            Copy(programFiles, src, dst, "Database.dll");
            Copy(programFiles, src, dst, "dbgshim.dll");
            Copy(programFiles, src, dst, "EntityFramework.dll");
            Copy(programFiles, src, dst, "EntityFramework.SqlServer.dll");
            Copy(programFiles, src, dst, "hostfxr.dll");
            Copy(programFiles, src, dst, "hostpolicy.dll");
            Copy(programFiles, src, dst, "JetBrains.Annotations.dll");
            Copy(programFiles, src, dst, "Microsoft.CSharp.dll");
            Copy(programFiles, src, dst, "Microsoft.DiaSymReader.Native.amd64.dll");
            Copy(programFiles, src, dst, "Microsoft.VisualBasic.Core.dll");
            Copy(programFiles, src, dst, "Microsoft.VisualBasic.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.Primitives.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.Registry.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.SystemEvents.dll");
            Copy(programFiles, src, dst, "mscordaccore.dll");
            Copy(programFiles, src, dst, "mscordaccore_amd64_amd64_4.700.20.26901.dll");
            Copy(programFiles, src, dst, "mscordbi.dll");
            Copy(programFiles, src, dst, "mscorlib.dll");
            Copy(programFiles, src, dst, "mscorrc.debug.dll");
            Copy(programFiles, src, dst, "mscorrc.dll");
            Copy(programFiles, src, dst, "netstandard.dll");
            Copy(programFiles, src, dst, "Newtonsoft.Json.dll");
            Copy(programFiles, src, dst, "PowerArgs.dll");
            Copy(programFiles, src, dst, "simengine2.deps.json");
            Copy(programFiles, src, dst, "simengine2.dll");
            Copy(programFiles, src, dst, "simengine2.exe");
            Copy(programFiles, src, dst, "simengine2.runtimeconfig.dev.json");
            Copy(programFiles, src, dst, "simengine2.runtimeconfig.json");
            Copy(programFiles, src, dst, "SimulationEngineLib.dll");
            Copy(programFiles, src, dst, "sni.dll");
            Copy(programFiles, src, dst, "SOS_README.md");
            Copy(programFiles, src, dst, "SQLite.Interop.dll");
            Copy(programFiles, src, dst, "System.AppContext.dll");
            Copy(programFiles, src, dst, "System.Buffers.dll");
            Copy(programFiles, src, dst, "System.CodeDom.dll");
            Copy(programFiles, src, dst, "System.Collections.Concurrent.dll");
            Copy(programFiles, src, dst, "System.Collections.dll");
            Copy(programFiles, src, dst, "System.Collections.Immutable.dll");
            Copy(programFiles, src, dst, "System.Collections.NonGeneric.dll");
            Copy(programFiles, src, dst, "System.Collections.Specialized.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.Annotations.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.DataAnnotations.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.EventBasedAsync.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.Primitives.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.TypeConverter.dll");
            Copy(programFiles, src, dst, "System.Configuration.ConfigurationManager.dll");
            Copy(programFiles, src, dst, "System.Configuration.dll");
            Copy(programFiles, src, dst, "System.Console.dll");
            Copy(programFiles, src, dst, "System.Core.dll");
            Copy(programFiles, src, dst, "System.Data.Common.dll");
            Copy(programFiles, src, dst, "System.Data.DataSetExtensions.dll");
            Copy(programFiles, src, dst, "System.Data.dll");
            Copy(programFiles, src, dst, "System.Data.SqlClient.dll");
            Copy(programFiles, src, dst, "System.Data.SQLite.dll");
            Copy(programFiles, src, dst, "System.Data.SQLite.EF6.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Contracts.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Debug.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.DiagnosticSource.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.FileVersionInfo.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Process.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.StackTrace.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.TextWriterTraceListener.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Tools.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.TraceSource.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Tracing.dll");
            Copy(programFiles, src, dst, "System.dll");
            Copy(programFiles, src, dst, "System.Drawing.Common.dll");
            Copy(programFiles, src, dst, "System.Drawing.dll");
            Copy(programFiles, src, dst, "System.Drawing.Primitives.dll");
            Copy(programFiles, src, dst, "System.Dynamic.Runtime.dll");
            Copy(programFiles, src, dst, "System.Globalization.Calendars.dll");
            Copy(programFiles, src, dst, "System.Globalization.dll");
            Copy(programFiles, src, dst, "System.Globalization.Extensions.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.Brotli.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.FileSystem.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.ZipFile.dll");
            Copy(programFiles, src, dst, "System.IO.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.AccessControl.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.DriveInfo.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.Primitives.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.Watcher.dll");
            Copy(programFiles, src, dst, "System.IO.IsolatedStorage.dll");
            Copy(programFiles, src, dst, "System.IO.MemoryMappedFiles.dll");
            Copy(programFiles, src, dst, "System.IO.Pipes.AccessControl.dll");
            Copy(programFiles, src, dst, "System.IO.Pipes.dll");
            Copy(programFiles, src, dst, "System.IO.UnmanagedMemoryStream.dll");
            Copy(programFiles, src, dst, "System.Linq.dll");
            Copy(programFiles, src, dst, "System.Linq.Dynamic.Core.dll");
            Copy(programFiles, src, dst, "System.Linq.Expressions.dll");
            Copy(programFiles, src, dst, "System.Linq.Parallel.dll");
            Copy(programFiles, src, dst, "System.Linq.Queryable.dll");
            Copy(programFiles, src, dst, "System.Memory.dll");
            Copy(programFiles, src, dst, "System.Net.dll");
            Copy(programFiles, src, dst, "System.Net.Http.dll");
            Copy(programFiles, src, dst, "System.Net.HttpListener.dll");
            Copy(programFiles, src, dst, "System.Net.Mail.dll");
            Copy(programFiles, src, dst, "System.Net.NameResolution.dll");
            Copy(programFiles, src, dst, "System.Net.NetworkInformation.dll");
            Copy(programFiles, src, dst, "System.Net.Ping.dll");
            Copy(programFiles, src, dst, "System.Net.Primitives.dll");
            Copy(programFiles, src, dst, "System.Net.Requests.dll");
            Copy(programFiles, src, dst, "System.Net.Security.dll");
            Copy(programFiles, src, dst, "System.Net.ServicePoint.dll");
            Copy(programFiles, src, dst, "System.Net.Sockets.dll");
            Copy(programFiles, src, dst, "System.Net.WebClient.dll");
            Copy(programFiles, src, dst, "System.Net.WebHeaderCollection.dll");
            Copy(programFiles, src, dst, "System.Net.WebProxy.dll");
            Copy(programFiles, src, dst, "System.Net.WebSockets.Client.dll");
            Copy(programFiles, src, dst, "System.Net.WebSockets.dll");
            Copy(programFiles, src, dst, "System.Numerics.dll");
            Copy(programFiles, src, dst, "System.Numerics.Vectors.dll");
            Copy(programFiles, src, dst, "System.ObjectModel.dll");
            Copy(programFiles, src, dst, "System.Private.CoreLib.dll");
            Copy(programFiles, src, dst, "System.Private.DataContractSerialization.dll");
            Copy(programFiles, src, dst, "System.Private.Uri.dll");
            Copy(programFiles, src, dst, "System.Private.Xml.dll");
            Copy(programFiles, src, dst, "System.Private.Xml.Linq.dll");
            Copy(programFiles, src, dst, "System.Reflection.DispatchProxy.dll");
            Copy(programFiles, src, dst, "System.Reflection.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.ILGeneration.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.Lightweight.dll");
            Copy(programFiles, src, dst, "System.Reflection.Extensions.dll");
            Copy(programFiles, src, dst, "System.Reflection.Metadata.dll");
            Copy(programFiles, src, dst, "System.Reflection.Primitives.dll");
            Copy(programFiles, src, dst, "System.Reflection.TypeExtensions.dll");
            Copy(programFiles, src, dst, "System.Resources.Extensions.dll");
            Copy(programFiles, src, dst, "System.Resources.Reader.dll");
            Copy(programFiles, src, dst, "System.Resources.ResourceManager.dll");
            Copy(programFiles, src, dst, "System.Resources.Writer.dll");
            Copy(programFiles, src, dst, "System.Runtime.CompilerServices.Unsafe.dll");
            Copy(programFiles, src, dst, "System.Runtime.CompilerServices.VisualC.dll");
            Copy(programFiles, src, dst, "System.Runtime.dll");
            Copy(programFiles, src, dst, "System.Runtime.Extensions.dll");
            Copy(programFiles, src, dst, "System.Runtime.Handles.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.RuntimeInformation.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.WindowsRuntime.dll");
            Copy(programFiles, src, dst, "System.Runtime.Intrinsics.dll");
            Copy(programFiles, src, dst, "System.Runtime.Loader.dll");
            Copy(programFiles, src, dst, "System.Runtime.Numerics.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Formatters.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Json.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Primitives.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Xml.dll");
            Copy(programFiles, src, dst, "System.Runtime.WindowsRuntime.dll");
            Copy(programFiles, src, dst, "System.Runtime.WindowsRuntime.UI.Xaml.dll");
            Copy(programFiles, src, dst, "System.Security.AccessControl.dll");
            Copy(programFiles, src, dst, "System.Security.Claims.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Algorithms.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Cng.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Csp.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Encoding.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.OpenSsl.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Primitives.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.ProtectedData.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.X509Certificates.dll");
            Copy(programFiles, src, dst, "System.Security.dll");
            Copy(programFiles, src, dst, "System.Security.Permissions.dll");
            Copy(programFiles, src, dst, "System.Security.Principal.dll");
            Copy(programFiles, src, dst, "System.Security.Principal.Windows.dll");
            Copy(programFiles, src, dst, "System.Security.SecureString.dll");
            Copy(programFiles, src, dst, "System.ServiceModel.Web.dll");
            Copy(programFiles, src, dst, "System.ServiceProcess.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.CodePages.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.Extensions.dll");
            Copy(programFiles, src, dst, "System.Text.Encodings.Web.dll");
            Copy(programFiles, src, dst, "System.Text.Json.dll");
            Copy(programFiles, src, dst, "System.Text.RegularExpressions.dll");
            Copy(programFiles, src, dst, "System.Threading.Channels.dll");
            Copy(programFiles, src, dst, "System.Threading.dll");
            Copy(programFiles, src, dst, "System.Threading.Overlapped.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Dataflow.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Extensions.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Parallel.dll");
            Copy(programFiles, src, dst, "System.Threading.Thread.dll");
            Copy(programFiles, src, dst, "System.Threading.ThreadPool.dll");
            Copy(programFiles, src, dst, "System.Threading.Timer.dll");
            Copy(programFiles, src, dst, "System.Transactions.dll");
            Copy(programFiles, src, dst, "System.Transactions.Local.dll");
            Copy(programFiles, src, dst, "System.ValueTuple.dll");
            Copy(programFiles, src, dst, "System.Web.dll");
            Copy(programFiles, src, dst, "System.Web.HttpUtility.dll");
            Copy(programFiles, src, dst, "System.Windows.dll");
            Copy(programFiles, src, dst, "System.Windows.Extensions.dll");
            Copy(programFiles, src, dst, "System.Xml.dll");
            Copy(programFiles, src, dst, "System.Xml.Linq.dll");
            Copy(programFiles, src, dst, "System.Xml.ReaderWriter.dll");
            Copy(programFiles, src, dst, "System.Xml.Serialization.dll");
            Copy(programFiles, src, dst, "System.Xml.XDocument.dll");
            Copy(programFiles, src, dst, "System.Xml.XmlDocument.dll");
            Copy(programFiles, src, dst, "System.Xml.XmlSerializer.dll");
            Copy(programFiles, src, dst, "System.Xml.XPath.dll");
            Copy(programFiles, src, dst, "System.Xml.XPath.XDocument.dll");
            Copy(programFiles, src, dst, "ucrtbase.dll");
            Copy(programFiles, src, dst, "WindowsBase.dll");
            Copy(programFiles, src, dst, "xunit.abstractions.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-console-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-datetime-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-debug-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-errorhandling-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-file-l2-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-handle-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-heap-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-interlocked-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-libraryloader-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-localization-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-memory-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-namedpipe-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processenvironment-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processthreads-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-processthreads-l1-1-1.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-profile-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-rtlsupport-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-string-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-synch-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-synch-l1-2-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-sysinfo-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-timezone-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-core-util-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-conio-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-convert-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-environment-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-filesystem-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-heap-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-locale-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-math-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-multibyte-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-private-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-process-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-runtime-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-stdio-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-string-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-time-l1-1-0.dll");
            Copy(programFiles, src, dst, "api-ms-win-crt-utility-l1-1-0.dll");
            Copy(programFiles, src, dst, "Autofac.dll");
            Copy(programFiles, src, dst, "Automation.dll");
            Copy(programFiles, src, dst, "CalcPostProcessor.dll");
            Copy(programFiles, src, dst, "CalculationController.dll");
            Copy(programFiles, src, dst, "CalculationEngine.dll");
            Copy(programFiles, src, dst, "clrcompression.dll");
            Copy(programFiles, src, dst, "clretwrc.dll");
            Copy(programFiles, src, dst, "clrjit.dll");
            Copy(programFiles, src, dst, "Common.dll");
            Copy(programFiles, src, dst, "coreclr.dll");
            Copy(programFiles, src, dst, "Database.dll");
            Copy(programFiles, src, dst, "dbgshim.dll");
            Copy(programFiles, src, dst, "EntityFramework.dll");
            Copy(programFiles, src, dst, "EntityFramework.SqlServer.dll");
            Copy(programFiles, src, dst, "hostfxr.dll");
            Copy(programFiles, src, dst, "hostpolicy.dll");
            Copy(programFiles, src, dst, "JetBrains.Annotations.dll");
            Copy(programFiles, src, dst, "Microsoft.CSharp.dll");
            Copy(programFiles, src, dst, "Microsoft.DiaSymReader.Native.amd64.dll");
            Copy(programFiles, src, dst, "Microsoft.VisualBasic.Core.dll");
            Copy(programFiles, src, dst, "Microsoft.VisualBasic.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.Primitives.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.Registry.dll");
            Copy(programFiles, src, dst, "Microsoft.Win32.SystemEvents.dll");
            Copy(programFiles, src, dst, "mscordaccore.dll");
            Copy(programFiles, src, dst, "mscordaccore_amd64_amd64_4.700.20.26901.dll");
            Copy(programFiles, src, dst, "mscordbi.dll");
            Copy(programFiles, src, dst, "mscorlib.dll");
            Copy(programFiles, src, dst, "mscorrc.debug.dll");
            Copy(programFiles, src, dst, "mscorrc.dll");
            Copy(programFiles, src, dst, "netstandard.dll");
            Copy(programFiles, src, dst, "Newtonsoft.Json.dll");
            Copy(programFiles, src, dst, "PowerArgs.dll");
            Copy(programFiles, src, dst, "simengine2.deps.json");
            Copy(programFiles, src, dst, "simengine2.dll");
            Copy(programFiles, src, dst, "simengine2.exe");
            Copy(programFiles, src, dst, "simengine2.runtimeconfig.json");
            Copy(programFiles, src, dst, "SimulationEngineLib.dll");
            Copy(programFiles, src, dst, "sni.dll");
            Copy(programFiles, src, dst, "SOS_README.md");
            Copy(programFiles, src, dst, "SQLite.Interop.dll");
            Copy(programFiles, src, dst, "System.AppContext.dll");
            Copy(programFiles, src, dst, "System.Buffers.dll");
            Copy(programFiles, src, dst, "System.CodeDom.dll");
            Copy(programFiles, src, dst, "System.Collections.Concurrent.dll");
            Copy(programFiles, src, dst, "System.Collections.dll");
            Copy(programFiles, src, dst, "System.Collections.Immutable.dll");
            Copy(programFiles, src, dst, "System.Collections.NonGeneric.dll");
            Copy(programFiles, src, dst, "System.Collections.Specialized.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.Annotations.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.DataAnnotations.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.EventBasedAsync.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.Primitives.dll");
            Copy(programFiles, src, dst, "System.ComponentModel.TypeConverter.dll");
            Copy(programFiles, src, dst, "System.Configuration.ConfigurationManager.dll");
            Copy(programFiles, src, dst, "System.Configuration.dll");
            Copy(programFiles, src, dst, "System.Console.dll");
            Copy(programFiles, src, dst, "System.Core.dll");
            Copy(programFiles, src, dst, "System.Data.Common.dll");
            Copy(programFiles, src, dst, "System.Data.DataSetExtensions.dll");
            Copy(programFiles, src, dst, "System.Data.dll");
            Copy(programFiles, src, dst, "System.Data.SqlClient.dll");
            Copy(programFiles, src, dst, "System.Data.SQLite.dll");
            Copy(programFiles, src, dst, "System.Data.SQLite.EF6.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Contracts.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Debug.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.DiagnosticSource.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.FileVersionInfo.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Process.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.StackTrace.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.TextWriterTraceListener.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Tools.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.TraceSource.dll");
            Copy(programFiles, src, dst, "System.Diagnostics.Tracing.dll");
            Copy(programFiles, src, dst, "System.dll");
            Copy(programFiles, src, dst, "System.Drawing.Common.dll");
            Copy(programFiles, src, dst, "System.Drawing.dll");
            Copy(programFiles, src, dst, "System.Drawing.Primitives.dll");
            Copy(programFiles, src, dst, "System.Dynamic.Runtime.dll");
            Copy(programFiles, src, dst, "System.Globalization.Calendars.dll");
            Copy(programFiles, src, dst, "System.Globalization.dll");
            Copy(programFiles, src, dst, "System.Globalization.Extensions.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.Brotli.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.FileSystem.dll");
            Copy(programFiles, src, dst, "System.IO.Compression.ZipFile.dll");
            Copy(programFiles, src, dst, "System.IO.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.AccessControl.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.DriveInfo.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.Primitives.dll");
            Copy(programFiles, src, dst, "System.IO.FileSystem.Watcher.dll");
            Copy(programFiles, src, dst, "System.IO.IsolatedStorage.dll");
            Copy(programFiles, src, dst, "System.IO.MemoryMappedFiles.dll");
            Copy(programFiles, src, dst, "System.IO.Pipes.AccessControl.dll");
            Copy(programFiles, src, dst, "System.IO.Pipes.dll");
            Copy(programFiles, src, dst, "System.IO.UnmanagedMemoryStream.dll");
            Copy(programFiles, src, dst, "System.Linq.dll");
            Copy(programFiles, src, dst, "System.Linq.Dynamic.Core.dll");
            Copy(programFiles, src, dst, "System.Linq.Expressions.dll");
            Copy(programFiles, src, dst, "System.Linq.Parallel.dll");
            Copy(programFiles, src, dst, "System.Linq.Queryable.dll");
            Copy(programFiles, src, dst, "System.Memory.dll");
            Copy(programFiles, src, dst, "System.Net.dll");
            Copy(programFiles, src, dst, "System.Net.Http.dll");
            Copy(programFiles, src, dst, "System.Net.HttpListener.dll");
            Copy(programFiles, src, dst, "System.Net.Mail.dll");
            Copy(programFiles, src, dst, "System.Net.NameResolution.dll");
            Copy(programFiles, src, dst, "System.Net.NetworkInformation.dll");
            Copy(programFiles, src, dst, "System.Net.Ping.dll");
            Copy(programFiles, src, dst, "System.Net.Primitives.dll");
            Copy(programFiles, src, dst, "System.Net.Requests.dll");
            Copy(programFiles, src, dst, "System.Net.Security.dll");
            Copy(programFiles, src, dst, "System.Net.ServicePoint.dll");
            Copy(programFiles, src, dst, "System.Net.Sockets.dll");
            Copy(programFiles, src, dst, "System.Net.WebClient.dll");
            Copy(programFiles, src, dst, "System.Net.WebHeaderCollection.dll");
            Copy(programFiles, src, dst, "System.Net.WebProxy.dll");
            Copy(programFiles, src, dst, "System.Net.WebSockets.Client.dll");
            Copy(programFiles, src, dst, "System.Net.WebSockets.dll");
            Copy(programFiles, src, dst, "System.Numerics.dll");
            Copy(programFiles, src, dst, "System.Numerics.Vectors.dll");
            Copy(programFiles, src, dst, "System.ObjectModel.dll");
            Copy(programFiles, src, dst, "System.Private.CoreLib.dll");
            Copy(programFiles, src, dst, "System.Private.DataContractSerialization.dll");
            Copy(programFiles, src, dst, "System.Private.Uri.dll");
            Copy(programFiles, src, dst, "System.Private.Xml.dll");
            Copy(programFiles, src, dst, "System.Private.Xml.Linq.dll");
            Copy(programFiles, src, dst, "System.Reflection.DispatchProxy.dll");
            Copy(programFiles, src, dst, "System.Reflection.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.ILGeneration.dll");
            Copy(programFiles, src, dst, "System.Reflection.Emit.Lightweight.dll");
            Copy(programFiles, src, dst, "System.Reflection.Extensions.dll");
            Copy(programFiles, src, dst, "System.Reflection.Metadata.dll");
            Copy(programFiles, src, dst, "System.Reflection.Primitives.dll");
            Copy(programFiles, src, dst, "System.Reflection.TypeExtensions.dll");
            Copy(programFiles, src, dst, "System.Resources.Extensions.dll");
            Copy(programFiles, src, dst, "System.Resources.Reader.dll");
            Copy(programFiles, src, dst, "System.Resources.ResourceManager.dll");
            Copy(programFiles, src, dst, "System.Resources.Writer.dll");
            Copy(programFiles, src, dst, "System.Runtime.CompilerServices.Unsafe.dll");
            Copy(programFiles, src, dst, "System.Runtime.CompilerServices.VisualC.dll");
            Copy(programFiles, src, dst, "System.Runtime.dll");
            Copy(programFiles, src, dst, "System.Runtime.Extensions.dll");
            Copy(programFiles, src, dst, "System.Runtime.Handles.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.RuntimeInformation.dll");
            Copy(programFiles, src, dst, "System.Runtime.InteropServices.WindowsRuntime.dll");
            Copy(programFiles, src, dst, "System.Runtime.Intrinsics.dll");
            Copy(programFiles, src, dst, "System.Runtime.Loader.dll");
            Copy(programFiles, src, dst, "System.Runtime.Numerics.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Formatters.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Json.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Primitives.dll");
            Copy(programFiles, src, dst, "System.Runtime.Serialization.Xml.dll");
            Copy(programFiles, src, dst, "System.Runtime.WindowsRuntime.dll");
            Copy(programFiles, src, dst, "System.Runtime.WindowsRuntime.UI.Xaml.dll");
            Copy(programFiles, src, dst, "System.Security.AccessControl.dll");
            Copy(programFiles, src, dst, "System.Security.Claims.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Algorithms.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Cng.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Csp.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Encoding.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.OpenSsl.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.Primitives.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.ProtectedData.dll");
            Copy(programFiles, src, dst, "System.Security.Cryptography.X509Certificates.dll");
            Copy(programFiles, src, dst, "System.Security.dll");
            Copy(programFiles, src, dst, "System.Security.Permissions.dll");
            Copy(programFiles, src, dst, "System.Security.Principal.dll");
            Copy(programFiles, src, dst, "System.Security.Principal.Windows.dll");
            Copy(programFiles, src, dst, "System.Security.SecureString.dll");
            Copy(programFiles, src, dst, "System.ServiceModel.Web.dll");
            Copy(programFiles, src, dst, "System.ServiceProcess.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.CodePages.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.dll");
            Copy(programFiles, src, dst, "System.Text.Encoding.Extensions.dll");
            Copy(programFiles, src, dst, "System.Text.Encodings.Web.dll");
            Copy(programFiles, src, dst, "System.Text.Json.dll");
            Copy(programFiles, src, dst, "System.Text.RegularExpressions.dll");
            Copy(programFiles, src, dst, "System.Threading.Channels.dll");
            Copy(programFiles, src, dst, "System.Threading.dll");
            Copy(programFiles, src, dst, "System.Threading.Overlapped.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Dataflow.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Extensions.dll");
            Copy(programFiles, src, dst, "System.Threading.Tasks.Parallel.dll");
            Copy(programFiles, src, dst, "System.Threading.Thread.dll");
            Copy(programFiles, src, dst, "System.Threading.ThreadPool.dll");
            Copy(programFiles, src, dst, "System.Threading.Timer.dll");
            Copy(programFiles, src, dst, "System.Transactions.dll");
            Copy(programFiles, src, dst, "System.Transactions.Local.dll");
            Copy(programFiles, src, dst, "System.ValueTuple.dll");
            Copy(programFiles, src, dst, "System.Web.dll");
            Copy(programFiles, src, dst, "System.Web.HttpUtility.dll");
            Copy(programFiles, src, dst, "System.Windows.dll");
            Copy(programFiles, src, dst, "System.Windows.Extensions.dll");
            Copy(programFiles, src, dst, "System.Xml.dll");
            Copy(programFiles, src, dst, "System.Xml.Linq.dll");
            Copy(programFiles, src, dst, "System.Xml.ReaderWriter.dll");
            Copy(programFiles, src, dst, "System.Xml.Serialization.dll");
            Copy(programFiles, src, dst, "System.Xml.XDocument.dll");
            Copy(programFiles, src, dst, "System.Xml.XmlDocument.dll");
            Copy(programFiles, src, dst, "System.Xml.XmlSerializer.dll");
            Copy(programFiles, src, dst, "System.Xml.XPath.dll");
            Copy(programFiles, src, dst, "System.Xml.XPath.XDocument.dll");
            Copy(programFiles, src, dst, "ucrtbase.dll");
            Copy(programFiles, src, dst, "WindowsBase.dll");
            Copy(programFiles, src, dst, "xunit.abstractions.dll");
            CheckIfFilesAreCompletelyCopied(src, programFiles);
        }
    }
}