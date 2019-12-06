using System;
using System.IO.Pipes;
using StreamJsonRpc;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyLsp
{
    class Program
    {
        public static Process process;
        public static Stream stdin;
        public static Stream stdout;
        public static Stream process_stdin;
        public static Stream process_stdout;
        public static JsonRpc rpc_client;
        public static JsonRpc rpc_server;

        static void Main(string[] args)
        {
            TimeSpan delay = new TimeSpan(0, 0, 0, 30);
            Console.Error.WriteLine("Waiting " + delay + " seconds...");
            Thread.Sleep((int)delay.TotalMilliseconds);
            var program = new Program();
            program.MainAsync(args).GetAwaiter().GetResult();
        }

        public static T[] SubArray<T>(T[] data, int index)
        {
            var length = data.Length - index;
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        async Task MainAsync(string[] args)
        {
            Console.Error.WriteLine("Connecting to server " + args[0]);
            var server_executable = args[0];
            var working_directory = Directory.GetCurrentDirectory();
            var server_arguments = String.Join(" ", SubArray(args, 1));
            TextReader x = System.Console.In as TextReader;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = server_executable;
            info.WorkingDirectory = working_directory;
            info.Arguments = server_arguments;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = false;
            process = new Process();
            process.StartInfo = info;
            if (!process.Start())
            {
                System.Console.Error.WriteLine("Failure in spawning process.");
                return;
            }

            // Set up listening of client reader with stdin.
            stdin = Console.OpenStandardInput();
            stdout = Console.OpenStandardOutput();
            process_stdin = process.StandardOutput.BaseStream;
            process_stdout = process.StandardInput.BaseStream;
            rpc_client = JsonRpc.Attach(stdout, stdin, new LanguageServerTarget("client"));
            rpc_server = JsonRpc.Attach(process_stdout, process_stdin, new LanguageServerTarget("server"));

            await Task.Delay(-1);
        }

        private static async Task ResponseToRpcRequestsAsync(NamedPipeServerStream stream, int clientId)
        {
            // Forward to server.
            Program.process.StandardInput.WriteLine();
        }
    }
}
