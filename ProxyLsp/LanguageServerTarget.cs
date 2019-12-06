using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.LanguageServer.Protocol;
using Newtonsoft.Json.Linq;
using StreamJsonRpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyLsp
{
    public class LanguageServerTarget
    {
        private string who;
        private static int times = 0;

        public LanguageServerTarget(string w)
        {
            who = w;
        }

        // ======= GENERAL ========

        [JsonRpcMethod(Methods.InitializeName)]
        public async System.Threading.Tasks.Task<JToken> InitializeNameAsync(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.InitializeName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.InitializedName)]
        public async void InitializedName(JToken arg)
        {
            times += 1;
            if (times > 1)
                throw new Exception();
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.InitializedName, arg);
        }

        [JsonRpcMethod(Methods.ShutdownName)]
        public async System.Threading.Tasks.Task<JToken> ShutdownName()
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.ShutdownName);
            return result;
        }

        [JsonRpcMethod(Methods.ExitName)]
        public async void ExitName()
        {
            await Program.rpc_server.NotifyAsync(Methods.ExitName);
        }

        // ======= WINDOW ========

        [JsonRpcMethod(Methods.WindowShowMessageName)]
        public async void WindowShowMessageName(JToken arg)
        {
            await Program.rpc_client.NotifyWithParameterObjectAsync(Methods.WindowShowMessageName, arg);
        }

        [JsonRpcMethod(Methods.WindowShowMessageRequestName)]
        public async System.Threading.Tasks.Task<JToken> WindowShowMessageRequestName(JToken arg)
        {
            var result = await Program.rpc_client.InvokeWithParameterObjectAsync<JToken>(Methods.WindowShowMessageRequestName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.WindowLogMessageName)]
        public async void WindowLogMessageName(JToken arg)
        {
            await Program.rpc_client.NotifyWithParameterObjectAsync(Methods.WindowLogMessageName, arg);
        }


        // ======= TELEMETRY ========

        [JsonRpcMethod(Methods.TelemetryEventName)]
        public async void TelemetryEventName(JToken arg)
        {
            await Program.rpc_client.NotifyWithParameterObjectAsync(Methods.TelemetryEventName, arg);
        }

        // ======= CLIENT ========

        [JsonRpcMethod(Methods.ClientRegisterCapabilityName)]
        public async System.Threading.Tasks.Task<JToken> ClientRegisterCapabilityName(JToken arg)
        {
            var result = await Program.rpc_client.InvokeWithParameterObjectAsync<JToken>(Methods.ClientRegisterCapabilityName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.ClientUnregisterCapabilityName)]
        public async System.Threading.Tasks.Task<JToken> ClientUnregisterCapabilityName(JToken arg)
        {
            var result = await Program.rpc_client.InvokeWithParameterObjectAsync<JToken>(Methods.ClientUnregisterCapabilityName, arg);
            return result;
        }

        // ======= WORKSPACE ========

        [JsonRpcMethod(Methods.WorkspaceDidChangeConfigurationName)]
        public async void WorkspaceDidChangeConfigurationName(JToken arg)
        {
            await Program.rpc_server.InvokeWithParameterObjectAsync<object>(Methods.WorkspaceDidChangeConfigurationName);
        }

        [JsonRpcMethod(Methods.WorkspaceDidChangeWatchedFilesName)]
        public async void WorkspaceDidChangeWatchedFilesName(JToken arg)
        {
            await Program.rpc_server.InvokeWithParameterObjectAsync<object>(Methods.WorkspaceDidChangeWatchedFilesName);
        }

        [JsonRpcMethod(Methods.WorkspaceSymbolName)]
        public async System.Threading.Tasks.Task<JToken> WorkspaceSymbolName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.WorkspaceSymbolName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.WorkspaceExecuteCommandName)]
        public async System.Threading.Tasks.Task<JToken> WorkspaceExecuteCommandName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.WorkspaceExecuteCommandName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.WorkspaceApplyEditName)]
        public async System.Threading.Tasks.Task<JToken> WorkspaceApplyEditName(JToken arg)
        {
            var result = await Program.rpc_client.InvokeWithParameterObjectAsync<JToken>(Methods.WorkspaceApplyEditName, arg);
            return result;
        }


        // ======= TEXT SYNCHRONIZATION ========

        [JsonRpcMethod(Methods.TextDocumentDidOpenName)]
        public async void TextDocumentDidOpenName(JToken arg)
        {
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.TextDocumentDidOpenName, arg);
        }

        [JsonRpcMethod(Methods.TextDocumentDidChangeName)]
        public async void TextDocumentDidChangeName(JToken arg)
        {
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.TextDocumentDidChangeName, arg);
        }

        [JsonRpcMethod(Methods.TextDocumentWillSaveName)]
        public async void TextDocumentWillSaveName(JToken arg)
        {
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.TextDocumentWillSaveName, arg);
        }

        [JsonRpcMethod(Methods.TextDocumentWillSaveWaitUntilName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentWillSaveWaitUntilName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentWillSaveWaitUntilName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentDidSaveName)]
        public async void TextDocumentDidSaveName(JToken arg)
        {
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.TextDocumentDidSaveName, arg);
        }

        [JsonRpcMethod(Methods.TextDocumentDidCloseName)]
        public async void TextDocumentDidCloseName(JToken arg)
        {
            await Program.rpc_server.NotifyWithParameterObjectAsync(Methods.TextDocumentDidCloseName, arg);
        }

        // ======= DIAGNOSTICS ========

        [JsonRpcMethod(Methods.TextDocumentPublishDiagnosticsName)]
        public async void TextDocumentPublishDiagnosticsName(JToken arg)
        {
            await Program.rpc_client.NotifyWithParameterObjectAsync(Methods.TextDocumentPublishDiagnosticsName, arg);
        }

        // ======= LANGUAGE FEATURES ========

        [JsonRpcMethod(Methods.TextDocumentCompletionName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentCompletionName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentCompletionName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentCompletionResolveName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentCompletionResolveName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentCompletionResolveName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentHoverName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentHoverName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentHoverName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentSignatureHelpName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentSignatureHelpName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentSignatureHelpName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentDefinitionName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentDefinitionName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentDefinitionName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentTypeDefinitionName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentTypeDefinitionName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentTypeDefinitionName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentImplementationName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentImplementationName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentImplementationName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentReferencesName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentReferencesName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentReferencesName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentDocumentHighlightName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentDocumentHighlightName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentDocumentHighlightName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentDocumentSymbolName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentDocumentSymbolName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentDocumentSymbolName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentCodeActionName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentCodeActionName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentCodeActionName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentCodeLensName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentCodeLensName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentCodeLensName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.CodeLensResolveName)]
        public async System.Threading.Tasks.Task<JToken> CodeLensResolveName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.CodeLensResolveName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentDocumentLinkName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentDocumentLinkName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentDocumentLinkName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.DocumentLinkResolveName)]
        public async System.Threading.Tasks.Task<JToken> DocumentLinkResolveName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.DocumentLinkResolveName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentFormattingName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentFormattingName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentFormattingName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentRangeFormattingName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentRangeFormattingName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentRangeFormattingName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentOnTypeFormattingName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentOnTypeFormattingName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentOnTypeFormattingName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentRenameName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentRenameName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentRenameName, arg);
            return result;
        }

        [JsonRpcMethod(Methods.TextDocumentFoldingRangeName)]
        public async System.Threading.Tasks.Task<JToken> TextDocumentFoldingRangeName(JToken arg)
        {
            var result = await Program.rpc_server.InvokeWithParameterObjectAsync<JToken>(Methods.TextDocumentFoldingRangeName, arg);
            return result;
        }
    }
}