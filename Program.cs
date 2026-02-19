using System;
namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

      Console.WriteLine("Write your secret message:");
      string secretMessage = Console.ReadLine();
      
      char[] msgArray = secretMessage.ToCharArray();
      char[] encryptedMessage = new char[msgArray.Length];
      
      Console.Write("Enter shift value: ");
      int shift = int.Parse(Console.ReadLine());

      for(int i = 0; i < secretMessage.Length; i++){
        char currentChar =  msgArray[i];
        char lowerChar = char.ToLower(currentChar);

        int index = Array.IndexOf(alphabet, lowerChar);
        if (index == -1){
          encryptedMessage[i] = currentChar;
          continue;
        }
        int shiftedIndex = (index + shift) % 26;
        char encryptedChar = alphabet[shiftedIndex];
        encryptedMessage[i] = encryptedChar;
      }
      string encryptedString = String.Join("", encryptedMessage);
      Console.WriteLine("Encrypted message: " + encryptedString);
    }
  }
}