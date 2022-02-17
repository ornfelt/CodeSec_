using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Microsoft.AspNetCore.DataProtection;

namespace CodeSec.common
{
  public class IO
  {
    private static FileStream fStream;
    private static StreamWriter sWriter;
    private static StreamReader sReader;
    static IDataProtector protector;

    public IO (IDataProtectionProvider provider)
    {
      protector = provider.CreateProtector("IO");
    }

    public bool SaveText(String textToWrite)
    {
      string protectedText = protector.Protect(textToWrite);
      try
      {
        sWriter = new StreamWriter("ProtectedLogText.txt", true);
        sWriter.Write(protectedText + "\n");
        sWriter.Close();
        return true;
      }
      catch (IOException ex) { }
      {
        return false;
      }
    }

    public String PrintText() //Function used to get information from the log file
    {

      ArrayList fileText = new ArrayList();

      string fileToRead = @"ProtectedLogText.txt";
      if (File.Exists(fileToRead))
      {
        try
        {
          sReader = new StreamReader("ProtectedLogText.txt");
          string fileLine = sReader.ReadLine();
          while (fileLine != null)
          {
            fileText.Add(fileLine);
            fileLine = sReader.ReadLine();
          }
          sReader.Close();
        }
        catch (NullReferenceException e) { }
        catch (FileNotFoundException e) { }
      }
      else
      {
        fileText.Add("empty");
        fStream = new FileStream("ProtectedLogText.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        fStream.Dispose();
      }
      String tempString = "";
      string stringToReturn = "";
      foreach (var item in fileText)
      {
        tempString = (string)item;
        stringToReturn += protector.Unprotect(tempString);
      }
      return stringToReturn;
    }
  }
}
