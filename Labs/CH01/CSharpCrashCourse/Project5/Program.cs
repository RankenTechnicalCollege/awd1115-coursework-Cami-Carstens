string userCCNum = string.Empty;

if (args.Length > 0 && string.IsNullOrEmpty(userCCNum))
{
    userCCNum = args[0];
}
else
{
    Console.WriteLine("Please enter your credit card number:");
    userCCNum = Console.ReadLine();
}

string ccNumMasked = string.Empty;

for(int index = 0; index < userCCNum.Length; index++)
{
    if (userCCNum[index] == '-' 
        || Char.IsWhiteSpace(userCCNum[index])
        || index >= userCCNum.Length -4)
    {
        ccNumMasked += userCCNum[index];
    }
    else
    {
        ccNumMasked += 'X';
    }
}
Console.WriteLine($"{ccNumMasked}");