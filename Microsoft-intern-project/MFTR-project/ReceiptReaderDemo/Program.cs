using System;
using System.IO;
using System.Threading.Tasks;
using ReceiptReaderDemo;

class Program
{
    static async Task Main()
    {
        try
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();

            if (commandLineArgs.Length < 2)
            {
                Console.WriteLine("Please provide a file path as a command line argument.");
                return;
            }

            string path = commandLineArgs[1];

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File not found at {path}");
            }

            Console.WriteLine(" Receipt Loaded, reading its contents");
            ReceiptReader receiptReader = new ReceiptReader();
            string content = await receiptReader.Read(path);
            Console.WriteLine("\t Processing Sucessful");

            Console.WriteLine(content);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            // Additional handling steps, if needed
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
            // Additional handling steps, if needed
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
            // Additional handling steps, if needed
        }
    }
}
