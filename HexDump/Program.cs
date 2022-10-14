using System;
using System.IO;
using System.Text;

namespace HexDump
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = 0;

            /*
            using (var reader = new StreamReader("textdata.txt"))
            {
                while (!reader.EndOfStream)
                {
                    // Read up to the next 16 bytes from the file into a byte array
                    var buffer = new char[16];
                    var bytesRead = reader.ReadBlock(buffer, 0, 16);

                    // Write the position/offset in hex, suffixed by a colon and space
                    Console.Write("{0:x4} ", position);
                    position += bytesRead;

                    // Writes hex value of each character in the byte array
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write("{0:x2} ", (byte)buffer[i]);
                        else Console.Write("   ");
                        if (i == 7) Console.Write("-- ");
                    }

                    // Writes the actual characters in the byte array
                    var bufferContents = new string(buffer);
                    Console.WriteLine("   {0}", bufferContents.Substring(0, bytesRead));
                }
            }
            */

            /*
            using (Stream input = File.OpenRead("binarydata.dat"))
            {
                var buffer = new byte[16];
                while (position < input.Length)
                {
                    // Read up to the next 16 bytes from the file into a byte array
                    var bytesRead = input.Read(buffer, 0, buffer.Length);

                    // Write the position/offset in hex, suffixed by a colon and space
                    Console.Write("{0:x4} ", position);
                    position += bytesRead;

                    // Writes hex value of each character in the byte array
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write("{0:x2} ", (byte)buffer[i]);
                        else Console.Write("   ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';
                    }

                    // Writes the actual characters in the byte array
                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("   {0}", bufferContents.Substring(0, bytesRead));
                }
            */

            using (Stream input = File.OpenRead(args[0]))
            {
                var buffer = new byte[16];
                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Write the position/offset in hex, suffixed by a colon and space
                    Console.Write("{0:x4} ", position);
                    position += bytesRead;

                    // Writes hex value of each character in the byte array
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write("{0:x2} ", (byte)buffer[i]);
                        else Console.Write("   ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';
                    }

                    // Writes the actual characters in the byte array
                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine("   {0}", bufferContents.Substring(0, bytesRead));
                }

            }
         }
    }
}
