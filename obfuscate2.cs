using System;
using System.Management.Automation;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Check if a cleartext command is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a PowerShell command as an argument.");
            return;
        }

        // Combine all command-line arguments into a single command string
        string command = string.Join(" ", args);

        try
        {
            // Encode the command to base64
            byte[] commandBytes = Encoding.UTF8.GetBytes(command);
            string encodedCommand = Convert.ToBase64String(commandBytes);

            // Decode the base64 command (for demonstration purposes, normally you would execute the cleartext command directly)
            byte[] data = Convert.FromBase64String(encodedCommand);
            string decodedCommand = Encoding.UTF8.GetString(data);

            // Create a PowerShell instance
            using (PowerShell ps = PowerShell.Create())
            {
                // Add the decoded command to the PowerShell instance
                ps.AddScript(decodedCommand);

                // Invoke the command and get the results
                var results = ps.Invoke();

                // Display the results
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("There was an error in encoding or decoding the base64 string.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

