using System.IO;
using System.Text;

string fileName = @"file01.dat";

string text = @"Закрывает текущий поток и отключает все ресурсы (например, сокеты и файловые дескрипторы), связанные с текущим потоком. Вместо вызова данного метода, убедитесь в том, что поток надлежащим образом ликвидирован.\r\n\r\n(Унаследовано от Stream)";

using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
{
    Console.WriteLine(fileStream.Name);
    Console.WriteLine(fileStream.Length);
    Console.WriteLine(fileStream.Position);

    //fileStream.Write(Encoding.UTF8.GetBytes(text));
    byte[] buffer = new byte[10];

    while (fileStream.Read(buffer, 0, buffer.Length - 1) != 0)
    {
        //fileStream.Read(buffer, 0, buffer.Length);
        Console.Write(Encoding.Default.GetString(buffer));
        Array.Clear(buffer);
    }


}


using (StreamWriter writer = new(fileName))
{
    writer.Write(text);
}

using (StreamReader reader = new(fileName))
{
    var txt = reader.ReadToEnd();
    Console.WriteLine(txt);
}



