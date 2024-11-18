int[] numbers = new int[5];
int[] specificNumbers = {1, 2, 3, 4, 5};

int firstNumber = specificNumbers[0];
Console.WriteLine(firstNumber);

int lastNumber = specificNumbers[specificNumbers.Length - 1];
Console.WriteLine(lastNumber);
Console.WriteLine();

for(int i = 0; i < specificNumbers.Length; i++) {
  specificNumbers[i] = specificNumbers[i] * 2; 
  //Console.WriteLine(specificNumbers[i]);
}
Console.WriteLine();

foreach(int num in specificNumbers) {
  Console.WriteLine(num);
}

Console.WriteLine();

string[] fruits = {"Cherry", "Banana", "Apple"};
Array.Sort(fruits);
Console.WriteLine(String.Join(",", fruits));

int index = Array.IndexOf(fruits, "Cherry");
Console.WriteLine(index);